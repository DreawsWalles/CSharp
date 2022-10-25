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
        string Filename;
        Trie Tree;
        public FrmMain()
        {
            InitializeComponent();
            Tree = new Trie();
        }

        private void FileToTree(string text)
        {
            char[] split = { '\r', '\n' };
            string[] result = text.Split(split);
            foreach (string element in result)
                if (element != "")
                    Tree.Add(element);
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PrintTree()
        {
            textBox1.Text = "";
            textBox1 = Tree.Print(textBox1);
        }

        private void AddWords()
        {
            textBox2.Text = "";
            foreach (string word in Tree)
                textBox2.Text += word + "\r\n";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Filename = openFileDialog1.FileName;
            string fileText = File.ReadAllText(Filename);
            FileToTree(fileText);
            PrintTree();
            AddWords();
            MessageBox.Show("Файл открыт", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter file = new StreamWriter(File.OpenWrite(Filename));
            foreach (string element in Tree)
                file.WriteLine(element);
            file.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Filename = saveFileDialog1.FileName;
            StreamWriter file = new StreamWriter(File.OpenWrite(Filename));
            foreach (string element in Tree)
                file.WriteLine(element);
            file.Close();
            MessageBox.Show("Файл сохранен", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInput form = new FrmInput();
            form.ShowDialog();
            if (form.DialogResult != DialogResult.OK)
                return;
            Tree.Add(form.Word);
            PrintTree();
            AddWords();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInput form = new FrmInput();
            form.ShowDialog();
            if (form.DialogResult != DialogResult.OK)
                return;
            if (!Tree.Contains(form.Word))
            {
                MessageBox.Show("Данного слова не найдено", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Tree.Delete(form.Word);
            PrintTree();
            AddWords();
        }

        private void containsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInput form = new FrmInput();
            form.ShowDialog();
            if (form.DialogResult != DialogResult.OK)
                return;
            if (!Tree.Contains(form.Word))
            {
                MessageBox.Show("Данного слова не найдено", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Данное слово найдено", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void taskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInput form = new FrmInput();
            form.ShowDialog();
            if (form.DialogResult != DialogResult.OK)
                return;
            MessageBox.Show(Tree.GetCountOfTaskWords(form.Word).ToString(), "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }
    }
}
