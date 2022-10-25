namespace ThreadManager
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.nudThreadTime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tbQueue = new System.Windows.Forms.TextBox();
            this.tbBlock = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreadTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 13);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Запустить";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(13, 43);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "Пауза";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(13, 95);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(488, 338);
            this.tbLog.TabIndex = 2;
            // 
            // nudThreadTime
            // 
            this.nudThreadTime.Location = new System.Drawing.Point(419, 12);
            this.nudThreadTime.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudThreadTime.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudThreadTime.Name = "nudThreadTime";
            this.nudThreadTime.Size = new System.Drawing.Size(82, 20);
            this.nudThreadTime.TabIndex = 4;
            this.nudThreadTime.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Выделяемый потоку квант времени:";
            // 
            // tbQueue
            // 
            this.tbQueue.Location = new System.Drawing.Point(127, 45);
            this.tbQueue.Name = "tbQueue";
            this.tbQueue.Size = new System.Drawing.Size(373, 20);
            this.tbQueue.TabIndex = 7;
            // 
            // tbBlock
            // 
            this.tbBlock.Location = new System.Drawing.Point(127, 72);
            this.tbBlock.Name = "tbBlock";
            this.tbBlock.Size = new System.Drawing.Size(372, 20);
            this.tbBlock.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 445);
            this.Controls.Add(this.tbBlock);
            this.Controls.Add(this.tbQueue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudThreadTime);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "Thread Manager";
            ((System.ComponentModel.ISupportInitialize)(this.nudThreadTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.NumericUpDown nudThreadTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbQueue;
        private System.Windows.Forms.TextBox tbBlock;
    }
}

