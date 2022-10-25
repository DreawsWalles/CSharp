using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class FormMain : Form
    {
        Finder finder;
        public FormMain()
        {
            InitializeComponent();
            finder = new Finder(textBoxOutput);            
        }

        private void buttonShowDirectories_Click(object sender, EventArgs e)
        {
            finder.ShowDirectories();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            finder.Start();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxOutput.Clear();
        }

        private void textBoxOutput_TextChanged(object sender, EventArgs e)
        {
            textBoxOutput.SelectionStart = textBoxOutput.Text.Length;
            textBoxOutput.ScrollToCaret();
        }
    }
}
