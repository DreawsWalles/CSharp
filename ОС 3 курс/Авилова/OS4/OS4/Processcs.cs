using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace OS4
{
    public class Processcs
    {
        List<int> resurs;
        private int p;
        private Random rnd = new Random(); // рандом

        public Processcs(int _p)
        {
            resurs=new List<int>();
            p=_p;
        }



        private bool Is_end()
        {


        }

        private void Сreate_process(int max_r)
        {
            for (int j = 0; j < max_r; j++)
            {
                int desicion = rnd.Next() % 2;
                 = (desicion == 1);
            }
        }



    }
}
