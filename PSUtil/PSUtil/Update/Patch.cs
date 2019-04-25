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
            DownloadedPath = Directory.GetCurrentDirectory() + @"/ModDir/" + Name + "/";
            if (! Directory.Exists(DownloadedPath))
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
                Modified_Files = configpatch.Modified_Files;
                DownloadedPath =  @"/ModDir/" + Name + "/";
            }
            catch(Exception e)
            {
                DownloadedPath = @"/ModDir/" + Name + "/";
                throw new MalFormedPatchException("Patching failed, prehaps config.json is missing or the Download Failed");
            }
        }
    }
    class MalFormedPatchException : Exception
    {
        public MalFormedPatchException(string message) : base(message)
        {
        }
    }
}
