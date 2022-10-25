namespace task2
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tbDir1 = new System.Windows.Forms.TextBox();
            this.tbDir2 = new System.Windows.Forms.TextBox();
            this.bBrowse1 = new System.Windows.Forms.Button();
            this.bBrowse2 = new System.Windows.Forms.Button();
            this.buttonGO = new System.Windows.Forms.Button();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // tbDir1
            // 
            this.tbDir1.Location = new System.Drawing.Point(12, 29);
            this.tbDir1.Multiline = true;
            this.tbDir1.Name = "tbDir1";
            this.tbDir1.Size = new System.Drawing.Size(320, 26);
            this.tbDir1.TabIndex = 0;
            // 
            // tbDir2
            // 
            this.tbDir2.Location = new System.Drawing.Point(12, 76);
            this.tbDir2.Multiline = true;
            this.tbDir2.Name = "tbDir2";
            this.tbDir2.Size = new System.Drawing.Size(320, 26);
            this.tbDir2.TabIndex = 1;
            // 
            // bBrowse1
            // 
            this.bBrowse1.Location = new System.Drawing.Point(347, 29);
            this.bBrowse1.Name = "bBrowse1";
            this.bBrowse1.Size = new System.Drawing.Size(27, 26);
            this.bBrowse1.TabIndex = 2;
            this.bBrowse1.Text = "...";
            this.bBrowse1.UseVisualStyleBackColor = true;
            this.bBrowse1.Click += new System.EventHandler(this.bBrowse1_Click);
            // 
            // bBrowse2
            // 
            this.bBrowse2.Location = new System.Drawing.Point(347, 76);
            this.bBrowse2.Name = "bBrowse2";
            this.bBrowse2.Size = new System.Drawing.Size(27, 26);
            this.bBrowse2.TabIndex = 3;
            this.bBrowse2.Text = "...";
            this.bBrowse2.UseVisualStyleBackColor = true;
            this.bBrowse2.Click += new System.EventHandler(this.bBrowse2_Click);
            // 
            // buttonGO
            // 
            this.buttonGO.Location = new System.Drawing.Point(148, 131);
            this.buttonGO.Name = "buttonGO";
            this.buttonGO.Size = new System.Drawing.Size(75, 23);
            this.buttonGO.TabIndex = 4;
            this.buttonGO.Text = "Search";
            this.buttonGO.UseVisualStyleBackColor = true;
            this.buttonGO.Click += new System.EventHandler(this.buttonGO_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 166);
            this.Controls.Add(this.buttonGO);
            this.Controls.Add(this.bBrowse2);
            this.Controls.Add(this.bBrowse1);
            this.Controls.Add(this.tbDir2);
            this.Controls.Add(this.tbDir1);
            this.Name = "Form1";
            this.Text = "Task2";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox tbDir1;
        private System.Windows.Forms.TextBox tbDir2;
        private System.Windows.Forms.Button bBrowse1;
        private System.Windows.Forms.Button bBrowse2;
        private System.Windows.Forms.Button buttonGO;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
    }
}

