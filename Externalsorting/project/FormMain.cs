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
                StreamWriter newFile = new StreamWriter(form.fileName);
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
                    MergeSort(fileName, form.fileName);
                    FormSortElements form_sort = new FormSortElements(form.fileName);
                    form_sort.ShowDialog();
                }
            }
        }

        // естественное двухпутевое однофазное слияние
        void MergeSort(string inputfileName, string outputFileName)
        {
            string[] fileNames = new string[] { "1.txt", "2.txt", "3.txt", "4.txt" };
            for (int j = 0; j < 4; j++) // создаем вспомогательные файлы
            {
                StreamWriter f = new StreamWriter(fileNames[j]);
                f.Close();
            }
            StreamWriter help = new StreamWriter("help.txt");
            StreamReader file = new StreamReader(inputfileName);
            while (!file.EndOfStream)
            {
                string info = file.ReadLine() + file.ReadLine() + file.ReadLine() + file.ReadLine();
                Film film = new Film(insertNode(info));
                if (film.Date.Year == 2000)
                    help.WriteLine(film);
            }
            help.Close();
            file.Close();
            // переливаем входной файл по двум вспомогательным.
            // файл с именем fileNames[2] гарантированно пуст
            // если перелили в один файл, то получили отсортированный файл
            bool isSorted = MergeSerieses("help.txt", fileNames[2], fileNames[0], fileNames[1]);
            int resultIndex = 0; // индекс названия файла, содержащего результат
            while (!isSorted) // пока файл не отсортирован
            {
                if (resultIndex == 0) // если нечетный номер переливания, льем из 1 и 2 в 3 и 4
                    isSorted = MergeSerieses(fileNames[0], fileNames[1], fileNames[2], fileNames[3]);
                else // иначе из 3 и 4 в 1 и 2
                    isSorted = MergeSerieses(fileNames[2], fileNames[3], fileNames[0], fileNames[1]);
                resultIndex += 2;
                resultIndex %= 4;
            }
            File.Copy(fileNames[resultIndex], outputFileName, true); // сохраняем результат
            for (int j = 0; j < 4; j++) // удаляем вспомогательные файлы
                File.Delete(fileNames[j]);
            File.Delete("help.txt");
        }


        // переливаем содержимое двух вспомогательных файлов в другие два
        bool MergeSerieses(string f1_in, string f2_in, string f1_out, string f2_out)
        {
            StreamReader f1_read = new StreamReader(f1_in);
            StreamReader f2_read = new StreamReader(f2_in);
            StreamWriter[] f_write = new StreamWriter[] { new StreamWriter(f1_out), new StreamWriter(f2_out) };

            Film lastRead1 = null;
            Film lastRead2 = null;
            string info = f1_read.ReadLine() + f1_read.ReadLine() + f1_read.ReadLine() + f1_read.ReadLine();
            if (info != "")
                lastRead1 = new Film(insertNode(info));
            info = f2_read.ReadLine() + f2_read.ReadLine() + f2_read.ReadLine() + f2_read.ReadLine();
            if (info != "")
                lastRead2 = new Film(insertNode(info));

            int i = 0; // количество получившихся серий
            // пока хотя бы 1 файл не пуст — сливаем серии в новый файл
            while (lastRead1 != null || lastRead2 != null)
            {
                // сливаем крайние серии в 1,
                // чередуем файлы, в которые сливаем
                Merge(f1_read, f2_read, f_write[i % 2], ref lastRead1, ref lastRead2);
                i++;
            }

            f1_read.Close();
            f2_read.Close();
            f_write[0].Close();
            f_write[1].Close();
            return i <= 1;
        }

        /// <summary>
        /// сливаем крайнии серии из файлов
        /// </summary>
        /// <param name="f1_in"> первый файл, содержащий серию </param>
        /// <param name="f2_in"> второй файл, содержащий серию </param>
        /// <param name="f_out"> файл, в который сливаются серии </param>
        /// <param name="lastRead1"> последний считанный из файла fr1 элемент </param>
        /// <param name="lastRead2"> последний считанный из файла fr2 элемент </param>
        void Merge(StreamReader f1_in, StreamReader f2_in, StreamWriter f_out, ref Film lastRead1, ref Film lastRead2)
        {
            bool isSeriesF1 = lastRead1 != null; // файл содержит серию, если он не пуст
            bool isSeriesF2 = lastRead2 != null;
            while (isSeriesF1 && isSeriesF2) // пока что оба файла сожержат серии
            {
                if (lastRead1.CompareTo(lastRead2) <= 0) // элемент первого файла меньше второго
                    isSeriesF1 = AddFromFile(f1_in, f_out, ref lastRead1);
                else
                    isSeriesF2 = AddFromFile(f2_in, f_out, ref lastRead2);
            }
            if (isSeriesF1) // если в первом файле серия не закончилась
                while (AddFromFile(f1_in, f_out, ref lastRead1)) ; // добавляем из него элементы, пока идет серия
            else if (isSeriesF2) // если во втором файле серия не закончилась
                while (AddFromFile(f2_in, f_out, ref lastRead2)) ; // добавляем из него элементы, пока идет серия
        }

        /// <summary>
        /// записываем в файл последний считанный элемент
        /// </summary>
        /// <param name="f_in"> файл, из которого считан lastRead</param>
        /// <param name="f_out"> файл, в который записываем lastRead</param>
        /// <param name="lastRead"> последний считанный элемент из файла </param>
        /// <returns> возвращаем true, если в файле, из которого считали элемент, продолжается текущая серия </returns>
        bool AddFromFile(StreamReader f_in, StreamWriter f_out, ref Film lastRead)
        {
            f_out.WriteLine(lastRead); // записываем последний считанный элемент в файл
            Film lastWritten = lastRead; // запоминаем последний записанный элемент
            string info = f_in.ReadLine() + f_in.ReadLine() + f_in.ReadLine() + f_in.ReadLine(); ; // считывает следующий элемент из файла file_read
            // если элемент отсутсвует, то в info будет записан null
            if (info == "")
            {
                lastRead = null;
                return false; // возвращаем false, т.к. серия заканчивается вместе с файлом
            }
            // иначе запоминаем последний считанный элемент
            lastRead = new Film(insertNode(info));
            // если последний считанный > или >= предыдущего, вернется true, 
            // т.к. в файле все еще идет необходимая серия
            // иначе вернется false, т.к. серия закончилась
            return lastRead.CompareTo(lastWritten) >= 0;
        }
    }
}
