using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class FrmColor : Form
    {
        public int designIsDefault { get; private set; }
        public string closeFormMessage { get; set; }
        public string closeFormTitle { get; set; }
        public Button BtnAccept { get; set; }
        public Button BtnCancel { get; set; }
        Settings set;
        public FrmColor()
        {
            InitializeComponent();
            BtnAccept = button_accept;
            BtnCancel = button_cancel;
            set = new Settings();
            designIsDefault = set.Node.DesignIsDefault;
            button_defaulte.Click += buttonType_Click;
            button_light_violet.Click += buttonType_Click;
            button_dark.Click += buttonType_Click;
            Localization.LocalFrmColor(this, set.Node.IsEnglish);
            Designer.DesignerFrmColor(this, set.Node.DesignIsDefault);
        }

        private void buttonType_Click(object sender, EventArgs e)
        {
            foreach (object element in Controls)
            {
                try
                {
                    Button button = (Button)element;
                    if (button.FlatAppearance.BorderColor == Color.Red)
                        button.FlatAppearance.BorderColor = Color.Gray;
                }
                catch
                { }
            }
            Button btn = (Button)sender;
            if (designIsDefault != Convert.ToInt32(btn.Tag))
            {
                btn.FlatAppearance.BorderColor = Color.Red;
                designIsDefault = Convert.ToInt32(btn.Tag);
                Designer.DesignerFrmColor(this, designIsDefault);
            }
            else
            {
                btn.FlatAppearance.BorderColor = Color.Gray;
                designIsDefault = -1;
            }
        }
        private void FrmColor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                {
                    DialogResult result = MessageBox.Show(closeFormMessage, closeFormTitle,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                        Close();
                }
            }
            if (e.KeyData == Keys.Enter)
            {
                button_accept_Click(sender, null);
            }
        }

        private void button_accept_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
