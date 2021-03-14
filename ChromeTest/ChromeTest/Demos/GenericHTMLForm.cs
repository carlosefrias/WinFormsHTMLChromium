using CefSharp;
using CefSharp.WinForms;
using System;
using System.Windows.Forms;

namespace ChromeTest.Demos
{
    public partial class GenericHtmlForm : Form
    {
        private ChromiumWebBrowser _mChromeBrowser;

        private readonly string _mHtmlToDisplay;

        public GenericHtmlForm(string formTitle, string htmlToDisplay)
        {
            InitializeComponent();

            Text = formTitle;

            _mHtmlToDisplay = htmlToDisplay;
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        public static string GetAppLocation()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        private void GenericHTMLForm_Load(object sender, EventArgs e)
        {
            _mChromeBrowser = new ChromiumWebBrowser(_mHtmlToDisplay);

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
    }
}
