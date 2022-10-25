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
    public partial class FrmMain : Form
    {
        private string fileName = "";
        Settings set;
        public FrmMain()
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
            tabControl1.Controls.Remove(tabPage2);
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
            FrmInputFileName form = new FrmInputFileName();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK && (!File.Exists(form.fileName ) || MessageBox.Show("Файл существует. Перезаписать?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                StreamWriter newFile = new StreamWriter(form.fileName);
                newFile.Close();
                MessageBox.Show("Файл создан.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fileName = form.fileName;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInputFileName form = new FrmInputFileName();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                panel1.Controls.Clear();
                fileName = form.fileName;
                StreamReader file = new StreamReader(fileName);
                string s;
                while (!file.EndOfStream)
                {
                    s = file.ReadLine() + file.ReadLine() + file.ReadLine()+ file.ReadLine();
                    Film film = new Film(insertNode(s));
                    AddElementInPanel(film);
                }
                file.Close();
                MessageBox.Show("Файл открыт", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName == "")
                MessageBox.Show("файл не сохранен, так как не было открыто ни одного файла", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                StreamWriter f_write = new StreamWriter(fileName);
                foreach (Label element in panel1.Controls)
                    f_write.WriteLine(element.Text);
                f_write.Close();
                MessageBox.Show("Файл сохранен", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddElementInPanel(Film element)
        {
            Label label = new Label
            {
                AutoSize = true,
                Font = new Font("Consolas", 12),
                Text = "Кинокомпания: " + element.FilmStudio + " Фильм: " + element.Name + " Режиссер: " + element.Director + " Длительность: " + element.Duration + Environment.NewLine + "Дата выхода: " + element.Date.ToString() + Environment.NewLine
            };
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

        private void AppendElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName == "")
            {
                MessageBox.Show("Необходимо открыть файл", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmInputElement form = new FrmInputElement();
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
                FrmInputFileName form = new FrmInputFileName();
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK && (!File.Exists(form.fileName) || MessageBox.Show("Файл существует. Перезаписать?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    SortUnBalance.MergeSort(fileName, form.fileName);
                    FrmSortElements form_sort = new FrmSortElements(form.fileName);
                    form_sort.ShowDialog();
                }
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            set = new Settings();
            if (set.isFirstRun)
            {
                FrmSetting frm = new FrmSetting();
                frm.ShowDialog();
                set.Refresh(new SettingsNode(frm.isEnglish, frm.designIsDefault));
            }
            FrmLoadOrCreateFile form = new FrmLoadOrCreateFile();
            form.ShowDialog();
            set.Refresh();
        }
    }
}
