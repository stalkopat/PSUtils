using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using PSUtil.Settings;
using System.IO;

namespace PSUtil.Verification
{
    public static class Checksums
    {
        public static int InstallationHashProgress;
        public static string GetMD5Hash(String FileName)
        {
            using (var md5 = MD5.Create())
            {
                using (var fileStream = System.IO.File.OpenRead(FileName))
                {
                    var md5hash = md5.ComputeHash(fileStream);

                    return Encoding.Default.GetString(md5hash);
                }
            }
        }
        public static string GetInstallationHash(LaunchSettings settings)
        {
            String PreHash = "";
            string[] files = Directory.GetFiles(settings.LaunchPath, "*", SearchOption.AllDirectories);
            for (int i = 0; i < files.Length; i++)
            {
                switch (Path.GetExtension(files[i]))
                {
                    case ".swp":
                        break;
                    case ".txt":
                        break;
                    case ".lst":
                        break;
                    case ".bmp":
                        break;
                    case ".mp3":
                        break;
                    case ".wav":
                        break;
                    case ".ini":
                        break;
                    default:
                        PreHash += GetMD5Hash(files[i]);
                        break;
                }
                double progress = ((double)i / (double)files.Length * 100);
                InstallationHashProgress = Convert.ToInt32(progress);
            }
            var md = MD5.Create();
            return BitConverter.ToString(md.ComputeHash(Encoding.Default.GetBytes(PreHash))).Replace("-", "").ToLower(); ;
        }
    }
    public class InvalidInstallException : Exception 
    {
        public InvalidInstallException(string message) : base(message)
        {
        }
    }
}
