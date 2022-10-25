namespace n2
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FDirTextBox = new System.Windows.Forms.TextBox();
            this.SDirTextBox = new System.Windows.Forms.TextBox();
            this.FDirLabel = new System.Windows.Forms.Label();
            this.SDirLabel = new System.Windows.Forms.Label();
            this.FileNumLabel = new System.Windows.Forms.Label();
            this.FileNum = new System.Windows.Forms.NumericUpDown();
            this.StartButton = new System.Windows.Forms.Button();
            this.ResultBox = new System.Windows.Forms.TextBox();
            this.HelpButton = new System.Windows.Forms.Button();
            this.FBrDlg1 = new System.Windows.Forms.FolderBrowserDialog();
            this.FBrDlg2 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FileNum)).BeginInit();
            this.SuspendLayout();
            // 
            // FDirTextBox
            // 
            this.FDirTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.FDirTextBox.Location = new System.Drawing.Point(12, 25);
            this.FDirTextBox.Name = "FDirTextBox";
            this.FDirTextBox.ReadOnly = true;
            this.FDirTextBox.Size = new System.Drawing.Size(479, 20);
            this.FDirTextBox.TabIndex = 0;
            // 
            // SDirTextBox
            // 
            this.SDirTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SDirTextBox.Location = new System.Drawing.Point(12, 75);
            this.SDirTextBox.Name = "SDirTextBox";
            this.SDirTextBox.ReadOnly = true;
            this.SDirTextBox.Size = new System.Drawing.Size(479, 20);
            this.SDirTextBox.TabIndex = 1;
            // 
            // FDirLabel
            // 
            this.FDirLabel.AutoSize = true;
            this.FDirLabel.Location = new System.Drawing.Point(12, 9);
            this.FDirLabel.Name = "FDirLabel";
            this.FDirLabel.Size = new System.Drawing.Size(93, 13);
            this.FDirLabel.TabIndex = 2;
            this.FDirLabel.Text = "Первый каталог:";
            // 
            // SDirLabel
            // 
            this.SDirLabel.AutoSize = true;
            this.SDirLabel.Location = new System.Drawing.Point(12, 59);
            this.SDirLabel.Name = "SDirLabel";
            this.SDirLabel.Size = new System.Drawing.Size(89, 13);
            this.SDirLabel.TabIndex = 3;
            this.SDirLabel.Text = "Второй каталог:";
            // 
            // FileNumLabel
            // 
            this.FileNumLabel.AutoSize = true;
            this.FileNumLabel.Location = new System.Drawing.Point(9, 193);
            this.FileNumLabel.Name = "FileNumLabel";
            this.FileNumLabel.Size = new System.Drawing.Size(110, 13);
            this.FileNumLabel.TabIndex = 5;
            this.FileNumLabel.Text = "Количество файлов:";
            // 
            // FileNum
            // 
            this.FileNum.Location = new System.Drawing.Point(136, 190);
            this.FileNum.Name = "FileNum";
            this.FileNum.Size = new System.Drawing.Size(110, 20);
            this.FileNum.TabIndex = 6;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(265, 185);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(110, 29);
            this.StartButton.TabIndex = 7;
            this.StartButton.Text = "Выполнить";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ResultBox
            // 
            this.ResultBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ResultBox.Location = new System.Drawing.Point(12, 124);
            this.ResultBox.Multiline = true;
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.ReadOnly = true;
            this.ResultBox.Size = new System.Drawing.Size(479, 55);
            this.ResultBox.TabIndex = 8;
            // 
            // HelpButton
            // 
            this.HelpButton.Location = new System.Drawing.Point(381, 185);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(110, 29);
            this.HelpButton.TabIndex = 9;
            this.HelpButton.Text = "Условие";
            this.HelpButton.UseVisualStyleBackColor = true;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Результат:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 222);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.ResultBox);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.FileNum);
            this.Controls.Add(this.FileNumLabel);
            this.Controls.Add(this.SDirLabel);
            this.Controls.Add(this.FDirLabel);
            this.Controls.Add(this.SDirTextBox);
            this.Controls.Add(this.FDirTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Task #2   18";
            ((System.ComponentModel.ISupportInitialize)(this.FileNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FDirTextBox;
        private System.Windows.Forms.TextBox SDirTextBox;
        private System.Windows.Forms.Label FDirLabel;
        private System.Windows.Forms.Label SDirLabel;
        private System.Windows.Forms.Label FileNumLabel;
        private System.Windows.Forms.NumericUpDown FileNum;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox ResultBox;
        private System.Windows.Forms.Button HelpButton;
        private System.Windows.Forms.FolderBrowserDialog FBrDlg1;
        private System.Windows.Forms.FolderBrowserDialog FBrDlg2;
        private System.Windows.Forms.Label label1;
    }
}

