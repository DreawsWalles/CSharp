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
        public Panel panel { get; set; }
        public Label lbl { get; set; }
        string path;
        string pathBin = "System/File.bin";
        string name;
        int type;
        Settings set;
        History history;
        /// <summary>
        ///0- файл создан
        ///1- файл не сохранен, так как не было открыто ни одного файла
        ///2- файл сохранен
        ///3- Ни одного файла не было открыто
        ///4- закрыть файл
        ///5- сохранить файл
        ///6- завершить работу программы?
        ///7- файл не удалось открыть
        ///8- Элемент добавлен
        /// </summary>
        public string[] Notifications;
        /// <summary>
        /// 0- курсовая работа.exe
        /// 1- Уведомление
        /// 2- ошибка
        /// </summary>
        public string[] Titles;
        /// <summary>
        ///0- кинокомпания
        ///1- фильм
        ///2- режиссер
        ///3- длительность
        ///4- дата выхода
        ///5- главные герои
        ///6- призы
        /// </summary>
        public string[] textForFilms;
        public MenuStrip mainMenu { get; set; }
        public TabControl TabCtrl { get; set; }
        public FrmMain()
        {
            InitializeComponent();
            tabControl1.Controls.Clear();
            textForFilms = new string[7];
            Titles = new string[3];
            Notifications = new string[9];
            mainMenu = menuStrip_main;
            TabCtrl = tabControl1;
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLoadOrCreateFile form = new FrmLoadOrCreateFile();
            form.ShowDialog();
            set.Refresh();
            if (form.DialogResult == DialogResult.OK)
            {
                path = form.path;
                name = form.Name;
                type = form.type;
                CreateTabPages();
                OpenFile();
                history = new History();
                MessageBox.Show(Notifications[0], Titles[1], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DataHistory node;
                node.Path = dialog.FileName;
                dialog.FileName = Path.GetFileNameWithoutExtension(dialog.FileName);
                name = dialog.FileName;
                node.Name = dialog.FileName;
                node.Date = Convert.ToString(DateTime.Now);
                path = node.Path;
                StreamReader file = new StreamReader(File.Open(node.Path, FileMode.Open));
                try
                {
                    type = Convert.ToInt32(file.ReadLine());
                    file.Close();
                    history.Add(node);
                    CreateTabPages();
                    OpenFile();
                }
                catch
                {
                    MessageBox.Show(Notifications[7], Titles[2], MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                file.Close();
            }
        }
        private string[] insertNode(string info)
        {
            string[] result = new string[7];
            string s;
            string help = "";
            info = info.Remove(0, 14);
            int i = 0;
            while (info[i] != ':')
            {
                help += info[i];
                i++;
            }
            s = " " + textForFilms[1];
            help = help.Replace(s, "");
            result[2] = help;
            help = "";
            i += 2;
            while (info[i] != ':')
            {
                help += info[i];
                i++;
            }
            s = " " + textForFilms[2];
            help = help.Replace(s, "");
            result[0] = help;
            help = "";
            i += 2;
            while (info[i] != ':')
            {
                help += info[i];
                i++;
            }
            s = " " + textForFilms[3];
            help = help.Replace(s, "");
            result[3] = help;
            help = "";
            i += 2;
            while (info[i] != ':')
            {
                help += info[i];
                i++;
            }
            s = textForFilms[4];
            help = help.Replace(s, "");
            result[4] = help;
            help = "";
            i += 2;
            while (info[i] != 'Г')
            {
                help += info[i];
                i++;
            }
            s = textForFilms[5];
            help = help.Replace(s, "");
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
            s = textForFilms[6];
            help = help.Replace(s, "");
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
            try
            {
                StreamWriter f_write = new StreamWriter(path);
                f_write.WriteLine(type.ToString());
                foreach (Label element in panel.Controls)
                    f_write.WriteLine(element.Text);
                f_write.Close();
                MessageBox.Show(Notifications[2], Titles[1], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(Notifications[1], Titles[2], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddElementInPanel(Film element)
        {
            Label label = new Label
            {
                AutoSize = true,
                Font = new Font("Consolas", 12),
                Text = textForFilms[0] + ": " + element.FilmStudio + textForFilms[1] + " : " + element.Name + textForFilms[2] +  " : " + element.Director + textForFilms[3] +  " : " + element.Duration + Environment.NewLine + textForFilms[4] +  ": " + element.Date.ToString() + Environment.NewLine
            };
            label.Text += textForFilms[5] + ": ";
            foreach (string elem in element.MainHeroes)
                label.Text += elem + ";";
            label.Text += Environment.NewLine;
            label.Text += textForFilms[6] + ": ";
            foreach (string elem in element.Prizes)
                label.Text += elem + ";";
            label.BackColor = Color.FromArgb(0, 201, 13);
            if (panel.Controls.Count == 0)
                label.Location = new Point(15, 0);
            else
                label.Location = new Point(15, panel.Controls[panel.Controls.Count - 1].Location.Y + panel.Controls[panel.Controls.Count - 1].Height + 15);
            panel.Controls.Add(label);
            if (panel.Controls[panel.Controls.Count - 1].Location.Y + panel.Controls[panel.Controls.Count - 1].Height + 15 == panel.Height)
            {
                panel.Height += panel.Controls[panel.Controls.Count - 1].Height + 30;
                Height += panel.Controls[panel.Controls.Count - 1].Height + 30;
            }
        }

        private void AppendElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.Controls.Count == 0)
            {
                MessageBox.Show(Notifications[3], Titles[2], MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (type != 5)
            {
                FrmInputFilm form = new FrmInputFilm();
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    MessageBox.Show(Notifications[8], Titles[1], MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Film film = new Film(form.information);
                    AddElementInPanel(film);
                }
            }
            else
            {
                
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
            if (form.DialogResult == DialogResult.OK)
            {
                path = form.path;
                name = form.Name;
                type = form.type;
                CreateTabPages();
                OpenFile();
                history = new History();
            }
            Localization.LocalFrmMain(this, set.Node.IsEnglish);
            Designer.DesinerFrmMain(this, set.Node.DesignIsDefault);
        }
        private void CreateTabPages()
        {
            panel = new Panel()
            {
                BackColor = Color.Black,
                Size = new Size(tabControl1.Size.Width, tabControl1.Size.Height),
                AutoScroll = true
            };
            bool ok = false;
            foreach(TabPage page in tabControl1.Controls)
            {
                if (page.Text == name)
                    ok = true;
            }
            TabPage tabPage;
            if (ok)
                tabPage = new TabPage(path);
            else
                tabPage = new TabPage(name);
            tabPage.Tag = path;
            tabPage.Controls.Add(panel);
            tabControl1.Controls.Add(tabPage);
            tabControl1.Refresh();
            Designer.DesignerTabControls(this, set.Node.DesignIsDefault);
        }
        private void AddElementInPanel(string element)
        {
            lbl = new Label();
            lbl.Font = new Font("Consolas", 12);
            lbl.FlatStyle = FlatStyle.Flat;
            lbl.BackColor = Color.Gainsboro;
            lbl.ForeColor = Color.Black;
            lbl.Height = 45;
            lbl.Width = 150;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Location = new Point(5 + 200 * (panel.Controls.Count % 4), 30 + 80 * (panel.Controls.Count / 4));
            lbl.Text = element;
            panel.Controls.Add(lbl);
        }
        //1- char
        //2- double
        //3- string
        //4- int
        //5- MyType
        //6- float
        private void OpenFile()
        {
            StreamReader file = new StreamReader(path);
            string s;
            switch (type)
            {
                case 1:
                    {
                        BinaryWriter fileBin = new BinaryWriter(File.Open(pathBin, FileMode.OpenOrCreate));
                        file.ReadLine();
                        while (!file.EndOfStream)
                        {
                            s = file.ReadLine();
                            AddElementInPanel(s);
                            fileBin.Write(s[0]);
                        }
                        fileBin.Close();
                    }
                    break;
                case 2:
                    {
                        BinaryWriter fileBin = new BinaryWriter(File.Open(pathBin, FileMode.OpenOrCreate));
                        file.ReadLine();
                        while (!file.EndOfStream)
                        {
                            s = file.ReadLine();
                            AddElementInPanel(s);
                            fileBin.Write(Convert.ToDouble(s));
                        }
                        fileBin.Close();
                    }
                    break;
                case 3:
                    {
                        BinaryWriter fileBin = new BinaryWriter(File.Open(pathBin, FileMode.OpenOrCreate));
                        file.ReadLine();
                        while (!file.EndOfStream)
                        {
                            s = file.ReadLine();
                            AddElementInPanel(s);
                            fileBin.Write(s);
                        }
                        fileBin.Close();
                    }
                    break;
                case 4:
                    {
                        BinaryWriter fileBin = new BinaryWriter(File.Open(pathBin, FileMode.OpenOrCreate));
                        file.ReadLine();
                        while (!file.EndOfStream)
                        {
                            s = file.ReadLine();
                            AddElementInPanel(s);
                            fileBin.Write(Convert.ToInt32(s));
                        }
                        fileBin.Close();
                    }
                    break;
                case 5:
                    {
                        FileStream fileBin = new FileStream(pathBin, FileMode.OpenOrCreate);
                        while (!file.EndOfStream)
                        {
                            s = file.ReadLine() + file.ReadLine() + file.ReadLine() + file.ReadLine();
                            Film film = new Film(insertNode(s));
                            AddElementInPanel(film);
                            film.Write(fileBin);
                        }
                    }
                    break;
                case 6:
                    {
                        BinaryWriter fileBin = new BinaryWriter(File.Open(pathBin, FileMode.OpenOrCreate));
                        file.ReadLine();
                        while (!file.EndOfStream)
                        {
                            s = file.ReadLine();
                            AddElementInPanel(s);
                            fileBin.Write(Convert.ToSingle(s));
                        }
                        fileBin.Close();
                    }
                    break;
            }
            file.Close();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.Controls.Count == 0)
            {
                MessageBox.Show(Notifications[3], Titles[2], MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult result = MessageBox.Show(Notifications[4] + " " + tabControl1.Controls[tabControl1.Controls.Count - 1].Text + "?", Titles[1],
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DialogResult res = MessageBox.Show(Notifications[5] + " " + tabControl1.Controls[tabControl1.Controls.Count - 1].Text + "?", Titles[1],
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(res == DialogResult.Yes)
                    saveToolStripMenuItem_Click(sender, null);
                tabControl1.Controls.Remove(tabControl1.Controls[tabControl1.Controls.Count - 1]);
                try
                {
                    path = Convert.ToString(tabControl1.Controls[tabControl1.Controls.Count - 1].Tag);
                    StreamReader file = new StreamReader(path);
                    type = Convert.ToInt32(file.ReadLine());
                }
                catch { }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.Controls.Count != 0)
            {
                SaveFileDialog dialog = new SaveFileDialog
                {
                    Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    history.Delete(path);
                    DataHistory node;
                    node.Path = dialog.FileName;
                    dialog.FileName = Path.GetFileNameWithoutExtension(dialog.FileName);
                    name = dialog.FileName;
                    node.Name = dialog.FileName;
                    node.Date = Convert.ToString(DateTime.Now);
                    path = node.Path;
                    saveToolStripMenuItem_Click(sender, null);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Notifications[6], Titles[1],
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void FrmMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult result = MessageBox.Show(Notifications[6], Titles[1],
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSetting form = new FrmSetting();
            form.ShowDialog();
            set.Refresh(new SettingsNode(form.isEnglish, form.designIsDefault));
            Localization.LocalFrmMain(this, set.Node.IsEnglish);
            Designer.DesinerFrmMain(this, set.Node.DesignIsDefault);
        }

        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            tabControl1.Size = new Size(Size.Width - 45, Size.Height - 80);
            foreach (TabPage page in tabControl1.TabPages)
            {
                Panel panel = (Panel)page.Controls[0];
                panel.Size = new Size(tabControl1.Width - 8, tabControl1.Height - 32);
            }
            int x = 5;
            int y = 30;
            foreach (Label element in panel.Controls)
            {
                if (x >= panel.Size.Width)
                {
                    x = 5;
                    y += 80;

                }
                element.Location = new Point(x, y);
                x += 200;
            }
        }

        private void withInternalSortingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.Controls.Count == 0)
            {
                MessageBox.Show(Notifications[3], Titles[2], MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path;
                path = dialog.FileName;
                SortWithInternalSort.MergeSort("System/File.bin", path);
                FrmSortElements form_sort = new FrmSortElements(path);
                form_sort.ShowDialog();
            }
        }

        private void withoutInternalSortingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.Controls.Count == 0)
            {
                MessageBox.Show(Notifications[3], Titles[2], MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path;
                path = dialog.FileName;
                SortWithInternalSort.MergeSort("System/File.bin", path);
                FrmSortElements form_sort = new FrmSortElements(path);
                form_sort.ShowDialog();
            }
        }
    }
}
