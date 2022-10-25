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
    public partial class FrmLoadOrCreateFile : Form
    {
        public Button BtnOpen { get; set; }
        public Button BtnCreate { get; set; }
        public Button BtnCansel { get; set; }
        public Button BtnChar { get; set; }
        public Button BtnDouble { get; set; }
        public Button BtnString { get; set; }
        public Button BtnInt { get; set; }
        public Button BtnMyType { get; set; }
        public Button BtnFloat { get; set; }
        public Button BtnColor { get; set; }
        public Button BtnRu { get; set; }
        public Button BtnEn { get; set; }
        public Label LblTitle { get; set; }
        public TextBox TextBox { get; set; }
        public ListBox listBox { get; set; }
        public Color SelectedTypeColor { get; set; }
        public Color UnSelectedTypeColor { get; set; }
        public Color ColorTextInput { get; set; }
        public Color ColorTextInputWait { get; set; }
        public Color EnterSelectItem { get; set; }
        public Color LeaveSeletcItem { get; set; }
        public Color EnterUnSelectItem { get; set; }
        public Color LeaveUnSelectItem { get; set; }
        public string textInput { get; set; }
        /// <summary>
        /// [0] - ошибка при открытии
        /// [1] - ошибка при создании
        /// [2] - Открыть файл?
        /// </summary>
        public string[] textError { get; set; }
        /// <summary>
        /// [0] - название уведомления (ошибка)
        /// [1] - название уведомления (Уведомление)
        /// </summary>
        public string[] Titles { get; set; }
        public int type { get; set; }
        public string closeFormTitle { get; set; }
        public string closeFormMessage { get; set; }
        string Name;
        string path;
        bool ok;

        Settings set;
        History history;
        bool IsEnglish;
        int DesignIsdefault;

        Size size;
        public FrmLoadOrCreateFile()
        {
            InitializeComponent();
            type = -1;
            BtnRu = buttonRu;
            BtnEn = buttonEn;
            BtnColor = buttonColor;
            listBox = listBox1;
            TextBox = textBox1;
            BtnOpen = buttonOpen;
            BtnCreate = buttonCreate;
            BtnCansel = buttonCansel;
            BtnChar = button_char;
            BtnDouble = button_double;
            BtnString = button_string;
            BtnInt = button_int;
            BtnMyType = button_MyType;
            BtnFloat = button_Float;
            LblTitle = labelTitle;
            textError = new string[3];
            Titles = new string[2];
            size = Size;

            set = new Settings();
            IsEnglish = set.Node.IsEnglish;
            DesignIsdefault = set.Node.DesignIsDefault;
            history = new History(IsEnglish);
            history.LoadListBox(ref listBox1);
            listBox1.SelectedIndex = 0;
            listBox1.DoubleClick += ListBoxItem_DoubleClick;

            
            Localization.LocalFrmLoadOrCreate(this, IsEnglish);
            Designer.DesignerFrmLoadOrCreateFile(this, DesignIsdefault);

            TextBox.Text = textInput;
            TextBox.ForeColor = ColorTextInputWait;
            buttonCreate.Enabled = false;

            ok = false;


            MinimumSize = Size;
            FrmLoadOrCreateFile_SizeChanged(this, null);

            buttonColor.BackColor = Color.FromArgb(45, 45, 48);
            listBox1.DrawMode = DrawMode.OwnerDrawFixed;
            listBox1.SelectedIndexChanged += new EventHandler(listBox_SelectedIndexChanged);
            button_char.MouseClick += buttonType_MouseClick;
            button_Float.MouseClick += buttonType_MouseClick;
            button_double.MouseClick += buttonType_MouseClick;
            button_string.MouseClick += buttonType_MouseClick;
            button_int.MouseClick += buttonType_MouseClick;
            button_MyType.MouseClick += buttonType_MouseClick;

            button_char.MouseEnter += buttonType_MouseEnter;
            button_Float.MouseEnter += buttonType_MouseEnter;
            button_double.MouseEnter += buttonType_MouseEnter;
            button_string.MouseEnter += buttonType_MouseEnter;
            button_int.MouseEnter += buttonType_MouseEnter;
            button_MyType.MouseEnter += buttonType_MouseEnter;

            button_char.MouseLeave += buttonType_MouseLeave;
            button_Float.MouseLeave += buttonType_MouseLeave;
            button_double.MouseLeave += buttonType_MouseLeave;
            button_string.MouseLeave += buttonType_MouseLeave;
            button_int.MouseLeave += buttonType_MouseLeave;
            button_MyType.MouseLeave += buttonType_MouseLeave;
        }

        private void buttonType_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.BackColor == EnterUnSelectItem)
                button.BackColor = EnterSelectItem;
            else
                button.BackColor = EnterUnSelectItem;
        }

        private void buttonType_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.BackColor == EnterSelectItem)
                button.BackColor = LeaveSeletcItem;
            else
                button.BackColor = LeaveUnSelectItem;
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Invalidate();
        }
        private void buttonType_MouseClick(object sender, EventArgs e)
        {
            foreach (object element in Controls)
            {
                try
                {
                    Button button = (Button)element;
                    if (button.BackColor == SelectedTypeColor)
                        button.BackColor = UnSelectedTypeColor;
                }
                catch
                { }
            }
            buttonCansel.BackColor = EnterUnSelectItem;
            buttonOpen.BackColor = EnterUnSelectItem;
            buttonRu.BackColor = EnterUnSelectItem;
            buttonEn.BackColor = EnterUnSelectItem;
            buttonCreate.BackColor = EnterUnSelectItem;
            Button btn = (Button)sender;
            if (type == -1)
                buttonCreate.Enabled = true;
            if (type != Convert.ToInt32(btn.Tag))
            {
                btn.BackColor = EnterSelectItem;
                type = Convert.ToInt32(btn.Tag);
            }
            else
            {
                btn.BackColor = UnSelectedTypeColor;
                buttonCreate.Enabled = false;
                type = -1;
            }
        }

        private void ListBoxItem_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show(textError[2] + " " + history[listBox1.SelectedIndex].Name + " ?", Titles[1],
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DialogResult = DialogResult.OK;
                    history.Update(history[listBox1.SelectedIndex]);
                    Close();
                }
            }
        }

        private void ButtonCansel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
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
                Name = dialog.FileName;
                node.Name = dialog.FileName;
                node.Date = Convert.ToString(DateTime.Now);
                path = node.Path;
                StreamReader file = new StreamReader(File.Open(node.Path, FileMode.Open));
                try
                {
                    type = Convert.ToInt32(file.ReadLine());
                    history.Add(node);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch
                {
                    MessageBox.Show(textError[0], Titles[1], MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                file.Close();
            }
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            FrmColor frm = new FrmColor();
            frm.ShowDialog();
            set.Refresh(new SettingsNode(IsEnglish, frm.designIsDefault));
            DesignIsdefault = frm.designIsDefault;
            Designer.DesignerFrmLoadOrCreateFile(this, DesignIsdefault);
        }

        private void buttonRu_Click(object sender, EventArgs e)
        {
            IsEnglish = false;
            Localization.LocalFrmLoadOrCreate(this, IsEnglish);
            set.Refresh(new SettingsNode(IsEnglish, DesignIsdefault));
        }

        private void buttonEn_Click(object sender, EventArgs e)
        {
            IsEnglish = true;
            Localization.LocalFrmLoadOrCreate(this, IsEnglish);
            set.Refresh(new SettingsNode(IsEnglish, DesignIsdefault));
        }
        

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text != textInput)
                return;
            textBox1.Text = "";
            textBox1.ForeColor = ColorTextInput;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                textBox1.Text = textInput;
                TextBox.ForeColor = ColorTextInputWait;
                ok = false;
            }
            else
            {
                Name = textBox1.Text;
                ok = true;
            }
        }

        private bool CheckFileName(string fileName)
        {
            int size = fileName.Length;
            int i = 0;
            while (i < size)
            {
                if ((fileName[i] == '/') || (fileName[i] == '\\') || (fileName[i] == ':') || (fileName[i] == '*') || (fileName[i] == '?') || (fileName[i] == '«') 
                    || (fileName[i] == '<') || (fileName[i] == '>') || (fileName[i] == '|'))
                    return false;
                else
                    i++;
            }
            return true;
        }
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (ok)
            {
                if (!CheckFileName(textBox1.Text))
                {
                    MessageBox.Show(textError[1], Titles[0], MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataHistory n;
                n.Name = textBox1.Text;
                n.Date = Convert.ToString(DateTime.Now);
                string pathname = "Lists/List_" + Name;
                Directory.CreateDirectory(pathname);
                pathname += '\\' + Name + ".bin";
                File.Create(pathname).Close();
                FileInfo file = new FileInfo(pathname);
                n.Path = file.DirectoryName + '\\' + Name + ".bin";
                StreamWriter fileW = new StreamWriter(File.Open(n.Path, FileMode.Open));
                fileW.WriteLine(type);
                fileW.Close();
                history.Add(n);
                path = n.Path;
                Name = n.Name;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show(textError[1], Titles[0], MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void form_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult result = MessageBox.Show(closeFormMessage, closeFormTitle,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    Close();
            }
        }


        private void FrmLoadOrCreateFile_SizeChanged(object sender, EventArgs e)
        {
            buttonCansel.Location = new Point(Size.Width - 335, Size.Height - 85);
            buttonOpen.Location = new Point(Size.Width - 435, Size.Height - 85);
            labelTitle.Location = new Point(labelTitle.Location.X, Size.Height - 83);
            textBox1.Location = new Point(textBox1.Location.X, Size.Height - 85);
            textBox1.Width = TextRenderer.MeasureText(textBox1.Text, textBox1.Font).Width + (Size.Width - size.Width) + 255;
            buttonCreate.Location = new Point(Size.Width - 217, Size.Height - 142);
            button_Float.Location = new Point(Size.Width - 217, Size.Height - 200);
            button_MyType.Location = new Point(Size.Width - 217, Size.Height - 250);
            button_int.Location = new Point(Size.Width - 217, Size.Height - 300);
            button_string.Location = new Point(Size.Width - 217, Size.Height - 350);
            button_double.Location = new Point(Size.Width - 217, Size.Height - 400);
            button_char.Location = new Point(Size.Width - 217, Size.Height - 450);
            buttonEn.Location = new Point(Size.Width - 53, buttonEn.Location.Y);
            buttonRu.Location = new Point(Size.Width - 87, buttonRu.Location.Y);
            buttonColor.Location = new Point(Size.Width - 117, buttonColor.Location.Y);
            listBox1.Size = new Size(Size.Width - 270, Size.Height - 120);
            history.LoadListBox(ref listBox1);
        }
    }
}
