using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace n2_1_4p86 {
    class Buffer {

        // Максимальное коичество элементов буфера
        public static int maxCapacity = 10;

        // Сообщения
        Queue<string> messages;

        // Сообщения для очереди
        private TextBox FMessages;

        // Сообщения читателей
        TextBox FReaders;

        // Сообщения писателей
        TextBox FWriters;

        // Конструктор буфера
        public Buffer (TextBox pInfo, TextBox pReaders, TextBox pWriters) {
            FMessages = pInfo;
            FReaders = pReaders;
            FWriters = pWriters;
            messages = new Queue<string>();
        } //public Buffer

        // Чтение сообщения (true, если чтение удалось)
        public bool WasRead (out string pString) {
            lock (this) {
                if (messages.Count == 0) {
                    pString = "";
                    return false;
                }
                pString = messages.Dequeue();
                FMessages.Invoke(new Action(EditMessages));
                return true;
            }
        } //public bool WasRead

        // Записывает сообщение (true, если очередь не переполнена и запись удалась)
        public bool WasWrite (string pString) {
            lock (this) {
                if (messages.Count >= maxCapacity)
                    return false;
                messages.Enqueue(pString);
                FMessages.Invoke(new Action(EditMessages));
                return true;
            }
        } //public bool WasWrite

        // Метод удаляет первую строчку из сообщений
        void EditMessages () {
            List<string> list = FMessages.Lines.ToList();
            list.Clear();
            for (int i = 0; i < messages.Count; i++)
                list.Add(messages.ElementAt(i));
            FMessages.Lines = list.ToArray();
        } //void RemoveFirstLine

        // Очистка буфера
        public void Clear () {
            messages.Clear();
        } //public void Clear
    } //class Buffer
} //namespace n2_1_4p86
