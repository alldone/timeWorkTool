using WorkTools.Code;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using WorkTools.Code.Model;
using System.Threading;

namespace WorkTools {
    public partial class MainForm : Form {
        private static SessionSwitchEventHandler sseh;
        private static FileSystemWatcher watcher;
        private Thread demoThread;

        public MainForm() {
            InitializeComponent();
            startMonitor();
        }
        private void open(Form fc) {
            fc.MdiParent = this;
            fc.Show();
        }
        private void dayLogToolStripMenuItem_Click(object sender, EventArgs e) {
            open(new frmDayLog());
        }
        private void configurationToolStripMenuItem_Click(object sender, EventArgs e) {
            open(new frmConfiguration(this));
        }
        private void Form1_Load(object sender, EventArgs e) {

        }




        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e) {
            Console.WriteLine(e.Reason.ToString());
            DataManager.store(e.Reason, DateTime.Now);
        }
        public void updatePath(string newPAth) {
            watcher.Path = newPAth;
        }
        private void startMonitor() {
            sseh = new SessionSwitchEventHandler(SystemEvents_SessionSwitch);
            SystemEvents.SessionSwitch += sseh;
            DataManager.storeStartPresence(DateTime.Now);
            Configuration c = DataManagerConf.read().FirstOrDefault();
            if (c == null) {
                c = new Configuration();
                c.PathToWatch = Directory.GetCurrentDirectory();
            }
            watcher = new FileSystemWatcher();
            watcher.Path = c.PathToWatch;
            watcher.NotifyFilter = NotifyFilters.LastWrite;

            /* NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                    | NotifyFilters.FileName | NotifyFilters.DirectoryName;
     */
            watcher.Filter = "*.*";
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }


        delegate void ssDelegato(FileSystemEventArgs e);
        public List<String> f = new List<String>();
        private void ss(FileSystemEventArgs e) {
            if (!e.FullPath.Contains(".tmp") && !e.FullPath.Contains(".crdownload") && !f.Contains(e.FullPath)) {
                f.Add(e.FullPath);
                this.WindowState = FormWindowState.Maximized;
                open(new frmMoveFile(this,e));
            }
            
            
        }       
         

        private void ThreadProcSafe(object e) {
            ssDelegato d = new ssDelegato(ss);
            this.Invoke(d, new object[] { e });
        }


        private void OnChanged(object source, FileSystemEventArgs e) {
            demoThread = new Thread(new ParameterizedThreadStart(this.ThreadProcSafe));
            demoThread.Start(e);
           
        }

        private void timerMonitor_Tick(object sender, EventArgs e) {
            DataManager.storePresence(DateTime.Now);
        }

        private void openFolderDatabaseToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("explorer.exe", DataManager.getDirectory());
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e) {
            Minimize();
        }
        public void Minimize() {
            this.WindowState = FormWindowState.Minimized;
        }

    }
}
