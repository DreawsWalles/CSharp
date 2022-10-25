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
    public partial class FormInitGuide : Form
    {
        private enum Place { Alphabet = 1, Value = 2};
        private enum Action { Add = 1, Edit = 2};
        private int place = 0;
        private int action = 0;
        public Guide Guide { get; set; }
        public FormInitGuide(Doing doing, IPublication publication)
        {
            InitializeComponent();
            Guide = (Guide)publication;
            foreach(string s in Guide.ValueFirstLevel.Keys)
                lbValueAlphabet.Items.Add(s);
            place = 0;
            action = 0;
        }

        private void FormInitGuide_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 34, Size.Height - 44);
            tableLayoutPanel2.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel3.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel4.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel5.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel6.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel7.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel8.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel9.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);

            tableLayoutPanel1.RowStyles[2].Height = 0;

            pbAddValueFirst.Enabled = false;
            pbAddValueFirst.Image = Properties.Resources.add_gray;
            pbEditValueFirst.Enabled = false;
            pbEditValueFirst.Image = Properties.Resources.edit_gray;
            pbRemoveValueFirst.Enabled = false;
            pbRemoveValueFirst.Image = Properties.Resources.close_gray;
            pbClearValueFirst.Enabled = false;
            pbClearValueFirst.Image = Properties.Resources.Clear_gray;

            pbEditValueScnd.Enabled = false;
            pbEditValueScnd.Image = Properties.Resources.accept_gray;
            pbRemoveValueScnd.Enabled = false;
            pbRemoveValueScnd.Image = Properties.Resources.close_gray;

            tbValueScnd.Enabled = false;

            btnAdd.Enabled = false;

            tbNameGuide.ForeColor = Color.Gray;
        }

        private void pbAddAlphabet_Click(object sender, EventArgs e)
        {
            place = (int)Place.Alphabet;
            action = (int)Action.Add;
            tableLayoutPanel1.RowStyles[2].Height = 38;
            tableLayoutPanel1.RowStyles[2].SizeType = SizeType.Absolute;
            tableLayoutPanel1.RowStyles[3].Height = 0;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            place = 0;
            action = 0;
            tableLayoutPanel1.RowStyles[2].Height = 0;
            tableLayoutPanel1.RowStyles[3].SizeType = SizeType.Absolute;
            tableLayoutPanel1.RowStyles[3].Height = 35;
            lbValueAlphabet.Enabled = true;
        }

        private void pbAddValueFirst_Click(object sender, EventArgs e)
        {
            place = (int)Place.Value;
            action = (int)Action.Add;
            tableLayoutPanel1.RowStyles[2].Height = 38;
            tableLayoutPanel1.RowStyles[2].SizeType = SizeType.Absolute;
            tableLayoutPanel1.RowStyles[3].Height = 0;
        }

        private void pbEditAlphabet_Click(object sender, EventArgs e)
        {
            place = (int)Place.Alphabet;
            action = (int)Action.Edit;
            tableLayoutPanel1.RowStyles[2].Height = 38;
            tableLayoutPanel1.RowStyles[2].SizeType = SizeType.Absolute;
            tableLayoutPanel1.RowStyles[3].Height = 0;

            tbValue.Text = Guide.Content[lbValueAlphabet.SelectedIndex];
            lbValueAlphabet.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(action == (int)Action.Add)
            {
                if (place == (int)Place.Alphabet)
                {
                    try
                    {
                        Guide.AddAlphabet(tbValue.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    lbValueAlphabet.Items.Clear();
                    foreach (string s in Guide.ValueFirstLevel.Keys)
                        lbValueAlphabet.Items.Add(s);
                }
                else
                {
                    try
                    {
                        Guide.AddFirstlevel(Guide.Content[lbValueAlphabet.SelectedIndex], tbValue.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    lbValueFirst.Items.Clear();
                    foreach (string s in Guide.ValueSecondLevel.Keys)
                        lbValueFirst.Items.Add(s);
                }
            }
            else
            {
                if (place == (int)Place.Alphabet)
                {
                    try
                    {
                        Guide.EditAplhabet(Guide.Content[lbValueAlphabet.SelectedIndex], tbValue.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    lbValueAlphabet.Items.Clear();
                    foreach (string s in Guide.ValueFirstLevel.Keys)
                        lbValueAlphabet.Items.Add(s);
                }
                else
                {
                    try
                    {
                        Guide.EditFirstlevel(lbValueFirst.Text, tbValue.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    tbValue.Text = "";
                    place = 0;
                    action = 0;
                    tableLayoutPanel1.RowStyles[2].Height = 0;
                    tableLayoutPanel1.RowStyles[3].SizeType = SizeType.Absolute;
                    tableLayoutPanel1.RowStyles[3].Height = 35;
                    lbValueAlphabet.Enabled = true;
                    lbValueFirst.Enabled = true;
                    lbValueFirst.Items.Clear();
                    List<string> tmp = Guide.ValueFirstLevel[Guide.Content[lbValueAlphabet.SelectedIndex]];
                    foreach (string s in tmp)
                        lbValueFirst.Items.Add(s);
                }
            }
            tbValue.Text = "";
            place = 0;
            action = 0;
            tableLayoutPanel1.RowStyles[2].Height = 0;
            tableLayoutPanel1.RowStyles[3].SizeType = SizeType.Absolute;
            tableLayoutPanel1.RowStyles[3].Height = 35;
            lbValueAlphabet.Enabled = true;
        }

        private void lbValueAlphabet_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbValueFirst.Items.Clear();
            List<string> tmp = Guide.ValueFirstLevel[Guide.Content[lbValueAlphabet.SelectedIndex]];
            pbAddValueFirst.Enabled = true;
            pbAddValueFirst.Image = Properties.Resources.add;
            if(tmp.Count > 0)
            {
                foreach(string s in tmp)
                    lbValueFirst.Items.Add(s);
            }
            else
            {
                pbEditValueFirst.Enabled = false;
                pbEditValueFirst.Image = Properties.Resources.edit_gray;
                pbRemoveValueFirst.Enabled = false;
                pbRemoveValueFirst.Image = Properties.Resources.close_gray;
                pbClearValueFirst.Enabled = false;
                pbClearValueFirst.Image = Properties.Resources.Clear_gray;

                pbEditValueScnd.Enabled = false;
                pbEditValueScnd.Image = Properties.Resources.accept_gray;
                pbRemoveValueScnd.Enabled = false;
                pbRemoveValueScnd.Image = Properties.Resources.close_gray;
                tbValueScnd.Enabled = false;
                tbValueScnd.Text = "";
            }
            place = 0;
            action = 0;
            tableLayoutPanel1.RowStyles[2].Height = 0;
            tableLayoutPanel1.RowStyles[3].SizeType = SizeType.Absolute;
            tableLayoutPanel1.RowStyles[3].Height = 35;
            lbValueAlphabet.Enabled = true;
        }

        private void lbValueFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbValueFirst.SelectedIndex != -1)
            {
                tbValueScnd.Clear();
                pbEditValueFirst.Enabled = true;
                pbEditValueFirst.Image = Properties.Resources.edit;
                pbClearValueFirst.Enabled = true;
                pbClearValueFirst.Image = Properties.Resources.Clear;
                pbRemoveValueFirst.Enabled = true;
                pbRemoveValueFirst.Image = Properties.Resources.close;
                tbValueScnd.Enabled = true;
                tbValueScnd.Text = Guide.ValueSecondLevel[lbValueFirst.Text];

                pbEditValueScnd.Enabled = true;
                pbEditValueScnd.Image = Properties.Resources.accept;
                pbRemoveValueScnd.Enabled = true;
                pbRemoveValueScnd.Image = Properties.Resources.close;
            }
        }

        private void pbClearAlphabet_Click(object sender, EventArgs e)
        {
            pbEditValueFirst.Enabled = false;
            pbEditValueFirst.Image = Properties.Resources.edit_gray;
            pbRemoveValueFirst.Enabled = false;
            pbRemoveValueFirst.Image = Properties.Resources.close_gray;
            pbClearValueFirst.Enabled = false;
            pbClearValueFirst.Image = Properties.Resources.Clear_gray;
            try
            {
                Guide.ClearAlphabet(Guide.Content[lbValueAlphabet.SelectedIndex]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tbValue.Text = "";
            place = 0;
            action = 0;
            tableLayoutPanel1.RowStyles[2].Height = 0;
            tableLayoutPanel1.RowStyles[3].SizeType = SizeType.Absolute;
            tableLayoutPanel1.RowStyles[3].Height = 35;
            lbValueAlphabet.Enabled = true;
            lbValueFirst.Items.Clear();
        }

        private void pbRemoveAlphabet_Click(object sender, EventArgs e)
        {
            pbAddValueFirst.Enabled = false;
            pbAddValueFirst.Image = Properties.Resources.add_gray;
            pbEditValueFirst.Enabled = false;
            pbEditValueFirst.Image = Properties.Resources.edit_gray;
            pbRemoveValueFirst.Enabled = false;
            pbRemoveValueFirst.Image = Properties.Resources.close_gray;
            pbClearValueFirst.Enabled = false;
            pbClearValueFirst.Image = Properties.Resources.Clear_gray;
            try
            {
                Guide.RemoveAlphabet(Guide.Content[lbValueAlphabet.SelectedIndex]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tbValue.Text = "";
            place = 0;
            action = 0;
            tableLayoutPanel1.RowStyles[2].Height = 0;
            tableLayoutPanel1.RowStyles[3].SizeType = SizeType.Absolute;
            tableLayoutPanel1.RowStyles[3].Height = 35;
            lbValueAlphabet.Enabled = true;
            lbValueFirst.Items.Clear();
            lbValueAlphabet.Items.Clear();
            foreach (string s in Guide.ValueFirstLevel.Keys)
                lbValueAlphabet.Items.Add(s);
        }

        private void pbEditValueFirst_Click(object sender, EventArgs e)
        {
            place = (int)Place.Value;
            action = (int)Action.Edit;
            tableLayoutPanel1.RowStyles[2].Height = 38;
            tableLayoutPanel1.RowStyles[2].SizeType = SizeType.Absolute;
            tableLayoutPanel1.RowStyles[3].Height = 0;

            tbValue.Text = lbValueFirst.Text;
            lbValueAlphabet.Enabled = false;
            lbValueFirst.Enabled = false;
        }

        private void pbRemoveValueScnd_Click(object sender, EventArgs e)
        {
            tbValueScnd.Text = "";
        }

        private void pbEditValueScnd_Click(object sender, EventArgs e)
        {
            try
            {
                Guide.AddSecondlevel(lbValueFirst.Text, tbValueScnd.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void pbClearValueFirst_Click(object sender, EventArgs e)
        {
            try
            {
                Guide.ClearFirstlevel(lbValueFirst.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            pbEditValueScnd.Enabled = false;
            pbEditValueScnd.Image = Properties.Resources.accept_gray;
            pbRemoveValueScnd.Enabled = false;
            pbRemoveValueScnd.Image = Properties.Resources.close_gray;

            tbValueScnd.Enabled = false;
            tbValueScnd.Text = "";

        }

        private void pbRemoveValueFirst_Click(object sender, EventArgs e)
        {
            try
            {
                Guide.RemoveFirstlevel(lbValueFirst.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lbValueFirst.Items.Clear();
            foreach (string s in Guide.ValueFirstLevel[lbValueAlphabet.Text])
                lbValueFirst.Items.Add(s);
            pbEditValueScnd.Enabled = false;
            pbEditValueScnd.Image = Properties.Resources.accept_gray;
            pbRemoveValueScnd.Enabled = false;
            pbRemoveValueScnd.Image = Properties.Resources.close_gray;

            tbValueScnd.Enabled = false;
            tbValueScnd.Text = "";
        }

        private void tbNameGuide_Enter(object sender, EventArgs e)
        {
            if(tbNameGuide.Text.Trim() == "Название справочника...")
            {
                tbNameGuide.Text = "";
                tbNameGuide.ForeColor = Color.Black;
            }
        }

        private void tbNameGuide_Leave(object sender, EventArgs e)
        {
            if (tbNameGuide.Text.Trim() == "")
            {
                tbNameGuide.Text = "Название справочника...";
                tbNameGuide.ForeColor = Color.Gray;
                btnAdd.Enabled = false;
            }
            else
                btnAdd.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Guide.NamePublication = tbNameGuide.Text;
            Close();
        }
    }
}
