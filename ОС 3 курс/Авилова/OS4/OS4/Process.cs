using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace OS4
{
    public class Process
    {
        public List<int> resurs;
        public int number;
        public int pointer;
        public static Mutex mutex; // Мьютекс 
        private Random rnd = new Random(DateTime.Now.Millisecond); // рандом

        public Process(int _p)
        {
                resurs = new List<int>();
                number = _p;
                pointer = -1;
                mutex = new Mutex();
                Сreate_process(Manager.Instace.max_r);
                Manager.Instace.Сreate_Matr(resurs, number);
          
        }

        //рандомно создаем потребность в ресурсах
        public void Сreate_process(int max_r)
        {
            for (int j = 0; j < max_r; j++)
            {
                int desicion = rnd.Next() % 2;
                if (desicion == 1)
                    resurs.Add(j);
            }
        }

        //рандомно берем ресурс
        public int Next_pointer()
        {
            if (resurs.Count == 0)
                return -1;
            else
                return rnd.Next(0, resurs.Count);
        }

        //функция проверяет наличие циклов в графе (backtracking) p-стартовая вершина
        public bool IsCycle(int p)
        {
            bool cycle = false;//сообщает,что цикл есть
            HashSet<int> s = new HashSet<int>();//множество посещенных вершин
            s.Add(p);
            Check(p, ref cycle, ref s);
            return cycle;
        }

        //есть ли цикл
        public void Check(int k, ref bool cycle, ref HashSet<int> s)
        {
            int i = 0;
            while ((!cycle) && (i < Manager.Instace.max_p))
            {
                if (Manager.Instace.graph[k, i] > 0)
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

        public void Do()
        {
            while ((resurs.Count > 0) && (true))
            {
                Do_something();
                Thread.Sleep(500);
            }
        }

        public void FreeResurs(int r)
        {
           
             //   if (((rnd.Next() % 2) == 1) && (Manager.Instace.allocated_resources[number, r] == 1))
            if (Manager.Instace.allocated_resources[number, r] == 1)
                {
                    Manager.Instace.Recoil(number, r);//откат
//                    main_form.Instance.SafeInvoke(frm => frm.Print_color_not(number, r));
                    Manager.Instace.allocated_resources[number, r] = 0;       
                }
        }

        private void Do_something()
        {

            int pointer = Next_pointer();
            int r = resurs[pointer];
            string str = "";

            if (Manager.Instace.Is_free(r))
            {
                lock (this)
                {
                    Manager.Instace.Full_graph(number, r);

                    if (IsCycle(number))  //если цикл есть
                    {

                        str = " ->Ресурс свободен,цикл есть - ресурс не выделен.Процесс блокируется. Откат";
                        main_form.Instance.SafeInvoke(frm => frm.Log("Процесс " + number.ToString() + " запросил ресурс " + r.ToString()));//обновляем 'действия' на форме
                        main_form.Instance.SafeInvoke(frm => frm.Log(str));//обновляем 'действия' на форме
                        Manager.Instace.Recoil(number, r);//откат
 //                       main_form.Instance.SafeInvoke(frm => frm.Print_color_not(number, r));
                        Thread.Sleep(3000);

                    }

                    else//если циклов нет
                    {
                        Manager.Instace.allocated_resources[number, r] = 1;
                        str = "->Ресурс свободен,цикла нет - ресурс выделен;";
                        main_form.Instance.SafeInvoke(frm => frm.Log("Процесс " + number.ToString() + " запросил ресурс " + r.ToString()));//обновляем 'действия' на форме
                        main_form.Instance.SafeInvoke(frm => frm.Log(str));
//                        main_form.Instance.SafeInvoke(frm => frm.Print_color(number, r));
                        Thread.Sleep(3000);

                    }

                }
            }

            else if (Manager.Instace.allocated_resources[number, r] == 0)
            {
                    main_form.Instance.SafeInvoke(frm => frm.Log("Процесс " + number.ToString() + "не выделяется" + r.ToString() + "он занят"));
//                    main_form.Instance.SafeInvoke(frm => frm.Print_color_not(number, r));
                
            }
            else
                FreeResurs(r);
        }
    }
}
