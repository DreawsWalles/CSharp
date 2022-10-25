using project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaveAlgorithmLib;

namespace project
{
    public partial class FormMain : Form
    {
        private int _valueM;
        private int _valueL;
        private int _valueN;

        private PictureBox _personPic = new PictureBox();
        private PictureBox _goalPic = new PictureBox();
        private PictureBox _bombPic = new PictureBox();
        private PictureBox _obstaclePic = new PictureBox();
        private PictureBox _EmptyPic = new PictureBox();

        private int? _choiceIcon = null;
        private int? _posPerson = null;
        private int? _posGoal = null;
        private bool isCorrectWay = false;
        public FormMain()
        {
            InitializeComponent();
            MinimumSize = Size;
            MaximizeBox = false;
            WindowState = FormWindowState.Maximized;
            FormInit formInit = new FormInit();
            if( formInit.ShowDialog() != DialogResult.OK )
                Environment.Exit(0);
            _valueM = (int)formInit.FirstValue;
            _valueN = (int)formInit.SecondValue;
            _valueL = (int)formInit.ThreeValue;


            Bitmap tmp = new Bitmap(Resources.person);
            _personPic.Image = new Bitmap(tmp);
            _personPic.Tag = 1;
            _personPic.ClientSize = new Size(tmp.Width + 4, tmp.Height + 4);

            tmp = new Bitmap(Resources.goal);
            _goalPic.Image = new Bitmap(tmp);
            _goalPic.Tag = 2;
            _goalPic.ClientSize = new Size(tmp.Width + 4, tmp.Height + 4);

            tmp = new Bitmap(Resources.bomb);
            _bombPic.Image = new Bitmap(tmp);
            _bombPic.Tag = 3;
            _bombPic.ClientSize = new Size(tmp.Width + 4, tmp.Height + 4);

            tmp = new Bitmap(Resources.Obstacle);
            _obstaclePic.Image = new Bitmap(tmp);
            _obstaclePic.Tag = 4;
            _obstaclePic.ClientSize = new Size(tmp.Width + 4, tmp.Height + 4);

            _EmptyPic.Image = null;
            _EmptyPic.BackColor = Color.White;
            _EmptyPic.ClientSize = new Size(54, 54);
            _EmptyPic.Tag = 5;

            _personPic.MouseHover += new EventHandler(PersonalPicMouseHoverHandler);
            _personPic.MouseLeave += new EventHandler(PersonalPicMouseLeaveHandler);
            _personPic.Click += new EventHandler(ChoiceIcon);

            _goalPic.MouseHover += new EventHandler(GoalPicMouseHoverHandler);
            _goalPic.MouseLeave += new EventHandler(GoalPicMouseLeaveHandler);
            _goalPic.Click += new EventHandler(ChoiceIcon);

            _bombPic.MouseHover += new EventHandler(BombPicMouseHoverHandler);
            _bombPic.MouseLeave += new EventHandler(BombPicMouseLeaveHandler);
            _bombPic.Click += new EventHandler(ChoiceIcon);

            _obstaclePic.MouseHover += new EventHandler(ObstaclePicMouseHoverHandler);
            _obstaclePic.MouseLeave += new EventHandler(ObstaclePicMouseLeaveHandler);
            _obstaclePic.Click += new EventHandler(ChoiceIcon);

            _EmptyPic.MouseHover += new EventHandler(EmptyPicMouseHoverHandler);
            _EmptyPic.MouseLeave += new EventHandler(EmptyPicMouseLeaveHandler);
            _EmptyPic.Click += new EventHandler(ChoiceIcon);

            if(formInit.Map == null)
                CreateLabyrinth();
            else
                CreateLabyrinth(formInit.Map);
        }
        private void ChoiceIcon(object sender, EventArgs e)
        {
            if(_choiceIcon != null)
            {
                switch(_choiceIcon)
                {
                    case 1:
                        _personPic.BorderStyle = BorderStyle.None;
                        break;
                    case 2:
                        _goalPic.BorderStyle = BorderStyle.None;
                        break;
                    case 3:
                        _bombPic.BorderStyle = BorderStyle.None;
                        break;
                    case 4:
                        _obstaclePic.BorderStyle = BorderStyle.None;
                        break;
                    case 5:
                        _EmptyPic.BorderStyle = BorderStyle.None;
                        break;
                }
            }
            PictureBox tmp = (PictureBox)sender;
            int currentChoice = (int)tmp.Tag;
            if(_choiceIcon == currentChoice)
            {
                _choiceIcon = null;
                return;
            }
            _choiceIcon = currentChoice;
            switch(_choiceIcon)
            {
                case 1:
                    _personPic.BorderStyle = BorderStyle.FixedSingle;
                    break;
                case 2:
                    _goalPic.BorderStyle = BorderStyle.FixedSingle;
                    break;
                case 3:
                    _bombPic.BorderStyle = BorderStyle.FixedSingle;
                    break;
                case 4:
                    _obstaclePic.BorderStyle = BorderStyle.FixedSingle;
                    break;
                case 5:
                    _EmptyPic.BorderStyle = BorderStyle.FixedSingle;
                    break;
            }
        }
        private void PersonalPicMouseHoverHandler(object sender, EventArgs e)
        {
            if(_choiceIcon != 1)
                _personPic.BorderStyle = BorderStyle.FixedSingle;
        }
        private void PersonalPicMouseLeaveHandler(object sender, EventArgs e)
        {
            if(_choiceIcon != 1)
                _personPic.BorderStyle = BorderStyle.None;
        }

