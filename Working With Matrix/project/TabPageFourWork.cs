using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Drawing;

namespace project
{
    static class TabPageFourWork
    {
        static FormMain form;
        public static void Load(FormMain f)
        {
            form = f;
        }
        public static void FormMain_Load(object sender, EventArgs e)
        {
            form.operation.Items.AddRange(new object[] { "+", "-", "*" });
            form.operation.SelectedIndex = 0;
            form.lblUpResult.AutoSize = false;
            form.lblDownResult.AutoSize = false;
            form.lblUpSecond.AutoSize = false;
            form.lblDownSecond.AutoSize = false;
            form.SizeResult.ReadOnly = true;
            form.SizeSecond.ReadOnly = true;
            form.SizeFirst.ReadOnly = true;
            form.lblUpFirst.AutoSize = false;
            form.lblDownFirst.AutoSize = false;
            form.tabControl2.Size = new Size(form.Size.Width - 80, form.Size.Height - 70);
            form.DGVResult.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 1.4), Convert.ToInt32(form.Size.Height / 4));
            form.DGVFirst.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 50), Convert.ToInt32(form.Size.Height / 4));
            form.DGVSecond.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 2.7), Convert.ToInt32(form.Size.Height / 4));
            form.DGVResult.Size = new Size(Convert.ToInt32(form.tabControl2.Size.Width / 4.2), Convert.ToInt32(form.Size.Height / 3.5));
            form.DGVFirst.Size = new Size(Convert.ToInt32(form.tabControl2.Size.Width / 4.2), Convert.ToInt32(form.Size.Height / 3.5));
            form.DGVSecond.Size = new Size(Convert.ToInt32(form.tabControl2.Size.Width / 4.2), Convert.ToInt32(form.Size.Height / 3.5));
            form.SizeResult.Location = new Point(form.DGVResult.Location.X + form.DGVResult.Size.Width, Convert.ToInt32(form.DGVResult.Location.Y + form.DGVResult.Size.Height / 2.5));
            form.lblUpResult.Text = "<";
            form.lblUpResult.Location = new Point(form.DGVResult.Location.X + form.DGVResult.Size.Width, form.DGVResult.Location.Y);
            for (int i = 1; form.SizeResult.Location.Y >= form.lblUpResult.Location.Y + i * 10; i++)
                form.lblUpResult.Text += "=";
            form.lblUpResult.Text += ">";
            form.lblDownResult.Location = new Point(form.DGVResult.Location.X + form.DGVResult.Size.Width, form.SizeResult.Location.Y + 23);
            form.lblDownResult.Text = "<";
            for (int i = 1; form.DGVResult.Location.Y + form.DGVResult.Size.Height >= form.lblDownResult.Location.Y + i * 9.7; i++)
                form.lblDownResult.Text += "=";
            form.lblDownResult.Text += ">";

            form.lblResult.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 1.55), Convert.ToInt32(form.DGVResult.Location.Y + form.DGVResult.Size.Height / 3));

            form.SizeSecond.Location = new Point(form.DGVSecond.Location.X + form.DGVSecond.Size.Width, Convert.ToInt32(form.DGVSecond.Location.Y + form.DGVSecond.Size.Height / 2.5));
            form.lblUpSecond.Text = "<";
            form.lblUpSecond.Location = new Point(form.DGVSecond.Location.X + form.DGVSecond.Size.Width, form.DGVSecond.Location.Y);
            for (int i = 1; form.SizeSecond.Location.Y >= form.lblUpSecond.Location.Y + i * 10; i++)
                form.lblUpSecond.Text += "=";
            form.lblUpSecond.Text += ">";
            form.lblDownSecond.Location = new Point(form.DGVSecond.Location.X + form.DGVSecond.Size.Width, form.SizeSecond.Location.Y + 23);
            form.lblDownSecond.Text = "<";
            for (int i = 1; form.DGVSecond.Location.Y + form.DGVSecond.Size.Height >= form.lblDownSecond.Location.Y + i * 9.7; i++)
                form.lblDownSecond.Text += "=";
            form.lblDownSecond.Text += ">";

            form.SizeFirst.Location = new Point(form.DGVFirst.Location.X + form.DGVFirst.Size.Width, Convert.ToInt32(form.DGVFirst.Location.Y + form.DGVFirst.Size.Height / 2.5));
            form.lblUpFirst.Text = "<";
            form.lblUpFirst.Location = new Point(form.DGVFirst.Location.X + form.DGVFirst.Size.Width, form.DGVFirst.Location.Y);
            for (int i = 1; form.SizeFirst.Location.Y >= form.lblUpFirst.Location.Y + i * 10; i++)
                form.lblUpFirst.Text += "=";
            form.lblUpFirst.Text += ">";
            form.lblDownFirst.Location = new Point(form.DGVFirst.Location.X + form.DGVFirst.Size.Width, form.SizeFirst.Location.Y + 23);
            form.lblDownFirst.Text = "<";
            for (int i = 1; form.DGVFirst.Location.Y + form.DGVFirst.Size.Height >= form.lblDownFirst.Location.Y + i * 9.7; i++)
                form.lblDownFirst.Text += "=";
            form.lblDownFirst.Text += ">";

            form.operation.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 3.3), Convert.ToInt32(form.DGVResult.Location.Y + form.DGVResult.Size.Height / 3));
            form.firstParam.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 50), Convert.ToInt32(form.Size.Height / 5.2));
            form.secondParam.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 2.7), Convert.ToInt32(form.Size.Height / 5.2));
            form.result.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 1.4), Convert.ToInt32(form.Size.Height / 5.2));

            form.Run.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 2.3), form.tabControl2.Location.Y + form.tabControl2.Size.Height - 70);
        }

        public static void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == 2)
            {
                DBWork.LoadComboBoxes(form.firstParam, form.secondParam, form.result);
                form.countMatrices = DBWork.GetCountMatrices();
                form.countVectors = DBWork.GetCountVectors();
            }
        }
        public static void FormMain_Resize(object sender, EventArgs e)
        {
            form.tabControl2.Size = new Size(form.Size.Width - 80, form.Size.Height - 70);
            form.DGVResult.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 1.4), Convert.ToInt32(form.Size.Height / 4));
            form.DGVFirst.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 50), Convert.ToInt32(form.Size.Height / 4));
            form.DGVSecond.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 2.7), Convert.ToInt32(form.Size.Height / 4));
            form.DGVResult.Size = new Size(Convert.ToInt32(form.tabControl2.Size.Width / 4.2), Convert.ToInt32(form.Size.Height / 3.5));
            form.DGVFirst.Size = new Size(Convert.ToInt32(form.tabControl2.Size.Width / 4.2), Convert.ToInt32(form.Size.Height / 3.5));
            form.DGVSecond.Size = new Size(Convert.ToInt32(form.tabControl2.Size.Width / 4.2), Convert.ToInt32(form.Size.Height / 3.5));
            form.SizeResult.Location = new Point(form.DGVResult.Location.X + form.DGVResult.Size.Width, Convert.ToInt32(form.DGVResult.Location.Y + form.DGVResult.Size.Height / 2.5));
            form.lblUpResult.Text = "<";
            form.lblUpResult.Location = new Point(form.DGVResult.Location.X + form.DGVResult.Size.Width, form.DGVResult.Location.Y);
            for (int i = 1; form.SizeResult.Location.Y >= form.lblUpResult.Location.Y + i * 10; i++)
                form.lblUpResult.Text += "=";
            form.lblUpResult.Text += ">";
            form.lblDownResult.Location = new Point(form.DGVResult.Location.X + form.DGVResult.Size.Width, form.SizeResult.Location.Y + 23);
            form.lblDownResult.Text = "<";
            for (int i = 1; form.DGVResult.Location.Y + form.DGVResult.Size.Height >= form.lblDownResult.Location.Y + i * 9.7; i++)
                form.lblDownResult.Text += "=";
            form.lblDownResult.Text += ">";
            form.lblResult.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 1.55), Convert.ToInt32(form.DGVResult.Location.Y + form.DGVResult.Size.Height / 3));
            form.SizeSecond.Location = new Point(form.DGVSecond.Location.X + form.DGVSecond.Size.Width, Convert.ToInt32(form.DGVSecond.Location.Y + form.DGVSecond.Size.Height / 2.5));
            form.lblUpSecond.Text = "<";
            form.lblUpSecond.Location = new Point(form.DGVSecond.Location.X + form.DGVSecond.Size.Width, form.DGVSecond.Location.Y);
            for (int i = 1; form.SizeSecond.Location.Y >= form.lblUpSecond.Location.Y + i * 10; i++)
                form.lblUpSecond.Text += "=";
            form.lblUpSecond.Text += ">";
            form.lblDownSecond.Location = new Point(form.DGVSecond.Location.X + form.DGVSecond.Size.Width, form.SizeSecond.Location.Y + 23);
            form.lblDownSecond.Text = "<";
            for (int i = 1; form.DGVSecond.Location.Y + form.DGVSecond.Size.Height >= form.lblDownSecond.Location.Y + i * 9.7; i++)
                form.lblDownSecond.Text += "=";
            form.lblDownSecond.Text += ">";

            form.SizeFirst.Location = new Point(form.DGVFirst.Location.X + form.DGVFirst.Size.Width, Convert.ToInt32(form.DGVFirst.Location.Y + form.DGVFirst.Size.Height / 2.5));
            form.lblUpFirst.Text = "<";
            form.lblUpFirst.Location = new Point(form.DGVFirst.Location.X + form.DGVFirst.Size.Width, form.DGVFirst.Location.Y);
            for (int i = 1; form.SizeFirst.Location.Y >= form.lblUpFirst.Location.Y + i * 10; i++)
                form.lblUpFirst.Text += "=";
            form.lblUpFirst.Text += ">";
            form.lblDownFirst.Location = new Point(form.DGVFirst.Location.X + form.DGVFirst.Size.Width, form.SizeFirst.Location.Y + 23);
            form.lblDownFirst.Text = "<";
            for (int i = 1; form.DGVFirst.Location.Y + form.DGVFirst.Size.Height >= form.lblDownFirst.Location.Y + i * 9.7; i++)
                form.lblDownFirst.Text += "=";
            form.lblDownFirst.Text += ">";

            form.operation.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 3.3), Convert.ToInt32(form.DGVResult.Location.Y + form.DGVResult.Size.Height / 3));
            form.firstParam.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 50), Convert.ToInt32(form.Size.Height / 5.2));
            form.secondParam.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 2.7), Convert.ToInt32(form.Size.Height / 5.2));
            form.result.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 1.4), Convert.ToInt32(form.Size.Height / 5.2));
            form.Run.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 2.3), form.tabControl2.Location.Y + form.tabControl2.Size.Height - 70);
        }
        public static void lblUpResult_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(form.BackColor);
            e.Graphics.RotateTransform(-90);
            SizeF textSize = e.Graphics.MeasureString(form.lblUpResult.Text, form.lblUpResult.Font);
            form.lblUpResult.Width = (int)textSize.Height + 2;
            form.lblUpResult.Height = (int)textSize.Width + 2;
            e.Graphics.TranslateTransform(-form.lblUpResult.Height / 2, form.lblUpResult.Width / 2);
            e.Graphics.DrawString(form.lblUpResult.Text, form.lblUpResult.Font, Brushes.Black, -(textSize.Width / 2), -(textSize.Height / 2));
        }
        public static void lblDownResult_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(form.BackColor);
            e.Graphics.RotateTransform(-90);
            SizeF textSize = e.Graphics.MeasureString(form.lblDownResult.Text, form.lblDownResult.Font);
            form.lblDownResult.Width = (int)textSize.Height + 2;
            form.lblDownResult.Height = (int)textSize.Width + 2;
            e.Graphics.TranslateTransform(-form.lblDownResult.Height / 2, form.lblDownResult.Width / 2);
            e.Graphics.DrawString(form.lblDownResult.Text, form.lblDownResult.Font, Brushes.Black, -(textSize.Width / 2), -(textSize.Height / 2));
        }
        public static  void lblUpSecond_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(form.BackColor);
            e.Graphics.RotateTransform(-90);
            SizeF textSize = e.Graphics.MeasureString(form.lblUpSecond.Text, form.lblUpSecond.Font);
            form.lblUpSecond.Width = (int)textSize.Height + 2;
            form.lblUpSecond.Height = (int)textSize.Width + 2;
            e.Graphics.TranslateTransform(-form.lblUpSecond.Height / 2, form.lblUpSecond.Width / 2);
            e.Graphics.DrawString(form.lblUpSecond.Text, form.lblUpSecond.Font, Brushes.Black, -(textSize.Width / 2), -(textSize.Height / 2));
        }
        public static void lblDownSecond_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(form.BackColor);
            e.Graphics.RotateTransform(-90);
            SizeF textSize = e.Graphics.MeasureString(form.lblDownSecond.Text, form.lblDownSecond.Font);
            form.lblDownSecond.Width = (int)textSize.Height + 2;
            form.lblDownSecond.Height = (int)textSize.Width + 2;
            e.Graphics.TranslateTransform(-form.lblDownSecond.Height / 2, form.lblDownSecond.Width / 2);
            e.Graphics.DrawString(form.lblDownSecond.Text, form.lblDownSecond.Font, Brushes.Black, -(textSize.Width / 2), -(textSize.Height / 2));
        }
        public static void lblDownFirst_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(form.BackColor);
            e.Graphics.RotateTransform(-90);
            SizeF textSize = e.Graphics.MeasureString(form.lblDownFirst.Text, form.lblDownFirst.Font);
            form.lblDownFirst.Width = (int)textSize.Height + 2;
            form.lblDownFirst.Height = (int)textSize.Width + 2;
            e.Graphics.TranslateTransform(-form.lblDownFirst.Height / 2, form.lblDownFirst.Width / 2);
            e.Graphics.DrawString(form.lblDownFirst.Text, form.lblDownFirst.Font, Brushes.Black, -(textSize.Width / 2), -(textSize.Height / 2));
        }
        public static void lblUpFirst_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(form.BackColor);
            e.Graphics.RotateTransform(-90);
            SizeF textSize = e.Graphics.MeasureString(form.lblUpFirst.Text, form.lblUpFirst.Font);
            form.lblUpFirst.Width = (int)textSize.Height + 2;
            form.lblUpFirst.Height = (int)textSize.Width + 2;
            e.Graphics.TranslateTransform(-form.lblUpFirst.Height / 2, form.lblUpFirst.Width / 2);
            e.Graphics.DrawString(form.lblUpFirst.Text, form.lblUpFirst.Font, Brushes.Black, -(textSize.Width / 2), -(textSize.Height / 2));
        }
        public static void LoadDataGridView(DataGridView DGV, TextBox box, TridiagonalMatrix matrix)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < matrix.Size; i++)
                dt.Columns.Add(Convert.ToString(i), typeof(double));
            for (int i = 0; i < matrix.Size; i++)
                dt.Rows.Add(new object[] { });
            for (int i = 0; i < matrix.Size; i++)
                for (int j = 0; j < matrix.Size; j++)
                    dt.Rows[i][j] = matrix[i, j];
            box.Text = Convert.ToString(matrix.Size);
            DGV.DataSource = dt;
        }
        public static void LoadDataGridView(DataGridView DGV, TextBox box, ScalarVector vector)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("0", typeof(double));
            for (int i = 0; i < vector.Size; i++)
                dt.Rows.Add(new object[] { });
            for (int i = 0; i < vector.Size; i++)
                dt.Rows[i][0] = vector[i];
            box.Text = Convert.ToString(vector.Size);
            DGV.DataSource = dt;
        }
        public static double[,] ConvertDataGridViewToMatrix(DataGridView DGV, TextBox box)
        {
            int size = Convert.ToInt32(box.Text);
            double[,] result = new double[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    result[i, j] = (double)DGV.Rows[i].Cells[j].Value;
            return result;
        }
        public static double[] ConvertDataGridViewToVector(DataGridView DGV, TextBox box)
        {
            int size = Convert.ToInt32(box.Text);
            double[] result = new double[size];
            for (int i = 0; i < size; i++)
                result[i] = (double)DGV.Rows[i].Cells[0].Value;
            return result;
        }
        public static void firstParam_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (form.numberResult)
            {
                case 1:
                    form.DGVFirst.DataSource = null;
                    break;
                case 2:
                    form.DGVSecond.DataSource = null;
                    break;
                case 3:
                    form.DGVResult.DataSource = null;
                    break;
            }
            if (form.firstParam.Text == "--Матрицы--" || form.firstParam.Text == "--Вектора--" || form.firstParam.Text == "None")
            {
                form.DGVFirst.DataSource = null;
                form.firstParam.Text = "None";
                form.SizeFirst.Text = "";
                form.numberResult = -1;
                return;
            }
            if (form.firstParam.SelectedIndex <= form.countMatrices + 1)
            {
                string format = DBWork.GetFormatMatrix(form.firstParam.Text);
                string filePath = DBWork.GetFilePathMatrix(form.firstParam.Text);
                switch (format)
                {
                    case "txt":
                        try
                        {
                            using (StreamReader file = new StreamReader(filePath))
                            {
                                TridiagonalMatrix matrix = new TridiagonalMatrix();
                                matrix.Initialize(file);
                                LoadDataGridView(form.DGVFirst, form.SizeFirst, matrix);
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    case "bin":
                        try
                        {
                            using (BinaryReader file = new BinaryReader(File.Open(filePath, FileMode.Open)))
                            {
                                TridiagonalMatrix matrix = new TridiagonalMatrix();
                                matrix.Initialize(file);
                                LoadDataGridView(form.DGVFirst, form.SizeFirst, matrix);
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    case "XML":
                        try
                        {
                            using (FileStream file = new FileStream(filePath, FileMode.Open))
                            {
                                TridiagonalMatrix matrix = new TridiagonalMatrix();
                                matrix.Initialize(file);
                                LoadDataGridView(form.DGVFirst, form.SizeFirst, matrix);
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                }
            }
            else
            {
                string format = DBWork.GetFormatVector(form.firstParam.Text);
                string filePath = DBWork.GetFilePathVector(form.firstParam.Text);
                switch (format)
                {
                    case "txt":
                        try
                        {
                            using (StreamReader file = new StreamReader(filePath))
                            {
                                ScalarVector vector = new ScalarVector();
                                vector.Initialize(file);
                                LoadDataGridView(form.DGVFirst, form.SizeFirst, vector);
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    case "bin":
                        try
                        {
                            using (BinaryReader file = new BinaryReader(File.Open(filePath, FileMode.Open)))
                            {
                                ScalarVector vector = new ScalarVector();
                                vector.Initialize(file);
                                LoadDataGridView(form.DGVFirst, form.SizeFirst, vector);
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    case "XML":
                        try
                        {
                            using (FileStream file = new FileStream(filePath, FileMode.Open))
                            {
                                ScalarVector vector = new ScalarVector();
                                vector.Initialize(file);
                                LoadDataGridView(form.DGVFirst, form.SizeFirst, vector);
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                }
            }
        }
        public static void secondParam_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (form.numberResult)
            {
                case 1:
                    form.DGVFirst.DataSource = null;
                    break;
                case 2:
                    form.DGVSecond.DataSource = null;
                    break;
                case 3:
                    form.DGVResult.DataSource = null;
                    break;
            }
            if (form.secondParam.Text == "--Матрицы--" || form.secondParam.Text == "--Вектора--" || form.secondParam.Text == "None")
            {
                form.DGVSecond.DataSource = null;
                form.secondParam.Text = "None";
                form.SizeSecond.Text = "";
                form.numberResult = -1;
                return;
            }
            if (form.secondParam.SelectedIndex <= form.countMatrices + 1)
            {
                string format = DBWork.GetFormatMatrix(form.secondParam.Text);
                string filePath = DBWork.GetFilePathMatrix(form.secondParam.Text);
                switch (format)
                {
                    case "txt":
                        try
                        {
                            using (StreamReader file = new StreamReader(filePath))
                            {
                                TridiagonalMatrix matrix = new TridiagonalMatrix();
                                matrix.Initialize(file);
                                LoadDataGridView(form.DGVSecond, form.SizeSecond, matrix);
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    case "bin":
                        try
                        {
                            using (BinaryReader file = new BinaryReader(File.Open(filePath, FileMode.Open)))
                            {
                                TridiagonalMatrix matrix = new TridiagonalMatrix();
                                matrix.Initialize(file);
                                LoadDataGridView(form.DGVSecond, form.SizeSecond, matrix);
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    case "XML":
                        try
                        {
                            using (FileStream file = new FileStream(filePath, FileMode.Open))
                            {
                                TridiagonalMatrix matrix = new TridiagonalMatrix();
                                matrix.Initialize(file);
                                LoadDataGridView(form.DGVSecond, form.SizeSecond, matrix);
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                }
            }
            else
            {
                string format = DBWork.GetFormatVector(form.secondParam.Text);
                string filePath = DBWork.GetFilePathVector(form.secondParam.Text);
                switch (format)
                {
                    case "txt":
                        try
                        {
                            using (StreamReader file = new StreamReader(filePath))
                            {
                                ScalarVector vector = new ScalarVector();
                                vector.Initialize(file);
                                LoadDataGridView(form.DGVSecond, form.SizeSecond, vector);
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    case "bin":
                        try
                        {
                            using (BinaryReader file = new BinaryReader(File.Open(filePath, FileMode.Open)))
                            {
                                ScalarVector vector = new ScalarVector();
                                vector.Initialize(file);
                                LoadDataGridView(form.DGVSecond, form.SizeSecond, vector);
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    case "XML":
                        try
                        {
                            using (FileStream file = new FileStream(filePath, FileMode.Open))
                            {
                                ScalarVector vector = new ScalarVector();
                                vector.Initialize(file);
                                LoadDataGridView(form.DGVSecond, form.SizeSecond, vector);
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                }
            }
        }
        public static void result_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (form.numberResult)
            {
                case 1:
                    form.DGVFirst.DataSource = null;
                    break;
                case 2:
                    form.DGVSecond.DataSource = null;
                    break;
                case 3:
                    form.DGVResult.DataSource = null;
                    break;
            }
            if (form.result.Text == "--Матрицы--" || form.result.Text == "--Вектора--" || form.result.Text == "None")
            {
                form.DGVResult.DataSource = null;
                form.result.Text = "None";
                form.SizeResult.Text = "";
                form.numberResult = -1;
                return;
            }
            if (form.result.SelectedIndex <= form.countMatrices + 1)
            {
                string format = DBWork.GetFormatMatrix(form.result.Text);
                string filePath = DBWork.GetFilePathMatrix(form.result.Text);
                switch (format)
                {
                    case "txt":
                        try
                        {
                            using (StreamReader file = new StreamReader(filePath))
                            {
                                TridiagonalMatrix matrix = new TridiagonalMatrix();
                                matrix.Initialize(file);
                                LoadDataGridView(form.DGVResult, form.SizeResult, matrix);
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    case "bin":
                        try
                        {
                            using (BinaryReader file = new BinaryReader(File.Open(filePath, FileMode.Open)))
                            {
                                TridiagonalMatrix matrix = new TridiagonalMatrix();
                                matrix.Initialize(file);
                                LoadDataGridView(form.DGVResult, form.SizeResult, matrix);
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    case "XML":
                        try
                        {
                            using (FileStream file = new FileStream(filePath, FileMode.Open))
                            {
                                TridiagonalMatrix matrix = new TridiagonalMatrix();
                                matrix.Initialize(file);
                                LoadDataGridView(form.DGVResult, form.SizeResult, matrix);
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                }
            }
            else
            {
                string format = DBWork.GetFormatVector(form.result.Text);
                string filePath = DBWork.GetFilePathVector(form.result.Text);
                switch (format)
                {
                    case "txt":
                        try
                        {
                            using (StreamReader file = new StreamReader(filePath))
                            {
                                ScalarVector vector = new ScalarVector();
                                vector.Initialize(file);
                                LoadDataGridView(form.DGVResult, form.SizeResult, vector);
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    case "bin":
                        try
                        {
                            using (BinaryReader file = new BinaryReader(File.Open(filePath, FileMode.Open)))
                            {
                                ScalarVector vector = new ScalarVector();
                                vector.Initialize(file);
                                LoadDataGridView(form.DGVResult, form.SizeResult, vector);
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    case "XML":
                        try
                        {
                            using (FileStream file = new FileStream(filePath, FileMode.Open))
                            {
                                ScalarVector vector = new ScalarVector();
                                vector.Initialize(file);
                                LoadDataGridView(form.DGVResult, form.SizeResult, vector);
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                }
            }
        }
        private static Dictionary<string, Func<TridiagonalMatrix, TridiagonalMatrix, TridiagonalMatrix>> operationMatrix = new Dictionary<string, Func<TridiagonalMatrix, TridiagonalMatrix, TridiagonalMatrix>>
        {
            {"+", (TridiagonalMatrix a, TridiagonalMatrix b) => a + b },
            {"-", (TridiagonalMatrix a, TridiagonalMatrix b) => a - b }
        };
        private static Dictionary<string, Func<ScalarVector, ScalarVector, ScalarVector>> operationVector = new Dictionary<string, Func<ScalarVector, ScalarVector, ScalarVector>>
        {
            {"+", (ScalarVector a, ScalarVector b) => a + b },
            {"-", (ScalarVector a, ScalarVector b) => a - b },
            {"*", (ScalarVector a, ScalarVector b) => new ScalarVector().Initialize(new double[]{ a * b}) },
        };

        private static ScalarVector RunthroughMethod(TridiagonalMatrix matrix, ScalarVector vector)
        {
            if (matrix.Size != vector.Size)
                throw new Exception("Размеры матрицы и вектора не совпадают");
            double[] L = new double[matrix.Size - 1];
            double[] M = new double[matrix.Size];
            double b = 1 / matrix[0, 0];
            L[0] = matrix[0, 1] * b;
            M[0] = vector[0] * b;
            int border = 0;
            for (int i = 1; i < matrix.Size - 1; i++)
            {
                L[i] = matrix[i, border + 2] / (matrix[i, border + 1] - matrix[i, border] * L[i - 1]);
                M[i] = (vector[i] - matrix[i, border] * M[i - 1]) / (matrix[i, border + 1] - matrix[i, border] * L[i - 1]);
                border++;
            }
            M[matrix.Size - 1] = (vector[matrix.Size - 1] - matrix[matrix.Size - 1, border] * M[matrix.Size - 2]) / (matrix[matrix.Size - 1, border + 1] - matrix[matrix.Size - 1, border] * L[matrix.Size - 2]);
            double[] X = new double[matrix.Size];
            X[matrix.Size - 1] = M[matrix.Size - 1];
            for (int i = matrix.Size - 2; i >= 0; i--)
                X[i] = M[i] - L[i] * X[i + 1];
            return new ScalarVector().Initialize(X);
        }
        private static ScalarVector InstabilityMethod(TridiagonalMatrix matrix, ScalarVector vector)
        {
            double[] Y = new double[matrix.Size];
            double[] Z = new double[matrix.Size];
            Y[0] = 0;
            Y[1] = vector[0] / matrix[0, 1];
            int border = 0;
            for (int i = 1; i < matrix.Size - 1; i++)
            {
                Y[i + 1] = (vector[i] - matrix[i, border] * Y[i - 1] - matrix[i, border + 1] * Y[i]) / matrix[i, border + 2];
                border++;
            }
            Z[0] = 1;
            Z[1] = -(matrix[0, 0] / matrix[0, 1]);
            border = 0;
            for (int i = 1; i < matrix.Size - 1; i++)
            {
                Z[i + 1] = -(matrix[i, border] * Z[i - 1] + matrix[i, border + 1] * Z[i]) / matrix[i, border + 2];
                border++;
            }
            double K = (vector[matrix.Size - 1] - matrix[matrix.Size - 1, matrix.Size - 2] * Y[matrix.Size - 2] - matrix[matrix.Size - 1, matrix.Size - 1] * Y[matrix.Size - 1]) /
                       (matrix[matrix.Size - 1, matrix.Size - 2] * Z[matrix.Size - 2] + matrix[matrix.Size - 1, matrix.Size - 1] * Z[matrix.Size - 1]);

            double[] X = new double[matrix.Size];
            for (int i = 0; i < matrix.Size; i++)
            {
                X[i] = Y[i] + K * Z[i];
            }
            return new ScalarVector().Initialize(X);
        }
        public static void Run_Click(object sender, EventArgs e)
        {
            switch (form.numberResult)
            {
                case 1:
                    form.DGVFirst.DataSource = null;
                    break;
                case 2:
                    form.DGVSecond.DataSource = null;
                    break;
                case 3:
                    form.DGVResult.DataSource = null;
                    break;
            }
            if ((form.DGVFirst.DataSource == null && form.DGVSecond.DataSource == null) || (form.DGVResult.DataSource == null && form.DGVSecond.DataSource == null) || (form.DGVFirst.DataSource == null && form.DGVResult.DataSource == null))
            {
                MessageBox.Show("Для выполнения операции должны быть инициализированны два поля", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (form.DGVFirst.DataSource != null && form.DGVSecond.DataSource != null && form.DGVResult.DataSource != null)
            {
                MessageBox.Show("Для выполнения операции должны быть не инициализированно одно поле ", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool resultIsEmpty = true;
            TridiagonalMatrix matrix1 = null;
            TridiagonalMatrix matrix2 = null;
            ScalarVector vector1 = null;
            ScalarVector vector2 = null;
            if (form.DGVFirst.DataSource != null)
            {
                if (form.firstParam.SelectedIndex <= form.countMatrices + 1)
                    matrix1 = new TridiagonalMatrix().Initialize(ConvertDataGridViewToMatrix(form.DGVFirst, form.SizeFirst));
                else
                    vector1 = new ScalarVector().Initialize(ConvertDataGridViewToVector(form.DGVFirst, form.SizeFirst));
            }
            else
                form.numberResult = 1;
            if (form.DGVSecond.DataSource != null)
            {
                if (form.secondParam.SelectedIndex <= form.countMatrices + 1)
                    if ((object)matrix1 == null)
                        matrix1 = new TridiagonalMatrix().Initialize(ConvertDataGridViewToMatrix(form.DGVSecond, form.SizeSecond));
                    else
                        matrix2 = new TridiagonalMatrix().Initialize(ConvertDataGridViewToMatrix(form.DGVSecond, form.SizeSecond));
                else
                    if ((object)vector1 == null)
                    vector1 = new ScalarVector().Initialize(ConvertDataGridViewToVector(form.DGVSecond, form.SizeSecond));
                else
                    vector2 = new ScalarVector().Initialize(ConvertDataGridViewToVector(form.DGVSecond, form.SizeSecond));
            }
            else
                form.numberResult = 2;
            if (form.DGVResult.DataSource != null)
            {
                resultIsEmpty = false;
                if (form.result.SelectedIndex <= form.countMatrices + 1)
                    matrix2 = new TridiagonalMatrix().Initialize(ConvertDataGridViewToMatrix(form.DGVResult, form.SizeResult));
                else
                    vector2 = new ScalarVector().Initialize(ConvertDataGridViewToVector(form.DGVResult, form.SizeResult));
            }
            else
                form.numberResult = 3;
            try
            {
                if (resultIsEmpty)
                {
                    if ((object)matrix1 != null && (object)matrix2 != null)
                        if (operationMatrix.ContainsKey(form.operation.Text))
                        {
                            LoadDataGridView(form.DGVResult, form.SizeResult, operationMatrix[form.operation.Text](matrix1, matrix2));
                            return;
                        }
                        else
                            throw new Exception("Операция умножения двух матриц не определена. Умножать можно только матрицу на вектор и вектор на вектор");
                    if ((object)vector1 != null && (object)vector2 != null)
                    {
                        LoadDataGridView(form.DGVResult, form.SizeResult, operationVector[form.operation.Text](vector1, vector2));
                        return;
                    }
                    if (form.operation.Text == "*")
                        LoadDataGridView(form.DGVResult, form.SizeResult, matrix1 * vector1);
                    else
                        throw new Exception("Для совместного использования вектора и матрицы определена только операция умножения");
                    return;
                }
                if (form.operation.Text == "*")
                {
                    if (!(matrix1 is object && vector2 is object))
                        throw new Exception("Данная операция определена для [matrix]*[vector]=[vector]");
                    FormChoice formChoice = new FormChoice();
                    formChoice.ShowDialog();
                    switch (formChoice.choice)
                    {
                        case 1:
                            switch (form.numberResult)
                            {
                                case 1:
                                    LoadDataGridView(form.DGVFirst, form.SizeFirst, RunthroughMethod(matrix1, vector2));
                                    break;
                                case 2:
                                    LoadDataGridView(form.DGVSecond, form.SizeSecond, RunthroughMethod(matrix1, vector2));
                                    break;
                            }
                            break;
                        case 2:
                            switch (form.numberResult)
                            {
                                case 1:
                                    LoadDataGridView(form.DGVFirst, form.SizeFirst, InstabilityMethod(matrix1, vector2));
                                    break;
                                case 2:
                                    LoadDataGridView(form.DGVSecond, form.SizeSecond, InstabilityMethod(matrix1, vector2));
                                    break;
                            }
                            break;
                    }
                }
                else
                {
                    if ((object)matrix2 == null && (object)vector1 == null)
                        throw new Exception("Данная операция возможна только для одинаковых типов");
                    if ((object)vector2 != null)
                    {
                        switch (form.numberResult)
                        {
                            case 1:
                                if (form.operation.Text == "+")
                                    LoadDataGridView(form.DGVFirst, form.SizeFirst, operationVector["-"](vector1, vector2));
                                else
                                    LoadDataGridView(form.DGVFirst, form.SizeFirst, operationVector["+"](vector1, vector2));
                                break;
                            case 2:
                                if (form.operation.Text == "+")
                                    LoadDataGridView(form.DGVSecond, form.SizeSecond, operationVector["-"](vector1, vector2));
                                else
                                    LoadDataGridView(form.DGVSecond, form.SizeSecond, operationVector["+"](vector1, vector2));
                                break;
                        }
                        return;
                    }
                    if ((object)matrix1 != null)
                    {
                        switch (form.numberResult)
                        {
                            case 1:
                                if (form.operation.Text == "+")
                                    LoadDataGridView(form.DGVFirst, form.SizeFirst, operationMatrix["-"](matrix1, matrix2));
                                else
                                    LoadDataGridView(form.DGVFirst, form.SizeFirst, operationMatrix["+"](matrix1, matrix2));
                                break;
                            case 2:
                                if (form.operation.Text == "+")
                                    LoadDataGridView(form.DGVSecond, form.SizeSecond, operationMatrix["-"](matrix1, matrix2));
                                else
                                    LoadDataGridView(form.DGVSecond, form.SizeSecond, operationMatrix["+"](matrix1, matrix2));
                                break;
                        }
                        return;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
