using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTools.Code.Model {
    public class Configuration {
        public string PathToWatch { get; set; }
        public TimeSpan HourAlert1 { get; set; }
        public TimeSpan HourAlert2 { get; set; }
        public string LastFolder { get; set; }
    }
}
