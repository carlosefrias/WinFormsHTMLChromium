using System;
using System.Windows.Forms;

namespace ChromeTest.Demos
{
    public partial class DemoLauncherForm : Form
    {
        public DemoLauncherForm()
        {
            InitializeComponent();
        }

        private static string GetAppLocation()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        private void buttonBootstrapDemo1_Click(object sender, EventArgs e)
        {
            var form = new BootStrapForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(@"user pressed ok");
            }
        }

        private void buttonBootstrapDemo2_Click(object sender, EventArgs e)
        {
            var form = new BootStrapForm2();
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(@"user pressed ok");
            }
        }

        private void DemoLauncherForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonGenericHTMLForm_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonCanvasParticleDemo_Click(object sender, EventArgs e)
        {
            var page = $"{GetAppLocation()}HTMLResources/html/canvas-particle.html";

            var form = new GenericHtmlForm("Canvas Particle Example", page);
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(@"user pressed ok");
            }
        }

        private void buttonCanvasBubblesDemo_Click(object sender, EventArgs e)
        {
            var page = $"{GetAppLocation()}HTMLResources/html/canvas-bubbles.html";

            var form = new GenericHtmlForm("Canvas Bubbles Example", page);
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(@"user pressed ok");
            }
        }

        private void buttonCSS3Demo_Click(object sender, EventArgs e)
        {
            var form = new GenericHtmlForm("CSS3 Demo", "http://daneden.github.io/animate.css/");
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(@"user pressed ok");
            }
        }

        private void buttonWebGLDemo_Click(object sender, EventArgs e)
        {
            var form = new GenericHtmlForm("WebGL Demo", "http://www.bongiovi.tw/experiments/webgl/blossom/");// "http://myshards.com/");
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(@"user pressed ok");
            }
        }

        private void buttonBootStrapDemo3_Click(object sender, EventArgs e)
        {
            var page = $"{GetAppLocation()}HTMLResources/html/BootstrapFormExample2.html";

            var form = new GenericHtmlForm("Bootstrap Form Example", page);
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(@"user pressed ok");
            }
        }

        private void buttonAmChartsDemo_Click(object sender, EventArgs e)
        {
            var page = $"{GetAppLocation()}HTMLResources/html/amChartExample.html";

            var form = new GenericHtmlForm("AM Chart Example", page);
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(@"user pressed ok");
            }
        }
    }
}
