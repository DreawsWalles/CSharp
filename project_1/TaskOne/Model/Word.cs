using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOne
{
    public class Word : IEnumerable, IEnumerator
    {
        private string word = null;

        public int Length
        {
            get
            {
                if (word == null)
                    throw new Exception("Слово не инициализировано");
                return word.Length; 
            }
            private set { }
        }

        public string Value {
            get
            {
                if (word == null)
                    throw new Exception("Слово не инициализировано");
                return word;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                word = value;
            }
        }

        public override string ToString()
        {
            if(word == null)
                throw new ArgumentNullException("value");
            return word.ToString();
        }

        public Word(string value)
        {
            word = value;           
        }

        public Word(char value)
        {
            word = new string(new char[] {value});
        }
        private int position = -1;

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            position++;
            return position < word.Length;
        }
        public void Reset()
        {
            position = -1;
        }

        public object Current 
        { 
            get 
            { 
                return word[position]; 
            } 
        }
    }
}
