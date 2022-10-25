using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Реализовать консольное приложение для решения следующей задачи. Вычислить значение функции, заданной с помощью ряда Тейлора, на интервале от Х0 до Xn с шагом h с заданной точностью e. 
Результат вывести в виде таблице*/

namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, sum, n, xn, xk, dx, eps, i, sum1;
            bool ok = false;
            do
            {
                Console.WriteLine("Введите границы отрезка в интервале от -1 до 1");
                do
                {
                    Console.Write("Введите первую границу: ");
                    xn = Convert.ToDouble(Console.ReadLine());
                    if ((xn < -1) && (xn > 1))
                        Console.WriteLine("Введено число, не входящие в значение интервала");
                } while ((xn < -1) && (xn > 1));
                do
                {
                    Console.Write("Введите вторую границу: ");
                    xk = Convert.ToDouble(Console.ReadLine());
                    if ((xk < -1) && (xk > 1))
                        Console.WriteLine("Введено число, не входящие в значение интервала");
                } while ((xk < -1) && (xk > 1));
                if (xn >= xk)
                {
                    Console.WriteLine("Введены некорректные границы");
                    Console.WriteLine("Повторите ввод");
                    Console.Clear();
                }
                else
                    ok = true;
            } while (ok == false);
            do
            {
                Console.Write("Введите шаг dx: ");
                dx = Convert.ToDouble(Console.ReadLine());
                if (((xn + dx) > xk) || (dx <= 0))
                {
                    Console.WriteLine("Введен некорректный шаг dx");
                    Console.Clear();
                }
            } while ((xn + dx) > xk);
            do
            {
                Console.Write("Введите значение E: ");
                eps = Convert.ToDouble(Console.ReadLine());
                if (eps <= 0)
                {
                    Console.WriteLine("Введено некорректное значение");
                }
            } while (eps <= 0);
            Console.Clear();
            Console.WriteLine("Левая граница отрезка: {0} \nПравая граница отрезка: {1} \nШаг dx: {2} \nЗначение E: {3} \n", xn, xk, dx, eps);

            Console.WriteLine("|==================|\n" +
                              "|                  |\n" +
                              "|        x         |\n" +
                              "|                  |\n" +
                              "|==================|");
            Console.WriteLine("|                  |\n" +
                              "| f(x) вычисленная |\n" +
                              "|                  |\n" +
                              "|==================|");
            Console.WriteLine("|                  |\n" +
                              "| f(x) по формуле  |\n" +
                              "|                  |\n" +
                              "|==================| ");
            x = xn;
            int Y = 5;
            int X = 20;
            int maxX = Console.BufferWidth;
            do
            {
                double x1 = x;
                sum = 1;
                n = 1;
                i = 1;
                sum1 = 1 / Math.Sqrt(1 + x);
                while (Math.Abs(sum - sum1) > eps)
                {
                    n *= -(((2 * i) - 1) / (2 * i));
                    sum += n * x1;
                    x1 = x1 * x;
                    i++;
                }
                Console.SetCursorPosition(X, Y);
                Console.WriteLine("==========|");
                Console.SetCursorPosition(X, Y + 1);
                Console.WriteLine("          |");
                Console.SetCursorPosition(X, Y + 2);
                Console.WriteLine("   {0:N1}", x);
                Console.SetCursorPosition(10 + X, Y + 2);
                Console.WriteLine("|\n");
                Console.SetCursorPosition(X, Y + 3);
                Console.WriteLine("          |");
                Console.SetCursorPosition(X, Y + 4);
                Console.WriteLine("==========|");

                Console.SetCursorPosition(X, Y + 5);
                Console.WriteLine("          |");
                Console.SetCursorPosition(X, Y + 6);
                Console.WriteLine(" {0:N6}", sum);
                Console.SetCursorPosition(10 + X, Y + 6);
                Console.WriteLine("|");
                Console.SetCursorPosition(X, Y + 7);
                Console.WriteLine("          |");
                Console.SetCursorPosition(X, Y + 8);
                Console.WriteLine("==========|");

                Console.SetCursorPosition(X, Y + 9);
                Console.WriteLine("          |");
                Console.SetCursorPosition(X, Y + 10);
                Console.WriteLine(" {0:N6}", sum1);
                Console.SetCursorPosition(10 + X, Y + 10);
                Console.WriteLine("|");
                Console.SetCursorPosition(X, Y + 11);
                Console.WriteLine("          |");
                Console.SetCursorPosition(X, Y + 12);
                Console.WriteLine("==========|");
                x += dx;
                X += 11;
                if (X + 11 >= maxX)
                {
                    Y += 14;
                    X = 20;
                    Console.SetCursorPosition(0, Y);
                    Console.WriteLine("|==================|\n" +
                                      "|                  |\n" +
                                      "|        x         |\n" +
                                      "|                  |\n" +
                                      "|==================|");
                    Console.WriteLine("|                  |\n" +
                                      "| f(x) вычисленная |\n" +
                                      "|                  |\n" +
                                      "|==================|");
                    Console.WriteLine("|                  |\n" +
                                      "| f(x) по формуле  |\n" +
                                      "|                  |\n" +
                                      "|==================| ");
                    Console.SetCursorPosition(X, Y);
                }
            } while (x <= xk);

            Console.ReadKey();
        }
    }
}
