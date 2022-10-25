using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace project
{
    static public class Sort
    {
        static private int count_swap = 0;
        static private int count_exchange = 0;
        static void Swap(ref int a, ref int b)
        {
            var t = a;
            a = b;
            b = t;
        }

        public static int[] ShellSort_bigValues(int[] array, ref Chart chart)
        {
            count_exchange = 0;
            count_swap = 0;
            int step = (array.Length + 2) / 3;
            while (step > 0)
            {
                for (int i = step; i < array.Length; i++)
                    for (int j = i - step; j >= 0; j -= step)
                    {
                        count_exchange++;
                        if (array[j] > array[j + step])
                        {
                            count_swap++;
                            Swap(ref array[j], ref array[j + step]);
                        }
                    }
                if (step != 1 && step <= 3)
                    step = 1;
                else
                    step = (step - 1) / 3;
            }
            Animation.getChart(ref chart, array.Length, count_swap, true);
            Animation.getChart(ref chart, array.Length, count_exchange, false);
            return array;
        }
        public static int[] ShellSort_SmallValues(int[] array, ref Panel panel)
        {
            count_exchange = 0;
            count_swap = 0;
            int step = (array.Length + 2) / 3;
            while (step > 0)
            {
                for (int i = step; i < array.Length; i++)
                    for (int j = i - step; j >= 0; j -= step)
                        if (array[j] > array[j + step])
                        {
                            Swap(ref array[j], ref array[j + step]);
                            Animation.Swap(j, j + step, ref panel);
                        }
                if (step != 1 && step <= 3)
                    step = 1;
                else
                    step = (step - 1) / 3;
            }
            return array;
        }
    }
}
