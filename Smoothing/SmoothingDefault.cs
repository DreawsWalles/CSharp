using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_14
{
    public static class SmoothingDefault
    {
        private static List<int[,]> SplitARGBChannels(Bitmap source, int x, int y)
        {
            int[,] channelA = new int[3, 3];
            int[,] channelR = new int[3, 3];
            int[,] channelG = new int[3, 3];
            int[,] channelB = new int[3, 3];
            int[] d = new int[] { -1, 0, 1 };
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    Color currentColor = source.GetPixel(x + d[i], y + d[j]);
                    channelA[i, j] = currentColor.A;
                    channelR[i, j] = currentColor.R;
                    channelG[i, j] = currentColor.G;
                    channelB[i, j] = currentColor.B;
                }
            return new List<int[,]>() { channelA, channelR, channelG, channelB };
        }

        private static int GetAverangeValue(int[,] matrix)
        {
            int result = 0;
            foreach (int value in matrix)
                result += value;
            return (int)Math.Round(result / 9.0);
        }
        private static Color GetColor(Bitmap source, int x, int y)
        {
            List<int[,]> matrixChanel = SplitARGBChannels(source, x, y);
            return Color.FromArgb(GetAverangeValue(matrixChanel[0]), GetAverangeValue(matrixChanel[1]), GetAverangeValue(matrixChanel[2]), GetAverangeValue(matrixChanel[3]));
        }
        private static Bitmap SmoothingWithProgressBar(Bitmap source, FormMain form)
        {
            Bitmap result = (Bitmap)source.Clone();
            double step = 100.0 / (source.Width * source.Height);
            double sum = 0.0;
            for (int y = 1; y < result.Height - 1; y++)
                for (int x = 1; x < result.Width - 1; x++)
                {
                    result.SetPixel(x, y, GetColor(result, x, y));
                    sum += step;
                    form.backgroundWorker1.ReportProgress((int)Math.Round(sum));
                }
            return result;
        }

        private static Bitmap SmoothingWithoutProgressBar(Bitmap source)
        {
            Bitmap result = (Bitmap)source.Clone();
            for (int y = 1; y < result.Height - 1; y++)
                for (int x = 1; x < result.Width - 1; x++)
                    result.SetPixel(x, y, GetColor(result, x, y));
            return result;
        }
        public static Bitmap Smoothing(this Bitmap source, FormMain form) => form == null ? SmoothingWithoutProgressBar(source) : SmoothingWithProgressBar(source, form);
    }
}
