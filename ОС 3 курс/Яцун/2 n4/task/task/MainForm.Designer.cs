namespace task
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbPath1 = new System.Windows.Forms.TextBox();
            this.btnBrowserFolder1 = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbDirectories1 = new System.Windows.Forms.TextBox();
            this.tbDirectories2 = new System.Windows.Forms.TextBox();
            this.lblAllDirectories1 = new System.Windows.Forms.Label();
            this.lblAllDirectories2 = new System.Windows.Forms.Label();
            this.tbPath2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowserFolder2 = new System.Windows.Forms.Button();
            this.tbUnique = new System.Windows.Forms.TextBox();
            this.lblUnique = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Путь к директории 1:";
            // 
            // tbPath1
            // 
            this.tbPath1.Location = new System.Drawing.Point(12, 29);
            this.tbPath1.Multiline = true;
            this.tbPath1.Name = "tbPath1";
            this.tbPath1.ReadOnly = true;
            this.tbPath1.Size = new System.Drawing.Size(261, 21);
            this.tbPath1.TabIndex = 1;
            // 
            // btnBrowserFolder1
            // 
            this.btnBrowserFolder1.Location = new System.Drawing.Point(279, 27);
            this.btnBrowserFolder1.Name = "btnBrowserFolder1";
            this.btnBrowserFolder1.Size = new System.Drawing.Size(75, 23);
            this.btnBrowserFolder1.TabIndex = 2;
            this.btnBrowserFolder1.Text = "Обзор";
            this.btnBrowserFolder1.UseVisualStyleBackColor = true;
            this.btnBrowserFolder1.Click += new System.EventHandler(this.btnBrowserFolder_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 398);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Старт";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbDirectories1
            // 
            this.tbDirectories1.Location = new System.Drawing.Point(12, 88);
            this.tbDirectories1.Multiline = true;
            this.tbDirectories1.Name = "tbDirectories1";
            this.tbDirectories1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDirectories1.Size = new System.Drawing.Size(225, 304);
            this.tbDirectories1.TabIndex = 5;
            // 
            // tbDirectories2
            // 
            this.tbDirectories2.Location = new System.Drawing.Point(243, 88);
            this.tbDirectories2.Multiline = true;
            this.tbDirectories2.Name = "tbDirectories2";
            this.tbDirectories2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDirectories2.Size = new System.Drawing.Size(248, 304);
            this.tbDirectories2.TabIndex = 6;
            // 
            // lblAllDirectories1
            // 
            this.lblAllDirectories1.AutoSize = true;
            this.lblAllDirectories1.Location = new System.Drawing.Point(9, 67);
            this.lblAllDirectories1.Name = "lblAllDirectories1";
            this.lblAllDirectories1.Size = new System.Drawing.Size(114, 13);
            this.lblAllDirectories1.TabIndex = 8;
            this.lblAllDirectories1.Text = "Всего директорий 1: ";
            // 
            // lblAllDirectories2
            // 
            this.lblAllDirectories2.AutoSize = true;
            this.lblAllDirectories2.Location = new System.Drawing.Point(240, 67);
            this.lblAllDirectories2.Name = "lblAllDirectories2";
            this.lblAllDirectories2.Size = new System.Drawing.Size(114, 13);
            this.lblAllDirectories2.TabIndex = 9;
            this.lblAllDirectories2.Text = "Всего директорий 2: ";
            // 
            // tbPath2
            // 
            this.tbPath2.Location = new System.Drawing.Point(368, 29);
            this.tbPath2.Name = "tbPath2";
            this.tbPath2.ReadOnly = true;
            this.tbPath2.Size = new System.Drawing.Size(273, 20);
            this.tbPath2.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(365, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Путь к дректории 2:";
            // 
            // btnBrowserFolder2
            // 
            this.btnBrowserFolder2.Location = new System.Drawing.Point(647, 26);
            this.btnBrowserFolder2.Name = "btnBrowserFolder2";
            this.btnBrowserFolder2.Size = new System.Drawing.Size(75, 23);
            this.btnBrowserFolder2.TabIndex = 12;
            this.btnBrowserFolder2.Text = "Обзор";
            this.btnBrowserFolder2.UseVisualStyleBackColor = true;
            this.btnBrowserFolder2.Click += new System.EventHandler(this.btnBrowserFolder2_Click);
            // 
            // tbUnique
            // 
            this.tbUnique.Location = new System.Drawing.Point(497, 88);
            this.tbUnique.Multiline = true;
            this.tbUnique.Name = "tbUnique";
            this.tbUnique.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbUnique.Size = new System.Drawing.Size(225, 304);
            this.tbUnique.TabIndex = 13;
            // 
            // lblUnique
            // 
            this.lblUnique.AutoSize = true;
            this.lblUnique.Location = new System.Drawing.Point(494, 67);
            this.lblUnique.Name = "lblUnique";
            this.lblUnique.Size = new System.Drawing.Size(139, 13);
            this.lblUnique.TabIndex = 14;
            this.lblUnique.Text = "Уникальные директории: ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 435);
            this.Controls.Add(this.lblUnique);
            this.Controls.Add(this.tbUnique);
            this.Controls.Add(this.btnBrowserFolder2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPath2);
            this.Controls.Add(this.lblAllDirectories2);
            this.Controls.Add(this.lblAllDirectories1);
            this.Controls.Add(this.tbDirectories2);
            this.Controls.Add(this.tbDirectories1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnBrowserFolder1);
            this.Controls.Add(this.tbPath1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPath1;
        private System.Windows.Forms.Button btnBrowserFolder1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbDirectories1;
        private System.Windows.Forms.TextBox tbDirectories2;
        private System.Windows.Forms.Label lblAllDirectories1;
        private System.Windows.Forms.Label lblAllDirectories2;
        private System.Windows.Forms.TextBox tbPath2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowserFolder2;
        private System.Windows.Forms.TextBox tbUnique;
        private System.Windows.Forms.Label lblUnique;
    }
}

