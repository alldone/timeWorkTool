using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using WorkTools.Code.Model;
using System.IO;
using Newtonsoft.Json;
 

namespace WorkTools.Code {
    public class DataManagerConf {

        public static string User = string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings.Get("user"))?"undefined": System.Configuration.ConfigurationManager.AppSettings.Get("user");
        public static string getDirectory() {
            var directory = Directory.GetCurrentDirectory() + "\\storage";
            if (!Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }
            return directory;
        }
        public static List<Configuration> read() {
            List<Configuration> ret = new List<Configuration>();
            var directory = getDirectory();
            var myFiles = Directory.GetFiles(directory, User + "conf.json*", SearchOption.AllDirectories);
            foreach (var file in myFiles) {
                using (StreamReader file1 = File.OpenText(file)) {
                    JsonSerializer serializer = new JsonSerializer();
                    var result = (List<Configuration>)serializer.Deserialize(file1, typeof(List<Configuration>));
                    ret = result;
                }
            }
            return ret;
        }

        public static void write(List<Configuration> data) {
            var directory = getDirectory();

            using (StreamWriter ff = File.CreateText(directory + "\\"+ User + "conf.json")) {
                new JsonSerializer().Serialize(ff, data);
            }
        }

        internal static void write(Configuration c) {
            List<Configuration> s = new List<Configuration>();
            s.Add(c);
            write(s);
        }
    }
}
