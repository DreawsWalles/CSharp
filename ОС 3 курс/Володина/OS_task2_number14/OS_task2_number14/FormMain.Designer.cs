namespace OS_task2_number14
{
    partial class FormMain
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.tbFirstDir = new System.Windows.Forms.TextBox();
            this.tbSecondDir = new System.Windows.Forms.TextBox();
            this.btnFirstDir = new System.Windows.Forms.Button();
            this.btnSecondDir = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbFirstDir = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFirstDirFiles = new System.Windows.Forms.TextBox();
            this.gbSecondDir = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSecondDirFiles = new System.Windows.Forms.TextBox();
            this.gbFirstDir.SuspendLayout();
            this.gbSecondDir.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbFirstDir
            // 
            this.tbFirstDir.BackColor = System.Drawing.Color.White;
            this.tbFirstDir.Location = new System.Drawing.Point(9, 25);
            this.tbFirstDir.Name = "tbFirstDir";
            this.tbFirstDir.ReadOnly = true;
            this.tbFirstDir.Size = new System.Drawing.Size(231, 20);
            this.tbFirstDir.TabIndex = 0;
            // 
            // tbSecondDir
            // 
            this.tbSecondDir.BackColor = System.Drawing.Color.White;
            this.tbSecondDir.Location = new System.Drawing.Point(6, 27);
            this.tbSecondDir.Name = "tbSecondDir";
            this.tbSecondDir.ReadOnly = true;
            this.tbSecondDir.Size = new System.Drawing.Size(222, 20);
            this.tbSecondDir.TabIndex = 1;
            // 
            // btnFirstDir
            // 
            this.btnFirstDir.Location = new System.Drawing.Point(249, 22);
            this.btnFirstDir.Name = "btnFirstDir";
            this.btnFirstDir.Size = new System.Drawing.Size(75, 23);
            this.btnFirstDir.TabIndex = 2;
            this.btnFirstDir.Text = "Обзор...";
            this.btnFirstDir.UseVisualStyleBackColor = true;
            this.btnFirstDir.Click += new System.EventHandler(this.btnFirstDir_Click);
            // 
            // btnSecondDir
            // 
            this.btnSecondDir.Location = new System.Drawing.Point(236, 25);
            this.btnSecondDir.Name = "btnSecondDir";
            this.btnSecondDir.Size = new System.Drawing.Size(75, 23);
            this.btnSecondDir.TabIndex = 3;
            this.btnSecondDir.Text = "Обзор...";
            this.btnSecondDir.UseVisualStyleBackColor = true;
            this.btnSecondDir.Click += new System.EventHandler(this.btnSecondDir_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(308, 428);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Старт";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Первый каталог:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Второй каталог:";
            // 
            // gbFirstDir
            // 
            this.gbFirstDir.Controls.Add(this.label3);
            this.gbFirstDir.Controls.Add(this.tbFirstDirFiles);
            this.gbFirstDir.Controls.Add(this.tbFirstDir);
            this.gbFirstDir.Controls.Add(this.label1);
            this.gbFirstDir.Controls.Add(this.btnFirstDir);
            this.gbFirstDir.Location = new System.Drawing.Point(12, 7);
            this.gbFirstDir.Name = "gbFirstDir";
            this.gbFirstDir.Size = new System.Drawing.Size(330, 415);
            this.gbFirstDir.TabIndex = 7;
            this.gbFirstDir.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Атрибуты файлов";
            // 
            // tbFirstDirFiles
            // 
            this.tbFirstDirFiles.BackColor = System.Drawing.Color.White;
            this.tbFirstDirFiles.Location = new System.Drawing.Point(9, 71);
            this.tbFirstDirFiles.Multiline = true;
            this.tbFirstDirFiles.Name = "tbFirstDirFiles";
            this.tbFirstDirFiles.ReadOnly = true;
            this.tbFirstDirFiles.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbFirstDirFiles.Size = new System.Drawing.Size(315, 338);
            this.tbFirstDirFiles.TabIndex = 8;
            // 
            // gbSecondDir
            // 
            this.gbSecondDir.Controls.Add(this.label4);
            this.gbSecondDir.Controls.Add(this.tbSecondDirFiles);
            this.gbSecondDir.Controls.Add(this.label2);
            this.gbSecondDir.Controls.Add(this.tbSecondDir);
            this.gbSecondDir.Controls.Add(this.btnSecondDir);
            this.gbSecondDir.Location = new System.Drawing.Point(348, 7);
            this.gbSecondDir.Name = "gbSecondDir";
            this.gbSecondDir.Size = new System.Drawing.Size(317, 415);
            this.gbSecondDir.TabIndex = 0;
            this.gbSecondDir.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Атрибуты файлов";
            // 
            // tbSecondDirFiles
            // 
            this.tbSecondDirFiles.BackColor = System.Drawing.Color.White;
            this.tbSecondDirFiles.Location = new System.Drawing.Point(6, 71);
            this.tbSecondDirFiles.Multiline = true;
            this.tbSecondDirFiles.Name = "tbSecondDirFiles";
            this.tbSecondDirFiles.ReadOnly = true;
            this.tbSecondDirFiles.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbSecondDirFiles.Size = new System.Drawing.Size(305, 338);
            this.tbSecondDirFiles.TabIndex = 9;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 463);
            this.Controls.Add(this.gbSecondDir);
            this.Controls.Add(this.gbFirstDir);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task 2";
            this.gbFirstDir.ResumeLayout(false);
            this.gbFirstDir.PerformLayout();
            this.gbSecondDir.ResumeLayout(false);
            this.gbSecondDir.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        public System.Windows.Forms.TextBox tbFirstDir;
        public System.Windows.Forms.TextBox tbSecondDir;
        private System.Windows.Forms.Button btnFirstDir;
        private System.Windows.Forms.Button btnSecondDir;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbFirstDir;
        private System.Windows.Forms.GroupBox gbSecondDir;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tbFirstDirFiles;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tbSecondDirFiles;
    }
}

