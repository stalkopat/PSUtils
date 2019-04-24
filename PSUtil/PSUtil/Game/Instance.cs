using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PSUtil.Game
{
    public class Instance
    {
        public Process process;
        public GameState gameState = GameState.NotRunning;
        private Settings.LaunchSettings settings;
        public void Start(Settings.LaunchSettings settings)
        {
            this.settings = settings;
            if (settings == null)
            {
                throw new Settings.EmptySettingsException("Settings not set, please use Valid settings!");
            }
            Settings.LaunchSettings.WriteSettings(settings);
            process = CreatePSProcess();
            process.Start();
            gameState = GameState.Running;
        }
        private Process CreatePSProcess()
        {
            process = new Process();
            process.StartInfo.WorkingDirectory = settings.LaunchPath;
            process.StartInfo.FileName = "planetside.exe";
            process.StartInfo.Arguments = "/K:StagingTest /CC " + settings.LaunchParams;
            process.Exited += new EventHandler(GameClosed);
            process.EnableRaisingEvents = true;
            return process;
        }
        private void GameClosed(object sender, EventArgs e)
        {
            gameState = GameState.Exited;
        }
    }
}
