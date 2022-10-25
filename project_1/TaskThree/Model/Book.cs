using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskThree
{
    public abstract class Book : IPublication
    {
        public string NamePublication { get; set; }

        public int CountOfNode 
        { 
            get 
            { 
                return Content.Count; 
            } 
            set { } 
        }
        public List<string> Content { get; set; } 

        public Book()
        {
            Content = new List<string>();
        }

        public string this[int index]
        {
            get
            {
                if(index < 0 || index >= Content.Count)
                    throw new ArgumentOutOfRangeException("index");
                return Content[index];
            }
            set
            {
                if (index < 0 || index >= Content.Count)
                    throw new ArgumentOutOfRangeException("index");
                Content[index] = value;
            }
        }
        public Book(string namePublication, List<string> content)
        {
            NamePublication = namePublication;
            Content = content;
        }


        string IPublication.ToString() => $"{NamePublication}\tКол-во записей:{CountOfNode}";

        public List<string> GetContent()
        {
            return Content;
        }

        public abstract Type GetType();
    }
}
