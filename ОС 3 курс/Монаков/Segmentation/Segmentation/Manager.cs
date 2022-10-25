using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
namespace Segmentation
{
    class Manager
    {
        // список свободной памяти
        private SortedList<int, int> sortedFreeSpace;
     
        private int memorySize;
        private int currPos;

        //элементы для отоборажения
        private Graphics gr;
        private TextBox txtBox;
        private Pen blackPen;
        private Brush br;
        private int topLeft;
        private int height;
        public Manager(Graphics g,int x0, TextBox t)
        {
            gr = g;
            currPos = x0;
            blackPen = new Pen(Color.Black, 2);
            br = new SolidBrush(Color.Black);
            topLeft = 42;
            height = 100;
            memorySize = 10000;
            txtBox = t;

            sortedFreeSpace = new SortedList<int, int>();
            sortedFreeSpace.Add(x0,memorySize - x0);
        }

        private void FreeSegment(int adrr, int size)
        {
            KeyValuePair<int, int> right = new KeyValuePair<int, int>(-1, 0);
            KeyValuePair<int, int> left = new KeyValuePair<int, int>(-1, 0);
            bool found_right, found_left;
            found_left = found_right = false;

            foreach (var i in sortedFreeSpace)
            {
                if (i.Key == adrr + size)
                {
                    right = i;
                    found_right = true;
                }
                if ( i.Key + i.Value == adrr)
                {
                    left = i;
                    found_left = true;
                }
            }
            
            if (found_left && found_right)
            {
                sortedFreeSpace.Remove(right.Key);
                sortedFreeSpace.Remove(left.Key);
                sortedFreeSpace.Add(left.Key, left.Value + size + right.Value);
            }
            else if (found_left)
            {
                sortedFreeSpace.Remove(left.Key);
                sortedFreeSpace.Add(left.Key, left.Value + size);
            }
            else if (found_right)
            {
                sortedFreeSpace.Remove(right.Key);
                sortedFreeSpace.Add(adrr, right.Value + size);
            }
            else
            {
                sortedFreeSpace.Add(adrr, right.Value + size);
            }
        }
        public void giveSegment(object sender, ProcessEventArgs e)
        {
            Process p = sender as Process;
            if (p != null)
            {
                lock (this) 
                {
                    //сегмент который необходимо положить в оперативную память
                   Segment tmp = p.segList.Find(s => s.number==e.numberOfSegment);
                   //если сегмент уже в оперативной памяти
                   if (!tmp.isTaken)
                   {
                       //если у процесса уже 3 сегмента в оперативной памяти
                       if (p.takenSegms.Count > 2)
                       {
                           Segment deleting = p.takenSegms.Dequeue();
                           deleting.isTaken = false;
                           AraiseSegment(deleting);//стираем с формы
                           FreeSegment(deleting.adrr, deleting.size);// добавляем в список свободной памяти
                           txtBox.Invoke(new Action(() => txtBox.Text += "Mенеджер освободил сегмент № " + e.numberOfSegment.ToString() + " процесса № " + p.name.ToString() + "\r\n"));
                           Thread.Sleep(1000);
                       }
                        KeyValuePair<int, int> help = new KeyValuePair<int, int>(-1, 0);
                        // пытаемся вставить сегмент в "дырки"
                        foreach (var freeAd in sortedFreeSpace)
                        {
                            if (tmp.size <= freeAd.Value)
                            {
                                help = freeAd;
                                tmp.adrr = freeAd.Key;
                                p.takenSegms.Enqueue(tmp);
                                tmp.isTaken = true;
                                DrawSegment(tmp, p.name, p.color);
                                Thread.Sleep(1000);
                                break;
                            }
                        }
                        if (tmp.isTaken)
                        {
                            sortedFreeSpace.Remove(help.Key);
                            if (help.Value > tmp.size)
                            {
                                sortedFreeSpace.Add(tmp.adrr + tmp.size, help.Value - tmp.size);
                            }
                            txtBox.Invoke(new Action(() => txtBox.Text += "Mенеджер добавил  сегмент № " + e.numberOfSegment.ToString() + " процесса № " + p.name.ToString() + "\r\n"));
                        }
                   }
               }
            }
        }

        public void freeProcess(object sender, ProcessEventArgs e)
        {
            Process p = sender as Process;
            if (p != null)
            {
                Segment tmp;
                lock(this)
                {
                    while(p.takenSegms.Count != 0)
                    {
                        tmp = p.takenSegms.Dequeue();
                        tmp.isTaken = false;
                        AraiseSegment(tmp);
                        FreeSegment(tmp.adrr, tmp.size);
                    }
                    txtBox.Invoke(new Action(() => txtBox.Text += "Mенеджер освобил все сегметы процесса № "+ p.name.ToString() + "\r\n"));
                }
            }
        }
        private void AraiseSegment(Segment s)
        {
            gr.FillRectangle(new SolidBrush(Color.White), s.adrr, topLeft, s.size, height);
            gr.DrawRectangle(blackPen, s.adrr, topLeft, s.size, height);
        }
        public  void DrawSegment(Segment s, int pr, Color color)
        {
            gr.DrawRectangle(blackPen, s.adrr, topLeft, s.size, height);
            gr.FillRectangle(new SolidBrush(color), s.adrr, topLeft, s.size, height);
            Font f = new Font(new FontFamily("Arial"), 12, FontStyle.Bold);
            int posX = s.adrr + s.size/2 - 8;
            switch( pr.ToString().Length)
            {
                case 1:
                    gr.DrawString(s.number.ToString(), f, br, posX, height/2+topLeft -10);
                    break;
                case 2:
                    gr.DrawString(pr.ToString(), f, br, posX - 5, height / 2 + topLeft - 10);
                    break;
            }
        }
    }
}
