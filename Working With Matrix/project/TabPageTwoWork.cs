using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace project
{
    public static class TabPageTwoWork
    {
        static FormMain form;
        public static void Load(FormMain f)
        {
            form = f;
        }
        private static double[] ConvertDataGridViewToVector()
        {
            int size = Convert.ToInt32(form.SizeVector.Text);
            double[] result = new double[size];
            for (int i = 0; i < size; i++)
                result[i] = (double)form.dataGridViewVector.Rows[i].Cells[0].Value;
            return result;
        }
        private static void SaveCurrentVector()
        {
            ScalarVector vector = new ScalarVector();
            ScalarVector otherVector = new ScalarVector();
            string format;
            string filePath;
            try
            {
                filePath = DBWork.GetFilePathVector(form.NameVector.Text);
                format = DBWork.GetFormatMatrix(form.NameVector.Text);
                vector.Initialize(ConvertDataGridViewToVector());
                switch (format)
                {
                    case "txt":
                        using (StreamReader file = new StreamReader(filePath))
                        {
                            otherVector.Initialize(file);
                        }
                        break;
                    case "bin":
                        using (BinaryReader file = new BinaryReader(File.Open(filePath, FileMode.Open)))
                        {
                            otherVector.Initialize(file);
                        }
                        break;
                    case "XML":
                        using (FileStream file = new FileStream(filePath, FileMode.Open))
                        {
                            otherVector.Initialize(file);
                        }
                        break;
                }
                if (vector == otherVector)
                    return;
            }
            catch { return; }
            if (MessageBox.Show("Сохранить " + form.NameVector.Text + "?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                switch (format)
                {
                    case "txt":
                        using (StreamWriter file = new StreamWriter(filePath))
                        {
                            vector.Write(file);
                        }
                        break;
                    case "bin":
                        using (BinaryWriter file = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                        {
                            vector.Write(file);
                        }
                        break;
                    case "XML":
                        using (FileStream file = new FileStream(filePath, FileMode.Create))
                        {
                            vector.Write(file);
                        }
                        break;
                }
            }
        }
        public static void UnVisibleElements()
        {
            form.dataGridViewVector.DataSource = null;
            form.dataGridViewVector.Visible = false;
            form.SizeVector.Visible = false;
            form.label1Vector.Visible = false;
            form.label2Vector.Visible = false;
            form.EditVector.Visible = false;
            form.AcceptVector.Visible = false;
            form.NameVector.Visible = false;
            form.CancelVector.Visible = false;
            form.RemoveVector.Visible = false;
            form.randomVector.Visible = false;
        }
        public static void VisibleElements()
        {
            form.dataGridViewVector.Visible = true;
            form.SizeVector.Visible = true;
            form.label1Vector.Visible = true;
            form.label2Vector.Visible = true;
            form.EditVector.Visible = true;
            form.AcceptVector.Visible = true;
            form.NameVector.Visible = true;
            form.CancelVector.Visible = true;
            form.RemoveVector.Visible = true;
            form.randomVector.Visible = true;
        }
        public static void FormMain_Load(object sender, EventArgs e)
        {
            form.comboBoxVector.Location = new Point(form.Size.Width - 190, 2);
            form.dataGridViewVector.Size = new Size(form.Size.Width - 115, form.Size.Height - 138);
            form.dataGridViewVector.Location = new Point(25, 70);
            form.SizeVector.Location = new Point(form.Size.Width - 85, Convert.ToInt32(form.Size.Height / 2.1));
            form.SizeVector.ReadOnly = true;
            form.label1Vector.Location = new Point(form.Size.Width - 85, 70);
            form.label1Vector.Text = "<";
            for (int i = 1; form.SizeVector.Location.Y >= form.label1Vector.Location.Y + i * 10.2; i++)
                form.label1Vector.Text += "=";
            form.label1Vector.Text += ">";
            form.label2Vector.Location = new Point(form.Size.Width - 85, form.SizeVector.Location.Y + 30);
            form.label2Vector.Text = "<";
            for (int i = 1; form.Size.Height - 70 >= form.label2Vector.Location.Y + i * 10; i++)
                form.label2Vector.Text += "=";
            form.label2Vector.Text += ">";
            form.EditVector.Location = new Point(25, 45);
            form.AcceptVector.Location = new Point(25, 45);
            form.NameVector.Location = new Point(60, 45);
            form.NameVector.ReadOnly = true;
            form.SizeVector.ReadOnly = true;
            form.CancelVector.Location = new Point(255, 45);
            form.RemoveVector.Location = new Point(form.Size.Width - 122, 43);
            form.randomVector.Location = new Point(form.Size.Width - 197, 46);
            form.label1Vector.AutoSize = false;
            form.label2Vector.AutoSize = false;
            form.AcceptVector.Visible = false;
            form.CancelVector.Visible = false;
        }
        public static void FormMain_Resize(object sender, EventArgs e)
        {
            form.comboBoxVector.Location = new Point(form.Size.Width - 190, 2);
            form.dataGridViewVector.Size = new Size(form.Size.Width - 115, form.Size.Height - 138);
            form.dataGridViewVector.Location = new Point(25, 70);
            form.SizeVector.Location = new Point(form.Size.Width - 85, Convert.ToInt32(form.Size.Height / 2.1));
            form.label1Vector.Location = new Point(25, form.Size.Height - 75);
            form.label1Vector.Location = new Point(form.Size.Width - 85, 70);
            form.label1Vector.Text = "<";
            for (int i = 1; form.SizeVector.Location.Y >= form.label1Vector.Location.Y + i * 10.2; i++)
                form.label1Vector.Text += "=";
            form.label1Vector.Text += ">";
            form.label2Vector.Location = new Point(form.Size.Width - 85, form.SizeVector.Location.Y + 30);
            form.label2Vector.Text = "<";
            for (int i = 1; form.Size.Height - 70 >= form.label2Vector.Location.Y + i * 10; i++)
                form.label2Vector.Text += "=";
            form.label2Vector.Text += ">";
            form.EditVector.Location = new Point(25, 45);
            form.AcceptVector.Location = new Point(25, 45);
            form.NameVector.Location = new Point(60, 45);
            form.CancelVector.Location = new Point(255, 45);
            form.RemoveVector.Location = new Point(form.Size.Width - 107, 43);
            form.randomVector.Location = new Point(form.Size.Width - 197, 46);

        }
        public static void LoadDataGridView(ScalarVector vector)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("0", typeof(int));
            for (int i = 0; i < vector.Size; i++)
                dt.Rows.Add(new object[] { });
            for (int i = 0; i < vector.Size; i++)
                dt.Rows[i][0] = vector[i];
            form.SizeVector.Text = Convert.ToString(vector.Size);
            form.dataGridViewVector.DataSource = dt;
        }
        public static void ImportVectorFromTxt(object sender, EventArgs e)
        {
            SaveCurrentVector();
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
                        form.NameVector.Text = tmp[tmp.Length - 1];
                        ScalarVector vector = new ScalarVector();
                        vector.Initialize(file);
                        DBWork.AddVector(filePath);
                        LoadDataGridView(vector);
                        form.comboBoxVector.Items.Add(tmp[tmp.Length - 1]);
                        form.comboBoxVector.SelectedIndex = form.comboBoxVector.Items.Count - 1;
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        public static void ImportVectorFromXml(object sender, EventArgs e)
        {
            SaveCurrentVector();
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
                        form.NameVector.Text = tmp[tmp.Length - 1];
                        ScalarVector vector = new ScalarVector();
                        vector.Initialize(file);
                        DBWork.AddVector(filePath);
                        LoadDataGridView(vector);
                        form.comboBoxVector.Items.Add(tmp[tmp.Length - 1]);
                        form.comboBoxVector.SelectedIndex = form.comboBoxVector.Items.Count - 1;
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        public static void ImportVectorFromBin(object sender, EventArgs e)
        {
            SaveCurrentVector();
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
                        form.NameVector.Text = tmp[tmp.Length - 1];
                        ScalarVector vector = new ScalarVector();
                        vector.Initialize(file);
                        DBWork.AddVector(filePath);
                        LoadDataGridView(vector);
                        form.comboBoxVector.Items.Add(tmp[tmp.Length - 1]);
                        form.comboBoxVector.SelectedIndex = form.comboBoxVector.Items.Count - 1;
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        public static void Label1Vector_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(form.BackColor);
            e.Graphics.RotateTransform(-90);
            SizeF textSize = e.Graphics.MeasureString(form.label1Vector.Text, form.label1Vector.Font);
            form.label1Vector.Width = (int)textSize.Height + 2;
            form.label1Vector.Height = (int)textSize.Width + 2;
            e.Graphics.TranslateTransform(-form.label1Vector.Height / 2, form.label1Vector.Width / 2);
            e.Graphics.DrawString(form.label1Vector.Text, form.label1Vector.Font, Brushes.Black, -(textSize.Width / 2), -(textSize.Height / 2));
        }
        public static void Label2Vector_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(form.BackColor);
            e.Graphics.RotateTransform(-90);
            SizeF textSize = e.Graphics.MeasureString(form.label2Vector.Text, form.label2Vector.Font);
            form.label2Vector.Width = (int)textSize.Height + 2;
            form.label2Vector.Height = (int)textSize.Width + 2;
            e.Graphics.TranslateTransform(-form.label2Vector.Height / 2, form.label2Vector.Width / 2);
            e.Graphics.DrawString(form.label2Vector.Text, form.label2Vector.Font, Brushes.Black, -(textSize.Width / 2), -(textSize.Height / 2));
        }
        public static void ComboBoxVector_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveCurrentVector();
            string format = DBWork.GetFormatVector(form.comboBoxVector.Text);
            string filePath = DBWork.GetFilePathVector(form.comboBoxVector.Text);
            ScalarVector vector = new ScalarVector();
            switch (format)
            {
                case "txt":
                    using (StreamReader file = new StreamReader(filePath))
                    {
                        vector.Initialize(file);
                    }
                    break;
                case "bin":
                    using (BinaryReader file = new BinaryReader(File.Open(filePath, FileMode.Open)))
                    {
                        vector.Initialize(file);
                    }
                    break;
                case "XML":
                    using (FileStream file = new FileStream(filePath, FileMode.Open))
                    {
                        vector.Initialize(file);
                    }
                    break;
            }
            LoadDataGridView(vector);
            form.NameVector.Text = form.comboBoxVector.Text;
            VisibleElements();
        }
        public static void RemoveVector_Click(object sender, EventArgs e)
        {
            SaveCurrentVector();
            form.dataGridViewVector.DataSource = null;
            DBWork.RemoveMatrix(form.NameVector.Text, form);
            if (form.comboBoxVector.Items.Count == 0)
                UnVisibleElements();
            else
                form.comboBoxVector.SelectedIndex = form.comboBoxVector.Items.Count - 1;
        }
        public static void EditVector_Click(object sender, EventArgs e)
        {
            form.EditVector.Visible = false;
            form.AcceptVector.Visible = true;
            form.CancelVector.Visible = true;
            form.NameVector.ReadOnly = false;
            form.currentNameVector = form.NameVector.Text;
        }
        public static void CancelVector_Click(object sender, EventArgs e)
        {
            form.NameVector.Text = form.currentNameVector;
            form.EditVector.Visible = true;
            form.AcceptVector.Visible = false;
            form.CancelVector.Visible = false;
            form.NameVector.ReadOnly = true;
        }
        public static void AcceptVector_Click(object sender, EventArgs e)
        {
            try
            {
                DBWork.UpdateVector(form.NameVector.Text, form);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            form.EditVector.Visible = true;
            form.AcceptVector.Visible = false;
            form.CancelVector.Visible = false;
            form.NameVector.ReadOnly = true;
        }
        public static void RandomVector_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int size = Convert.ToInt32(form.SizeVector.Text);
            for (int i = 0; i < size; i++)
                form.dataGridViewVector.Rows[i].Cells[0].Value = rnd.Next(-100, 100);
        }
        public static void Create_Click(object sender, EventArgs e)
        {
            FormCreate formCreate = new FormCreate("вектора");
            formCreate.ShowDialog();
            if (formCreate.DialogResult == DialogResult.OK)
            {
                Directory.CreateDirectory("Vector");
                FileStream file = new FileStream("Vector/" + formCreate.nameObject + ".xml", FileMode.Create);
                int size = formCreate.sizeObject;
                DataTable dt = new DataTable();
                dt.Columns.Add("0", typeof(int));
                for (int i = 0; i < size; i++)
                    dt.Rows.Add(new object[] { });
                for (int i = 0; i < size; i++)
                    dt.Rows[i][0] = 0;
                form.SizeVector.Text = Convert.ToString(size);
                form.dataGridViewVector.DataSource = dt;
                ScalarVector vector = new ScalarVector();
                vector.Initialize(ConvertDataGridViewToVector());
                DBWork.AddVector(file.Name);
                vector.Write(file);
                file.Close();
                form.comboBoxVector.Items.Add(formCreate.nameObject + ".xml");
                form.comboBoxVector.SelectedIndex = form.comboBoxVector.Items.Count - 1;
                form.NameVector.Text = formCreate.nameObject + ".xml";
            }
        }
        public static void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("D:\\OneDrive - ВГУ\\C#\\project.NumericalMethods.WorkingWithMatrix\\project\\Chislennye_metody_Laboratornaya_rabota_SLAU_s_tryokhdiagonalnoy_matritsey.pdf");
        }
        public static void ExportVectorFromTxt(object sender, EventArgs e)
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
                        ScalarVector vector = new ScalarVector();
                        vector.Initialize(ConvertDataGridViewToVector());
                        vector.Write(file);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        public static void ExportVectorFromBin(object sender, EventArgs e)
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
                        ScalarVector vector = new ScalarVector();
                        vector.Initialize(ConvertDataGridViewToVector());
                        vector.Write(file);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        public static void ExportVectorFromXml(object sender, EventArgs e)
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
                        ScalarVector vector = new ScalarVector();
                        vector.Initialize(ConvertDataGridViewToVector());
                        vector.Write(file);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
