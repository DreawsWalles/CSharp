namespace program_3
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
            this.LblMin = new System.Windows.Forms.Label();
            this.TbMin = new System.Windows.Forms.TextBox();
            this.LblMax = new System.Windows.Forms.Label();
            this.TbMax = new System.Windows.Forms.TextBox();
            this.TbOutput = new System.Windows.Forms.TextBox();
            this.BttStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblMin
            // 
            this.LblMin.AutoSize = true;
            this.LblMin.Location = new System.Drawing.Point(12, 23);
            this.LblMin.Name = "LblMin";
            this.LblMin.Size = new System.Drawing.Size(151, 13);
            this.LblMin.TabIndex = 0;
            this.LblMin.Text = "Нижняя граница диапазона:";
            // 
            // TbMin
            // 
            this.TbMin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbMin.Location = new System.Drawing.Point(166, 20);
            this.TbMin.Name = "TbMin";
            this.TbMin.Size = new System.Drawing.Size(106, 20);
            this.TbMin.TabIndex = 1;
            this.TbMin.Text = "10000000";
            // 
            // LblMax
            // 
            this.LblMax.AutoSize = true;
            this.LblMax.Location = new System.Drawing.Point(12, 49);
            this.LblMax.Name = "LblMax";
            this.LblMax.Size = new System.Drawing.Size(153, 13);
            this.LblMax.TabIndex = 2;
            this.LblMax.Text = "Верхняя граница диапазона:";
            // 
            // TbMax
            // 
            this.TbMax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbMax.Location = new System.Drawing.Point(166, 46);
            this.TbMax.Name = "TbMax";
            this.TbMax.Size = new System.Drawing.Size(106, 20);
            this.TbMax.TabIndex = 3;
            this.TbMax.Text = "90000000";
            // 
            // TbOutput
            // 
            this.TbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbOutput.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TbOutput.Location = new System.Drawing.Point(12, 72);
            this.TbOutput.Multiline = true;
            this.TbOutput.Name = "TbOutput";
            this.TbOutput.ReadOnly = true;
            this.TbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbOutput.Size = new System.Drawing.Size(260, 153);
            this.TbOutput.TabIndex = 4;
            // 
            // BttStart
            // 
            this.BttStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BttStart.Location = new System.Drawing.Point(139, 231);
            this.BttStart.Name = "BttStart";
            this.BttStart.Size = new System.Drawing.Size(133, 23);
            this.BttStart.TabIndex = 5;
            this.BttStart.Text = "Вывести информацию";
            this.BttStart.UseVisualStyleBackColor = true;
            this.BttStart.Click += new System.EventHandler(this.BttStart_Click);
            // 
            // FormMain
            // 
            this.AcceptButton = this.BttStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.BttStart);
            this.Controls.Add(this.TbOutput);
            this.Controls.Add(this.TbMax);
            this.Controls.Add(this.LblMax);
            this.Controls.Add(this.TbMin);
            this.Controls.Add(this.LblMin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Владельцы блоков";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblMin;
        private System.Windows.Forms.TextBox TbMin;
        private System.Windows.Forms.Label LblMax;
        private System.Windows.Forms.TextBox TbMax;
        private System.Windows.Forms.TextBox TbOutput;
        private System.Windows.Forms.Button BttStart;
    }
}

