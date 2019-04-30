using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using PSUtil.Verification;

namespace PSUtil.Update
{
    public class Patcher
    {
        public static int PatchProgress = 0;
        public string currenthash;
        public void ApplyPatch(Patch patch, Settings.LaunchSettings settings)
        {
            patch.PrepareForPatching();

            foreach (String PatchedFile in patch.Modified_Files)
            {
                File.Copy(Directory.GetCurrentDirectory() + @"/ModDir/"+ patch.Name + "/Extracted/" + PatchedFile, Directory.GetCurrentDirectory() + @"/PlanetSide/" + PatchedFile, true);
            }
            
        }
        public bool IntegrityCheck(Settings.LaunchSettings settings)
        {
            currenthash = Checksums.GetInstallationHash(settings);
            if(currenthash == "1014c2a973f9ccd2a310039eb484dc27")
            {
                return true;
            }
            return false;
        }
        public bool IntegrityCheck(Settings.LaunchSettings settings, Patch patch)
        {
            currenthash = Checksums.GetInstallationHash(settings);
            if (currenthash == patch.ExpectedHash)
            {
                return true;
            }
            return false;
        }
        public void RestoreBaseInstall()
        {
            DeleteBinaries();
            try
            {
                ThreadPool.QueueUserWorkItem(x =>
                {
                    while(Directory.GetFiles(Directory.GetCurrentDirectory() + @"/PlanetSideBase/PlanetSide", "*", SearchOption.AllDirectories).Length > Directory.GetFiles(Directory.GetCurrentDirectory() + @"/PlanetSide/", "*", SearchOption.AllDirectories).Length)
                    {
                        int dir1 = Directory.GetFiles(Directory.GetCurrentDirectory() + @"/PlanetSide/", "*", SearchOption.AllDirectories).Length;
                        int dir2 = Directory.GetFiles(Directory.GetCurrentDirectory() + @"/PlanetSideBase/PlanetSide", "*", SearchOption.AllDirectories).Length;
                        PatchProgress = 50 + Convert.ToInt32(((double)dir1 / (double)dir2 * 50));
                    }
                });
                new Microsoft.VisualBasic.Devices.Computer().FileSystem
                    .CopyDirectory(Directory.GetCurrentDirectory() + @"/PlanetSideBase/PlanetSide", Directory.GetCurrentDirectory() + @"/PlanetSide/");

            }
            catch
            {

            }
        }
        private void DeleteBinaries()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + @"/PlanetSide/", "*", SearchOption.AllDirectories);
            for (int i = 0; i < files.Length; i++)
            {
                switch (Path.GetExtension(files[i]))
                {
                    case ".txt":
                        if (Path.GetFileNameWithoutExtension(files[i]).Contains("news_unicode"))
                        {
                            File.Delete(files[i]);
                        }
                        break;
                    case ".ini":
                        break;
                    case ".lst":
                        break;
                    case ".bmp":
                        break;
                    case ".mp3":
                        break;
                    case ".wav":
                        break;
                    default:
                        File.Delete(files[i]);
                        break;
                }
                double progress = ((double)i / (double)files.Length * 50);
                PatchProgress = Convert.ToInt32(progress);
            }
        }
    }
}
