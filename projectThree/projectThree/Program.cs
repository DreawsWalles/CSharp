using System;
using System.ComponentModel.DataAnnotations;

namespace projectThree
{
    class Program
    {
        static void Main(string[] args)
        {
            int count;
            Console.Write("Введите количество прямых:");
            count = Convert.ToInt32(Console.ReadLine());
            int[,] a = new int[count, 3];
            Console.WriteLine("Введите коэффициенты прямых");
            for (int l = 0; l < count; l++)
            {
                Console.WriteLine("Ввода для прямой {0}", l+1);
                do
                {
                    Console.WriteLine("Коэффициент A: ");
                    a[l, 0] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Коэффициент B: ");
                    a[l, 1] = Convert.ToInt32(Console.ReadLine());
                    if ((a[l, 0] == 0) && (a[l, 1] == 0))
                        Console.WriteLine("Коэффициенты A и B должны быть отличны от нуля");
                } while ((a[l, 0] == 0) && (a[l, 1] == 0));
                Console.WriteLine("Коэффициент C:");
                a[l, 2] = Convert.ToInt32(Console.ReadLine());
            }
            bool ok = false;
            int i = 0;
            int j;
            int k;
            //данные для проверки y=2x+1, y=3x, y=-2x+5
            while (!ok && (i < count - 2))
            {
                j = i + 1;
                while (!ok && (j < count - 1))
                {
                    k = j + 1;
                    while (!ok && (k < count))
                    {
                        //вычисляем общий определитель
                        if ((a[i, 0] * a[j, 1] * a[k, 2] + a[i, 1] * a[j, 2] * a[k, 0] + a[i, 2] * a[j, 0] * a[k, 1] - a[i, 2] * a[j, 1] * a[k, 0] - a[i, 0] * a[j, 2] * a[k, 1] - a[k, 2] * a[i, 1] * a[j, 0]) == 0)
                            //вычисляем миноры
                            if ((a[j, 0] * a[k, 1] - a[k, 0] * a[j, 1]) != 0)
                                if ((a[k, 0] * a[i, 1] * a[i, 0] * a[k, 1]) != 0)
                                    if ((a[i, 0] * a[j, 1] - a[i, 1] * a[j, 0]) != 0)
                                        ok = true;
                        k++;
                    }
                    j++;
                }
                i++;    
            }
            if (ok)
                Console.WriteLine("Прямые пересекаются");
            else
                Console.WriteLine("Прямые не пересекаются");
        }
    }
}
