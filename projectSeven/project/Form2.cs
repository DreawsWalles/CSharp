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
    public partial class Form2 : Form
    {
        public Student tmp = new Student();
        int index = -1;
        public Form2(Student x)
        {
            InitializeComponent();
            tmp._FIO = x._FIO;
            tmp._Course = x._Course;
            tmp._Group = x._Group;
            tmp._budget = x._budget;
            int CountSession= tmp._Course * 2;
            tmp._sessions = new Sessia[CountSession];
            for (int i = 0; i < CountSession; ++i)
            {
                tmp._sessions[i] = new Sessia();
            }

            for (int i = 0; i < tmp._Course * 2; ++i)//записываем каждую сессию
            {
                for (int j = 0; j < 5; ++j)//каждый экзамен
                {
                    tmp._sessions[i]._exams[j]._nameOfexam = x._sessions[i]._exams[j]._nameOfexam;
                    tmp._sessions[i]._exams[j]._mark = x._sessions[i]._exams[j]._mark;
                }
            }
            //заносим значения на формочку
            textBox1.Text = tmp._FIO;
            comboBox1.Text = (tmp._Course).ToString();
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox1.Items.Add("4");
            textBox2.Text = (tmp._Group).ToString();
            comboBox2.Text = (tmp._budget ? "Бюджет" : "Договор");
            comboBox2.Items.Add("Бюджет");
            comboBox2.Items.Add("Договор");
            numericUpDown1.Maximum = 5;
            numericUpDown1.Minimum = 0;
            numericUpDown1.Visible = false;
            numericUpDown2.Maximum = 5;
            numericUpDown2.Minimum = 0;
            numericUpDown2.Visible = false;
            numericUpDown3.Maximum = 5;
            numericUpDown3.Minimum = 0;
            numericUpDown3.Visible = false;
            numericUpDown4.Maximum = 5;
            numericUpDown4.Minimum = 0;
            numericUpDown4.Visible = false;
            numericUpDown5.Maximum = 5;
            numericUpDown5.Minimum = 0;
            numericUpDown5.Visible = false;
            Subject.Visible = false;
            Mark.Visible = false;
            panel1.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            Save.Visible = false;
            Cansel.Location = new Point(374,40);
            ChangeList(CountSession);
        }
        private void ChangeList(int CountSessio)
        {
            listBox1.Items.Clear();
            for (int i = 1; i <= CountSessio; ++i)
            {
                listBox1.Items.Add(i.ToString());
            }
        }
        public bool CheckString(string s)
        {
            int size = s.Length;
            for (int i = 0; i < size; i++)
                if (!(((s[i]>='a') && (s[i]<='z')) || ((s[i] >= 'A') && (s[i]<= 'Z')) || (s[i]==' ')))
                    if (!(((s[i] >= 'а') && (s[i] <= 'я')) || ((s[i] >= 'А') && (s[i] <= 'Я')) || (s[i] == ' ')))
                        return false;
            return true;
        }
        public bool CheckInt(string s)
        {
            int size = s.Length;
            for (int i = 0; i < size; i++)
                if (!((s[i] >= '0') && (s[i] <= '9')))
                    return false;
            return true;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (CheckString(textBox1.Text))
            {
                Cansel.Location = new Point(474, 40);
                Save.Visible = true;
            }
            else
            {
                MessageBox.Show("Введены некорректное ФИО");
                Save.Visible = false;
                Cansel.Location = new Point(374, 40);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Cansel.Location = new Point(474, 40);
            Save.Visible = true;
            tmp._sessions[index]._exams[0]._nameOfexam = textBox3.Text;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                if (CheckInt(comboBox1.Text))
                {
                    int newCourse = Convert.ToInt32(comboBox1.Text);
                    if (newCourse > 0)
                    {
                        if ((newCourse <= 4))
                        {
                            if (tmp._Course != newCourse)
                            {
                                tmp._Course = newCourse;
                                int CountSessio = tmp._Course * 2;
                                tmp._sessions = new Sessia[CountSessio];
                                for (int i = 0; i < CountSessio; ++i)
                                {
                                    tmp._sessions[i] = new Sessia();
                                }
                                Cansel.Location = new Point(474, 40);
                                Save.Visible = true;
                                ChangeList(CountSessio);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введено недопустимое значение значение");
                            Save.Visible = false;
                            Cansel.Location = new Point(374, 40);
                        }
                    }
                    else
                    {
                        Save.Visible = false;
                        Cansel.Location = new Point(374, 40);
                        listBox1.Items.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Введено некорректное значение");
                    Save.Visible = false;
                    Cansel.Location = new Point(374, 40);
                }
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            index = listBox1.SelectedIndex;//узнаем индекс выбранной сессии
            if (index != -1)
            {
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                numericUpDown3.Visible = true;
                numericUpDown4.Visible = true;
                numericUpDown5.Visible = true;
                Subject.Visible = true;
                Mark.Visible = true;
                panel1.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                Save.Visible = true;
                Cansel.Location = new Point(474, 40);
                textBox3.Text = tmp._sessions[index]._exams[0]._nameOfexam;
                numericUpDown1.Value = tmp._sessions[index]._exams[0]._mark;
                textBox4.Text = tmp._sessions[index]._exams[1]._nameOfexam;
                numericUpDown2.Value = tmp._sessions[index]._exams[1]._mark;
                textBox5.Text = tmp._sessions[index]._exams[2]._nameOfexam;
                numericUpDown3.Value = tmp._sessions[index]._exams[2]._mark;
                textBox6.Text = tmp._sessions[index]._exams[3]._nameOfexam;
                numericUpDown4.Value = tmp._sessions[index]._exams[3]._mark;
                textBox7.Text = tmp._sessions[index]._exams[4]._nameOfexam;
                numericUpDown5.Value = tmp._sessions[index]._exams[4]._mark;
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            //вносим изменения
            
        }

        private void Save_Click_1(object sender, EventArgs e)
        {
            tmp._FIO = textBox1.Text;
            tmp._Group = Int32.Parse(textBox2.Text);
            tmp._budget = (comboBox2.Text == "Бюджет");
            this.DialogResult = DialogResult.OK;
        }

        private void Cansel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (CheckInt(textBox2.Text))
                {
                    int i = Convert.ToInt32(textBox2.Text);
                    if (i >= 0)
                    {
                        Cansel.Location = new Point(474, 40);
                        Save.Visible = true;
                    }
                    else
                    {
                        if (i == 0)
                        {
                            Save.Visible = false;
                            Cansel.Location = new Point(374, 40);
                        }
                        else
                        {
                            MessageBox.Show("Введено недопустимое значение значение");
                            Save.Visible = false;
                            Cansel.Location = new Point(374, 40);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введено некорректное значение");
                    Save.Visible = false;
                    Cansel.Location = new Point(374, 40);
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Cansel.Location = new Point(474, 40);
            Save.Visible = true;
            tmp._sessions[index]._exams[0]._nameOfexam = textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Cansel.Location = new Point(474, 40);
            Save.Visible = true;
            tmp._sessions[index]._exams[2]._nameOfexam = textBox5.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            Cansel.Location = new Point(474, 40);
            Save.Visible = true;
            tmp._sessions[index]._exams[3]._nameOfexam = textBox6.Text;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            Cansel.Location = new Point(474, 40);
            Save.Visible = true;
            tmp._sessions[index]._exams[4]._nameOfexam = textBox7.Text;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Cansel.Location = new Point(474, 40);
            Save.Visible = true;
            tmp._sessions[index]._exams[0]._mark = (int)(numericUpDown1.Value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Cansel.Location = new Point(474, 40);
            Save.Visible = true;
            tmp._sessions[index]._exams[1]._mark = (int)(numericUpDown2.Value);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Cansel.Location = new Point(474, 40);
            Save.Visible = true;
            tmp._sessions[index]._exams[2]._mark = (int)(numericUpDown3.Value);
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            Cansel.Location = new Point(474, 40);
            Save.Visible = true;
            tmp._sessions[index]._exams[3]._mark = (int)(numericUpDown4.Value);
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            Cansel.Location = new Point(474, 40);
            Save.Visible = true;
            tmp._sessions[index]._exams[4]._mark = (int)(numericUpDown5.Value);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboBox2.Text.Length == 6) || (comboBox2.Text.Length == 7))
            if (CheckString(comboBox2.Text))
            {
                Cansel.Location = new Point(474, 40);
                Save.Visible = true;
                if (comboBox2.Text != "Бюджет") 
                        if (comboBox2.Text != "бюджет") 
                            if(comboBox2.Text != "БЮДЖЕТ")
                                if (comboBox2.Text != "Договор") 
                                    if (comboBox2.Text != "договор") 
                                        if (comboBox2.Text != "ДОГОВОР")
                                            {
                                                MessageBox.Show("Введены некорректные данные");
                                                Save.Visible = false;
                                                Cansel.Location = new Point(374, 40);
                                            }
            }
            else
            {
                MessageBox.Show("Введены некорректные данные");
                Save.Visible = false;
                Cansel.Location = new Point(374, 40);
            }
        }
    }
}
