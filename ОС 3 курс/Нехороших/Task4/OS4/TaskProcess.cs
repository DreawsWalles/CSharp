using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Task4
{
    public class TaskProcess
    {
        //список ресурсов для процесса
        public List<int> resourses;
        //номер процесса
        public int number;

        public TaskProcess(int _p, int ResCount)
        {
                resourses = new List<int>();
                number = _p;
                СreateProcess(ResCount);
          
        }

        //список ресурсов для процесса, мр - макс. кол-во ресурсов
        public void СreateProcess(int countr)
        {
            Thread.Sleep(20);
            Random rnd = new Random();
            for (int i = 0; i < countr; i++)
            {
                if (rnd.Next(0, 1000) % 3 != 1)
                    resourses.Add(i);
            }
        }

        //по логике должен уметь только работать с процессом
        public string WorkWithRes()
        {
            return "Процесс " + number + " начал работу с ресурсом.";
        }

        //рандомно берем ресурс
        public int GetResource()
        {
            Thread.Sleep(20);
            Random rnd = new Random();
            if (resourses.Count == 0)
                return -1;
            else
                return rnd.Next(0, resourses.Count);
        }

    }
}
