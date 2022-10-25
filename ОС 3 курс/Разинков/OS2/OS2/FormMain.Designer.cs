namespace OS2
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxFirstDir = new System.Windows.Forms.TextBox();
            this.buttonSelectFirstDir = new System.Windows.Forms.Button();
            this.folderBrowserDialogMain = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonSelectSecondDir = new System.Windows.Forms.Button();
            this.textBoxSecondDir = new System.Windows.Forms.TextBox();
            this.labelDirectoryName = new System.Windows.Forms.Label();
            this.labelSetFileSizeInBytes = new System.Windows.Forms.Label();
            this.numericUpDownSetFileSize = new System.Windows.Forms.NumericUpDown();
            this.labelSetFileSizeBlock = new System.Windows.Forms.Label();
            this.domainUpDownSetFileSizeBlockType = new System.Windows.Forms.DomainUpDown();
            this.buttonCountFiles = new System.Windows.Forms.Button();
            this.labelFirstDirFilesCountText = new System.Windows.Forms.Label();
            this.labelFirstDirFilesCount = new System.Windows.Forms.Label();
            this.labelSecondDirFilesCountText = new System.Windows.Forms.Label();
            this.labelSecondDirFilesCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSetFileSize)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxFirstDir
            // 
            this.textBoxFirstDir.Location = new System.Drawing.Point(15, 40);
            this.textBoxFirstDir.MaxLength = 240;
            this.textBoxFirstDir.Name = "textBoxFirstDir";
            this.textBoxFirstDir.ReadOnly = true;
            this.textBoxFirstDir.Size = new System.Drawing.Size(482, 22);
            this.textBoxFirstDir.TabIndex = 0;
            this.textBoxFirstDir.TextChanged += new System.EventHandler(this.textBoxFirstDir_TextChanged);
            // 
            // buttonSelectFirstDir
            // 
            this.buttonSelectFirstDir.Location = new System.Drawing.Point(527, 39);
            this.buttonSelectFirstDir.Name = "buttonSelectFirstDir";
            this.buttonSelectFirstDir.Size = new System.Drawing.Size(102, 23);
            this.buttonSelectFirstDir.TabIndex = 1;
            this.buttonSelectFirstDir.Text = "Выберите";
            this.buttonSelectFirstDir.UseVisualStyleBackColor = true;
            this.buttonSelectFirstDir.Click += new System.EventHandler(this.buttonSelectFirstDir_Click);
            // 
            // buttonSelectSecondDir
            // 
            this.buttonSelectSecondDir.Location = new System.Drawing.Point(527, 86);
            this.buttonSelectSecondDir.Name = "buttonSelectSecondDir";
            this.buttonSelectSecondDir.Size = new System.Drawing.Size(102, 23);
            this.buttonSelectSecondDir.TabIndex = 5;
            this.buttonSelectSecondDir.Text = "Выберите";
            this.buttonSelectSecondDir.UseVisualStyleBackColor = true;
            this.buttonSelectSecondDir.Click += new System.EventHandler(this.buttonSelectSecondDir_Click);
            // 
            // textBoxSecondDir
            // 
            this.textBoxSecondDir.Location = new System.Drawing.Point(15, 87);
            this.textBoxSecondDir.MaxLength = 240;
            this.textBoxSecondDir.Name = "textBoxSecondDir";
            this.textBoxSecondDir.ReadOnly = true;
            this.textBoxSecondDir.Size = new System.Drawing.Size(482, 22);
            this.textBoxSecondDir.TabIndex = 4;
            this.textBoxSecondDir.TextChanged += new System.EventHandler(this.textBoxSecondDir_TextChanged);
            // 
            // labelDirectoryName
            // 
            this.labelDirectoryName.AutoSize = true;
            this.labelDirectoryName.Location = new System.Drawing.Point(12, 9);
            this.labelDirectoryName.Name = "labelDirectoryName";
            this.labelDirectoryName.Size = new System.Drawing.Size(167, 17);
            this.labelDirectoryName.TabIndex = 6;
            this.labelDirectoryName.Text = "Выбранные директории";
            // 
            // labelSetFileSizeInBytes
            // 
            this.labelSetFileSizeInBytes.AutoSize = true;
            this.labelSetFileSizeInBytes.Location = new System.Drawing.Point(12, 131);
            this.labelSetFileSizeInBytes.Name = "labelSetFileSizeInBytes";
            this.labelSetFileSizeInBytes.Size = new System.Drawing.Size(108, 17);
            this.labelSetFileSizeInBytes.TabIndex = 7;
            this.labelSetFileSizeInBytes.Text = "Размер файла:";
            // 
            // numericUpDownSetFileSize
            // 
            this.numericUpDownSetFileSize.Location = new System.Drawing.Point(201, 131);
            this.numericUpDownSetFileSize.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownSetFileSize.Name = "numericUpDownSetFileSize";
            this.numericUpDownSetFileSize.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownSetFileSize.TabIndex = 11;
            this.numericUpDownSetFileSize.ValueChanged += new System.EventHandler(this.numericUpDownSetFileSize_ValueChanged);
            // 
            // labelSetFileSizeBlock
            // 
            this.labelSetFileSizeBlock.AutoSize = true;
            this.labelSetFileSizeBlock.Location = new System.Drawing.Point(12, 160);
            this.labelSetFileSizeBlock.Name = "labelSetFileSizeBlock";
            this.labelSetFileSizeBlock.Size = new System.Drawing.Size(176, 17);
            this.labelSetFileSizeBlock.TabIndex = 12;
            this.labelSetFileSizeBlock.Text = "Единица размера файла:";
            // 
            // domainUpDownSetFileSizeBlockType
            // 
            this.domainUpDownSetFileSizeBlockType.Items.Add("Байт");
            this.domainUpDownSetFileSizeBlockType.Items.Add("Килобайт");
            this.domainUpDownSetFileSizeBlockType.Items.Add("Мегабайт");
            this.domainUpDownSetFileSizeBlockType.Items.Add("Гигабайт");
            this.domainUpDownSetFileSizeBlockType.Location = new System.Drawing.Point(201, 160);
            this.domainUpDownSetFileSizeBlockType.Name = "domainUpDownSetFileSizeBlockType";
            this.domainUpDownSetFileSizeBlockType.Size = new System.Drawing.Size(120, 22);
            this.domainUpDownSetFileSizeBlockType.TabIndex = 13;
            this.domainUpDownSetFileSizeBlockType.Text = "Байт";
            // 
            // buttonCountFiles
            // 
            this.buttonCountFiles.Location = new System.Drawing.Point(527, 154);
            this.buttonCountFiles.Name = "buttonCountFiles";
            this.buttonCountFiles.Size = new System.Drawing.Size(102, 23);
            this.buttonCountFiles.TabIndex = 14;
            this.buttonCountFiles.Text = "Считать";
            this.buttonCountFiles.UseVisualStyleBackColor = true;
            this.buttonCountFiles.Click += new System.EventHandler(this.buttonCountFiles_Click);
            // 
            // labelFirstDirFilesCountText
            // 
            this.labelFirstDirFilesCountText.AutoSize = true;
            this.labelFirstDirFilesCountText.Location = new System.Drawing.Point(12, 195);
            this.labelFirstDirFilesCountText.Name = "labelFirstDirFilesCountText";
            this.labelFirstDirFilesCountText.Size = new System.Drawing.Size(288, 17);
            this.labelFirstDirFilesCountText.TabIndex = 15;
            this.labelFirstDirFilesCountText.Text = "Количество файлов в первой директории:";
            // 
            // labelFirstDirFilesCount
            // 
            this.labelFirstDirFilesCount.AutoSize = true;
            this.labelFirstDirFilesCount.Location = new System.Drawing.Point(321, 195);
            this.labelFirstDirFilesCount.Name = "labelFirstDirFilesCount";
            this.labelFirstDirFilesCount.Size = new System.Drawing.Size(0, 17);
            this.labelFirstDirFilesCount.TabIndex = 16;
            // 
            // labelSecondDirFilesCountText
            // 
            this.labelSecondDirFilesCountText.AutoSize = true;
            this.labelSecondDirFilesCountText.Location = new System.Drawing.Point(12, 226);
            this.labelSecondDirFilesCountText.Name = "labelSecondDirFilesCountText";
            this.labelSecondDirFilesCountText.Size = new System.Drawing.Size(295, 17);
            this.labelSecondDirFilesCountText.TabIndex = 17;
            this.labelSecondDirFilesCountText.Text = "Количество файлов во второй директории:";
            // 
            // labelSecondDirFilesCount
            // 
            this.labelSecondDirFilesCount.AutoSize = true;
            this.labelSecondDirFilesCount.Location = new System.Drawing.Point(321, 226);
            this.labelSecondDirFilesCount.Name = "labelSecondDirFilesCount";
            this.labelSecondDirFilesCount.Size = new System.Drawing.Size(0, 17);
            this.labelSecondDirFilesCount.TabIndex = 18;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 254);
            this.Controls.Add(this.labelSecondDirFilesCount);
            this.Controls.Add(this.labelSecondDirFilesCountText);
            this.Controls.Add(this.labelFirstDirFilesCount);
            this.Controls.Add(this.labelFirstDirFilesCountText);
            this.Controls.Add(this.buttonCountFiles);
            this.Controls.Add(this.domainUpDownSetFileSizeBlockType);
            this.Controls.Add(this.labelSetFileSizeBlock);
            this.Controls.Add(this.numericUpDownSetFileSize);
            this.Controls.Add(this.labelSetFileSizeInBytes);
            this.Controls.Add(this.labelDirectoryName);
            this.Controls.Add(this.buttonSelectSecondDir);
            this.Controls.Add(this.textBoxSecondDir);
            this.Controls.Add(this.buttonSelectFirstDir);
            this.Controls.Add(this.textBoxFirstDir);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(656, 301);
            this.MinimumSize = new System.Drawing.Size(656, 301);
            this.Name = "FormMain";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSetFileSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFirstDir;
        private System.Windows.Forms.Button buttonSelectFirstDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogMain;
        private System.Windows.Forms.Button buttonSelectSecondDir;
        private System.Windows.Forms.TextBox textBoxSecondDir;
        private System.Windows.Forms.Label labelDirectoryName;
        private System.Windows.Forms.Label labelSetFileSizeInBytes;
        private System.Windows.Forms.NumericUpDown numericUpDownSetFileSize;
        private System.Windows.Forms.Label labelSetFileSizeBlock;
        private System.Windows.Forms.DomainUpDown domainUpDownSetFileSizeBlockType;
        private System.Windows.Forms.Button buttonCountFiles;
        private System.Windows.Forms.Label labelFirstDirFilesCountText;
        private System.Windows.Forms.Label labelFirstDirFilesCount;
        private System.Windows.Forms.Label labelSecondDirFilesCountText;
        private System.Windows.Forms.Label labelSecondDirFilesCount;
    }
}

