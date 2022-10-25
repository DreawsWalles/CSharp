using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_14
{
    public class Masks
    {
        private static int def_size = 300 * 300;
        private FormMain _form;
        private Bitmap _source;
        private int _sizeSmoothing;
        public Masks(Bitmap source, int sizeSmoothing, FormMain form = null)
        {
            _form = form;
            _source = source;
            _sizeSmoothing = sizeSmoothing;
        }
        private List<int[]> SplitARGBChannels(Bitmap source, int x, int y, int[] dx, int[] dy)
        {
            int[] channelA = new int[3];
            int[] channelR = new int[3];
            int[] channelG = new int[3];
            int[] channelB = new int[3];
            for (int index = 0; index < 3; index++)
            {
                Color currentColor = source.GetPixel(x + dx[index], y + dy[index]);
                channelA[index] = currentColor.A;
                channelR[index] = currentColor.R;
                channelG[index] = currentColor.G;
                channelB[index] = currentColor.B;
            }
            return new List<int[]>() { channelA, channelR, channelG, channelB };
        }
        private int GetAverangeValue(int[] array)
        {
            int result = 0;
            foreach (int element in array)
                result += element;
            return (int)Math.Round(result / 3.0);
        }
        private Color GetColor(Bitmap source, int x, int y, int[] dx, int[] dy)
        {
            List<int[]> matrixChannels = SplitARGBChannels(source, x, y, dx, dy);
            return Color.FromArgb(GetAverangeValue(matrixChannels[0]), GetAverangeValue(matrixChannels[1]), GetAverangeValue(matrixChannels[2]), GetAverangeValue(matrixChannels[3]));
        }
        private Bitmap IncreaseSize(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width + 2, source.Height + 2);
            for (int y = 0; y < source.Height; y++)
                for (int x = 0; x < source.Width; x++)
                    result.SetPixel(x + 1, y + 1, source.GetPixel(x, y));
            for (int i = 1; i < source.Width; i++)
            {
                result.SetPixel(i, 0, source.GetPixel(i, 0));
                result.SetPixel(i, source.Height, source.GetPixel(i, source.Height - 1));
            }
            for (int i = 1; i < source.Height; i++)
            {
                result.SetPixel(0, i, source.GetPixel(0, i));
                result.SetPixel(source.Width, i, source.GetPixel(source.Width - 1, i));
            }
            result.SetPixel(0, 0, GetColor(result, 0, 0, new int[] { 1, 1, 0 }, new int[] { 0, 1, 0 }));
            result.SetPixel(0, source.Height, GetColor(result, 0, source.Height, new int[] { 0, 1, 1 }, new int[] { -1, 0, -1 }));
            result.SetPixel(source.Width, 0, GetColor(result, source.Width, 0, new int[] { -1, -1, 0 }, new int[] { 0, 1, 1 }));
            result.SetPixel(source.Width, source.Height, GetColor(result, source.Width, source.Height, new int[] { 0, -1, -1 }, new int[] { -1, 0, -1 }));
            return result;
        }

        private Bitmap ReduceSize(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width - 2, source.Height - 2);
            for (int y = 0; y < result.Height; y++)
                for (int x = 0; x < result.Width; x++)
                    result.SetPixel(x, y, source.GetPixel(x + 1, y + 1));
            return result;
        }
        public Bitmap Smoothing()
        {
            if (_form != null)
                _form.progressBar1.Invoke((MethodInvoker)delegate
                {
                    _form.progressBar1.Visible = true;
                    _form.progressBar1.Value = 0;
                });

            //Bitmap result = _source.Width * _source.Height < def_size ? ReduceSize(SmoothingDefault.Smoothing(IncreaseSize(_source), _form)) : SmoothingGaussian.Smoothing(_source, Convert.ToDouble(_sizeSmoothing), _form);

            Bitmap result = _source.Width * _source.Height < def_size ? _source.Smoothing(_form) : _source.Smoothing(Convert.ToDouble(_sizeSmoothing), _form) ;
            if (_form != null)
                _form.progressBar1.Invoke((MethodInvoker)delegate
                {
                    _form.progressBar1.Value = 100;
                });
            return result;
        }
    }
}
