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
using System.Windows.Forms.DataVisualization.Charting;

namespace project.ApproximateRepresentationOfFunctions
{
    public partial class Form1 : Form
    {
        private readonly object locker = new object();
        private delegate int GetK();
        private GetK delegateK;
        private int getK() => trackBarK.Value;

        private delegate int GetN();
        private GetN delegateN;
        private int getN() => trackBarN.Value;

        private delegate int GetIndexFunc();
        private GetIndexFunc delegateIndexFunc;
        private int getIndexFunc() => comboBoxFunctions.SelectedIndex;

        private delegate string GetLeftBorder();
        private GetLeftBorder delegateLeftBorder;
        private string getLeftBorder() => leftBorder.Text;

        private delegate string GetRightBorder();
        private GetRightBorder delegateRightBorder;
        private string getRightBorder() => rightBorder.Text;

        private delegate object GetSelectItem();
        private GetSelectItem delegateSelectItem;
        private object getSelectItem() => comboBoxFunctions.SelectedItem;

        private delegate int GetMaxN();
        private GetMaxN delegateMaxN;
        private int getMaxN() => trackBarN.Maximum;
        public Form1()
        {
            InitializeComponent();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(CreateSeriesErrorChebyshev);
            backgroundWorker.DoWork += new DoWorkEventHandler(CreateSeriesErrorNormal);
            backgroundWorker.DoWork += new DoWorkEventHandler(CreateSeriesFunction);
            backgroundWorker.DoWork += new DoWorkEventHandler(CreateSeriesPolynomial);
            backgroundWorker.DoWork += new DoWorkEventHandler(CreateSeriesInterpPoints);
            backgroundWorker.DoWork += new DoWorkEventHandler(DrawErrorTable);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunWorkerCompleted);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);


