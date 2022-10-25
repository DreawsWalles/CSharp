namespace ThreadPriority
{
    partial class mainForm
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
            this.tbAll = new System.Windows.Forms.TextBox();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.NumPrior = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NumPrior)).BeginInit();
            this.SuspendLayout();
            // 
            // tbAll
            // 
            this.tbAll.Location = new System.Drawing.Point(12, 106);
            this.tbAll.Multiline = true;
            this.tbAll.Name = "tbAll";
            this.tbAll.ReadOnly = true;
            this.tbAll.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbAll.Size = new System.Drawing.Size(359, 388);
            this.tbAll.TabIndex = 2;
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(391, 106);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.ReadOnly = true;
            this.tbResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbResult.Size = new System.Drawing.Size(359, 388);
            this.tbResult.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(537, 26);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(130, 53);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "СТАРТ";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl.Location = new System.Drawing.Point(79, 41);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(256, 29);
            this.lbl.TabIndex = 4;
            this.lbl.Text = "Искомый приоритет:";
            // 
            // NumPrior
            // 
            this.NumPrior.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumPrior.Location = new System.Drawing.Point(366, 40);
            this.NumPrior.Name = "NumPrior";
            this.NumPrior.Size = new System.Drawing.Size(120, 30);
            this.NumPrior.TabIndex = 0;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 506);
            this.Controls.Add(this.NumPrior);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.tbAll);
            this.Name = "mainForm";
            this.Text = "Task3";
            ((System.ComponentModel.ISupportInitialize)(this.NumPrior)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAll;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.NumericUpDown NumPrior;
    }
}

