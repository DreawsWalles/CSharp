using System;
using System.Threading;

namespace program_1
{
    class Reader
    {
        private const int time = 50 * ProgramData.speed;    // Минимальный период времени между чтением данных из буфера

        private Print massege;      // Делегат для вывода
        private string name;        // Имя чиитателя
        private int retries;        // Число удалений данных этим читателем

        private DataStack st;


        public Reader(DataStack stack, string name, Print massege, int readings)
        {
            this.retries = readings;
            this.st = stack;
            this.name = name;
            this.massege = massege;
            this.massege("Новый читатель " + this.name + ", должен совершить удалений: " + this.retries.ToString() + Environment.NewLine);
        }

        public void DeletedData()
        {

            Random rand = new Random();
            Thread.Sleep(rand.Next(time, 4 * time));

            int? x = null;

            while ((x == null) || (retries > 0))
            {
                x = st.Pop();
                retries--;
                if (x != null)
                    massege("Читатель " + name + " удаляет данные: " + x.ToString() + ", осталось удалений: " + retries.ToString() + Environment.NewLine);
                else
                    massege("Для читателя " + name + " нет данных" + Environment.NewLine);
                Thread.Sleep(time * 2);
            }    
        }
    }
}
