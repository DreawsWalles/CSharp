using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.ApproximateRepresentationOfFunctions
{
    internal class NewtonPolynomial
    {
        private Func<double, double> f;
        private double[] X;
        private double[] d;
        public NewtonPolynomial(double[] X, Func<double, double> f)
        {
            this.X = X;
            this.f = f;
            d = findCoeffsD();
        }

        private double[] findCoeffsD()
        {
            int n = X.Length - 1;
            d = new double[n + 1];
            for (int k = 0; k <= n; k++)
            {
                for (int i = 0; i <= k; i++)
                {
                    double tmp = f(X[i]);
                    for (int j = 0; j <= k; j++)
                        if (j != i)
                            tmp /= X[i] - X[j];
                    d[k] += tmp;
                }

            }

            return d;
        }

        public double Eval(double x)
        {

            int n = X.Length - 1;
            double ksi = 1.0;
            double result = d[0];
            for (int i = 1; i <= n; i++)
            {
                ksi *= x - X[i - 1];
                result += d[i] * ksi;
            }

            return result;
        }

        public double GetMaxError(double[] points)
        {
            double maxError = 0;

            foreach (double x in points)
                maxError = Math.Max(maxError, Math.Abs(f(x) - Eval(x)));

            return maxError;
        }
    }
}
