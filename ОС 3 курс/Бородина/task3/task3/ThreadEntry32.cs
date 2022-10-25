using System;
using System.Text;
using System.Runtime.InteropServices;

namespace task3
{

    // Структура, содержащая информацию о потоках
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct ThreadEntry32
    {
        const int MAX_PATH = 260;
        public uint dwSize;  // размер записи
        public uint cntUsage; // счетчик ссылок процесса
        public uint th32ThreadID; // идентификатор потока
        public uint th32OwnerProcessID; //идентификатор родительского процесса
        public int tpBasePri; //базовый класс приоритета потока
        public int tpDeltaPri; //дельта приоритет потока
        public uint dwFlags; //зарезервировано

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.Append("Информация о потоке:").Append(Environment.NewLine)
                .Append(Environment.NewLine)
                .Append("ID потока: ").Append(th32ThreadID).Append(Environment.NewLine)
                .Append("ID родительского процесса: ").Append(th32OwnerProcessID).Append(Environment.NewLine)
                .Append("Размер памяти: ").Append(dwSize).Append(" байт").Append(Environment.NewLine)
                .Append("Базовый приоритет: ").Append(tpBasePri).Append(Environment.NewLine)
                .Append("Счетчик ссылок: ").Append(cntUsage).Append(Environment.NewLine);
            return str.ToString();
        }
    }
}