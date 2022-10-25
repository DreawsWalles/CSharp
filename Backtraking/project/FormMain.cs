using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace project
{
    public partial class FormMain : Form
    { 
        Bones list = new Bones();
        new ContextMenuStrip ContextMenu = new ContextMenuStrip();
        public FormMain()
        {
            InitializeComponent();
            BackColor = Color.FromArgb(189, 147, 84);
            button_add.BackColor = Color.FromArgb(189, 147, 84);
            button_add.FlatAppearance.MouseDownBackColor = Color.FromArgb(189, 147, 84);
            button_add.FlatAppearance.MouseOverBackColor = Color.FromArgb(189, 147, 84);
            button_random.BackColor = Color.FromArgb(189, 147, 84);
            button_random.FlatAppearance.MouseDownBackColor = Color.FromArgb(189, 147, 84);
            button_random.FlatAppearance.MouseOverBackColor = Color.FromArgb(189, 147, 84);
            button_task.BackColor = Color.FromArgb(189, 147, 84);
            button_task.FlatAppearance.MouseDownBackColor = Color.FromArgb(189, 147, 84);
            button_task.FlatAppearance.MouseOverBackColor = Color.FromArgb(189, 147, 84);
            panel1.BackColor = Color.FromArgb(227, 209, 138);
            button_add.BackgroundImage = Drawing.DrawIconAdd(Color.Indigo, Color.Thistle).Image;
            button_random.BackgroundImage = Drawing.DrawIconRandom(Color.Indigo, Color.Thistle).Image;
            button_task.BackgroundImage = Drawing.DrawIconTitleTask(Color.Indigo, "Task").Image;
            button_task.Visible = false;


            ToolStripMenuItem EditMenuItem = new ToolStripMenuItem("Редактировать");
            EditMenuItem.Click += Edit_click;
            ToolStripMenuItem DeleteMenuItem = new ToolStripMenuItem("Удалить");
            DeleteMenuItem.Click += Delete_click;
            ContextMenu.Items.AddRange(new[] { EditMenuItem, DeleteMenuItem });

            foreach (ToolStripMenuItem m in ContextMenu.Items)
            {
                SetColor(m);
            }
            ContextMenu.Renderer = new ToolStripProfessionalRenderer(new ChangeStyleItem());
            ContextMenu.Font = new Font("Consolas", 12);
        }

        public class ChangeStyleItem : ProfessionalColorTable
        {
            public override Color MenuItemSelected { get { return Color.Indigo; } }
            public override Color ToolStripBorder { get { return Color.Indigo; } }
            public override Color ToolStripDropDownBackground { get { return Color.DarkViolet; } }
            public override Color ImageMarginGradientBegin { get { return Color.DarkViolet; } }
            public override Color ImageMarginGradientEnd { get { return Color.DarkViolet; } }
            public override Color ImageMarginGradientMiddle { get { return Color.DarkViolet; } }
            public override Color MenuItemSelectedGradientBegin { get { return Color.DarkSlateGray; } }
            public override Color MenuItemSelectedGradientEnd { get { return Color.DarkSlateGray; } }
            public override Color MenuItemPressedGradientBegin { get { return Color.DarkSlateGray; } }
            public override Color MenuItemPressedGradientMiddle { get { return Color.DarkSlateGray; } }
            public override Color MenuItemPressedGradientEnd { get { return Color.DarkSlateGray; } }
            public override Color MenuItemBorder { get { return Color.DarkViolet; } }
        }
        private void SetColor(ToolStripMenuItem item)
        {
            item.ForeColor = Color.White;
            foreach (ToolStripMenuItem it in item.DropDownItems)
            {
                SetColor(it);
            }
        }

        private void Edit_click(object sender, EventArgs e)
        {
            FormAdd form = new FormAdd();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                PictureBox currnet = (PictureBox)ContextMenu.SourceControl;
                PictureBox picture = Drawing.CreateFigure(form.up, form.down, Color.FromArgb(133, 96, 63), Color.White);
                picture.ContextMenuStrip = ContextMenu;
                Bone tmp = new Bone();
                tmp.up = form.up;
                tmp.down = form.down;
                tmp.picture = picture;
                list[(int)currnet.Tag] = tmp;
                panel1.Controls.Clear();
                for (int i = 0; i < list.Count; i++)
                    Drawing.AddElementInPanel(ref panel1, list[i].picture);
            }
        }
        private void Delete_click(object sender, EventArgs e)
        {
            PictureBox currnet = (PictureBox)ContextMenu.SourceControl;
            list.Remove(list[(int)currnet.Tag]);
            panel1.Controls.Clear();
            for (int i = 0; i < list.Count; i++)
                Drawing.AddElementInPanel(ref panel1, list[i].picture);
            if (list.Count == 0)
                button_task.Visible = false;
        }
        private void button_random_MouseEnter(object sender, EventArgs e)
        {
            button_random.BackgroundImage = Drawing.DrawIconRandom(Color.Thistle, Color.Indigo).Image;
        }

        private void button_random_MouseLeave(object sender, EventArgs e)
        {
            button_random.BackgroundImage = Drawing.DrawIconRandom(Color.Indigo, Color.Thistle).Image;
        }

        private void button_add_MouseEnter(object sender, EventArgs e)
        {
            button_add.BackgroundImage = Drawing.DrawIconAdd(Color.Thistle, Color.Indigo).Image;
        }

        private void button_add_MouseLeave(object sender, EventArgs e)
        {
            button_add.BackgroundImage = Drawing.DrawIconAdd(Color.Indigo, Color.Thistle).Image;
        }

        private void CorrectSizeForm()
        {
            Width += 115;
            Height += 80;
            panel1.Width += 115;
            panel1.Height += 80;
            button_add.Location = new Point(button_add.Location.X + 115, button_add.Location.Y + 80);
            button_random.Location = new Point(button_random.Location.X + 115, button_random.Location.Y + 80);
            button_task.Location = new Point(button_task.Location.X + 115, button_task.Location.Y + 80);
            panel1.Controls.Clear();
            for (int i = 0; i < list.Count; i++)
                Drawing.AddElementInPanel(ref panel1, list[i].picture);
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            FormAdd form = new FormAdd();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                PictureBox picture = Drawing.CreateFigure(form.up, form.down, Color.FromArgb(133, 96, 63), Color.White);
                picture.ContextMenuStrip = ContextMenu;
                list.Add(form.up, form.down, picture);
                if (!Drawing.AddElementInPanel(ref panel1, picture))
                    CorrectSizeForm();
            }
        }

        private void button_random_Click(object sender, EventArgs e)
        {
            button_task.Visible = true;
            Random rnd = new Random();
            int up = rnd.Next(0, 6);
            int down = rnd.Next(0, 6);
            PictureBox picture = Drawing.CreateFigure(up, down, Color.FromArgb(133, 96, 63), Color.White);
            picture.ContextMenuStrip = ContextMenu;
            list.Add(up, down, picture);
            if (!Drawing.AddElementInPanel(ref panel1, picture))
                CorrectSizeForm();
        }

        private void button_task_MouseEnter(object sender, EventArgs e)
        {
            button_task.BackgroundImage = Drawing.DrawIconTitleTask(Color.DarkViolet, "Task").Image;
        }

        private void button_task_MouseLeave(object sender, EventArgs e)
        {
            button_task.BackgroundImage = Drawing.DrawIconTitleTask(Color.Indigo, "Task").Image;
        }

        private void button_task_Click(object sender, EventArgs e)
        {
            FormTask form = new FormTask(list, panel1.Size);
            form.ShowDialog();
            panel1.Controls.Clear();
            for (int i = 0; i < list.Count; i++)
                Drawing.AddElementInPanel(ref panel1, list[i].picture);
        }
    }
}
