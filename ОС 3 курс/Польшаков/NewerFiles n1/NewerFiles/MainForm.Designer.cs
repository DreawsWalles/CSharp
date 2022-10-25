namespace NewerFiles
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
            this.textBoxResult1 = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonOpenDirectory1 = new System.Windows.Forms.Button();
            this.buttonOpenDirectory2 = new System.Windows.Forms.Button();
            this.labelDirectory1 = new System.Windows.Forms.Label();
            this.labelDirectory2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxResult1
            // 
            this.textBoxResult1.Location = new System.Drawing.Point(175, 12);
            this.textBoxResult1.Multiline = true;
            this.textBoxResult1.Name = "textBoxResult1";
            this.textBoxResult1.ReadOnly = true;
            this.textBoxResult1.Size = new System.Drawing.Size(245, 125);
            this.textBoxResult1.TabIndex = 0;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Enabled = false;
            this.buttonSearch.Location = new System.Drawing.Point(12, 12);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(143, 29);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "Get newer files";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonOpenDirectory1
            // 
            this.buttonOpenDirectory1.Location = new System.Drawing.Point(12, 63);
            this.buttonOpenDirectory1.Name = "buttonOpenDirectory1";
            this.buttonOpenDirectory1.Size = new System.Drawing.Size(143, 29);
            this.buttonOpenDirectory1.TabIndex = 3;
            this.buttonOpenDirectory1.Text = "Browse first directory";
            this.buttonOpenDirectory1.UseVisualStyleBackColor = true;
            this.buttonOpenDirectory1.Click += new System.EventHandler(this.buttonOpenDirectory1_Click);
            // 
            // buttonOpenDirectory2
            // 
            this.buttonOpenDirectory2.Location = new System.Drawing.Point(12, 108);
            this.buttonOpenDirectory2.Name = "buttonOpenDirectory2";
            this.buttonOpenDirectory2.Size = new System.Drawing.Size(143, 29);
            this.buttonOpenDirectory2.TabIndex = 4;
            this.buttonOpenDirectory2.Text = "Browse second directory";
            this.buttonOpenDirectory2.UseVisualStyleBackColor = true;
            this.buttonOpenDirectory2.Click += new System.EventHandler(this.buttonOpenDirectory2_Click);
            // 
            // labelDirectory1
            // 
            this.labelDirectory1.AutoSize = true;
            this.labelDirectory1.Location = new System.Drawing.Point(172, 159);
            this.labelDirectory1.Name = "labelDirectory1";
            this.labelDirectory1.Size = new System.Drawing.Size(0, 13);
            this.labelDirectory1.TabIndex = 7;
            // 
            // labelDirectory2
            // 
            this.labelDirectory2.AutoSize = true;
            this.labelDirectory2.Location = new System.Drawing.Point(172, 192);
            this.labelDirectory2.Name = "labelDirectory2";
            this.labelDirectory2.Size = new System.Drawing.Size(0, 13);
            this.labelDirectory2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "First directory:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Second directory:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 276);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelDirectory2);
            this.Controls.Add(this.labelDirectory1);
            this.Controls.Add(this.buttonOpenDirectory2);
            this.Controls.Add(this.buttonOpenDirectory1);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxResult1);
            this.Name = "MainForm";
            this.Text = "Find Directories";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxResult1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonOpenDirectory1;
        private System.Windows.Forms.Button buttonOpenDirectory2;
        private System.Windows.Forms.Label labelDirectory1;
        private System.Windows.Forms.Label labelDirectory2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

