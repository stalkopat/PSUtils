using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using PSUtil.ManagedClient;
using PSUtil.Settings;
using Newtonsoft.Json;
using System.IO;
namespace LauncherExample
{
    public partial class Launcher :  MetroForm
    {
        public Client Client = Client.RestoreClient();
        public Launcher()
        {
            InitializeComponent();
            ThreadPool.QueueUserWorkItem(x => {
                while (true) //Updates UI
                {
                    ProgressBar.Invoke(new Action(() => {
                        int Progress = Client.GetProgress();
                        ProgressBar.Value = Progress; }));
                    InstallationStatus.Invoke(new Action(() => { InstallationStatus.Text = Client.InstallationStatus.ToString(); }));
                    LaunchButton.Invoke(new Action(() =>
                    {
                        if (Client.InstallationStatus != PSUtil.Install.InstallationStatus.Not_Installed)
                        {
                            LaunchButton.Text = "PLAY";
                        }
                        else
                        {
                            LaunchButton.Text = "INSTALL";
                        }
                    }));
                    GameStatus.Invoke(new Action(() => { GameStatus.Text = Client.gameState().ToString(); }));
                    Thread.Sleep(100);
                }
            });
            
        }

        private void Launcher_FormClosing(object sender, FormClosingEventArgs e)
        {
            Client.SaveClient();
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            if (Client.InstallationStatus != PSUtil.Install.InstallationStatus.Not_Installed)
            {
                Client.SetServer(new Server(ServerTextBox.Text));
                ThreadPool.QueueUserWorkItem(x => { Client.Launch(); });
            }
            else
            {
                ThreadPool.QueueUserWorkItem(x => { Client.CleanInstall(); });
            }
        }
    }
}