        private void GoalPicMouseHoverHandler(object sender, EventArgs e)
        {
            if(_choiceIcon != 2)
                _goalPic.BorderStyle = BorderStyle.FixedSingle;
        }
        private void GoalPicMouseLeaveHandler(object sender, EventArgs e)
        {
            if(_choiceIcon != 2)
                _goalPic.BorderStyle = BorderStyle.None;
        }

        private void BombPicMouseHoverHandler(object sender, EventArgs e)
        {
            if(_choiceIcon != 3)
                _bombPic.BorderStyle = BorderStyle.FixedSingle;
        }
        private void BombPicMouseLeaveHandler(object sender, EventArgs e)
        {
            if(_choiceIcon != 3)
            _bombPic.BorderStyle = BorderStyle.None;
        }

        private void ObstaclePicMouseHoverHandler(object sender, EventArgs e)
        {
            if(_choiceIcon != 4)
                _obstaclePic.BorderStyle = BorderStyle.FixedSingle;
        }
        private void ObstaclePicMouseLeaveHandler(object sender, EventArgs e)
        {
            if(_choiceIcon != 4)
                _obstaclePic.BorderStyle = BorderStyle.None;
        }

        private void EmptyPicMouseHoverHandler(object sender, EventArgs e)
        {
            if (_choiceIcon != 5)
                _EmptyPic.BorderStyle = BorderStyle.FixedSingle;
        }
        private void EmptyPicMouseLeaveHandler(object sender, EventArgs e)
        {
            if (_choiceIcon != 5)
                _EmptyPic.BorderStyle = BorderStyle.None;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = Size;
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel1);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel2);

