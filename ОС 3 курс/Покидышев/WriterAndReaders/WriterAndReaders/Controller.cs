using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

#pragma warning disable 618

namespace WriterAndReaders
{
    internal class Controller
    {
        private const int BufferLength = 1000;
        private const int MaxReaders = 5;
        private const int MaxReaderMessages = 2;

        private readonly QueueBuffer<int> _buffer = new QueueBuffer<int>(BufferLength);

        private readonly Thread _thread;

        private readonly List<Reader> _readers = new List<Reader>();
        private readonly Writer _writer;

        private readonly TextBox _tbReader;
        private readonly TextBox _tbBuffer;
        private readonly TextBox _tbWriter;

        public Controller(TextBox tbReader, TextBox tbWriter, TextBox tbBuffer)
        {
            _tbReader = tbReader;
            _tbBuffer = tbBuffer;
            _tbWriter = tbWriter;

            _writer = new Writer(_buffer, MaxReaders*MaxReaderMessages)
            {
                DataWrittenCallback =
                    item => _tbWriter.Invoke(new Action(() => _tbWriter.AppendText("\nWriter добавил число " + item + "\n")))
            };
           
            _thread = new Thread(Run);
            _thread.Start();
        }

        private void Run()
        {
            for (int i = 0; i < MaxReaders; i++)
            {
                var reader = new Reader(_buffer, MaxReaderMessages, i);
                reader.DataReadCallback = item => _tbBuffer.Invoke(new Action(() => _tbBuffer.AppendText("\nReader " + reader.No + " забрал число " + item + "\n")));
                reader.StartCallback = () => _tbReader.Invoke(new Action(() => _tbReader.AppendText("\nReader " + reader.No + " был создан" + "\n")));
                reader.StopCallback = () => _tbReader.Invoke(new Action(() => _tbReader.AppendText("\nReader " + reader.No + " завершил работу" + "\n")));

                _readers.Add(reader);
                Thread.Sleep(new Random().Next(400, 900));
            }
        }

        public void Abort()
        {
            _writer.Abort();
            _thread.Abort();
            foreach(var reader in _readers)
            {
                reader.Abort();
            }
            _readers.Clear();
        }

        public void StopReaders()
        {
            foreach (var reader in _readers)
            {
                reader.Stop();
            }
        }
        public void ResumeReaders()
        {
            foreach (var reader in _readers)
            {
                reader.Resume();
            }
        }

        public void StopWriter()
        {
            _writer.Stop();
        }

        public void ResumeWriter()
        {
            _writer.Resume();
        }

        public void Suspend()
        {
            _thread.Suspend();
        }

        public void Resume()
        {
            _thread.Resume();
        }
    }
}
