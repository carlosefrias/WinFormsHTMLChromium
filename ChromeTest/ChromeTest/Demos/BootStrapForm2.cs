using CefSharp;
using CefSharp.WinForms;
using System;
using System.Windows.Forms;

namespace ChromeTest.Demos
{
    public partial class BootStrapForm2 : Form
    {
        private ChromiumWebBrowser _mChromeBrowser;

        private SomeClass _mJavascriptSvc;

        public BootStrapForm2()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private static string GetAppLocation()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        private void BootStrapForm2_Load(object sender, EventArgs e)
        {
            var page = $"{GetAppLocation()}HTMLResources/html/BootstrapFormExample.html";
            _mChromeBrowser = new ChromiumWebBrowser(page);
            _mJavascriptSvc = new SomeClass(_mChromeBrowser);


            // Register the JavaScriptInteractionObj class with JS
            _mChromeBrowser.RegisterJsObject("winformObj", _mJavascriptSvc);

            Controls.Add(_mChromeBrowser);

            ChromeDevToolsSystemMenu.CreateSysMenu(this);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // Test if the About item was selected from the system menu
            if (m.Msg == ChromeDevToolsSystemMenu.WmSysCommand && ((int)m.WParam == ChromeDevToolsSystemMenu.SYSMENU_CHROME_DEV_TOOLS))
            {
                _mChromeBrowser.ShowDevTools();
            }
        }

        private void BootStrapForm2_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void BootStrapForm2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                _mChromeBrowser.ShowDevTools();
            }
        }

        private void BootStrapForm2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }
    }

    public class SomeClass
    {
        public Person m_theMan = null;

        [JavascriptIgnore] private ChromiumWebBrowser MChromeBrowser { get; }

        public SomeClass(ChromiumWebBrowser webBrowser )
        {
            MChromeBrowser = webBrowser;
        }

        public string SomeFunction()
        {
            return "yippieee";
        }

        public void ButtonPressed(string buttonName)
        {
            //MessageBox.Show(string.Format("Message box from C# winforms. Msg: {0}", buttonName));

           // var script = "document.body.style.backgroundColor = 'red';";
            //var script = "$('#inputEmail').val('a@a.com');";

            // var script = "var x = 1234";
            const string script = "msgBoxFromJavaScript();";

            MChromeBrowser.ExecuteScriptAsync(script);
        }
    }
}
