using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace project
{
    public struct Bone
    {
        public int up;
        public int down;
        public PictureBox picture;
        public int CompareTo(Bone other)
        {
            if (up == other.up && down == other.down)
                return 0;
            if (up < other.up && down < other.down)
                return -1;
            return 1;
        }
    }



    public class Bones
    {
        public List<Bone> list;
        public Bones()
        {
            list = new List<Bone>();
        }
        public int Count
        {
            get
            {
                return list.Count();
            }
        }
        public void Add(int upVal, int downVal, PictureBox pic)
        {
            Bone tmp = new Bone();
            tmp.up = upVal;
            tmp.down = downVal;
            tmp.picture = pic;
            list.Add(tmp);
        }
        public void Add(Bone element) => list.Add(element);

        public Bone this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = value;
            }
        }
        public bool Remove(Bone element)
        {
            return list.Remove(element);
        }
        public bool Contains(Bone element)
        {
            return list.Contains(element);
        }

        private void FindChain(ref Bones result, ref Bones current, int lastValue, ref bool[,] isFree)
        {
            if (result.Count <= list.Count)
            {
                if (isFree[lastValue, lastValue])
                {
                    current.Add(lastValue, lastValue, Drawing.CreateFigure(lastValue, lastValue, Color.FromArgb(133, 96, 63), Color.White));
                    isFree[lastValue, lastValue] = false;
                    FindChain(ref result, ref current, lastValue, ref isFree);
                    isFree[lastValue, lastValue] = true;
                }
                else
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (isFree[lastValue, i])
                        {
                            isFree[lastValue, i] = false;
                            isFree[i, lastValue] = false;

                            current.Add(lastValue, i, Drawing.CreateFigure(lastValue, i, Color.FromArgb(133, 96, 63), Color.White));

                            FindChain(ref result, ref current, i, ref isFree);

                            isFree[lastValue, i] = true;
                            isFree[i, lastValue] = true;
                            break;
                        }
                    }
                }

                if (current.Count >= result.Count)
                    result = current.Copy();
            }
        }
        public void Clear()
        {
            list.Clear();
        }
        public Bones Copy()
        {
            Bones result = new Bones();
            Bone[] tmp = new Bone[list.Count];
            list.CopyTo(tmp);
            foreach (Bone element in tmp)
                result.Add(element);
            return result;
        }
        public bool Search(Bone element, ref Bone result, ref int index)
        {
            index = 0;
            while (index < list.Count && list[index].CompareTo(element) != 0)
                index++;
            if (index == list.Count)
                return false;
            result = list[index];
            return true;
        }
        public Bones GetMaxChain()
        {
            
            Bones result = new Bones();
            Bones current = new Bones();

            bool[,] isFree = new bool[7, 7];
            for (int i = 0; i < list.Count; i++)
                isFree[list[i].up, list[i].down] = true;
            for (int i = 0; i < 7 && result.Count < list.Count; i++)
                for (int j = 0; j < 7 && result.Count < list.Count; j++)
                {
                    if (isFree[i, j])
                    {
                        isFree[i, j] = false;
                        isFree[j, i] = false;
                        current.Add(i, j, Drawing.CreateFigure(i, j, Color.FromArgb(133, 96, 63), Color.White));
                        FindChain(ref result, ref current, i, ref isFree);
                        if (result.Count < list.Count)
                        {
                            current.Clear();
                            current.Add(j, i, Drawing.CreateFigure(j, i, Color.FromArgb(133, 96, 63), Color.White));
                            FindChain(ref result, ref current, j, ref isFree);
                        }
                        current.Clear();
                        isFree[i, j] = true;
                        isFree[j, i] = true;
                    }
                }
            return result;
        }
    }
}
