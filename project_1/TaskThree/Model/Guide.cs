using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskThree
{
    public class Guide : Book
    {
        public Dictionary<string, List<string>> ValueFirstLevel = new Dictionary<string, List<string>>();
        public Dictionary<string, string> ValueSecondLevel = new Dictionary<string, string>();

        public Guide(string[] alphabet) : base()
        {
            foreach (string s in alphabet)
            {
                Content.Add(s);
                ValueFirstLevel.Add(s, new List<string>());
            }
        }
        public void AddAlphabet(string node)
        {
            if (ValueFirstLevel.ContainsKey(node))
                throw new Exception("Переданное значение уже добавлено в словарь");
            ValueFirstLevel.Add(node, new List<string>());
            Content.Add(node);
        }

        public void EditAplhabet(string oldNode, string newNode)
        {
            if (!ValueFirstLevel.ContainsKey(oldNode))
                throw new Exception("Данного ключа не найдено");
            List<string> tmp = ValueFirstLevel[oldNode];
            ValueFirstLevel.Remove(oldNode);
            ValueFirstLevel.Add(newNode, tmp);
            int i = 0;
            while (i < Content.Count && Content[i] != oldNode)
                i++;
            Content.Remove(oldNode);
            Content.Insert(i,newNode);
        }

        public void ClearAlphabet(string node)
        {
            if (!ValueFirstLevel.ContainsKey(node))
                throw new Exception("Данного ключа не найдено");
            foreach(string s in ValueFirstLevel[node])
                ValueSecondLevel.Remove(node);
            ValueFirstLevel[node].Clear();
        }

        public void RemoveAlphabet(string node)
        {
            if (!ValueFirstLevel.ContainsKey(node))
                throw new Exception("Данного ключа не найдено");
            foreach (string s in ValueFirstLevel[node])
                ValueSecondLevel.Remove(node);
            ValueFirstLevel.Remove(node);
            Content.Remove(node);
        }

        public void AddFirstlevel(string key, string value)
        {
            if (!ValueFirstLevel.ContainsKey(key))
                throw new Exception("Данного ключа не найдено");
            if (ValueSecondLevel.ContainsKey(value))
                throw new Exception("Переданное значение уже добавлено в словарь");
            ValueFirstLevel[key].Add(value);
            ValueSecondLevel.Add(value, null);
        }

        public void EditFirstlevel(string oldNode, string newNode)
        {
            if (!ValueSecondLevel.ContainsKey(oldNode))
                throw new Exception("Данного ключа не найдено");
            string tmp = ValueSecondLevel[oldNode];
            ValueSecondLevel.Remove(oldNode);
            string str = "";
            ValueSecondLevel.Add(newNode, tmp);
            foreach(string s in ValueFirstLevel.Keys)
                if(ValueFirstLevel[s].Contains(oldNode))
                {
                    str = s;
                    break;
                }
            List<string> newList = new List<string>();
            foreach (string s in ValueFirstLevel[str])
                if (s == oldNode)
                    newList.Add(newNode);
                else
                    newList.Add(s);
            ValueFirstLevel[str] = newList;
        }
        public void AddSecondlevel(string key, string value)
        {
            if (!ValueSecondLevel.ContainsKey(key))
                throw new Exception("Данного ключа не найдено");
            ValueSecondLevel[key] = value;
        }
        public void ClearFirstlevel(string node)
        {
            if (!ValueSecondLevel.ContainsKey(node))
                throw new Exception("Данного ключа не найдено");
            ValueSecondLevel[node] = null;
        }

        public void RemoveFirstlevel(string node)
        {
            if (!ValueSecondLevel.ContainsKey(node))
                throw new Exception("Данного ключа не найдено");
            ValueSecondLevel.Remove(node);
            foreach(List<string> l in ValueFirstLevel.Values)
                if(l.Contains(node))
                    l.Remove(node);
        }

        public override Type GetType() => typeof(Guide);
    }
}
