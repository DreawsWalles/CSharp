using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace project
{
    public static class Animation
    {
        static public void Swap(int index_1, int index_2, ref Panel panel)
        {
            string tmp = panel.Controls[index_1].Text;
            panel.Controls[index_1].BackColor = Color.BlueViolet;
            panel.Controls[index_2].BackColor = Color.BlueViolet;
            panel.Refresh();
            System.Threading.Thread.Sleep(500);
            panel.Controls[index_1].Text = panel.Controls[index_2].Text;
            panel.Controls[index_2].Text = tmp;
            panel.Controls[index_1].BackColor = Color.ForestGreen;
            panel.Controls[index_2].BackColor = Color.ForestGreen;
            panel.Refresh();
            System.Threading.Thread.Sleep(500);
            panel.Controls[index_1].BackColor = Color.Red;
            panel.Controls[index_2].BackColor = Color.Red;

        }
        public static void getChart(ref Chart result, int x, int y, bool isPer)
        {
            if (isPer)
                result.Series.ElementAt(0).Points.AddXY(x, y);
            else
                result.Series.ElementAt(1).Points.AddXY(x, y);
        }
    }
}
