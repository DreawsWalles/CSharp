using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace OS4
{
    public partial class main_form : Form
    {
        Manager mng;
        public static main_form Instance;
        private Random rnd = new Random(DateTime.Now.Millisecond); 

        public main_form()
        {
            InitializeComponent();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            mng.Start();
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            Print_matr();
        }

        //печать матрицы
        public void Print_matr()
        {
            if (mng == null)
            {
                int p = (int)numUpDown_p.Value;
                int r = (int)numUpDown_r.Value;
                dGV_matr.RowCount = p + 1;
                dGV_matr.ColumnCount = r + 1;
                dGV_graph.RowCount = p + 1;
                dGV_graph.ColumnCount = p + 1;
                mng = new Manager(p, r);
            }
            for (int i = 0; i < dGV_matr.ColumnCount; i++)
                for (int j = 0; j < dGV_matr.RowCount; j++)
                {

                    if (i == 0 && j != 0)
                    {
                        dGV_matr[i, j].Value = "Процесс" + (j - 1).ToString();
                        dGV_graph[0, j].Value = "Процесс" + (j - 1).ToString();
                        dGV_graph[j, 0].Value = "Процесс" + (j - 1).ToString();
                    }
                    else if (j == 0 && i != 0)
                        dGV_matr[i, j].Value = "Ресурс" + (i - 1).ToString();
                    else if (i == 0 && j == 0)
                        dGV_matr[i, j].Value = "";
                    else
                        if (mng.matr[j - 1, i - 1]==1)
                            dGV_matr[i, j].Value = '1';
                }
        }

        //печать графа
        public void Print_graph()
        {
            for (int i = 1; i < dGV_graph.ColumnCount; i++)
                for (int j = 1; j < dGV_graph.RowCount; j++)
                 if (mng.graph[j - 1, i - 1] > 0)
                {
                    dGV_graph[i, j].Value = mng.graph[j - 1, i - 1].ToString();
                }

        }

        //использую для проверки программы
        public void Print_color(int i, int j)
        {

            dGV_matr[j + 1, i + 1].Style.BackColor = System.Drawing.Color.Green;
        }
        
        //использую для проверки программы
        public void Print_color_not(int i, int j)
        {
            dGV_matr[j + 1, i + 1].Style.BackColor = System.Drawing.Color.Red;
        }

        //печать происходящего в 'действия' 
        public void Log(string str)
        {
            logTB.AppendText(str);
            logTB.Text += "\r\n";
        }

        private void main_form_Load(object sender, EventArgs e)
        {
            main_form.Instance = this;
        }

        private void main_form_FormClosed(object sender, FormClosedEventArgs e)
        {
  //         Process.GetCurrentProcess().Kill();
        }

    }
}
