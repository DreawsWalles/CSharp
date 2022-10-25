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
using System.Runtime.Serialization.Formatters.Binary;

namespace project
{
    public partial class FormMain : Form
    {
        private string fileName = "";
        public FormMain()
        {
            InitializeComponent();
            BackColor = Color.FromArgb(166, 4, 0);
            menuStrip_main.BackColor = Color.FromArgb(166, 4, 0);
            menuStrip_main.Renderer = new NoHigthligthRenderer();
            foreach (ToolStripMenuItem m in menuStrip_main.Items)
            {
                SetColor(m);
            }
            menuStrip_main.Renderer = new ToolStripProfessionalRenderer(new ChangeStyleItem());
            panel1.BackColor = Color.FromArgb(255, 180, 115);
        }

        internal class NoHigthligthRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (e.Item.OwnerItem == null)
                    base.OnRenderMenuItemBackground(e);
            }
        }

        private void SetColor(ToolStripMenuItem item)
        {
            item.ForeColor = Color.White;
            foreach (ToolStripMenuItem it in item.DropDownItems)
            {
                SetColor(it);
            }
        }

        public class ChangeStyleItem : ProfessionalColorTable
        {
            public override Color MenuItemSelected { get { return Color.FromArgb(29, 112, 116); } }
            public override Color ToolStripBorder { get { return Color.FromArgb(1, 147, 154); } }
            public override Color ToolStripDropDownBackground { get { return Color.FromArgb(1, 147, 154); } }
            public override Color ImageMarginGradientBegin { get { return Color.FromArgb(1, 147, 154); } }
            public override Color ImageMarginGradientEnd { get { return Color.FromArgb(1, 147, 154); } }
            public override Color ImageMarginGradientMiddle { get { return Color.FromArgb(1, 147, 154); } }
            public override Color MenuItemSelectedGradientBegin { get { return Color.FromArgb(29, 112, 116); } }
            public override Color MenuItemSelectedGradientEnd { get { return Color.FromArgb(29, 112, 116); } }
            public override Color MenuItemPressedGradientBegin { get { return Color.FromArgb(29, 112, 116); } }
            public override Color MenuItemPressedGradientMiddle { get { return Color.FromArgb(29, 112, 116); } }
            public override Color MenuItemPressedGradientEnd { get { return Color.FromArgb(29, 112, 116); } }
            public override Color MenuItemBorder { get { return Color.FromArgb(1, 147, 154); } }
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            FormInputFileName form = new FormInputFileName();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK && (!File.Exists(form.fileName ) || MessageBox.Show("Файл существует. Перезаписать?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                FileStream newFile = new FileStream(form.fileName, FileMode.Create);
                newFile.Close();
                MessageBox.Show("Файл создан.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fileName = form.fileName;
            }
        }

        private string[] insertNode(string info)
        {
            string[] result = new string[7];
            string help = "";
            info = info.Remove(0, 14);
            int i = 0;
            while (info[i]!= ':')
            {
                help += info[i];
                i++;
            }
            help = help.Replace(" Фильм", "");
            result[2] = help;
            help = "";
            i+=2;
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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInputFileName form = new FormInputFileName();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK && File.Exists(form.fileName))
            {
                panel1.Controls.Clear();
                fileName = form.fileName;
                FileStream file = new FileStream(fileName, FileMode.Open);
                while (file.Position != file.Length)
                {
                    Film tmp = new Film();
                    tmp.Read(file);
                    AddElementInPanel(tmp);
                }
                file.Close();
                MessageBox.Show("Файл открыт", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Файл не удалось открыть", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName == "")
                MessageBox.Show("файл не сохранен, так как не было открыто ни одного файла", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                foreach(Label element in panel1.Controls)
                {
                    Film film = new Film(insertNode(element.Text));
                    film.Write(file);
                }
                file.Close();
                MessageBox.Show("Файл сохранен", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            if (panel1.Controls[panel1.Controls.Count - 1].Location.Y + panel1.Controls[panel1.Controls.Count - 1].Height + 15 >= panel1.Height)
            {
                panel1.Height += panel1.Controls[panel1.Controls.Count - 1].Height + 30;
                Height += panel1.Controls[panel1.Controls.Count - 1].Height + 30;
            }
        }

        private void appendElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName == "")
            {
                MessageBox.Show("Необходимо открыть файл", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FormInputElement form = new FormInputElement();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Элемент добавлен", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Film film = new Film(form.information);
                AddElementInPanel(film);
            }
        }

        private void sortElementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName == "")
                MessageBox.Show("Необходимо открыть файл", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                FormInputFileName form = new FormInputFileName();
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK && (!File.Exists(form.fileName) || MessageBox.Show("Файл существует. Перезаписать?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    Sort.MergeSort(fileName, form.fileName);
                    FormSortElements form_sort = new FormSortElements(form.fileName);
                    form_sort.ShowDialog();
                }
            }
        }
    }
}
