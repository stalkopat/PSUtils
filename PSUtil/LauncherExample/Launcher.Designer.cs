namespace LauncherExample
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
            this.ProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.InstallationStatus = new MetroFramework.Controls.MetroLabel();
            this.LaunchButton = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.GameStatus = new MetroFramework.Controls.MetroLabel();
            this.ServerTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.ProgressBarStatusText = new MetroFramework.Controls.MetroLabel();
            this.DownloadStatus = new MetroFramework.Controls.MetroLabel();
            this.InstalledMods = new MetroFramework.Controls.MetroTile();
            this.PatchURL = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.IntegrityStatus = new MetroFramework.Controls.MetroLabel();
            this.InstallationHash = new MetroFramework.Controls.MetroTextBox();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.ServerCompatibilityl = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(23, 404);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(754, 23);
            this.ProgressBar.TabIndex = 0;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 64);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(111, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Installation Status:";
            // 
            // InstallationStatus
            // 
            this.InstallationStatus.AutoSize = true;
            this.InstallationStatus.Location = new System.Drawing.Point(141, 63);
            this.InstallationStatus.Name = "InstallationStatus";
            this.InstallationStatus.Size = new System.Drawing.Size(0, 0);
            this.InstallationStatus.TabIndex = 2;
            // 
            // LaunchButton
            // 
            this.LaunchButton.Location = new System.Drawing.Point(283, 332);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(241, 66);
            this.LaunchButton.Style = MetroFramework.MetroColorStyle.Green;
            this.LaunchButton.TabIndex = 3;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 83);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(85, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Game Status:";
            // 
            // GameStatus
            // 
            this.GameStatus.AutoSize = true;
            this.GameStatus.Location = new System.Drawing.Point(141, 83);
            this.GameStatus.Name = "GameStatus";
            this.GameStatus.Size = new System.Drawing.Size(0, 0);
            this.GameStatus.TabIndex = 5;
            // 
            // ServerTextBox
            // 
            this.ServerTextBox.Location = new System.Drawing.Point(141, 105);
            this.ServerTextBox.Name = "ServerTextBox";
            this.ServerTextBox.Size = new System.Drawing.Size(135, 23);
            this.ServerTextBox.TabIndex = 6;
            this.ServerTextBox.Text = "play.psforever.net:51200";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(23, 105);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(51, 19);
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Server:";
            // 
            // ProgressBarStatusText
            // 
            this.ProgressBarStatusText.AutoSize = true;
            this.ProgressBarStatusText.Location = new System.Drawing.Point(283, 404);
            this.ProgressBarStatusText.Name = "ProgressBarStatusText";
            this.ProgressBarStatusText.Size = new System.Drawing.Size(0, 0);
            this.ProgressBarStatusText.TabIndex = 8;
            // 
            // DownloadStatus
            // 
            this.DownloadStatus.AutoSize = true;
            this.DownloadStatus.Location = new System.Drawing.Point(23, 430);
            this.DownloadStatus.Name = "DownloadStatus";
            this.DownloadStatus.Size = new System.Drawing.Size(0, 0);
            this.DownloadStatus.TabIndex = 9;
            // 
            // InstalledMods
            // 
            this.InstalledMods.Location = new System.Drawing.Point(531, 63);
            this.InstalledMods.Name = "InstalledMods";
            this.InstalledMods.Size = new System.Drawing.Size(246, 61);
            this.InstalledMods.TabIndex = 10;
            // 
            // PatchURL
            // 
            this.PatchURL.Location = new System.Drawing.Point(531, 153);
            this.PatchURL.Name = "PatchURL";
            this.PatchURL.PromptText = "URL";
            this.PatchURL.Size = new System.Drawing.Size(246, 23);
            this.PatchURL.TabIndex = 11;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(531, 131);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(106, 19);
            this.metroLabel4.TabIndex = 12;
            this.metroLabel4.Text = "Install new Patch:";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(531, 183);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(103, 23);
            this.metroButton1.TabIndex = 13;
            this.metroButton1.Text = "Install";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(641, 183);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(136, 23);
            this.metroButton2.TabIndex = 14;
            this.metroButton2.Text = "Remove All Patches";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(23, 131);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(88, 19);
            this.metroLabel5.TabIndex = 15;
            this.metroLabel5.Text = "Current Hash:";
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(641, 212);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(136, 23);
            this.metroButton3.TabIndex = 17;
            this.metroButton3.Text = "Verify GameInstallation";
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(531, 238);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(111, 38);
            this.metroLabel6.TabIndex = 18;
            this.metroLabel6.Text = "Current\r\nInstallation Status:";
            // 
            // IntegrityStatus
            // 
            this.IntegrityStatus.AutoSize = true;
            this.IntegrityStatus.Location = new System.Drawing.Point(641, 257);
            this.IntegrityStatus.Name = "IntegrityStatus";
            this.IntegrityStatus.Size = new System.Drawing.Size(66, 19);
            this.IntegrityStatus.TabIndex = 19;
            this.IntegrityStatus.Text = "No Errors";
            // 
            // InstallationHash
            // 
            this.InstallationHash.Location = new System.Drawing.Point(141, 131);
            this.InstallationHash.Name = "InstallationHash";
            this.InstallationHash.Size = new System.Drawing.Size(135, 23);
            this.InstallationHash.TabIndex = 20;
            // 
            // metroButton4
            // 
            this.metroButton4.Location = new System.Drawing.Point(23, 183);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(162, 23);
            this.metroButton4.TabIndex = 21;
            this.metroButton4.Text = "GetServerCompatibility";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // ServerCompatibilityl
            // 
            this.ServerCompatibilityl.AutoSize = true;
            this.ServerCompatibilityl.Location = new System.Drawing.Point(23, 209);
            this.ServerCompatibilityl.Name = "ServerCompatibilityl";
            this.ServerCompatibilityl.Size = new System.Drawing.Size(0, 0);
            this.ServerCompatibilityl.TabIndex = 22;
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ServerCompatibilityl);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.InstallationHash);
            this.Controls.Add(this.IntegrityStatus);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.PatchURL);
            this.Controls.Add(this.InstalledMods);
            this.Controls.Add(this.DownloadStatus);
            this.Controls.Add(this.ProgressBarStatusText);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.ServerTextBox);
            this.Controls.Add(this.GameStatus);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.LaunchButton);
            this.Controls.Add(this.InstallationStatus);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.ProgressBar);
            this.Name = "Launcher";
            this.Resizable = false;
            this.Text = "PSUtil Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Launcher_FormClosing);
            this.Load += new System.EventHandler(this.Launcher_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroProgressBar ProgressBar;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel InstallationStatus;
        private MetroFramework.Controls.MetroButton LaunchButton;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel GameStatus;
        private MetroFramework.Controls.MetroTextBox ServerTextBox;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel ProgressBarStatusText;
        private MetroFramework.Controls.MetroLabel DownloadStatus;
        private MetroFramework.Controls.MetroTile InstalledMods;
        private MetroFramework.Controls.MetroTextBox PatchURL;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel IntegrityStatus;
        private MetroFramework.Controls.MetroTextBox InstallationHash;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroLabel ServerCompatibilityl;
    }
}

