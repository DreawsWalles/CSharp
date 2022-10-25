using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TaskThree.FormMain;

namespace TaskThree
{
    public partial class FormInitEncyclopedia : Form
    {
        public Encyclopedia Encyclopedia { get; set; }
        private List<bool> checkedItems;

        private Doing doing;
        public FormInitEncyclopedia(Doing doing, IPublication publication = null)
        {
            InitializeComponent();
            Encyclopedia = new Encyclopedia();
            if (publication != null)
            {
                tbName.Text = publication.NamePublication;
                Encyclopedia.NamePublication = publication.NamePublication;
                tbName.ForeColor = Color.Black;
                List<string> tmp = publication.GetContent();
                foreach(string node in tmp)
                    checkedListBox1.Items.Add(node);
                Encyclopedia.Content = tmp;
            }
            switch(doing)
            {
                case Doing.Add:
                    btnAddNode.Text = "Добавить энциклопедию";
                    btnAddNode.Enabled = false;
                    break;
                case Doing.View:
                    btnAdd.Visible = false;
                    btnAddNode.Text = "Закрыть";
                    btnAddNode.Enabled = true;
                    break;
                case Doing.Edit:
                    btnAddNode.Text = "Сохранить";
                    btnAddNode.Enabled = true;
                    break;
            }
            this.doing = doing;
        }

