using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace project
{
    [Serializable]
    public class Film : IComparable
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string FilmStudio { get; set; }
        public string Director { get; set; }
        public int Duration { get; set; }
        public string[] Prizes { get; set; }
        public string[] MainHeroes { get; set; }

        public Film()
        {
            Name = "-";
            Date = DateTime.Parse("2020.01.01");
            FilmStudio = "-";
            Director = "-";
            Duration = 0;
        }
        public Film (string[] information)
        {
            Name = information[0];
            Date = DateTime.Parse(information[1]);
            FilmStudio = information[2];
            Director = information[3];
            Duration = Convert.ToInt32(information[4]);
            Prizes = information[5].Split(',');
            Prizes = Prizes.Where(x => x != "").ToArray();
            MainHeroes = information[6].Split(',');
            MainHeroes = MainHeroes.Where(x => x != "").ToArray();            
        }
        public override string ToString()
        {
            string result;
            result = "Кинокомпания: " + FilmStudio + " Фильм: " + Name + " Режиссер: " + Director + " Длительность: " + Duration + Environment.NewLine + "Дата выхода: " + Date.ToString() + Environment.NewLine;
            result += "Главные герои: ";
            foreach (string elem in MainHeroes)
                result += elem + ";";
            result += Environment.NewLine;
            result += "Призы: ";
            foreach (string elem in Prizes)
                result += elem + ";";
            return result;
        }
        public int CompareTo(object obj)
        {
            Film film = (Film)(obj);
            return Duration.CompareTo(film.Duration);
        }

        //Запись объекта в файл
        public void Write(FileStream fileStream)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, this);
        }

        //Чтение объекта из файла
        public Film Read(FileStream fileStream)
        {
            if (fileStream.Position == fileStream.Length)
            {
                return null;
            }

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Film toLoad = (Film)binaryFormatter.Deserialize(fileStream);
            Name = toLoad.Name;
            Date = toLoad.Date;
            FilmStudio = toLoad.FilmStudio;
            Director = toLoad.Director;
            Duration = toLoad.Duration;
            Prizes = toLoad.Prizes;
            MainHeroes = toLoad.MainHeroes;
            return this;
        }
    }
}
