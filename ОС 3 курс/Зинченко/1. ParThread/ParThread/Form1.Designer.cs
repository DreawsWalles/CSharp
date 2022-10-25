namespace ParThread
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
            this.tbWriters = new System.Windows.Forms.TextBox();
            this.tbReaders = new System.Windows.Forms.TextBox();
            this.tbMessages = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbWriters
            // 
            this.tbWriters.Location = new System.Drawing.Point(12, 32);
            this.tbWriters.Multiline = true;
            this.tbWriters.Name = "tbWriters";
            this.tbWriters.ReadOnly = true;
            this.tbWriters.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbWriters.Size = new System.Drawing.Size(331, 352);
            this.tbWriters.TabIndex = 0;
            // 
            // tbReaders
            // 
            this.tbReaders.Location = new System.Drawing.Point(393, 32);
            this.tbReaders.Multiline = true;
            this.tbReaders.Name = "tbReaders";
            this.tbReaders.ReadOnly = true;
            this.tbReaders.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbReaders.Size = new System.Drawing.Size(331, 352);
            this.tbReaders.TabIndex = 1;
            // 
            // tbMessages
            // 
            this.tbMessages.Location = new System.Drawing.Point(12, 416);
            this.tbMessages.Multiline = true;
            this.tbMessages.Name = "tbMessages";
            this.tbMessages.ReadOnly = true;
            this.tbMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMessages.Size = new System.Drawing.Size(331, 174);
            this.tbMessages.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(393, 524);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(88, 34);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Старт";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(496, 524);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(120, 34);
            this.btnPause.TabIndex = 4;
            this.btnPause.Text = "Пауза";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(636, 524);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(88, 34);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Стоп";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 602);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tbMessages);
            this.Controls.Add(this.tbReaders);
            this.Controls.Add(this.tbWriters);
            this.Name = "MainForm";
            this.Text = "Монитор";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbWriters;
        private System.Windows.Forms.TextBox tbReaders;
        private System.Windows.Forms.TextBox tbMessages;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
    }
}

