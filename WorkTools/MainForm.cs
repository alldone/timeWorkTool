using WorkTools.Code;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WorkTools {
    public partial class MainForm : Form {
        private static SessionSwitchEventHandler sseh;

        public MainForm() {
            InitializeComponent();
        }
     
        private void dayLogToolStripMenuItem_Click(object sender, EventArgs e) {
            frmDayLog fc = new frmDayLog();
            fc.MdiParent = this;
            fc.Show();
        }

        private void Form1_Load(object sender, EventArgs e) {
            startMonitor();
        }
        
         
        

        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e) {
            Console.WriteLine(e.Reason.ToString());
            DataManager.store(e.Reason, DateTime.Now);
        }
        private void startMonitor() {
            sseh = new SessionSwitchEventHandler(SystemEvents_SessionSwitch);
            SystemEvents.SessionSwitch += sseh;
            DataManager.storeStartPresence(DateTime.Now);
        } 

        private void timerMonitor_Tick(object sender, EventArgs e) {
            DataManager.storePresence(DateTime.Now);
        }

        private void openFolderDatabaseToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("explorer.exe", DataManager.getDirectory());
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
