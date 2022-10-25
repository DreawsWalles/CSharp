using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;


namespace project
{
    public class TridiagonalMatrix
    {
        public int Size { get; private set; }
        private ScalarVector firstDiagonal = null;
        private ScalarVector secondDiagonal = null;
        private ScalarVector thridDiagonal = null;
        
        public TridiagonalMatrix() { Size = -1; }
        public TridiagonalMatrix(int size)
        {
            Size = size;
            secondDiagonal = new ScalarVector(size);
            firstDiagonal = new ScalarVector(size - 1);
            thridDiagonal = new ScalarVector(size - 1);
        }
        public double this[int i, int j]
        {
            get 
            {
                if (i < 0 || i > Size)
                    throw new Exception("Попытка обращения к элементу, который находится вне границ матрицы");
                if (j < 0 || j > Size)
                    throw new Exception("Попытка обращения к элементу, который находится вне границ матрицы");
                if (i == j)
                    return secondDiagonal[i];
                else if (i + 1 == j)
                    return thridDiagonal[i];
                else if (i == j + 1)
                    return firstDiagonal[i - 1];
                else return 0;
            }
            set 
            {
                if (i < 0 || i > Size)
                    throw new Exception("Попытка обращения к элементу, который находится вне границ матрицы");
                if (j < 0 || j > Size)
                    throw new Exception("Попытка обращения к элементу, который находится вне границ матрицы");
                if (i == j)
                    secondDiagonal[i] = value;
                else if (i + 1 == j)
                    thridDiagonal[i] = value;
                else if (i == j + 1)
                    firstDiagonal[i - 1] = value;
                else
                    throw new Exception("Данный элемент должен быть равен 0");
            }
        }
        private void ConvertMatrixToDiagonals(double[,] value)
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (i == j)
                        secondDiagonal[i] = value[i, j];
                    else if (i + 1 == j)
                        thridDiagonal[i] = value[i, j];
                    else if (i == j + 1)
                        firstDiagonal[i - 1] = value[i, j];
                    else if (value[i, j] != 0)
                        throw new Exception("Недиагональный элемент не равен нулю. Данная матрицы не является трехдиагональной");
                        
        }
        /// <summary>
        /// Инициализация матрицы с помощью передачи массива int[,]
        /// </summary>
        /// <param name="value"></param>
        public TridiagonalMatrix Initialize(double[,] value)
        {
            if ((Math.Sqrt(value.Length) - Math.Truncate(Math.Sqrt(Convert.ToDouble(value.Length)))) != 0.0)
                throw new Exception("Данный массив не является матрицей");
            Size = (int)Math.Sqrt(value.Length);
            if (Size < 2)
                throw new Exception("Данный массив не является матрицей");
            secondDiagonal = new ScalarVector(Size);
            firstDiagonal = new ScalarVector(Size - 1);
            thridDiagonal = new ScalarVector(Size - 1);
            ConvertMatrixToDiagonals(value);
            return this;
        }
        /// <summary>
        /// Инициализация матрицы из текстового файла
        /// </summary>
        /// <param name="file">Файл, из которого необходимо считать данные</param>
        public TridiagonalMatrix Initialize(StreamReader file)
        {
            string line = "";
            char errorElement = ' ';
            int posErrorElement = -1;
            try
            {
                line = file.ReadLine();
                HelpFunction.ConvertToInt(line, out int size, ref errorElement, ref posErrorElement);
                if (size < 2)
                    throw new Exception("Считанный размер не может быть размером матрицы");
                Size = size;
                secondDiagonal = new ScalarVector(Size);
                firstDiagonal = new ScalarVector(Size - 1);
                thridDiagonal = new ScalarVector(Size - 1);
                int i = 0;
                double[,] value = new double[Size, Size];
                while (i < Size && !file.EndOfStream)
                {
                    line = file.ReadLine();
                    line = line.Trim();
                    string[] vec = line.Split(';');
                    int count = 0;
                    while (count < vec.Length && count < Size)
                    {
                        HelpFunction.ConvertToDouble(vec[count], out double param, ref errorElement, ref posErrorElement);
                        if (!(i == count || i + 1 == count || i == count + 1) && param != 0)
                            throw new Exception("Недиагональный элемент не равен нулю. Данная матрицы не является трехдиагональной");
                        value[i, count] = param;
                        count++;
                    }
                    if (count != Size)
                        throw new Exception("Размер матрицы не совпадает с количеством считанных данных");
                    i++;
                }
                if (i != Size)
                    throw new Exception("Размер матрицы не совпадает с количеством считанных данных");
                ConvertMatrixToDiagonals(value);
                return this;
            }
            catch (Exception e)
            {
                if (e.Message == "Размер матрицы не совпадает с количеством считанных данных")
                    throw new Exception(e.Message);
                throw new Exception($"{e.Message}. Считанная строка: {line}. {(posErrorElement == -1 ? "" : $"Некореектный символ: { errorElement }")}");
            }
        }
        /// <summary>
        /// Инициализация матрицы из бинарного файла
        /// </summary>
        /// <param name="file">Файл, из которого необходимо считать данные</param>
        public TridiagonalMatrix Initialize(BinaryReader file)
        {
            try
            {
                int size = file.ReadInt32();
                if (size < 2)
                    throw new Exception("Считанный размер не может быть размером матрицы");
                Size = size;
                secondDiagonal = new ScalarVector(size);
                firstDiagonal = new ScalarVector(size - 1);
                thridDiagonal = new ScalarVector(size - 1);
                int i = 0;
                double param;
                double[,] value = new double[Size, Size];
                while (i < Size && file.PeekChar() > -1)
                {
                    int count = 0;
                    while (count < Size && file.PeekChar() > -1)
                    {
                        param = file.ReadDouble();
                        if (!(i == count || i + 1 == count || i == count + 1) && param != 0)
                            throw new Exception("Недиагональный элемент не равен нулю. Данная матрицы не является трехдиагональной");
                        value[i, count] = param;
                        count++;
                    }
                    if (count != Size)
                        throw new Exception("Размер матрицы не совпадает с количеством считанных данных");
                    i++;
                }
                if (i != Size)
                    throw new Exception("Размер матрицы не совпадает с количеством считанных данных");
                ConvertMatrixToDiagonals(value);
                return this;
            }
            catch (Exception e)
            {
                if (e.Message != "Размер матрицы не совпадает с количеством считанных данных" || e.Message != "Считанный размер не может быть размером матрицы")
                    throw new Exception("При считывании данных произошла ошибка");
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// Инициализация матрицы из файла xml
        /// </summary>
        /// <param name="file">Файл, из которого необходимо считать данные</param>
        public TridiagonalMatrix Initialize(FileStream file)
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
                if (size < 2)
                    throw new Exception("Считанный размер не может быть размером матрицы");
                Size = size;
                secondDiagonal = new ScalarVector(size);
                firstDiagonal = new ScalarVector(size - 1);
                thridDiagonal = new ScalarVector(size - 1);
                int i = 0;
                double[,] value = new double[Size, Size];
                fileXML.Read();
                while (i < Size && !fileXML.EOF)
                {
                    int count = 0;
                    while (count < Size && !fileXML.EOF)
                    {
                        line = fileXML.GetAttribute("value");
                        HelpFunction.ConvertToDouble(line, out double param, ref errorElement, ref posErrorElement);
                        if (!(i == count || i + 1 == count || i == count + 1) && param != 0)
                            throw new Exception("Недиагональный элемент не равен нулю. Данная матрицы не является трехдиагональной");
                        value[i, count] = param;
                        count++;
                        fileXML.Read();
                    }
                    if (count != Size)
                        throw new Exception("Размер матрицы не совпадает с количеством считанных данных");
                    i++;
                }
                if (i != Size)
                    throw new Exception("Размер матрицы не совпадает с количеством считанных данных");
                ConvertMatrixToDiagonals(value);
                return this;
            }
            catch (Exception e)
            {
                if (e.Message == "Размер матрицы не совпадает с количеством считанных данных")
                    throw new Exception(e.Message);
                throw new Exception($"{e.Message}. Считанная строка: {line}. {(posErrorElement == -1 ? "" : $"Некореектный символ: { errorElement }")}");
            }
        }
        /// <summary>
        /// Преобразование матрицы в массив строк
        /// </summary>
        /// <returns>Возвращает массив строк</returns>
        public new string[,] ToString()
        {
            if ((object)firstDiagonal == null)
                throw new Exception("Матрица неинициализирована");
            string[,] result = new string[Size, Size];
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (i == j)
                        result[i, j] = Convert.ToString(secondDiagonal[i]);
                    else if (i + 1 == j)
                        result[i, j] = Convert.ToString(thridDiagonal[i]);
                    else if (i == j + 1)
                        result[i, j] = Convert.ToString(firstDiagonal[i - 1]);
                    else
                        result[i, j] = "0";
            return result;
        }
        /// <summary>
        /// Запись в текстовый файл
        /// </summary>
        /// <param name="file">Файл, в который записывается матрица</param>
        public void Write(StreamWriter file)
        {
            if ((object)firstDiagonal == null)
                throw new Exception("Матрица неинициализирована");
            file.WriteLine(Size);
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (i == j)
                        file.Write(secondDiagonal[i]);
                    else if (i + 1 == j)
                        file.Write(thridDiagonal[i]);
                    else if (i == j + 1)
                        file.Write(firstDiagonal[i - 1]);
                    else
                        file.Write(0);
                    if (j != Size - 1)
                        file.Write(';');
                }
                file.WriteLine();
            }
        }
        /// <summary>
        /// Запись в бинарный файл
        /// </summary>
        /// <param name="file">Файл, в который записывается матрицы</param>
        public void Write(BinaryWriter file)
        {
            if ((object)firstDiagonal == null)
                throw new Exception("Матрица неинициализирована");
            file.Write(Size);
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (i == j)
                        file.Write(secondDiagonal[i]);
                    else if (i + 1 == j)
                        file.Write(thridDiagonal[i]);
                    else if (i == j + 1)
                        file.Write(firstDiagonal[i - 1]);
                    else
                        file.Write(0);
                    
        }
        /// <summary>
        /// Запись в XML файл
        /// </summary>
        /// <param name="file">Файл, в который записывается матрица</param>
        public void Write(FileStream file)
        {
            if ((object)firstDiagonal == null)
                throw new Exception("Вектор не инициализирован");
            XmlTextWriter fileXML = new XmlTextWriter(file, Encoding.Unicode);
            try
            {
                fileXML.Formatting = Formatting.Indented;
                fileXML.WriteStartDocument();
                fileXML.WriteStartElement("Vector");
                fileXML.WriteAttributeString("size", Convert.ToString(Size));
                for (int i = 0; i < Size; i++)
                    for (int j = 0; j < Size; j++)
                    {
                        fileXML.WriteStartElement("Element");
                        if (i == j)
                            fileXML.WriteAttributeString("value", Convert.ToString(Convert.ToString(secondDiagonal[i])));
                        else if (i + 1 == j)
                            fileXML.WriteAttributeString("value", Convert.ToString(Convert.ToString(thridDiagonal[i])));
                        else if (i == j + 1)
                            fileXML.WriteAttributeString("value", Convert.ToString(Convert.ToString(firstDiagonal[i - 1])));
                        else
                            fileXML.WriteAttributeString("value", "0");
                        fileXML.WriteEndElement();
                    }
                fileXML.WriteEndElement();
                fileXML.WriteEndDocument();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fileXML.Close();
            }
        }
        public static TridiagonalMatrix operator +(TridiagonalMatrix a, TridiagonalMatrix b)
        {
            if (a.Size != b.Size)
                throw new Exception("Операция сложения определена только для матриц одноо порядка");
            TridiagonalMatrix result = new TridiagonalMatrix(a.Size);
            int i = 0;
            int j = 0;
            result[i, j] = a[i, j] + b[i, j];
            j++;
            result[i, j] = a[i, j] + b[i, j];
            int border = 0;
            for (i = 1; i < a.Size - 1; i++)
            {
                for (j = border; j < border + 3; j++)
                    result[i, j] = a[i, j] + b[i, j];
                border++;
            }
            result[result.Size - 1, result.Size - 2] = a[result.Size - 1, result.Size - 2] + b[result.Size - 1, result.Size - 2];
            result[result.Size - 1, result.Size - 1] = a[result.Size - 1, result.Size - 1] + b[result.Size - 1, result.Size - 1];
            return result;
        }
        public static TridiagonalMatrix operator -(TridiagonalMatrix a, TridiagonalMatrix b)
        {
            if (a.Size != b.Size)
                throw new Exception("Операция вычитания определена только для матриц одноо порядка");
            TridiagonalMatrix result = new TridiagonalMatrix(a.Size);
            int i = 0;
            int j = 0;
            result[i, j] = a[i, j] - b[i, j];
            j++;
            result[i, j] = a[i, j] - b[i, j];
            int border = 0;
            for (i = 1; i < a.Size - 1; i++)
            {
                for (j = border; j < border + 3; j++)
                    result[i, j] = a[i, j] - b[i, j];
                border++;
            }
            result[result.Size - 1, result.Size - 2] = a[result.Size - 1, result.Size - 2] - b[result.Size - 1, result.Size - 2];
            result[result.Size - 1, result.Size - 1] = a[result.Size - 1, result.Size - 1] - b[result.Size - 1, result.Size - 1];
            return result;
        }
        public static ScalarVector operator *(TridiagonalMatrix matrix, ScalarVector vec)
        {
            if (matrix.Size != vec.Size)
                throw new Exception("Для умножения матрицы на вектор количество строк матрицы и количество элементов вектора должны совпадать");
            ScalarVector result = new ScalarVector(vec.Size);
            int i = 0;
            int j = 0;
            result[i] = matrix[i, j] * vec[j] + matrix[i, j + 1] * vec[j + 1];
            for(i = 1; i < vec.Size - 1; i++)
            {
                result[i] = matrix[i, j] * vec[j] + matrix[i, j + 1] * vec[j + 1] + matrix[i, j + 2] * vec[j + 2];
                j++;
            }
            result[i] = matrix[i, j] * vec[j] + matrix[i, j + 1] * vec[j + 1];
            return result;
        }
        public static bool operator ==(TridiagonalMatrix a, TridiagonalMatrix b)
        {
            if (a.Size != b.Size)
                return false;
            int i = 0;
            int j = 0;
            if (a[i, j] != b[i, j] || a[i, j + 1] != b[i, j + 1])
                return false;
            int border = 0;
            for(i = 1; i < a.Size - 1; i++)
            {
                for (j = border; j < border + 3; j++)
                    if (a[i, j] != b[i, j])
                        return false;
                border++;
            }
            if (a[a.Size - 1, a.Size - 2] != b[b.Size - 1, b.Size - 2] || a[a.Size - 1, a.Size - 1] != b[b.Size - 1, b.Size - 1])
                return false;
            return true;
        }
        public static bool operator !=(TridiagonalMatrix a, TridiagonalMatrix b)
        {
            return a == b ? false : true;
        }

    }
}
