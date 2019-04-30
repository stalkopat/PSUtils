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
using PSUtil.Update;
using System.Diagnostics;

namespace LauncherExample
{
    public partial class Launcher : MetroForm
    {
        public Client Client = Client.RestoreClient();
        bool hasheractive = false;
        public Launcher()
        {

            InitializeComponent();
            ThreadPool.QueueUserWorkItem(x =>
            {
                while (true) //Updates UI
                {
                    ProgressBar.Invoke(new Action(() =>
                    {
                        int Progress = Client.GetProgress();
                        ProgressBar.Value = Progress;

                    }));
                    DownloadStatus.Invoke(new Action(() => { DownloadStatus.Text = Client.getInstallStatusMessage(); }));
                    InstallationStatus.Invoke(new Action(() => { InstallationStatus.Text = Client.InstallationStatus.ToString(); }));
                    LaunchButton.Invoke(new Action(() =>
                    {
                        if (Client.InstallationStatus != PSUtil.Install.InstallationStatus.Not_Installed)
                        {
                            LaunchButton.Enabled = true;
                            LaunchButton.Text = "PLAY";
                        }
                        else
                        {
                            LaunchButton.Text = "INSTALL";
                        }
                    }));
                    InstalledMods.Invoke(new Action(() =>
                    {
                        string Patches = "";
                        foreach (Patch patch in Client.CurrentlyApplied)
                        {
                            Patches += patch.Name + "\n";
                        }
                        InstalledMods.Text = Patches;
                    }));
                    InstalledMods.Invoke(new Action(() => { InstalledMods.Text = Client.getInstalledPatches(); }));
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
                LaunchButton.Enabled = false;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Patch patch = new Patch();
            patch.DownloadURL = PatchURL.Text;
            ThreadPool.QueueUserWorkItem(x => { Client.ApplyPatch(patch); });
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(x => { Client.RestoreInstall(); });
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(a =>
            {
                bool integrity = Client.getFileIntegrity();
                string outputtxt = "";
                if (integrity)
                {
                    outputtxt = "No Errors";
                }
                else
                {
                    outputtxt = "Problem with\ninstallation detected";
                }
                IntegrityStatus.Invoke(new Action(() => {
                    IntegrityStatus.Text = outputtxt;
                }));
                var hashvar = Client.HashSum;
                InstallationHash.Invoke(new Action(() =>
                {
                    InstallationHash.Text = hashvar;
                }));
                Debug.WriteLine(hashvar);
            });
        }
    }

}
