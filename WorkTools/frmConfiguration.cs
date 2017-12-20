using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkTools.Code;
using WorkTools.Code.Model;

namespace WorkTools {
    public partial class frmConfiguration : Form {
        private MainForm mainForm;
        public frmConfiguration(MainForm mainForm) {
            InitializeComponent();
            this.mainForm = mainForm;
            Configuration c = DataManagerConf.read().FirstOrDefault();
            if (c != null) {
                txtFolder.Text = string.IsNullOrEmpty(c.PathToWatch) ? Directory.GetCurrentDirectory() : c.PathToWatch;
                folderBrowserDialog1.SelectedPath = string.IsNullOrEmpty( c.PathToWatch) ? Directory.GetCurrentDirectory() : c.PathToWatch;
            }

        }

        private void btnSearchDirectory_Click(object sender, EventArgs e) {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                var folder = folderBrowserDialog1.SelectedPath;
                Configuration c = DataManagerConf.read().FirstOrDefault();
                if (c == null) { c = new Configuration(); }
                c.PathToWatch = folder;
                txtFolder.Text = folder;
                List<Configuration> cc = new List<Configuration>();
                cc.Add(c);
                DataManagerConf.write(cc);
            }
        }
    }
}
