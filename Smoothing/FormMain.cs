using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_14
{
    public partial class FormMain : Form
    {
        private List<bool> _savesPictures = new List<bool>();
        private List<NodeHistory> _backAction = new List<NodeHistory>();
        private List<NodeHistory> _nextAction = new List<NodeHistory>();
        private List<string> _sourcePictures = new List<string>();
        private int _sizeSmoothing = 1;
        public FormMain()
        {
            InitializeComponent();
            menuStrip1.Renderer = new NoHigthligthRenderer();
            foreach (ToolStripMenuItem item in menuStrip1.Items)
                SetColor_1(item);
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new ChangeStyleItem());
            tabControl1.Visible = false;
            btnFilter.Enabled = false;
            btnBack.Enabled = false;
            btnReturn.Enabled = false;
            btnSave.Enabled = false;
            btnClose.Enabled = false;

            progressBar1.Visible = false;
            label1.Visible = false;

            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
        }



        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != -1 && !(_backAction[_backAction.Count - 1].NumTabPage == tabControl1.SelectedIndex && _backAction[_backAction.Count - 1].Action == "open"))
            {
                _backAction.Add(new NodeHistory()
                {
                    NumTabPage = tabControl1.SelectedIndex,
                    File = (string)tabControl1.TabPages[tabControl1.SelectedIndex].Tag,
                    Action = "open"
                });
                btnBack.BackgroundImage = _backAction.Count > 1 ? Properties.Resources.back_black : Properties.Resources.back_gray;
                btnBack.Enabled = _backAction.Count > 1 ? true : false;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 18, Size.Height - 40);
            tabControl1.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            flowLayoutPanel1.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            flowLayoutPanel1.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 18, Size.Height - 40);
            tabControl1.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            flowLayoutPanel1.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            if(tabControl1.TabPages.Count != 0)
                foreach (var element in tabControl1.TabPages[tabControl1.SelectedIndex].Controls)
                    try
                    {
                        ((TableLayoutPanel)element).Size = tabControl1.Size;
                    }
                    catch { }
        }

        private void SetColor_1(ToolStripMenuItem item)
        {
            item.ForeColor = Color.Black;
            foreach (ToolStripMenuItem it in item.DropDownItems)
                SetColor_1(it);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            label1.Visible = false;
            
            using (OpenFileDialog open_dialog = new OpenFileDialog())
            { 
                open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
                if (open_dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        TabPage tabPage = new TabPage();
                        TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
                        tableLayoutPanel.Size = tabControl1.Size;
                        PictureBox pictureBox = new PictureBox();
                        tabPage.Controls.Add(tableLayoutPanel);
                        using (Stream s = new FileStream(open_dialog.FileName, FileMode.Open, FileAccess.Read))
                        {
                            pictureBox.Size = Image.FromStream(s).Size;
                            pictureBox.Image = Image.FromStream(s);
                            pictureBox.Invalidate();
                        }
                        tabPage.BackColor = Color.White;
                        string name = Path.GetFileName(open_dialog.FileName);
                        tabPage.Text = name.Length <= 15 ? name : name.Substring(0, 7) + "..." + name.Substring(name.Length - 5);
                        tabPage.Tag = Convert.ToBase64String(File.ReadAllBytes(open_dialog.FileName));
                        tabPage.Name = open_dialog.FileName;
                        pictureBox.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom);
                        tableLayoutPanel.Controls.Add(pictureBox);
                        tabControl1.Visible = true;
                        tabControl1.TabPages.Add(tabPage);
                        tabControl1.SelectedIndex = tabControl1.TabPages.Count == 1 ? 0 : tabControl1.TabPages.Count - 1;

                        btnFilter.BackgroundImage = Properties.Resources.filter_black;
                        btnFilter.Enabled = true;
                        btnSave.Enabled = true;
                        btnSave.BackgroundImage = Properties.Resources.save_black;
                        btnClose.Enabled = true;
                        btnClose.BackgroundImage = Properties.Resources.close_black;
                        _savesPictures.Add(true);
                        _sourcePictures.Add((string)tabPage.Tag);

                        if (tabControl1.TabPages.Count == 1)
                        {
                            _backAction.Add(new NodeHistory()
                            {
                                NumTabPage = tabControl1.SelectedIndex,
                                File = (string)tabControl1.TabPages[tabControl1.SelectedIndex].Tag,
                                Action = "open"
                            });
                            btnBack.BackgroundImage = _backAction.Count > 1 ? Properties.Resources.back_black : Properties.Resources.back_gray;
                            btnBack.Enabled = _backAction.Count > 1 ? true : false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(null, null);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            label1.Visible = false;
            if (tabControl1.TabPages.Count > 0 && !_savesPictures[tabControl1.SelectedIndex])
            {
                using (Stream s = new FileStream(tabControl1.TabPages[tabControl1.SelectedIndex].Name, FileMode.Create, FileAccess.Write))
                {
                    try
                    {
                        ((PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0].Controls[0]).Image.Save(s, System.Drawing.Imaging.ImageFormat.Png);
                        using(MemoryStream ms = new MemoryStream())
                        {
                            ((PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0].Controls[0]).Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            tabControl1.TabPages[tabControl1.SelectedIndex].Tag = Convert.ToBase64String(ms.ToArray());
                            _sourcePictures[tabControl1.SelectedIndex] = (string)tabControl1.TabPages[tabControl1.SelectedIndex].Tag;
                        }
                        tabControl1.TabPages[tabControl1.SelectedIndex].Text = tabControl1.TabPages[tabControl1.SelectedIndex].Text.Substring(tabControl1.TabPages[tabControl1.SelectedIndex].Text.Length - 2);
                        _backAction = _backAction.Where(element => element.NumTabPage != tabControl1.SelectedIndex).ToList();
                        _nextAction = _nextAction.Where(element => element.NumTabPage != tabControl1.SelectedIndex).ToList();
                        btnBack.BackgroundImage = _backAction.Count > 1 ? Properties.Resources.back_black : Properties.Resources.back_gray;
                        btnBack.Enabled = _backAction.Count > 1 ? true : false;
                        btnReturn.BackgroundImage = _nextAction.Count > 0 ? Properties.Resources.go_black : Properties.Resources.go_gray;
                        btnReturn.Enabled = _nextAction.Count > 0 ? true : false;
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить выбранную картинку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            label1.Visible = false;
            if (tabControl1.TabPages.Count > 0)
            {
                using (SaveFileDialog fileDialoge = new SaveFileDialog())
                {
                    fileDialoge.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
                    if (fileDialoge.ShowDialog() == DialogResult.OK)
                    {
                        using (Stream s = new FileStream(fileDialoge.FileName, FileMode.Create, FileAccess.Write))
                        {
                            try
                            {
                                ((PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0].Controls[0]).Image.Save(s, System.Drawing.Imaging.ImageFormat.Png);
                                tabControl1.TabPages[tabControl1.SelectedIndex].Name = fileDialoge.FileName;
                                string name = Path.GetFileName(fileDialoge.FileName);
                                tabControl1.TabPages[tabControl1.SelectedIndex].Text = name.Length <= 15 ? name : name.Substring(0, 7) + "..." + name.Substring(name.Length - 5);
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    ((PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0].Controls[0]).Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    tabControl1.TabPages[tabControl1.SelectedIndex].Tag = Convert.ToBase64String(ms.ToArray());
                                    _sourcePictures[tabControl1.SelectedIndex] = (string)tabControl1.TabPages[tabControl1.SelectedIndex].Tag;
                                }
                                _backAction = _backAction.Where(element => element.NumTabPage != tabControl1.SelectedIndex).ToList();
                                _nextAction = _nextAction.Where(element => element.NumTabPage != tabControl1.SelectedIndex).ToList();
                                btnBack.BackgroundImage = _backAction.Count > 1 ? Properties.Resources.back_black : Properties.Resources.back_gray;
                                btnBack.Enabled = _backAction.Count > 1 ? true : false;
                                btnReturn.BackgroundImage = _nextAction.Count > 0 ? Properties.Resources.go_black : Properties.Resources.go_gray;
                                btnReturn.Enabled = _nextAction.Count > 0 ? true : false;
                            }
                            catch
                            {
                                MessageBox.Show("Невозможно сохранить выбранную картинку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            label1.Visible = false;
            if (tabControl1.TabPages.Count > 0)
            {
                for(int i = 0; i < tabControl1.TabPages.Count; i++)
                    if(!_savesPictures[i])
                        using (Stream s = new FileStream(tabControl1.TabPages[i].Name, FileMode.Create, FileAccess.Write))
                        {
                            try
                            {
                                ((PictureBox)tabControl1.TabPages[i].Controls[0].Controls[0]).Image.Save(s, System.Drawing.Imaging.ImageFormat.Png);
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    ((PictureBox)tabControl1.TabPages[i].Controls[0].Controls[0]).Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    tabControl1.TabPages[i].Tag = Convert.ToBase64String(ms.ToArray());
                                    _sourcePictures[i] = (string)tabControl1.TabPages[i].Tag;
                                }
                                tabControl1.TabPages[i].Text = tabControl1.TabPages[i].Text.Substring(tabControl1.TabPages[i].Text.Length - 2);
                                _backAction.Clear();
                                _nextAction.Clear();
                                btnBack.BackgroundImage = Properties.Resources.back_gray;
                                btnBack.Enabled = false;
                                btnReturn.BackgroundImage = Properties.Resources.go_gray;
                                btnReturn.Enabled = false;
                            }
                            catch
                            {
                                MessageBox.Show("Невозможно сохранить картинку: \"" + tabControl1.TabPages[i].Text + " \"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(null, null);
        }

        private void canselToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btnBack.Enabled)
            {
                progressBar1.Visible = false;
                label1.Visible = false;
                NodeHistory tmp = _backAction[_backAction.Count - 1];
                _nextAction.Add(tmp);
                _backAction.RemoveAt(_backAction.Count - 1);
                btnReturn.Enabled = true;
                btnReturn.BackgroundImage = Properties.Resources.go_gray;
                btnBack.BackgroundImage = _backAction.Count > 1 ? Properties.Resources.back_black : Properties.Resources.back_gray;
                btnBack.Enabled = _backAction.Count > 1 ? true : false;
                switch (tmp.Action)
                {
                    case "open":
                        tabControl1.SelectedIndex = _backAction[_backAction.Count - 1].NumTabPage;
                        break;
                    case "mask":
                        using (MemoryStream ms = new MemoryStream())
                        {
                            byte[] bytes = Convert.FromBase64String(_backAction[_backAction.Count - 1].File);
                            ms.Write(bytes, 0, bytes.Length);
                            ((PictureBox)tabControl1.TabPages[tmp.NumTabPage].Controls[0].Controls[0]).Image = Image.FromStream(ms);
                            tabControl1.TabPages[tmp.NumTabPage].Tag = _backAction[_backAction.Count - 1].File;
                            if (_backAction[_backAction.Count - 1].File == _sourcePictures[tmp.NumTabPage]
                                && tabControl1.TabPages[tmp.NumTabPage].Text[tabControl1.TabPages[tmp.NumTabPage].Text.Length - 1] == '*')
                                tabControl1.TabPages[tmp.NumTabPage].Text = tabControl1.TabPages[tmp.NumTabPage].Text.Remove(tabControl1.TabPages[tmp.NumTabPage].Text.Length - 1);
                            if (_backAction[_backAction.Count - 1].File != _sourcePictures[tmp.NumTabPage]
                                && tabControl1.TabPages[tmp.NumTabPage].Text[tabControl1.TabPages[tmp.NumTabPage].Text.Length - 1] != '*')
                                tabControl1.TabPages[tmp.NumTabPage].Text = tabControl1.TabPages[tmp.NumTabPage].Text += '*';
                        }
                        break;
                }
            }
        }
        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btnReturn.Enabled)
            {
                progressBar1.Visible = false;
                label1.Visible = false;
                NodeHistory tmp = _nextAction[_nextAction.Count - 1];
                _nextAction.RemoveAt(_nextAction.Count - 1);
                _backAction.Add(tmp);
                switch (tmp.Action)
                {
                    case "open":
                        tabControl1.SelectedIndex = tmp.NumTabPage;
                        break;
                    case "mask":
                        using (MemoryStream ms = new MemoryStream())
                        {
                            byte[] bytes = Convert.FromBase64String(tmp.File);
                            ms.Write(bytes, 0, bytes.Length);
                            ((PictureBox)tabControl1.TabPages[tmp.NumTabPage].Controls[0].Controls[0]).Image = Image.FromStream(ms);
                            tabControl1.TabPages[tmp.NumTabPage].Tag = _backAction[_backAction.Count - 1].File;
                            if (_backAction[_backAction.Count - 1].File == _sourcePictures[tmp.NumTabPage]
                                && tabControl1.TabPages[tmp.NumTabPage].Text[tabControl1.TabPages[tmp.NumTabPage].Text.Length - 1] == '*')
                                tabControl1.TabPages[tmp.NumTabPage].Text = tabControl1.TabPages[tmp.NumTabPage].Text.Remove(tabControl1.TabPages[tmp.NumTabPage].Text.Length - 1);
                            if (_backAction[_backAction.Count - 1].File != _sourcePictures[tmp.NumTabPage]
                                && tabControl1.TabPages[tmp.NumTabPage].Text[tabControl1.TabPages[tmp.NumTabPage].Text.Length - 1] != '*')
                                tabControl1.TabPages[tmp.NumTabPage].Text = tabControl1.TabPages[tmp.NumTabPage].Text += '*';
                        }
                        break;
                }
                btnReturn.BackgroundImage = _nextAction.Count > 0 ? Properties.Resources.go_black : Properties.Resources.go_gray;
                btnReturn.Enabled = _nextAction.Count > 0 ? true : false;
                btnBack.BackgroundImage = _backAction.Count > 1 ? Properties.Resources.back_black : Properties.Resources.back_gray;
                btnBack.Enabled = _backAction.Count > 1 ? true : false;
            }
        }

        private void takeMaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (!backgroundWorker1.IsBusy)
            {
                FormSize form = new FormSize();
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    _sizeSmoothing = form.SizeSmoothing;
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            else
                MessageBox.Show("В данный момент времени происходит обработка изображения", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            progressBar1.Invoke((MethodInvoker)delegate
            {
                progressBar1.Visible = false;
            });
            label1.Invoke((MethodInvoker)delegate
            {
                label1.Visible = false;
            });
            if (tabControl1.TabPages.Count > 0)
            {
                try
                {
                    string tmp = null;
                    PictureBox picBox = null;
                    Invoke(new Action(() =>
                    {
                        tmp = (string)tabControl1.TabPages[tabControl1.SelectedIndex].Tag;
                        picBox = ((PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0].Controls[0]);
                    }));
                    
                    using (MemoryStream ms = new MemoryStream())
                    {
                        byte[] bytes = Convert.FromBase64String(tmp);
                        ms.Write(bytes, 0, bytes.Length);
                        var img = Image.FromStream(ms);
                        Stopwatch t = new Stopwatch();
                        t.Start();
                        Masks masks = new Masks((Bitmap)img,_sizeSmoothing,this);
                        img = masks.Smoothing();
                        t.Stop();
                        Console.WriteLine(t.Elapsed);
                        Invoke(new Action(() =>
                        {
                            picBox.Image = img;
                            if (tabControl1.TabPages[tabControl1.SelectedIndex].Text[tabControl1.TabPages[tabControl1.SelectedIndex].Text.Length - 1] != '*')
                                tabControl1.TabPages[tabControl1.SelectedIndex].Text += "*";
                            using (MemoryStream msout = new MemoryStream())
                            {
                                img.Save(msout, System.Drawing.Imaging.ImageFormat.Png);
                                tabControl1.TabPages[tabControl1.SelectedIndex].Tag = Convert.ToBase64String(msout.ToArray());
                            }
                            _savesPictures[tabControl1.SelectedIndex] = false;
                            picBox.Refresh();
                        }));
                    }
                    Invoke(new Action(() =>
                    {
                        _backAction.Add(new NodeHistory()
                        {
                            NumTabPage = tabControl1.SelectedIndex,
                            File = (string)tabControl1.TabPages[tabControl1.SelectedIndex].Tag,
                            Action = "mask"
                        });
                        btnBack.BackgroundImage = _backAction.Count > 1 ? Properties.Resources.back_black : Properties.Resources.back_gray;
                        btnBack.Enabled = _backAction.Count > 1 ? true : false;
                    }));
                }
                catch
                {
                    Invoke(new Action(() =>
                    {
                        label1.Visible = true;
                        label1.Text = "Обработка была завершена с ошибкой.";
                        progressBar1.Visible = false;
                    }));  
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            canselToolStripMenuItem_Click(null, null);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            returnToolStripMenuItem_Click(null, null);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            label1.Visible = false;
            if (MessageBox.Show("Закрыть файл \"" + tabControl1.TabPages[tabControl1.SelectedIndex].Text + "\"?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!_savesPictures[tabControl1.SelectedIndex] && 
                    MessageBox.Show("Файл \"" + tabControl1.TabPages[tabControl1.SelectedIndex].Text + "\" не сохранен. Сохранить?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    using (Stream s = new FileStream(tabControl1.TabPages[tabControl1.SelectedIndex].Name, FileMode.Create, FileAccess.Write))
                    {
                        try
                        {
                            ((PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0].Controls[0]).Image.Save(s, System.Drawing.Imaging.ImageFormat.Png);
                        }
                        catch
                        {
                            MessageBox.Show("Невозможно сохранить выбранную картинку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                _backAction = _backAction.Where(element => element.NumTabPage != tabControl1.SelectedIndex).ToList();
                _nextAction = _nextAction.Where(element => element.NumTabPage != tabControl1.SelectedIndex).ToList();
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
                _savesPictures.RemoveAt(tabControl1.SelectedIndex);
                if(tabControl1.TabPages.Count > 0)
                    tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                else
                {
                    tabControl1.Visible = false;
                    btnFilter.BackgroundImage = Properties.Resources.filter_gray;
                    btnFilter.Enabled = false;
                    btnSave.Enabled = false;
                    btnSave.BackgroundImage = Properties.Resources.save_gray;
                    btnClose.Enabled = false;
                    btnClose.BackgroundImage = Properties.Resources.close_gray;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            closeToolStripMenuItem_Click(null, null);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            takeMaskToolStripMenuItem_Click(null, null);
        }
    }
}
