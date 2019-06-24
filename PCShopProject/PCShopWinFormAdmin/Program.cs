using System;
using System.Windows.Forms;

namespace PCShopWinFormAdmin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            clsMQTTClient.Instance.ConnectMqttClient();
            Application.Run(frmMain.Instance);
        }
    }
}
