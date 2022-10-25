using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Segmentation
{
    public partial class SegmentationFrom : Form
    {
        private Graphics graphics;
        public SegmentationFrom()
        {
            InitializeComponent();
            graphics = pctBox.CreateGraphics();
          
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == (Char)Keys.Back)
                return;
            e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Helper h = new Helper( graphics, txtBox);
        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            t.SelectionStart = t.Text.Length;
            t.ScrollToCaret();
        }


    }
}
