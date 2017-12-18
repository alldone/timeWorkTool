using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTools.Code.Model {
    public class MonitoringItem {
        public SessionSwitchReason State { get; set; }
        public DateTime When { get; set; }
    }
}
