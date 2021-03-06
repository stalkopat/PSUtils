﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace PSUtil.Game
{
    public class Launcher
    {
        public Settings.LaunchSettings settings;
        [JsonIgnore]
        public Instance instance = new Instance();
        public void Launch(Settings.LaunchSettings settings)
        {
            instance.Start(settings);
        }
        public void Launch()
        {
            instance.Start(settings);
        }
    }
}
