using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_14
{
    public partial class FormSize : Form
    {
        public int SizeSmoothing = 0;
        public FormSize()
        {
            InitializeComponent();
            MinimumSize = Size;
            MaximumSize = Size;
        }

        private void tableLayoutPanel1_Resize(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 18, Size.Height - 40);
            tableLayoutPanel2.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            trackBar1.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
        }

        private void FormSize_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 18, Size.Height - 40);
            tableLayoutPanel2.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            trackBar1.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = Convert.ToString(trackBar1.Value);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SizeSmoothing = trackBar1.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCansel_Click(object sender, EventArgs e)
        {
            SizeSmoothing = trackBar1.Value;
            DialogResult = DialogResult.Cancel;
            Close(); 
        }
    }
}
