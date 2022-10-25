/*
 * Вывести информацию о владельцах блоков
 * из заданного диапазона линейных адресов.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace program_3
{
    public partial class FormMain : Form
    {
        private Selection s;
        private Selection.SendInfo OnShow;

        public FormMain()
        {
            InitializeComponent();
            OnShow = onshow;
        }

        private void onshow(IEnumerable<string> infos)
        {
            if (TbOutput.InvokeRequired)
            {
                object[] param = { infos };
                TbOutput.Invoke(OnShow, param);
            }
            else
                infos.ToList().ForEach(x => TbOutput.Text += (x + Environment.NewLine));
        }

        private void BttStart_Click(object sender, EventArgs e)
        {
            TbOutput.Clear();
            uint min = Convert.ToUInt32(TbMin.Text);
            uint max = Convert.ToUInt32(TbMax.Text);
            s = new Selection(TbOutput, min, max);
            s.ShowInfo += OnShow;
            s.Start();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (s.Thread.IsAlive)
                s.Thread.Abort();
        }
    }
}
