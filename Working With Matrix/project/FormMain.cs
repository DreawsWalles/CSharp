using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;


namespace project
{
    public struct diapozon
    {
        public int min;
        public int max;
    }
    public partial class FormMain : Form
    {
        public ComboBox comboBox;
        public TextBox nameMatrix;
        public string currentNameMatrix;
        public string currentNameVector;
        public double tmpField;
        public int countMatrices;
        public int countVectors;
        public int numberResult = -1;
        public List<diapozon> diapozons = new List<diapozon>();

        public FormMain()
        { 
            InitializeComponent();
            AddEventsTabPageOne();
            AddEventsTabPageTwo();
            AddEventsTabPageFour();
            AddEventsTabPageFive();
            comboBox = comboBoxMatrix;
            nameMatrix = NameMatrix;
            TabPageOneWork.UnVisibleElements();
            TabPageTwoWork.UnVisibleElements();
            
            DBWork.Load(this);
        }
        private void AddEventsTabPageOne()
        {
            TabPageOneWork.Load(this);
            Load += new EventHandler(TabPageOneWork.Form_Load);
            Resize += new EventHandler(TabPageOneWork.Form_Resize);
            txtToolStripMenuItem.Click += new EventHandler(TabPageOneWork.ImportMatrixFromTxt);
            xmlToolStripMenuItem.Click += new EventHandler(TabPageOneWork.ImportMatrixFromXml);
            binToolStripMenuItem.Click += new EventHandler(TabPageOneWork.ImportMatrixFromBin);
            txtToolStripMenuItem1.Click += new EventHandler(TabPageOneWork.ExportMatrixFromTxt);
            xmlToolStripMenuItem1.Click += new EventHandler(TabPageOneWork.ExportMatrixFromXml);
            binToolStripMenuItem1.Click += new EventHandler(TabPageOneWork.ExportMatrixFromBin);
            label1Matrix.Paint += new PaintEventHandler(TabPageOneWork.Label1_Paint);
            label2Matrix.Paint += new PaintEventHandler(TabPageOneWork.Label2_Paint);
            comboBoxMatrix.SelectedIndexChanged += new EventHandler(TabPageOneWork.ComboBox1_SelectedIndexChanged);
            RemoveMatrix.Click += new EventHandler(TabPageOneWork.Remove_Click);
            EditMatrix.Click += new EventHandler(TabPageOneWork.Edit_Click);
            CanselMatrix.Click += new EventHandler(TabPageOneWork.Cansel_Click);
            AcceptMatrix.Click += new EventHandler(TabPageOneWork.Accept_Click);
            dataGridViewMatrix.CellEndEdit += new DataGridViewCellEventHandler(TabPageOneWork.DataGridView1_CellEndEdit);
            dataGridViewMatrix.CellBeginEdit += new DataGridViewCellCancelEventHandler(TabPageOneWork.DataGridView1_CellBeginEdit);
            dataGridViewMatrix.DataError += new DataGridViewDataErrorEventHandler(TabPageOneWork.DataGridView1_DataError);
            dataGridViewMatrix.UserAddedRow += new DataGridViewRowEventHandler(TabPageOneWork.DataGridView1_UserAddedRow);
            randomMatrix.Click += new EventHandler(TabPageOneWork.Random_Click);
            toolStripMenuItem1.Click += new EventHandler(TabPageOneWork.Create_Click);
            toolStripMenuItem2.Click += new EventHandler(TabPageOneWork.ToolStripMenuItem2_Click);
        }
        private void AddEventsTabPageTwo()
        {
            TabPageTwoWork.Load(this);
            Load += new EventHandler(TabPageTwoWork.FormMain_Load);
            Resize += new EventHandler(TabPageTwoWork.FormMain_Resize);
            txtToolStripMenuItem2.Click += new EventHandler(TabPageTwoWork.ImportVectorFromTxt);
            xmlToolStripMenuItem2.Click += new EventHandler(TabPageTwoWork.ImportVectorFromXml);
            binToolStripMenuItem2.Click += new EventHandler(TabPageTwoWork.ImportVectorFromBin);
            label1Vector.Paint += new PaintEventHandler(TabPageTwoWork.Label1Vector_Paint);
            label2Vector.Paint += new PaintEventHandler(TabPageTwoWork.Label2Vector_Paint);
            comboBoxVector.SelectedIndexChanged += new EventHandler(TabPageTwoWork.ComboBoxVector_SelectedIndexChanged);
            RemoveVector.Click += new EventHandler(TabPageTwoWork.RemoveVector_Click);
            EditVector.Click += new EventHandler(TabPageTwoWork.EditVector_Click);
            CancelVector.Click += new EventHandler(TabPageTwoWork.CancelVector_Click);
            AcceptVector.Click += new EventHandler(TabPageTwoWork.AcceptVector_Click);
            randomVector.Click += new EventHandler(TabPageTwoWork.RandomVector_Click);
            toolStripMenuItem3.Click += new EventHandler(TabPageTwoWork.Create_Click);
            toolStripMenuItem4.Click += new EventHandler(TabPageTwoWork.ToolStripMenuItem4_Click);
            txtToolStripMenuItem3.Click += new EventHandler(TabPageTwoWork.ExportVectorFromTxt);
            xmlToolStripMenuItem3.Click += new EventHandler(TabPageTwoWork.ExportVectorFromXml);
            binToolStripMenuItem3.Click += new EventHandler(TabPageTwoWork.ExportVectorFromBin);
        }
        private void AddEventsTabPageFour()
        {
            TabPageFourWork.Load(this);
            Load += new EventHandler(TabPageFourWork.FormMain_Load);
            Resize += new EventHandler(TabPageFourWork.FormMain_Resize);
            lblUpResult.Paint += new PaintEventHandler(TabPageFourWork.lblUpResult_Paint);
            lblDownResult.Paint += new PaintEventHandler(TabPageFourWork.lblDownResult_Paint);
            lblUpSecond.Paint += new PaintEventHandler(TabPageFourWork.lblUpSecond_Paint);
            lblDownSecond.Paint += new PaintEventHandler(TabPageFourWork.lblDownSecond_Paint);
            lblUpFirst.Paint += new PaintEventHandler(TabPageFourWork.lblUpFirst_Paint);
            lblDownFirst.Paint += new PaintEventHandler(TabPageFourWork.lblDownFirst_Paint);
            tabControl1.Selected += new TabControlEventHandler(TabPageFourWork.tabControl1_Selected);
            firstParam.SelectedIndexChanged += new EventHandler(TabPageFourWork.firstParam_SelectedIndexChanged);
            secondParam.SelectedIndexChanged += new EventHandler(TabPageFourWork.secondParam_SelectedIndexChanged);
            result.SelectedIndexChanged += new EventHandler(TabPageFourWork.result_SelectedIndexChanged);
            Run.Click += new EventHandler(TabPageFourWork.Run_Click);
        }
        private void AddEventsTabPageFive()
        {
            TabPageFiveWork.Load(this);
            Load += new EventHandler(TabPageFiveWork.FormMain_Load);
            Resize += new EventHandler(TabPageFiveWork.FormMain_Resize);
            lblDownFirstTest.Paint += new PaintEventHandler(TabPageFiveWork.lblDownFirstTest_Paint);
            lblUpFirstTest.Paint += new PaintEventHandler(TabPageFiveWork.lblUpFirstTest_Paint);
            lblDownSecondTest.Paint += new PaintEventHandler(TabPageFiveWork.lblDownSecondTest_Paint);
            lblUpSecondTest.Paint += new PaintEventHandler(TabPageFiveWork.lblUpSecondTest_Paint);
            lblDownResultTest.Paint += new PaintEventHandler(TabPageFiveWork.lblDownResultTest_Paint);
            lblUpResultTest.Paint += new PaintEventHandler(TabPageFiveWork.lblUpResultTest_Paint);
            tabControl2.Selected += new TabControlEventHandler(TabPageFiveWork.tabControl2_Selected);
            firstParamTest.SelectedIndexChanged += new EventHandler(TabPageFiveWork.firstParamTest_SelectedIndexChanged);
            secondParamTest.SelectedIndexChanged += new EventHandler(TabPageFiveWork.secondParamTest_SelectedIndexChanged);
            RunTest.Click += new EventHandler(TabPageFiveWork.RunTest_Click);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lbl1Check1.ForeColor = Color.Gray;
            lbl2Check1.ForeColor = Color.Gray;
            lbl3Check1.ForeColor = Color.Gray;
            lbl4Check1.ForeColor = Color.Gray;
            box1Check1.ReadOnly = true;
            box2Check1.ReadOnly = true;

            lbl1Check2.ForeColor = Color.Gray;
            lbl2Check2.ForeColor = Color.Gray;
            lbl3Check2.ForeColor = Color.Gray;
            lbl4Check2.ForeColor = Color.Gray;
            box1Check2.ReadOnly = true;
            box2Check2.ReadOnly = true;

            lbl1Check3.ForeColor = Color.Gray;
            lbl2Check3.ForeColor = Color.Gray;
            lbl3Check3.ForeColor = Color.Gray;
            lbl4Check3.ForeColor = Color.Gray;
            box1Check3.ReadOnly = true;
            box2Check3.ReadOnly = true;

            lbl1Check4.ForeColor = Color.Gray;
            lbl2Check4.ForeColor = Color.Gray;
            lbl3Check4.ForeColor = Color.Gray;
            lbl4Check4.ForeColor = Color.Gray;
            box1Check4.ReadOnly = true;
            box2Check4.ReadOnly = true;
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            
        }

