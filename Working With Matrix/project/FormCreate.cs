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
    public partial class FormCreate : Form
    {
        private string name;
        public int sizeObject;
        public string nameObject;
        public FormCreate(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void FormCreate_Load(object sender, EventArgs e)
        {
            Text = "Создание " + name;
            label1.Text = "Название " + name + ":";
            label2.Text = "Размер " + name + ":";
            if (name == "матрицы")
            {
                label1.Location = new Point(20, 10);
                NameObject.Location = new Point(180, 10);
                label2.Location = new Point(38, 40);
                SizeObject.Location = new Point(180, 40);
            }
            else
            {
                label1.Location = new Point(20, 10);
                NameObject.Location = new Point(180, 10);
                label2.Location = new Point(38, 40);
                SizeObject.Location = new Point(180, 40);
            }
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            if (name == "матрицы")
            {
                if (string.IsNullOrEmpty(SizeObject.Text))
                {
                    MessageBox.Show("Введите размер " + name, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (Convert.ToInt32(SizeObject.Text) < 0)
                {
                    MessageBox.Show("Размер " + name + " должен быть положительным", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(NameObject.Text))
                {
                    MessageBox.Show("Введите название " + name, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!DBWork.CheckNameMatrix(NameObject.Text))
                {
                    MessageBox.Show("Название данной " + name + " уже существует", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                sizeObject = Convert.ToInt32(SizeObject.Text);
                nameObject = NameObject.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                if (string.IsNullOrEmpty(SizeObject.Text))
                {
                    MessageBox.Show("Введите размер " + name, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (Convert.ToInt32(SizeObject.Text) < 0)
                {
                    MessageBox.Show("Размер " + name + " должен быть положительным", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(NameObject.Text))
                {
                    MessageBox.Show("Введите название " + name, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!DBWork.CheckNameVector(NameObject.Text))
                {
                    MessageBox.Show("Название данного " + name + " уже существует", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                sizeObject = Convert.ToInt32(SizeObject.Text);
                nameObject = NameObject.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            
        }
    }
}
