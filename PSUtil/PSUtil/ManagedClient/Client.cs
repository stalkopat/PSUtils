using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSUtil.Game;
using PSUtil.Install;
using PSUtil.Settings;
using PSUtil.Update;
using System.IO;
using Newtonsoft.Json;

namespace PSUtil.ManagedClient
{
    public class Client
    {
        List<Patch> patches = new List<Patch>();
        List<Patch> CurrentlyApplied = new List<Patch>();
        List<Server> Servers = new List<Server>();
        Patcher patcher = new Patcher();
        Launcher launcher = new Launcher();
        LaunchSettings Settings = new LaunchSettings();
        Installer installer = new Installer();
        
        public void SetServer(Server server)
        {
            Settings.PlayServer = server;
        }
        public void AddServer(Server server)
        {
            Servers.Add(server);
        }
        public void AddPatch(Patch patch)
        {
            patcher.ApplyPatch(patch, Settings);
        }
        public void CleanInstall()
        {
            installer.StartInstall();
            Settings.LaunchPath = Directory.GetCurrentDirectory() + @"\PlanetSide\";
            patcher.RestoreBaseInstall();
            CurrentlyApplied = new List<Patch>();
        }
        public void CleanInstall(String CUSTOMURL)
        {
            installer.StartInstall(CUSTOMURL);
            Settings.LaunchPath = Directory.GetCurrentDirectory() + @"\PlanetSide\";
            patcher.RestoreBaseInstall();
            CurrentlyApplied = new List<Patch>();
        }
        public void RestoreInstall()
        {
            patcher.RestoreBaseInstall();
            CurrentlyApplied = new List<Patch>();
        }
        public int GetProgress()
        {
            if(installer.Progress == 100 && patcher.PatchProgress == 100)
            {
                return 100;
            }
            else if(installer.Progress != 100)
            {
                return installer.Progress;
            }
            else
            {
                return patcher.PatchProgress;
            }
        }
        public void SaveClient()
        {
            if(!Directory.Exists(Directory.GetCurrentDirectory() + "/Client/"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Client/");
            }
            StreamWriter streamWriter = new StreamWriter(Directory.GetCurrentDirectory() + "/Client/config.json");
            streamWriter.Write(JsonConvert.SerializeObject(this));
            streamWriter.Dispose();
        }
        public static Client RestoreClient()
        {
            if (PreviousInstall())
            {
                StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + "/Client/config.json");
                Client client = JsonConvert.DeserializeObject<Client>(streamReader.ReadToEnd());
                streamReader.Dispose();
                return client;
            }
            else
            {
                return new Client();
            }
        }
        public static bool PreviousInstall()
        {
            return File.Exists(Directory.GetCurrentDirectory() + "/Client/config.json");
        }
    }
}
