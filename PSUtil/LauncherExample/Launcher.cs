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
                ProgressBar.Invoke(new Action(() => { ProgressBar.Value = Client.GetProgress();  }));
                Thread.Sleep(100);
            });
        }

        private void Launcher_FormClosing(object sender, FormClosingEventArgs e)
        {
            Client.SaveClient();
        }
    }
}
