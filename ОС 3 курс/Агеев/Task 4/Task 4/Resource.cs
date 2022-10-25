using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    /// <summary>
    /// Ресурс, реализует паттерн одиночки
    /// </summary>
    class Resource
    {
        /// <summary>
        /// Экземпляр-одиночка
        /// </summary>
        private static Resource instance;

        private Resource(TextBox resource)
        {
            tbRes = resource;
        }

        private Resource()
        {
            tbRes = null;
        }
        //самим ресурсом будет текстовое поле
        private TextBox tbRes;
        
        /// <summary>
        /// Запись в ресурс
        /// </summary>
        /// <param name="text">Строка текста</param>
        public void Write(string text)
        {
            tbRes.AppendText(text);
        }
        /// <summary>
        /// Очистка ресурса
        /// </summary>
        public void Clear()
        {
            tbRes.Clear();
        }

        /// <summary>
        /// Создание ресурса
        /// </summary>
        /// <param name="resource">Текстовое поле</param>
        /// <returns></returns>
        public static Resource CreateInstance(TextBox resource)
        {
            instance = new Resource(resource);
            return instance;
        }
        /// <summary>
        /// Получение ресурса
        /// </summary>
        /// <returns></returns>
        public static Resource GetInstance()
        {
            if (instance == null)
                instance = new Resource();
            return instance;
        }
    }
}
