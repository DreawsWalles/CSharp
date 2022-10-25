using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskThree
{
    public partial class FormChoiceAlphabet : Form
    {
        public string[] Alphabet { get; set; }

        private List<string[]> createAlphabets;
        public FormChoiceAlphabet()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void FormChoiceAlphabet_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 34, Size.Height - 40);
            tableLayoutPanel2.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height - 15);
            tableLayoutPanel3.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);

            tableLayoutPanel3.ColumnStyles[0].Width = 0;
            tableLayoutPanel3.ColumnStyles[0].SizeType = SizeType.Absolute;
            tableLayoutPanel3.ColumnStyles[1].Width = 0;
            tableLayoutPanel3.ColumnStyles[1].SizeType = SizeType.Absolute;
            comboBox1.Visible = false;
            tableLayoutPanel3.ColumnStyles[2].Width = 100;
            tableLayoutPanel3.ColumnStyles[2].SizeType = SizeType.Percent;

            btnAccept.Enabled = false;

            createAlphabets = new List<string[]>();
        }

        private void FormChoiceAlphabet_Resize(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 34, Size.Height - 40);
            tableLayoutPanel2.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height - 15);
            tableLayoutPanel1.Size = new Size(Size.Width - 34, Size.Height - 40);
            tableLayoutPanel2.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height - 15);
            tableLayoutPanel3.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void rbtnEnglish_CheckedChanged(object sender, EventArgs e)
        {
            rbtnCreate.Checked = false;
            Alphabet = rbtnEnglish.Checked ?
                new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
                                      "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"} :
                null;
            btnAccept.Enabled = Alphabet == null ? false : true;

        }

        private void rbtnRussian_CheckedChanged(object sender, EventArgs e)
        {
            rbtnCreate.Checked = false;
            Alphabet = rbtnRussian.Checked ?
                new string[] { "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я",
                               "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я"} :
                null;
            btnAccept.Enabled = Alphabet == null ? false : true;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FormInitAlphabet frm = new FormInitAlphabet();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                string[] tmp = frm.Alphabet.ToArray();
                string str = "";
                foreach(string s in tmp)
                    str += s + " ";
                createAlphabets.Add(tmp);
                comboBox1.Items.Add(str);
                comboBox1.SelectedIndex = 0;
                rbtnCreate.Checked = true;
                rbtnEnglish.Checked = false;
                rbtnRussian.Checked = false;
                tableLayoutPanel3.ColumnStyles[0].Width = 35;
                tableLayoutPanel3.ColumnStyles[0].SizeType = SizeType.Absolute;
                tableLayoutPanel3.ColumnStyles[1].Width = 50;
                tableLayoutPanel3.ColumnStyles[1].SizeType = SizeType.Percent;
                comboBox1.Visible = true;
                tableLayoutPanel3.ColumnStyles[2].Width = 50;
                tableLayoutPanel3.ColumnStyles[2].SizeType = SizeType.Percent;
                Alphabet = tmp;
                btnAccept.Enabled = true;
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            rbtnCreate.Checked = true;
            rbtnEnglish.Checked = false;
            rbtnRussian.Checked = false;
            Alphabet = createAlphabets[comboBox1.SelectedIndex];
            btnAccept.Enabled = true;
        }

        private void rbtnCreate_CheckedChanged(object sender, EventArgs e)
        {
            rbtnEnglish.Checked = false;
            rbtnRussian.Checked = false;
            Alphabet = createAlphabets[comboBox1.SelectedIndex];
            btnAccept.Enabled = true;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
