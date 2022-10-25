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
    public partial class FormGetN : Form
    {
        public int count = -1;
		int border;
        public FormGetN(string text, int borBeg)
        {
            InitializeComponent();
            label1.Text = text;
			border = borBeg;
			textBox1.Size = new Size(label1.Size.Width, textBox1.Size.Height);
			button_ok.Location = new Point(Convert.ToInt32(textBox1.Location.X + textBox1.Size.Width / 3.5), button_ok.Location.Y);
			Height = button_ok.Location.Y + button_ok.Size.Height + 50;
			Width = textBox1.Location.X + textBox1.Size.Width + 50;
        }

		int CheckChoise(string s, int border)
		{
			int num;
			
			if (s.Length == 0)
			{
				MessageBox.Show("Считана пустая строка. Повторите ввод", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return -1;
			}
			else
			{
				num = 0;
				int len = s.Length;
				int i = 0;
				int n;
				while (i < len)
					if ((s[i] >= '0') && (s[i] <= '9'))
					{
						n = s[i] - '0';
						num = num * 10 + n;
						i++;
					}
					else
					{
						string message = "Считан некорректный символ: " + s[i] + ".Повторите ввод";
						MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return -1;
					}
				if (num < border)
				{
					string message = "Считанное значение некорректно. Значение должно быть больше " + border + ".Повторите ввод";
					MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return -1;
				}
				return num;
			}
		}
		
		private void FormGetN_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult result = MessageBox.Show("Закрыть окно?", "Закрыть",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    if (count == -1)
                        DialogResult = DialogResult.Cancel;
                    Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
				count = CheckChoise(textBox1.Text, border);
				if (count == -1)
				{
					DialogResult result = MessageBox.Show("Закрыть окно?", "Закрыть",
						MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (result == DialogResult.Yes)
					{
						if (count == -1)
							DialogResult = DialogResult.Cancel;
						Close();
					}
				}
				else
				{
					DialogResult = DialogResult.OK;
					Close();
				}
			}
        }

        private void button_ok_Click(object sender, EventArgs e)
		{
			count = CheckChoise(textBox1.Text, border);
			if (count == -1)
			{
				DialogResult result = MessageBox.Show("Закрыть окно?", "Закрыть",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					if (count == -1)
						DialogResult = DialogResult.Cancel;
					Close();
				}
			}
			else
			{
				DialogResult = DialogResult.OK;
				Close();
			}
        }
    }
}
