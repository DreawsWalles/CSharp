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
    public partial class FormConvertType : Form
    {
        public int choice = -1;

        //1-int
        //2-float
        //3-char
        //4-double
        //5-bool
        //6-string
        public FormConvertType()
        {
            InitializeComponent();
            button_pred.Visible = false;
            button_double.Visible = false;
            button_bool.Visible = false;
            button_string.Visible = false;
            MaximumSize = Size;
            MinimumSize = Size;
        }

        private void button_int_Click(object sender, EventArgs e)
        {
            choice = 1;
            Close();
        }

        private void button_float_Click(object sender, EventArgs e)
        {
            choice = 2;
            Close();
        }

        private void button_char_Click(object sender, EventArgs e)
        {
            choice = 3;
            Close();
        }

        private void button_double_Click(object sender, EventArgs e)
        {
            choice = 4;
            Close();
        }

        private void button_bool_Click(object sender, EventArgs e)
        {
            choice = 5;
            Close();
        }

        private void button_string_Click(object sender, EventArgs e)
        {
            choice = 6;
            Close();
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            button_int.Visible = false;
            button_float.Visible = false;
            button_char.Visible = false;
            button_double.Visible = true;
            button_bool.Visible = true;
            button_string.Visible = true;
            button_pred.Visible = true;
            button_next.Visible = false;
        }

        private void button_pred_Click(object sender, EventArgs e)
        {
            button_int.Visible = true;
            button_float.Visible = true;
            button_char.Visible = true;
            button_double.Visible = false;
            button_bool.Visible = false;
            button_string.Visible = false;
            button_pred.Visible = false;
            button_next.Visible = true;
        }
    }
}
