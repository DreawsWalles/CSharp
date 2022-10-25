using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    class Node
    {
        private const int AlphabetSize = 26;

        public Node[] Nodes = new Node[AlphabetSize];
        public bool IsEndOfWord;

        public Node() => IsEndOfWord = false;

        public bool IsEmpty()
        {
            for (int i = 0; i < AlphabetSize; i++)
                if (Nodes[i] != null)
                    return false;
            return true;
        }
        private char WhatLeter(int i)
        {
            return Convert.ToChar('a' + i);
        }
        public void Print(Node node, int index, ref TextBox textBox)
        {
            if (node != null)
            {
                for (int i = 0; i < 26; i++)
                {
                    if (node.Nodes[i] != null)
                    {

                        for (int j = 0; j < index; j++)
                            textBox.Text += '\t';
                        if (node.Nodes[i].IsEndOfWord)
                            textBox.Text += WhatLeter(i) + "." + "\r\n";
                        else
                            textBox.Text += WhatLeter(i) + "\r\n";
                        Print(node.Nodes[i], index + 1, ref textBox);
                    }

                }
            }
        }
    }
}
