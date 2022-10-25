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
    public partial class FormCondition : Form
    {
        public int doing;
        int type;
        public int result_int;
        public float result_float;
        public char result_char;
        public double result_double;
        public bool result_bool;
        public string result_string;
        public MyType result_myType;
        int i = 0;
        public FormCondition(int t)
        {
            InitializeComponent();
            MaximumSize = Size;
            MinimumSize = Size;
            DialogResult = DialogResult.Cancel;
            type = t;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            i++;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (i != 1)
            {
                DialogResult = DialogResult.OK;
                doing = 1;
                Close();
            }
            else
                i++;
            
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            if (i != 1)
            {
                DialogResult = DialogResult.OK;
                doing = 2;
                Close();
            }
            else
                i++;
            
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            if (i != 1)
            {
                FormInputElement form = new FormInputElement(type);
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    switch (type)
                    {
                        case 1:
                            result_int = form.result_int;
                            break;
                        case 2:
                            result_float = form.result_float;
                            break;
                        case 3:
                            result_char = form.result_char;
                            break;
                        case 4:
                            result_double = form.result_double;
                            break;
                        case 5:
                            result_bool = form.result_bool;
                            break;
                        case 6:
                            result_string = form.result_string;
                            break;
                        case 7:
                            result_myType = form.result_myType;
                            break;
                    }
                    doing = 3;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
                i++;
            
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            if (i != 1)
            {
                FormInputElement form = new FormInputElement(type);
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    switch (type)
                    {
                        case 1:
                            result_int = form.result_int;
                            break;
                        case 2:
                            result_float = form.result_float;
                            break;
                        case 3:
                            result_char = form.result_char;
                            break;
                        case 4:
                            result_double = form.result_double;
                            break;
                        case 5:
                            result_bool = form.result_bool;
                            break;
                        case 6:
                            result_string = form.result_string;
                            break;
                        case 7:
                            result_myType = form.result_myType;
                            break;
                    }
                    doing = 4;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
                i++;
        }
    }
}
