using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskFour
{
    public partial class FormMain : Form
    {
        private List<Type> classes;
        private string path;

        private IMoveObject moveObject = null;
        private MethodInfo moveMethod;

        private enum Action
        {
            Empty = 0,
            ChoisePoint = 1,
            ChoiseRoute = 2,
            Passenger = 3
        };
        private int action = (int)Action.Empty;

        private List<object> parametrs = new List<object>();
        public FormMain()
        {
            InitializeComponent();
        }

        public static Point ObjectToPoint(object obj) => (Point)obj;


        private void FormMain_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 34, Size.Height - 44);

            tbPath.ForeColor = Color.Gray;
            tableLayoutPanel3.Visible = false;
            cbMethods.Enabled = false;
            btnRun.Enabled = false;

            List<string> tmp = new List<string>();
            foreach(MethodInfo method in typeof(IMoveObject).GetMethods())
                if(!method.Name.Contains("get_") && !(method.Name.Contains("set_")))
                    tmp.Add(method.Name);
            cbMethods.Items.AddRange(tmp.ToArray());
            tableLayoutPanel1.RowStyles[2].Height = 0;
            tableLayoutPanel1.RowStyles[3].Height = 100;
            tableLayoutPanel1.RowStyles[3].SizeType = SizeType.Percent;

            flowLayoutPanel1.Visible = false;
            panel1.Visible = false;
            InitNet();
        }

        private void InitNet()
        {
            for (int i = 0; i < 4; i++)
            {
                PictureBox t = new PictureBox();
                t.Size = new Size(5, 79);
                flowLayoutPanel1.Controls.Add(t);
                for (int j = 0; j < 9; j++)
                {
                    PictureBox pic = new PictureBox();
                    pic.Click += new EventHandler(ChoicePoint);
                    pic.Size = new Size(79, 79);
                    pic.BorderStyle = BorderStyle.FixedSingle;
                    pic.Tag = $"{i};{j}";
                    flowLayoutPanel1.Controls.Add(pic);
                }
                t = new PictureBox();
                t.Size = new Size(5, 79);
                flowLayoutPanel1.Controls.Add(t);
            }
        }

        private void ChoicePoint(object sender, EventArgs e)
        {
            if (action == (int)Action.ChoisePoint)
                foreach (PictureBox t in flowLayoutPanel1.Controls)
                    if (t.Tag != ((PictureBox)sender).Tag)
                    {
                        t.BackColor = Color.White;
                        parametrs.Remove(t);
                    }
            PictureBox pic = (PictureBox)sender;
            Point tmp = new Point();
            string[] s = ((string)(pic.Tag)).Split(';');
            tmp.Y = Convert.ToInt32(s[0]) * 79;
            tmp.X = Convert.ToInt32(s[1]) * 79;
            if (pic.BackColor == Color.White)
            {
                pic.BackColor = Color.Green;
                parametrs.Add(tmp);
            }
            else
            {
                pic.BackColor = Color.White;
                parametrs.Remove(tmp);
            }
        }

        private void tbPath_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnLoad_Click(null, null);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "dll files (*.dll)|*.dll|All files (*.*)|*.*";
                if(fileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Assembly asm = Assembly.LoadFrom(fileDialog.FileName);
                        List<Type> tmp = new List<Type>();
                        foreach (Type c in asm.GetExportedTypes())
                            if (c.GetInterfaces().Contains(typeof(IMoveObject)) && !c.IsAbstract)
                                tmp.Add(c);
                        if (tmp.Count == 0)
                            throw new Exception("В данной библиотеке нет ни одного класса, который реализует интерфейс");
                        foreach (Type c in tmp)
                            cbNameClasses.Items.Add(c.Name);
                        string s = Path.GetFileName(fileDialog.FileName);
                        tbPath.Text = s.Remove(s.Length - 4, 4);
                        tbPath.ForeColor = Color.Black;
                        classes = tmp;
                        tableLayoutPanel3.Visible = true;
                        cbNameClasses.SelectedIndex = 0;
                        path = fileDialog.FileName;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tableLayoutPanel3.Visible = false;
                        tbPath.Text = "Нажмите для открытия диалога...";
                        tbPath.ForeColor = Color.Gray;
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbNameClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNameClasses.SelectedIndex != -1)
            {
                cbMethods.SelectedIndex = 0;
                panel1.Controls.Clear();
                moveObject = (IMoveObject)Activator.CreateInstance(classes[cbNameClasses.SelectedIndex], panel1);
                cbMethods.Enabled = true;
            }
            else
                cbMethods.Enabled = false;
        }

        private void cbMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMethods.SelectedIndex != -1)
            {
                moveMethod = classes[cbNameClasses.SelectedIndex].GetMethod(cbMethods.Text);
                if(moveMethod.GetParameters().Length > 0)
                {
                    tableLayoutPanel1.RowStyles[3].Height = 0;
                    tableLayoutPanel1.RowStyles[2].Height = 100;
                    tableLayoutPanel1.RowStyles[2].SizeType = SizeType.Percent;
                    flowLayoutPanel1.Visible = true;
                    btnRun.Enabled = true;
                }
                else
                {
                    tableLayoutPanel1.RowStyles[2].Height = 0;
                    tableLayoutPanel1.RowStyles[3].Height = 100;
                    tableLayoutPanel1.RowStyles[3].SizeType = SizeType.Percent;
                    flowLayoutPanel1.Visible = false;
                    action = (int)Action.Empty;
                }

                switch (moveMethod.Name)
                {
                    case "Initialization":
                        action = (int)Action.ChoisePoint;
                        break;
                    case "Move":
                        action = (int)Action.ChoiseRoute;
                        break;
                    case "Loading":
                        action = (int)Action.Passenger;
                        tableLayoutPanel1.RowStyles[2].Height = 0;
                        tableLayoutPanel1.RowStyles[3].Height = 100;
                        tableLayoutPanel1.RowStyles[3].SizeType = SizeType.Percent;
                        flowLayoutPanel1.Visible = false;
                        break;
                }
            }
            else
                btnRun.Enabled = false;
        }


        private void btnRun_Click(object sender, EventArgs e)   
        {
            if (action == (int)Action.ChoisePoint)
            {
                int i = 0;
                while (i < flowLayoutPanel1.Controls.Count && flowLayoutPanel1.Controls[i].BackColor != Color.Green)
                    i++;
                if (i == flowLayoutPanel1.Controls.Count)
                {
                    MessageBox.Show("Вы не выбрали ни одной точки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (PictureBox pictureBox in flowLayoutPanel1.Controls)
                    if (pictureBox.BackColor == Color.Green)
                    {
                        Point tmp = new Point();
                        string[] s = ((string)(pictureBox.Tag)).Split(';');
                        tmp.Y = Convert.ToInt32(s[0]) * 79;
                        tmp.X = Convert.ToInt32(s[1]) * 79;
                        parametrs = new List<object> { tmp };
                    }
            }
            else if (action == (int)Action.ChoiseRoute)
            {
                if (parametrs.Count == 0)
                {
                    MessageBox.Show("Вы не выбрали ни одной точки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                parametrs = new List<object> { parametrs.ToArray() };
            }
            else if (action == (int)Action.Passenger)
            {
                FormChoice frm = new FormChoice(path, moveObject, panel1);
                if (frm.ShowDialog() != DialogResult.OK)
                    return;
                parametrs = new List<object> { frm.MoveObject };
            }
            else
                parametrs = null;

            tableLayoutPanel1.RowStyles[2].Height = 0;
            tableLayoutPanel1.RowStyles[3].Height = 100;
            tableLayoutPanel1.RowStyles[3].SizeType = SizeType.Percent;
            panel1.Visible = true;
            try
            {
                moveMethod.Invoke(moveObject, parametrs != null ? new object[] { parametrs.ToArray() } : null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