            flowLayoutPanel2.Controls.Add(_personPic);
            flowLayoutPanel2.Controls.Add(_goalPic);
            flowLayoutPanel2.Controls.Add(_obstaclePic);
            flowLayoutPanel2.Controls.Add(_EmptyPic);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel3);


            flowLayoutPanel1.Size = new Size(tableLayoutPanel2.Width, flowLayoutPanel1.Height);
            tableLayoutPanel2.Size = new Size(tableLayoutPanel1.Width - 20, tableLayoutPanel2.Height);
            flowLayoutPanel2.Size = new Size(tableLayoutPanel2.Width, flowLayoutPanel2.Height);
            flowLayoutPanel3.Size = new Size(_valueM * 90, tableLayoutPanel1.Height - 71);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = Size;
            flowLayoutPanel1.Size = new Size(tableLayoutPanel2.Width, flowLayoutPanel1.Height);
            tableLayoutPanel2.Size = new Size(tableLayoutPanel1.Width - 20, tableLayoutPanel2.Height);
            flowLayoutPanel2.Size = new Size(tableLayoutPanel2.Width, flowLayoutPanel2.Height);
            flowLayoutPanel3.Size = new Size(_valueM * 90, tableLayoutPanel1.Height - 71);
        }
        private void CreateLabyrinth()
        {
            for (int i = 0; i < _valueM; i++)
                for (int j = 0; j < _valueN; j++)
                {
                    PictureBox pic = new PictureBox();
                    pic.Image = null;
                    pic.Click += new EventHandler(ChangePicture);
                    pic.BackColor = Color.White;
                    flowLayoutPanel3.Controls.Add(pic);
                    pic.ClientSize = new Size(84, 84);
                    pic.Name = $"{i};{j}";
                    pic.Tag = 5;
                }
            flowLayoutPanel3.Size = new Size(_valueM * 90, tableLayoutPanel1.Height - 71);
        }
        private void CreateLabyrinth(int[,] map)
        {
            int tmp = 0;
            for (int i = 0; i < _valueM; i++)
                for (int j = 0; j < _valueN; j++)
                {
                    switch (map[i, j])
                    {
                        case 0:
                            {
                                PictureBox pic = new PictureBox();
                                pic.Image = null;
                                pic.Click += new EventHandler(ChangePicture);
                                pic.BackColor = Color.White;
                                flowLayoutPanel3.Controls.Add(pic);
                                pic.ClientSize = new Size(84, 84);
                                pic.Name = $"{i};{j}";
                                pic.Tag = 5;
                            }
                            break;
                        case 1:
                            {
                                PictureBox pic = new PictureBox();
                                pic.Image = choiceBitmap[4];
                                pic.Click += new EventHandler(ChangePicture);
                                flowLayoutPanel3.Controls.Add(pic);
                                pic.ClientSize = new Size(84, 84);
                                pic.BackColor = Color.White;
                                pic.Name = $"{i};{j}";
                                pic.Tag = 4;
                            }
                            break;
                        case 2:
                            {
                                PictureBox pic = new PictureBox();
                                pic.Image = choiceBitmap[1];
                                pic.Click += new EventHandler(ChangePicture);
                                flowLayoutPanel3.Controls.Add(pic);
                                pic.ClientSize = new Size(84, 84);
                                pic.BackColor = Color.White;
                                pic.Name = $"{i};{j}";
                                pic.Tag = 1;
                                _posPerson = tmp;
                            }
                            break;
                        case 3:
                            {
                                PictureBox pic = new PictureBox();
                                pic.Image = choiceBitmap[2];
                                pic.Click += new EventHandler(ChangePicture);
                                flowLayoutPanel3.Controls.Add(pic);
                                pic.ClientSize = new Size(84, 84);
                                pic.BackColor = Color.White;
                                pic.Name = $"{i};{j}";
                                pic.Tag = 2;
                                _posGoal = tmp;
                            }
                            break;
                            tmp++;
                    }
                
                }
            flowLayoutPanel3.Size = new Size(_valueM * 90, tableLayoutPanel1.Height - 71);
        }
        private Dictionary<int, Bitmap> choiceBitmap = new Dictionary<int, Bitmap>()
        {
            {1, new Bitmap(Resources.Cell_Person) },
            {2, new Bitmap(Resources.Cell_Goal) },
            {3, new Bitmap(Resources.Cell_Bomb) },
            {4, new Bitmap(Resources.Cell_Obstacle) },
            {5, null }
        };
        private void ChangePicture(object sender, EventArgs e)
        {
            if (_choiceIcon != null)
            {
                if (_posPerson != null && _choiceIcon == 1)
                {
                    MessageBox.Show("Вы уже добавили одного персонажа в лабиринт", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(_posGoal != null && _choiceIcon == 2)
                {
                    MessageBox.Show("Вы уже добавили одну цель в лабиринт", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                PictureBox tmp = (PictureBox)sender;
                int i = 0;
                while (((PictureBox)flowLayoutPanel3.Controls[i]).Name != tmp.Name)
                    i++;
                if (tmp.Image == null)
                {
                    if (_choiceIcon == 1)
                        _posPerson = i;
                    if (_choiceIcon == 2)
                        _posGoal = i;
                }
                else
                {
                    if ((int)((PictureBox)flowLayoutPanel3.Controls[i]).Tag == 1)
                        _posPerson = null;
                    if ((int)((PictureBox)flowLayoutPanel3.Controls[i]).Tag == 2)
                        _posGoal = null;
                }
                ((PictureBox)flowLayoutPanel3.Controls[i]).Image = choiceBitmap[(int)_choiceIcon];
                ((PictureBox)flowLayoutPanel3.Controls[i]).Tag = _choiceIcon;
            }
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            FormRedraw formRedraw = new FormRedraw();
            if(formRedraw.ShowDialog() == DialogResult.OK)
            {
                _valueM = (int)formRedraw.FirstValue;
                _valueN = (int)formRedraw.SecondValue;
                _valueL = (int)formRedraw.ThreeValue;
                CreateLabyrinth();
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if(_posGoal == null)
            {
                MessageBox.Show("Точка назначения не выбрана", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_posPerson == null)
            {
                MessageBox.Show("Местоположение персонажа не выбрано", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(isCorrectWay)
            {

            }
            buttonBack.Enabled = false;
            buttonStart.Enabled = false;
            buttonClear.Enabled = false;
            Cell[,] param = new Cell[_valueM, _valueN];
            Point posPerson = new Point();
            Point posGoal = new Point();
            int tmp = 0;
            for (int i = 0; i < _valueM; i++)
                for (int j = 0; j < _valueN; j++)
                {
                    int meaning = (int)((PictureBox)flowLayoutPanel3.Controls[tmp]).Tag;
                    param[i, j] = new Cell { Pos = tmp, MeaningCell = meaning == 4 ? 1 : 0 };
                    if (meaning == 1)
                        posPerson = new Point() { Y = i, X = j };
                    if (meaning == 2)
                        posGoal = new Point() { Y = i, X = j };
                    tmp++;
                }
            int[] way = WaveAlgorithm.GetWay(param, _valueM, _valueN, _valueL, posPerson, posGoal);
            if(way == null)
            {
                MessageBox.Show("Не удается построить путь", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isCorrectWay = false;
                return;
            }
            isCorrectWay = true;
            for(int i = 0; i < way.Length; i++)
            {
                if ((int)((PictureBox)flowLayoutPanel3.Controls[way[i]]).Tag == 4)
                    ((PictureBox)flowLayoutPanel3.Controls[way[i]]).BackColor = Color.Red;
                else
                    ((PictureBox)flowLayoutPanel3.Controls[way[i]]).BackColor = Color.Green;
                Thread.Sleep(1000);
            }
        }
    }
}
