using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTwo
{
    public class ComputerSecondLevel : ComputerFirstLevel
    {
        private int valueHardDisk;
        public ComputerSecondLevel() : base()
        {

        }

        public ComputerSecondLevel(string nameCPU, double frequencyCPU, int valueRAM, int valueHardDisk) : base(nameCPU, frequencyCPU, valueRAM)
        {
            this.valueHardDisk = valueHardDisk;
        }

        public new double Quality() => base.Quality() + 0.5 * valueHardDisk;

        public new string ToString() => $"Название процессора: {nameCPU}\r\n" +
                                             $"Частота процессора: {frequencyCPU} МГЦ\r\n" +
                                             $"Объем оперативной памяти: {valueRAM} МБ\r\n" +
                                             $"Объем жесктого диска: {valueHardDisk} ГБ\r\n" +
                                             $"Качество: {Quality()}";
    }
}
