using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace PSUtil.Settings
{
    public class LaunchSettings
    {
        private String _LaunchPath;
        public String LaunchPath {
            get { return _LaunchPath; }
            set {
                if (Directory.Exists(value))
                {
                    _LaunchPath = value;
                }
                else
                {
                    throw new DirectoryNotFoundException();
                }
            }
        }
        public string LaunchParams;
        public Server PlayServer = new Server("play.psforever.net:51200");
        public Login Authentication;
        public void SaveSettings(String Path)
        {
            StreamWriter streamWriter = new StreamWriter(Path, false);
            streamWriter.Write(JsonConvert.SerializeObject(this));
            streamWriter.Dispose();
        }
        public static LaunchSettings LoadSettings(String Path)
        {
            StreamReader streamReader = new StreamReader(Path);
            return JsonConvert.DeserializeObject<LaunchSettings>(streamReader.ReadToEnd());
        }
        public static void WriteSettings(LaunchSettings settings)
        {
            StreamWriter streamWriter = new StreamWriter(settings.LaunchPath+"client.ini");
            streamWriter.Write(settings.GetINI());
            streamWriter.Dispose();
        }
        private string GetINI()
        {
            return "[network]\n\nlogin0=" + PlayServer;

        }
    }
    public class EmptySettingsException : Exception
    {
        public EmptySettingsException(string message) : base(message)
        {
        }
    }
}
