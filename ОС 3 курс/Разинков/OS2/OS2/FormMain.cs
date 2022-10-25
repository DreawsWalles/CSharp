using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace OS2
{
    enum FileSizeBlockType
    {
        Byte = 1,
        KiloByte = 1024,
        MegaByte = 1024 * 1024,
        GigaByte = 1024 * 1024 * 1024
    };

    public partial class FormMain : Form
    {
        Dictionary<string, FileSizeBlockType> BlockType = new Dictionary<string, FileSizeBlockType>()
        {
            { "Байт",       FileSizeBlockType.Byte      },
            { "Килобайт",   FileSizeBlockType.KiloByte  },
            { "Мегабайт",   FileSizeBlockType.MegaByte  },
            { "Гигабайт",   FileSizeBlockType.GigaByte  }
        };

        DirectoryFileCountInfo firstDir, secondDir;

        public FormMain()
        {
            InitializeComponent();
            Application.Idle += Idle;
            labelFirstDirFilesCount.Text = labelSecondDirFilesCount.Text = "0";
            RsdnDirectory.MaxSizeInBytes = 0;
            firstDir = new DirectoryFileCountInfo();
            secondDir = new DirectoryFileCountInfo();
        }

        void Idle(object sender, EventArgs e)
        {
            buttonCountFiles.Enabled = textBoxFirstDir.Text != "" && textBoxSecondDir.Text != "";
            labelFirstDirFilesCount.Text = firstDir.Count.ToString();
            labelSecondDirFilesCount.Text = secondDir.Count.ToString();
        }

        private void buttonSelectFirstDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogMain.ShowDialog() == DialogResult.OK)
                textBoxFirstDir.Text = firstDir.Path = folderBrowserDialogMain.SelectedPath;
        }

        private void buttonSelectSecondDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogMain.ShowDialog() == DialogResult.OK)
                textBoxSecondDir.Text = secondDir.Path = folderBrowserDialogMain.SelectedPath;
        }

        private void numericUpDownSetFileSize_ValueChanged(object sender, EventArgs e)
        {
            FileSizeBlockType type;
            BlockType.TryGetValue(domainUpDownSetFileSizeBlockType.Text, out type);
            RsdnDirectory.MaxSizeInBytes = (UInt32)(numericUpDownSetFileSize.Value) * (UInt32)type;
        }

        private void buttonCountFiles_Click(object sender, EventArgs e)
        {
            FileCounter.CountFiles(firstDir);
            FileCounter.CountFiles(secondDir);
        }

        private void textBoxFirstDir_TextChanged(object sender, EventArgs e)
        {
            labelFirstDirFilesCount.Text = "0";
        }

        private void textBoxSecondDir_TextChanged(object sender, EventArgs e)
        {
            labelSecondDirFilesCount.Text = "0";
        }
    }
}
