using System.Windows.Forms;

namespace Task2_ex7
{
    public partial class ResultOfTask : Form
    {
        /// <summary>
        /// Формат строки, полученной из типа данных ДатаВремя
        /// </summary>
        public static string FormatOfDate = "";

        /// <summary>
        /// Инициализация формы и заполнение ее значениями
        /// </summary>
        /// <param name="scanner">Объект, содержащий результаты просмотра каталогов</param>
        public ResultOfTask(TaskDirectories scanner)
        {
            InitializeComponent();
            SetBoxes(scanner);
            tbGeneralInfo.Lines = SetGeneralInfo(scanner);
        }

        /// <summary>
        /// Информация о самом позднем файле в каждом из каталогов
        /// </summary>
        private void SetBoxes(TaskDirectories scanner)
        {
            tbMaxFirstDate.Text = scanner.First.MaxDateTime.ToString(FormatOfDate);
            tbMaxSecondDate.Text = scanner.Second.MaxDateTime.ToString(FormatOfDate);            
        }

        /// <summary>
        /// Результат наличия самого позднего файла вовтором каталоге
        /// </summary>
        private static string[] SetGeneralInfo(TaskDirectories scanner)
        {
            if (scanner.TheLatestDate() == 2)
                return new[]
                {
                    "Есть"
                };
            else
                return new[]
                {
                    "Нет"
                };
        }

    }
}
