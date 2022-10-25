using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zadacha_1
{
    public partial class FormMain : Form
    {
        private int[] _array;
        private int _lastIndex = 0;
        private static object formLocker = new object();
        private static System.Threading.Timer timer;
        private List<IThread> _listThreads = new List<IThread>();
        public static int maxSize;

        private static FormMain visualForm;
        public static FormMain GetInstanse()
        {
            lock (formLocker)
            {
                if (visualForm == null)
                    visualForm = new FormMain();
            }
            return visualForm;
        }

        public FormMain()
        {
            InitializeComponent();
            elementCount.Maximum = 13;
            elementCount.Minimum = 6;
            delay.Minimum = 2;
            _array = new int[(int)elementCount.Value];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable matr = new DataTable("matrix");
            DataColumn[] cols = new DataColumn[(int)elementCount.Value];
            for (int i = 0; i < (int)elementCount.Value; i++)
            {
                cols[i] = new DataColumn(i.ToString());
                matr.Columns.Add(cols[i]);
            }
            dataGridView1.DataSource = matr;

            MinimumSize = Size;
            tableLayoutPanel1.Size = new Size(Size.Width - 15, Size.Height - 15);
            flowLayoutPanel1.Width = Size.Width - 15;
            tableLayoutPanel2.Size = new Size(Size.Width - 15, Size.Height - 92);
            tableLayoutPanel3.Size = new Size(Size.Width - 15, tableLayoutPanel3.Height);
            tableLayoutPanel4.Size = new Size(Size.Width - 15, Size.Height - 80);
            tableLayoutPanel5.Size = new Size((int)(tableLayoutPanel4.Width * 0.5), tableLayoutPanel4.Height);
            tableLayoutPanel6.Size = new Size((int)(tableLayoutPanel4.Width * 0.5), tableLayoutPanel4.Height);
            tableLayoutPanel7.Size = new Size((int)(tableLayoutPanel4.Width * 0.5), tableLayoutPanel4.Height);
            writer.Size = new Size((int)(tableLayoutPanel2.Width * 0.5), tableLayoutPanel2.Height - 35);
            reader.Size = new Size((int)(tableLayoutPanel2.Width * 0.5), tableLayoutPanel2.Height - 35);
            logs.Size = new Size((int)(tableLayoutPanel2.Width * 0.5), tableLayoutPanel2.Height - 35);
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 15, Size.Height - 15);
            flowLayoutPanel1.Width = Size.Width - 15;
            tableLayoutPanel2.Size = new Size(Size.Width - 15, Size.Height - 92);
            tableLayoutPanel3.Size = new Size(Size.Width - 15, tableLayoutPanel3.Height);
            tableLayoutPanel4.Size = new Size(Size.Width - 15, Size.Height - 80);
            tableLayoutPanel5.Size = new Size((int)(tableLayoutPanel4.Width * 0.5), tableLayoutPanel4.Height);
            tableLayoutPanel6.Size = new Size((int)(tableLayoutPanel4.Width * 0.5), tableLayoutPanel4.Height);
            tableLayoutPanel7.Size = new Size((int)(tableLayoutPanel4.Width * 0.5), tableLayoutPanel4.Height);
            writer.Size = new Size((int)(tableLayoutPanel2.Width * 0.5), tableLayoutPanel2.Height - 35);
            reader.Size = new Size((int)(tableLayoutPanel2.Width * 0.5), tableLayoutPanel2.Height - 35);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            writer.Text = "";
            reader.Text = "";
            logs.Text = "";
            btnStop.Visible = true;
            btnPause.Visible = true;
            btnStart.Visible = false;
            delay.Visible = true;
            label5.Visible = true;
            elementCount.Enabled = false;
            maxSize = (int)elementCount.Value;
            Run();
        }
        public void Run()
        {
            ThreadVisitor visitor = new ThreadVisitor();

            Reader reader = new Reader();
            visitor.SetNeedCharacteristics(reader, "reader");
            visitor.StartThread(reader);
            _listThreads.Add(reader);

            TimerCallback tm = new TimerCallback(CreateProducer);
            // создаем таймер
            int num = 0;
            timer = new System.Threading.Timer(tm, num, 0, new Random(DateTime.Now.Millisecond).Next(1000, 3000));
        }

        private void CreateProducer(object obj)
        {
            ThreadVisitor visitor = new ThreadVisitor();

            Writer writer = new Writer();

            visitor.SetNeedCharacteristics(writer, "writer");

            lock (formLocker)
            {
                visitor.StartThread(writer);
                _listThreads.Add(writer);
                AddNewMessage(writer.MainThread.Name + " запущен", "logThreads");
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Visible = true;
            btnStop.Visible = false;
            btnPause.Visible = false;
            delay.Visible = false;
            label5.Visible = false;
            elementCount.Enabled = true;
            var tmp = new ThreadVisitor();
            timer.Dispose();
            foreach (var item in _listThreads)
                tmp.Kill(item);
        }

        private void elementCount_ValueChanged(object sender, EventArgs e)
        {
            DataTable matr = new DataTable("matrix");
            DataColumn[] cols = new DataColumn[(int)elementCount.Value];
            for (int i = 0; i < (int)elementCount.Value; i++)
            {
                cols[i] = new DataColumn(i.ToString());
                matr.Columns.Add(cols[i]);
            }
            dataGridView1.DataSource = matr;
            _array = new int[(int)elementCount.Value];
        }
        public void AddElement(int data)
        {
            Invoke(new Action(() =>
            {
                if (_lastIndex < maxSize)
                {
                    _array[_lastIndex++] = data;
                    UpdateFront(dataGridView1);
                }

                AddNewMessage("Записано значение " + data.ToString(), "writer");
            }));
        }
        public void RemoveElement()
        {
            Invoke(new Action(() =>
            {
                int tmp = 0;
                Thread.Sleep(500);
                if (_lastIndex - 1 >= 0)
                {
                    for (int i = 1; i < _lastIndex; i++)
                    {
                        _array[i - 1] = _array[i];
                    }
                    tmp = _array[_lastIndex - 1];
                    _array[_lastIndex - 1] = 0;

                    UpdateFront(dataGridView1);

                    _lastIndex--;
                }
                AddNewMessage($"Прочитано значение: {tmp}", "reader");
            }));
        }
        public void AddNewMessage(string message, string panelName)
        {
            Invoke(new Action(() =>
            {

                switch (panelName)
                {
                    case "writer":
                        writer.AppendText(message + Environment.NewLine);
                        break;
                    case "reader":
                        reader.AppendText(message + Environment.NewLine);
                        break;
                    case "logThreads":
                        logs.AppendText(message + Environment.NewLine);
                        break;
                }
                this.Refresh();
            }));
        }

        public void SetElement(int idx, int data)
        {

            _array[idx] = data;
            UpdateFront(dataGridView1);
        }

        private void UpdateFront(DataGridView Grid)
        {
            Invoke(new Action(() =>
            {
                var maxSize = (int)elementCount.Value;
                DataTable matr = new DataTable("matrix");
                DataColumn[] cols = new DataColumn[maxSize];

                for (int i = 0; i < maxSize; i++)
                {
                    cols[i] = new DataColumn(i.ToString());
                    matr.Columns.Add(cols[i]);
                }

                dataGridView1.DataSource = matr;

                //задать размер для клеток
                for (int i = 0; i < maxSize; i++)
                    dataGridView1.Columns[i].Width = 50;

                Grid.DataSource = matr;
                // инициализация значений
                DataGridViewCell Cell;

                for (int i = 0; i < maxSize; i++)
                {
                    Cell = Grid.Rows[0].Cells[i];
                    Cell.Value = _array[i].ToString();
                }

                //this.Refresh();
                Thread.Sleep(500);


            }));
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            delay.Enabled = false;
            Thread.Sleep((int)delay.Value * 1000);
            btnStop.Enabled = true;
            delay.Enabled = true;
        }
    }
}
