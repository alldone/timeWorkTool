using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkTools.Code;
using WorkTools.Code.Model;

namespace WorkTools {
    public partial class frmMoveFile : Form {
        private MainForm mainForm;
        private FileSystemEventArgs fileInfo;

        public frmMoveFile(MainForm mainForm, FileSystemEventArgs e) {
            InitializeComponent();
            this.mainForm = mainForm;
            this.fileInfo = e;

        }
        private void bind() {
            this.lblFilename.Text = this.fileInfo.Name;
            this.lblCurrentDirectory.Text = this.fileInfo.FullPath;

        }
        private void frmMoveFile_Load(object sender, EventArgs e) {
            bind();
            Configuration c = DataManagerConf.read().FirstOrDefault();
            btnMoveToLast.Visible = (c != null && !string.IsNullOrEmpty(c.LastFolder));
            if (btnMoveToLast.Visible) {
                btnMoveToLast.Text = "Move To:" + c.LastFolder;
            }
        }
        private void move(String path) {

            Configuration c = DataManagerConf.read().FirstOrDefault();
            c.LastFolder = path;
            string newName = this.fileInfo.Name;
            string newpath = c.LastFolder + "\\" + newName;

            bool moved = false;
            try {
                if (File.Exists(newpath)) {
                    newName = DateTime.Now.ToString("yyyyMMddHHmmss") + newName;
                    newpath = c.LastFolder + "\\" + newName;
                }
                File.Move(this.fileInfo.FullPath, newpath);
                moved = true;
            } catch (Exception ex) {
                moved = false;
                MessageBox.Show("Error during move file operation : " + ex.Message);
            }
            if (moved) {
                this.mainForm.f.Remove(this.fileInfo.FullPath);
                this.fileInfo = new FileSystemEventArgs(this.fileInfo.ChangeType, c.LastFolder, newName);
                bind();
                DataManagerConf.write(c);
            }
        }
        private void btnMoveToLast_Click(object sender, EventArgs e) {
            Configuration c = DataManagerConf.read().FirstOrDefault();
            move(c.LastFolder);
        }
        private void btnMove_Click(object sender, EventArgs e) {
            Configuration c = DataManagerConf.read().FirstOrDefault();
            if (c == null) {
                c = new Configuration();
            } else {
                if (!string.IsNullOrEmpty(c.LastFolder)) {
                    folderBrowserDialog1.SelectedPath = c.LastFolder;
                }
            }
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                move(folderBrowserDialog1.SelectedPath);
            }
        }

        private void frmMoveFile_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                this.Close();
                this.mainForm.Minimize();
            }
        }

        private void btnMove_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                this.Close();
                this.mainForm.Minimize();
            }
        }

        private void btnMoveToLast_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                this.Close();
                this.mainForm.Minimize();
            }
        }
    }
}
