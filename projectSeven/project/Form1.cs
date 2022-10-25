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
    public partial class Form1 : Form
    {
        StudentList StudentsBook = new StudentList();
        int id;
        int count = 0;
        public Form1()
        {
            InitializeComponent();
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            TextOfCource.Visible = false;
            ExportToolStripMenuItem.Visible = false;
            button1.Location = new Point(581, 145);
            ToolTip tip1 = new ToolTip();
            tip1.InitialDelay = 1000;
            tip1.ShowAlways = true;
            tip1.SetToolTip(button4, "Найти лучшую(по успеваемости) группу на заданном курсе");
            TextOfCource.Items.Add("1");
            TextOfCource.Items.Add("2");
            TextOfCource.Items.Add("3");
            TextOfCource.Items.Add("4");
        }
        //добавение записи
        private void button1_Click(object sender, EventArgs e)
        {
            Student x = new Student();
            StudentsBook.Add(x);
            Form2 newForm = new Form2(x);
            newForm.Owner = this;
            newForm.ShowDialog();
            if (newForm.DialogResult == DialogResult.OK)
            {
                StudentsBook.list[StudentsBook.list.Count-1] = newForm.tmp;
                listBox1.Items.Add(newForm.tmp._FIO + ", курс " + newForm.tmp._Course + ", группа " + newForm.tmp._Group);
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                TextOfCource.Visible = true;
                ExportToolStripMenuItem.Visible = true;
                button1.Location = new Point(581, 51);
            }
            newForm.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Form2 newForm = new Form2(StudentsBook.list[listBox1.SelectedIndex]);
                newForm.Owner = this;
                newForm.ShowDialog();
                if (newForm.DialogResult == DialogResult.OK)
                {
                    StudentsBook.list[listBox1.SelectedIndex] = newForm.tmp;
                    listBox1.Items.Clear();
                    int size = StudentsBook.list.Count;
                    for (int i = 0; i < size; i++)
                    {
                        listBox1.Items.Add(StudentsBook.list[i]._FIO + ", курс " + StudentsBook.list[i]._Course + ", группа " + StudentsBook.list[i]._Group);
                    }
                }

                newForm.Close();
            }
            else
            {
                MessageBox.Show("Сначала выберите студента", "Информация",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information);
            }
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            id = listBox1.SelectedIndex;
            if (id != -1)
            {
                StudentsBook.list.RemoveAt(id);
                listBox1.Items.RemoveAt(id);
                if (listBox1.Items.Count == 0)
                {
                    button3.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                    button4.Visible = false;
                    TextOfCource.Visible = false;
                    ExportToolStripMenuItem.Visible = false;
                    button1.Location = new Point(581, 145);
                }
                id = 0;
            }
            else
                MessageBox.Show("Сначала выбереите запись");

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TextOfCource_SelectedIndexChanged(sender, e);
            MessageBox.Show("Лучшая группа по успеваемости:" + "\n"
                + StudentsBook.Task(Convert.ToInt32(TextOfCource.Text)), "Информация",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }
        public bool CheckInt(string s)
        {
            int size = s.Length;
            for (int i = 0; i < size; i++)
                if (!((s[i] >= '0') && (s[i] <= '9')))
                    return false;
            return true;
        }
        private void TextOfCource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TextOfCource.Text != "")
            {
                if (CheckInt(TextOfCource.Text))
                {
                    int newCourse = Convert.ToInt32(TextOfCource.Text);
                    if (newCourse > 4)
                        MessageBox.Show("Введено недопустимое значение значение");
                }
                else
                    MessageBox.Show("Введено некорректное значение");
            }
        }
        //сохрание в XML
        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDlg = new SaveFileDialog();
            saveFileDlg.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            if (saveFileDlg.ShowDialog() == DialogResult.OK)
            {
                StudentsBook.SaveXML(saveFileDlg.FileName);
            }
        }
        //сохрание в TXT
        private void tXTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDlg = new SaveFileDialog();
            saveFileDlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDlg.ShowDialog() == DialogResult.OK)
            {
                StudentsBook.Savetxt(saveFileDlg.FileName);
            }
        }
        //сохрание в BIN
        private void bINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDlg = new SaveFileDialog();
            saveFileDlg.Filter = "bin files (*.bin)|*.bin|All files (*.*)|*.*";
            if (saveFileDlg.ShowDialog() == DialogResult.OK)
            {
                StudentsBook.SaveBin(saveFileDlg.FileName);
            }
        }
        //открытие из XML
        private void xMLToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                count = 0;
                listBox1.Items.Clear();
                StudentsBook.LoadXML(openFileDlg.FileName);
                foreach (Student x in StudentsBook.list)
                {
                    listBox1.Items.Add(x._FIO + ", курс " + x._Course + ", группа " + x._Group);
                    count++;
                }
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                TextOfCource.Visible = true;
                ExportToolStripMenuItem.Visible = true;
                button1.Location = new Point(581, 51);
            }
        }

        private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //открытие TXT
        private void tXTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                count = 0;
                listBox1.Items.Clear();
                StudentsBook.Loadtxt(openFileDlg.FileName);
                foreach (Student x in StudentsBook.list)
                {
                    listBox1.Items.Add(x._FIO + ", курс " + x._Course + ", группа " + x._Group);
                    count++;
                }
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                TextOfCource.Visible = true;
                ExportToolStripMenuItem.Visible = true;
                button1.Location = new Point(581, 51);
            }
        }
        //открыть BIN
        private void bINToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "bin files (*.bin)|*.bin|All files (*.*)|*.*";
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                count = 0;
                listBox1.Items.Clear();
                StudentsBook.LoadBin(openFileDlg.FileName);
                foreach (Student x in StudentsBook.list)
                {
                    listBox1.Items.Add(x._FIO + ", курс " + x._Course + ", группа " + x._Group);
                    count++;
                }
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                TextOfCource.Visible = true;
                ExportToolStripMenuItem.Visible = true;
                button1.Location = new Point(581, 51);
            }
        }

        private void TaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Найти лучшую(по успеваемости) группу на заданном курсе");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
