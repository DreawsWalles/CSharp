using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Activities;
using System.IO;

namespace project
{
    public static class TabPageOneWork
    {
        static FormMain form;
        public static void Load(FormMain f)
        {
            form = f;
        }
        public static void Form_Load(object sender, EventArgs e)
        {
            form.tabControl1.Size = form.Size;
            form.sizeMatrix.ReadOnly = true;
            form.tabControl1.Location = new Point(10, 0);
            form.comboBoxMatrix.Location = new Point(form.Size.Width - 190, 2);
            form.comboBoxMatrix.DropDownStyle = ComboBoxStyle.DropDownList;
            form.MinimumSize = form.Size;
            form.dataGridViewMatrix.Size = new Size(form.tabPage1.Width - 80, form.tabPage1.Height - 130);
            form.dataGridViewMatrix.Location = new Point(25, 70);
            form.EditMatrix.Location = new Point(25, 45);
            form.NameMatrix.Location = new Point(60, 45);
            form.NameMatrix.ReadOnly = true;
            form.AcceptMatrix.Location = new Point(25, 45);
            form.CanselMatrix.Location = new Point(255, 45);
            form.RemoveMatrix.Location = new Point(form.Size.Width - 121, 43);
            form.sizeMatrix.Location = new Point(form.Size.Width - 85, Convert.ToInt32(form.Size.Height / 2.1));
            form.label1Matrix.AutoSize = false;
            form.label1Matrix.Text = "<";
            form.label1Matrix.Location = new Point(form.Size.Width - 85, 75);
            for (int i = 1; form.sizeMatrix.Location.Y >= form.label1Matrix.Location.Y + i * 10; i++)
                form.label1Matrix.Text += "=";
            form.label1Matrix.Text += ">";
            form.label2Matrix.AutoSize = false;
            form.label2Matrix.Text = "<";
            form.label2Matrix.Location = new Point(form.Size.Width - 85, form.sizeMatrix.Location.Y + 30);
            for (int i = 1; form.tabPage1.Height - 60 >= form.label2Matrix.Location.Y + i * 10; i++)
                form.label2Matrix.Text += "=";
            form.label2Matrix.Text += ">";
            form.randomMatrix.Location = new Point(form.Size.Width - 196, 46);
        }

