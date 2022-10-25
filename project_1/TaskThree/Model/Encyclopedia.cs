using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskThree
{
    public class Encyclopedia : Book
    {
        private Dictionary<string, string> values = new Dictionary<string, string>();
        public Encyclopedia() : base()
        {

        }
        public void Add(string content, string valueDictionary)
        {
            if (values.ContainsKey(content))
                throw new Exception("Переданное значение уже добавлено в словарь");
            values.Add(content, valueDictionary);
            Content.Insert(0, content);
            
        }

        public void Edit(int index, string newNode, string newValueDictionary)
        {
            if(index < 0 || index >= Content.Count)
                throw new ArgumentOutOfRangeException("index");
            Content.RemoveAt(index);
            Content.Insert(0, newNode);
            string tmp = values[Content[0]];
            values.Remove(Content[0]);
            values.Add(newNode, tmp);
        }

        public List<string> GetNamesPublications()
        {
            List<string> resutlt = new List<string>();
            foreach (string content in Content)
                resutlt.Add(content);
            return resutlt;
        }

        public override Type GetType() => typeof(Encyclopedia);

        public string GetValue(int index)
        {
            return values[Content[index]];
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= Content.Count)
                throw new ArgumentOutOfRangeException("index");
            values.Remove(Content[index]);
            Content.RemoveAt(index);
        }
    }
}
