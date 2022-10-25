using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOne
{
    public class Text : IEnumerable, IEnumerator
    {
        private Sentence title = null;
        public Sentence Title
        {
            get
            {
                if (title == null)
                    throw new InvalidOperationException("Заголовок неинициализирован");
                return title;
            }
            set
            {
                title = value;
            }
        }

        private Sentence[] text = null;

        public Sentence[] Value
        {
            get
            {
                if (text == null)
                    throw new InvalidOperationException("Текст неинициализирован");
                return text;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                text = value;
            }
        }

        public Text()
        {

        }
        public Text(Sentence Title)
        {
            title = Title;
        }

        public Text(Sentence[] text)
        {
            this.text = text;
        }

        public Text(string text)
        {
            this.text = Convert(text).ToArray();
        }

        public Text(Sentence Title, Sentence[] text)
        {
            title = Title;
            this.text = text;
        }

        public Text(Sentence Title, string[] text)
        {
            title = Title;
            this.text = new Sentence[text.Length];
            for (int i = 0; i < text.Length; i++)
                this.text[i] = new Sentence(text[i]);
        }

        public Text(Sentence Title, string text)
        {
            title = Title;           
            this.text = Convert(text).ToArray();
        }
        private List<Sentence> Convert(string text)
        {
            List<Sentence> result = new List<Sentence>();
            Sentence sen = null;
            string tmp = "";
            for (int i = 0; i < text.Length; i++)
                if (!".?!".Contains(text[i]))
                    tmp += text[i];
                else
                {
                    tmp += text[i];
                    sen = new Sentence(tmp);
                    result.Add(sen);
                    tmp = "";
                }
            if (tmp != "")
            {
                sen = new Sentence(tmp);
                result.Add(sen);
            }
            return result;
        }
        public void Append(string text)
        {
            if (this.text == null)
            {
                this.text = Convert(text).ToArray();
                return;
            }
            List<Sentence> tmp = Convert(text);
            foreach (Sentence s in tmp)
                this.text.Append(s);
        }
        public void Clear()
        {
            text = null;
            title = null;
        }

        public override string ToString()
        {
            string result = "";
            foreach(Sentence s in this.text)
                result += s.ToString();
            return result;
        }
        private int position = -1;

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            position++;
            return position < this.text.Length;
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get
            {
                return text[position];
            }
        }
    }
}
