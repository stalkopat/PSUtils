namespace Launcher
{
    partial class Launcher
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.PlayButton = new MetroFramework.Controls.MetroButton();
            this.ProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.Status = new MetroFramework.Controls.MetroLabel();
            this.ServerList = new MetroFramework.Controls.MetroListView();
            this.SelectedServer = new MetroFramework.Controls.MetroTextBox();
            this.AddServerToList = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.ServerStatus = new MetroFramework.Controls.MetroLabel();
            this.ModInstallURL = new MetroFramework.Controls.MetroTextBox();
            this.RestoreInstall = new MetroFramework.Controls.MetroButton();
            this.InstallMod = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.InstallStatus = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.AppliedMods = new MetroFramework.Controls.MetroTile();
            this.VerifyIntegrity = new MetroFramework.Controls.MetroButton();
            this.FileIntegrityStatus = new MetroFramework.Controls.MetroLabel();
            this.CheckSum = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // PlayButton
            // 
            this.PlayButton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.PlayButton.Location = new System.Drawing.Point(23, 324);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(179, 69);
            this.PlayButton.TabIndex = 1;
            this.PlayButton.Text = "PLAY";
            this.PlayButton.UseSelectable = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(23, 399);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(754, 28);
            this.ProgressBar.TabIndex = 1;
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(209, 324);
            this.Status.MaximumSize = new System.Drawing.Size(550, 0);
            this.Status.MinimumSize = new System.Drawing.Size(550, 0);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(0, 0);
            this.Status.TabIndex = 2;
            this.Status.WrapToLine = true;
            // 
            // ServerList
            // 
            this.ServerList.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ServerList.FullRowSelect = true;
            this.ServerList.Location = new System.Drawing.Point(23, 85);
            this.ServerList.MultiSelect = false;
            this.ServerList.Name = "ServerList";
            this.ServerList.Size = new System.Drawing.Size(179, 204);
            this.ServerList.TabIndex = 3;
            this.ServerList.UseCompatibleStateImageBehavior = false;
            this.ServerList.UseSelectable = true;
            this.ServerList.View = System.Windows.Forms.View.List;
            this.ServerList.SelectedIndexChanged += new System.EventHandler(this.ServerList_SelectedIndexChanged_1);
            // 
            // SelectedServer
            // 
            // 
            // 
            // 
            this.SelectedServer.CustomButton.Image = null;
            this.SelectedServer.CustomButton.Location = new System.Drawing.Point(157, 1);
            this.SelectedServer.CustomButton.Name = "";
            this.SelectedServer.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.SelectedServer.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.SelectedServer.CustomButton.TabIndex = 1;
            this.SelectedServer.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.SelectedServer.CustomButton.UseSelectable = true;
            this.SelectedServer.CustomButton.Visible = false;
            this.SelectedServer.Lines = new string[0];
            this.SelectedServer.Location = new System.Drawing.Point(23, 295);
            this.SelectedServer.MaxLength = 32767;
            this.SelectedServer.Name = "SelectedServer";
            this.SelectedServer.PasswordChar = '\0';
            this.SelectedServer.PromptText = "IP";
            this.SelectedServer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SelectedServer.SelectedText = "";
            this.SelectedServer.SelectionLength = 0;
            this.SelectedServer.SelectionStart = 0;
            this.SelectedServer.ShortcutsEnabled = true;
            this.SelectedServer.Size = new System.Drawing.Size(179, 23);
            this.SelectedServer.TabIndex = 0;
            this.SelectedServer.UseSelectable = true;
            this.SelectedServer.WaterMark = "IP";
            this.SelectedServer.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.SelectedServer.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.SelectedServer.TextChanged += new System.EventHandler(this.SelectedServer_TextChanged);
            // 
            // AddServerToList
            // 
            this.AddServerToList.Location = new System.Drawing.Point(208, 295);
            this.AddServerToList.Name = "AddServerToList";
            this.AddServerToList.Size = new System.Drawing.Size(100, 23);
            this.AddServerToList.TabIndex = 5;
            this.AddServerToList.Text = "Add to List";
            this.AddServerToList.UseSelectable = true;
            this.AddServerToList.Click += new System.EventHandler(this.AddServerToList_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(208, 250);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(88, 19);
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "Server Status:";
            // 
            // ServerStatus
            // 
            this.ServerStatus.AutoSize = true;
            this.ServerStatus.Location = new System.Drawing.Point(209, 269);
            this.ServerStatus.Name = "ServerStatus";
            this.ServerStatus.Size = new System.Drawing.Size(0, 0);
            this.ServerStatus.TabIndex = 7;
            // 
            // ModInstallURL
            // 
            // 
            // 
            // 
            this.ModInstallURL.CustomButton.Image = null;
            this.ModInstallURL.CustomButton.Location = new System.Drawing.Point(286, 1);
            this.ModInstallURL.CustomButton.Name = "";
            this.ModInstallURL.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.ModInstallURL.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ModInstallURL.CustomButton.TabIndex = 1;
            this.ModInstallURL.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ModInstallURL.CustomButton.UseSelectable = true;
            this.ModInstallURL.CustomButton.Visible = false;
            this.ModInstallURL.Lines = new string[0];
            this.ModInstallURL.Location = new System.Drawing.Point(469, 136);
            this.ModInstallURL.MaxLength = 32767;
            this.ModInstallURL.Name = "ModInstallURL";
            this.ModInstallURL.PasswordChar = '\0';
            this.ModInstallURL.PromptText = "URL";
            this.ModInstallURL.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ModInstallURL.SelectedText = "";
            this.ModInstallURL.SelectionLength = 0;
            this.ModInstallURL.SelectionStart = 0;
            this.ModInstallURL.ShortcutsEnabled = true;
            this.ModInstallURL.Size = new System.Drawing.Size(308, 23);
            this.ModInstallURL.TabIndex = 9;
            this.ModInstallURL.UseSelectable = true;
            this.ModInstallURL.WaterMark = "URL";
            this.ModInstallURL.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ModInstallURL.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // RestoreInstall
            // 
            this.RestoreInstall.Location = new System.Drawing.Point(596, 166);
            this.RestoreInstall.Name = "RestoreInstall";
            this.RestoreInstall.Size = new System.Drawing.Size(181, 23);
            this.RestoreInstall.TabIndex = 10;
            this.RestoreInstall.Text = "Restore Clean Installation";
            this.RestoreInstall.UseSelectable = true;
            this.RestoreInstall.Click += new System.EventHandler(this.RestoreInstall_Click);
            // 
            // InstallMod
            // 
            this.InstallMod.Location = new System.Drawing.Point(469, 166);
            this.InstallMod.Name = "InstallMod";
            this.InstallMod.Size = new System.Drawing.Size(121, 23);
            this.InstallMod.TabIndex = 11;
            this.InstallMod.Text = "Install Mod";
            this.InstallMod.UseSelectable = true;
            this.InstallMod.Click += new System.EventHandler(this.InstallMod_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(469, 196);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(94, 19);
            this.metroLabel2.TabIndex = 12;
            this.metroLabel2.Text = "Current Status:";
            // 
            // InstallStatus
            // 
            this.InstallStatus.AutoSize = true;
            this.InstallStatus.Location = new System.Drawing.Point(570, 196);
            this.InstallStatus.Name = "InstallStatus";
            this.InstallStatus.Size = new System.Drawing.Size(0, 0);
            this.InstallStatus.TabIndex = 13;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(24, 63);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(52, 19);
            this.metroLabel3.TabIndex = 14;
            this.metroLabel3.Text = "Servers";
            // 
            // AppliedMods
            // 
            this.AppliedMods.ActiveControl = null;
            this.AppliedMods.Location = new System.Drawing.Point(469, 63);
            this.AppliedMods.Name = "AppliedMods";
            this.AppliedMods.Size = new System.Drawing.Size(308, 67);
            this.AppliedMods.TabIndex = 15;
            this.AppliedMods.UseSelectable = true;
            // 
            // VerifyIntegrity
            // 
            this.VerifyIntegrity.Location = new System.Drawing.Point(469, 219);
            this.VerifyIntegrity.Name = "VerifyIntegrity";
            this.VerifyIntegrity.Size = new System.Drawing.Size(121, 23);
            this.VerifyIntegrity.TabIndex = 16;
            this.VerifyIntegrity.Text = "Verify File Integrity";
            this.VerifyIntegrity.UseSelectable = true;
            this.VerifyIntegrity.Click += new System.EventHandler(this.VerifyIntegrity_Click);
            // 
            // FileIntegrityStatus
            // 
            this.FileIntegrityStatus.AutoSize = true;
            this.FileIntegrityStatus.Location = new System.Drawing.Point(469, 249);
            this.FileIntegrityStatus.Name = "FileIntegrityStatus";
            this.FileIntegrityStatus.Size = new System.Drawing.Size(0, 0);
            this.FileIntegrityStatus.TabIndex = 17;
            // 
            // CheckSum
            // 
            // 
            // 
            // 
            this.CheckSum.CustomButton.Image = null;
            this.CheckSum.CustomButton.Location = new System.Drawing.Point(209, 1);
            this.CheckSum.CustomButton.Name = "";
            this.CheckSum.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.CheckSum.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.CheckSum.CustomButton.TabIndex = 1;
            this.CheckSum.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.CheckSum.CustomButton.UseSelectable = true;
            this.CheckSum.CustomButton.Visible = false;
            this.CheckSum.Lines = new string[0];
            this.CheckSum.Location = new System.Drawing.Point(546, 270);
            this.CheckSum.MaxLength = 32767;
            this.CheckSum.Name = "CheckSum";
            this.CheckSum.PasswordChar = '\0';
            this.CheckSum.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CheckSum.SelectedText = "";
            this.CheckSum.SelectionLength = 0;
            this.CheckSum.SelectionStart = 0;
            this.CheckSum.ShortcutsEnabled = true;
            this.CheckSum.Size = new System.Drawing.Size(231, 23);
            this.CheckSum.TabIndex = 18;
            this.CheckSum.UseSelectable = true;
            this.CheckSum.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CheckSum.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(469, 270);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(71, 19);
            this.metroLabel4.TabIndex = 19;
            this.metroLabel4.Text = "Checksum:";
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.CheckSum);
            this.Controls.Add(this.FileIntegrityStatus);
            this.Controls.Add(this.VerifyIntegrity);
            this.Controls.Add(this.AppliedMods);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.InstallStatus);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.InstallMod);
            this.Controls.Add(this.RestoreInstall);
            this.Controls.Add(this.ModInstallURL);
            this.Controls.Add(this.ServerStatus);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.AddServerToList);
            this.Controls.Add(this.SelectedServer);
            this.Controls.Add(this.ServerList);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.PlayButton);
            this.Name = "Launcher";
            this.Resizable = false;
            this.Text = "PlanetSide Launcher";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private MetroFramework.Controls.MetroButton PlayButton;
        private MetroFramework.Controls.MetroProgressBar ProgressBar;
        private MetroFramework.Controls.MetroLabel Status;
        private MetroFramework.Controls.MetroListView ServerList;
        private MetroFramework.Controls.MetroTextBox SelectedServer;
        private MetroFramework.Controls.MetroButton AddServerToList;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel ServerStatus;
        private MetroFramework.Controls.MetroTextBox ModInstallURL;
        private MetroFramework.Controls.MetroButton RestoreInstall;
        private MetroFramework.Controls.MetroButton InstallMod;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel InstallStatus;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTile AppliedMods;
        private MetroFramework.Controls.MetroButton VerifyIntegrity;
        private MetroFramework.Controls.MetroLabel FileIntegrityStatus;
        private MetroFramework.Controls.MetroTextBox CheckSum;
        private MetroFramework.Controls.MetroLabel metroLabel4;
    }
}

