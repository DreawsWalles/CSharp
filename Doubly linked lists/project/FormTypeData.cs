using System;
using System.Windows.Forms;
using System.IO;

namespace project
{
    public partial class FormTypeData : Form
    {
        public int realization = 0;
        public int type = 0;
        bool ok = false;
        public DataHistory data = new DataHistory();
        public string path;
        public string nameList;
        public bool mutable = true;
        public FormTypeData()
        {
            InitializeComponent();
            button_bool.Visible = false;
            button_char.Visible = false;
            button_double.Visible = false;
            button_float.Visible = false;
            button_integer.Visible = false;
            button_string.Visible = false;
            button_pred.Visible = false;
            button_mytype.Visible = false;
            button_next.Visible = false;
            name.Text = "Название списка";
            name.ForeColor = System.Drawing.Color.Gray;
            InitListBox();
            MaximumSize = Size;
            MinimumSize = Size;
            button_double.ForeColor = System.Drawing.Color.Thistle;
            button_double.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            button_double.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            button_bool.FlatAppearance.BorderSize = 0;
            button_char.FlatAppearance.BorderSize = 0;
            button_double.FlatAppearance.BorderSize = 0;
            button_float.FlatAppearance.BorderSize = 0;
            button_string.FlatAppearance.BorderSize = 0;
            button_string.ForeColor = System.Drawing.Color.Thistle;
            button_string.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            button_string.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
        }
        private void InitListBox()
        {
            DataNode n;
            string space;
            for (int i = 0; i < data.Count; i++)
            {
                n = data.getNode(i);
                n.date = n.date.Insert(8, "                   ");
                space = "".PadRight(20 - n.name.Length);
                listBox1.Items.Add(n.name + space + n.date);
            }

            
        }
        void SaveNode()
        {
            DataNode n;
            n.name = name.Text;
            n.date = Convert.ToString(DateTime.Now);
            string pathname = "Lists/List_" + nameList;
            Directory.CreateDirectory(pathname);
            pathname += '\\' + nameList + ".bin";
            File.Create(pathname).Close();
            FileInfo file = new FileInfo(pathname);
            n.path = file.DirectoryName + '\\' + nameList + ".bin";
            StreamWriter fileW = new StreamWriter(File.Open(n.path, FileMode.Open));
            fileW.WriteLine("+");
            fileW.WriteLine(type);
            fileW.WriteLine(realization);
            fileW.Close();
            data.Add(n);
            path = n.path;
            nameList = n.name;
        }
        private void button_integer_Click(object sender, EventArgs e)
        {
            if (!ok)
                MessageBox.Show("Введите название списка");
            else
            {
                type = 1;
                SaveNode();
                Close();
            }
        }
        private void button_float_Click(object sender, EventArgs e)
        {
            if (!ok)
                MessageBox.Show("Введите название списка");
            else
            {
                type = 2;
                SaveNode();
                Close();
            }
        }
        private void button_char_Click(object sender, EventArgs e)
        {
            if (!ok)
                MessageBox.Show("Введите название списка");
            else
            {
                type = 3;
                SaveNode();
                Close();
            }
        }

        private void button_double_Click(object sender, EventArgs e)
        {
            if (!ok)
                MessageBox.Show("Введите название списка");
            else
            {
                type = 4;
                SaveNode();
                Close();
            }
        }

        private void button_bool_Click(object sender, EventArgs e)
        {
            if (!ok)
                MessageBox.Show("Введите название списка");
            else
            {
                type = 5;
                SaveNode();
                Close();
            }
        }

        private void button_string_Click(object sender, EventArgs e)
        {
            if (!ok)
                MessageBox.Show("Введите название списка");
            else
            {
                type = 6;
                SaveNode();
                Close();
            }
        }
        private void button_next_Click(object sender, EventArgs e)
        {
            button_pred.Visible = true;
            button_next.Visible = false;
            button_char.Visible = false;
            button_float.Visible = false;
            button_double.Visible = true;
            button_string.Visible = true;
            button_mytype.Visible = true;
            button_bool.Visible = true;
        }

        private void button_pred_Click(object sender, EventArgs e)
        {
            button_pred.Visible = false;
            button_next.Visible = true;
            button_float.Visible = true;
            button_char.Visible = true;
            button_double.Visible = false;
            button_string.Visible = false;
            button_mytype.Visible = false;
            button_bool.Visible = true;
        }

        private void Link_Click(object sender, EventArgs e)
        {
            realization = 1;
            Link.Visible = false;
            Array.Visible = false;
            button_bool.Visible = true;
            button_char.Visible = true;
            button_float.Visible = true;
            button_integer.Visible = true;
            button_next.Visible = true;
        }

        private void Array_Click(object sender, EventArgs e)
        {
            realization = 2;
            Link.Visible = false;
            Array.Visible = false;
            button_bool.Visible = true;
            button_char.Visible = true;
            button_float.Visible = true;
            button_integer.Visible = true;
            button_next.Visible = true;
        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void name_Enter(object sender, EventArgs e)
        {
                name.Text = "";
                name.ForeColor = System.Drawing.Color.Black;
        }

        private void name_Leave(object sender, EventArgs e)
        {
            if (name.TextLength == 0)
            {
                name.Text = "Название списка";
                name.ForeColor = System.Drawing.Color.Gray;
                ok = false;
            }
            else
            {
                ok = true;
                nameList = name.Text;
            }

        }

        private void button_path_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DataNode n;
                n.path = dialog.FileName;
                dialog.FileName = Path.GetFileNameWithoutExtension(dialog.FileName);
                nameList = dialog.FileName;
                n.name = dialog.FileName;
                n.date = Convert.ToString(DateTime.Now);
                data.Add(n);
                path = n.path;
                StreamReader file = new StreamReader(File.Open(n.path, FileMode.Open));
                string s = file.ReadLine();
                if (s == "+")
                    mutable = true;
                else
                    mutable = false;
                type = Convert.ToInt32(file.ReadLine());
                realization = Convert.ToInt32(file.ReadLine());
                file.Close();
                Close();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataNode n = data.getNode(listBox1.SelectedIndex);
            data.Add(n);  
            nameList = n.name;
            path = n.path;
            StreamReader file = new StreamReader(File.Open(n.path, FileMode.Open));
            string s = file.ReadLine();
            if (s == "+")
                mutable = true;
            else
                mutable = false;
            type = Convert.ToInt32(file.ReadLine());
            realization = Convert.ToInt32(file.ReadLine());
            file.Close();
            Close();
        }

        private void FormTypeData_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button_mytype_Click(object sender, EventArgs e)
        {
            if (!ok)
                MessageBox.Show("Введите название списка");
            else
            {
                type = 7;
                SaveNode();
                Close();
            }
        }
    }
}
