namespace program_2
{
    partial class FormMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.Fbd1 = new System.Windows.Forms.FolderBrowserDialog();
            this.LblDirectory1 = new System.Windows.Forms.Label();
            this.LblDirectory2 = new System.Windows.Forms.Label();
            this.TbDirectory1 = new System.Windows.Forms.TextBox();
            this.TbDirectory2 = new System.Windows.Forms.TextBox();
            this.BttDirectory1 = new System.Windows.Forms.Button();
            this.BttDirectory2 = new System.Windows.Forms.Button();
            this.BttStart = new System.Windows.Forms.Button();
            this.Fbd2 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.res1 = new System.Windows.Forms.TextBox();
            this.res2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblDirectory1
            // 
            this.LblDirectory1.AutoSize = true;
            this.LblDirectory1.Location = new System.Drawing.Point(18, 23);
            this.LblDirectory1.Name = "LblDirectory1";
            this.LblDirectory1.Size = new System.Drawing.Size(60, 13);
            this.LblDirectory1.TabIndex = 0;
            this.LblDirectory1.Text = "Каталог 1:";
            // 
            // LblDirectory2
            // 
            this.LblDirectory2.AutoSize = true;
            this.LblDirectory2.Location = new System.Drawing.Point(18, 57);
            this.LblDirectory2.Name = "LblDirectory2";
            this.LblDirectory2.Size = new System.Drawing.Size(60, 13);
            this.LblDirectory2.TabIndex = 1;
            this.LblDirectory2.Text = "Каталог 2:";
            // 
            // TbDirectory1
            // 
            this.TbDirectory1.Location = new System.Drawing.Point(83, 23);
            this.TbDirectory1.Name = "TbDirectory1";
            this.TbDirectory1.Size = new System.Drawing.Size(280, 20);
            this.TbDirectory1.TabIndex = 2;
            this.TbDirectory1.Text = "..\\..\\..\\test1";
            // 
            // TbDirectory2
            // 
            this.TbDirectory2.Location = new System.Drawing.Point(83, 54);
            this.TbDirectory2.Name = "TbDirectory2";
            this.TbDirectory2.Size = new System.Drawing.Size(280, 20);
            this.TbDirectory2.TabIndex = 3;
            this.TbDirectory2.Text = "..\\..\\..\\test2";
            // 
            // BttDirectory1
            // 
            this.BttDirectory1.Location = new System.Drawing.Point(369, 21);
            this.BttDirectory1.Name = "BttDirectory1";
            this.BttDirectory1.Size = new System.Drawing.Size(75, 23);
            this.BttDirectory1.TabIndex = 4;
            this.BttDirectory1.Text = "Обзор";
            this.BttDirectory1.UseVisualStyleBackColor = true;
            this.BttDirectory1.Click += new System.EventHandler(this.BttDirectory1_Click);
            // 
            // BttDirectory2
            // 
            this.BttDirectory2.Location = new System.Drawing.Point(369, 51);
            this.BttDirectory2.Name = "BttDirectory2";
            this.BttDirectory2.Size = new System.Drawing.Size(75, 23);
            this.BttDirectory2.TabIndex = 5;
            this.BttDirectory2.Text = "Обзор";
            this.BttDirectory2.UseVisualStyleBackColor = true;
            this.BttDirectory2.Click += new System.EventHandler(this.BttDirectory2_Click);
            // 
            // BttStart
            // 
            this.BttStart.Location = new System.Drawing.Point(186, 80);
            this.BttStart.Name = "BttStart";
            this.BttStart.Size = new System.Drawing.Size(75, 23);
            this.BttStart.TabIndex = 6;
            this.BttStart.Text = "Сравнить";
            this.BttStart.UseVisualStyleBackColor = true;
            this.BttStart.Click += new System.EventHandler(this.BttStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Количество RеadOnly файлов в 1 каталоге:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Количество RеadOnly файлов во 2 каталоге:";
            // 
            // res1
            // 
            this.res1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.res1.Location = new System.Drawing.Point(262, 25);
            this.res1.Name = "res1";
            this.res1.ReadOnly = true;
            this.res1.Size = new System.Drawing.Size(101, 20);
            this.res1.TabIndex = 9;
            this.res1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // res2
            // 
            this.res2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.res2.Location = new System.Drawing.Point(262, 57);
            this.res2.Name = "res2";
            this.res2.ReadOnly = true;
            this.res2.Size = new System.Drawing.Size(101, 20);
            this.res2.TabIndex = 10;
            this.res2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BttDirectory1);
            this.groupBox1.Controls.Add(this.BttDirectory2);
            this.groupBox1.Controls.Add(this.BttStart);
            this.groupBox1.Controls.Add(this.LblDirectory1);
            this.groupBox1.Controls.Add(this.LblDirectory2);
            this.groupBox1.Controls.Add(this.TbDirectory2);
            this.groupBox1.Controls.Add(this.TbDirectory1);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 109);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Исходные данные:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.res1);
            this.groupBox2.Controls.Add(this.res2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(451, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Результат:";
            // 
            // FormMain
            // 
            this.AcceptButton = this.BttStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 232);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Количество ReadOnly";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog Fbd1;
        private System.Windows.Forms.Label LblDirectory1;
        private System.Windows.Forms.Label LblDirectory2;
        private System.Windows.Forms.TextBox TbDirectory1;
        private System.Windows.Forms.TextBox TbDirectory2;
        private System.Windows.Forms.Button BttDirectory1;
        private System.Windows.Forms.Button BttDirectory2;
        private System.Windows.Forms.Button BttStart;
        private System.Windows.Forms.FolderBrowserDialog Fbd2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox res1;
        private System.Windows.Forms.TextBox res2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

