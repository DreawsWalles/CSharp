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
    public partial class FormSmallValues : Form
    {
        int count;
        int[] array = new int[10];
        bool check = true;
        public FormSmallValues()
        {
            InitializeComponent();
            Hide();
            FormGetN form = new FormGetN("Введите интервал значений набора", 0);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                count = form.count;
                Building_a_chain();
            }
            else
                DialogResult = DialogResult.Cancel;
        }
        private void Building_a_chain()
        {
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                array[i] = rand.Next(0, count);
                Label label = new Label()
                {
                    FlatStyle = FlatStyle.Flat,
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.Red,
                    ForeColor = Color.White,
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(40, 40),
                    Text = array[i].ToString(),
                    Location = new Point(45 * i + 5, 7),
                    Font = new Font("Consolas", 12, FontStyle.Bold)
                };
                panel1.Controls.Add(label);
            }
            panel1.Height = panel1.Controls[0].Location.Y + 50;
            panel1.Width = panel1.Controls[panel1.Controls.Count - 1].Location.X + 45;
            Width = panel1.Location.X + panel1.Width + 30;
            button_sort.Location = new Point(Convert.ToInt32(Width / 4 + 50), panel1.Location.Y + panel1.Height);
            Height = button_sort.Location.Y + button_sort.Height + 55;
        }
        private void FormSmallValues_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult result = MessageBox.Show("Закрыть окно?", "Закрыть",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    Close();
            }
        }

        private void button_sort_Click(object sender, EventArgs e)
        {
            if (check)
            {
                Sort.ShellSort_SmallValues(array, ref panel1);
                button_sort.Text = "Закрыть";
                button_sort.BackColor = Color.Red;
                check = false;
                for (int i = 0; i < 10; i++)
                    panel1.Controls[i].BackColor = Color.ForestGreen;
            }
            else
                Close();
        }
    }
}
