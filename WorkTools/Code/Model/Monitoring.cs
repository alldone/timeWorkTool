using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTools.Code.Model {
    public class Monitoring  :IComparable {
        public DateTime Day { get; set; }
        public List<MonitoringItem> Items { get; set; }
        public DateTime LastSeenInDay { get; set; }
        public DateTime FirstSeenInDay { get; set; }

        public string Calculate() {
            if (LastSeenInDay == null)
                LastSeenInDay = DateTime.Now;
            if (FirstSeenInDay == null)
                FirstSeenInDay= DateTime.Now;
            TimeSpan totalSpan = LastSeenInDay - FirstSeenInDay;

            Items = Items.OrderBy(c => c.When).ToList();
            DateTime? start = null;
            DateTime? stop = null;
            foreach (MonitoringItem item in Items) {
                if (start == null && stop == null && item.State== SessionSwitchReason.SessionLock) {
                    start = item.When;
                }
                if (start != null && stop == null && item.State == SessionSwitchReason.SessionUnlock) {
                    stop = item.When;
                }
                if (start != null && stop != null && start.HasValue  && stop.HasValue) {
                    totalSpan = totalSpan - (stop.Value - start.Value);
                    start = null;
                    stop = null;
                }
            }
            if (start.HasValue && !stop.HasValue) {
                stop = LastSeenInDay;
                totalSpan = totalSpan - (stop.Value - start.Value);
                start = null;
                stop = null;
            }

            return totalSpan.ToString();

        }

        public int CompareTo(object obj) {
            Monitoring other = (Monitoring)obj;
            return other.Day.CompareTo(this.Day);
        }
    }
}
