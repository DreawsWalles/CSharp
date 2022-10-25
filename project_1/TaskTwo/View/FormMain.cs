using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskTwo
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FotmMain_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 34, Size.Height - 44);
            tabControl1.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel2.Size = new Size(tabControl1.Width - 14, tabControl1.Height - 42);
            tableLayoutPanel3.Size = new Size(tabControl1.Width - 14, tabControl1.Height - 42);
            tableLayoutPanel4.Size = new Size(tableLayoutPanel2.Width, tableLayoutPanel2.Height);
            tableLayoutPanel5.Size = new Size(tableLayoutPanel2.Width, tableLayoutPanel2.Height);
            tableLayoutPanel6.Size = new Size(tableLayoutPanel2.Width, tableLayoutPanel2.Height);
            tableLayoutPanel7.Size = new Size(tableLayoutPanel2.Width, tableLayoutPanel2.Height);
            tableLayoutPanel8.Size = new Size(tableLayoutPanel2.Width, tableLayoutPanel2.Height);

            tbNameFrst.ForeColor = Color.Gray;
            tbFrequencyFrst.ForeColor = Color.Gray;
            tbValueRamFrst.ForeColor = Color.Gray;

            tbNameScnd.ForeColor = Color.Gray;
            tbFrequencyScnd.ForeColor = Color.Gray;
            tbValueRamScnd.ForeColor = Color.Gray;
            tbHardDiskValue.ForeColor = Color.Gray;

        }

        private void FotmMain_Resize(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 34, Size.Height - 44);
            tabControl1.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel2.Size = new Size(tabControl1.Width - 14, tabControl1.Height - 42);
            tableLayoutPanel3.Size = new Size(tabControl1.Width - 14, tabControl1.Height - 42);
            tableLayoutPanel4.Size = new Size(tableLayoutPanel2.Width, tableLayoutPanel2.Height);
            tableLayoutPanel5.Size = new Size(tableLayoutPanel2.Width, tableLayoutPanel2.Height);
            tableLayoutPanel6.Size = new Size(tableLayoutPanel2.Width, tableLayoutPanel2.Height);
            tableLayoutPanel7.Size = new Size(tableLayoutPanel2.Width, tableLayoutPanel2.Height);
            tableLayoutPanel8.Size = new Size(tableLayoutPanel2.Width, tableLayoutPanel2.Height);
        }

        private void tbNameFrst_Enter(object sender, EventArgs e)
        {
            if(tbNameFrst.Text.Trim() == "Название...")
            {
                tbNameFrst.Text = "";
                tbNameFrst.ForeColor = Color.Black;
            }
        }

        private void tbNameFrst_Leave(object sender, EventArgs e)
        {
            if(tbNameFrst.Text.Trim() == "")
            {
                tbNameFrst.Text = "Название...";
                tbNameFrst.ForeColor = Color.Gray;
            }
        }

        private void tbFrequencyFrst_Enter(object sender, EventArgs e)
        {
            if (tbFrequencyFrst.Text.Trim() == "Частота процессора...")
            {
                tbFrequencyFrst.Text = "";
                tbFrequencyFrst.ForeColor = Color.Black;
            }
        }

        private void tbFrequencyFrst_Leave(object sender, EventArgs e)
        {
            if (tbFrequencyFrst.Text.Trim() == "")
            {
                tbFrequencyFrst.Text = "Частота процессора...";
                tbFrequencyFrst.ForeColor = Color.Gray;
            }
            else
            {
                try
                {
                    Convert.ToDouble(tbFrequencyFrst.Text);
                    tbFrequencyFrst.ForeColor = Color.Black;
                }
                catch
                {
                    MessageBox.Show("Введено некорректное значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbFrequencyFrst.ForeColor = Color.Red;
                }
            }
        }

        private void tbValueRamFrst_Enter(object sender, EventArgs e)
        {
            if (tbValueRamFrst.Text.Trim() == "Объем оперативной памяти...")
            {
                tbValueRamFrst.Text = "";
                tbValueRamFrst.ForeColor = Color.Black;
            }
        }

        private void tbValueRamFrst_Leave(object sender, EventArgs e)
        {
            if (tbValueRamFrst.Text.Trim() == "")
            {
                tbValueRamFrst.Text = "Объем оперативной памяти...";
                tbValueRamFrst.ForeColor = Color.Gray;
            }
            else
            {
                try
                {
                    Convert.ToInt32(tbValueRamFrst.Text);
                    tbValueRamFrst.ForeColor = Color.Black;
                }
                catch
                {
                    MessageBox.Show("Введено некорректное значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbValueRamFrst.ForeColor = Color.Red;
                }
            }
        }

        private void tbNameScnd_Enter(object sender, EventArgs e)
        {
            if (tbNameScnd.Text.Trim() == "Название...")
            {
                tbNameScnd.Text = "";
                tbNameScnd.ForeColor = Color.Black;
            }
        }

        private void tbNameScnd_Leave(object sender, EventArgs e)
        {
            if (tbNameScnd.Text.Trim() == "")
            {
                tbNameScnd.Text = "Название...";
                tbNameScnd.ForeColor = Color.Gray;
            }
        }

        private void tbFrequencyScnd_Enter(object sender, EventArgs e)
        {
            if (tbFrequencyScnd.Text.Trim() == "Частота процессора...")
            {
                tbFrequencyScnd.Text = "";
                tbFrequencyScnd.ForeColor = Color.Black;
            }
        }

        private void tbFrequencyScnd_Leave(object sender, EventArgs e)
        {
            if (tbFrequencyScnd.Text.Trim() == "")
            {
                tbFrequencyScnd.Text = "Частота процессора...";
                tbFrequencyScnd.ForeColor = Color.Gray;
            }
            else
            {
                try
                {
                    Convert.ToDouble(tbFrequencyScnd.Text);
                    tbFrequencyScnd.ForeColor = Color.Black;
                }
                catch
                {
                    MessageBox.Show("Введено некорректное значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbFrequencyScnd.ForeColor = Color.Red;
                }
            }
        }

        private void tbValueRamScnd_Enter(object sender, EventArgs e)
        {
            if (tbValueRamScnd.Text.Trim() == "Объем оперативной памяти...")
            {
                tbValueRamScnd.Text = "";
                tbValueRamScnd.ForeColor = Color.Black;
            }
            else
            {
                try
                {
                    Convert.ToInt32(tbValueRamScnd.Text);
                    tbValueRamScnd.ForeColor = Color.Black;
                }
                catch
                {
                    MessageBox.Show("Введено некорректное значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbValueRamScnd.ForeColor = Color.Red;
                }
            }
        }

        private void tbValueRamScnd_Leave(object sender, EventArgs e)
        {
            if (tbValueRamScnd.Text.Trim() == "")
            {
                tbValueRamScnd.Text = "Объем оперативной памяти...";
                tbValueRamScnd.ForeColor = Color.Gray;
            }
        }

        private void tbHardDiskValue_Enter(object sender, EventArgs e)
        {
            if (tbHardDiskValue.Text.Trim() == "Объем жесткого диска...")
            {
                tbHardDiskValue.Text = "";
                tbHardDiskValue.ForeColor = Color.Black;
            }
        }

        private void tbHardDiskValue_Leave(object sender, EventArgs e)
        {
            if (tbHardDiskValue.Text.Trim() == "")
            {
                tbHardDiskValue.Text = "Объем жесткого диска...";
                tbHardDiskValue.ForeColor = Color.Gray;
            }
            else
            {
                try
                {
                    Convert.ToInt32(tbHardDiskValue.Text);
                    tbHardDiskValue.ForeColor = Color.Black;
                }
                catch
                {
                    MessageBox.Show("Введено некорректное значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbHardDiskValue.ForeColor = Color.Red;
                }
            }

        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            {
                if(tbNameFrst.Text == "Название...")
                {
                    MessageBox.Show("Не ввдено название процессора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(tbFrequencyFrst.Text == "Частота процессора...")
                {
                    MessageBox.Show("Не ввдена частота процессора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(tbFrequencyFrst.ForeColor == Color.Red)
                {
                    MessageBox.Show("Введенная частота процессора является некорректной", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(tbValueRamFrst.Text == "Объем оперативной памяти...")
                {
                    MessageBox.Show("Не введен объем оперативной памяти", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(tbValueRamFrst.ForeColor == Color.Red)
                {
                    MessageBox.Show("Введенный объем оперативной памяти является некорректным", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ComputerFirstLevel computerFirst = new ComputerFirstLevel(tbNameFrst.Text, Convert.ToDouble(tbFrequencyFrst.Text), Convert.ToInt32(tbValueRamFrst.Text));
                MessageBox.Show(computerFirst.ToString(), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tbNameScnd.Text == "Название...")
            {
                MessageBox.Show("Не ввдено название процессора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbFrequencyScnd.Text == "Частота процессора...")
            {
                MessageBox.Show("Не ввдена частота процессора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbFrequencyScnd.ForeColor == Color.Red)
            {
                MessageBox.Show("Введенная частота процессора является некорректной", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbValueRamScnd.Text == "Объем оперативной памяти...")
            {
                MessageBox.Show("Не введен объем оперативной памяти", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbValueRamScnd.ForeColor == Color.Red)
            {
                MessageBox.Show("Введенный объем оперативной памяти является некорректным", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbHardDiskValue.Text == "Объем жесткого диска...")
            {
                MessageBox.Show("Не введен объем жесткого диска", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbHardDiskValue.ForeColor == Color.Red)
            {
                MessageBox.Show("Введенный объем жесткого диска является некорректным", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ComputerSecondLevel computerSecond = new ComputerSecondLevel(tbNameScnd.Text, Convert.ToDouble(tbFrequencyScnd.Text), Convert.ToInt32(tbValueRamScnd.Text), Convert.ToInt32(tbHardDiskValue.Text));
            MessageBox.Show(computerSecond.ToString(), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
