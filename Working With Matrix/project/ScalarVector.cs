using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace project
{
    public class ScalarVector
    {
        public int Size { get; private set; }
        private double[] vector = null; 
        public double this[int index]
        {
            get 
            {
                if (vector == null)
                    throw new Exception("Вектор не инициализирован");
                if (index < 0 || index >= Size)
                    throw new Exception("Индекс нахоодился вне границ вектора");
                return vector[index]; 
            }
            set 
            {
                if (vector == null)
                    throw new Exception("Вектор не инициализирован");
                if (index < 0 || index >= Size)
                    throw new Exception("Индекс нахоодился вне границ вектора");
                vector[index] = value; 
            }
        }
        public ScalarVector() { Size = -1; }
        public ScalarVector(int size)
        {
            if (size <= 0)
                throw new Exception("Размер вектора должен быть положительным");
            Size = size;
            vector = new double[size];
        }
        /// <summary>
        /// Инициализация вектора с помощью передачи массива int
        /// </summary>
        /// <param name="vector"></param>
        public ScalarVector Initialize(double[] vector)
        {
            Size = vector.Length;
            this.vector = vector;
            return this;
        }
        /// <summary>
        /// Инициализация вектора из текстового файла
        /// </summary>
        /// <param name="file">Файл, из которого необходимо считать данные</param>
        public ScalarVector Initialize(StreamReader file)
        {
            string line = "";
            char errorElement = ' ';
            int posErrorElement = -1;
            try
            {
                line = file.ReadLine();
                HelpFunction.ConvertToInt(line, out int size, ref errorElement, ref posErrorElement);
                if (size <= 0)
                    throw new Exception("Считанный размер вектора меньше или равен 0");
                Size = size;
                vector = new double[Size];
                line = file.ReadLine();
                line = line.Trim();
                string[] vec = line.Split(';');
                int count = 0;
                while (count < vec.Length && count < Size)
                {
                    HelpFunction.ConvertToDouble(vec[count], out double param, ref errorElement, ref posErrorElement);
                    vector[count] = param;
                    count++;
                }
                if (count != Size)
                    throw new Exception("Размер вектора не совпадает с количеством считанных данных");
                return this;
            }
            catch(Exception e)
            {
                if (e.Message == "Размер вектора не совпадает с количеством считанных данных")
                    throw new Exception(e.Message);
                throw new Exception($"{e.Message}. Считанная строка: {line}. {(posErrorElement == -1 ? "" : $"Некореектный символ: { errorElement }")}");
            }
        }
        /// <summary>
        /// Инициализация вектора из бинарного файла
        /// </summary>
        /// <param name="file">Файл, из которого необходимо считать данные</param>
        public ScalarVector Initialize(BinaryReader file)
        {
            try
            {
                int size = file.ReadInt32();
                if (size <= 0)
                    throw new Exception("Считанный размер вектора меньше или равен 0");
                Size = size;
                vector = new double[Size];
                int count = 0;
                while (count < Size && file.PeekChar() > -1)
                {
                    vector[count] = file.ReadDouble();
                    count++;
                }
                if (count != Size)
                    throw new Exception("Размер вектора не совпадает с количеством считанных данных");
                return this;
            }
            catch(Exception e)
            {
                if (e.Message != "Размер вектора не совпадает с количеством считанных данных" || e.Message != "Считанный размер вектора меньше или равен 0")
                    throw new Exception("При считывании данных произошла ошибка");
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// Инициализация вектора из файла xml
        /// </summary>
        /// <param name="file">Файл, из которого необходимо считать данные</param>
        public ScalarVector Initialize(FileStream file)
        {
            string line = "";
            char errorElement = ' ';
            int posErrorElement = -1;
            try
            {
                XmlTextReader fileXML = new XmlTextReader(file)
                {
                    WhitespaceHandling = WhitespaceHandling.None
                };
                fileXML.MoveToContent();
                line = fileXML.GetAttribute("size");
                HelpFunction.ConvertToInt(line, out int size, ref errorElement, ref posErrorElement);
                if (size <= 0)
                    throw new Exception("Считанный размер вектора меньше или равен 0");
                Size = size;
                vector = new double[Size];
                fileXML.Read();
                int count = 0;
                while (count < Size && !fileXML.EOF)
                {
                    line = fileXML.GetAttribute("value");
                    HelpFunction.ConvertToDouble(line, out double param, ref errorElement, ref posErrorElement);
                    vector[count] = param;
                    count++;
                    fileXML.Read();
                }
                if (count != Size)
                    throw new Exception("Размер вектора не совпадает с количеством считанных данных");
                return this;
            }
            catch(Exception e)
            {
                if (e.Message == "Размер вектора не совпадает с количеством считанных данных")
                    throw new Exception(e.Message);
                throw new Exception($"{e.Message}. Считанная строка: {line}. {(posErrorElement == -1 ? "" : $"Некореектный символ: { errorElement }")}");
            }
        }
        /// <summary>
        /// Преобразование вектора в массив строк
        /// </summary>
        /// <returns>Возвращает массив строк</returns>
        public new string[] ToString()
        {
            if (vector == null)
                throw new Exception("Вектор неинициализирован");
            string[] result = new string[Size];
            for (int i = 0; i < Size; i++)
                result[i] = Convert.ToString(vector[i]);
            return result;
        }
        /// <summary>
        /// Запись в текстовый файл
        /// </summary>
        /// <param name="file">Файл, в который записывается вектор</param>
        public void Write(StreamWriter file)
        {
            if (vector == null)
                throw new Exception("Вектор неинициализирован");
            file.WriteLine(Size);
            for (int i = 0; i < Size - 1; i++)
                file.Write(vector[i] + ';');
            file.WriteLine(vector[Size - 1]);

        }
        /// <summary>
        /// Запись в бинарный файл
        /// </summary>
        /// <param name="file">Файл, в который записывается вектор</param>
        public void Write(BinaryWriter file)
        {
            if (vector == null)
                throw new Exception("Вектор не инициализирован");
            file.Write(Size);
            foreach (double element in vector)
                file.Write(element);
        }
        /// <summary>
        /// Запись в XML файл
        /// </summary>
        /// <param name="file">Файл, в который записывается вектор</param>
        public void Write(FileStream file)
        {
            if (vector == null)
                throw new Exception("Вектор не инициализирован");
            XmlTextWriter fileXML = new XmlTextWriter(file, Encoding.Unicode);
            try
            {
                fileXML.Formatting = Formatting.Indented;
                fileXML.WriteStartDocument();
                fileXML.WriteStartElement("Vector");
                fileXML.WriteAttributeString("size", Convert.ToString(Size));
                foreach (double element in vector)
                {
                    fileXML.WriteStartElement("Element");
                    fileXML.WriteAttributeString("value", Convert.ToString(element));
                    fileXML.WriteEndElement();
                }
                fileXML.WriteEndElement();
                fileXML.WriteEndDocument();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fileXML.Close();
            }
        }
        public static ScalarVector operator +(ScalarVector a, ScalarVector b)
        {
            ScalarVector result = new ScalarVector(a.Size > b.Size ? a.Size : b.Size);
            for (int i = 0; i < a.Size && i < b.Size; i++)
                result[i] = a[i] + b[i];
            if (a.Size > b.Size)
                for (int i = b.Size; i < a.Size; i++)
                    result[i] = a[i];
            else
                for (int i = a.Size; i < b.Size; i++)
                    result[i] = b[i];
            return result;
        }
        public static ScalarVector operator -(ScalarVector a, ScalarVector b)
        {
            ScalarVector result = new ScalarVector(a.Size > b.Size ? a.Size : b.Size);
            for (int i = 0; i < a.Size && i < b.Size; i++)
                result[i] = a[i] - b[i];
            if (a.Size > b.Size)
                for (int i = b.Size; i < a.Size; i++)
                    result[i] = a[i];
            else
                for (int i = a.Size; i < b.Size; i++)
                    result[i] = b[i];
            return result;
        }
        public static double operator *(ScalarVector a, ScalarVector b)
        {
            double result = 0;
            for (int i = 0; i < a.Size && i < b.Size; i++)
                result += a[i] * b[i];
            return result;
        }
        public double NormMax()
        {
            double max = Int32.MinValue;
            foreach (int element in vector)
                if (element > max)
                    max = element;
            return max;
        }
        public static bool operator ==(ScalarVector a, ScalarVector b)
        {
            if (a.Size != b.Size)
                return false;
            for (int i = 0; i < a.Size; i++)
                if (a[i] != b[i])
                    return false;
            return true;
        }
        public static bool operator !=(ScalarVector a, ScalarVector b)
        {
            return a == b ? false : true;
        }
    }
}
