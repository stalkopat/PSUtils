using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using Newtonsoft.Json;

namespace PSUtil.Update
{
    public class Patch
    {
        public List<String> Modified_Files = new List<String>();
        public String DownloadURL;
        public String Name;
        String DownloadedPath;
        public void PrepareForPatching()
        {
            if(DownloadURL == null && DownloadedPath == null)
            {
                throw new MissingURLException("Missing URL, please supply an URL");
            }

            if (DownloadedPath != null)
            {
                var tempdir = Directory.CreateDirectory(Path.GetRandomFileName());
                File.Move(DownloadedPath, tempdir.FullName+"/Mod.psmod");
                ZipFile.ExtractToDirectory(tempdir.FullName + "Mod.psmod", tempdir.FullName + "/Extracted/");
                StreamReader reader = new StreamReader(tempdir.FullName + "/Extracted/" + "config.json");
                Patch configpatch = JsonConvert.DeserializeObject<Patch>(reader.ReadToEnd());
                reader.Dispose();
                Name = configpatch.Name;
                DownloadedPath = Directory.GetCurrentDirectory() + @"/ModDir/" + Name + "/";
                tempdir.MoveTo(DownloadedPath);
                Modified_Files = configpatch.Modified_Files;
            }
            else if (Name != null && DownloadURL != null)
            {
                DownloadedPath = Directory.GetCurrentDirectory() + @"/ModDir/" + Name + "/";
                if (!Directory.Exists(DownloadedPath))
                {
                    Directory.CreateDirectory(DownloadedPath);
                }
                FileDownloader.DownloadFileFromURLToPath(DownloadURL, DownloadedPath + "Mod.psmod");
                
                try
                {
                    Directory.Delete(DownloadedPath + "Extracted/", true);
                    ZipFile.ExtractToDirectory(DownloadedPath + "Mod.psmod", DownloadedPath + "Extracted/");
                    File.Delete(DownloadedPath + "config.json");
                    File.Move(DownloadedPath + "Extracted/config.json", DownloadedPath + "config.json");
                    StreamReader reader = new StreamReader(DownloadedPath + "config.json");
                    Patch configpatch = JsonConvert.DeserializeObject<Patch>(reader.ReadToEnd());
                    reader.Dispose();
                    Modified_Files = configpatch.Modified_Files;
                    DownloadedPath = @"/ModDir/" + Name + "/";
                    return;
                }
                catch (Exception e)
                {
                    DownloadedPath = @"/ModDir/" + Name + "/";
                    throw new MalFormedPatchException("Patching failed, prehaps config.json is missing or the Download Failed");
                }
            }
            else
            {
                var tempdir = Directory.CreateDirectory("ModDir/"+Path.GetRandomFileName());
                FileDownloader.DownloadFileFromURLToPath(DownloadURL, tempdir.FullName + "/Mod.psmod");
                ZipFile.ExtractToDirectory(tempdir.FullName + "/Mod.psmod", tempdir.FullName + "/Extracted/");
                StreamReader reader = new StreamReader(tempdir.FullName + "/Extracted/" + "config.json");
                Patch configpatch = JsonConvert.DeserializeObject<Patch>(reader.ReadToEnd());
                reader.Dispose();
                Name = configpatch.Name;
                DownloadedPath = Directory.GetCurrentDirectory() + @"/ModDir/" + Name + "/";
                tempdir.MoveTo(DownloadedPath);
                Modified_Files = configpatch.Modified_Files;
            }

        }
    }
    class MalFormedPatchException : Exception
    {
        public MalFormedPatchException(string message) : base(message)
        {
        }
    }
    class MissingURLException : Exception
    {
        public MissingURLException(string message) : base(message)
        {

        }
    }
}
