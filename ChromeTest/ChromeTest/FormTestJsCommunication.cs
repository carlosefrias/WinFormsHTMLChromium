using CefSharp;
using CefSharp.WinForms;
using System;
using System.Windows.Forms;

namespace ChromeTest
{
    public partial class FormTestJsCommunication : Form
    {
        private ChromiumWebBrowser _mChromeBrowser;

        public FormTestJsCommunication()
        {
            InitializeComponent();
        }

        private void FormTestJsCommunication_Load(object sender, EventArgs e)
        {
            Cef.Initialize();
            _mChromeBrowser = new ChromiumWebBrowser("http://www.maps.google.com");

            panel1.Controls.Add(_mChromeBrowser);

        }

        private void FormTestJsCommunication_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
    }
}
