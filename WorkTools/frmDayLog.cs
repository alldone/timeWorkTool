using WorkTools.Code;
using WorkTools.Code.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkTools {
    public partial class frmDayLog : Form {
        public frmDayLog() {
            InitializeComponent();
        }
        private String FORMATTER_DAY = "dd/MM/yyyy";
        private String FORMATTER_DAY_MIN = "dd/MM/yyyy HH:mm:ss";
        private void frmDayLog_Load(object sender, EventArgs e) {
            makeList();
            bindList();
        }

        private void bindList() {
            List<Monitoring> list = DataManager.read();
            list = list.OrderByDescending(z => z.Day).ToList();
            foreach (Monitoring item in list) {
                string[] arr = new string[4];
                ListViewItem itm;
                arr[0] = item.Day.ToString(FORMATTER_DAY);
                arr[1] = item.FirstSeenInDay.ToString(FORMATTER_DAY_MIN);
                arr[2] = item.LastSeenInDay.ToString(FORMATTER_DAY_MIN);
                arr[3] = item.Calculate();
                itm = new ListViewItem(arr);
                lst.Items.Add(itm);
            }
        }

        private void makeList() {
            lst.Columns.Add("Day", 100);
            lst.Columns.Add("Start", 170);
            lst.Columns.Add("Finish", 170);
            lst.Columns.Add("Worked", 200);
        }
    }
}
