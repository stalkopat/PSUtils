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
        public List<Patch> patches = new List<Patch>();
        public List<Patch> CurrentlyApplied = new List<Patch>();
        public List<Server> Servers = new List<Server>();
        public Patcher patcher = new Patcher();
        public Launcher launcher = new Launcher();
        public LaunchSettings Settings = new LaunchSettings();
        public Installer installer = new Installer();
        public static int Progress = 0;
        public InstallationStatus InstallationStatus = InstallationStatus.Not_Installed;
        public void SetServer(Server server)
        {
            Settings.PlayServer = server;
        }
        public void AddServer(Server server)
        {
            Servers.Add(server);
        }
        public void ApplyPatch(Patch patch)
        {
            patcher.ApplyPatch(patch, Settings);
            CurrentlyApplied.Add(patch);
            InstallationStatus = InstallationStatus.Modded;
        }
        public void CleanInstall()
        {
            installer.StartInstall();
            Settings.LaunchPath = Directory.GetCurrentDirectory() + @"\PlanetSide\";
            patcher.RestoreBaseInstall();
            CurrentlyApplied = new List<Patch>();
            InstallationStatus = InstallationStatus.Installed;
        }
        public void CleanInstall(String CUSTOMURL)
        {
            installer.StartInstall(CUSTOMURL);
            Settings.LaunchPath = Directory.GetCurrentDirectory() + @"\PlanetSide\";
            patcher.RestoreBaseInstall();
            CurrentlyApplied = new List<Patch>();
            InstallationStatus = InstallationStatus.Modded;
        }
        public void RestoreInstall()
        {
            patcher.RestoreBaseInstall();
            CurrentlyApplied = new List<Patch>();
            InstallationStatus = InstallationStatus.Installed;
        }
        public int GetProgress()
        {
            if (InstallationStatus == InstallationStatus.Not_Installed && Progress == 0)
            {
                Double res = FileDownloader.Received_Bytes / 1978539839d * 100d;
                return Convert.ToInt32(res); //File Size of default PS Installation, mitigation for google Drive not setting content-length
            }
            else
            {
                return FileDownloader.Progress;
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
        public GameState gameState()
        {
            return launcher.instance.gameState;
        }
        public string getInstallStatusMessage()
        {
            if(GetProgress() > 0)
            {
                return "Downloading...";
            }
            else if(GetProgress() == 100)
            {
                return "Unpacking Files and Building Base Installation...";
            }
            else
            {
                return "";
            }
        }
        public List<Patch> getNotInstalledPatches()
        {
            return patches.Where(p => CurrentlyApplied.Contains(p)).ToList();
        }
        public String getInstalledPatches()
        {
            String s = "";
            foreach(Patch p in CurrentlyApplied)
            {
                s += p.Name + "\n";
            }
            return s;
        }
        public void Launch()
        {
            launcher.Launch(Settings);
        }
    }
    
}
