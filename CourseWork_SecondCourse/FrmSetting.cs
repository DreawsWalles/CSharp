using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class FrmSetting : Form
    {
        public bool isEnglish { get; private set; }
        public int designIsDefault { get; private set; }
        public Label textColor { get; set; }
        public Label textLanguage { get; set; }
        public Button BtnAccept { get; set; }
        public Button BtnCancel { get; set; }
        public ComboBox ComboBoxColor { get; set; }
        public ComboBox ComboBoxLanguage { get; set; }
        public Color ColorHover { get; set; }
        public Color ColorText { get; set; }
        public Color mainColor { get; set; }
        public string closeFormTitle { get; set; }
        public string closeFormMessage { get; set; }
        Settings set;
        public FrmSetting()
        {
            InitializeComponent();
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox2.DrawMode = DrawMode.OwnerDrawFixed;
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            MinimumSize = Size;
            MaximumSize = Size;
            set = new Settings();
            isEnglish = set.Node.IsEnglish;
            designIsDefault = set.Node.DesignIsDefault;
            ComboBoxColor = comboBox1;
            ComboBoxLanguage = comboBox2;
            textColor = label_color;
            textLanguage = label_language;
            BtnAccept = button_accept;
            BtnCancel = button_cancel;
            Designer.DesignerFrmSetting(this, designIsDefault);
            Localization.LocalFrmSetting(this, isEnglish);
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = designIsDefault;
            comboBox2.SelectedIndex = Convert.ToInt32(isEnglish);
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            isEnglish = comboBox2.SelectedIndex == 1;
            designIsDefault = comboBox1.SelectedIndex;
            Close();
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBox1.Invalidate();
            isEnglish = comboBox2.SelectedIndex == 1;
            Localization.LocalFrmSetting(this, isEnglish);
        }

        private void comboBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                var combo = sender as ComboBox;

                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    e.Graphics.FillRectangle(new SolidBrush(ColorHover), e.Bounds);
                else
                    e.Graphics.FillRectangle(new SolidBrush(mainColor), e.Bounds);

                e.Graphics.DrawString(combo.Items[e.Index].ToString(),
                                              e.Font,
                                              new SolidBrush(ColorText),
                                              new Point(e.Bounds.X, e.Bounds.Y));
            }
            catch { }
        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                var combo = sender as ComboBox;

                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    e.Graphics.FillRectangle(new SolidBrush(ColorHover), e.Bounds);
                else
                    e.Graphics.FillRectangle(new SolidBrush(mainColor), e.Bounds);

                e.Graphics.DrawString(combo.Items[e.Index].ToString(),
                                              e.Font,
                                              new SolidBrush(ColorText),
                                              new Point(e.Bounds.X, e.Bounds.Y));
            }
            catch { }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBox2.Invalidate();
            designIsDefault = comboBox1.SelectedIndex;
            Designer.DesignerFrmSetting(this, designIsDefault);
        }

        private void FrmSetting_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                {
                    DialogResult result = MessageBox.Show(closeFormMessage, closeFormTitle,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                        Close();
                }
            }
            if (e.KeyData == Keys.Enter)
            {
                button_accept_Click(sender, null);
            }

        }

        private void button_accept_Click(object sender, EventArgs e)
        {
            isEnglish = comboBox2.SelectedIndex == 1;
            designIsDefault = comboBox1.SelectedIndex;
            Close();
        }
    }
}
