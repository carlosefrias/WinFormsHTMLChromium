using CefSharp;
using CefSharp.WinForms;
using System;
using System.Windows.Forms;

namespace ChromeTest.Demos
{
    public partial class BootStrapForm : Form
    {
        private ChromiumWebBrowser _mChromeBrowser;

        public BootStrapForm()
        {
            InitializeComponent();
        }

        private void BootStrapForm_Load(object sender, EventArgs e)
        {
           // Cef.Initialize();

            var page = $"{GetAppLocation()}HTMLResources/html/BootstrapExample.html";
            _mChromeBrowser = new ChromiumWebBrowser(page);

            Controls.Add(_mChromeBrowser);

            ChromeDevToolsSystemMenu.CreateSysMenu(this);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // Test if the About item was selected from the system menu
            if (m.Msg == ChromeDevToolsSystemMenu.WmSysCommand && (int)m.WParam == ChromeDevToolsSystemMenu.SYSMENU_CHROME_DEV_TOOLS)
            {
                _mChromeBrowser.ShowDevTools();
            }
        }

        private void BootStrapForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Cef.Shutdown();
        }

        private static string GetAppLocation()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}
