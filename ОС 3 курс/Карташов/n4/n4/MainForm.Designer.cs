namespace n4
{
    partial class MainForm
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
            this.ThreadsNum = new System.Windows.Forms.NumericUpDown();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.ResultTB = new System.Windows.Forms.TextBox();
            this.TimeNum = new System.Windows.Forms.NumericUpDown();
            this.ThLbl = new System.Windows.Forms.Label();
            this.TimeLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ThreadsNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeNum)).BeginInit();
            this.SuspendLayout();
            // 
            // ThreadsNum
            // 
            this.ThreadsNum.Location = new System.Drawing.Point(408, 167);
            this.ThreadsNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ThreadsNum.Name = "ThreadsNum";
            this.ThreadsNum.Size = new System.Drawing.Size(75, 20);
            this.ThreadsNum.TabIndex = 0;
            this.ThreadsNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(12, 164);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(193, 23);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(12, 193);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(193, 23);
            this.StopButton.TabIndex = 2;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // ResultTB
            // 
            this.ResultTB.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ResultTB.Location = new System.Drawing.Point(12, 12);
            this.ResultTB.Multiline = true;
            this.ResultTB.Name = "ResultTB";
            this.ResultTB.ReadOnly = true;
            this.ResultTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResultTB.Size = new System.Drawing.Size(471, 146);
            this.ResultTB.TabIndex = 3;
            // 
            // TimeNum
            // 
            this.TimeNum.Location = new System.Drawing.Point(408, 197);
            this.TimeNum.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.TimeNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TimeNum.Name = "TimeNum";
            this.TimeNum.Size = new System.Drawing.Size(75, 20);
            this.TimeNum.TabIndex = 5;
            this.TimeNum.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // ThLbl
            // 
            this.ThLbl.AutoSize = true;
            this.ThLbl.Location = new System.Drawing.Point(223, 169);
            this.ThLbl.Name = "ThLbl";
            this.ThLbl.Size = new System.Drawing.Size(113, 13);
            this.ThLbl.TabIndex = 6;
            this.ThLbl.Text = "Количество потоков:";
            // 
            // TimeLbl
            // 
            this.TimeLbl.AutoSize = true;
            this.TimeLbl.Location = new System.Drawing.Point(223, 199);
            this.TimeLbl.Name = "TimeLbl";
            this.TimeLbl.Size = new System.Drawing.Size(179, 13);
            this.TimeLbl.TabIndex = 7;
            this.TimeLbl.Text = "Время, выделяемое потокам, мс:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 225);
            this.Controls.Add(this.TimeLbl);
            this.Controls.Add(this.ThLbl);
            this.Controls.Add(this.TimeNum);
            this.Controls.Add(this.ResultTB);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.ThreadsNum);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Task #4 Guaranteed Planner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ThreadsNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown ThreadsNum;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.TextBox ResultTB;
        private System.Windows.Forms.NumericUpDown TimeNum;
        private System.Windows.Forms.Label ThLbl;
        private System.Windows.Forms.Label TimeLbl;
    }
}

