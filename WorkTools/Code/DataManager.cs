using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using WorkTools.Code.Model;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;

namespace WorkTools.Code {
    public class DataManager {
        //Microsoft.Win32.SessionSwitchReason.SessionUnlock
        //Microsoft.Win32.SessionSwitchReason.SessionLock
        public static string User = string.IsNullOrEmpty( ConfigurationManager.AppSettings.Get("user"))?"undefined": ConfigurationManager.AppSettings.Get("user");
        public static List<Monitoring> read() {
            List<Monitoring> ret = new List<Monitoring>();
            var directory = getDirectory();
            var myFiles = Directory.GetFiles(directory, User + ".json*", SearchOption.AllDirectories);
            foreach (var file in myFiles) {

                using (StreamReader file1 = File.OpenText(file)) {
                    JsonSerializer serializer = new JsonSerializer();
                    var result = (List<Monitoring>)serializer.Deserialize(file1, typeof(List<Monitoring>));
                    ret = result;
                }

            }
            return ret;
        }

        private static void write(List<Monitoring> data) {
            var directory = getDirectory();

            using (StreamWriter ff = File.CreateText(directory + "\\"+ User + ".json")) {
                new JsonSerializer().Serialize(ff, data);
            }
        }

        internal static void storeStartPresence(DateTime now) {
            List<Monitoring> ret = read();
            if (ret == null || ret.Count == 0) {
                ret = new List<Monitoring>();
                Monitoring x = new Monitoring() { Day = DateTime.Now.Date, Items = new List<MonitoringItem>(), FirstSeenInDay = now };
                ret.Add(x);
            } else {
                Monitoring x = ret.Where(c => c.Day == DateTime.Now.Date).FirstOrDefault();
                if (x == null) {
                    x = new Monitoring() { Day = DateTime.Now.Date, Items = new List<MonitoringItem>(), FirstSeenInDay = now };
                    ret.Add(x);
                } else {
                    if (x.FirstSeenInDay == null)
                        x.FirstSeenInDay = now;
                }
            }
            write(ret);
        }

        public static string getDirectory() {
            var directory = Directory.GetCurrentDirectory() + "\\storage";
            if (!Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }
            return directory;
        }
        public static void storePresence(DateTime now) {
            List<Monitoring> ret = read();
            if (ret == null || ret.Count == 0) {
                ret = new List<Monitoring>();
                Monitoring x = new Monitoring() { Day = DateTime.Now.Date, Items = new List<MonitoringItem>(), LastSeenInDay = now };
                ret.Add(x);
            } else {
                Monitoring x = ret.Where(c => c.Day == DateTime.Now.Date).FirstOrDefault();
                if (x == null) {
                    x = new Monitoring() { Day = DateTime.Now.Date, Items = new List<MonitoringItem>(), LastSeenInDay = now };
                    ret.Add(x);
                } else {
                    x.LastSeenInDay = now;
                }
            }
            write(ret);
        }
        public static void store(SessionSwitchReason reason, DateTime now) {
            List<Monitoring> ret = read();
            if (ret == null || ret.Count == 0) {
                ret = new List<Monitoring>();
                Monitoring x = new Monitoring() { Day = DateTime.Now.Date, Items = new List<MonitoringItem>() };
                x.Items.Add(new MonitoringItem() { State = reason, When = now });
                ret.Add(x);
            } else {
                Monitoring x = ret.Where(c => c.Day == DateTime.Now.Date).FirstOrDefault();
                if (x == null) {
                    x = new Monitoring() { Day = DateTime.Now.Date, Items = new List<MonitoringItem>() };
                    x.Items.Add(new MonitoringItem() { State = reason, When = now });
                    ret.Add(x);
                } else {
                    x.Items.Add(new MonitoringItem() { State = reason, When = now });
                }
            }
            write(ret);
        }
    }
}
