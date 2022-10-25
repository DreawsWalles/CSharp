using System;
using System.Windows.Forms;
using System.Threading;

namespace Task3_ex17
{
    public partial class Form_main : Form
    {
        ToolHelp32 th;
        public Form_main()
        {
            InitializeComponent();
            btn_execute.Enabled = false;
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            th = new ToolHelp32();
        }        

        /// <summary>
        /// Метод отображения всех процессов для потока
        /// </summary>
        void RunAll()
        {
            lock (this)
            {
                Invoke(new Action(()=>btn_showAll.Enabled = btn_execute.Enabled = false));
                foreach (ProcessEntry32 process in th.GetProcessesInIdRange())
                {
                    tb_all.Invoke(new Action(()=>tb_all.AppendText(process.ToString() + "Количество модулей: " + th.CountModuleLength(process.th32ProcessID) + "\r\n"
                                      + "Общая память: " + th.CountModuleMemSize(process.th32ProcessID).ToString() + " байт\r\n\r\n")));
                }
                Invoke(new Action(() => btn_showAll.Enabled = btn_execute.Enabled = true));
            }
        }

        /// <summary>
        /// Выполнение условия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_execute_Click(object sender, EventArgs e)
        {
            tb_res.Clear();

            Thread thrExec;
            thrExec = new Thread(new ThreadStart(RunSize));
            thrExec.Start();
        }        

        /// <summary>
        /// Метод для потока, считающего размер памяти модулей
        /// </summary>
        void RunSize()
        {
            long maxSize = th.MaxModuleMemSize();
            tb_res.Invoke(new Action(() => tb_res.AppendText("Максимальный размер памяти модуля: " + maxSize.ToString() + "\r\n\r\n")));
            Invoke(new Action(() => btn_execute.Enabled = false));

            foreach (ProcessEntry32 process in th.GetProcessesInIdRange())
            {
                tb_res.Invoke(new Action(() => tb_res.AppendText(process.ToString())));
                tb_res.Invoke(new Action(() => tb_res.AppendText("Модуль с максимальным размером: " + th.CountModuleMemSize(process.th32ProcessID).ToString() + "\r\n\r\n")));
            }

            Invoke(new Action(() => btn_execute.Enabled = true));
        }

        /// <summary>
        /// Отобращение всех процессов в диапазоне ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_showAll_Click_1(object sender, EventArgs e)
        {
            tb_all.Clear();

            Thread AllThrd = new Thread(new ThreadStart(RunAll));
            AllThrd.Start();
        }
    }
}
