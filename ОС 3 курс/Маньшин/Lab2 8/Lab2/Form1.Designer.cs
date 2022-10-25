namespace Lab2
{
    partial class Form1
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
            this.buttonHelp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPath1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPath2 = new System.Windows.Forms.TextBox();
            this.buttonFirstDirectory = new System.Windows.Forms.Button();
            this.buttonSecondDirectory = new System.Windows.Forms.Button();
            this.labelFirst = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelSecond = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // buttonHelp
            // 
            this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHelp.Location = new System.Drawing.Point(496, 6);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(30, 30);
            this.buttonHelp.TabIndex = 0;
            this.buttonHelp.Text = "?";
            this.buttonHelp.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Первая директория:";
            // 
            // textBoxPath1
            // 
            this.textBoxPath1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPath1.Location = new System.Drawing.Point(128, 6);
            this.textBoxPath1.Name = "textBoxPath1";
            this.textBoxPath1.Size = new System.Drawing.Size(268, 20);
            this.textBoxPath1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Первая директория:";
            // 
            // textBoxPath2
            // 
            this.textBoxPath2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPath2.Location = new System.Drawing.Point(128, 32);
            this.textBoxPath2.Name = "textBoxPath2";
            this.textBoxPath2.Size = new System.Drawing.Size(268, 20);
            this.textBoxPath2.TabIndex = 2;
            // 
            // buttonFirstDirectory
            // 
            this.buttonFirstDirectory.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonFirstDirectory.Location = new System.Drawing.Point(402, 6);
            this.buttonFirstDirectory.Name = "buttonFirstDirectory";
            this.buttonFirstDirectory.Size = new System.Drawing.Size(75, 20);
            this.buttonFirstDirectory.TabIndex = 3;
            this.buttonFirstDirectory.Text = "Обзор...";
            this.buttonFirstDirectory.UseVisualStyleBackColor = true;
            this.buttonFirstDirectory.Click += new System.EventHandler(this.buttonFirstDirectory_Click);
            // 
            // buttonSecondDirectory
            // 
            this.buttonSecondDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSecondDirectory.Location = new System.Drawing.Point(402, 32);
            this.buttonSecondDirectory.Name = "buttonSecondDirectory";
            this.buttonSecondDirectory.Size = new System.Drawing.Size(75, 20);
            this.buttonSecondDirectory.TabIndex = 3;
            this.buttonSecondDirectory.Text = "Обзор...";
            this.buttonSecondDirectory.UseVisualStyleBackColor = true;
            this.buttonSecondDirectory.Click += new System.EventHandler(this.buttonSecondDirectory_Click);
            // 
            // labelFirst
            // 
            this.labelFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFirst.AutoSize = true;
            this.labelFirst.Location = new System.Drawing.Point(229, 84);
            this.labelFirst.Name = "labelFirst";
            this.labelFirst.Size = new System.Drawing.Size(51, 13);
            this.labelFirst.TabIndex = 4;
            this.labelFirst.Text = "labelCnt1";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Скрытых файлов в первой директории:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Скрытых файлов во второй директории:";
            // 
            // labelSecond
            // 
            this.labelSecond.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSecond.AutoSize = true;
            this.labelSecond.Location = new System.Drawing.Point(229, 97);
            this.labelSecond.Name = "labelSecond";
            this.labelSecond.Size = new System.Drawing.Size(35, 13);
            this.labelSecond.TabIndex = 4;
            this.labelSecond.Text = "label3";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Скрытых файлов";
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(232, 58);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(75, 23);
            this.buttonCheck.TabIndex = 6;
            this.buttonCheck.Text = "Сравнить";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // labelResult
            // 
            this.labelResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(106, 110);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(16, 13);
            this.labelResult.TabIndex = 4;
            this.labelResult.Text = "...";
            this.labelResult.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 128);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.labelSecond);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelFirst);
            this.Controls.Add(this.buttonSecondDirectory);
            this.Controls.Add(this.buttonFirstDirectory);
            this.Controls.Add(this.textBoxPath2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPath1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonHelp);
            this.MinimumSize = new System.Drawing.Size(554, 167);
            this.Name = "Form1";
            this.Text = "Lab2N8";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPath1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPath2;
        private System.Windows.Forms.Button buttonFirstDirectory;
        private System.Windows.Forms.Button buttonSecondDirectory;
        private System.Windows.Forms.Label labelFirst;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelSecond;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

