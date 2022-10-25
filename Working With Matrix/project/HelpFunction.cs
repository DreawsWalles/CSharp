using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    static class HelpFunction
    {
        static public void ConvertToInt(string value, out int result, ref char errorElement, ref int posErrorElement)
        {
            if (string.IsNullOrEmpty(value))
                throw new Exception("Переданный параметр value пуст или имеет значение null");
            value = value.Trim(' ');
            int pos;
            bool isMinus;
            if (value[0] == '-')
            {
                isMinus = true;
                pos = 1;
            }
            else
            {
                isMinus = false;
                pos = 0;
            }
            if(pos == value.Length)
            {
                errorElement = '-';
                posErrorElement = 0;
                throw new Exception("Переданный параметр value некорректен");
            }
            result = 0;
            while(pos < value.Length)
            {
                if (!char.IsDigit(value[pos]))
                {
                    errorElement = value[pos];
                    posErrorElement = pos;
                    throw new Exception("В параметре value обнаружен некорректный символ");
                }
                else
                    result = result * 10 + (value[pos] - '0');
                pos++;
            }
            result = isMinus ? result *= -1 : result;
        }
        static public void ConvertToDouble(string value, out double result, ref char errorElement, ref int posErrorElement)
        {
            if (string.IsNullOrEmpty(value))
                throw new Exception("Переданный параметр value пуст или имеет значение null");
            value = value.Trim(' ');
            result = -1;
            try
            {
               result = Convert.ToDouble(value);
            }
            catch
            {
                for(int i = 0; i < value.Length; i++)
                    if (!Char.IsDigit(value[i]))
                    {
                        errorElement = value[i];
                        posErrorElement = i;
                    }
            }
        }
    }
}
