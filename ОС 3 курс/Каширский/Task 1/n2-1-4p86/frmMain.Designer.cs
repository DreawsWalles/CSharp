namespace n2_1_4p86
{
    partial class frmMain
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
            this.lblMessages = new System.Windows.Forms.Label();
            this.txtbxMessages = new System.Windows.Forms.TextBox();
            this.txtbxReaders = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.txtbxWriters = new System.Windows.Forms.TextBox();
            this.lblReaders = new System.Windows.Forms.Label();
            this.lblWriters = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMessages
            // 
            this.lblMessages.AutoSize = true;
            this.lblMessages.Location = new System.Drawing.Point(12, 20);
            this.lblMessages.Name = "lblMessages";
            this.lblMessages.Size = new System.Drawing.Size(58, 13);
            this.lblMessages.TabIndex = 0;
            this.lblMessages.Text = "Messages:";
            // 
            // txtbxMessages
            // 
            this.txtbxMessages.Location = new System.Drawing.Point(12, 36);
            this.txtbxMessages.Multiline = true;
            this.txtbxMessages.Name = "txtbxMessages";
            this.txtbxMessages.ReadOnly = true;
            this.txtbxMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbxMessages.Size = new System.Drawing.Size(275, 275);
            this.txtbxMessages.TabIndex = 1;
            // 
            // txtbxReaders
            // 
            this.txtbxReaders.Location = new System.Drawing.Point(297, 36);
            this.txtbxReaders.Multiline = true;
            this.txtbxReaders.Name = "txtbxReaders";
            this.txtbxReaders.ReadOnly = true;
            this.txtbxReaders.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbxReaders.Size = new System.Drawing.Size(275, 122);
            this.txtbxReaders.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 326);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(167, 326);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(100, 23);
            this.btnPause.TabIndex = 5;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(315, 326);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 23);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(472, 326);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(100, 23);
            this.btnHelp.TabIndex = 7;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // txtbxWriters
            // 
            this.txtbxWriters.Location = new System.Drawing.Point(297, 189);
            this.txtbxWriters.Multiline = true;
            this.txtbxWriters.Name = "txtbxWriters";
            this.txtbxWriters.ReadOnly = true;
            this.txtbxWriters.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbxWriters.Size = new System.Drawing.Size(275, 122);
            this.txtbxWriters.TabIndex = 3;
            // 
            // lblReaders
            // 
            this.lblReaders.AutoSize = true;
            this.lblReaders.Location = new System.Drawing.Point(294, 20);
            this.lblReaders.Name = "lblReaders";
            this.lblReaders.Size = new System.Drawing.Size(50, 13);
            this.lblReaders.TabIndex = 8;
            this.lblReaders.Text = "Readers:";
            // 
            // lblWriters
            // 
            this.lblWriters.AutoSize = true;
            this.lblWriters.Location = new System.Drawing.Point(294, 173);
            this.lblWriters.Name = "lblWriters";
            this.lblWriters.Size = new System.Drawing.Size(43, 13);
            this.lblWriters.TabIndex = 9;
            this.lblWriters.Text = "Writers:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.lblWriters);
            this.Controls.Add(this.lblReaders);
            this.Controls.Add(this.txtbxWriters);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtbxReaders);
            this.Controls.Add(this.txtbxMessages);
            this.Controls.Add(this.lblMessages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task 1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessages;
        private System.Windows.Forms.TextBox txtbxReaders;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.TextBox txtbxWriters;
        private System.Windows.Forms.Label lblReaders;
        private System.Windows.Forms.Label lblWriters;
        private System.Windows.Forms.TextBox txtbxMessages;
    }
}

