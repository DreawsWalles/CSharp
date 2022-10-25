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
    public partial class FrmInputElement : Form
    {
        public string[] information = new string[7];
        private bool[] isOkey = new bool[7];
        public FrmInputElement()
        {
            InitializeComponent();
            ActiveControl = Add;
            textBox4.Text = "Введите название фильма";
            textBox4.ForeColor = Color.Gray;
            textBox3.Text = "Введите название киностудии";
            textBox3.ForeColor = Color.Gray;
            textBox1.Text = "Введите режиссера";
            textBox1.ForeColor = Color.Gray;
            textBox2.Text = "Введите продолжительсть";
            textBox2.ForeColor = Color.Gray;
            textBox5.Text = "Введите призы";
            textBox5.ForeColor = Color.Gray;
            ToolTip tip = new ToolTip();
            tip.AutoPopDelay = 5000;
            tip.InitialDelay = 1000;
            tip.ReshowDelay = 500;
            tip.ShowAlways = true;
            tip.SetToolTip(textBox5, "Вводите призы через запитую. Если призы отсутсвуют введите -");
            textBox6.Text = "Введите главных героев";
            textBox6.ForeColor = Color.Gray;
            MaximumSize = Size;
            MinimumSize = Size;
            BackColor = Color.FromArgb(166, 4, 0);
            textBox1.BackColor = Color.FromArgb(255, 180, 115);
            textBox2.BackColor = Color.FromArgb(255, 180, 115);
            textBox3.BackColor = Color.FromArgb(255, 180, 115);
            textBox4.BackColor = Color.FromArgb(255, 180, 115);
            textBox5.BackColor = Color.FromArgb(255, 180, 115);
            textBox6.BackColor = Color.FromArgb(255, 180, 115);
            Add.BackColor = Color.FromArgb(255, 118, 115);
            button2.BackColor = Color.FromArgb(255, 118, 115);
            button3.BackColor = Color.FromArgb(255, 118, 115);
        }
        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox4.ForeColor = Color.Black;
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.TextLength == 0)
            {
                textBox4.Text = "Введите название фильма";
                textBox4.ForeColor = System.Drawing.Color.Gray;
            }
            else
            {
                information[0] = textBox4.Text;
                isOkey[0] = true;
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            information[1] = dateTimePicker1.Value.ToString();
            isOkey[1] = true;
            int i = 0;
            while (i < 7 && isOkey[i])
                i++;
            if (i != 7)
            {
                MessageBox.Show("Не все поля заполнены", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();

        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox3.ForeColor = Color.Black;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.TextLength == 0)
            {
                textBox3.Text = "Введите название киностудии";
                textBox3.ForeColor = System.Drawing.Color.Gray;
            }
            else
            {
                information[2] = textBox3.Text;
                isOkey[2] = true;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0)
            {
                textBox1.Text = "Введите режиссера";
                textBox1.ForeColor = System.Drawing.Color.Gray;
            }
            else
            {
                information[3] = textBox1.Text;
                isOkey[3] = true;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.ForeColor = Color.Black;
        }

        private int CheckChoise(string s)
        {
            int num;
            if (s.Length == 0)
            {
                MessageBox.Show("Считана пустая строка. Повторите ввод", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else
            {
                num = 0;
                int len = s.Length;
                int i = 0;
                int n;
                while (i < len)
                    if ((s[i] >= '0') && (s[i] <= '9'))
                    {
                        n = s[i] - '0';
                        num = num * 10 + n;
                        i++;
                    }
                    else
                    {
                        string message = "Считан некорректный символ: " + s[i] + " . Повторите ввод";
                        MessageBox.Show(message, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                if (num < 0)
                {

                    MessageBox.Show("Считанное значение некорректно.Значение должно быть больше 0", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                return num;
            }
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.TextLength == 0)
            { 
                textBox2.Text = "Введите продолжительсть";
                textBox2.ForeColor = System.Drawing.Color.Gray;
            }
            else
            {
                if (CheckChoise(textBox2.Text) != -1)
                {
                    information[4] = textBox2.Text;
                    isOkey[4] = true;
                }
                else
                {
                    textBox2.Text = "Введите продолжительсть";
                    textBox2.ForeColor = System.Drawing.Color.Gray;
                }
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox5.ForeColor = Color.Black;
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.TextLength == 0)
            {
                textBox5.Text = "Введите призы";
                textBox5.ForeColor = System.Drawing.Color.Gray;
            }
            else
            {
                information[5] = textBox5.Text;
                isOkey[5] = true;
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            textBox6.Text = "";
            textBox6.ForeColor = Color.Black;
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.TextLength == 0)
            {
                textBox6.Text = "Введите главных героев";
                textBox6.ForeColor = System.Drawing.Color.Gray;
            }
            else
            {
                information[6] = textBox6.Text;
                isOkey[6] = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmInput form = new FrmInput("Введите призы, отделяя их запятой");
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                textBox5.Text = form.field;
                isOkey[5] = true;
                information[5] = form.field;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmInput form = new FrmInput("Введите главных героев, отделяя их запятой");
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                textBox6.Text = form.field;
                isOkey[6] = true;
                information[6] = form.field;
            }
        }
    }
}
