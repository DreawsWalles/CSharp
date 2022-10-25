using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Task1._2._3._3
{
    public partial class MainForm : Form
    {
        Model model;
        Console console;
        Thread modelThread;

        public MainForm()
        {
            InitializeComponent();
            console = new Console(0, 0, ClientSize.Width / 2, ClientSize.Height, true);
            model = new Model(console);
            modelThread = new Thread(model.loop);
            modelThread.Name = "Менеджер";
            this.Controls.Add(console);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (modelThread.ThreadState == ThreadState.Stopped)
            {
                modelThread = new Thread(model.loop);
                modelThread.Start();
            }
            else
                modelThread.Start();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            model.RequestStop();
            console.printMessage(Environment.NewLine + Environment.NewLine + "Поток - менеджер прекратил свою работу и существование!" + Environment.NewLine + Environment.NewLine);
        }
    }
}