        private void check1_CheckedChanged(object sender, EventArgs e)
        {
            if (!check1.Checked)
            {
                lbl1Check1.ForeColor = Color.Gray;
                lbl2Check1.ForeColor = Color.Gray;
                lbl3Check1.ForeColor = Color.Gray;
                lbl4Check1.ForeColor = Color.Gray;
                box1Check1.ReadOnly = true;
                box2Check1.ReadOnly = true;
            }
            else
            {
                lbl1Check1.ForeColor = Color.Black;
                lbl2Check1.ForeColor = Color.Black;
                lbl3Check1.ForeColor = Color.Black;
                lbl4Check1.ForeColor = Color.Black;
                box1Check1.ReadOnly = false;
                box2Check1.ReadOnly = false;
            }
        }

        private void check2_CheckedChanged(object sender, EventArgs e)
        {
            if (!check2.Checked)
            {
                lbl1Check2.ForeColor = Color.Gray;
                lbl2Check2.ForeColor = Color.Gray;
                lbl3Check2.ForeColor = Color.Gray;
                lbl4Check2.ForeColor = Color.Gray;
                box1Check2.ReadOnly = true;
                box2Check2.ReadOnly = true;
            }
            else
            {
                lbl1Check2.ForeColor = Color.Black;
                lbl2Check2.ForeColor = Color.Black;
                lbl3Check2.ForeColor = Color.Black;
                lbl4Check2.ForeColor = Color.Black;
                box1Check2.ReadOnly = false;
                box2Check2.ReadOnly = false;
            }
        }

