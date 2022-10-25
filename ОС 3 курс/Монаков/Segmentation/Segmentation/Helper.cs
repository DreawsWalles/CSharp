using System;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace Segmentation
{
    class Helper
    {
         private Manager manager;
         private Thread thread;
         public Helper( Graphics g, TextBox t)
         {
             manager = new Manager(g, 5, t);
             thread = new Thread(Start);
             thread.Start();
         }
        private void Start()
        {
            Random randonGen = new Random();
            int i = 1;
            while (true)
            {
                Color randomColor = Color.FromArgb(randonGen.Next(255), randonGen.Next(255), randonGen.Next(255));
                Process p = new Process(i, randonGen.Next(5, 20), randomColor);
                p.WantSegment += manager.giveSegment;
                p.FreeMe += manager.freeProcess;
                p.Go();
                i++;
                Thread.Sleep(3000);
            }

        }
    }
}
