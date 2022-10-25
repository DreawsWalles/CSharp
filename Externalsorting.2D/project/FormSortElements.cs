using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace project
{
    public partial class FormSortElements : Form
    {
        string fileName;
        public FormSortElements(string Name)
        {
            InitializeComponent();
            BackColor = Color.FromArgb(166, 4, 0);
            panel1.BackColor = Color.FromArgb(255, 180, 115);
            fileName = Name;
        }

        private void AddElementInPanel(Film element)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Font = new Font("Consolas", 12);
            label.Text = "Кинокомпания: " + element.FilmStudio + " Фильм: " + element.Name + " Режиссер: " + element.Director + " Длительность: " + element.Duration + Environment.NewLine + "Дата выхода: " + element.Date.ToString() + Environment.NewLine;
            label.Text += "Главные герои: ";
            foreach (string elem in element.MainHeroes)
                if (elem != "\r\n")
                    label.Text += elem + ";";
            label.Text += Environment.NewLine;
            label.Text += "Призы: ";
            foreach (string elem in element.Prizes)
                if (elem != "\r\n")
                    label.Text += elem + ";";
            label.BackColor = Color.FromArgb(0, 201, 13);
            if (panel1.Controls.Count == 0)
                label.Location = new Point(15, 0);
            else
                label.Location = new Point(15, panel1.Controls[panel1.Controls.Count - 1].Location.Y + panel1.Controls[panel1.Controls.Count - 1].Height + 15);
            panel1.Controls.Add(label);
            if (panel1.Controls[panel1.Controls.Count - 1].Location.Y + panel1.Controls[panel1.Controls.Count - 1].Height + 15 == panel1.Height)
            {
                panel1.Height += panel1.Controls[panel1.Controls.Count - 1].Height + 30;
                Height += panel1.Controls[panel1.Controls.Count - 1].Height + 30;
            }
        }

        private void FormSortElements_Load(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            string s;
            while (file.Position != file.Length)
            {

                Film film = new Film();
                film.Read(file);
                AddElementInPanel(film);
            }
            file.Close();
            MessageBox.Show("Файл отортирован.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
