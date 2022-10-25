using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTwo
{
    public class ComputerFirstLevel
    {
        protected string nameCPU;
        protected double frequencyCPU;
        protected int valueRAM;

        public double Quality() => 0.1 * frequencyCPU + valueRAM;

        public override string ToString() => $"Название процессора: {nameCPU}\r\n" +
                                             $"Частота процессора: {frequencyCPU} МГЦ\r\n" +
                                             $"Объем оперативной памяти: {valueRAM} МБ\r\n" +
                                             $"Качество: {Quality()}";
        public ComputerFirstLevel()
        {

        }

        public ComputerFirstLevel(string nameCPU, double frequencyCPU, int valueRAM)
        {
            this.nameCPU = nameCPU;
            this.frequencyCPU = frequencyCPU;
            this.valueRAM = valueRAM;
        }

    }
}
