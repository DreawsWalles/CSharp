namespace OS1
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
            this.components = new System.ComponentModel.Container();
            this.timerWorkerGenerator = new System.Windows.Forms.Timer(this.components);
            this.textBoxQueue = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBoxWritersLog = new System.Windows.Forms.TextBox();
            this.textBoxReadersLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // timerWorkerGenerator
            // 
            this.timerWorkerGenerator.Interval = 1000;
            this.timerWorkerGenerator.Tick += new System.EventHandler(this.timerWorkerGenerator_Tick);
            // 
            // textBoxQueue
            // 
            this.textBoxQueue.Location = new System.Drawing.Point(311, 12);
            this.textBoxQueue.Multiline = true;
            this.textBoxQueue.Name = "textBoxQueue";
            this.textBoxQueue.ReadOnly = true;
            this.textBoxQueue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxQueue.Size = new System.Drawing.Size(300, 400);
            this.textBoxQueue.TabIndex = 0;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(402, 443);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(129, 34);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBoxWritersLog
            // 
            this.textBoxWritersLog.Location = new System.Drawing.Point(12, 12);
            this.textBoxWritersLog.Multiline = true;
            this.textBoxWritersLog.Name = "textBoxWritersLog";
            this.textBoxWritersLog.ReadOnly = true;
            this.textBoxWritersLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxWritersLog.Size = new System.Drawing.Size(300, 400);
            this.textBoxWritersLog.TabIndex = 2;
            // 
            // textBoxReadersLog
            // 
            this.textBoxReadersLog.Location = new System.Drawing.Point(617, 12);
            this.textBoxReadersLog.Multiline = true;
            this.textBoxReadersLog.Name = "textBoxReadersLog";
            this.textBoxReadersLog.ReadOnly = true;
            this.textBoxReadersLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxReadersLog.Size = new System.Drawing.Size(300, 400);
            this.textBoxReadersLog.TabIndex = 3;
            // 
            // FormMain
            // 
            this.AcceptButton = this.buttonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 489);
            this.Controls.Add(this.textBoxReadersLog);
            this.Controls.Add(this.textBoxWritersLog);
            this.Controls.Add(this.textBoxQueue);
            this.Controls.Add(this.buttonStart);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerWorkerGenerator;
        private System.Windows.Forms.TextBox textBoxQueue;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBoxWritersLog;
        private System.Windows.Forms.TextBox textBoxReadersLog;
    }
}

