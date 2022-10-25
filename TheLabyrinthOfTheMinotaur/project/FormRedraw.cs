using project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class FormRedraw : Form
    {
        public int? FirstValue = null;
        public int? SecondValue = null;
        public int? ThreeValue = null;
        public int[,] Map;

        Bitmap Folder;
        Bitmap OpenFolder;
        Thread _thread;
        public FormRedraw()
        {
            InitializeComponent();
            _thread = new Thread(new ThreadStart(CheckParams));
            _thread.Start();

            FolderPic.MouseEnter += new EventHandler(FolderEnterHandler);
            FolderPic.MouseLeave += new EventHandler(FolderLeaveHandler);
            FolderPic.Click += new EventHandler(FolderClick);
            Folder = new Bitmap(Resources.Folder);
            OpenFolder = new Bitmap(Resources.Opened_Folder);
            DialogResult = DialogResult.Cancel;
        }

        private void FolderEnterHandler(object sender, EventArgs e)
        {
            FolderPic.Image = OpenFolder;
        }
        private void FolderLeaveHandler(object sender, EventArgs e)
        {
            FolderPic.Image = Folder;
        }
        private void FolderClick(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                fileDialog.FilterIndex = 2;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = fileDialog.FileName;
                    string line = null;
                    try
                    {
                        using (StreamReader file = new StreamReader(filePath))
                        {
                            line = file.ReadLine();
                            if (line == null)
                                throw new Exception("");
                            string[] tmp = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            if (tmp.Count() == 1)
                                throw new Exception("1");
                            if (tmp[0].Trim() != "m:" || tmp.Count() != 2)
                                throw new Exception("param");
                            line = tmp[1];
                            int param;
                            param = Convert.ToInt32(line);
                            if (param <= 0)
                            {
                                MessageBox.Show($"Из файла \"{filePath}\" считаное значение в первой строке меньше или равно 0\nПроверьте ваш файл", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (param > 10)
                            {
                                MessageBox.Show($"Введенное значение \"{param}\" больше 10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            FirstValue = param;
                            line = file.ReadLine();
                            if (line == null)
                                throw new Exception("");
                            tmp = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            if (tmp.Count() == 1)
                                throw new Exception("2");
                            if (tmp[0].Trim() != "n:" || tmp.Count() != 2)
                                throw new Exception("param");
                            line = tmp[1];
                            param = Convert.ToInt32(line);
                            if (param <= 0)
                            {
                                MessageBox.Show($"Из файла \"{filePath}\" считаное значение во второй строке меньше или равно 0\nПроверьте ваш файл", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (param > 20)
                            {
                                MessageBox.Show($"Введенное значение \"{param}\" больше 10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            SecondValue = param;
                            line = file.ReadLine();
                            if (line == null)
                                throw new Exception("");
                            tmp = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            if (tmp.Count() == 1)
                                throw new Exception("3");
                            if (tmp[0].Trim() != "l:" || tmp.Count() != 2)
                                throw new Exception("param");
                            line = tmp[1];
                            param = Convert.ToInt32(line);
                            if (param < 0 || param > 5)
                            {
                                MessageBox.Show($"Из файла \"{filePath}\" считаное значение в третьей строке должно входить в отрезок [0;5]\nПроверьте ваш файл", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            ThreeValue = param;
                            Map = new int[(int)FirstValue, (int)SecondValue];
                            line = file.ReadToEnd();
                            if ((Map = InitMap(line, Map)) == null)
                            {
                                FirstValue = null;
                                SecondValue = null;
                                ThreeValue = null;
                                return;
                            }
                            int countPers = 0;
                            int countGoal = 0;
                            for (int i = 0; i < FirstValue; i++)
                                for (int j = 0; j < SecondValue; j++)
                                {
                                    if (Map[i, j] == 2)
                                        countPers++;
                                    if (Map[i, j] == 3)
                                        countPers++;
                                }
                            if (countPers == 0)
                            {
                                MessageBox.Show($"При считывании карты из файла {filePath} не было считано ни одной стратовой позиции", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                FirstValue = null;
                                SecondValue = null;
                                ThreeValue = null;
                                return;
                            }
                            if (countGoal == 0)
                            {
                                MessageBox.Show($"При считывании карты из файла {filePath} не было считано ни одной конечной позиции", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                FirstValue = null;
                                SecondValue = null;
                                ThreeValue = null;
                                return;
                            }
                            if (countPers > 1)
                            {
                                MessageBox.Show($"При считывании карты из файла {filePath} было считано более одной стратовой позиции", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                FirstValue = null;
                                SecondValue = null;
                                ThreeValue = null;
                                return;
                            }
                            if (countGoal > 1)
                            {
                                MessageBox.Show($"При считывании карты из файла {filePath} было считано более одной конечной позиции", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                FirstValue = null;
                                SecondValue = null;
                                ThreeValue = null;
                                return;
                            }
                            _thread.Abort();
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        if (String.IsNullOrEmpty(ex.Message))
                        {
                            MessageBox.Show($"Из файла \"{filePath}\" считано некорректное значение: \"{line}\".\n" +
                            $"Файл должен имено следующую архитектуру:\n" +
                            $"m: /*Ширина лабиринта*/\n" +
                            $"n: /*Длина лабиринта*/\n" +
                            $"l: /*Количество бомб*/\n" +
                            $"/*Карта лабиринта*/\n" +
                            $"Проверьте ваш файл",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (ex.Message == "1" || ex.Message == "2" || ex.Message == "3")
                        {
                            switch (Convert.ToInt32(ex.Message))
                            {
                                case 1:
                                    MessageBox.Show($"Из файла \"{filePath}\" считано некорректное значение первого параметра: \"{line}\".\n" +
                                "Попробуйте добавить пробел",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                case 2:
                                    MessageBox.Show($"Из файла \"{filePath}\" считано некорректное значение второго параметра: \"{line}\".\n" +
                                "Попробуйте добавить пробел",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                case 3:
                                    MessageBox.Show($"Из файла \"{filePath}\" считано некорректное значение третьего параметра: \"{line}\".\n" +
                                "Попробуйте добавить пробел",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                            }
                        }
                        if (ex.Message == "param")
                        {
                            MessageBox.Show($"Файл \"{filePath}\" имеет некорректную архитектуру.\n" +
                            $"Файл должен имено следующую архитектуру:\n" +
                            $"m: /*Ширина лабиринта*/\n" +
                            $"n: /*Длина лабиринта*/\n" +
                            $"l: /*Количество бомб*/\n" +
                            $"/*Карта лабиринта*/\n" +
                            $"Проверьте ваш файл",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        MessageBox.Show($"Из файла \"{filePath}\" считано некорректное значение: \"{line}\".\n" +
                            $"Файл должен имено следующую архитектуру:\n" +
                            $"n /*Ширина лабиринта*/\n" +
                            $"m /*Длина лабиринта*/\n" +
                            $"l /*Количество бомб*/\n" +
                            $"/*Карта лабиринта*/\n" +
                            $"Проверьте ваш файл",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private int[,] InitMap(string text, int[,] map)
        {
            try
            {
                string[] tmp = text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                int i = 0;
                foreach (string line in tmp)
                {
                    int j = 0;
                    string[] currentLine = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string s in currentLine)
                        try
                        {
                            map[i, j++] = Convert.ToInt32(s);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"При считывании матрицы было считано некорректное значение: \"{s}\".");
                            return null;
                        }
                    i++;
                }
                return map;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Указанные параметры и размеры считанной матрицы не совпадают.");
                return null;
            }
        }
        private void CheckParams()
        {
            while (true)
            {
                if (FirstValue == null || SecondValue == null || ThreeValue == null)
                    buttonBuild.Enabled = false;
                else
                    buttonBuild.Invoke((MethodInvoker)delegate
                    {
                        buttonBuild.Enabled = true;
                    });
            }
        }

        private void FormRedraw_Load(object sender, EventArgs e)
        {
            buttonBuild.Enabled = false;
            textBoxM.Focus();
            MinimumSize = Size;
            tableLayoutPanel1.Size = Size;
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel5);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel6);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel7);
            tableLayoutPanel2.Size = new Size(tableLayoutPanel1.Size.Width - 30, tableLayoutPanel2.Size.Height);
            tableLayoutPanel3.Size = new Size(tableLayoutPanel1.Size.Width - 30, tableLayoutPanel3.Size.Height);
            tableLayoutPanel4.Size = new Size(tableLayoutPanel1.Size.Width - 30, tableLayoutPanel4.Size.Height);
            tableLayoutPanel5.Size = new Size(tableLayoutPanel1.Size.Width - 30, tableLayoutPanel5.Size.Height);
            tableLayoutPanel6.Size = new Size(tableLayoutPanel1.Size.Width, tableLayoutPanel6.Size.Height);
            tableLayoutPanel7.Size = new Size(tableLayoutPanel1.Size.Width, tableLayoutPanel7.Size.Height);


            FolderPic.Image = Folder;
            FolderPic.ClientSize = new Size(Folder.Width + 4, Folder.Height + 4);
        }

        private void FormRedraw_Resize(object sender, EventArgs e)
        {
            tableLayoutPanel2.Size = new Size(tableLayoutPanel1.Size.Width - 30, tableLayoutPanel2.Size.Height);
            tableLayoutPanel3.Size = new Size(tableLayoutPanel1.Size.Width - 30, tableLayoutPanel3.Size.Height);
            tableLayoutPanel4.Size = new Size(tableLayoutPanel1.Size.Width - 30, tableLayoutPanel4.Size.Height);
            tableLayoutPanel5.Size = new Size(tableLayoutPanel1.Size.Width - 30, tableLayoutPanel5.Size.Height);
            tableLayoutPanel6.Size = new Size(tableLayoutPanel1.Size.Width, tableLayoutPanel6.Size.Height);
            tableLayoutPanel7.Size = new Size(tableLayoutPanel1.Size.Width, tableLayoutPanel7.Size.Height);
        }

        private void textBoxM_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int? param = null;
                if (textBoxM.Text.Length > 0)
                    param = Convert.ToInt32(textBoxM.Text);
                if (param == 0)
                {
                    MessageBox.Show($"Введенное значение \"{param}\" равно 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxM.MaxLength = textBoxM.Text.Length;
                    FirstValue = null;
                    return;
                }
                if (param > 10)
                {
                    MessageBox.Show($"Введенное значение \"{param}\" больше 10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxM.MaxLength = textBoxM.Text.Length;
                    FirstValue = null;
                    return;
                }
                textBoxM.MaxLength = 2;
                FirstValue = param;
            }
            catch
            {
                MessageBox.Show($"Введен некорректный символ: {textBoxM.Text[textBoxM.Text.Length - 1]}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxM.MaxLength = textBoxM.Text.Length;
                FirstValue = null;
            }
        }

        private void textBoxL_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int? param = null;
                if (textBoxL.Text.Length > 0)
                {
                    param = Convert.ToInt32(textBoxL.Text);
                    if (param < 0 || param > 5)
                    {
                        MessageBox.Show("Значение должно быть от 0 до 5", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxL.MaxLength = textBoxL.Text.Length;
                        ThreeValue = null;
                        return;
                    }
                    ThreeValue = param;
                    textBoxL.MaxLength = 2;
                }
            }
            catch
            {
                MessageBox.Show($"Введен некорректный символ: {textBoxL.Text[textBoxL.Text.Length - 1]}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxL.MaxLength = textBoxL.Text.Length;
                SecondValue = null;
            }
        }

        private void textBoxN_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int? param = null;
                if (textBoxN.Text.Length > 0)
                    param = Convert.ToInt32(textBoxN.Text);
                if (param == 0)
                {
                    MessageBox.Show($"Введенное значение \"{param}\" равно 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxN.MaxLength = textBoxN.Text.Length;
                    SecondValue = null;
                    return;
                }
                if (param > 20)
                {
                    MessageBox.Show($"Введенное значение \"{param}\" больше 20", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxN.MaxLength = textBoxN.Text.Length;
                    SecondValue = null;
                    return;
                }
                textBoxN.MaxLength = 2;
                SecondValue = param;
            }
            catch
            {
                MessageBox.Show($"Введен некорректный символ: {textBoxN.Text[textBoxN.Text.Length - 1]}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxN.MaxLength = textBoxN.Text.Length;
                SecondValue = null;
            }
        }

        private void buttonBuild_Click(object sender, EventArgs e)
        {
            _thread.Abort();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            _thread.Abort();
            DialogResult=DialogResult.Cancel;
            Close();
        }
    }
}
