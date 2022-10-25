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

namespace project.NumericalDifferentiation
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Chart.Size = new Size(Size.Width, Size.Height - 30);
            button1.Location = new Point(Size.Width - 140, Size.Height - 100);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Chart.Size = new Size(Size.Width, Size.Height - 30);
            button1.Location = new Point(Size.Width - 140, Size.Height - 100);
            MinimumSize = Size;
            Chart.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Chart.Visible = true;
            float h_min = (float)Math.Pow(2.0d, -13.0d);
            float h_max = 1f;
            Chart.Series.Clear();
            Chart.ChartAreas[0].AxisY.Maximum = h_max;
            int size = 4096;
            float[] H = MainTask.GenerateList(h_min, h_max, size);

            Series seriesOne = CreateSeries(H, MainTask.DeltaApriori, "delta_apriori");
            Series seriesTwo = CreateSeries(H, MainTask.DeltaCalculated, "delta_calculated");
            Parallel.Invoke(
                () =>
                {
                    seriesOne = CreateSeries(H, MainTask.DeltaApriori, "delta_apriori");
                },
                ()=>
                {
                    seriesTwo = CreateSeries(H, MainTask.DeltaCalculated, "delta_calculated");
                }
                );

            Chart.Series.Add(seriesOne);
            Chart.Series.Add(seriesTwo);
            Chart.ChartAreas[0].AxisY.Maximum = 0.05;
            Chart.ChartAreas[0].AxisY.Minimum = 0;
        }

        public static Series CreateSeries(float[] H, Func<float, float> F, string name)
        {
            Series result = new Series
            {
                Name = name,
                ChartType = SeriesChartType.Point
            };
            for (int i = 0; i < H.Length; i++)
                result.Points.AddXY(H[i], F(H[i]));
            return result;
        }
    }
}
