﻿using System;

namespace Task234
{
    public class Writer
    {
        private readonly int _num;

        public Writer(int num) { _num = num; }

        public void Write()
        {
            int temp = new Random().Next(100);

            if (BufferClass.Push(temp))
                ThreadMaker.AppendToTextBox(@"Писатель " + _num + @" положил число " + temp + "\r\n");
            else
                ThreadMaker.AppendToTextBox("Буфер полностью заполнен. Писатель " + _num + " в очереди." + "\r\n");
        }
    }
}
