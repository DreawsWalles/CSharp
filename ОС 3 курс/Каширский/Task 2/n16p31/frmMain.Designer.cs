namespace n16p31
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
            this.txt1stDirectory = new System.Windows.Forms.TextBox();
            this.txt2ndDirectory = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.lbl1stDirectory = new System.Windows.Forms.Label();
            this.lbl2ndDirectory = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.btn1stDirectory = new System.Windows.Forms.Button();
            this.btn2ndDirectory = new System.Windows.Forms.Button();
            this.fldDlg1stdir = new System.Windows.Forms.FolderBrowserDialog();
            this.fldDlg2nddir = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // txt1stDirectory
            // 
            this.txt1stDirectory.Enabled = false;
            this.txt1stDirectory.Location = new System.Drawing.Point(125, 47);
            this.txt1stDirectory.Name = "txt1stDirectory";
            this.txt1stDirectory.Size = new System.Drawing.Size(200, 20);
            this.txt1stDirectory.TabIndex = 0;
            // 
            // txt2ndDirectory
            // 
            this.txt2ndDirectory.Enabled = false;
            this.txt2ndDirectory.Location = new System.Drawing.Point(125, 97);
            this.txt2ndDirectory.Name = "txt2ndDirectory";
            this.txt2ndDirectory.Size = new System.Drawing.Size(200, 20);
            this.txt2ndDirectory.TabIndex = 2;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(125, 144);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 4;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(50, 200);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(100, 23);
            this.btnRun.TabIndex = 5;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(342, 200);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(100, 23);
            this.btnHelp.TabIndex = 6;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // lbl1stDirectory
            // 
            this.lbl1stDirectory.AutoSize = true;
            this.lbl1stDirectory.Location = new System.Drawing.Point(50, 50);
            this.lbl1stDirectory.Name = "lbl1stDirectory";
            this.lbl1stDirectory.Size = new System.Drawing.Size(67, 13);
            this.lbl1stDirectory.TabIndex = 5;
            this.lbl1stDirectory.Text = "1st directory:";
            // 
            // lbl2ndDirectory
            // 
            this.lbl2ndDirectory.AutoSize = true;
            this.lbl2ndDirectory.Location = new System.Drawing.Point(50, 100);
            this.lbl2ndDirectory.Name = "lbl2ndDirectory";
            this.lbl2ndDirectory.Size = new System.Drawing.Size(71, 13);
            this.lbl2ndDirectory.TabIndex = 6;
            this.lbl2ndDirectory.Text = "2nd directory:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(50, 150);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 7;
            this.lblDate.Text = "Date:";
            // 
            // btn1stDirectory
            // 
            this.btn1stDirectory.Location = new System.Drawing.Point(342, 45);
            this.btn1stDirectory.Name = "btn1stDirectory";
            this.btn1stDirectory.Size = new System.Drawing.Size(100, 23);
            this.btn1stDirectory.TabIndex = 1;
            this.btn1stDirectory.Text = "Browse...";
            this.btn1stDirectory.UseVisualStyleBackColor = true;
            this.btn1stDirectory.Click += new System.EventHandler(this.btn1stDirectory_Click);
            // 
            // btn2ndDirectory
            // 
            this.btn2ndDirectory.Location = new System.Drawing.Point(342, 95);
            this.btn2ndDirectory.Name = "btn2ndDirectory";
            this.btn2ndDirectory.Size = new System.Drawing.Size(100, 23);
            this.btn2ndDirectory.TabIndex = 3;
            this.btn2ndDirectory.Text = "Browse...";
            this.btn2ndDirectory.UseVisualStyleBackColor = true;
            this.btn2ndDirectory.Click += new System.EventHandler(this.btn2ndDirectory_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.btn2ndDirectory);
            this.Controls.Add(this.btn1stDirectory);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lbl2ndDirectory);
            this.Controls.Add(this.lbl1stDirectory);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txt2ndDirectory);
            this.Controls.Add(this.txt1stDirectory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt1stDirectory;
        private System.Windows.Forms.TextBox txt2ndDirectory;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label lbl1stDirectory;
        private System.Windows.Forms.Label lbl2ndDirectory;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btn1stDirectory;
        private System.Windows.Forms.Button btn2ndDirectory;
        private System.Windows.Forms.FolderBrowserDialog fldDlg1stdir;
        private System.Windows.Forms.FolderBrowserDialog fldDlg2nddir;
    }
}

