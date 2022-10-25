using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskFour
{
    public partial class FormChoice : Form
    {
        private List<Type> types = new List<Type>();
        public IMoveObject MoveObject { get; set; }
        private Panel panel;
        public FormChoice(string path, IMoveObject selectObj, Panel panel)
        {
            InitializeComponent();
            Assembly asm = Assembly.LoadFrom(path);
            foreach (Type c in asm.GetExportedTypes())
                if (c.GetInterfaces().Contains(typeof(IMoveObject)) && !c.IsAbstract && c.FullName != selectObj.ToString())
                    types.Add(c);
            for(int i = 0; i < types.Count; i++)
            {
                RowStyle row = new RowStyle();
                row.Height = 35;
                row.SizeType = SizeType.Percent;
                RadioButton btn = new RadioButton();
                btn.Text = types[i].Name;
                btn.Anchor = AnchorStyles.Left;
                btn.CheckedChanged += new EventHandler(btn_Click);
                btn.Tag = i;
                tableLayoutPanel2.RowStyles.Add(row);
                tableLayoutPanel1.Controls.Add(btn, 0, i + 1);
            }
            Size = new Size(Width, 120 + types.Count + 2 * 40);
            this.panel = panel;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            btnAccept.Enabled = ((RadioButton)sender).Checked ? true : false;
            MoveObject = MoveObject = (IMoveObject)Activator.CreateInstance(types[(int)((RadioButton)sender).Tag], panel);
        }

        private void FormChoice_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 34, Size.Height - 44);
            btnAccept.Enabled = false;
        }

        private void FormChoice_Resize(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 34, Size.Height - 44);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
