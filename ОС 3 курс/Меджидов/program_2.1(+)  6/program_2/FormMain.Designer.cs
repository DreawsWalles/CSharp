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
            this.SuspendLayout();
            // 
            // LblDirectory1
            // 
            this.LblDirectory1.AutoSize = true;
            this.LblDirectory1.Location = new System.Drawing.Point(12, 23);
            this.LblDirectory1.Name = "LblDirectory1";
            this.LblDirectory1.Size = new System.Drawing.Size(60, 13);
            this.LblDirectory1.TabIndex = 0;
            this.LblDirectory1.Text = "Каталог 1:";
            // 
            // LblDirectory2
            // 
            this.LblDirectory2.AutoSize = true;
            this.LblDirectory2.Location = new System.Drawing.Point(12, 49);
            this.LblDirectory2.Name = "LblDirectory2";
            this.LblDirectory2.Size = new System.Drawing.Size(60, 13);
            this.LblDirectory2.TabIndex = 1;
            this.LblDirectory2.Text = "Каталог 2:";
            // 
            // TbDirectory1
            // 
            this.TbDirectory1.Location = new System.Drawing.Point(78, 20);
            this.TbDirectory1.Name = "TbDirectory1";
            this.TbDirectory1.Size = new System.Drawing.Size(463, 20);
            this.TbDirectory1.TabIndex = 2;
            this.TbDirectory1.Text = "..\\..\\..\\test1";
            // 
            // TbDirectory2
            // 
            this.TbDirectory2.Location = new System.Drawing.Point(78, 46);
            this.TbDirectory2.Name = "TbDirectory2";
            this.TbDirectory2.Size = new System.Drawing.Size(463, 20);
            this.TbDirectory2.TabIndex = 3;
            this.TbDirectory2.Text = "..\\..\\..\\test2";
            // 
            // BttDirectory1
            // 
            this.BttDirectory1.Location = new System.Drawing.Point(547, 18);
            this.BttDirectory1.Name = "BttDirectory1";
            this.BttDirectory1.Size = new System.Drawing.Size(75, 23);
            this.BttDirectory1.TabIndex = 4;
            this.BttDirectory1.Text = "Обзор";
            this.BttDirectory1.UseVisualStyleBackColor = true;
            this.BttDirectory1.Click += new System.EventHandler(this.BttDirectory1_Click);
            // 
            // BttDirectory2
            // 
            this.BttDirectory2.Location = new System.Drawing.Point(547, 44);
            this.BttDirectory2.Name = "BttDirectory2";
            this.BttDirectory2.Size = new System.Drawing.Size(75, 23);
            this.BttDirectory2.TabIndex = 5;
            this.BttDirectory2.Text = "Обзор";
            this.BttDirectory2.UseVisualStyleBackColor = true;
            this.BttDirectory2.Click += new System.EventHandler(this.BttDirectory2_Click);
            // 
            // BttStart
            // 
            this.BttStart.Location = new System.Drawing.Point(447, 80);
            this.BttStart.Name = "BttStart";
            this.BttStart.Size = new System.Drawing.Size(175, 23);
            this.BttStart.TabIndex = 6;
            this.BttStart.Text = "Проверить";
            this.BttStart.UseVisualStyleBackColor = true;
            this.BttStart.Click += new System.EventHandler(this.BttStart_Click);
            // 
            // FormMain
            // 
            this.AcceptButton = this.BttStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 111);
            this.Controls.Add(this.BttStart);
            this.Controls.Add(this.BttDirectory2);
            this.Controls.Add(this.BttDirectory1);
            this.Controls.Add(this.TbDirectory2);
            this.Controls.Add(this.TbDirectory1);
            this.Controls.Add(this.LblDirectory2);
            this.Controls.Add(this.LblDirectory1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Дата создания";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

