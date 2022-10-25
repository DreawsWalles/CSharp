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

namespace Task3._7
{
    public partial class MainForm : Form
    {
        Model model;
        List<HeapEntry32> heapEntrys;
        int Min, Max;

        public MainForm()
        {
            InitializeComponent();
            model = new Model();

        }



        private void btnDoTask_Click(object sender, EventArgs e)
        {
            int min = Int32.Parse(txbxMinAdress.Text);
            int max = Int32.Parse(txbxMaxAdress.Text);
            foreach (var heap in heapEntrys)
            {
                if(heap.dwAdress > min && heap.dwAdress < max )
                {
                    txbxInfo.Text += model.getProcessInfo(heap.th32ProcessID) + Environment.NewLine + Environment.NewLine; 
                }
            }

        }

        private void btnGetRange_Click(object sender, EventArgs e)
        {
            heapEntrys = model.HeapEntrys;
            heapEntrys = heapEntrys.OrderBy(x => x.dwAdress).ToList();
            Min = (int)heapEntrys[0].dwAdress;
            Max = (int)heapEntrys[heapEntrys.Count - 1].dwAdress;
            txbxMinAdress.Text = Min.ToString();
            txbxMaxAdress.Text = Max.ToString();
        }

        private void txbxMaxAdress_KeyPress(object sender, KeyPressEventArgs e)
        {
         
        }

        private void txbxMinAdress_KeyPress(object sender, KeyPressEventArgs e)
        {
  
        }
    }
}