        private void check3_CheckedChanged(object sender, EventArgs e)
        {
            if (!check3.Checked)
            {
                lbl1Check3.ForeColor = Color.Gray;
                lbl2Check3.ForeColor = Color.Gray;
                lbl3Check3.ForeColor = Color.Gray;
                lbl4Check3.ForeColor = Color.Gray;
                box1Check3.ReadOnly = true;
                box2Check3.ReadOnly = true;
            }
            else
            {
                lbl1Check3.ForeColor = Color.Black;
                lbl2Check3.ForeColor = Color.Black;
                lbl3Check3.ForeColor = Color.Black;
                lbl4Check3.ForeColor = Color.Black;
                box1Check3.ReadOnly = false;
                box2Check3.ReadOnly = false;
            }
        }

        private void check4_CheckedChanged(object sender, EventArgs e)
        {
            if (!check4.Checked)
            {
                lbl1Check4.ForeColor = Color.Gray;
                lbl2Check4.ForeColor = Color.Gray;
                lbl3Check4.ForeColor = Color.Gray;
                lbl4Check4.ForeColor = Color.Gray;
                box1Check4.ReadOnly = true;
                box2Check4.ReadOnly = true;
            }
            else
            {
                lbl1Check4.ForeColor = Color.Black;
                lbl2Check4.ForeColor = Color.Black;
                lbl3Check4.ForeColor = Color.Black;
                lbl4Check4.ForeColor = Color.Black;
                box1Check4.ReadOnly = false;
                box2Check4.ReadOnly = false;
            }
        }

