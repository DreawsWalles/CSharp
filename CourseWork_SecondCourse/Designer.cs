using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace project
{
    static class Designer
    {
        static FrmLoadOrCreateFile frmFile;
        static PictureBox color;
        static PictureBox color_dark;

        static FrmMain frmMain;
        static Color frmMainColorTextMenu;
        static Color frmMainColorHoverItemMenu;
        static Color frmMainColorBackColorMenu;
        static Color frmMainColorTextTabPage;
        static Color frmMainBackColorTabControl;
        static Color frmMainBaclColorTabPage;
        static Color frmMainBaclColorTabPageNoneActive;

        public static PictureBox Сolor { get { return copyPicture(color); } private set { } }
       
        static Designer()
        {
            color = new PictureBox();
            color.Image = (Image)Properties.Resources.ResourceManager.GetObject("Color_circle");
            color_dark = new PictureBox();
            color_dark.Image = (Image)Properties.Resources.ResourceManager.GetObject("Color_circle_dark");
        }

        private static PictureBox copyPicture(PictureBox picture)
        {
            PictureBox pic = new PictureBox
            {
                Image = picture.Image,
                Width = picture.Width,
                Height = picture.Height,
                Region = picture.Region,
                Tag = picture.Tag
            };

            return pic;
        }

        private static Region cutRegion(Bitmap picture)
        {
            GraphicsPath graphics = new GraphicsPath();
            Color whiteCol = picture.GetPixel(0, 0);
            for (int x = 0; x < picture.Width; x++)
            {
                for (int y = 0; y < picture.Height; y++)
                {
                    if (!picture.GetPixel(x, y).Equals(whiteCol))
                    {
                        graphics.AddRectangle(new Rectangle(x, y, 1, 1));
                    }
                }
            }
            return new Region(graphics);
        }


        //--------------Дизайн формы FrmLoadOrCreateFile---------------//
        public static void DesignerFrmLoadOrCreateFile(FrmLoadOrCreateFile form, int design)
        {
            frmFile = form;
            switch (design)
            {
                case 0:
                    form.listBox.DrawItem += new DrawItemEventHandler(listBox_DrawItem_1);

                    form.SelectedTypeColor = Color.Gainsboro;
                    form.UnSelectedTypeColor = Color.Transparent;

                    form.BackColor = Color.White;
                    form.listBox.BackColor = Color.White;
                    form.listBox.BorderStyle = BorderStyle.FixedSingle;
                    form.TextBox.BackColor = Color.White;
                    form.TextBox.BorderStyle = BorderStyle.FixedSingle;

                    form.BtnChar.ForeColor = Color.Black;
                    form.BtnDouble.ForeColor = Color.Black;
                    form.BtnString.ForeColor = Color.Black;
                    form.BtnInt.ForeColor = Color.Black;
                    form.BtnMyType.ForeColor = Color.Black;
                    form.BtnFloat.ForeColor = Color.Black;

                    form.BtnChar.BackColor = Color.White;
                    form.BtnDouble.BackColor = Color.White;
                    form.BtnString.BackColor = Color.White;
                    form.BtnInt.BackColor = Color.White;
                    form.BtnMyType.BackColor = Color.White;
                    form.BtnFloat.BackColor = Color.White;

                    form.EnterUnSelectItem = Color.Gainsboro;
                    form.EnterSelectItem = Color.LightGray;
                    form.LeaveSeletcItem = Color.Gainsboro;
                    form.LeaveUnSelectItem = Color.White;

                    form.LblTitle.ForeColor = Color.Black;

                    form.ColorTextInputWait = Color.Gray;
                    form.ColorTextInput = Color.Black;

                    form.BtnCreate.BackColor = Color.Gray;
                    form.BtnCreate.FlatStyle = FlatStyle.System;
                    form.BtnCreate.ForeColor = Color.Black;

                    form.BtnColor.BackgroundImage = color.Image;

                    form.BtnEn.ForeColor = Color.Black;
                    form.BtnEn.FlatStyle = FlatStyle.System;
                    form.BtnEn.BackColor = Color.Gray;

                    form.BtnRu.ForeColor = Color.Black;
                    form.BtnRu.FlatStyle = FlatStyle.System;
                    form.BtnRu.BackColor = Color.Gray;

                    form.BtnOpen.ForeColor = Color.Black;
                    form.BtnOpen.FlatStyle = FlatStyle.System;
                    form.BtnOpen.BackColor = Color.Gray;

                    form.BtnCansel.ForeColor = Color.Black;
                    form.BtnCansel.FlatStyle = FlatStyle.System;
                    form.BtnCansel.BackColor = Color.Gray;
                    break;
                case 1:
                    form.LblTitle.ForeColor = Color.White;

                    form.BackColor = Color.FromArgb(45, 45, 48);
                    form.TextBox.BackColor = Color.FromArgb(28, 28, 28);
                    form.TextBox.BorderStyle = BorderStyle.None;

                    form.BtnChar.ForeColor = Color.White;
                    form.BtnDouble.ForeColor = Color.White;
                    form.BtnString.ForeColor = Color.White;
                    form.BtnInt.ForeColor = Color.White;
                    form.BtnMyType.ForeColor = Color.White;
                    form.BtnFloat.ForeColor = Color.White;

                    form.BtnChar.BackColor = Color.FromArgb(45, 45, 48);
                    form.BtnDouble.BackColor = Color.FromArgb(45, 45, 48);
                    form.BtnString.BackColor = Color.FromArgb(45, 45, 48);
                    form.BtnInt.BackColor = Color.FromArgb(45, 45, 48);
                    form.BtnMyType.BackColor = Color.FromArgb(45, 45, 48);
                    form.BtnFloat.BackColor = Color.FromArgb(45, 45, 48);

                    form.UnSelectedTypeColor = Color.FromArgb(45, 45, 48);
                    form.SelectedTypeColor = Color.BlueViolet;

                    form.EnterUnSelectItem = Color.BlueViolet;
                    form.EnterSelectItem = Color.Indigo;
                    form.LeaveSeletcItem = Color.BlueViolet;
                    form.LeaveUnSelectItem = Color.FromArgb(45, 45, 48);

                    form.ColorTextInput = Color.White;
                    form.ColorTextInputWait = Color.Gray;

                    form.BtnCreate.BackColor = Color.BlueViolet;
                    form.BtnCreate.FlatStyle = FlatStyle.Flat;
                    form.BtnCreate.ForeColor = Color.White;

                    form.BtnColor.BackgroundImage = color_dark.Image;

                    form.BtnEn.ForeColor = Color.White;
                    form.BtnEn.FlatStyle = FlatStyle.Flat;
                    form.BtnEn.BackColor = Color.BlueViolet;

                    form.BtnRu.ForeColor = Color.White;
                    form.BtnRu.FlatStyle = FlatStyle.Flat;
                    form.BtnRu.BackColor = Color.BlueViolet;

                    form.BtnOpen.ForeColor = Color.White;
                    form.BtnOpen.FlatStyle = FlatStyle.Flat;
                    form.BtnOpen.BackColor = Color.BlueViolet;

                    form.BtnCansel.ForeColor = Color.White;
                    form.BtnCansel.FlatStyle = FlatStyle.Flat;
                    form.BtnCansel.BackColor = Color.BlueViolet;

                    form.listBox.DrawItem += new DrawItemEventHandler(listBox_DrawItem_2);
                    form.listBox.BackColor = Color.FromArgb(28, 28, 28);
                    form.listBox.BorderStyle = BorderStyle.None;
                    break;
                case 2:
                    form.listBox.DrawItem += new DrawItemEventHandler(listBox_DrawItem_3);

                    form.UnSelectedTypeColor = Color.Transparent;
                    form.SelectedTypeColor = Color.BlueViolet;

                    form.BackColor = Color.White;
                    form.listBox.BackColor = Color.White;
                    form.listBox.BorderStyle = BorderStyle.FixedSingle;
                    form.TextBox.BackColor = Color.White;
                    form.TextBox.BorderStyle = BorderStyle.FixedSingle;

                    form.BtnChar.ForeColor = Color.Black;
                    form.BtnDouble.ForeColor = Color.Black;
                    form.BtnString.ForeColor = Color.Black;
                    form.BtnInt.ForeColor = Color.Black;
                    form.BtnMyType.ForeColor = Color.Black;
                    form.BtnFloat.ForeColor = Color.Black;

                    form.BtnChar.BackColor = Color.White;
                    form.BtnDouble.BackColor = Color.White;
                    form.BtnString.BackColor = Color.White;
                    form.BtnInt.BackColor = Color.White;
                    form.BtnMyType.BackColor = Color.White;
                    form.BtnFloat.BackColor = Color.White;

                    form.EnterUnSelectItem = Color.BlueViolet;
                    form.EnterSelectItem = Color.Indigo;
                    form.LeaveSeletcItem = Color.BlueViolet;
                    form.LeaveUnSelectItem = Color.Transparent;

                    form.LblTitle.ForeColor = Color.Black;

                    form.ColorTextInputWait = Color.Gray;
                    form.ColorTextInput = Color.Black;

                    form.BtnCreate.BackColor = Color.BlueViolet;
                    form.BtnCreate.FlatStyle = FlatStyle.Flat;
                    form.BtnCreate.ForeColor = Color.Black;

                    form.BtnColor.BackgroundImage = color.Image;

                    form.BtnEn.ForeColor = Color.Black;
                    form.BtnEn.FlatStyle = FlatStyle.Flat;
                    form.BtnEn.BackColor = Color.BlueViolet;

                    form.BtnRu.ForeColor = Color.Black;
                    form.BtnRu.FlatStyle = FlatStyle.Flat;
                    form.BtnRu.BackColor = Color.BlueViolet;

                    form.BtnOpen.ForeColor = Color.Black;
                    form.BtnOpen.FlatStyle = FlatStyle.Flat;
                    form.BtnOpen.BackColor = Color.BlueViolet;

                    form.BtnCansel.ForeColor = Color.Black;
                    form.BtnCansel.FlatStyle = FlatStyle.Flat;
                    form.BtnCansel.BackColor = Color.BlueViolet;
                    break;
            }
        }
        private static void listBox_DrawItem_1(object sender, DrawItemEventArgs e)
        {
            try
            {
                int index = e.Index;
                Graphics g = e.Graphics;
                foreach (int selectedIndex in frmFile.listBox.SelectedIndices)
                {
                    if (index == selectedIndex)
                    {
                        // Draw the new background colour
                        e.DrawBackground();
                        g.FillRectangle(new SolidBrush(Color.Gainsboro), e.Bounds);
                    }
                }

                // Get the item details
                Font font = frmFile.listBox.Font;
                Color colour = frmFile.listBox.ForeColor;
                string text = frmFile.listBox.Items[index].ToString();

                // Print the text
                g.DrawString(text, font, new SolidBrush(Color.Black), (float)e.Bounds.X, (float)e.Bounds.Y);
                e.DrawFocusRectangle();
            }
            catch { }
        }
        private static void listBox_DrawItem_2(object sender, DrawItemEventArgs e)
        {
            try
            {
                int index = e.Index;
                Graphics g = e.Graphics;
                foreach (int selectedIndex in frmFile.listBox.SelectedIndices)
                {
                    if (index == selectedIndex)
                    {
                        // Draw the new background colour
                        e.DrawBackground();
                        g.FillRectangle(new SolidBrush(Color.MediumPurple), e.Bounds);
                    }
                }

                // Get the item details
                Font font = frmFile.listBox.Font;
                Color colour = frmFile.listBox.ForeColor;
                string text = frmFile.listBox.Items[index].ToString();

                // Print the text
                g.DrawString(text, font, new SolidBrush(Color.White), (float)e.Bounds.X, (float)e.Bounds.Y);
                e.DrawFocusRectangle();
            }
            catch { }
        }
        private static void listBox_DrawItem_3(object sender, DrawItemEventArgs e)
        {
            try
            {
                int index = e.Index;
                Graphics g = e.Graphics;
                foreach (int selectedIndex in frmFile.listBox.SelectedIndices)
                {
                    if (index == selectedIndex)
                    {
                        // Draw the new background colour
                        e.DrawBackground();
                        g.FillRectangle(new SolidBrush(Color.MediumPurple), e.Bounds);
                    }
                }

                // Get the item details
                Font font = frmFile.listBox.Font;
                Color colour = frmFile.listBox.ForeColor;
                string text = frmFile.listBox.Items[index].ToString();

                // Print the text
                g.DrawString(text, font, new SolidBrush(Color.Black), (float)e.Bounds.X, (float)e.Bounds.Y);
                e.DrawFocusRectangle();
            }
            catch { }
        }
        //------------------------------------------------------------//

        //------------------Дизайн формы FrmSettin--------------------//
        public static void DesignerFrmSetting(FrmSetting form, int design)
        {
            switch(design)
            {
                case 0:
                    form.BackColor = Color.White;
                    form.textColor.ForeColor = Color.Black;
                    form.textLanguage.ForeColor = Color.Black;
                    form.ColorText = Color.Black;
                    form.mainColor = Color.White;
                    form.ColorHover = Color.Gainsboro;
                    form.BtnAccept.BackColor = Color.Gray;
                    form.BtnCancel.BackColor = Color.Gray;
                    form.BtnAccept.ForeColor = Color.Black;
                    form.BtnCancel.ForeColor = Color.Black;
                    form.BtnAccept.FlatStyle = FlatStyle.System;
                    form.BtnCancel.FlatStyle = FlatStyle.System;
                    form.ComboBoxColor.FlatStyle = FlatStyle.System;
                    form.ComboBoxLanguage.FlatStyle = FlatStyle.System;
                    form.ComboBoxColor.BackColor = Color.White;
                    form.ComboBoxLanguage.BackColor = Color.White;
                    break;
                case 1:
                    form.BackColor = Color.FromArgb(45, 45, 48);
                    form.textColor.ForeColor = Color.White;
                    form.textLanguage.ForeColor = Color.White;
                    form.ColorText = Color.White;
                    form.mainColor = Color.FromArgb(28, 28, 28);
                    form.ColorHover = Color.MediumPurple;
                    form.BtnAccept.BackColor = Color.BlueViolet;
                    form.BtnCancel.BackColor = Color.BlueViolet;
                    form.BtnAccept.ForeColor = Color.White;
                    form.BtnCancel.ForeColor = Color.White;
                    form.BtnAccept.FlatStyle = FlatStyle.Flat;
                    form.BtnCancel.FlatStyle = FlatStyle.Flat;
                    form.ComboBoxColor.FlatStyle = FlatStyle.Flat;
                    form.ComboBoxLanguage.FlatStyle = FlatStyle.Flat;
                    form.ComboBoxColor.BackColor = Color.FromArgb(45, 45, 48);
                    form.ComboBoxLanguage.BackColor = Color.FromArgb(45, 45, 48);
                    break;
                case 2:
                    form.BackColor = Color.White;
                    form.textColor.ForeColor = Color.Black;
                    form.textLanguage.ForeColor = Color.Black;
                    form.ColorText = Color.Black;
                    form.mainColor = Color.White;
                    form.ColorHover = Color.MediumPurple;
                    form.BtnAccept.BackColor = Color.BlueViolet;
                    form.BtnCancel.BackColor = Color.BlueViolet;
                    form.BtnAccept.ForeColor = Color.Black;
                    form.BtnCancel.ForeColor = Color.Black;
                    form.BtnAccept.FlatStyle = FlatStyle.Flat;
                    form.BtnCancel.FlatStyle = FlatStyle.Flat;
                    form.ComboBoxColor.FlatStyle = FlatStyle.System;
                    form.ComboBoxLanguage.FlatStyle = FlatStyle.System;
                    form.ComboBoxColor.BackColor = Color.White;
                    form.ComboBoxLanguage.BackColor = Color.White;
                    break;
            }
        }
        //-----------------------------------------------------------//

        //------------------Дизайн для формы FrmColor--------------------//
        public static void DesignerFrmColor(FrmColor form, int design)
        {
            switch (design)
            {
                case 0:
                    form.BackColor = Color.White;
                    form.BtnAccept.ForeColor = Color.Black;
                    form.BtnAccept.BackColor = Color.Gray;
                    form.BtnAccept.FlatStyle = FlatStyle.System;
                    form.BtnCancel.ForeColor = Color.Black;
                    form.BtnCancel.BackColor = Color.Gray;
                    form.BtnCancel.FlatStyle = FlatStyle.System;
                    break;
                case 1:
                    form.BackColor = Color.FromArgb(45, 45, 48);
                    form.BtnAccept.ForeColor = Color.White;
                    form.BtnAccept.BackColor = Color.BlueViolet;
                    form.BtnAccept.FlatStyle = FlatStyle.Flat;
                    form.BtnCancel.ForeColor = Color.White;
                    form.BtnCancel.BackColor = Color.BlueViolet;
                    form.BtnCancel.FlatStyle = FlatStyle.Flat;
                    break;
                case 2:
                    form.BackColor = Color.White;
                    form.BtnAccept.ForeColor = Color.Black;
                    form.BtnAccept.BackColor = Color.BlueViolet;
                    form.BtnAccept.FlatStyle = FlatStyle.Flat;
                    form.BtnCancel.ForeColor = Color.Black;
                    form.BtnCancel.BackColor = Color.BlueViolet;
                    form.BtnCancel.FlatStyle = FlatStyle.Flat;
                    break;
            }
        }
        //----------------------------------------------------------------//

        //-----------------Дизайн для формы FrmMain-----------------------//
        public static void DesinerFrmMain(FrmMain form, int design)
        {
            frmMain = form;
            ToolStripMenuItem element = (ToolStripMenuItem)form.mainMenu.Items[0];
            switch (design)
            {
                case 0:
                    form.BackColor = Color.White;
                    form.mainMenu.BackColor = Color.White;
                    frmMainColorTextMenu = Color.Black;
                    frmMainColorHoverItemMenu = Color.Gainsboro;
                    frmMainColorBackColorMenu = Color.Beige;
                    DesignerTabControls(form, design);
                    break;
                case 1:
                    form.BackColor = Color.FromArgb(45, 45, 48);
                    form.mainMenu.BackColor = Color.FromArgb(45, 45, 48);
                    frmMainColorTextMenu = Color.White;
                    frmMainColorHoverItemMenu = Color.BlueViolet;
                    frmMainColorBackColorMenu = Color.FromArgb(28, 28, 28);
                    DesignerTabControls(form, design);
                    break;
                case 2:
                    form.BackColor = Color.White;
                    form.mainMenu.BackColor = Color.White;
                    frmMainColorTextMenu = Color.Black;
                    frmMainColorHoverItemMenu = Color.BlueViolet;
                    frmMainColorBackColorMenu = Color.Beige;
                    DesignerTabControls(form, design);
                    break;
            }
            form.mainMenu.Renderer = new NoHigthligthRenderer();
            foreach (ToolStripMenuItem m in form.mainMenu.Items)
            {
                SetColor(m);
            }
            form.mainMenu.Renderer = new ToolStripProfessionalRenderer(new ChangeStyleItem());
        }
        public static void DesignerTabControls(FrmMain form, int design)
        {
            form.TabCtrl.DrawMode = TabDrawMode.OwnerDrawFixed;
            form.TabCtrl.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
            switch (design)
                {
                case 0:
                    frmMainBaclColorTabPage = Color.Gainsboro;
                    frmMainBackColorTabControl = Color.White;
                    frmMainColorTextTabPage = Color.Black;
                    frmMainBaclColorTabPageNoneActive = Color.White;
                    foreach (TabPage page in form.TabCtrl.TabPages)
                    {
                        Panel panel = (Panel)page.Controls[0];

                        panel.BackColor = Color.White;
                        panel.BorderStyle = BorderStyle.FixedSingle;
                        panel.Size = new Size(form.TabCtrl.Width - 10, form.TabCtrl.Height - 32);

                        foreach(Label element in panel.Controls)
                        {
                            element.BackColor = Color.Gainsboro;
                            element.ForeColor = Color.Black;
                        }
                    }
                    break;
                case 1:
                    frmMainBaclColorTabPage = Color.BlueViolet;
                    frmMainBackColorTabControl = Color.FromArgb(45, 45, 48);
                    frmMainColorTextTabPage = Color.White;
                    frmMainBaclColorTabPageNoneActive = Color.FromArgb(45, 45, 48);
                    foreach (TabPage page in form.TabCtrl.TabPages)
                    {
                        Panel panel = (Panel)page.Controls[0];

                        panel.BackColor = Color.FromArgb(28, 28, 28);
                        panel.BorderStyle = BorderStyle.None;
                        panel.Size = new Size(form.TabCtrl.Width - 8, form.TabCtrl.Height - 32);

                        foreach (Label element in panel.Controls)
                        {
                            element.BackColor = Color.BlueViolet;
                            element.ForeColor = Color.White;
                        }
                    }
                    break;
                case 2:
                    frmMainBaclColorTabPage = Color.BlueViolet;
                    frmMainBackColorTabControl = Color.White;
                    frmMainColorTextTabPage = Color.Black;
                    frmMainBaclColorTabPageNoneActive = Color.White;
                    foreach (TabPage page in form.TabCtrl.TabPages)
                    {
                        Panel panel = (Panel)page.Controls[0];

                        panel.BackColor = Color.White;
                        panel.BorderStyle = BorderStyle.FixedSingle;
                        panel.Size = new Size(form.TabCtrl.Width - 10, form.TabCtrl.Height - 32);

                        foreach (Label element in panel.Controls)
                        {
                            element.BackColor = Color.BlueViolet;
                            element.ForeColor = Color.Black;
                        }
                    }
                    break;
            }
        
        }
        private static void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Привязать рабочую область
            Rectangle rec01 = frmMain.TabCtrl.ClientRectangle;
            // Устанавливаем цвет фона рабочего пространства
            e.Graphics.FillRectangle(new SolidBrush(frmMainBackColorTabControl), rec01);

            // Серый фон
            SolidBrush back = new SolidBrush(frmMainBaclColorTabPage);
            SolidBrush back_none_active = new SolidBrush(frmMainBaclColorTabPageNoneActive);
            // синий шрифт
            SolidBrush white = new SolidBrush(frmMainColorTextTabPage);
            StringFormat sf = new StringFormat();
            // Выравнивание текста по горизонтали / вертикали по центру
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            for (int i = 0; i < frmMain.TabCtrl.TabPages.Count; i++)
            {
                // Вкладка привязки
                Rectangle rec = frmMain.TabCtrl.GetTabRect(i);
                // Устанавливаем фон вкладки
                if (frmMain.TabCtrl.SelectedIndex == i)
                    e.Graphics.FillRectangle(back, rec);
                else
                    e.Graphics.FillRectangle(back_none_active, rec);

                // Устанавливаем шрифт и цвет вкладки
                e.Graphics.DrawString(frmMain.TabCtrl.TabPages[i].Text, new Font("Consolas", 10), white, rec, sf);
            }
        }
        internal class NoHigthligthRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (e.Item.OwnerItem == null)
                    base.OnRenderMenuItemBackground(e);
            }
        }

        private static void SetColor(ToolStripMenuItem item)
        {
            item.ForeColor = frmMainColorTextMenu;
            foreach (ToolStripMenuItem it in item.DropDownItems)
            {
                SetColor(it);
            }
        }

        public class ChangeStyleItem : ProfessionalColorTable
        {
            public override Color MenuItemSelected { get { return frmMainColorHoverItemMenu; } }
            public override Color ToolStripBorder { get { return frmMainColorBackColorMenu; } }
            public override Color ToolStripDropDownBackground { get { return frmMainColorBackColorMenu; } }
            public override Color ImageMarginGradientBegin { get { return frmMainColorBackColorMenu; } }
            public override Color ImageMarginGradientEnd { get { return frmMainColorBackColorMenu; } }
            public override Color ImageMarginGradientMiddle { get { return frmMainColorBackColorMenu; } }
            public override Color MenuItemSelectedGradientBegin { get { return frmMainColorHoverItemMenu; } }
            public override Color MenuItemSelectedGradientEnd { get { return frmMainColorHoverItemMenu; } }
            public override Color MenuItemPressedGradientBegin { get { return frmMainColorHoverItemMenu; } }
            public override Color MenuItemPressedGradientMiddle { get { return frmMainColorHoverItemMenu; } }
            public override Color MenuItemPressedGradientEnd { get { return frmMainColorHoverItemMenu; } }
            public override Color MenuItemBorder { get { return frmMainColorHoverItemMenu; } }
        }
        //------------------------------------------------------------------//

        //------------------Дизайн для формы frmInputFilm---------------------//
        public static void DesignerFrmInputFilm(FrmInputFilm form, int design)
        {
            switch(design)
            {
                case 0:
                    foreach (Label element in form.labels)
                        element.ForeColor = Color.Black;
                    form.BtnAdd.BackColor = Color.Gainsboro;
                    form.BtnAdd.ForeColor = Color.Black;
                    form.BackColor = Color.White;
                    form.BtnMore_1.BackColor = Color.Gainsboro;
                    form.BtnMore_1.ForeColor = Color.Black;
                    form.BtnMore_2.BackColor = Color.Gainsboro;
                    form.BtnMore_2.ForeColor = Color.Black;
                    break;
                case 1:
                    form.BackColor = Color.FromArgb(45, 45, 48);
                    foreach (Label element in form.labels)
                        element.ForeColor = Color.White;
                    form.BtnAdd.BackColor = Color.BlueViolet;
                    form.BtnAdd.ForeColor = Color.White;
                    form.BtnMore_1.BackColor = Color.BlueViolet;
                    form.BtnMore_1.ForeColor = Color.White;
                    form.BtnMore_2.BackColor = Color.BlueViolet;
                    form.BtnMore_2.ForeColor = Color.White;
                    break;
                case 2:
                    foreach (Label element in form.labels)
                        element.ForeColor = Color.Black;
                    form.BtnAdd.BackColor = Color.BlueViolet;
                    form.BtnAdd.ForeColor = Color.Black;
                    form.BackColor = Color.White;
                    form.BtnMore_1.BackColor = Color.BlueViolet;
                    form.BtnMore_1.ForeColor = Color.Black;
                    form.BtnMore_2.BackColor = Color.BlueViolet;
                    form.BtnMore_2.ForeColor = Color.Black;
                    break;
            }
        }
        //--------------------------------------------------------------------//

        //-----------------Дизайн для формы FrnInput-------------------------//
        public static void DesignerFrmInput(FrmInput form, int design)
        {
            switch(design)
            {
                case 0:
                    form.BackColor = Color.White;
                    form.BtnAccept.BackColor = Color.Gainsboro;
                    form.BtnAccept.ForeColor = Color.Black;
                    break;
                case 1:
                    form.BackColor =Color.FromArgb(45, 45, 48);
                    form.BtnAccept.BackColor = Color.BlueViolet;
                    form.BtnAccept.ForeColor = Color.White;
                    break;
                case 2:
                    form.BackColor = Color.White;
                    form.BtnAccept.BackColor = Color.BlueViolet;
                    form.BtnAccept.ForeColor = Color.White;
                    break;
            }
        }
    }
}
