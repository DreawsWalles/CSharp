using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace project
{
    public partial class FormBigValues : Form
    {
        int count;
        public FormBigValues()
        {
            InitializeComponent();
            Hide();
            //FormGetN form = new FormGetN("Введите размерность набора", 11);
            //form.ShowDialog();
            //if (form.DialogResult == DialogResult.OK)
            //{
                //count = form.count;
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //}
            //else
            //    DialogResult = DialogResult.Cancel;
        }
        private void FormBigValues_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult result = MessageBox.Show("Закрыть окно?", "Закрыть",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    Close();
            }
        }

        private void FormBigValues_Load(object sender, EventArgs e)
        {
            button_update_Click(sender, e);
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            chart1.Series.ElementAt(0).Points.Clear();
            chart1.Series.ElementAt(1).Points.Clear();
            int k = 0;
            Random rand = new Random();
            int n = 100;
            while (n <= 10000)
            {
                int[] array = new int[n];
                for (int i = 0; i < n; i++)
                    array[i] = rand.Next();
                Sort.ShellSort_bigValues(array, ref chart1);
                n *= 10;
            }
        }
    }
}