        private void FormInitEncyclopedia_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 34, Size.Height - 44);
            tableLayoutPanel2.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel3.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel4.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel5.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel6.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);

            tableLayoutPanel1.RowStyles[2].Height = 0;

            tableLayoutPanel1.RowStyles[1].Height = 100;
            tableLayoutPanel1.RowStyles[1].SizeType = SizeType.Percent;

            tableLayoutPanel1.RowStyles[4].Height = 0;
            tableLayoutPanel1.RowStyles[5].Height = 0;

            if (doing == Doing.Add)
            {
                tbName.ForeColor = Color.Gray;
                tbNamePublication.ForeColor = Color.Gray;
                tbContent.ForeColor = Color.Gray;
            }

            checkedItems = new List<bool>();
            btnView.Visible = false;
        }

        private void FormInitEncyclopedia_Resize(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 34, Size.Height - 44);
            tableLayoutPanel2.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel3.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel4.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel5.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel6.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
        }

        private void tbName_Enter(object sender, EventArgs e)
        {
            if(tbName.Text.Trim() == "Введите название...")
            {
                tbName.Text = "";
                tbName.ForeColor = Color.Black;
            }
        }

        private void tbName_Leave(object sender, EventArgs e)
        {
            if(tbName.Text.Trim() == "")
            {
                tbName.Text = "Введите название...";
                tbName.ForeColor = Color.Gray;
                btnAddNode.Enabled = false;
            }
            else 
                btnAddNode.Enabled = true;
        }

        private void btnCansel_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.RowStyles[2].Height = 0;

            tableLayoutPanel1.RowStyles[1].Height = 100;
            tableLayoutPanel1.RowStyles[1].SizeType = SizeType.Percent;

            tableLayoutPanel1.RowStyles[0].Height = 40;
            tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Absolute;

            tableLayoutPanel1.RowStyles[3].Height = 35;
            tableLayoutPanel1.RowStyles[3].SizeType = SizeType.Absolute;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.RowStyles[2].Height = 100;
            tableLayoutPanel1.RowStyles[2].SizeType = SizeType.Percent;
            tableLayoutPanel1.RowStyles[0].Height = 0;
            tableLayoutPanel1.RowStyles[3].Height = 0;
            tableLayoutPanel1.RowStyles[4].Height = 0;

            tableLayoutPanel1.RowStyles[1].Height = 0;
            tableLayoutPanel4.RowStyles[2].Height = 40;
            tableLayoutPanel4.RowStyles[2].SizeType = SizeType.Absolute;

            tbNamePublication.Text = "Введите название статьи...";
            tbContent.Text = "Введите статью...";
            tbNamePublication.ForeColor = Color.Gray;
            tbContent.ForeColor = Color.Gray;

            btnSave.Text = "Добавить";
        }

        private void tbNamePublication_Enter(object sender, EventArgs e)
        {
            if (tbNamePublication.Text.Trim() == "Введите название статьи...")
            {
                tbNamePublication.Text = "";
                tbNamePublication.ForeColor = Color.Black;
            }
        }

        private void tbNamePublication_Leave(object sender, EventArgs e)
        {
            if (tbNamePublication.Text.Trim() == "")
            {
                tbNamePublication.Text = "Введите название статьи...";
                tbNamePublication.ForeColor = Color.Black;
            }

        }

        private void tbContent_Enter(object sender, EventArgs e)
        {
            if(tbContent.Text.Trim() == "Введите статью...")
            {
                tbContent.Text = "";
                tbContent.ForeColor = Color.Black;
            }
        }

        private void tbContent_Leave(object sender, EventArgs e)
        {
            if(tbContent.Text.Trim() == "")
            {
                tbContent.Text = "Введите статью...";
                tbContent.ForeColor = Color.Gray;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(tbNamePublication.Text.Trim() == "Введите название статьи...")
            {
                MessageBox.Show("Отсутсвует название статьи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (btnSave.Text == "Добавить")
            {
                try
                {
                    Encyclopedia.Add(tbNamePublication.Text, tbContent.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                List<string> tmp = Encyclopedia.GetNamesPublications();
                checkedListBox1.Items.Clear();
                foreach (string name in tmp)
                    checkedListBox1.Items.Add(name);
                checkedItems.Add(false);
            }
            else
            {
                try
                {
                    Encyclopedia.Add(tbNamePublication.Text, tbContent.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                checkedItems[checkedListBox1.SelectedIndex] = false;
                List<string> tmp = Encyclopedia.GetNamesPublications();
                checkedListBox1.Items.Clear();
                foreach (string name in tmp)
                    checkedListBox1.Items.Add(name);
                checkedItems.Add(false);
            }

            tableLayoutPanel1.RowStyles[2].Height = 0;

            tableLayoutPanel1.RowStyles[1].Height = 100;
            tableLayoutPanel1.RowStyles[1].SizeType = SizeType.Percent;

            tableLayoutPanel1.RowStyles[0].Height = 40;
            tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Absolute;

            tableLayoutPanel1.RowStyles[3].Height = 35;
            tableLayoutPanel1.RowStyles[3].SizeType = SizeType.Absolute;
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (doing == Doing.Edit || doing == Doing.Add)
            {
                if (e.NewValue == CheckState.Checked)
                    checkedItems[checkedListBox1.SelectedIndex] = true;
                else
                    checkedItems[checkedListBox1.SelectedIndex] = false;
                if (checkedItems.Contains(true))
                {
                    tableLayoutPanel1.RowStyles[4].Height = 40;
                    tableLayoutPanel1.RowStyles[4].SizeType = SizeType.Absolute;
                    tableLayoutPanel1.RowStyles[3].Height = 0;
                }
                else
                {
                    tableLayoutPanel1.RowStyles[4].Height = 0;
                    tableLayoutPanel1.RowStyles[3].Height = 35;
                    tableLayoutPanel1.RowStyles[3].SizeType = SizeType.Absolute;
                }
                int countTmp = 0;
                int i = 0;
                while (countTmp <= 1 && i < checkedItems.Count)
                {
                    if (checkedItems[i])
                        countTmp++;
                    i++;
                }
                btnEdit.Enabled = countTmp == 1 ? true : false;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int i = 0;
            while(i < Encyclopedia.CountOfNode)
            {
                if (checkedItems[i])
                {
                    Encyclopedia.Remove(i);
                    checkedListBox1.Items.RemoveAt(i);
                    checkedItems.RemoveAt(i);
                }
                else
                    i++;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.RowStyles[2].Height = 100;
            tableLayoutPanel1.RowStyles[2].SizeType = SizeType.Percent;
            tableLayoutPanel1.RowStyles[0].Height = 0;
            //tableLayoutPanel1.RowStyles[3].Height = 40;
            //tableLayoutPanel1.RowStyles[3].SizeType = SizeType.Absolute;
            tableLayoutPanel4.RowStyles[2].Height = 40;
            tableLayoutPanel4.RowStyles[2].SizeType = SizeType.Absolute;
            tableLayoutPanel1.RowStyles[4].Height = 0;

            tableLayoutPanel1.RowStyles[1].Height = 0;

            int i = 0;
            while (!checkedItems[i] && i < checkedItems.Count)
                i++;
            checkedListBox1.SelectedIndex = i;
            tbNamePublication.Text = Encyclopedia[i];
            tbContent.Text = Encyclopedia.GetValue(i);
            tbName.ForeColor = Color.Black;
            tbContent.ForeColor = Color.Black;

            btnSave.Text = "Сохранить";
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!btnView.Focused)
                btnView.Visible = checkedListBox1.SelectedIndex != -1 ? true : false;
        }

        private void checkedListBox1_Leave(object sender, EventArgs e)
        {
            if (!btnView.Focused)
                checkedListBox1.SelectedIndex = -1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.RowStyles[2].Height = 100;
            tableLayoutPanel1.RowStyles[2].SizeType = SizeType.Percent;
            tableLayoutPanel1.RowStyles[0].Height = 0;
            tableLayoutPanel1.RowStyles[3].Height = 0;
            tableLayoutPanel1.RowStyles[4].Height = 0;
            tableLayoutPanel1.RowStyles[5].Height = 35;
            tableLayoutPanel1.RowStyles[5].SizeType = SizeType.Absolute;
            tableLayoutPanel1.RowStyles[1].Height = 0;
            tableLayoutPanel4.RowStyles[2].Height = 0;

            tbContent.Text = Encyclopedia.GetValue(checkedListBox1.SelectedIndex);
            tbNamePublication.Text = Encyclopedia[checkedListBox1.SelectedIndex];

            tbContent.ForeColor = Color.Black;
            tbNamePublication.ForeColor = Color.Black;
        }

        private void btnCloseNode_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.RowStyles[2].Height = 0;

            tableLayoutPanel1.RowStyles[1].Height = 100;
            tableLayoutPanel1.RowStyles[1].SizeType = SizeType.Percent;

            tableLayoutPanel1.RowStyles[0].Height = 40;
            tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Absolute;

            tableLayoutPanel1.RowStyles[3].Height = 35;
            tableLayoutPanel1.RowStyles[3].SizeType = SizeType.Absolute;

            tableLayoutPanel1.RowStyles[5].Height = 0;
        }

        private void btnAddNode_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Encyclopedia.NamePublication = tbName.Text;
            Close();
        }
    }
}
