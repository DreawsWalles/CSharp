using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace project
{
    public class Trie : IEnumerable<string>
    {
        private const int AlphabetSize = 26;

        private Node _root;

        public Trie() => _root = new Node();
        public Trie(string[] words) : this()
        {
            foreach (var word in words)
                Add(word);
        }

        public bool IsEmpty() => _root.IsEmpty();

        public void Clear() => _root = new Node();

        public bool Contains(string word)
        {
            var length = word.Length;
            var tmp = _root;
            int index;
            for (int level = 0; level < length; level++)
            {
                try
                {
                    index = GetIndexOf(word[level]);
                    Debug.WriteLine(index);
                    if (tmp.Nodes[index] == null)
                        return false;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new ArgumentException("Invalid symbol encountered");
                }
                tmp = tmp.Nodes[index];
            }
            return tmp != null && tmp.IsEndOfWord;
        }

        public TextBox Print(TextBox textBox)
        {
             _root.Print(_root, 0, ref textBox);
            return textBox;
        }

        private int GetIndexOf(char letter) => letter - 'a';

        public void Add(string word)
        {
            var length = word.Length;
            if (length <= 0)
                return;
            var tmp = _root;
            int index;
            try
            {
                for (int level = 0; level < length; level++)
                {
                    index = GetIndexOf(word[level]);
                    if (tmp.Nodes[index] == null)
                        tmp.Nodes[index] = new Node();
                    tmp = tmp.Nodes[index];
                }
                tmp.IsEndOfWord = true;
            }
            catch (IndexOutOfRangeException)
            {
                throw new ArgumentException("Invalid symbol encountered");
            }
        }

        public void Delete(string word) => Delete(_root, word);

        private Node Delete(Node node, string word, int depth = 0)
        {
            if (node == null)
                return null;
            if (depth == word.Length)
            {
                if (node.IsEndOfWord)
                    node.IsEndOfWord = false;

                if (node.IsEmpty())
                    node = null;

                return node;
            }
            try
            {
                int index = GetIndexOf(word[depth]);
                node.Nodes[index] = Delete(node.Nodes[index], word, depth + 1);
            }
            catch (IndexOutOfRangeException)
            {
                throw new ArgumentException("Invalid symbol encountered");
            }
            if (node.IsEmpty() && !node.IsEndOfWord)
                node = null;
            return node;
        }

        private bool CheckWord(string check, string word)
        {
            if (word.Length < check.Length)
                return false;
            int index = 0;
            while (index < check.Length && index < word.Length)
            {
                if (check[index] != word[index])
                    return false;
                index++;
            }
            return true;

        }
        public int GetCountOfTaskWords(string prefix)
        {
            int finalCount = 0;
            foreach (string word in this)
            {
                if (CheckWord(prefix, word))
                    finalCount++;
            }
            return finalCount;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return GetWords(_root, "").GetEnumerator();
        }

        private IEnumerable<string> GetWords(Node node, string word)
        {
            if (node != null)
            {
                if (node.IsEndOfWord)
                    yield return word;
                for (int i = 0; i < AlphabetSize; i++)
                    if (node.Nodes[i] != null)
                        foreach (var j in GetWords(node.Nodes[i], word + char.ConvertFromUtf32('a' + i)))
                            yield return j;
            }
        }

        public string[] ToArray() => GetWords(_root, "").ToArray();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
