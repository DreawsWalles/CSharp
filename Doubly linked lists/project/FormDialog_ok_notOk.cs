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
    public partial class FormDialog_ok_notOk : Form
    {
        public FormDialog_ok_notOk(string message)
        {
            InitializeComponent();
            label1.Text = message;
            
        }

        private void FormDialog_ok_notOk_SizeChanged(object sender, EventArgs e)
        {
            int X = (int)(Width * 0.1);
            int Y = (int)(Height * 0.5);
            ok.Location = new Point(X, Y);
            X = (int)(X * 2 + 80);
            Cansel.Location = new Point(X, Y);
        }

        private void ok_MouseLeave(object sender, EventArgs e)
        {
            ok.ForeColor = Color.White;
        }

        private void ok_MouseEnter(object sender, EventArgs e)
        {
            ok.ForeColor = Color.Black;
        }

        private void Cansel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Hide();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
        }
    }
}
