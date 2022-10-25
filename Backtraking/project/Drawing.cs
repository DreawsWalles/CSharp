using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace project
{
    static class Drawing
    {
        static public int count_2 = 0;

        static private Bitmap FillInTheCircle(int x, int y, Bitmap tmp, Color color)
        {
            Graphics figureGraphics = Graphics.FromImage(tmp);
            figureGraphics.DrawEllipse(new Pen(color), x, y, 10, 10);
            figureGraphics.FillEllipse(new SolidBrush(color), x, y, 10, 10);
            return tmp;
        }

        static private Bitmap DrawPoint(Bitmap tmp, int countPoint, bool isUp, Color color)
        {
            if (isUp)
                switch (countPoint)
                {
                    case 1:
                        tmp = FillInTheCircle(Convert.ToInt32(tmp.Width / 2.5), tmp.Height / 5, tmp, color);
                        break;
                    case 2:
                        tmp = FillInTheCircle(9, Convert.ToInt32(tmp.Height / 3.1), tmp, color);
                        tmp = FillInTheCircle(tmp.Width - 20, 7, tmp, color);
                        break;
                    case 3:
                        tmp = FillInTheCircle(9, Convert.ToInt32(tmp.Height / 3.1), tmp, color);
                        tmp = FillInTheCircle(Convert.ToInt32(tmp.Width / 2.5), tmp.Height / 5, tmp, color);
                        tmp = FillInTheCircle(tmp.Width - 20, 7, tmp, color);
                        break;
                    case 4:
                        tmp = FillInTheCircle(9, Convert.ToInt32(tmp.Height / 3.1), tmp, color);
                        tmp = FillInTheCircle(tmp.Width - 20, 7, tmp, color);
                        tmp = FillInTheCircle(tmp.Width - 20, Convert.ToInt32(tmp.Height / 3.1), tmp, color);
                        tmp = FillInTheCircle(9, 7, tmp, color);
                        break;
                    case 5:
                        tmp = FillInTheCircle(9, Convert.ToInt32(tmp.Height / 3.1), tmp, color);
                        tmp = FillInTheCircle(tmp.Width - 20, 7, tmp, color);
                        tmp = FillInTheCircle(tmp.Width - 20, Convert.ToInt32(tmp.Height / 3.1), tmp, color);
                        tmp = FillInTheCircle(9, 7, tmp, color);
                        tmp = FillInTheCircle(Convert.ToInt32(tmp.Width / 2.5), tmp.Height / 5, tmp, color);
                        break;
                    case 6:
                        tmp = FillInTheCircle(9, Convert.ToInt32(tmp.Height / 3.1), tmp, color);
                        tmp = FillInTheCircle(tmp.Width - 20, 7, tmp, color);
                        tmp = FillInTheCircle(tmp.Width - 20, Convert.ToInt32(tmp.Height / 3.1), tmp, color);
                        tmp = FillInTheCircle(9, 7, tmp, color);
                        tmp = FillInTheCircle(9, tmp.Height / 5, tmp, color);
                        tmp = FillInTheCircle(tmp.Width - 20, tmp.Height / 5, tmp, color);
                        break;
                }
            else
                switch (countPoint)
                {
                    case 1:
                        tmp = FillInTheCircle(Convert.ToInt32(tmp.Width / 2.5), Convert.ToInt32(tmp.Height / 1.5), tmp, color);
                        break;
                    case 2:
                        tmp = FillInTheCircle(9, Convert.ToInt32(tmp.Height / 1.23), tmp, color);
                        tmp = FillInTheCircle(tmp.Width - 20, Convert.ToInt32(tmp.Height / 1.85), tmp, color);
                        break;
                    case 3:
                        tmp = FillInTheCircle(9, Convert.ToInt32(tmp.Height / 1.23), tmp, color);
                        tmp = FillInTheCircle(Convert.ToInt32(tmp.Width / 2.5), Convert.ToInt32(tmp.Height / 1.5), tmp, color);
                        tmp = FillInTheCircle(tmp.Width - 20, Convert.ToInt32(tmp.Height / 1.85), tmp, color);
                        break;
                    case 4:
                        tmp = FillInTheCircle(9, Convert.ToInt32(tmp.Height / 1.23), tmp, color);
                        tmp = FillInTheCircle(tmp.Width - 20, Convert.ToInt32(tmp.Height / 1.85), tmp, color);
                        tmp = FillInTheCircle(9, Convert.ToInt32(tmp.Height / 1.85), tmp, color);
                        tmp = FillInTheCircle(tmp.Width - 20, Convert.ToInt32(tmp.Height / 1.23), tmp, color);
                        break;
                    case 5:
                        tmp = FillInTheCircle(9, Convert.ToInt32(tmp.Height / 1.23), tmp, color);
                        tmp = FillInTheCircle(tmp.Width - 20, Convert.ToInt32(tmp.Height / 1.85), tmp, color);
                        tmp = FillInTheCircle(9, Convert.ToInt32(tmp.Height / 1.85), tmp, color);
                        tmp = FillInTheCircle(tmp.Width - 20, Convert.ToInt32(tmp.Height / 1.23), tmp, color);
                        tmp = FillInTheCircle(Convert.ToInt32(tmp.Width / 2.5), Convert.ToInt32(tmp.Height / 1.5), tmp, color);
                        break;
                    case 6:
                        tmp = FillInTheCircle(9, Convert.ToInt32(tmp.Height / 1.23), tmp, color);
                        tmp = FillInTheCircle(tmp.Width - 20, Convert.ToInt32(tmp.Height / 1.85), tmp, color);
                        tmp = FillInTheCircle(9, Convert.ToInt32(tmp.Height / 1.85), tmp, color);
                        tmp = FillInTheCircle(tmp.Width - 20, Convert.ToInt32(tmp.Height / 1.23), tmp, color);
                        tmp = FillInTheCircle(9, Convert.ToInt32(tmp.Height / 1.5), tmp, color);
                        tmp = FillInTheCircle(tmp.Width - 20, Convert.ToInt32(tmp.Height / 1.5), tmp, color);
                        break;
                }
            return tmp;
        }

        static public PictureBox CreateFigure(int countPointUp, int countPointDown, Color color_main, Color color_paint)
        {
            PictureBox result = new PictureBox
            {
                Size = new Size(100, 60)
            };

            Bitmap figure = new Bitmap(50, 100);


            for (int x = 3; x < figure.Width - 1; x++)
                for (int y = 3; y < figure.Height - 1; y++)
                    figure.SetPixel(x - 1, y - 1, color_main);

            for (int i = 0; i < figure.Width; i++)
            {
                figure.SetPixel(i, figure.Width - 1, Color.White);
                figure.SetPixel(i, figure.Width, Color.White);
            }
            figure = DrawPoint(figure, countPointUp, true, color_paint);
            figure = DrawPoint(figure, countPointDown, false, color_paint);
            for (int i = 0; i < figure.Height; i++)
            {
                figure.SetPixel(0, i, Color.Black);
                figure.SetPixel(1, i, Color.Black);
                figure.SetPixel(figure.Width - 1, i, Color.Black);
                figure.SetPixel(figure.Width - 2, i, Color.Black);
            }

            for (int i = 0; i < figure.Width; i++)
            {
                figure.SetPixel(i, 0, Color.Black);
                figure.SetPixel(i, 1, Color.Black);
                figure.SetPixel(i, 2 * figure.Width - 1, Color.Black);
                figure.SetPixel(i, 2 * figure.Width - 2, Color.Black);
            }
            figure.RotateFlip(RotateFlipType.Rotate270FlipNone);
            result.Image = figure;
            return result;
        }

        static public PictureBox DrawIconAdd(Color color, Color fon)
        {
            PictureBox result = new PictureBox
            {
                Size = new Size(420, 420)
            };
            Bitmap figure = new Bitmap(400, 400);
            Graphics figureGraphics = Graphics.FromImage(figure);
            figureGraphics.DrawEllipse(new Pen(color), 0, 0, 350, 350);
            figureGraphics.FillEllipse(new SolidBrush(color), 0, 0, 350, 350);

            figureGraphics.DrawEllipse(new Pen(fon), 26, 25, 300, 300);
            figureGraphics.FillEllipse(new SolidBrush(fon), 26, 25, 300, 300);

            figureGraphics.DrawRectangle(new Pen(color), (float)148, (float)50, 50, 250);
            figureGraphics.FillRectangle(new SolidBrush(color),(float)148, (float)50, 50, 250);//вертикаль

            figureGraphics.DrawRectangle(new Pen(color), (float)50, (float)150, 250, 50);
            figureGraphics.FillRectangle(new SolidBrush(color), (float)50, (float)150, 250, 50);//горизонталь

            result.Image = figure;
            return result;
        }

        static public PictureBox DrawIconRandom(Color color, Color fon)
        {
            PictureBox result = new PictureBox
            {
                Size = new Size(420, 420)
            };
            Bitmap figure = new Bitmap(400, 400);
            Graphics figureGraphics = Graphics.FromImage(figure);
            figureGraphics.DrawEllipse(new Pen(color), 0, 0, 350, 350);
            figureGraphics.FillEllipse(new SolidBrush(color), 0, 0, 350, 350);

            figureGraphics.DrawEllipse(new Pen(fon), 26, 25, 300, 300);
            figureGraphics.FillEllipse(new SolidBrush(fon), 26, 25, 300, 300);

            figureGraphics.DrawRectangle(new Pen(color), 50, 130, 60, 30);
            figureGraphics.FillRectangle(new SolidBrush(color), 50, 130, 60, 30);
            figureGraphics.DrawRectangle(new Pen(color), 50, 190, 60, 30);
            figureGraphics.FillRectangle(new SolidBrush(color), 50, 190, 60, 30);


            figureGraphics.DrawRectangle(new Pen(color), 200, 130, 60, 30);
            figureGraphics.FillRectangle(new SolidBrush(color), 200, 130, 60, 30);
            figureGraphics.DrawRectangle(new Pen(color), 200, 190, 60, 30);
            figureGraphics.FillRectangle(new SolidBrush(color), 200, 190, 60, 30);

            for (int i = 0; i < 30; i++)
            {
                figureGraphics.DrawLine(new Pen(color), 200, 130 + i, 110, 190 + i);
                figureGraphics.DrawLine(new Pen(color), 110, 160 - i, (float)(122 + i * 0.5), (float)(169 - i* 0.3));
                figureGraphics.DrawLine(new Pen(color), 200, 190 + i, (float)(190 - i * 0.5), (float)(180 + i * 0.3));
            }
            for (int i = 0; i < 26; i++)
            {
                figureGraphics.DrawLine(new Pen(color), 260 + i, 120 + i, 260 + i, 170 - i);
                figureGraphics.DrawLine(new Pen(color), 260 + i, 180 + i, 260 + i, 230 - i);
            }
            result.Image = figure;
            return result;
        }
        
        static public PictureBox DrawIconTitleTask(Color color, string text)
        {
            PictureBox result = new PictureBox()
            {
                Size = new Size(420, 420)
            };
            Bitmap figure = new Bitmap(410, 410);
            Graphics graphics = Graphics.FromImage(figure);

            graphics.DrawString(text, new Font("Roboto", 17, FontStyle.Bold), new SolidBrush(color), 0, 0);

            result.Image = figure;
            return result;
        }

        static public bool AddElementInPanel(ref Panel panel, PictureBox picture) //функция для добавления элементов при создании
        {

            if (panel.Controls.Count == 0)
            {
                picture.Location = new Point(15, 10);
                picture.Tag = panel.Controls.Count;
                panel.Controls.Add(picture);
            }
            else
            {
                if (panel.Controls[panel.Controls.Count - 1].Location.Y + 79 >= panel.Height && panel.Controls[panel.Controls.Count - 1].Location.X + 230 >= panel.Width)
                    return false;
                PictureBox lastPicture = (PictureBox)panel.Controls[panel.Controls.Count - 1];
                picture.Tag = panel.Controls.Count;
                if (panel.Controls[panel.Controls.Count - 1].Location.X + 230 < panel.Width)
                    picture.Location = new Point(lastPicture.Location.X + 115, lastPicture.Location.Y);
                else
                    picture.Location = new Point(15, lastPicture.Location.Y + 80);
                panel.Controls.Add(picture);

            }
            return true;
        }

        static public void AddElementInPanel(ref Panel panel, Bone element) //функция для выстравивания цепочки при выполнении освновной задачи
        {
            if (panel.Controls.Count == 0)
            {
                element.picture.Location = new Point(15, 10);
                panel.Controls.Add(element.picture);
            }
            else if (count_2 % 2 == 0)
                if (panel.Controls[panel.Controls.Count - 1].Location.X + 204 < panel.Width)
                {
                    element.picture.Location = new Point(panel.Controls[panel.Controls.Count - 1].Location.X + 102, panel.Controls[panel.Controls.Count - 1].Location.Y);
                    panel.Controls.Add(element.picture);
                }
                else
                {
                    element.picture.Size = new Size(50, 100);
                    element.picture.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    element.picture.Location = new Point(panel.Controls[panel.Controls.Count - 1].Location.X + 102, panel.Controls[panel.Controls.Count - 1].Location.Y);
                    panel.Controls.Add(element.picture);
                    count_2++;
                }
            else if ((panel.Controls[panel.Controls.Count - 1].Location.X - 204 < 15))
            {
                element.picture.Location = new Point(panel.Controls[panel.Controls.Count - 1].Location.X - 102, panel.Controls[panel.Controls.Count - 1].Location.Y);
                panel.Controls.Add(element.picture);
            }
            else
            {
                element.picture.Size = new Size(50, 100);
                element.picture.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                element.picture.Location = new Point(panel.Controls[panel.Controls.Count - 1].Location.X + 102, panel.Controls[panel.Controls.Count - 1].Location.Y);
                panel.Controls.Add(element.picture);
                count_2++;
            }
        }
    }
}
            