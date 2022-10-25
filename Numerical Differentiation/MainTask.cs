using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace project.NumericalDifferentiation
{
    public static class MainTask
    {
        private static Random rnd = new Random();
        private static float epsilon = (float)Math.Pow(2.0d, -23.0d);
        private static float M0 = 1f;
        private static float M7 = 1f;
        private static float F(float x) => (float)Math.Sin(x);
        private static float D(float x) => (float)Math.Sin(x);
        public static float DeltaApriori(float h) => (M7 * 7f * (float)Math.Pow(h, 4) / 240f) + (40f * epsilon * M0 / (3f * (float)Math.Pow(h, 4)));





        public static float[] GenerateList(float minValue, float maxFloat, int size)
        {
            float[] result = new float[size];
            float delta = maxFloat - minValue;
            float tmp = 1f / (size - 1);
            for(int i = 0; i < size; i++)
            {
                result[i] = minValue + delta * i * tmp;
            }
            return result;
        }
        private static float Random(int minValue, int maxValue)
        {
            return minValue + rnd.Next(maxValue - minValue + 1);
        }
        public static float DeltaCalculated(float h)
        {
            float result = 0;
            int maxIter = 32;

            float tmp = 1 / 6f / (float)Math.Pow(h, 4);
            for (int iter = 0; iter < maxIter; iter++)
            {
                float x = Random(-2000, 2000) / Random(100, 1000);
                float dfExac = D(x);
                float dfCalc = (-F(x - 3 * h) + 12 * F(x - 2 * h) - 39 * F(x - h) + 56 * F(x) - 39 * F(x + h) + 12 * F(x + 2 * h) - F(x + 3 * h)) * tmp;
                float dfDelta = Math.Abs(dfExac - dfCalc);
                result = Math.Max(result, dfDelta);
            }

            return result;
        }

    }

}
