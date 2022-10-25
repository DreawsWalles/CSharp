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

namespace Task4
{
    public partial class main_form : Form
    {
        Manager manag;
        Thread main;

        public main_form()
        {
            InitializeComponent();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            Infotb.Clear();
            PrintTitle();
            manag = new Manager((int)numUpDown_p.Value, (int)numUpDown_r.Value);
            manag.ChangeGraph += Print_graph;
            manag.ShowAboutWork += Infotb.AppendText;
            PrintInfoAboutProcess();

            main = new Thread(new ThreadStart(new Action(() => { manag.Start(); })));
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            main.Start();
            btnStop.Enabled = true;
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            manag.Stop();
            main.Abort();
            btnStop.Enabled = false;
        }

        void PrintTitle()
        {
            int p = (int)numUpDown_p.Value;
            int r = (int)numUpDown_r.Value;
            dGV_matr.RowCount = p + 1;
            dGV_matr.ColumnCount = r + 1;
            dGV_graph.RowCount = p + 1;
            dGV_graph.ColumnCount = p + 1;

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
                }
                
        }
        //печать матрицы
        public void PrintInfoAboutProcess()
        {
            for (int i = 1; i < dGV_matr.ColumnCount; i++)
                for (int j = 1; j < dGV_matr.RowCount; j++)
                {
                    if (manag.DataAboutProcess[j - 1, i - 1]==1)
                        dGV_matr[i, j].Value = '1';
                    else
                        dGV_matr[i, j].Value = '0';
                }
        }

        //печать графа
        public void Print_graph()
        {
            for (int i = 1; i < dGV_graph.ColumnCount; i++)
                for (int j = 1; j < dGV_graph.RowCount; j++)
                     if (manag.Graph[j - 1, i - 1] > 0)
                     {
                         dGV_graph[i, j].Value = manag.Graph[j - 1, i - 1].ToString();
                     } 

        }

        private void main_form_Load(object sender, EventArgs e)
        {
            
        }

        private void main_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

    }
}
