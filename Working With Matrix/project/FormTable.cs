using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class FormTable : Form
    {
        List<diapozon> diapozons;

        public FormTable(List<diapozon> diapozons)
        {
            InitializeComponent();
            this.diapozons = diapozons;
        }
        public double[] CreateRow(int size)
        {
            TridiagonalMatrix matrix = new TridiagonalMatrix().Initialize(CreateMatrix(diapozons[0], diapozons[1], diapozons[2], size));
            ScalarVector vector = new ScalarVector().Initialize(CreateVector(diapozons[3], size));
            ScalarVector vectorResult = new ScalarVector();
            vectorResult = matrix * vector;
            ScalarVector X1 = new ScalarVector();
            ScalarVector X2 = new ScalarVector();
            X1 = RunthroughMethod(matrix, vectorResult);
            X2 = InstabilityMethod(matrix, vectorResult);
            double[] result = new double[2];
            ScalarVector a = new ScalarVector();
            a = vector - X1;
            double rate = Math.Abs(a[0]);

            for (int i = 0; i < vector.Size; i++)
                if (!(Math.Abs(a[i]) <= rate))
                    rate = Math.Abs(a[i]);
            result[0] = rate;
            a = vector - X2;
            rate = Math.Abs(a[0]);
            for (int i = 0; i < vector.Size; i++)
                if (!(Math.Abs(a[i]) <= rate))
                    rate = Math.Abs(a[i]);
            result[1] = rate;
            return result;
        }
        public double[,] CreateMatrix(diapozon d1, diapozon d2, diapozon d3 , int size)
        {
            Random rnd = new Random();
            double[,] result = new double[size, size];
            for(int i = 0; i < size; i++)
                for(int j = 0; j < size; j++)
                    if (i == j)
                        result[i, j] = rnd.Next(d2.min, d2.max);
                    else if(i + 1 == j)
                        result[i, j] = rnd.Next(d1.min, d1.max);
                    else if(i == j + 1)
                        result[i, j] = rnd.Next(d3.min, d3.max);
                    else
                        result[i, j] = 0;
            return result;
        }
        public double[] CreateVector(diapozon d, int size)
        {
            Random rnd = new Random();
            double[] result = new double[size];
            for (int i = 0; i < size; i++)
                result[i] = rnd.Next(d.min, d.max);
            return result;
        }
        public ScalarVector RunthroughMethod(TridiagonalMatrix matrix, ScalarVector vector)
        {
            if (matrix.Size != vector.Size)
                throw new Exception("Размеры матрицы и вектора не совпадают");
            double[] L = new double[matrix.Size - 1];
            double[] M = new double[matrix.Size];
            double b = 1 / matrix[0, 0];
            L[0] = matrix[0, 1] * b;
            M[0] = vector[0] * b;
            int border = 0;
            for (int i = 1; i < matrix.Size - 1; i++)
            {
                L[i] = matrix[i, border + 2] / (matrix[i, border + 1] - matrix[i, border] * L[i - 1]);
                M[i] = (vector[i] - matrix[i, border] * M[i - 1]) / (matrix[i, border + 1] - matrix[i, border] * L[i - 1]);
                border++;
            }
            M[matrix.Size - 1] = (vector[matrix.Size - 1] - matrix[matrix.Size - 1, border] * M[matrix.Size - 2]) / (matrix[matrix.Size - 1, border + 1] - matrix[matrix.Size - 1, border] * L[matrix.Size - 2]);
            double[] X = new double[matrix.Size];
            X[matrix.Size - 1] = M[matrix.Size - 1];
            for (int i = matrix.Size - 2; i >= 0; i--)
                X[i] = M[i] - L[i] * X[i + 1];
            return new ScalarVector().Initialize(X);
        }
        public ScalarVector InstabilityMethod(TridiagonalMatrix matrix, ScalarVector vector)
        {
            double[] Y = new double[matrix.Size];
            double[] Z = new double[matrix.Size];
            Y[0] = 0;
            Y[1] = vector[0] / matrix[0, 1];
            int border = 0;
            for (int i = 1; i < matrix.Size - 1; i++)
            {
                Y[i + 1] = (vector[i] - matrix[i, border] * Y[i - 1] - matrix[i, border + 1] * Y[i]) / matrix[i, border + 2];
                border++;
            }
            Z[0] = 1;
            Z[1] = -(matrix[0, 0] / matrix[0, 1]);
            border = 0;
            for (int i = 1; i < matrix.Size - 1; i++)
            {
                Z[i + 1] = -(matrix[i, border] * Z[i - 1] + matrix[i, border + 1] * Z[i]) / matrix[i, border + 2];
                border++;
            }
            double K = (vector[matrix.Size - 1] - matrix[matrix.Size - 1, matrix.Size - 2] * Y[matrix.Size - 2] - matrix[matrix.Size - 1, matrix.Size - 1] * Y[matrix.Size - 1]) /
                       (matrix[matrix.Size - 1, matrix.Size - 2] * Z[matrix.Size - 2] + matrix[matrix.Size - 1, matrix.Size - 1] * Z[matrix.Size - 1]);

            double[] X = new double[matrix.Size];
            for (int i = 0; i < matrix.Size; i++)
            {
                X[i] = Y[i] + K * Z[i];
            }
            return new ScalarVector().Initialize(X);
        }

        private void FormTable_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Размерность", typeof(int));
            dt.Columns.Add("Прогонка", typeof(double));
            dt.Columns.Add("Неустойчивость", typeof(double));
            for (int i = 0; i < 7; i++)
                dt.Rows.Add(new object[] { });
            double[] row = CreateRow(10);
            dt.Rows[0][0] = 10;
            dt.Rows[0][1] = row[0];
            dt.Rows[0][2] = row[1];

            row = CreateRow(30);
            dt.Rows[1][0] = 30;
            dt.Rows[1][1] = row[0];
            dt.Rows[1][2] = row[1];

            row = CreateRow(100);
            dt.Rows[2][0] = 100;
            dt.Rows[2][1] = row[0];
            dt.Rows[2][2] = row[1];

            row = CreateRow(500);
            dt.Rows[3][0] = 500;
            dt.Rows[3][1] = row[0];
            dt.Rows[3][2] = row[1];

            row = CreateRow(1000);
            dt.Rows[4][0] = 1000;
            dt.Rows[4][1] = row[0];
            dt.Rows[4][2] = row[1];

            row = CreateRow(5000);
            dt.Rows[5][0] = 5000;
            dt.Rows[5][1] = row[0];
            dt.Rows[5][2] = row[1];

            row = CreateRow(10000);
            dt.Rows[6][0] = 10000;
            dt.Rows[6][1] = row[0];
            dt.Rows[6][2] = row[1];



            dataGridView1.DataSource = dt;
        }
    }
}
