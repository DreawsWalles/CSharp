using System;
using System.Threading;
using System.Windows.Forms;

namespace Task2_ex7
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// Объект, осуществляющий поиск файлов по двум каталогам
        /// </summary>
        private readonly TaskDirectories _worker;
        
        /// <summary>
        /// Поток выполнения главной задачи 
        /// </summary>
        private Thread _thread;
        
        /// <summary>
        /// Форма результата
        /// </summary>
        private ResultOfTask _results;

        /// <summary>
        /// Инициализация главной формы
        /// </summary>
        public FormMain()
        {
            InitializeComponent();            
            _worker = new TaskDirectories();
            Application.Idle += EnabledControl;
        }

        /// <summary>
        /// Выбор каталога и запуск потока, решающего главную задачу, при выборе первого каталога
        /// </summary>
        private void selectFirstDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK != fileBrowerFirst.ShowDialog())            
                return;

            _thread = new Thread(Task);
            _worker.First.Directory = fileBrowerFirst.SelectedPath;
            tbFirstPath.Text = _worker.First.Directory;
            if (_worker.CanScan) 
                _thread.Start();                            
        }

        /// <summary>
        /// Выбор каталога и запуск потока, решающего главную задачу, при выборе второго каталога
        /// </summary>
        private void selectSecondDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK != fileBrowerSecond.ShowDialog())            
                return;

            _thread = new Thread(Task);
            _worker.Second.Directory = fileBrowerSecond.SelectedPath;
            tbSecondPath.Text = _worker.Second.Directory;
            if (_worker.CanScan) 
                _thread.Start();                
        }

        /*/// <summary>
        /// Выбор каталога и запуск потока, решающего главную задачу, при выбраны двух каталогов
        /// </summary>
        public void selectDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sndr = sender as ToolStripMenuItem;
            var browser = sndr == menuFirstSelect ? fileBrowerFirst : fileBrowerSecond;
            if (DialogResult.OK != browser.ShowDialog())
                return;

            _thread = new Thread(Task);
            if (sndr == menuFirstSelect)
                _worker.First.Directory = browser.SelectedPath;
            else 
                _worker.Second.Directory = browser.SelectedPath;
            
            if (_worker.CanScan)
                _thread.Start();
        }*/

        /// <summary>
        /// Запуск процесса поиска файлов в подкаталогах и получение самых поздних дат
        /// </summary>
        private void Task()
        {
            Thread thread = new Thread(_worker.Solve);
            thread.Start();
            thread.Join();
            mainMenu.Invoke(new Action( () => menuFullResults.Enabled = true));
        }

        /// <summary> Закрытие всех потоков при закрытии главной формы
        /// </summary>
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        /// <summary>
        /// Вызов формы результата
        /// </summary>
        private void mainMenuFullResults_Click(object sender, EventArgs e)
        {
            _results = new ResultOfTask(_worker);
            _results.Show();
        }

        /// <summary>
        /// Контроль за доступностью пунктов меню (нельзя выбрать новый подкаталог, пока поток выполняется)
        /// </summary>
        private void EnabledControl(object sender, EventArgs e)
        {            
            menuFirstSelect.Enabled = menuSecondSelect.Enabled = _thread == null || 
                (_thread != null && !_thread.IsAlive);
        }

    }
}
