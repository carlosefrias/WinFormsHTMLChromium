using System;
using System.Windows.Forms;

namespace ChromeTest
{
    public partial class ChangeAddressForm : Form
    {
        public ChangeAddressForm()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void ChangeAddressForm_Load(object sender, EventArgs e)
        {

        }
    }
}