        private void box1Check1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(box1Check1);
            }
            catch
            {
                foreach(char element in box1Check1.Text)
                    if(!Char.IsDigit(element))
                    {
                        MessageBox.Show("Некооректный элемент: " + element + ".", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
            }
        }

        private void box2Check1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(box2Check1);
            }
            catch
            {
                foreach (char element in box2Check1.Text)
                    if (!Char.IsDigit(element))
                    {
                        MessageBox.Show("Некооректный элемент: " + element + ".", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
            }
        }

        private void box1Check2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(box1Check2);
            }
            catch
            {
                foreach (char element in box1Check2.Text)
                    if (!Char.IsDigit(element))
                    {
                        MessageBox.Show("Некооректный элемент: " + element + ".", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
            }
        }

        private void box2Check2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(box2Check2);
            }
            catch
            {
                foreach (char element in box2Check2.Text)
                    if (!Char.IsDigit(element))
                    {
                        MessageBox.Show("Некооректный элемент: " + element + ".", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
            }
        }

        private void box1Check3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(box1Check3);
            }
            catch
            {
                foreach (char element in box1Check3.Text)
                    if (!Char.IsDigit(element))
                    {
                        MessageBox.Show("Некооректный элемент: " + element + ".", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
            }
        }

        private void box2Check3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(box2Check3);
            }
            catch
            {
                foreach (char element in box2Check3.Text)
                    if (!Char.IsDigit(element))
                    {
                        MessageBox.Show("Некооректный элемент: " + element + ".", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
            }
        }

        private void box1Check4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(box1Check4);
            }
            catch
            {
                foreach (char element in box1Check4.Text)
                    if (!Char.IsDigit(element))
                    {
                        MessageBox.Show("Некооректный элемент: " + element + ".", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
            }
        }

        private void box2Check4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(box2Check4);
            }
            catch
            {
                foreach (char element in box2Check4.Text)
                    if (!Char.IsDigit(element))
                    {
                        MessageBox.Show("Некооректный элемент: " + element + ".", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (check1.Checked)
                {
                    if (string.IsNullOrEmpty(box1Check1.Text) || string.IsNullOrEmpty(box2Check1.Text))
                        throw new Exception("Вы выбрали диапозон для диагонали A, но не указали его полностью");
                    diapozon d = new diapozon() { min = Convert.ToInt32(box1Check1.Text), max = Convert.ToInt32(box2Check1.Text) };
                    diapozons.Add(d);
                }
                else
                {
                    diapozon d = new diapozon() { min = 1, max = 20 };
                    diapozons.Add(d);
                }
                if (check2.Checked)
                {
                    if (string.IsNullOrEmpty(box1Check2.Text) || string.IsNullOrEmpty(box2Check2.Text))
                        throw new Exception("Вы выбрали диапозон для диагонали B, но не указали его полностью");
                    diapozon d = new diapozon() { min = Convert.ToInt32(box1Check2.Text), max = Convert.ToInt32(box2Check2.Text) };
                    diapozons.Add(d);
                }
                else
                {
                    diapozon d = new diapozon() { min = 1, max = 20 };
                    diapozons.Add(d);
                }
                if (check3.Checked)
                {
                    if (string.IsNullOrEmpty(box1Check3.Text) || string.IsNullOrEmpty(box2Check3.Text))
                        throw new Exception("Вы выбрали диапозон для диагонали B, но не указали его полностью");
                    diapozon d = new diapozon() { min = Convert.ToInt32(box1Check3.Text), max = Convert.ToInt32(box2Check3.Text) };
                    diapozons.Add(d);
                }
                else
                {
                    diapozon d = new diapozon() { min = 1, max = 20 };
                    diapozons.Add(d);
                }
                if (check4.Checked)
                {
                    if (string.IsNullOrEmpty(box1Check4.Text) || string.IsNullOrEmpty(box2Check4.Text))
                        throw new Exception("Вы выбрали диапозон для вектора X, но не указали его полностью");
                    diapozon d = new diapozon() { min = Convert.ToInt32(box1Check4.Text), max = Convert.ToInt32(box2Check4.Text) };
                    diapozons.Add(d);
                }
                else
                {
                    diapozon d = new diapozon() { min = 1, max = 20 };
                    diapozons.Add(d);
                }
                FormTable form = new FormTable(diapozons);
                form.ShowDialog();

            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
