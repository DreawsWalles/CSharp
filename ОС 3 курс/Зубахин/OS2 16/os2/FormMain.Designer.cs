namespace Task2
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
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.buttonGo = new System.Windows.Forms.Button();
            this.tbDir1 = new System.Windows.Forms.TextBox();
            this.tbDir2 = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.bBrowse1 = new System.Windows.Forms.Button();
            this.bBrowse2 = new System.Windows.Forms.Button();
            this.labelPromt = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(85, 19);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(142, 20);
            this.dateTimePicker.TabIndex = 0;
            this.dateTimePicker.Value = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(51, 176);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 23);
            this.buttonGo.TabIndex = 1;
            this.buttonGo.Text = "ОК";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // tbDir1
            // 
            this.tbDir1.Location = new System.Drawing.Point(24, 79);
            this.tbDir1.Name = "tbDir1";
            this.tbDir1.Size = new System.Drawing.Size(160, 20);
            this.tbDir1.TabIndex = 2;
            // 
            // tbDir2
            // 
            this.tbDir2.Location = new System.Drawing.Point(24, 131);
            this.tbDir2.Name = "tbDir2";
            this.tbDir2.Size = new System.Drawing.Size(160, 20);
            this.tbDir2.TabIndex = 3;
            // 
            // bBrowse1
            // 
            this.bBrowse1.Location = new System.Drawing.Point(200, 78);
            this.bBrowse1.Name = "bBrowse1";
            this.bBrowse1.Size = new System.Drawing.Size(75, 23);
            this.bBrowse1.TabIndex = 4;
            this.bBrowse1.Text = "Browse...";
            this.bBrowse1.UseVisualStyleBackColor = true;
            this.bBrowse1.Click += new System.EventHandler(this.bBrowse1_Click);
            // 
            // bBrowse2
            // 
            this.bBrowse2.Location = new System.Drawing.Point(200, 130);
            this.bBrowse2.Name = "bBrowse2";
            this.bBrowse2.Size = new System.Drawing.Size(75, 23);
            this.bBrowse2.TabIndex = 5;
            this.bBrowse2.Text = "Browse...";
            this.bBrowse2.UseVisualStyleBackColor = true;
            this.bBrowse2.Click += new System.EventHandler(this.bBrowse2_Click);
            // 
            // labelPromt
            // 
            this.labelPromt.AutoSize = true;
            this.labelPromt.Location = new System.Drawing.Point(21, 23);
            this.labelPromt.Name = "labelPromt";
            this.labelPromt.Size = new System.Drawing.Size(33, 13);
            this.labelPromt.TabIndex = 7;
            this.labelPromt.Text = "Date:";
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(162, 176);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 8;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Directory 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Directory 2";
            // 
            // buttonTask
            // 
            this.buttonTask.Location = new System.Drawing.Point(266, -1);
            this.buttonTask.Name = "buttonTask";
            this.buttonTask.Size = new System.Drawing.Size(27, 23);
            this.buttonTask.TabIndex = 11;
            this.buttonTask.Text = "?";
            this.buttonTask.UseVisualStyleBackColor = true;
            this.buttonTask.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 211);
            this.Controls.Add(this.buttonTask);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelPromt);
            this.Controls.Add(this.bBrowse2);
            this.Controls.Add(this.bBrowse1);
            this.Controls.Add(this.tbDir2);
            this.Controls.Add(this.tbDir1);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.dateTimePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Task 2";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.TextBox tbDir1;
        private System.Windows.Forms.TextBox tbDir2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.Button bBrowse1;
        private System.Windows.Forms.Button bBrowse2;
        private System.Windows.Forms.Label labelPromt;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonTask;
    }
}

