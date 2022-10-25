namespace Task234
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
            this.lblReaders = new System.Windows.Forms.Label();
            this.lblWriters = new System.Windows.Forms.Label();
            this.btnReadersStop = new System.Windows.Forms.Button();
            this.btnWritersStop = new System.Windows.Forms.Button();
            this.btnReadersStart = new System.Windows.Forms.Button();
            this.btnWritersStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbStack
            // 
            this.tbStack.BackColor = System.Drawing.Color.White;
            this.tbStack.Location = new System.Drawing.Point(24, 23);
            this.tbStack.Margin = new System.Windows.Forms.Padding(6);
            this.tbStack.Multiline = true;
            this.tbStack.Name = "tbStack";
            this.tbStack.ReadOnly = true;
            this.tbStack.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbStack.Size = new System.Drawing.Size(1020, 475);
            this.tbStack.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(24, 527);
            this.btnStart.Margin = new System.Windows.Forms.Padding(6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(524, 96);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Старт";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(24, 662);
            this.btnExit.Margin = new System.Windows.Forms.Padding(6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(524, 96);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Завершить";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblReaders
            // 
            this.lblReaders.AutoSize = true;
            this.lblReaders.Location = new System.Drawing.Point(650, 552);
            this.lblReaders.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblReaders.Name = "lblReaders";
            this.lblReaders.Size = new System.Drawing.Size(108, 26);
            this.lblReaders.TabIndex = 6;
            this.lblReaders.Text = "Читатели";
            // 
            // lblWriters
            // 
            this.lblWriters.AutoSize = true;
            this.lblWriters.Location = new System.Drawing.Point(871, 552);
            this.lblWriters.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblWriters.Name = "lblWriters";
            this.lblWriters.Size = new System.Drawing.Size(110, 26);
            this.lblWriters.TabIndex = 7;
            this.lblWriters.Text = "Писатели";
            // 
            // btnReadersStop
            // 
            this.btnReadersStop.Location = new System.Drawing.Point(616, 604);
            this.btnReadersStop.Margin = new System.Windows.Forms.Padding(6);
            this.btnReadersStop.Name = "btnReadersStop";
            this.btnReadersStop.Size = new System.Drawing.Size(198, 44);
            this.btnReadersStop.TabIndex = 8;
            this.btnReadersStop.Text = "Приостановить";
            this.btnReadersStop.UseVisualStyleBackColor = true;
            this.btnReadersStop.Click += new System.EventHandler(this.btnReaders_Click);
            // 
            // btnWritersStop
            // 
            this.btnWritersStop.Location = new System.Drawing.Point(840, 604);
            this.btnWritersStop.Margin = new System.Windows.Forms.Padding(6);
            this.btnWritersStop.Name = "btnWritersStop";
            this.btnWritersStop.Size = new System.Drawing.Size(204, 44);
            this.btnWritersStop.TabIndex = 9;
            this.btnWritersStop.Text = "Приостановить";
            this.btnWritersStop.UseVisualStyleBackColor = true;
            this.btnWritersStop.Click += new System.EventHandler(this.btnWritersStop_Click);
            // 
            // btnReadersStart
            // 
            this.btnReadersStart.Location = new System.Drawing.Point(616, 688);
            this.btnReadersStart.Margin = new System.Windows.Forms.Padding(6);
            this.btnReadersStart.Name = "btnReadersStart";
            this.btnReadersStart.Size = new System.Drawing.Size(198, 44);
            this.btnReadersStart.TabIndex = 10;
            this.btnReadersStart.Text = "Возобновить";
            this.btnReadersStart.UseVisualStyleBackColor = true;
            this.btnReadersStart.Click += new System.EventHandler(this.btnReadersStart_Click);
            // 
            // btnWritersStart
            // 
            this.btnWritersStart.Location = new System.Drawing.Point(840, 688);
            this.btnWritersStart.Margin = new System.Windows.Forms.Padding(6);
            this.btnWritersStart.Name = "btnWritersStart";
            this.btnWritersStart.Size = new System.Drawing.Size(204, 44);
            this.btnWritersStart.TabIndex = 11;
            this.btnWritersStart.Text = "Возобновить";
            this.btnWritersStart.UseVisualStyleBackColor = true;
            this.btnWritersStart.Click += new System.EventHandler(this.btnWritersStart_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1072, 1071);
            this.Controls.Add(this.btnWritersStart);
            this.Controls.Add(this.btnReadersStart);
            this.Controls.Add(this.btnWritersStop);
            this.Controls.Add(this.btnReadersStop);
            this.Controls.Add(this.lblWriters);
            this.Controls.Add(this.lblReaders);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tbStack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Читатели/писатели";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbStack;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblReaders;
        private System.Windows.Forms.Label lblWriters;
        private System.Windows.Forms.Button btnReadersStop;
        private System.Windows.Forms.Button btnWritersStop;
        private System.Windows.Forms.Button btnReadersStart;
        private System.Windows.Forms.Button btnWritersStart;
    }
}

