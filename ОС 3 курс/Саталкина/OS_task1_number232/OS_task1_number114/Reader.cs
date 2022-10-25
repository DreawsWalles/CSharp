namespace OS_task1_number232
{
    public class Reader
    {
        public Reader() { }

        public void Read()
        {
            int temp;

            if (BufferClass.Pop(out temp))
                ThreadMaker.AppendToTextBox(@"Читатель забрал число " + temp + "\r\n");
            else
                ThreadMaker.AppendToTextBox("Буфер пуст. Читатель ожидает." + "\r\n");
        }
    }
}

