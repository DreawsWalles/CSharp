using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class FormConvertElement : Form
    {
        public int choice = -1;
        public FormConvertElement()
        {
            InitializeComponent();
            MaximumSize = Size;
            MinimumSize = Size;
        }

        private void Array_Click(object sender, EventArgs e)
        {
            choice = 2;
            Close();
        }

        private void List_Click(object sender, EventArgs e)
        {
            choice = 1;
            Close();
        }
    }
}
