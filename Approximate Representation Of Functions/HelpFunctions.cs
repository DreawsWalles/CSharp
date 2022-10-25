using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace project.ApproximateRepresentationOfFunctions
{
    public static class HelpFunctions
    {
        public static void UnEnableElements(string nameElement, Form1 form)
        {
            foreach (Control element in form.Controls)
            {
                try
                {
                    var tmp = (Panel)element;
                    if (tmp.Name == "panelParams")
                    {
                        foreach (Control control in tmp.Controls)
                        {
                            if (control.Name != nameElement)
                            {
                                try
                                {
                                    var label = (Label)control;
                                    continue;
                                }
                                catch { }
                                control.Enabled = false;
                            }
                        }
                    }
                    continue;
                }
                catch { }
                try
                {
                    var tmp = (Chart)element;
                    tmp.BackColor = Color.WhiteSmoke;
                    tmp.Enabled = false;
                }
                catch { }
            }
        }
        public static void SetBorderChart(Chart chart)
        {
            double maxY = Double.MinValue;
            double minY = Double.MaxValue;

            double maxX = Double.MinValue;
            double minX = Double.MaxValue;
            foreach (Series series in chart.Series)
                foreach (var point in series.Points)
                {
                    if (point.XValue > maxX)
                        maxX = point.XValue;
                    if (point.XValue < minX)
                        minX = point.XValue;
                    foreach (double y in point.YValues)
                    {
                        if (y > maxY)
                            maxY = y;
                        if (y < minY)
                            minY = y;
                    }
                }
            chart.ChartAreas[0].AxisY.Maximum = Math.Ceiling(maxY) + 1;
            chart.ChartAreas[0].AxisY.Minimum = Math.Ceiling(minY) - 1;

            chart.ChartAreas[0].AxisX.Maximum = Math.Ceiling(maxX) + 1;
            chart.ChartAreas[0].AxisX.Minimum = Math.Ceiling(minX) - 1;
        }
        public static void EnableElements(string nameElement, Form1 form)
        {
            foreach (Control element in form.Controls)
            {
                try
                {
                    var tmp = (Panel)element;
                    if (tmp.Name == "panelParams")
                    {
                        foreach (Control control in tmp.Controls)
                            control.Enabled = true;
                    }
                    continue;
                }
                catch { }
                try
                {
                    var tmp = (Chart)element;
                    tmp.BackColor = Color.White;
                    tmp.Enabled = true;
                }
                catch { }
            }
        }
        public static bool CheckBorder(string value, Label lbl)
        {
            try
            {
                Convert.ToDouble(value);
                lbl.Visible = false;
                return true;
            }
            catch (Exception e)
            {
                if (String.IsNullOrEmpty(value))
                {
                    lbl.Visible = true;
                    lbl.Text = "Введена пустая строка";
                    return false;
                }
                value = value.Trim();
                bool ok = true;
                int i = 0;
                while (ok && i < value.Length)
                {
                    if ((value[i] == '-' && i == 0) || value[i] == ',')
                    {
                        i++;
                        continue;
                    }
                    else if (!Char.IsDigit(value[i]))
                    {
                        lbl.Text = $"Введен некорректный символ: '{value[i]}'.";
                        ok = false;
                    }
                    i++;
                }
                if (ok)
                    lbl.Text = e.Message;
                lbl.Visible = true;
                return false;
            }
        }
    }
}
