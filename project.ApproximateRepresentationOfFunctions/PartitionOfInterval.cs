using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.ApproximateRepresentationOfFunctions
{
    public static class PartitionOfInterval
    {
        public static double[] NormalPartition(double left, double right, int n)
        {
            if (n < 2)
                throw new Exception("n должно быть больше единицы");
            double[] result = new double[n];
            double nDivided = 1.0 / (n - 1);
            double difference = right - left;
            for (int i = 0; i < n; i++)
                result[i] = left + i * difference * nDivided;
            return result;
        }
        public static double[] ChebyshevPartition(double left, double right, int n)
        {
            if (n < 2)
                throw new Exception("n должно быть больше единицы");
            double[] result = new double[n];
            double halfDifference = (right - left) / 2.0;
            double halfBorderSum = (left + right) / 2.0;
            double tmp = Math.PI / (2.0 * (n - 1) + 2.0);
            for (int i = 0; i < n; i++)
                result[i] = halfBorderSum + halfDifference * Math.Cos((2.0 * i + 1.0) * tmp);
            Array.Sort(result);
            return result;
        }
    }
}
