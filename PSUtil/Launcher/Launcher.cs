using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using System.Threading;
using PSUtil.ManagedClient;
using PSUtil.Settings;
using PSUtil.Update;

namespace Launcher
{
    public partial class Launcher : MetroForm
    {
        static Client ManagedClient = new Client();
        public Launcher()
        {
            InitializeComponent();
            HandleStartup();
            ThreadPool.QueueUserWorkItem(X => SyncUI());
        }
        public void HandleStartup()
        {
            ManagedClient = Client.RestoreClient();
            foreach (Server saved in ManagedClient.Servers)
            {
                ServerList.Items.Add(saved.ToString());
            }
            SelectedServer.Text = ManagedClient.Settings.PlayServer.ToString();
            Application.ApplicationExit += saveClient;
        }

        private void saveClient(object sender, EventArgs e)
        {
            ManagedClient.SaveClient();
        }

        public void SyncUI()
        {
            while (true) {
                try { 
                this.Invoke(
                new Action(
                    () =>
                    {
                        try
                        {
                            if (ManagedClient.InstallationStatus != PSUtil.Install.InstallationStatus.Not_Installed)
                            {
                                PlayButton.Text = "PLAY";
                            }
                            else
                            {
                                PlayButton.Text = "INSTALL";
                            }
                            if (ManagedClient.inProgressOperation != InProgressOperation.None)
                            {
                                PlayButton.Enabled = false;
                                InstallMod.Enabled = false;
                                RestoreInstall.Enabled = false;
                                VerifyIntegrity.Enabled = false;
                            }
                            else
                            {

                                PlayButton.Enabled = true;
                                InstallMod.Enabled = true;
                                RestoreInstall.Enabled = true;
                                VerifyIntegrity.Enabled = true;
                            }
                            Status.Text = ManagedClient.getInstallStatusMessage();
                            ProgressBar.Value = ManagedClient.GetProgress();
                            //ServerStatus.Text = ManagedClient.get
                            InstallStatus.Text = ManagedClient.InstallationStatus.ToString();
                            AppliedMods.Text = ManagedClient.getInstalledPatches();
                            CheckSum.Text = ManagedClient.HashSum;
                        }
                        catch { }
                    }
                )
                );
                }
                catch
                {

                }
                Thread.Sleep(200);
           }
        }

        private void SelectedServer_TextChanged(object sender, EventArgs e)
        {
            ManagedClient.SetServer(new Server(SelectedServer.Text));
        }

        private void AddServerToList_Click(object sender, EventArgs e)
        {
            Server New = new Server(SelectedServer.Text);
            ManagedClient.AddServer(New);
            ServerList.Items.Add(New.ToString());
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (ManagedClient.InstallationStatus != PSUtil.Install.InstallationStatus.Not_Installed)
            {
                ThreadPool.QueueUserWorkItem(x => { ManagedClient.Launch(); });
            }
            else
            {
                ThreadPool.QueueUserWorkItem(x => { ManagedClient.CleanInstall(); });
            }
        }
        

        private void VerifyIntegrity_Click(object sender, EventArgs e)
        {
            if(ManagedClient.InstallationStatus != PSUtil.Install.InstallationStatus.Not_Installed) { 
            ThreadPool.QueueUserWorkItem(a =>
            {
                bool integrity = ManagedClient.getFileIntegrity();
                string outputtxt = "";
                if (integrity)
                {
                    outputtxt = "No Errors";
                }
                else
                {
                    outputtxt = "Problem with\ninstallation detected";
                }
                FileIntegrityStatus.Text = outputtxt;
            });
            }
        }

        private void RestoreInstall_Click(object sender, EventArgs e)
        {
            if (ManagedClient.InstallationStatus != PSUtil.Install.InstallationStatus.Not_Installed)
            {

                ThreadPool.QueueUserWorkItem(x => ManagedClient.RestoreInstall());
            }
        }

        private void InstallMod_Click(object sender, EventArgs e)
        {
            if (ManagedClient.InstallationStatus != PSUtil.Install.InstallationStatus.Not_Installed)
            {

                Patch patch = new Patch();
                patch.DownloadURL = ModInstallURL.Text;
                ThreadPool.QueueUserWorkItem(x => { ManagedClient.ApplyPatch(patch); });
            }
        }
        private void ServerList_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (ServerList.SelectedItems.Count != 0)
            {
                Server server = new Server(ServerList.SelectedItems[0].Text);
                ManagedClient.SetServer(server);
                SelectedServer.Text = server.ToString();
                ServerList.SelectedItems[0].Selected = false;
            }
        }
    }
}