            delegateK = new GetK(getK);
            delegateN = new GetN(getN);
            delegateIndexFunc = new GetIndexFunc(getIndexFunc);
            delegateLeftBorder = new GetLeftBorder(getLeftBorder);
            delegateRightBorder = new GetRightBorder(getRightBorder);
            delegateSelectItem = new GetSelectItem(getSelectItem);
            delegateMaxN = new GetMaxN(getMaxN);
        }
        private bool isCorrect = true;
        Func<double, double>[] functions = new Func<double, double>[]
        {
            (double x) => Math.Pow(x, 3) + 21 * Math.Pow(x, 2) + 2,
            (double x) => Math.Cos(x),
            (double x) => Math.Sin(x),
            (double x) => -1 / (Math.Pow(x, 2) + 9),
            (double x) => -9 + Math.Pow(x, 2) - 6 * x + 6,
            (double x) => 21 + Math.Pow(x, 4) - Math.Pow(x, 5) + x + 7 - Math.Pow(x, 3) + 8 * Math.Pow(x, 2) - 5,
            (double x) => 2 * Math.Cos(Math.Pow(x, 2)) + Math.Sin(Math.Pow(x, 3)) + Math.Cos(Math.Sin(Math.Pow(x, 2))) + 5 * Math.Sin(x) * Math.Pow(x, 3) + 10,
            (double x) => Math.Cos(x) + Math.Sin(x),
        };

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxFunctions.Items.AddRange(new string[]{
                "x^3 + 21x^2 + 2",
                "cos(x)",
                "sin(x)",
                "1 / (x^2 + 9)",
                "-9 + x^2 - 6x + 6",
                "21 + x^4 - x^5 + x + 7 - x^3 + 8x^2 - 5",
                "2cos(x^2) + sin(x^3) + cos(sin(x^3)) + 5sin(x)cos(x) + 10",
                "cos(x) + sin(x)"
            });
            comboBoxFunctions.SelectedIndex = 6;
            lblErrorLeftBorder.Visible = false;
            lblErrorRightBorder.Visible = false;
            rightBorder.Text = "10";
            leftBorder.Text = "-10";
            lblTrackBarNSize.Text = Convert.ToString(trackBarN.Value);
            lblTrackBarKSize.Text = Convert.ToString(trackBarK.Value);

            StartPosition = FormStartPosition.CenterScreen;
            Redraw();

        }

        private void leftBorder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') 
                leftBorder_Leave(sender, new EventArgs());
        }

        private void leftBorder_Leave(object sender, EventArgs e)
        {
            if (!HelpFunctions.CheckBorder(leftBorder.Text, lblErrorLeftBorder))
            {
                ActiveControl = null;
                isCorrect = false;
                HelpFunctions.UnEnableElements("leftBorder", this);
            }
            else
            {
                HelpFunctions.EnableElements("leftBorder", this);
                isCorrect = true;
                Redraw();
            }
        }

        private void rightBorder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                rightBorder_Leave(sender, new EventArgs());
        }

        private void rightBorder_Leave(object sender, EventArgs e)
        {
            if (!HelpFunctions.CheckBorder(rightBorder.Text, lblErrorRightBorder))
            {
                ActiveControl = null;
                isCorrect = false;
                HelpFunctions.UnEnableElements("rightBorder", this);
            }
            else
            {
                HelpFunctions.EnableElements("rightBorder", this);
                isCorrect= true;
                Redraw();
            }
        }

        private void trackBarN_ValueChanged(object sender, EventArgs e)
        {
            lblTrackBarNSize.Text = Convert.ToString(trackBarN.Value);
            Redraw();
        }

        private void trackBarK_ValueChanged(object sender, EventArgs e)
        {
            lblTrackBarKSize.Text = Convert.ToString(trackBarK.Value);
            Redraw();
        }
        private void CreateSeriesFunction(object sender, DoWorkEventArgs e)
        {
            int k = (int)trackBarK.Invoke(delegateK);
            int n = (int)trackBarN.Invoke(delegateN);
            Func<double, double> f = functions[(int)comboBoxFunctions.Invoke(delegateIndexFunc)];
            double[] pointsNormal = PartitionOfInterval.NormalPartition(Convert.ToDouble(leftBorder.Invoke(delegateLeftBorder)), Convert.ToDouble(rightBorder.Invoke(delegateRightBorder)), n + 1);
            double[] pointsChebyshev = PartitionOfInterval.ChebyshevPartition(Convert.ToDouble(leftBorder.Invoke(delegateLeftBorder)), Convert.ToDouble(rightBorder.Invoke(delegateRightBorder)), n + 1);
            NewtonPolynomial polynomialNormal = new NewtonPolynomial(pointsNormal, f);
            NewtonPolynomial polynomialChebyshev = new NewtonPolynomial(pointsChebyshev, f);

            Series function = new Series();
            for (int i = 1; i <= n; i++)
            {
                double[] xNormal = PartitionOfInterval.NormalPartition(pointsNormal[i - 1], pointsNormal[i], k);
                double[] xChebyshev = PartitionOfInterval.ChebyshevPartition(pointsChebyshev[i - 1], pointsChebyshev[i], k);

                for (int j = 0; j < k; j++)
                {
                    double fNormalValue = f(xNormal[j]);
                    function.Points.AddXY(xNormal[j], fNormalValue);
                    backgroundWorker.ReportProgress((int)(1f / (k * n) * 10));
                }
            }

            function.Name = comboBoxFunctions.Invoke(delegateSelectItem).ToString() + "\n";
            function.ChartType = SeriesChartType.Line;

            function.BorderWidth = 1;
            function.Color = Color.Blue;

            chart1.Invoke((MethodInvoker)delegate
            {
                chart1.Series.Add(function);
            });
        }
        private void CreateSeriesPolynomial(object sender, DoWorkEventArgs e)
        {
            int k = (int)trackBarK.Invoke(delegateK);
            int n = (int)trackBarN.Invoke(delegateN);
            Func<double, double> f = functions[(int)comboBoxFunctions.Invoke(delegateIndexFunc)];
            double[] pointsNormal = PartitionOfInterval.NormalPartition(Convert.ToDouble(leftBorder.Invoke(delegateLeftBorder)), Convert.ToDouble(rightBorder.Invoke(delegateRightBorder)), n + 1);
            double[] pointsChebyshev = PartitionOfInterval.ChebyshevPartition(Convert.ToDouble(leftBorder.Invoke(delegateLeftBorder)), Convert.ToDouble(rightBorder.Invoke(delegateRightBorder)), n + 1);
            NewtonPolynomial polynomialNormal = new NewtonPolynomial(pointsNormal, f);
            NewtonPolynomial polynomialChebyshev = new NewtonPolynomial(pointsChebyshev, f);
            Series polynomial = new Series();
            for (int i = 1; i <= n; i++)
            {
                double[] xNormal = PartitionOfInterval.NormalPartition(pointsNormal[i - 1], pointsNormal[i], k);
                double[] xChebyshev = PartitionOfInterval.ChebyshevPartition(pointsChebyshev[i - 1], pointsChebyshev[i], k);

                for (int j = 0; j < k; j++)
                {
                    double pNormalValue = polynomialNormal.Eval(xNormal[j]);
                    polynomial.Points.AddXY(xNormal[j], pNormalValue);
                    backgroundWorker.ReportProgress((int)(1f / (k * n) * 10));
                }
            }

            polynomial.Name = "Полином Ньютона" + '\n';
            polynomial.ChartType = SeriesChartType.Line;
            polynomial.BorderWidth = 1;
            polynomial.Color = Color.Red;

            chart1.Invoke((MethodInvoker)delegate
            {
                chart1.Series.Add(polynomial);
            });
        }
        private void CreateSeriesInterpPoints(object sender, DoWorkEventArgs e)
        {
            int k = (int)trackBarK.Invoke(delegateK);
            int n = (int)trackBarN.Invoke(delegateN);
            Func<double, double> f = functions[(int)comboBoxFunctions.Invoke(delegateIndexFunc)];
            double[] pointsNormal = PartitionOfInterval.NormalPartition(Convert.ToDouble(leftBorder.Invoke(delegateLeftBorder)), Convert.ToDouble(rightBorder.Invoke(delegateRightBorder)), n + 1);
            double[] pointsChebyshev = PartitionOfInterval.ChebyshevPartition(Convert.ToDouble(leftBorder.Invoke(delegateLeftBorder)), Convert.ToDouble(rightBorder.Invoke(delegateRightBorder)), n + 1);
            NewtonPolynomial polynomialNormal = new NewtonPolynomial(pointsNormal, f);
            NewtonPolynomial polynomialChebyshev = new NewtonPolynomial(pointsChebyshev, f);
            Series interpPoints = new Series();
            interpPoints.Points.AddXY(pointsNormal[0], f(pointsNormal[0]));
            for (int i = 1; i <= n; i++)
            {
                interpPoints.Points.AddXY(pointsNormal[i], f(pointsNormal[i]));
                backgroundWorker.ReportProgress((int)(1f / n) * 10);
            }

            interpPoints.Name = "Точки интерполяции" + '\n';
            interpPoints.ChartType = SeriesChartType.Point;
            interpPoints.Color = Color.Black;
            chart1.Invoke((MethodInvoker)delegate
            {
                chart1.Series.Add(interpPoints);
            });
        }
        private void CreateSeriesErrorNormal(object sender, DoWorkEventArgs e)
        {
            int k = (int)trackBarK.Invoke(delegateK);
            int n = (int)trackBarN.Invoke(delegateN);
            Func<double, double> f = functions[(int)comboBoxFunctions.Invoke(delegateIndexFunc)];
            double[] pointsNormal = PartitionOfInterval.NormalPartition(Convert.ToDouble(leftBorder.Invoke(delegateLeftBorder)), Convert.ToDouble(rightBorder.Invoke(delegateRightBorder)), n + 1);
            double[] pointsChebyshev = PartitionOfInterval.ChebyshevPartition(Convert.ToDouble(leftBorder.Invoke(delegateLeftBorder)), Convert.ToDouble(rightBorder.Invoke(delegateRightBorder)), n + 1);
            NewtonPolynomial polynomialNormal = new NewtonPolynomial(pointsNormal, f);
            NewtonPolynomial polynomialChebyshev = new NewtonPolynomial(pointsChebyshev, f);
            Series errorNormal = new Series();

            for (int i = 1; i <= n; i++)
            {

                double[] xNormal = PartitionOfInterval.NormalPartition(pointsNormal[i - 1], pointsNormal[i], k);
                double[] xChebyshev = PartitionOfInterval.ChebyshevPartition(pointsChebyshev[i - 1], pointsChebyshev[i], k);

                for (int j = 0; j < k; j++)
                {
                    double fNormalValue = f(xNormal[j]);
                    double pNormalValue = polynomialNormal.Eval(xNormal[j]);
                    errorNormal.Points.AddXY(xNormal[j], Math.Abs(fNormalValue - pNormalValue));
                    backgroundWorker.ReportProgress((int)(1f / (k * n) * 10));
                }
            }

            errorNormal.Name = "Ошибка при\nравномерном\nразбиении" + '\n';
            errorNormal.ChartType = SeriesChartType.Line;
            errorNormal.Color = Color.Red;

            chart2.Invoke((MethodInvoker)delegate
            {
                chart2.Series.Add(errorNormal);
            });
        }
        private void CreateSeriesErrorChebyshev(object sender, DoWorkEventArgs e)
        {
            int k = (int)trackBarK.Invoke(delegateK);
            int n = (int)trackBarN.Invoke(delegateN);
            Func<double, double> f = functions[(int)comboBoxFunctions.Invoke(delegateIndexFunc)];
            double[] pointsNormal = PartitionOfInterval.NormalPartition(Convert.ToDouble(leftBorder.Invoke(delegateLeftBorder)), Convert.ToDouble(rightBorder.Invoke(delegateRightBorder)), n + 1);
            double[] pointsChebyshev = PartitionOfInterval.ChebyshevPartition(Convert.ToDouble(leftBorder.Invoke(delegateLeftBorder)), Convert.ToDouble(rightBorder.Invoke(delegateRightBorder)), n + 1);
            NewtonPolynomial polynomialNormal = new NewtonPolynomial(pointsNormal, f);
            NewtonPolynomial polynomialChebyshev = new NewtonPolynomial(pointsChebyshev, f);
            Series errorChebyshev = new Series();

            for (int i = 1; i <= n; i++)
            {

                double[] xNormal = PartitionOfInterval.NormalPartition(pointsNormal[i - 1], pointsNormal[i], k);
                double[] xChebyshev = PartitionOfInterval.ChebyshevPartition(pointsChebyshev[i - 1], pointsChebyshev[i], k);

                for (int j = 0; j < k; j++)
                {
                    double fChebyshevValue = f(xChebyshev[j]);
                    double pChebyshevValue = polynomialChebyshev.Eval(xChebyshev[j]);
                    errorChebyshev.Points.AddXY(xChebyshev[j], Math.Abs(fChebyshevValue - pChebyshevValue));
                    backgroundWorker.ReportProgress((int)(1f / (k * n) * 10));
                }
            }

            errorChebyshev.Name = "Ошибка при\nЧебышевском\nразбиении" + '\n';
            errorChebyshev.ChartType = SeriesChartType.Line;
            errorChebyshev.Color = Color.Orange;

            chart2.Invoke((MethodInvoker)delegate
            {
                chart2.Series.Add(errorChebyshev);
            });
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblSuccess.Visible = true;
            lblProcess.Visible = false;
            progressBar1.Visible = false;
            HelpFunctions.SetBorderChart(chart1);
            leftBorder.Enabled = true;
            rightBorder.Enabled = true;
            trackBarK.Enabled = true;
            trackBarN.Enabled = true;
            comboBoxFunctions.Enabled = true;
            int k = progressBar1.Value;

        }
        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value += e.ProgressPercentage;
        }
        private void Redraw()
        {
            if (isCorrect)
            {
                lblProcess.Visible = true;
                progressBar1.Visible = true;
                lblSuccess.Visible = false;
                chart1.Series.Clear();
                chart2.Series.Clear();
                Series fakeSeries = new Series();
                fakeSeries.ChartType = SeriesChartType.Point;
                fakeSeries.IsVisibleInLegend = false;
                chart1.Series.Add(fakeSeries);
                dataGridView1.Rows.Clear();
                leftBorder.Enabled = false;
                rightBorder.Enabled = false;
                trackBarK.Enabled = false;
                trackBarN.Enabled = false;
                comboBoxFunctions.Enabled = false;
                progressBar1.Value = 0;
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void DrawErrorTable(object sender, DoWorkEventArgs e)
        {
            int n = (int)trackBarN.Invoke(delegateMaxN);
            int k = (int)trackBarK.Invoke(delegateK);
            Func<double, double> f = functions[(int)comboBoxFunctions.Invoke(delegateIndexFunc)];
            double leftBorderValue = Convert.ToDouble(leftBorder.Invoke(delegateLeftBorder));
            double rightBorderValue = Convert.ToDouble(rightBorder.Invoke(delegateRightBorder));
            
            for (int i = 1; i <= n; i++)
            {
                double[] pointsNormal = PartitionOfInterval.NormalPartition(leftBorderValue, rightBorderValue, i + 1);
                double[] pointsChebyshev = PartitionOfInterval.ChebyshevPartition(leftBorderValue, rightBorderValue, i + 1);

                NewtonPolynomial polynomialNormal = new NewtonPolynomial(pointsNormal, f);
                NewtonPolynomial polynomialChebyshev = new NewtonPolynomial(pointsChebyshev, f);

                double maxErrorNormal = 0;
                double maxErrorChebyshev = 0;

                for (int j = 1; j <= i; j++)
                {
                    double[] xNormal = PartitionOfInterval.NormalPartition(pointsNormal[j - 1], pointsNormal[j], k);
                    double[] xChebyshev = PartitionOfInterval.ChebyshevPartition(pointsChebyshev[j - 1], pointsChebyshev[j], k);

                    maxErrorNormal = Math.Max(maxErrorNormal, polynomialNormal.GetMaxError(xNormal));
                    maxErrorChebyshev = Math.Max(maxErrorChebyshev, polynomialChebyshev.GetMaxError(xChebyshev));
                    backgroundWorker.ReportProgress((int)(1f / (k * n) * 10));
                }
                dataGridView1.Invoke((MethodInvoker)delegate
                { 
                    dataGridView1.Rows.Add(i, maxErrorNormal, maxErrorChebyshev);
                });
            }
        }
        private void comboBoxFunctions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(leftBorder.Text) && !String.IsNullOrEmpty(rightBorder.Text))
                Redraw();
        }
    }
}
