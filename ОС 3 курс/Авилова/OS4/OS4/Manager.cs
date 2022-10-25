using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace OS4
{
    public class Manager
    {
        public int max_p; // кол-во процессов

        public int max_r; // кол-во ресурсов

        public int[,] matr; // матрица значений строка-процессы столбец-ресурсы

        public int[,] graph; // граф

        public int[,] allocated_resources; // выделенные ресурсы

        private Random rnd = new Random(); // рандом

        public static Manager Instace;

        //конструктор
        public Manager(int p, int r)
        {
            max_p = p;
            max_r = r;
            matr = new int[max_p, max_r];
            graph = new int[max_p, max_p];
            allocated_resources = new int[max_p, max_r];
            Сreate_allocated_resource();
            Manager.Instace = this;
        }

        //заполнение матрицы значениями
        public void Сreate_Matr(List<int> resurs, int p)
        {
            for (int i = 0; i < max_r; i++)
                if (resurs.Contains(i))
                    matr[p, i] = 1;
                else
                    matr[p, i] = 0;
            main_form.Instance.SafeInvoke(frm => frm.Print_matr());
        }

        //массив занятых ресурсов, все обнуляем
        private void Сreate_allocated_resource()
        {
            for (int i = 0; i < max_p; i++)
                for (int j = 0; j < max_r; j++)
                    allocated_resources[i, j] = 0;
        }

        //добавить значение в граф
        public void Full_graph(int p, int r)
        {
            for (int i = 0; i < max_p; i++)
                if ((i != p) && (matr[i, r] == 1))
                {
                    graph[p, i]++;
                    main_form.Instance.SafeInvoke(frm => frm.Print_graph());
                }
        }

        //откат дуги
        public void Recoil(int p, int r)
        {
            for (int i = 0; i < max_p; i++)
                if ((i != p) && (matr[i, r] == 1) && (graph[p, i] > 0))
                {
                    graph[p, i]--;
                    main_form.Instance.SafeInvoke(frm => frm.Print_graph());
                }
        }

        //свободен ли ресурс
        public bool Is_free(int r)
        {
            for (int i = 0; i < max_p; i++)
                if (allocated_resources[i, r] == 1)
                    return false;
            return true;
        }

        //запускаем процессы
        public void Start()
        {
            for (int i = 0; i < max_p; i++)
            {
                int p = i;
                Process process = new Process(i);
                Thread t = new Thread(delegate() { process.Do(); });
                t.Start();
                Thread.Sleep(500);
            }
        }
    }
}
