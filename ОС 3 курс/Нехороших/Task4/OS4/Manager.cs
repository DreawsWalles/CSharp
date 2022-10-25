using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Task4
{
    public class Manager
    {
        public int CountProcess; // кол-во процессов
        public int CountResourses; // кол-во ресурсов

        //данные о процессах и нужных им ресурсах.
        //строка - процессы, столбцы - ресурсы
        public int[,] DataAboutProcess;
        // граф
        public int[,] Graph;
        public TaskProcess[] ListProcesses;

        //чтобы можно было управлять остановками потоков
        public Thread[] ListThread;

        // выделенные ресурсы
        public bool[,] UsedResourses;


        //для связи с формой
        public delegate void Change();
        public event Change ChangeGraph;

        public delegate void ShowInfo(string a);
        public event ShowInfo ShowAboutWork;

        //конструктор
        public Manager(int p, int r)
        {
            CountProcess = p;
            CountResourses = r;

            //массив процессов
            ListProcesses = new TaskProcess [CountProcess];
            InitProcesses();

            DataAboutProcess = new int[CountProcess, CountResourses];
            InitDataAboutProcess();

            ListThread = new Thread[CountProcess];
            Graph = new int[CountProcess, CountProcess];

            UsedResourses = new bool[CountProcess, CountResourses]; //CountProcess, 
            InitUsedResource();
        }
        #region Вспомогательные

        //заполнение матрицы значениями
        public void InitDataAboutProcess()
        {
            for (int i = 0; i < CountProcess; i++)
                for (int j = 0; j < CountResourses; j++ )
                    if (ListProcesses[i].resourses.Contains(j))
                        DataAboutProcess[i, j] = 1;
                    else
                        DataAboutProcess[i,j] = 0; 
        }

        public void InitProcesses()
        {
            for (int i = 0; i < CountProcess; i++)
                ListProcesses[i] = new TaskProcess(i, CountResourses);

        }

        //Инфа про владельцев ресурсов
        private void InitUsedResource()
        {
            for (int i = 0; i < CountProcess; i++)
                for (int j = 0; j < CountResourses; j++)
                    UsedResourses[i, j] = false;
        }
        #endregion

        #region Работа с графом
        //добавить дуги в граф
        public void AddArcsInGraph(int p, int r)
        {
            for (int i = 0; i < CountProcess; i++)
                if ((i != p) && (DataAboutProcess[i, r] == 1))
                    //проводим дугу
                    Graph[p, i]++;

            ChangeGraph();
        }

        //откат состояния вершины, п - вершина, р - ресурс
        public void Recoil(int p, int r)
        {
            for (int i = 0; i < CountProcess; i++)
                if ((i != p) && (DataAboutProcess[i, r] == 1) && (Graph[p, i] > 0))
                     Graph[p, i]--;

            ChangeGraph();
        }

        //есть ли цикл в графе
        public bool IsCycle(int p)
        {
            bool cycle = false;
            HashSet<int> s = new HashSet<int>();//множество посещенных вершин
            s.Add(p);
            Check(p, ref cycle, ref s);
            return cycle;
        }

        //рекурсия для проверки цикла
        public void Check(int k, ref bool cycle, ref HashSet<int> s)
        {
            int i = 0;
            //пока не цикл и не прошли по всем процессам
            while ((!cycle) && (i < CountProcess))
            {
                if (Graph[k, i] > 0)
                {
                    if (s.Contains(i))
                        cycle = true;
                    else
                    {
                        s.Add(i);
                        Check(i, ref cycle, ref s);
                        if (!cycle)
                            s.Remove(i);
                    }
                }
                i++;
            }
        }

        #endregion

        public void StartProcess(object t)
        {
            while(true)
            {
                Thread.Sleep(500);
                ProcessControl(t);
            }
        }

        private void ProcessControl(object o)
        {
            int i = (int)o;
            int pointer = ListProcesses[i].GetResource();

            //получили ресурс
            int r = ListProcesses[i].resourses[pointer];
            ShowAboutWork("Процесс " + i + " запросил ресурс " + r + Environment.NewLine);

            //если он свободен
            if (IsFree(r))
            {
                lock (this)
                {
                    //меняем граф
                    AddArcsInGraph(ListProcesses[i].number, r);
                    //проверяем на цикл
                    if (IsCycle(ListProcesses[i].number)) 
                    {

                        ShowAboutWork( " ->Ресурс свободен, цикл есть - ресурс не выделен.Процесс блокируется. Откат"+ Environment.NewLine);
                        //шаг назад
                        Recoil(ListProcesses[i].number, r);
                        Thread.Sleep(3000);

                    }

                    else
                    {
                        UsedResourses[ListProcesses[i].number, r] = true; 
                        ShowAboutWork("->Ресурс свободен, цикла нет - ресурс выделен!"+Environment.NewLine);
                        ShowAboutWork(ListProcesses[i].WorkWithRes() + Environment.NewLine);
                        // work = true;
                        Thread.Sleep(3000);
                        FreeResurs(ListProcesses[i].number, r);
                        ShowAboutWork("-> Ресурс " + r + " cвободен! " + Environment.NewLine);
                    }

                }
            }
            //если занято
            else
            {
               ShowAboutWork("Процесс " + i.ToString() + " не выполняется. Ресурс " + r.ToString() + " занят."+Environment.NewLine);
                Thread.Sleep(3000);                                
            }

        }
            
        //свободен ли ресурс
        public bool IsFree(int r)
        {
            for (int i = 0; i < CountProcess; i++)
                if (UsedResourses[i, r])
                    return false;
            return true;
        }

        //освободить ресурс
        public void FreeResurs(int number, int r)
        {

            if (UsedResourses[number, r])
            {
                //откат                
                Recoil(number, r);
                UsedResourses[number, r] = false;
            }
        }

        //запускаем процессы
        public void Start()
        {
            for (int i = 0; i < CountProcess; i++)
            {
                ListThread[i] = new Thread(new ParameterizedThreadStart(StartProcess));
                ListThread[i].Start(i);
                Thread.Sleep(500);
            }
        }

        public void Stop()
        {
            for (int i = 0; i < CountProcess; i++)
                ListThread[i].Abort();
        }
    }
}
