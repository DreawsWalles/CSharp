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
    public partial class FormChoice : Form
    {
        public int choice = -1;
        public FormChoice()
        {
            InitializeComponent();
            Name = "Выбор метода вычисления";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_MouseClick(object sender, MouseEventArgs e)
        {
            choice = 1;
            Close();
        }

        private void radioButton2_MouseClick(object sender, MouseEventArgs e)
        {
            choice = 2;
            Close();
        }
    }
}
