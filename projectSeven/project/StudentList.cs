using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace project
{
    [Serializable]
    [XmlRoot("Student")]
    class StudentList
    {
        [XmlArray("StudentList"), XmlArrayItem(typeof(Student), ElementName = "Student")]

        public List<Student> list //список студентов
        { get; set; }

        //конструктор класса
        public StudentList()
        {
            list = new List<Student>();
        }

        //добавление студента в список
        public void Add(Student student)
        {
            list.Add(student);
            //return list.Count - 1;
        }

        //класс студента, имеющего задолжность
        public void SaveBin(string fileName)
        {
            BinaryFormatter bf = new BinaryFormatter();
            Stream writer = new FileStream(fileName, FileMode.Create);
            bf.Serialize(writer, list);
            writer.Close();
        }

        //загрузить из бинарного файла
        public void LoadBin(string fileName)
        {
            BinaryFormatter bf = new BinaryFormatter();
            Stream reader = new FileStream(fileName, FileMode.Open);
            list = (List<Student>)bf.Deserialize(reader);
        }

        //XML Сериализация
        public void SaveXML(string fileName)
        {
            // передаем в конструктор тип класса
            XmlSerializer writer = new XmlSerializer(typeof(StudentList));
            // получаем поток, куда будем записывать сериализованный объект
            FileStream sw = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
            StreamWriter file = new StreamWriter(sw);
            writer.Serialize(file, this);
            file.Close();
        }

        //XML десериализация
        public void LoadXML(string fileName)
        {
            XmlSerializer xf = new XmlSerializer(typeof(StudentList));
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            StudentList tmb = (StudentList)xf.Deserialize(fs);
            list = tmb.list;
        }


        //сохранить как текстовый
        public void Savetxt(string fileName)
        {
            StreamWriter stWr = new StreamWriter(fileName, false, Encoding.Default);
            foreach (Student x in list)
            {
                string[] txt = x.ToText();
                foreach (string s in txt)
                    stWr.WriteLine(s);
                stWr.WriteLine();
            }
            stWr.Close();
        }

        //загрузить из текстового
        public void Loadtxt(string fileName)
        {
            list = new List<Student>();
            StreamReader stR = new StreamReader(fileName, Encoding.Default);

            while (!stR.EndOfStream)
            {
                list.Add(Student.TextToStudent(stR));
            }
            stR.Close();
        }

        class max_ball 
        {
            int group { get; set; }
            double ball { get; set; }
        }

        public int Task(int course)
        {
            double[,] mass = new double[2, list.Count];
                for (int j = 0; j < list.Count; j++)
                {
                    mass[0, j] = -1;
                    mass[1, j] = 0;

                }
            bool ok;
            int count=0;
            foreach(Student x in list)
            {
                count = 0;
                if (x._Course == course)
                {
                    ok = true;
                    while (ok)
                        if ((mass[0, count] == -1) || (mass[0, count] == x._Group))
                            ok = false;
                        else
                            count++;
                    mass[0, count] = x._Group;
                    mass[1, count] += x.task(course*2);
                }
            }
            double max = 0;
            for(int i = 0;i < list.Count; i++)
            {
                if (mass[1, i] > max)
                {
                    max = mass[1, i];
                    count = (int)mass[0,i];
                }
            }
            return count;                
        }
    }
}