        public static void Form_Resize(object sender, EventArgs e)
        {

            form.tabControl1.Size = form.Size;
            form.comboBoxMatrix.Location = new Point(form.Size.Width - 190, 2);
            form.dataGridViewMatrix.Size = new Size(form.tabPage1.Width - 80, form.tabPage1.Height - 130);
            form.RemoveMatrix.Location = new Point(form.Size.Width - 121, 43);
            form.sizeMatrix.Location = new Point(form.Size.Width - 85, Convert.ToInt32(form.Size.Height / 2.1));
            form.label1Matrix.Text = "<";
            form.label1Matrix.Location = new Point(form.Size.Width - 85, 75);
            for (int i = 1; form.sizeMatrix.Location.Y >= form.label1Matrix.Location.Y + i * 10; i++)
                form.label1Matrix.Text += "=";
            form.label1Matrix.Text += ">";
            form.label2Matrix.Text = "<";
            form.label2Matrix.Location = new Point(form.Size.Width - 85, form.sizeMatrix.Location.Y + 30);
            for (int i = 1; form.tabPage1.Height - 60 >= form.label2Matrix.Location.Y + i * 10; i++)
                form.label2Matrix.Text += "=";
            form.label2Matrix.Text += ">";
            form.randomMatrix.Location = new Point(form.Size.Width - 196, 46);
        }
        private static void SaveCurrentMatrix()
        {
            TridiagonalMatrix matrix = new TridiagonalMatrix();
            TridiagonalMatrix otherMatrix = new TridiagonalMatrix();
            string format;
            string filePath;
            try
            {
                filePath = DBWork.GetFilePathMatrix(form.NameMatrix.Text);
                format = DBWork.GetFormatMatrix(form.NameMatrix.Text);
                matrix.Initialize(ConvertDataGridViewToMatrix());
                switch (format)
                {
                    case "txt":
                        using (StreamReader file = new StreamReader(filePath))
                        {
                            otherMatrix.Initialize(file);
                        }
                        break;
                    case "bin":
                        using (BinaryReader file = new BinaryReader(File.Open(filePath, FileMode.Open)))
                        {
                            otherMatrix.Initialize(file);
                        }
                        break;
                    case "XML":
                        using (FileStream file = new FileStream(filePath, FileMode.Open))
                        {
                            otherMatrix.Initialize(file);
                        }
                        break;
                }
                if (matrix == otherMatrix)
                    return;
            }
            catch { return; }
            if (MessageBox.Show("Сохранить " + form.NameMatrix.Text + "?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                switch (format)
                {
                    case "txt":
                        using (StreamWriter file = new StreamWriter(filePath))
                        {
                            matrix.Write(file);
                        }
                        break;
                    case "bin":
                        using (BinaryWriter file = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                        {
                            matrix.Write(file);
                        }
                        break;
                    case "XML":
                        using (FileStream file = new FileStream(filePath, FileMode.Create))
                        {
                            matrix.Write(file);
                        }
                        break;
                }
            }
        }
        private static double[,] ConvertDataGridViewToMatrix()
        {
            int size = Convert.ToInt32(form.sizeMatrix.Text);
            double[,] result = new double[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    result[i, j] = (double)form.dataGridViewMatrix.Rows[i].Cells[j].Value;
            return result;
        }
        public static void VisibleElements()
        {
            form.dataGridViewMatrix.Visible = true;
            form.label1Matrix.Visible = true;
            form.label2Matrix.Visible = true;
            form.sizeMatrix.Visible = true;
            form.EditMatrix.Visible = true;
            form.NameMatrix.Visible = true;
            form.RemoveMatrix.Visible = true;
            form.randomMatrix.Visible = true;
        }
        public static void UnVisibleElements()
        {
            form.dataGridViewMatrix.Visible = false;
            form.label1Matrix.Visible = false;
            form.label2Matrix.Visible = false;
            form.sizeMatrix.Visible = false;
            form.EditMatrix.Visible = false;
            form.NameMatrix.Visible = false;
            form.CanselMatrix.Visible = false;
            form.RemoveMatrix.Visible = false;
            form.AcceptMatrix.Visible = false;
            form.randomMatrix.Visible = false;
        }
        public static void LoadDataGridView(TridiagonalMatrix matrix)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < matrix.Size; i++)
                dt.Columns.Add(Convert.ToString(i), typeof(double));
            for (int i = 0; i < matrix.Size; i++)
                dt.Rows.Add(new object[] { });
            for (int i = 0; i < matrix.Size; i++)
                for (int j = 0; j < matrix.Size; j++)
                    dt.Rows[i][j] = matrix[i, j];
            form.sizeMatrix.Text = Convert.ToString(matrix.Size);
            form.dataGridViewMatrix.DataSource = dt;
        }
        public static void ImportMatrixFromTxt(object sender, EventArgs e)
        {
            SaveCurrentMatrix();
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = fileDialog.FileName;
                using (StreamReader file = new StreamReader(filePath))
                {
                    try
                    {
                        VisibleElements();
                        string[] tmp = filePath.Split('\\');
                        form.NameMatrix.Text = tmp[tmp.Length - 1];
                        TridiagonalMatrix matrix = new TridiagonalMatrix();
                        matrix.Initialize(file);
                        DBWork.AddMatrix(filePath);
                        LoadDataGridView(matrix);
                        form.comboBoxMatrix.Items.Add(tmp[tmp.Length - 1]);
                        form.comboBoxMatrix.SelectedIndex = form.comboBoxMatrix.Items.Count - 1;
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        public static void ImportMatrixFromXml(object sender, EventArgs e)
        {
            SaveCurrentMatrix();
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "XML files (*.XML)|*.XML|All files (*.*)|*.*"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = fileDialog.FileName;
                using (FileStream file = new FileStream(filePath, FileMode.Open))
                {
                    try
                    {
                        VisibleElements();
                        string[] tmp = filePath.Split('\\');
                        form.NameMatrix.Text = tmp[tmp.Length - 1];
                        TridiagonalMatrix matrix = new TridiagonalMatrix();
                        matrix.Initialize(file);
                        DBWork.AddMatrix(filePath);
                        LoadDataGridView(matrix);
                        form.comboBoxMatrix.Items.Add(tmp[tmp.Length - 1]);
                        form.comboBoxMatrix.SelectedIndex = form.comboBoxMatrix.Items.Count - 1;
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        public static void ImportMatrixFromBin(object sender, EventArgs e)
        {
            SaveCurrentMatrix();
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "BIN files (*.BIN)|*.BIN|All files (*.*)|*.*"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = fileDialog.FileName;
                using (BinaryReader file = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    try
                    {
                        VisibleElements();
                        string[] tmp = filePath.Split('\\');
                        form.NameMatrix.Text = tmp[tmp.Length - 1];
                        TridiagonalMatrix matrix = new TridiagonalMatrix();
                        matrix.Initialize(file);
                        DBWork.AddMatrix(filePath);
                        LoadDataGridView(matrix);
                        form.comboBoxMatrix.Items.Add(tmp[tmp.Length - 1]);
                        form.comboBoxMatrix.SelectedIndex = form.comboBoxMatrix.Items.Count - 1;
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        public static void ExportMatrixFromTxt(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = fileDialog.FileName;
                using (StreamWriter file = new StreamWriter(filePath))
                {
                    try
                    {
                        TridiagonalMatrix matrix = new TridiagonalMatrix();
                        matrix.Initialize(ConvertDataGridViewToMatrix());
                        matrix.Write(file);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        public static void ExportMatrixFromXml(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog
            {
                Filter = "XML files (*.XML)|*.XML|All files (*.*)|*.*"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = fileDialog.FileName;
                using (FileStream file = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    try
                    {
                        TridiagonalMatrix matrix = new TridiagonalMatrix();
                        matrix.Initialize(ConvertDataGridViewToMatrix());
                        matrix.Write(file);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        public static void ExportMatrixFromBin(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog
            {
                Filter = "BIN files (*.BIN)|*.BIN|All files (*.*)|*.*"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = fileDialog.FileName;
                using (BinaryWriter file = new BinaryWriter(File.Open(filePath, FileMode.OpenOrCreate)))
                {
                    try
                    {
                        TridiagonalMatrix matrix = new TridiagonalMatrix();
                        matrix.Initialize(ConvertDataGridViewToMatrix());
                        matrix.Write(file);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        public static void Label1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(form.BackColor);
            e.Graphics.RotateTransform(-90);
            SizeF textSize = e.Graphics.MeasureString(form.label1Matrix.Text, form.label1Matrix.Font);
            form.label1Matrix.Width = (int)textSize.Height + 2;
            form.label1Matrix.Height = (int)textSize.Width + 2;
            e.Graphics.TranslateTransform(-form.label1Matrix.Height / 2, form.label1Matrix.Width / 2);
            e.Graphics.DrawString(form.label1Matrix.Text, form.label1Matrix.Font, Brushes.Black, -(textSize.Width / 2), -(textSize.Height / 2));
        }
        public static void Label2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(form.BackColor);
            e.Graphics.RotateTransform(-90);
            SizeF textSize = e.Graphics.MeasureString(form.label2Matrix.Text, form.label2Matrix.Font);
            form.label2Matrix.Width = (int)textSize.Height + 2;
            form.label2Matrix.Height = (int)textSize.Width + 2;
            e.Graphics.TranslateTransform(-form.label2Matrix.Height / 2, form.label2Matrix.Width / 2);
            e.Graphics.DrawString(form.label2Matrix.Text, form.label2Matrix.Font, Brushes.Black, -(textSize.Width / 2), -(textSize.Height / 2));
        }
        public static void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveCurrentMatrix();
            string format = DBWork.GetFormatMatrix(form.comboBoxMatrix.Text);
            string filePath = DBWork.GetFilePathMatrix(form.comboBoxMatrix.Text);
            TridiagonalMatrix matrix = new TridiagonalMatrix();
            switch (format)
            {
                case "txt":
                    using (StreamReader file = new StreamReader(filePath))
                    {
                        matrix.Initialize(file);
                    }
                    break;
                case "bin":
                    using (BinaryReader file = new BinaryReader(File.Open(filePath, FileMode.Open)))
                    {
                        matrix.Initialize(file);
                    }
                    break;
                case "XML":
                    using (FileStream file = new FileStream(filePath, FileMode.Open))
                    {
                        matrix.Initialize(file);
                    }
                    break;
            }
            LoadDataGridView(matrix);
            form.NameMatrix.Text = form.comboBoxMatrix.Text;
            VisibleElements();
        }
        public static void Remove_Click(object sender, EventArgs e)
        {
            SaveCurrentMatrix();
            form.dataGridViewMatrix.DataSource = null;
            DBWork.RemoveMatrix(form.NameMatrix.Text, form);
            if (form.comboBoxMatrix.Items.Count == 0)
                UnVisibleElements();
            else
                form.comboBoxMatrix.SelectedIndex = form.comboBoxMatrix.Items.Count - 1;
        }
        public static void Edit_Click(object sender, EventArgs e)
        {
            form.EditMatrix.Visible = false;
            form.AcceptMatrix.Visible = true;
            form.CanselMatrix.Visible = true;
            form.NameMatrix.ReadOnly = false;
            form.currentNameMatrix = form.NameMatrix.Text;
        }
        public static void Cansel_Click(object sender, EventArgs e)
        {
            form.NameMatrix.Text = form.currentNameMatrix;
            form.EditMatrix.Visible = true;
            form.AcceptMatrix.Visible = false;
            form.CanselMatrix.Visible = false;
            form.NameMatrix.ReadOnly = true;
        }
        public static void Accept_Click(object sender, EventArgs e)
        {
            try
            {
                DBWork.UpdateMatrix(form.NameMatrix.Text, form);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            form.EditMatrix.Visible = true;
            form.AcceptMatrix.Visible = false;
            form.CanselMatrix.Visible = false;
            form.NameMatrix.ReadOnly = true;
        }
        public static void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < Convert.ToInt32(form.sizeMatrix.Text) && !(e.RowIndex == e.ColumnIndex || e.RowIndex + 1 == e.ColumnIndex || e.RowIndex == e.ColumnIndex + 1) && (int)form.dataGridViewMatrix.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != 0)
            {
                form.dataGridViewMatrix.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = form.tmpField;
                MessageBox.Show("Недиагональный элемент должен быть равен 0", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex < Convert.ToInt32(form.sizeMatrix.Text))
                form.tmpField = (double)form.dataGridViewMatrix.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }

        public static void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("В ячейках должны находится только цифры", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void DataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            DataTable dt = new DataTable();
            int size = Convert.ToInt32(form.sizeMatrix.Text);
            for (int i = 0; i < size + 1; i++)
                dt.Columns.Add(Convert.ToString(i), typeof(double));
            for (int i = 0; i < size + 1; i++)
                dt.Rows.Add(new object[] { });
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    dt.Rows[i][j] = (double)form.dataGridViewMatrix.Rows[i].Cells[j].Value;
            for (int i = 0; i <= size; i++)
            {
                dt.Rows[i][size] = 0;
                dt.Rows[size][i] = 0;
            }
            form.dataGridViewMatrix.DataSource = dt;
            form.sizeMatrix.Text = Convert.ToString(size + 1);
        }
        public static void Random_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int size = Convert.ToInt32(form.sizeMatrix.Text);
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (i == j || i + 1 == j || i == j + 1)
                        form.dataGridViewMatrix.Rows[i].Cells[j].Value = rnd.Next(-100, 100);
                    else
                        form.dataGridViewMatrix.Rows[i].Cells[j].Value = 0;
        }
        public static void Create_Click(object sender, EventArgs e)
        {
            FormCreate formCreate = new FormCreate("матрицы");
            formCreate.ShowDialog();
            if (formCreate.DialogResult == DialogResult.OK)
            {
                Directory.CreateDirectory("Matrix");
                FileStream file = new FileStream("Matrix/" + formCreate.nameObject + ".xml", FileMode.Create);
                int size = formCreate.sizeObject;
                DataTable dt = new DataTable();
                for (int i = 0; i < size; i++)
                    dt.Columns.Add(Convert.ToString(i), typeof(int));
                for (int i = 0; i < size; i++)
                    dt.Rows.Add(new object[] { });
                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                        dt.Rows[i][j] = 0;
                form.sizeMatrix.Text = Convert.ToString(size);
                form.dataGridViewMatrix.DataSource = dt;
                TridiagonalMatrix matrix = new TridiagonalMatrix();
                matrix.Initialize(ConvertDataGridViewToMatrix());
                DBWork.AddMatrix(file.Name);
                matrix.Write(file);
                file.Close();
                form.comboBoxMatrix.Items.Add(formCreate.nameObject + ".xml");
                form.comboBoxMatrix.SelectedIndex = form.comboBoxMatrix.Items.Count - 1;
                form.NameMatrix.Text = formCreate.nameObject + ".xml";
            }
        }
        public static void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("D:\\OneDrive - ВГУ\\C#\\project.NumericalMethods.WorkingWithMatrix\\project\\Chislennye_metody_Laboratornaya_rabota_SLAU_s_tryokhdiagonalnoy_matritsey.pdf");
        }
    }
}
