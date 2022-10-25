using System;
using System.Collections.Generic;
using System.Threading;
using System.Drawing;

namespace Segmentation
{
    class Process
    {
        public int name { get; private set; }
        public int amountOfSegments;
        public Color color;
       
        public List<Segment> segList;
        public Queue<Segment> takenSegms;

        public event EventHandler<ProcessEventArgs> WantSegment;
        public event EventHandler<ProcessEventArgs> FreeMe;

        private Thread thread;
        private int liveTime;
        int seed;

        public Process(int nam,int lTime, Color c)
        {
            seed = name = nam;
            liveTime = lTime;
            color = c;
            takenSegms = new Queue<Segment>();
            segList = new List<Segment>();
            Random r = new Random();
            amountOfSegments = r.Next(5, 10);
            for (int j = 0; j < amountOfSegments; ++j )
                    segList.Add(new Segment(r.Next(30,70), j));
            thread = new Thread(Start);
        }

        public void Go()
        {
            thread.Start();
        }
        private void Start()
        {
            int i = 0;
            Random rand = new Random(seed);
            while (i < liveTime)
            {
                if (WantSegment != null)
                {
                    ProcessEventArgs e = new ProcessEventArgs();
                    e.numberOfSegment = rand.Next(amountOfSegments);
                    WantSegment(this, e);
                    Thread.Sleep(1500);
                }
                i++;
            }
            FreeMe?.Invoke(this, new ProcessEventArgs());
        }

    }
}
