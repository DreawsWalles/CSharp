namespace Task2_ex7
{
    partial class ResultOfTask
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
            this.tbMaxFirstDate = new System.Windows.Forms.TextBox();
            this.tbMaxSecondDate = new System.Windows.Forms.TextBox();
            this.tbGeneralInfo = new System.Windows.Forms.TextBox();
            this.lblFirstDir = new System.Windows.Forms.Label();
            this.lblSecondDir = new System.Windows.Forms.Label();
            this.lnlMaxDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbMaxFirstDate
            // 
            this.tbMaxFirstDate.Location = new System.Drawing.Point(120, 21);
            this.tbMaxFirstDate.Name = "tbMaxFirstDate";
            this.tbMaxFirstDate.ReadOnly = true;
            this.tbMaxFirstDate.Size = new System.Drawing.Size(121, 20);
            this.tbMaxFirstDate.TabIndex = 3;
            // 
            // tbMaxSecondDate
            // 
            this.tbMaxSecondDate.Location = new System.Drawing.Point(120, 47);
            this.tbMaxSecondDate.Name = "tbMaxSecondDate";
            this.tbMaxSecondDate.ReadOnly = true;
            this.tbMaxSecondDate.Size = new System.Drawing.Size(121, 20);
            this.tbMaxSecondDate.TabIndex = 6;
            // 
            // tbGeneralInfo
            // 
            this.tbGeneralInfo.Location = new System.Drawing.Point(10, 73);
            this.tbGeneralInfo.Name = "tbGeneralInfo";
            this.tbGeneralInfo.ReadOnly = true;
            this.tbGeneralInfo.Size = new System.Drawing.Size(231, 20);
            this.tbGeneralInfo.TabIndex = 7;
            // 
            // lblFirstDir
            // 
            this.lblFirstDir.AutoSize = true;
            this.lblFirstDir.Location = new System.Drawing.Point(7, 28);
            this.lblFirstDir.Name = "lblFirstDir";
            this.lblFirstDir.Size = new System.Drawing.Size(107, 13);
            this.lblFirstDir.TabIndex = 8;
            this.lblFirstDir.Text = "Первая директория";
            // 
            // lblSecondDir
            // 
            this.lblSecondDir.AutoSize = true;
            this.lblSecondDir.Location = new System.Drawing.Point(7, 54);
            this.lblSecondDir.Name = "lblSecondDir";
            this.lblSecondDir.Size = new System.Drawing.Size(105, 13);
            this.lblSecondDir.TabIndex = 9;
            this.lblSecondDir.Text = "Втория директория";
            // 
            // lnlMaxDate
            // 
            this.lnlMaxDate.AutoSize = true;
            this.lnlMaxDate.Location = new System.Drawing.Point(117, 5);
            this.lnlMaxDate.Name = "lnlMaxDate";
            this.lnlMaxDate.Size = new System.Drawing.Size(89, 13);
            this.lnlMaxDate.TabIndex = 12;
            this.lnlMaxDate.Text = "Последняя дата";
            // 
            // ResultOfTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 111);
            this.Controls.Add(this.lnlMaxDate);
            this.Controls.Add(this.lblSecondDir);
            this.Controls.Add(this.lblFirstDir);
            this.Controls.Add(this.tbGeneralInfo);
            this.Controls.Add(this.tbMaxSecondDate);
            this.Controls.Add(this.tbMaxFirstDate);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(270, 150);
            this.MinimumSize = new System.Drawing.Size(270, 150);
            this.Name = "ResultOfTask";
            this.Text = "ResultOfTask";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbMaxFirstDate;
        private System.Windows.Forms.TextBox tbMaxSecondDate;
        private System.Windows.Forms.TextBox tbGeneralInfo;
        private System.Windows.Forms.Label lblFirstDir;
        private System.Windows.Forms.Label lblSecondDir;
        private System.Windows.Forms.Label lnlMaxDate;
    }
}