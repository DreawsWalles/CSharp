using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_14
{
    public static class SmoothingGaussian
    {
        private static int _maxWin = 56;
        private static int _maxDim;

        private struct ARGBStruct
        {
            public double A { get; set; }
            public double R { get; set; }
            public double G { get; set; }
            public double B { get; set; }

        };

        private static double[] InitWindow(double _sigma)
        {
            double[] result = new double[2 * _maxWin];
            result[_maxWin - 1] = 1;
            double coefSmoothing = 2 * _sigma * _sigma;
            for (int i = 1; i <= _maxWin; i++)
            {
                double tmp = i * (-i) / coefSmoothing;
                result[_maxWin + i - 1] = Math.Exp(tmp);
                result[_maxWin - i] = result[_maxWin + i - 1];
            }
            return result;
        }
        private static Bitmap SmoothingWithForm(Bitmap source, FormMain form, double _sigma)
        {
            _maxDim = source.Height > source.Width ? source.Height : source.Width;
            double[] window = InitWindow(_sigma);
            int _n = (int)Math.Round(3 * _sigma);
            Color[] tmp = new Color[_maxDim];
            Bitmap result = (Bitmap)source.Clone();
            double t = source.Height + source.Width;
            double step = 100 / t;
            double sumRes = 0.0;

            for (int j = 0; j < result.Height; j++)
            {
                for (int i = 0; i < result.Width; i++)
                {
                    double sum = 0;
                    ARGBStruct tmpARGB = new ARGBStruct();
                    for (int k = -_n; k < _n; k++)
                    {
                        int l = i + k;
                        if (l >= 0 && l < result.Width)
                        {
                            Color tmpColor = result.GetPixel(l, j);
                            tmpARGB.A += tmpColor.A * window[_maxWin + k];
                            tmpARGB.R += tmpColor.R * window[_maxWin + k];
                            tmpARGB.G += tmpColor.G * window[_maxWin + k];
                            tmpARGB.B += tmpColor.B * window[_maxWin + k];
                            sum += window[_maxWin + k];
                        }
                    }
                    tmp[i] = Color.FromArgb((int)Math.Round(tmpARGB.A / sum),
                                                  (int)Math.Round(tmpARGB.R / sum),
                                                  (int)Math.Round(tmpARGB.G / sum),
                                                  (int)Math.Round(tmpARGB.B / sum));
                }
                for (int i = 0; i < result.Width; i++)
                    result.SetPixel(i, j, tmp[i]);
                sumRes += step;
                form.backgroundWorker1.ReportProgress((int)Math.Round(sumRes));
            }

            for (int i = 0; i < result.Width; i++)
            {
                for (int j = 0; j < result.Height; j++)
                {
                    double sum = 0;
                    ARGBStruct tmpARGB = new ARGBStruct();
                    for (int k = -_n; k < _n; k++)
                    {
                        int l = j + k;
                        if (l >= 0 && l < result.Height)
                        {
                            Color tmpColor = result.GetPixel(i, l);
                            tmpARGB.A += tmpColor.A * window[_maxWin + k];
                            tmpARGB.R += tmpColor.R * window[_maxWin + k];
                            tmpARGB.G += tmpColor.G * window[_maxWin + k];
                            tmpARGB.B += tmpColor.B * window[_maxWin + k];
                            sum += window[_maxWin + k];
                        }
                    }
                    tmp[i] = Color.FromArgb((int)Math.Round(tmpARGB.A / sum),
                                                  (int)Math.Round(tmpARGB.R / sum),
                                                  (int)Math.Round(tmpARGB.G / sum),
                                                  (int)Math.Round(tmpARGB.B / sum));
                }
                for (int j = 0; i < result.Width; i++)
                    result.SetPixel(i, j, tmp[i]);
                sumRes += step;
                form.backgroundWorker1.ReportProgress((int)Math.Round(sumRes));
            }
            return result;
        }
        private static Bitmap SmoothingWithOutForm(Bitmap source, double _sigma)
        {
            _maxDim = source.Height > source.Width ? source.Height : source.Width;
            double[] window = InitWindow(_sigma);
            int _n = (int)Math.Round(3 * _sigma);
            Color[] tmp = new Color[_maxDim];
            Bitmap result = (Bitmap)source.Clone();

            for (int j = 0; j < result.Height; j++)
            {
                for (int i = 0; i < result.Width; i++)
                {
                    double sum = 0;
                    ARGBStruct tmpARGB = new ARGBStruct();
                    for (int k = -_n; k < _n; k++)
                    {
                        int l = i + k;
                        if (l >= 0 && l < result.Width)
                        {
                            Color tmpColor = result.GetPixel(l, j);
                            tmpARGB.A += tmpColor.A * window[_maxWin + k];
                            tmpARGB.R += tmpColor.R * window[_maxWin + k];
                            tmpARGB.G += tmpColor.G * window[_maxWin + k];
                            tmpARGB.B += tmpColor.B * window[_maxWin + k];
                            sum += window[_maxWin + k];
                        }
                    }
                    tmp[i] = Color.FromArgb((int)Math.Round(tmpARGB.A / sum),
                                                  (int)Math.Round(tmpARGB.R / sum),
                                                  (int)Math.Round(tmpARGB.G / sum),
                                                  (int)Math.Round(tmpARGB.B / sum));
                }
                for (int i = 0; i < result.Width; i++)
                    result.SetPixel(i, j, tmp[i]);
            }

            for (int i = 0; i < result.Width; i++)
            {
                for (int j = 0; j < result.Height; j++)
                {
                    double sum = 0;
                    ARGBStruct tmpARGB = new ARGBStruct();
                    for (int k = -_n; k < _n; k++)
                    {
                        int l = j + k;
                        if (l >= 0 && l < result.Height)
                        {
                            Color tmpColor = result.GetPixel(i, l);
                            tmpARGB.A += tmpColor.A * window[_maxWin + k];
                            tmpARGB.R += tmpColor.R * window[_maxWin + k];
                            tmpARGB.G += tmpColor.G * window[_maxWin + k];
                            tmpARGB.B += tmpColor.B * window[_maxWin + k];
                            sum += window[_maxWin + k];
                        }
                    }
                    tmp[i] = Color.FromArgb((int)Math.Round(tmpARGB.A / sum),
                                                  (int)Math.Round(tmpARGB.R / sum),
                                                  (int)Math.Round(tmpARGB.G / sum),
                                                  (int)Math.Round(tmpARGB.B / sum));
                }
                for (int j = 0; i < result.Width; i++)
                    result.SetPixel(i, j, tmp[i]);
            }
            return result;
        }
        public static Bitmap Smoothing(this Bitmap source, double _sigma, FormMain form)
        {
            return form == null ? SmoothingWithOutForm(source, _sigma) : SmoothingWithForm(source, form, _sigma);
        }
    }
}
