﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO.Compression;
using System.IO;

namespace PSUtil.Install
{
    public class Installer
    {
        public int Progress = 0;
        public void StartInstall(String URL = "https://drive.google.com/uc?id=0B9EQ4wD-WnFIQTJON0hJb0dldWM")
        {
            try
            {
                File.Delete(@"PlanetSideBase/Zipfile.zip");
            }
            catch
            {

            }
            try
            {
                Directory.CreateDirectory(@"PlanetSideBase/");
            }
            catch
            {

            }
            FileDownloader.DownloadFileFromURLToPath(URL,   @"PlanetSideBase /Zipfile.zip");

            ZipFile.ExtractToDirectory(@"PlanetSideBase/Zipfile.zip", @"PlanetSideBase/");

            File.Delete(@"PlanetSideBase/Zipfile.zip");
        }
    }
}