namespace OS_task1_number114
{
    public class Reader
    {
        private readonly int _num;

        public Reader(int num) { _num = num; }

        public void Read()
        {
            int temp;
            
            if (BufferClass.Pop(out temp))
                ThreadMaker.AppendToTextBox(@"Читатель " + _num + @" забрал число " + temp + "\r\n");
            else
                ThreadMaker.AppendToTextBox("Буфер пуст. Читатель " + _num + " в очереди." + "\r\n");
        }
    }
}
