namespace n3
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
            this.ProcessTB = new System.Windows.Forms.TextBox();
            this.ResultTB = new System.Windows.Forms.TextBox();
            this.ProcessLabel = new System.Windows.Forms.Label();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.ProcessNum = new System.Windows.Forms.NumericUpDown();
            this.ProcessNumLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.GetProcessButton = new System.Windows.Forms.Button();
            this.HelpButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessNum)).BeginInit();
            this.SuspendLayout();
            // 
            // ProcessTB
            // 
            this.ProcessTB.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ProcessTB.Location = new System.Drawing.Point(12, 23);
            this.ProcessTB.Multiline = true;
            this.ProcessTB.Name = "ProcessTB";
            this.ProcessTB.ReadOnly = true;
            this.ProcessTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProcessTB.Size = new System.Drawing.Size(207, 223);
            this.ProcessTB.TabIndex = 0;
            // 
            // ResultTB
            // 
            this.ResultTB.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ResultTB.Location = new System.Drawing.Point(225, 23);
            this.ResultTB.Multiline = true;
            this.ResultTB.Name = "ResultTB";
            this.ResultTB.ReadOnly = true;
            this.ResultTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResultTB.Size = new System.Drawing.Size(207, 223);
            this.ResultTB.TabIndex = 1;
            // 
            // ProcessLabel
            // 
            this.ProcessLabel.AutoSize = true;
            this.ProcessLabel.Location = new System.Drawing.Point(74, 7);
            this.ProcessLabel.Name = "ProcessLabel";
            this.ProcessLabel.Size = new System.Drawing.Size(79, 13);
            this.ProcessLabel.TabIndex = 2;
            this.ProcessLabel.Text = "Все процессы";
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(222, 7);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(213, 13);
            this.ResultLabel.TabIndex = 3;
            this.ResultLabel.Text = "Процессы с заданным кол-вом модулей";
            // 
            // ProcessNum
            // 
            this.ProcessNum.Location = new System.Drawing.Point(12, 271);
            this.ProcessNum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ProcessNum.Name = "ProcessNum";
            this.ProcessNum.Size = new System.Drawing.Size(109, 20);
            this.ProcessNum.TabIndex = 4;
            // 
            // ProcessNumLabel
            // 
            this.ProcessNumLabel.AutoSize = true;
            this.ProcessNumLabel.Location = new System.Drawing.Point(9, 255);
            this.ProcessNumLabel.Name = "ProcessNumLabel";
            this.ProcessNumLabel.Size = new System.Drawing.Size(115, 13);
            this.ProcessNumLabel.TabIndex = 5;
            this.ProcessNumLabel.Text = "Количество модулей:";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(127, 255);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(92, 40);
            this.StartButton.TabIndex = 6;
            this.StartButton.Text = "Выполнить";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // GetProcessButton
            // 
            this.GetProcessButton.Location = new System.Drawing.Point(225, 255);
            this.GetProcessButton.Name = "GetProcessButton";
            this.GetProcessButton.Size = new System.Drawing.Size(103, 40);
            this.GetProcessButton.TabIndex = 7;
            this.GetProcessButton.Text = "Получить процессы";
            this.GetProcessButton.UseVisualStyleBackColor = true;
            this.GetProcessButton.Click += new System.EventHandler(this.GetProcessButton_Click);
            // 
            // HelpButton
            // 
            this.HelpButton.Location = new System.Drawing.Point(334, 255);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(98, 40);
            this.HelpButton.TabIndex = 8;
            this.HelpButton.Text = "Условие";
            this.HelpButton.UseVisualStyleBackColor = true;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 303);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.GetProcessButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.ProcessNumLabel);
            this.Controls.Add(this.ProcessNum);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.ProcessLabel);
            this.Controls.Add(this.ResultTB);
            this.Controls.Add(this.ProcessTB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Task #3   18";
            ((System.ComponentModel.ISupportInitialize)(this.ProcessNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ProcessTB;
        private System.Windows.Forms.TextBox ResultTB;
        private System.Windows.Forms.Label ProcessLabel;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.NumericUpDown ProcessNum;
        private System.Windows.Forms.Label ProcessNumLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button GetProcessButton;
        private System.Windows.Forms.Button HelpButton;
    }
}

