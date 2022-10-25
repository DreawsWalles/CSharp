using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
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
            if (FilmStudio.CompareTo(film.FilmStudio) == 0)
                return Director.CompareTo(film.Director);
            return FilmStudio.CompareTo(film.FilmStudio);
        }
    }
}
