using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOne
{
    public class Sentence : IEnumerable, IEnumerator
    {
        private Word[] sentence = null;

        public int Length
        {
            get
            {
                if (sentence == null)
                    throw new Exception("Предложение не инициализировано");
                return sentence.Length;
            }
            private set { }
        }

        public Word[] Value
        {
            get
            {
                if (sentence == null)
                    throw new Exception("Предложение не инициализировано");
                return sentence;
            }
            set
            {
                if(value == null)
                    throw new ArgumentNullException("value");
                sentence = value;
            }
        }


        public override string ToString()
        {
            if (sentence == null)
                throw new Exception("Предложение не инициализировано");
            string result = "";
            foreach(Word word in Value)
                result += word.ToString();
            return result;
        }

        public Sentence(Word[] sentence)
        {
            this.sentence = sentence;
        }

        public Sentence(string[] sentence)
        {
            this.sentence = new Word[sentence.Length];
            for(int i = 0; i < sentence.Length; i++)
                this.sentence[i] = new Word(sentence[i]);
        }

        public Sentence(string sentence)
        {
            List<Word> sen = new List<Word>();
            string tmp = "";
            for (int i = 0; i < sentence.Length; i++)
                if("\t\r\n".Contains(sentence[i]))
                {
                    sen.Add(new Word(sentence[i]));
                    tmp = "";
                }
                else if (!" .,?/\'\"!:;[]{}".Contains(sentence[i]))
                    tmp += sentence[i];
                else
                {
                    if(tmp != "")
                        sen.Add(new Word(tmp));
                    sen.Add(new Word(sentence[i]));
                    tmp = "";
                }
            if (tmp != "")
                sen.Add(new Word(tmp));
            this.sentence = sen.ToArray();

        }

        private int position = -1;

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            position++;
            return position < sentence.Length;
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get
            {
                return sentence[position];
            }
        }


    }
}
