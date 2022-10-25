using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace project
{
    [Serializable]
    public struct Exam
    {
        public string _nameOfexam;
        public int _mark;
    }
    [Serializable]
    public class Sessia
    {
        public Exam [] _exams { get; set; }
        public Sessia()
        {
            _exams = new Exam[5];
            _exams[0]._nameOfexam = "Математический_анализ";
            _exams[1]._nameOfexam = "Теория_вероятности";
            _exams[2]._nameOfexam = "С++";
            _exams[3]._nameOfexam = "C#";
            _exams[4]._nameOfexam = "Алгоритмы_и_структуры_данных";
        }
    }

    [Serializable]
    public class Student
    {
        public string _FIO { get; set; }
        public int _Course { get; set; }
        public int _Group { get; set; }
        public bool _budget { get; set; }
        public Sessia[] _sessions { get; set; }
        public string[] ToText()
        {
            int size = 5+ _Course * 12;
            string[] result = new string[size];
            result[0] = "ФИО: " + _FIO;
            result[1] = "Курс: " + _Course.ToString();
            result[2] = "Номер Группы: " + _Group.ToString();
            result[3] = "Форма обучения: " + (_budget ? "Бюджет" : "Договор");
            int pos = 5;
            for (int i = 0; i < _Course * 2; ++i)
            {
                result[pos] = "Сессия №" + (i + 1).ToString() + ":";
                ++pos;
                for (int j = 0; j < 5; ++j)
                {
                    result[pos] = _sessions[i]._exams[j]._nameOfexam + " " + _sessions[i]._exams[j]._mark.ToString();
                    ++pos;
                }
            }
            return result;
        }
        //достаем нужную часть из строки: count - сколько, one - начиная с какого слова
        static public string GetData(string str, int count, int one = 1)
        {
            string res = "";
            char[] splitchar = { ' ' };
            string[] strArr;
            strArr = str.Split(splitchar);
            for (int i = one; i < count; ++i)
                res = res + strArr[i] + " ";
            res = res.Trim();
            return res;
        }

        //из массива строк в объект
        static public Student TextToStudent(StreamReader file)
        {
            string mas = file.ReadLine();
            int size = mas.Length;      //кол-во строк
            Student res = new Student();
            //Достаем значение ФИО
            res._FIO = GetData(mas, 4);
            //Достаем значение Номер курса
            mas = file.ReadLine();
            res._Course = Int32.Parse(GetData(mas, 2, 1));
            //Достаем номер группы
            mas = file.ReadLine();
            res._Group = Int32.Parse(GetData(mas, 3, 2));
            //Достаем форму обучения
            mas = file.ReadLine();
            res._budget = (GetData(mas, 3, 2) == "Бюджет");

            //mas[4]-Успеваемость:
            //каждая 6-я строка номер сессии
            file.ReadLine();
            file.ReadLine(); 
            int CountSession = res._Course * 2;
            res._sessions = new Sessia[CountSession];
            for (int i = 0; i < CountSession; ++i)
            {
                res._sessions[i] = new Sessia();
            }

            for (int i = 0; i < CountSession; ++i)//записываем каждую сессию
            {
                for (int j = 0; j < 5; ++j)
                {
                    mas = file.ReadLine();
                    res._sessions[i]._exams[j]._nameOfexam = GetData(mas, 1, 0);
                    res._sessions[i]._exams[j]._mark = Int32.Parse(GetData(mas, 2, 1));
                }
                file.ReadLine();
            }
            return res;
        }
        public double task(int i)
        {
            double result = 0;
            for (int j = 0; j < 5; j++)
                result += _sessions[i-2]._exams[j]._mark;
            for (int j = 0; j < 5; j++)
                result += _sessions[i-1]._exams[j]._mark;
            return result/5;
        }
    }
}
