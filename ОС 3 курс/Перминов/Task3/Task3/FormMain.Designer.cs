namespace Task3
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
            this.buttonRun = new System.Windows.Forms.Button();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.numericUpDownThreadsNumber = new System.Windows.Forms.NumericUpDown();
            this.labelThreadsNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreadsNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(12, 220);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(260, 23);
            this.buttonRun.TabIndex = 0;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(12, 12);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(260, 163);
            this.textBoxOutput.TabIndex = 1;
            // 
            // numericUpDownThreadsNumber
            // 
            this.numericUpDownThreadsNumber.Location = new System.Drawing.Point(12, 194);
            this.numericUpDownThreadsNumber.Name = "numericUpDownThreadsNumber";
            this.numericUpDownThreadsNumber.Size = new System.Drawing.Size(260, 20);
            this.numericUpDownThreadsNumber.TabIndex = 2;
            // 
            // labelThreadsNumber
            // 
            this.labelThreadsNumber.AutoSize = true;
            this.labelThreadsNumber.Location = new System.Drawing.Point(12, 178);
            this.labelThreadsNumber.Name = "labelThreadsNumber";
            this.labelThreadsNumber.Size = new System.Drawing.Size(87, 13);
            this.labelThreadsNumber.TabIndex = 3;
            this.labelThreadsNumber.Text = "Threads number:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.labelThreadsNumber);
            this.Controls.Add(this.numericUpDownThreadsNumber);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.buttonRun);
            this.Name = "FormMain";
            this.Text = "Task 3";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreadsNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.NumericUpDown numericUpDownThreadsNumber;
        private System.Windows.Forms.Label labelThreadsNumber;
    }
}

