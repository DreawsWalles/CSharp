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
    public partial class FormTask : Form
    {
        public FormTask(Bones list, Size size)
        {
            InitializeComponent();
            BackColor = Color.FromArgb(189, 147, 84);
            panel1.BackColor = Color.FromArgb(227, 209, 138);
            panel2.BackColor = Color.FromArgb(227, 209, 138);
            label1.Text += list.Count.ToString();
            button_close.BackgroundImage = Drawing.DrawIconTitleTask(Color.Indigo, "Close").Image;
            button_close.FlatAppearance.MouseDownBackColor = Color.FromArgb(189, 147, 84);
            button_close.FlatAppearance.MouseOverBackColor = Color.FromArgb(189, 147, 84);
            Bones allList = list.Copy();
            Bones result = allList.GetMaxChain();
            panel1.Size = size;
            panel2.Width = panel1.Width;
            for (int i = 0; i < allList.Count; i++)
                Drawing.AddElementInPanel(ref panel1, Drawing.CreateFigure(allList[i].up, allList[i].down, Color.FromArgb(133, 96, 63), Color.White));
            if (panel1.Controls[panel1.Controls.Count - 1].Location.Y + 79 < panel1.Height)
                panel1.Height -= 80;
            Size = new Size(panel1.Width + 60, Height);
            label2.Text += result.Count.ToString();
            label2.Location = new Point(label2.Location.X, panel1.Location.Y + panel1.Height + 10);
            panel2.Location = new Point(panel2.Location.X, label2.Location.Y + label2.Height + 10);
            Drawing.AddElementInPanel(ref panel2, Drawing.CreateFigure(result[0].down, result[0].up, Color.FromArgb(133, 96, 63), Color.White));
            for (int i = 1; i < result.Count; i++)
                Drawing.AddElementInPanel(ref panel2, result[i]);
            panel2.Height = panel2.Controls[panel2.Controls.Count - 1].Location.Y + 110;
            Height = panel2.Location.Y + panel2.Height + 70;
            button_close.Location = new Point(Width / 2 - 37, Height - 65);
            MaximumSize = Size;
            MinimumSize = Size;
        }

        private void button_close_MouseEnter(object sender, EventArgs e)
        {
            button_close.BackgroundImage = Drawing.DrawIconTitleTask(Color.DarkViolet, "Close").Image;
        }

        private void button_close_MouseLeave(object sender, EventArgs e)
        {
            button_close.BackgroundImage = Drawing.DrawIconTitleTask(Color.Indigo, "Close").Image;
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
