using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskThree
{
    public partial class FormChoice : Form
    {
        public int Choice { get; set; }
        public FormChoice()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void FormChoice_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 34, Size.Height - 44);
            tableLayoutPanel2.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnGuide_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Choice = 1;
        }

        private void btnEncyclopedia_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Choice = 2;
        }
    }
}
