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
    static class TabPageFiveWork
    {
        static FormMain form;
        public static void Load(FormMain f)
        {
            form = f;
        }
        public static void FormMain_Load(object sender, EventArgs e)
        {
            form.operationTest.Items.Add("*");
            form.operationTest.SelectedIndex = 0;
            form.lblUpResultTest.AutoSize = false;
            form.lblDownResultTest.AutoSize = false;
            form.lblUpSecondTest.AutoSize = false;
            form.lblDownSecondTest.AutoSize = false;
            form.SizeResultTest.ReadOnly = true;
            form.SizeSecondTest.ReadOnly = true;
            form.SizeFirstTest.ReadOnly = true;
            form.lblUpFirstTest.AutoSize = false;
            form.lblDownFirstTest.AutoSize = false;
            form.DGVResultTest.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 1.4), Convert.ToInt32(form.Size.Height / 4));
            form.DGVFirstTest.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 50), Convert.ToInt32(form.Size.Height / 4));
            form.DGVSecondTest.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 2.7), Convert.ToInt32(form.Size.Height / 4));
            form.DGVResultTest.Size = new Size(Convert.ToInt32(form.tabControl2.Size.Width / 4.2), Convert.ToInt32(form.Size.Height / 3.5));
            form.DGVFirstTest.Size = new Size(Convert.ToInt32(form.tabControl2.Size.Width / 4.2), Convert.ToInt32(form.Size.Height / 3.5));
            form.DGVSecondTest.Size = new Size(Convert.ToInt32(form.tabControl2.Size.Width / 4.2), Convert.ToInt32(form.Size.Height / 3.5));
            form.SizeResultTest.Location = new Point(form.DGVResultTest.Location.X + form.DGVResultTest.Size.Width, Convert.ToInt32(form.DGVResultTest.Location.Y + form.DGVResultTest.Size.Height / 2.5));
            form.lblUpResultTest.Text = "<";
            form.lblUpResultTest.Location = new Point(form.DGVResultTest.Location.X + form.DGVResultTest.Size.Width, form.DGVResultTest.Location.Y);
            for (int i = 1; form.SizeResultTest.Location.Y >= form.lblUpResultTest.Location.Y + i * 10; i++)
                form.lblUpResultTest.Text += "=";
            form.lblUpResultTest.Text += ">";
            form.lblDownResultTest.Location = new Point(form.DGVResultTest.Location.X + form.DGVResultTest.Size.Width, form.SizeResultTest.Location.Y + 23);
            form.lblDownResultTest.Text = "<";
            for (int i = 1; form.DGVResultTest.Location.Y + form.DGVResultTest.Size.Height >= form.lblDownResultTest.Location.Y + i * 9.7; i++)
                form.lblDownResultTest.Text += "=";
            form.lblDownResultTest.Text += ">";

            form.lblResultTest.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 1.55), Convert.ToInt32(form.DGVResultTest.Location.Y + form.DGVResultTest.Size.Height / 3));

            form.SizeSecondTest.Location = new Point(form.DGVSecondTest.Location.X + form.DGVSecondTest.Size.Width, Convert.ToInt32(form.DGVSecondTest.Location.Y + form.DGVSecondTest.Size.Height / 2.5));
            form.lblUpSecondTest.Text = "<";
            form.lblUpSecondTest.Location = new Point(form.DGVSecondTest.Location.X + form.DGVSecondTest.Size.Width, form.DGVSecondTest.Location.Y);
            for (int i = 1; form.SizeSecondTest.Location.Y >= form.lblUpSecondTest.Location.Y + i * 10; i++)
                form.lblUpSecondTest.Text += "=";
            form.lblUpSecondTest.Text += ">";
            form.lblDownSecondTest.Location = new Point(form.DGVSecondTest.Location.X + form.DGVSecondTest.Size.Width, form.SizeSecondTest.Location.Y + 23);
            form.lblDownSecondTest.Text = "<";
            for (int i = 1; form.DGVSecondTest.Location.Y + form.DGVSecondTest.Size.Height >= form.lblDownSecondTest.Location.Y + i * 9.7; i++)
                form.lblDownSecondTest.Text += "=";
            form.lblDownSecondTest.Text += ">";

            form.SizeFirstTest.Location = new Point(form.DGVFirstTest.Location.X + form.DGVFirstTest.Size.Width, Convert.ToInt32(form.DGVFirstTest.Location.Y + form.DGVFirstTest.Size.Height / 2.5));
            form.lblUpFirstTest.Text = "<";
            form.lblUpFirstTest.Location = new Point(form.DGVFirstTest.Location.X + form.DGVFirstTest.Size.Width, form.DGVFirstTest.Location.Y);
            for (int i = 1; form.SizeFirstTest.Location.Y >= form.lblUpFirstTest.Location.Y + i * 10; i++)
                form.lblUpFirstTest.Text += "=";
            form.lblUpFirstTest.Text += ">";
            form.lblDownFirstTest.Location = new Point(form.DGVFirstTest.Location.X + form.DGVFirstTest.Size.Width, form.SizeFirstTest.Location.Y + 23);
            form.lblDownFirstTest.Text = "<";
            for (int i = 1; form.DGVFirstTest.Location.Y + form.DGVFirstTest.Size.Height >= form.lblDownFirstTest.Location.Y + i * 9.7; i++)
                form.lblDownFirstTest.Text += "=";
            form.lblDownFirstTest.Text += ">";

            form.operationTest.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 3.3), Convert.ToInt32(form.DGVResultTest.Location.Y + form.DGVResultTest.Size.Height / 3));
            form.firstParamTest.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 50), Convert.ToInt32(form.Size.Height / 5.2));
            form.secondParamTest.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 2.7), Convert.ToInt32(form.Size.Height / 5.2));
            form.resultTest.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 1.4), Convert.ToInt32(form.Size.Height / 5.2));

            form.RunTest.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 2.3), form.tabControl2.Location.Y + form.tabControl2.Size.Height - 70);
            form.errorRate.Location = new Point(40, 30);
        }

        public static void FormMain_Resize(object sender, EventArgs e)
        {
            form.DGVResultTest.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 1.4), Convert.ToInt32(form.Size.Height / 4));
            form.DGVFirstTest.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 50), Convert.ToInt32(form.Size.Height / 4));
            form.DGVSecondTest.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 2.7), Convert.ToInt32(form.Size.Height / 4));
            form.DGVResultTest.Size = new Size(Convert.ToInt32(form.tabControl2.Size.Width / 4.2), Convert.ToInt32(form.Size.Height / 3.5));
            form.DGVFirstTest.Size = new Size(Convert.ToInt32(form.tabControl2.Size.Width / 4.2), Convert.ToInt32(form.Size.Height / 3.5));
            form.DGVSecondTest.Size = new Size(Convert.ToInt32(form.tabControl2.Size.Width / 4.2), Convert.ToInt32(form.Size.Height / 3.5));
            form.SizeResultTest.Location = new Point(form.DGVResultTest.Location.X + form.DGVResultTest.Size.Width, Convert.ToInt32(form.DGVResultTest.Location.Y + form.DGVResultTest.Size.Height / 2.5));
            form.lblUpResultTest.Text = "<";
            form.lblUpResultTest.Location = new Point(form.DGVResultTest.Location.X + form.DGVResultTest.Size.Width, form.DGVResultTest.Location.Y);
            for (int i = 1; form.SizeResultTest.Location.Y >= form.lblUpResultTest.Location.Y + i * 10; i++)
                form.lblUpResultTest.Text += "=";
            form.lblUpResultTest.Text += ">";
            form.lblDownResultTest.Location = new Point(form.DGVResultTest.Location.X + form.DGVResultTest.Size.Width, form.SizeResultTest.Location.Y + 23);
            form.lblDownResultTest.Text = "<";
            for (int i = 1; form.DGVResultTest.Location.Y + form.DGVResultTest.Size.Height >= form.lblDownResultTest.Location.Y + i * 9.7; i++)
                form.lblDownResultTest.Text += "=";
            form.lblDownResultTest.Text += ">";

            form.lblResultTest.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 1.55), Convert.ToInt32(form.DGVResultTest.Location.Y + form.DGVResultTest.Size.Height / 3));

            form.SizeSecondTest.Location = new Point(form.DGVSecondTest.Location.X + form.DGVSecondTest.Size.Width, Convert.ToInt32(form.DGVSecondTest.Location.Y + form.DGVSecondTest.Size.Height / 2.5));
            form.lblUpSecondTest.Text = "<";
            form.lblUpSecondTest.Location = new Point(form.DGVSecondTest.Location.X + form.DGVSecondTest.Size.Width, form.DGVSecondTest.Location.Y);
            for (int i = 1; form.SizeSecondTest.Location.Y >= form.lblUpSecondTest.Location.Y + i * 10; i++)
                form.lblUpSecondTest.Text += "=";
            form.lblUpSecondTest.Text += ">";
            form.lblDownSecondTest.Location = new Point(form.DGVSecondTest.Location.X + form.DGVSecondTest.Size.Width, form.SizeSecondTest.Location.Y + 23);
            form.lblDownSecondTest.Text = "<";
            for (int i = 1; form.DGVSecondTest.Location.Y + form.DGVSecondTest.Size.Height >= form.lblDownSecondTest.Location.Y + i * 9.7; i++)
                form.lblDownSecondTest.Text += "=";
            form.lblDownSecondTest.Text += ">";

            form.SizeFirstTest.Location = new Point(form.DGVFirstTest.Location.X + form.DGVFirstTest.Size.Width, Convert.ToInt32(form.DGVFirstTest.Location.Y + form.DGVFirstTest.Size.Height / 2.5));
            form.lblUpFirstTest.Text = "<";
            form.lblUpFirstTest.Location = new Point(form.DGVFirstTest.Location.X + form.DGVFirstTest.Size.Width, form.DGVFirstTest.Location.Y);
            for (int i = 1; form.SizeFirstTest.Location.Y >= form.lblUpFirstTest.Location.Y + i * 10; i++)
                form.lblUpFirstTest.Text += "=";
            form.lblUpFirstTest.Text += ">";
            form.lblDownFirstTest.Location = new Point(form.DGVFirstTest.Location.X + form.DGVFirstTest.Size.Width, form.SizeFirstTest.Location.Y + 23);
            form.lblDownFirstTest.Text = "<";
            for (int i = 1; form.DGVFirstTest.Location.Y + form.DGVFirstTest.Size.Height >= form.lblDownFirstTest.Location.Y + i * 9.7; i++)
                form.lblDownFirstTest.Text += "=";
            form.lblDownFirstTest.Text += ">";

            form.operationTest.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 3.3), Convert.ToInt32(form.DGVResultTest.Location.Y + form.DGVResultTest.Size.Height / 3));
            form.firstParamTest.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 50), Convert.ToInt32(form.Size.Height / 5.2));
            form.secondParamTest.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 2.7), Convert.ToInt32(form.Size.Height / 5.2));
            form.resultTest.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 1.4), Convert.ToInt32(form.Size.Height / 5.2));

            form.RunTest.Location = new Point(Convert.ToInt32(form.tabControl2.Size.Width / 2.3), form.tabControl2.Location.Y + form.tabControl2.Size.Height - 70);
            form.errorRate.Location = new Point(40, 30);
        }

        public static void lblUpFirstTest_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(form.BackColor);
            e.Graphics.RotateTransform(-90);
            SizeF textSize = e.Graphics.MeasureString(form.lblUpFirstTest.Text, form.lblUpFirstTest.Font);
            form.lblUpFirstTest.Width = (int)textSize.Height + 2;
            form.lblUpFirstTest.Height = (int)textSize.Width + 2;
            e.Graphics.TranslateTransform(-form.lblUpFirstTest.Height / 2, form.lblUpFirstTest.Width / 2);
            e.Graphics.DrawString(form.lblUpFirstTest.Text, form.lblUpFirstTest.Font, Brushes.Black, -(textSize.Width / 2), -(textSize.Height / 2));
        }

        public static void lblDownFirstTest_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(form.BackColor);
            e.Graphics.RotateTransform(-90);
            SizeF textSize = e.Graphics.MeasureString(form.lblDownFirstTest.Text, form.lblDownFirstTest.Font);
            form.lblDownFirstTest.Width = (int)textSize.Height + 2;
            form.lblDownFirstTest.Height = (int)textSize.Width + 2;
            e.Graphics.TranslateTransform(-form.lblDownFirstTest.Height / 2, form.lblDownFirstTest.Width / 2);
            e.Graphics.DrawString(form.lblDownFirstTest.Text, form.lblDownFirstTest.Font, Brushes.Black, -(textSize.Width / 2), -(textSize.Height / 2));
        }

        public static void lblUpResultTest_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(form.BackColor);
            e.Graphics.RotateTransform(-90);
            SizeF textSize = e.Graphics.MeasureString(form.lblUpResultTest.Text, form.lblUpResultTest.Font);
            form.lblUpResultTest.Width = (int)textSize.Height + 2;
            form.lblUpResultTest.Height = (int)textSize.Width + 2;
            e.Graphics.TranslateTransform(-form.lblUpResultTest.Height / 2, form.lblUpResultTest.Width / 2);
            e.Graphics.DrawString(form.lblUpResultTest.Text, form.lblUpResultTest.Font, Brushes.Black, -(textSize.Width / 2), -(textSize.Height / 2));
        }

        public static void lblDownResultTest_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(form.BackColor);
            e.Graphics.RotateTransform(-90);
            SizeF textSize = e.Graphics.MeasureString(form.lblDownResultTest.Text, form.lblDownResultTest.Font);
            form.lblDownResultTest.Width = (int)textSize.Height + 2;
            form.lblDownResultTest.Height = (int)textSize.Width + 2;
            e.Graphics.TranslateTransform(-form.lblDownResultTest.Height / 2, form.lblDownResultTest.Width / 2);
            e.Graphics.DrawString(form.lblDownResultTest.Text, form.lblDownResultTest.Font, Brushes.Black, -(textSize.Width / 2), -(textSize.Height / 2));
        }

        public static void lblDownSecondTest_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(form.BackColor);
            e.Graphics.RotateTransform(-90);
            SizeF textSize = e.Graphics.MeasureString(form.lblDownSecondTest.Text, form.lblDownSecondTest.Font);
            form.lblDownSecondTest.Width = (int)textSize.Height + 2;
            form.lblDownSecondTest.Height = (int)textSize.Width + 2;
            e.Graphics.TranslateTransform(-form.lblDownSecondTest.Height / 2, form.lblDownSecondTest.Width / 2);
            e.Graphics.DrawString(form.lblDownSecondTest.Text, form.lblDownSecondTest.Font, Brushes.Black, -(textSize.Width / 2), -(textSize.Height / 2));
        }

        public static void lblUpSecondTest_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(form.BackColor);
            e.Graphics.RotateTransform(-90);
            SizeF textSize = e.Graphics.MeasureString(form.lblUpSecondTest.Text, form.lblUpSecondTest.Font);
            form.lblUpSecondTest.Width = (int)textSize.Height + 2;
            form.lblUpSecondTest.Height = (int)textSize.Width + 2;
            e.Graphics.TranslateTransform(-form.lblUpSecondTest.Height / 2, form.lblUpSecondTest.Width / 2);
            e.Graphics.DrawString(form.lblUpSecondTest.Text, form.lblUpSecondTest.Font, Brushes.Black, -(textSize.Width / 2), -(textSize.Height / 2));
        }

        public static void tabControl2_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
                DBWork.LoadComboBoxes(form.firstParamTest, form.secondParamTest);
                form.resultTest.Items.Add("Result");
                form.resultTest.SelectedIndex = 0;
                form.countMatrices = DBWork.GetCountMatrices();
                form.countVectors = DBWork.GetCountVectors();
            }
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

        public static void firstParamTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            form.DGVResult.DataSource = null;
            if (form.firstParamTest.Text == "--Матрицы--" || form.firstParamTest.Text == "--Вектора--" || form.firstParamTest.Text == "None")
            {
                form.DGVFirstTest.DataSource = null;
                form.firstParamTest.Text = "None";
                form.SizeFirstTest.Text = "";
                return;
            }
            if (form.firstParamTest.SelectedIndex <= form.countMatrices + 1)
            {
                string format = DBWork.GetFormatMatrix(form.firstParamTest.Text);
                string filePath = DBWork.GetFilePathMatrix(form.firstParamTest.Text);
                switch (format)
                {
                    case "txt":
                        try
                        {
                            using (StreamReader file = new StreamReader(filePath))
                            {
                                TridiagonalMatrix matrix = new TridiagonalMatrix();
                                matrix.Initialize(file);
                                LoadDataGridView(form.DGVFirstTest, form.SizeFirstTest, matrix);
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
                                LoadDataGridView(form.DGVFirstTest, form.SizeFirstTest, matrix);
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
                                LoadDataGridView(form.DGVFirstTest, form.SizeFirstTest, matrix);
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
                string format = DBWork.GetFormatVector(form.firstParamTest.Text);
                string filePath = DBWork.GetFilePathVector(form.firstParamTest.Text);
                switch (format)
                {
                    case "txt":
                        try
                        {
                            using (StreamReader file = new StreamReader(filePath))
                            {
                                ScalarVector vector = new ScalarVector();
                                vector.Initialize(file);
                                LoadDataGridView(form.DGVFirstTest, form.SizeFirstTest, vector);
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
                                LoadDataGridView(form.DGVFirstTest, form.SizeFirstTest, vector);
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
                                LoadDataGridView(form.DGVFirstTest, form.SizeFirstTest, vector);
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

        public static void secondParamTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            form.DGVResult.DataSource = null;
            if (form.secondParamTest.Text == "--Матрицы--" || form.secondParamTest.Text == "--Вектора--" || form.secondParamTest.Text == "None")
            {
                form.DGVSecondTest.DataSource = null;
                form.secondParamTest.Text = "None";
                form.SizeSecondTest.Text = "";
                return;
            }
            if (form.secondParamTest.SelectedIndex <= form.countMatrices + 1)
            {
                string format = DBWork.GetFormatMatrix(form.secondParamTest.Text);
                string filePath = DBWork.GetFilePathMatrix(form.secondParamTest.Text);
                switch (format)
                {
                    case "txt":
                        try
                        {
                            using (StreamReader file = new StreamReader(filePath))
                            {
                                TridiagonalMatrix matrix = new TridiagonalMatrix();
                                matrix.Initialize(file);
                                LoadDataGridView(form.DGVSecondTest, form.SizeSecondTest, matrix);
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
                                LoadDataGridView(form.DGVSecondTest, form.SizeSecondTest, matrix);
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
                                LoadDataGridView(form.DGVSecondTest, form.SizeSecondTest, matrix);
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
                string format = DBWork.GetFormatVector(form.secondParamTest.Text);
                string filePath = DBWork.GetFilePathVector(form.secondParamTest.Text);
                switch (format)
                {
                    case "txt":
                        try
                        {
                            using (StreamReader file = new StreamReader(filePath))
                            {
                                ScalarVector vector = new ScalarVector();
                                vector.Initialize(file);
                                LoadDataGridView(form.DGVSecondTest, form.SizeSecondTest, vector);
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
                                LoadDataGridView(form.DGVSecondTest, form.SizeSecondTest, vector);
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
                                LoadDataGridView(form.DGVSecondTest, form.SizeSecondTest, vector);
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

        public static ScalarVector RunthroughMethod(TridiagonalMatrix matrix, ScalarVector vector)
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
        public static ScalarVector InstabilityMethod(TridiagonalMatrix matrix, ScalarVector vector)
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

        public static void RunTest_Click(object sender, EventArgs e)
        {
            form.DGVResult.DataSource = null;
            if (form.DGVFirstTest.DataSource == null || form.DGVSecondTest.DataSource == null)
            {
                MessageBox.Show("Для выполнения операции должны быть инициализированны два поля", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            TridiagonalMatrix matrix = new TridiagonalMatrix().Initialize(ConvertDataGridViewToMatrix(form.DGVFirstTest, form.SizeFirstTest));
            ScalarVector vector = new ScalarVector().Initialize(ConvertDataGridViewToVector(form.DGVSecondTest, form.SizeSecondTest));
            ScalarVector vectorResult = new ScalarVector();
            vectorResult = matrix * vector;
            FormChoice formChoice = new FormChoice();
            formChoice.ShowDialog();
            ScalarVector X = new ScalarVector();
            switch (formChoice.choice)
            {
                case 1:
                    X = RunthroughMethod(matrix, vectorResult);
                    break;
                case 2:
                    X = InstabilityMethod(matrix, vectorResult);
                    break;
            }
            double rate = Int32.MinValue;
            for (int i = 0; i < vector.Size; i++)
                if (Math.Abs(vector[i] - X[i]) > rate)
                    rate = Math.Abs(vector[i] - X[i]);
            form.errorRate.Text += Convert.ToString(rate);
            LoadDataGridView(form.DGVResultTest, form.SizeResultTest, vector);
        }
    }
}
