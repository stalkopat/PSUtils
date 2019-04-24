﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PSUtil.Update
{
    public class Patcher
    {
        public void ApplyPatch(String URL, Settings.LaunchSettings settings)
        {
            FileDownloader.DownloadFileFromURLToPath(URL, @"/ModDir/");

        }
        public void RestoreBaseInstall()
        {
            DeleteBinaries();
            try {
                new Microsoft.VisualBasic.Devices.Computer().
                    FileSystem.CopyDirectory(Directory.GetCurrentDirectory() + @"/PlanetSideBase/PlanetSide", Directory.GetCurrentDirectory() + @"/PlanetSide/");
            }
            catch
            {

            }
        }
        private void DeleteBinaries()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + @"/PlanetSide/", "*", SearchOption.AllDirectories);
            for(int i = 0; i< files.Length; i++)
            {
                switch(Path.GetExtension(files[i])){
                    case ".txt":
                        if (Path.GetFileNameWithoutExtension(files[i]).Contains("news_unicode"))
                        {
                            File.Delete(files[i]);
                        }
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
            }
        }
    }
}
