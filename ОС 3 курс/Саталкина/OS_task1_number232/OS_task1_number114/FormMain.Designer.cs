namespace OS_task1_number232
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbStack = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.gbWriters = new System.Windows.Forms.GroupBox();
            this.rbResumeWriters = new System.Windows.Forms.RadioButton();
            this.rbPauseWriters = new System.Windows.Forms.RadioButton();
            this.gbReaders = new System.Windows.Forms.GroupBox();
            this.rbResumeReaders = new System.Windows.Forms.RadioButton();
            this.rbPauseReaders = new System.Windows.Forms.RadioButton();
            this.gbWriters.SuspendLayout();
            this.gbReaders.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbStack
            // 
            this.tbStack.BackColor = System.Drawing.Color.White;
            this.tbStack.Location = new System.Drawing.Point(12, 12);
            this.tbStack.Multiline = true;
            this.tbStack.Name = "tbStack";
            this.tbStack.ReadOnly = true;
            this.tbStack.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbStack.Size = new System.Drawing.Size(284, 424);
            this.tbStack.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 442);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(133, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Запуск";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(152, 442);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(144, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Завершить";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // gbWriters
            // 
            this.gbWriters.Controls.Add(this.rbResumeWriters);
            this.gbWriters.Controls.Add(this.rbPauseWriters);
            this.gbWriters.Enabled = false;
            this.gbWriters.Location = new System.Drawing.Point(12, 482);
            this.gbWriters.Name = "gbWriters";
            this.gbWriters.Size = new System.Drawing.Size(134, 59);
            this.gbWriters.TabIndex = 4;
            this.gbWriters.TabStop = false;
            this.gbWriters.Text = "Писатели";
            // 
            // rbResumeWriters
            // 
            this.rbResumeWriters.AutoSize = true;
            this.rbResumeWriters.Checked = true;
            this.rbResumeWriters.Location = new System.Drawing.Point(3, 36);
            this.rbResumeWriters.Name = "rbResumeWriters";
            this.rbResumeWriters.Size = new System.Drawing.Size(91, 17);
            this.rbResumeWriters.TabIndex = 1;
            this.rbResumeWriters.TabStop = true;
            this.rbResumeWriters.Text = "Возобновить";
            this.rbResumeWriters.UseVisualStyleBackColor = true;
            this.rbResumeWriters.CheckedChanged += new System.EventHandler(this.rbPauseWriters_CheckedChanged);
            // 
            // rbPauseWriters
            // 
            this.rbPauseWriters.AutoSize = true;
            this.rbPauseWriters.Location = new System.Drawing.Point(3, 16);
            this.rbPauseWriters.Name = "rbPauseWriters";
            this.rbPauseWriters.Size = new System.Drawing.Size(103, 17);
            this.rbPauseWriters.TabIndex = 0;
            this.rbPauseWriters.Text = "Приостановить";
            this.rbPauseWriters.UseVisualStyleBackColor = true;
            this.rbPauseWriters.CheckedChanged += new System.EventHandler(this.rbPauseWriters_CheckedChanged);
            // 
            // gbReaders
            // 
            this.gbReaders.Controls.Add(this.rbResumeReaders);
            this.gbReaders.Controls.Add(this.rbPauseReaders);
            this.gbReaders.Enabled = false;
            this.gbReaders.Location = new System.Drawing.Point(154, 482);
            this.gbReaders.Name = "gbReaders";
            this.gbReaders.Size = new System.Drawing.Size(142, 59);
            this.gbReaders.TabIndex = 5;
            this.gbReaders.TabStop = false;
            this.gbReaders.Text = "Читатель";
            // 
            // rbResumeReaders
            // 
            this.rbResumeReaders.AutoSize = true;
            this.rbResumeReaders.Checked = true;
            this.rbResumeReaders.Location = new System.Drawing.Point(6, 36);
            this.rbResumeReaders.Name = "rbResumeReaders";
            this.rbResumeReaders.Size = new System.Drawing.Size(91, 17);
            this.rbResumeReaders.TabIndex = 2;
            this.rbResumeReaders.TabStop = true;
            this.rbResumeReaders.Text = "Возобновить";
            this.rbResumeReaders.UseVisualStyleBackColor = true;
            this.rbResumeReaders.CheckedChanged += new System.EventHandler(this.rbPauseReaders_CheckedChanged);
            // 
            // rbPauseReaders
            // 
            this.rbPauseReaders.AutoSize = true;
            this.rbPauseReaders.Location = new System.Drawing.Point(6, 16);
            this.rbPauseReaders.Name = "rbPauseReaders";
            this.rbPauseReaders.Size = new System.Drawing.Size(103, 17);
            this.rbPauseReaders.TabIndex = 1;
            this.rbPauseReaders.Text = "Приостановить";
            this.rbPauseReaders.UseVisualStyleBackColor = true;
            this.rbPauseReaders.CheckedChanged += new System.EventHandler(this.rbPauseReaders_CheckedChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 553);
            this.Controls.Add(this.gbReaders);
            this.Controls.Add(this.gbWriters);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tbStack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Читатель-писатели";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.gbWriters.ResumeLayout(false);
            this.gbWriters.PerformLayout();
            this.gbReaders.ResumeLayout(false);
            this.gbReaders.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbStack;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.GroupBox gbWriters;
        public System.Windows.Forms.GroupBox gbReaders;
        private System.Windows.Forms.RadioButton rbResumeWriters;
        private System.Windows.Forms.RadioButton rbPauseWriters;
        private System.Windows.Forms.RadioButton rbResumeReaders;
        private System.Windows.Forms.RadioButton rbPauseReaders;
    }
}

