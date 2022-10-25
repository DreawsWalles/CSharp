using System;

namespace projectFour
{
    class Program
    {
        static bool CheckNum(string s)
        {
            int size = s.Length;
            int i = 0;
            if (size == 0)
                return false;
            else
                if (s[0] == '-')
            {
                return false;
            }
            else

                while (i < size)
                {
                    if ((s[i] >= '0') && (s[i] <= '9'))
                        i++;
                    else
                        return false;
                }
            return true;
        }
        static void Random(ref int[,] matr, int n)
        {
            var rand = new Random();
            Console.WriteLine("Ваша матрица: ");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matr[i, j] = rand.Next(-100,100);

        }
        static bool CheckData(string s)
        {
            int size = s.Length;
            int i = 0;
            if (size == 0)
                return false;
            else
                if (s[0] == '-')
            {
                i++;
            }
            else

                while (i < size)
                {
                    if ((s[i] >= '0') && (s[i] <= '9'))
                        i++;
                    else
                        return false;
                }
            return true;
        }
        static void printmatr (int [,] matr, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write(matr[i, j] + " ");
                Console.WriteLine();
            }

        }
        static void InputKeyboard(ref int[,] matr, int size)
        {
            Console.WriteLine("Введите матрицу " + size + " * " + size + ": ");
            int count;
            int j;
            string s;
            string[] nums;
            int n = 0;
            for (int i = 0; i < size; i++)
            {
                j = 0;
                Console.Write("Введите {0} строку матрицы: ", i + 1);
                s = Console.ReadLine();
                s.Trim();
                nums = s.Split(' ');
                foreach (string num in nums)
                {
                    if (num != "")
                    {
                        if (CheckData(num))
                            n = Convert.ToInt32(num);
                        else
                        {
                            Console.WriteLine("При считывании {0} строки обнаружен некореектный символ {1}", i + 1, num);
                            break;
                        }
                        matr[i, j] = n;
                        if (j <= size)
                            j++;
                        else
                        {
                            Console.WriteLine("Введено слишком много значений. Максимум значений {0}", size);
                            i--;
                            break;
                        }
                    }
                }
                if (j < size)
                {
                    Console.WriteLine("Введено слишком мало значений. Необходимое значение {0}", size);
                    i--;
                }
            }
        }
        static bool CheckFibonachi(int n)
        {
            if ((Convert.ToInt32(Math.Sqrt((5 * n * n) - 4))) == (Convert.ToDouble(Math.Sqrt((5 * n * n) - 4))))
                return true;
            else
                return false;
        }
        static int[] getFibonachi(int size, int[,] mass, int j, out int size_out)
        {

            int[] mass_out = new int[size];
            int k = 0;
            for (int i=0;i<size;i++)
                if (CheckFibonachi(mass[i,j]))
                {
                    mass_out[k] = mass[i,j];
                    k++;
                }
            size_out = k;
            return mass_out;
        }
        static void Main(string[] args)
        {
            bool ok = true;
            int n=0;
            do
            {
                Console.Write("Введите размер матрицы: ");
                string num;
                num = Console.ReadLine();
                num.Trim();
                if (CheckNum(num))
                {
                    n = Convert.ToInt32(num);
                    if (n == 0)
                    {
                        ok = false;
                        Console.WriteLine("Некорректный размер матрицы");
                        Console.Write("Нажмите Enter для продолжения...");
                        Console.ReadKey();
                    }
                    else
                        ok = true;
                }
                else
                {
                    ok = false;
                    Console.WriteLine("Некорректный размер матрицы");
                    Console.Write("Нажмите Enter для продолжения...");
                    Console.ReadKey();
                }
                Console.Clear();
            } while (!ok);
            int[,] matr = new int[n, n];
            int choise = 0;
            do
            {
                Console.WriteLine("1.Задать матрицу рандомно");
                Console.WriteLine("2.Ввести матрицу с клавиатуры");
                Console.Write("Введите: ");
                string s = Console.ReadLine();
                s.Trim();
                if (CheckNum(s))
                {
                    choise = Convert.ToInt32(s);
                    if ((choise < 1) || (choise > 2))
                    {
                        ok = false;
                        Console.WriteLine("Некоррекное число");
                        Console.Write("Нажмите Enter для продолжения...");
                        Console.ReadKey();
                    }
                    else
                        ok = true;
                }
                else
                {
                    ok = false;
                    Console.WriteLine("Некорректные данные");
                    Console.Write("Нажмите Enter для продолжения...");
                    Console.ReadKey();
                }
                Console.Clear();
            } while (!ok);
            switch (choise)
            {
                case 1:
                    Random(ref matr, n);
                    break;
                case 2:
                    InputKeyboard(ref matr, n);
                    break;
            }
            Console.WriteLine("Нажмите Enter для продолжения...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Ваша матрица: ");
            printmatr(matr, n);
            Console.WriteLine();
            Console.WriteLine("В данной матрице числа Фибоначи в ");
            int size;
            int[] mass = new int[n];
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0} столбце:",j+1);
                mass = getFibonachi(n, matr, j, out size);
                if (size == 0)
                    Console.Write("не найдено");
                else
                    for (int i = 0; i < size; i++)
                        Console.Write(" " + mass[i]);
                Console.WriteLine();
            }
        }
    }
}
