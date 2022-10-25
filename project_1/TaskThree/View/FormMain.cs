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
    public partial class FormMain : Form
    {
        List<IPublication> publications;

        public enum Doing { Add = 1, View = 2, Edit = 3}
        public FormMain()
        {
            InitializeComponent();
            
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 34, Size.Height - 44);
            tableLayoutPanel2.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel3.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel5.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);

            publications = new List<IPublication>();
            btnView.Enabled = false;
            btnRemove.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormChoice formChoice = new FormChoice();
            if(formChoice.ShowDialog() == DialogResult.OK)
            {
                switch (formChoice.Choice)
                {
                    case 1:
                        {
                            FormChoiceAlphabet frm = new FormChoiceAlphabet();
                            if(frm.ShowDialog() == DialogResult.OK)
                            {

                                FormInitGuide formInitGuide = new FormInitGuide(Doing.Add,  new Guide(frm.Alphabet));
                                Hide();
                                if(formInitGuide.ShowDialog() == DialogResult.OK)
                                {
                                    publications.Insert(0, formInitGuide.Guide);
                                    lbMain.Items.Clear();
                                    foreach (IPublication publication in publications)
                                        lbMain.Items.Add(publication.ToString());
                                }
                                Show();
                            }
                        }
                        break;
                    case 2:
                        {
                            FormInitEncyclopedia frm = new FormInitEncyclopedia(Doing.Add);
                            Hide();
                            if(frm.ShowDialog() == DialogResult.OK)
                            {
                                publications.Insert(0, frm.Encyclopedia);
                                lbMain.Items.Clear();
                                foreach(IPublication publication in publications)
                                    lbMain.Items.Add(publication.ToString());
                            }
                            Show();
                        }
                        break;
                }
                btnView.Enabled = true;
                btnRemove.Enabled = true;
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 34, Size.Height - 44);
            tableLayoutPanel2.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel3.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel5.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
        }

        private void lbMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbContent.Items.Clear();
            foreach(string s in publications[lbMain.SelectedIndex].GetContent())
                lbContent.Items.Add(s);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbMain.SelectedIndex != -1)
            {
                publications.RemoveAt(lbMain.SelectedIndex);
                lbMain.Items.Clear();
                foreach (IPublication publication in publications)
                    lbMain.Items.Add(publication.ToString());
                btnView.Enabled = publications.Count == 0 ? false : true;
                btnRemove.Enabled = publications.Count == 0 ? false : true;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            Type type = publications[lbMain.SelectedIndex].GetType();
            if (type == typeof(Encyclopedia))
            {
                FormInitEncyclopedia frm = new FormInitEncyclopedia(Doing.Edit, publications[lbMain.SelectedIndex]);
                Hide();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    publications.RemoveAt(lbMain.SelectedIndex);
                    publications.Insert(0, frm.Encyclopedia);
                    lbMain.Items.Clear();
                    foreach (IPublication publication in publications)
                        lbMain.Items.Add(publication.ToString());
                }
                frm.ShowDialog();
                Show();
            }
            else
            {
                FormInitGuide frm = new FormInitGuide(Doing.Edit, publications[lbMain.SelectedIndex]);
                Hide();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    publications.RemoveAt(lbMain.SelectedIndex);
                    publications.Insert(0, frm.Guide);
                    lbMain.Items.Clear();
                    foreach (IPublication publication in publications)
                        lbMain.Items.Add(publication.ToString());
                }
                frm.ShowDialog();
                Show();
            }
        }
    }
}
