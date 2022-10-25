using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Reflection;

namespace project
{
    public partial class FormInputElement : Form
    {
        public int type;
        public int result_int;
        public float result_float;
        public char result_char;
        public double result_double;
        public bool result_bool;
        public string result_string;
        public MyType result_myType;
        string date;
        public FormInputElement(int t)
        {
            type = t;
            InitializeComponent();
            MaximumSize = Size;
            MinimumSize = Size;
            textBox1.Text = "Введите элемент";
            textBox1.ForeColor = Color.Gray;
            ActiveControl = Accept;
            label1.Visible = false;
            if (type != 7)
            {
                button_date.Visible = false;
                button_name.Visible = false;
            }
            else
            {
                result_myType = new MyType();
                button_date.BackColor = Color.OrangeRed;
                button_date.ForeColor = Color.White;
                button_date.FlatAppearance.MouseOverBackColor = Color.Tomato;
                button_date.FlatAppearance.MouseDownBackColor = Color.OrangeRed;
                
            }
        }

        private void Accept_MouseLeave(object sender, EventArgs e)
        {
            Accept.ForeColor = Color.White;
            Accept.BackColor = Color.OrangeRed;
        }

        private void Accept_MouseEnter(object sender, EventArgs e)
        {
            Accept.BackColor = Color.Chartreuse;
            Accept.ForeColor = Color.Black;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                textBox1.Text = "Введите элемент";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private bool Check()
        {
            switch (type)
            {
                //int
                case 1:
                    foreach(char sim in textBox1.Text)
                    {
                        if ((sim < '0') || (sim > '9'))
                        {
                            label1.Visible = true;
                            label1.Text = "Введен недопустимый символ: " + sim;
                            return false;
                        }
                    }
                    result_int = Convert.ToInt32(textBox1.Text);
                    break;
                //float
                case 2:
                    if (textBox1.Text[0] == ',')
                        return false;
                    else
                    {
                        int count = 0;
                        int pos = 0;
                        while (pos < textBox1.Text.Length && count <2)
                        {
                            if (textBox1.Text[pos] == ',')
                                count++;
                            else
                            {
                                if ((textBox1.Text[pos] >= '0') && (textBox1.Text[pos] <= '9'))
                                    pos++;
                                else
                                {
                                    label1.Visible = true;
                                    label1.Text = "Введен недопустимый символ: " + textBox1.Text[pos];
                                    return false;
                                }
                            }
                        }
                        if (count == 2)
                            return false;
                        result_float = float.Parse(textBox1.Text);
                    }
                    break;

                //char
                case 3:
                    if (textBox1.Text.Length > 1)
                    {
                        label1.Visible = true;
                        label1.Text = "Некорректно введенные данные.\nДопустим только один символ";
                        return false;
                    }
                    else
                        result_char = textBox1.Text[0];
                    break;
                //double
                case 4:
                    if (textBox1.Text[0] == ',')
                        return false;
                    else
                    {
                        int count = 0;
                        int pos = 0;
                        while (pos < textBox1.Text.Length && count < 2)
                        {
                            if (textBox1.Text[pos] == ',')
                                count++;
                            else
                            {
                                if ((textBox1.Text[pos] >= '0') && (textBox1.Text[pos] <= '9'))
                                    pos++;
                                else
                                {
                                    label1.Visible = true;
                                    label1.Text = "Введен недопустимый символ: " + textBox1.Text[pos];
                                    return false;
                                }
                            }
                        }
                        if (count == 2)
                            return false;
                        result_double = Convert.ToDouble(textBox1.Text);
                    }
                    break;
                //bool
                case 5:
                    if (textBox1.Text == "1" || textBox1.Text == "0")
                    {
                        if (textBox1.Text == "1")
                            result_bool = true;
                        else
                            result_bool = false;
                    }
                    else
                    {
                        string text = textBox1.Text.ToLowerInvariant();
                        if (text == "true" || text == "false")
                            if (text == "true")
                                result_bool = true;
                            else
                                result_bool = false;
                        else
                        {
                            label1.Visible = true;
                            label1.Text = "Некорректно введенные данные.\nДопустимо: 0, 1, true, false";
                            return false;
                        }
                    }
                    break;
                //string
                case 6:
                    result_string = textBox1.Text;
                    break;
                //My Type
                case 7:
                    if (date != null && result_myType.name != null)
                    {
                        DateTime scheduleDate;
                        if (!DateTime.TryParse(date, out scheduleDate))
                        {
                            MessageBox.Show("Некорректно введены данные\nФормат даты:dd.mm.yyyy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        result_myType.date = scheduleDate;
                    }
                    break;
            }
            return true;
        }
        private void Accept_Click(object sender, EventArgs e)
        {
            if (type == 7)
            {
                if (button_date.BackColor == Color.OrangeRed)
                    date = textBox1.Text;
                if (button_name.BackColor == Color.OrangeRed)
                    result_myType.name = textBox1.Text;
            }
            if (textBox1.Text == "" || textBox1.ForeColor == Color.Gray)
                MessageBox.Show("Введите элемент", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (Check())
            {
                DialogResult = DialogResult.OK;
                Close();
            }    
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void button_date_Click(object sender, EventArgs e)
        {
            if (button_date.BackColor != Color.OrangeRed)
            {
                button_date.BackColor = Color.OrangeRed;
                button_date.ForeColor = Color.White;
                button_date.FlatAppearance.MouseOverBackColor = Color.Tomato;
                button_date.FlatAppearance.MouseDownBackColor = Color.OrangeRed;
                button_name.BackColor = Color.DarkCyan;
                button_name.ForeColor = Color.Thistle;
                button_name.FlatAppearance.MouseDownBackColor = Color.DarkCyan;
                button_name.FlatAppearance.MouseOverBackColor = Color.Indigo;
                if (textBox1.Text != "Введите элемент" || textBox1.Text != "")
                    result_myType.name = textBox1.Text;
                else
                    result_myType.name = null;
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void button_name_Click(object sender, EventArgs e)
        {
            if (button_name.BackColor != Color.OrangeRed)
            {
                button_name.BackColor = Color.OrangeRed;
                button_name.ForeColor = Color.White;
                button_name.FlatAppearance.MouseOverBackColor = Color.Tomato;
                button_name.FlatAppearance.MouseDownBackColor = Color.OrangeRed;
                button_date.BackColor = Color.DarkCyan;
                button_date.ForeColor = Color.Thistle;
                button_date.FlatAppearance.MouseOverBackColor = Color.Indigo;
                button_date.FlatAppearance.MouseDownBackColor = Color.DarkCyan;
                if (textBox1.Text != "Введите элемент" || textBox1.Text != "")
                    date = textBox1.Text;
                else
                    date = null;
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void FormInputElement_FormClosed(object sender, FormClosedEventArgs e)
        {
          
          //  DialogResult = DialogResult.Cancel;
        }
    }
}
