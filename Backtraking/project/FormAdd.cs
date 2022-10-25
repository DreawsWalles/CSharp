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
    public partial class FormAdd : Form
    {
        public int up;
        public int down;
        public FormAdd()
        {
            InitializeComponent();            
            BackColor = Color.FromArgb(189, 147, 84);
            MaximumSize = Size;
            MinimumSize = Size;
            Up.ValueChanged += new EventHandler(ValueChanged);
            Down.ValueChanged += new EventHandler(ValueChanged);
            panel1.Controls.Add(Drawing.CreateFigure((int)Up.Value, (int)Down.Value, Color.FromArgb(133, 96, 63), Color.White));
            button_ok.BackColor = Color.FromArgb(189, 147, 84);
            button_ok.FlatAppearance.MouseDownBackColor = Color.FromArgb(189, 147, 84);
            button_ok.FlatAppearance.MouseOverBackColor = Color.FromArgb(189, 147, 84);
            button_ok.FlatStyle = FlatStyle.Flat;
            button_ok.ForeColor = Color.Indigo;
            button_cancel.ForeColor = Color.Indigo;

            button_cancel.BackColor = Color.FromArgb(189, 147, 84);
            button_cancel.FlatAppearance.MouseDownBackColor = Color.FromArgb(189, 147, 84);
            button_cancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(189, 147, 84);
            button_cancel.FlatStyle = FlatStyle.Flat;

        }
        private void ValueChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(Drawing.CreateFigure((int)Up.Value, (int)Down.Value, Color.FromArgb(133, 96, 63), Color.White));
        }

        private void button_ok_MouseEnter(object sender, EventArgs e)
        {
            button_ok.ForeColor = Color.Green;
        }

        private void button_ok_MouseLeave(object sender, EventArgs e)
        {
            button_ok.ForeColor = Color.Indigo;
        }

        private void button_cancel_MouseEnter(object sender, EventArgs e)
        {
            button_cancel.ForeColor = Color.Red;
        }

        private void button_cancel_MouseLeave(object sender, EventArgs e)
        {
            button_cancel.ForeColor = Color.Indigo;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            up = (int)Up.Value;
            down = (int)Down.Value;
            Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
