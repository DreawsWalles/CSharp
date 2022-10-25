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
    }
}
