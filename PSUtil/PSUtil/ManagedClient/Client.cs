using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSUtil.Game;
using PSUtil.Install;
using PSUtil.Settings;
using PSUtil.Update;
using PSUtil.Verification;
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
        public string HashSum;
        public static int Progress = 0;
        public InstallationStatus InstallationStatus = InstallationStatus.Not_Installed;
        public InProgressOperation inProgressOperation = InProgressOperation.None;
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
            inProgressOperation = InProgressOperation.Modding;
            patcher.ApplyPatch(patch, Settings);
            CurrentlyApplied.Add(patch);
            inProgressOperation = InProgressOperation.Verification;
            getFileIntegrity();
            InstallationStatus = InstallationStatus.Modded;
            inProgressOperation = InProgressOperation.None;
        }
        public void CleanInstall()
        {
            inProgressOperation = InProgressOperation.Installation;
            installer.StartInstall();
            Settings.LaunchPath = Directory.GetCurrentDirectory() + @"\PlanetSide\";
            patcher.RestoreBaseInstall();
            CurrentlyApplied = new List<Patch>();
            InstallationStatus = InstallationStatus.Installed;
            inProgressOperation = InProgressOperation.None;
        }
        public void CleanInstall(String CUSTOMURL)
        {
            inProgressOperation = InProgressOperation.Installation;
            installer.StartInstall(CUSTOMURL);
            Settings.LaunchPath = Directory.GetCurrentDirectory() + @"\PlanetSide\";
            patcher.RestoreBaseInstall();
            CurrentlyApplied = new List<Patch>();
            InstallationStatus = InstallationStatus.Modded;
            inProgressOperation = InProgressOperation.None;
        }
        public void RestoreInstall()
        {
            inProgressOperation = InProgressOperation.Restore;
            patcher.RestoreBaseInstall();
            patcher.IntegrityCheck(Settings);
            CurrentlyApplied = new List<Patch>();
            inProgressOperation = InProgressOperation.Verification;
            HashSum = patcher.currenthash;
            InstallationStatus = InstallationStatus.Installed;
            inProgressOperation = InProgressOperation.None;
        }
        public String getInstallChecksum()
        {
            inProgressOperation = InProgressOperation.Verification;
            var rtn = Checksums.GetInstallationHash(Settings);
            HashSum = rtn;
            inProgressOperation = InProgressOperation.None;
            return rtn;
        }
        public bool getFileIntegrity()
        {
            inProgressOperation = InProgressOperation.Verification;
            bool rtn;
            if (InstallationStatus == InstallationStatus.Modded) { 
                rtn = patcher.IntegrityCheck(Settings, CurrentlyApplied[0]);
            }
            else
            {
                rtn = patcher.IntegrityCheck(Settings);
            }
            HashSum = patcher.currenthash;
            inProgressOperation = InProgressOperation.None;
            return rtn;  
        }
        public int GetProgress()
        {
            if(inProgressOperation == InProgressOperation.Installation) { 
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
            else if(inProgressOperation == InProgressOperation.Restore)
            {
                return Patcher.PatchProgress;
            }else if(inProgressOperation == InProgressOperation.Verification)
            {
                return Checksums.InstallationHashProgress;
            }
            else
            {
                return 100;
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
        public String CheckServerCompatibility()
        {
            return ServerCompatibility.GetServerCompatibility(Settings.PlayServer.ToString(), patcher.currenthash);
        }
        public string getInstallStatusMessage()
        {
            if (inProgressOperation == InProgressOperation.Installation)
            {
                if (GetProgress() > 0)
                {
                    return "Downloading...";
                }
                else if (GetProgress() > 98)
                {
                    return "Unpacking Files and Building Base Installation...";
                }
                else
                {
                    return "";
                }
            }
            else if(inProgressOperation == InProgressOperation.None)
            {
                return "Ready to Play!";
            }else if(inProgressOperation == InProgressOperation.Modding)
            {
                return "Applying Mod...";
            }else if(inProgressOperation == InProgressOperation.Restore)
            {
                return "Restoring Original Installation...";
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
    public enum InProgressOperation
    {
        None, Modding, Restore, Installation, Verification
    }
}
