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

        private string[] insertNode(string info)
        {
            string[] result = new string[7];
            string help = "";
            info = info.Remove(0, 14);
            int i = 0;
            while (info[i] != ':')
            {
                help += info[i];
                i++;
            }
            help = help.Replace(" Фильм", "");
            result[2] = help;
            help = "";
            i += 2;
            while (info[i] != ':')
            {
                help += info[i];
                i++;
            }
            help = help.Replace(" Режиссер", "");
            result[0] = help;
            help = "";
            i += 2;
            while (info[i] != ':')
            {
                help += info[i];
                i++;
            }
            help = help.Replace(" Длительность", "");
            result[3] = help;
            help = "";
            i += 2;
            while (info[i] != ':')
            {
                help += info[i];
                i++;
            }
            help = help.Replace("Дата выхода", "");
            result[4] = help;
            help = "";
            i += 2;
            while (info[i] != 'Г')
            {
                help += info[i];
                i++;
            }
            help = help.Replace("Главые герои", "");
            result[1] = help;
            while (info[i] != ':')
                i++;
            i += 2;
            help = "";
            while (info[i] != ':')
            {
                help += info[i];
                i++;
            }
            help = help.Replace("Призы", "");
            help = help.Replace(";", ",");
            result[5] = help;
            i += 2;
            help = "";
            while (i < info.Length)
            {
                help += info[i];
                i++;
            }
            help = help.Replace(";", ",");
            result[6] = help;
            return result;
        }

        private void AddElementInPanel(Film element)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Font = new Font("Consolas", 12);
            label.Text = "Кинокомпания: " + element.FilmStudio + " Фильм: " + element.Name + " Режиссер: " + element.Director + " Длительность: " + element.Duration + Environment.NewLine + "Дата выхода: " + element.Date.ToString() + Environment.NewLine;
            label.Text += "Главные герои: ";
            foreach (string elem in element.MainHeroes)
                label.Text += elem + ";";
            label.Text += Environment.NewLine;
            label.Text += "Призы: ";
            foreach (string elem in element.Prizes)
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
            StreamReader file = new StreamReader(fileName);
            string s;
            while (!file.EndOfStream)
            {
                s = file.ReadLine() + file.ReadLine() + file.ReadLine() + file.ReadLine();
                Film film = new Film(insertNode(s));
                AddElementInPanel(film);
            }
            file.Close();
            MessageBox.Show("Файл отортирован.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
