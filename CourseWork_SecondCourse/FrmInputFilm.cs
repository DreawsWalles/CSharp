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
    public partial class FrmInputFilm : Form
    {
        public string[] information = new string[7];
        private bool[] isOkey = new bool[7];
        /// <summary>
        /// 0- Добавление элемента
        /// 1- Уведомление
        /// 2- Ошибка
        /// </summary>
        public string[] Titles;
        /// <summary>
        /// 0- Не все поля заполнены
        /// 1- Введена пустая строка. Повторите ввод
        /// </summary>
        public string[] Notofocations;
        /// <summary>
        ///[0] = "Введите название фильма";
        ///[1] = "Введите название киностудии";
        ///[2] = "Введите режиссера";
        ///[3] = "Введите продолжительсть";
        ///[4] = "Введите призы";
        ///[5] = "Введите призы через запитую. Если призы отсутсвуют введите -";
        ///[6] = "Введите главных героев";
        ///[7] = "Считан некорректный символ: ";
        ///[8] = " . Повторите ввод";
        ///[9] = "Считанное значение некорректно.Значение должно быть больше 0";
        ///[10] = "Введите призы, отделяя их запятой";
        ///[11] = "Введите главных героев, отделяя их запятой";
        /// </summary>
        public string[] TextForUser;
        public Label[] labels;
        public Button BtnAdd { get; set; }
        public Button BtnMore_1 { get; set; }
        public Button BtnMore_2 { get; set; }
        Settings set;
        public FrmInputFilm()
        {
            set = new Settings();
            InitializeComponent();
            TextForUser = new string[12];
            Notofocations = new string[2];
            Titles = new string[3];
            labels = new Label[7];
            labels[0] = label1;
            labels[1] = label2;
            labels[2] = label3;
            labels[3] = label4;
            labels[4] = label5;
            labels[5] = label6;
            labels[6] = label7;
            set = new Settings();
            Localization.LocalFrmInputFilm(this, set.Node.IsEnglish);
            ActiveControl = Add;
            textBox4.Text = TextForUser[0];
            textBox4.ForeColor = Color.Gray;
            textBox3.Text = TextForUser[1];
            textBox3.ForeColor = Color.Gray;
            textBox1.Text = TextForUser[2];
            textBox1.ForeColor = Color.Gray;
            textBox2.Text = TextForUser[3];
            textBox2.ForeColor = Color.Gray;
            textBox5.Text = TextForUser[4];
            textBox5.ForeColor = Color.Gray;
            ToolTip tip = new ToolTip();
            tip.AutoPopDelay = 5000;
            tip.InitialDelay = 1000;
            tip.ReshowDelay = 500;
            tip.ShowAlways = true;
            tip.SetToolTip(textBox5, TextForUser[5]);
            textBox6.Text = TextForUser[6];
            textBox6.ForeColor = Color.Gray;
            MaximumSize = Size;
            MinimumSize = Size;
            MinimizeBox = false;
            MaximizeBox = false;
            BtnAdd = Add;
            BtnMore_1 = button2;
            BtnMore_2 = button3;
            Text = Titles[0];
            Designer.DesignerFrmInputFilm(this, set.Node.DesignIsDefault);
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
                textBox4.Text = TextForUser[0];
                textBox4.ForeColor = Color.Gray;
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
                MessageBox.Show(Notofocations[0], Titles[2], MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                textBox3.Text = TextForUser[1];
                textBox3.ForeColor = Color.Gray;
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
                textBox1.Text = TextForUser[2];
                textBox1.ForeColor = Color.Gray;
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
                MessageBox.Show(Notofocations[1], Titles[2], MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        string message = TextForUser[7] + s[i] + TextForUser[8];
                        MessageBox.Show(message, Titles[1], MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                if (num < 0)
                {

                    MessageBox.Show(TextForUser[9], Titles[2], MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                return num;
            }
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.TextLength == 0)
            { 
                textBox2.Text = TextForUser[3];
                textBox2.ForeColor = Color.Gray;
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
                    textBox2.Text = TextForUser[3];
                    textBox2.ForeColor = Color.Gray;
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
                textBox5.Text = TextForUser[4];
                textBox5.ForeColor = Color.Gray;
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
                textBox6.Text = TextForUser[6];
                textBox6.ForeColor = Color.Gray;
            }
            else
            {
                information[6] = textBox6.Text;
                isOkey[6] = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmInput form = new FrmInput(TextForUser[10]);
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
            FrmInput form = new FrmInput(TextForUser[11]);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                textBox6.Text = form.field;
                isOkey[6] = true;
                information[6] = form.field;
            }
        }

        private void FrmInputFilm_Load(object sender, EventArgs e)
        {

        }
    }
}
