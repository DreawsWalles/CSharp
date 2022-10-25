namespace os2
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
            this.buttonGo = new System.Windows.Forms.Button();
            this.tbDir1 = new System.Windows.Forms.TextBox();
            this.tbDir2 = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.bBrowse1 = new System.Windows.Forms.Button();
            this.bBrowse2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(141, 201);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 23);
            this.buttonGo.TabIndex = 1;
            this.buttonGo.Text = "ОК";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbDir1
            // 
            this.tbDir1.Location = new System.Drawing.Point(56, 53);
            this.tbDir1.Name = "tbDir1";
            this.tbDir1.Size = new System.Drawing.Size(160, 20);
            this.tbDir1.TabIndex = 2;
            // 
            // tbDir2
            // 
            this.tbDir2.Location = new System.Drawing.Point(56, 115);
            this.tbDir2.Name = "tbDir2";
            this.tbDir2.Size = new System.Drawing.Size(160, 20);
            this.tbDir2.TabIndex = 3;
            // 
            // folderBrowserDialog1
            // 
            //this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // bBrowse1
            // 
            this.bBrowse1.Location = new System.Drawing.Point(242, 53);
            this.bBrowse1.Name = "bBrowse1";
            this.bBrowse1.Size = new System.Drawing.Size(75, 23);
            this.bBrowse1.TabIndex = 4;
            this.bBrowse1.Text = "Обзор...";
            this.bBrowse1.UseVisualStyleBackColor = true;
            this.bBrowse1.Click += new System.EventHandler(this.bBrowse1_Click);
            // 
            // bBrowse2
            // 
            this.bBrowse2.Location = new System.Drawing.Point(242, 115);
            this.bBrowse2.Name = "bBrowse2";
            this.bBrowse2.Size = new System.Drawing.Size(75, 23);
            this.bBrowse2.TabIndex = 5;
            this.bBrowse2.Text = "Обзор...";
            this.bBrowse2.UseVisualStyleBackColor = true;
            this.bBrowse2.Click += new System.EventHandler(this.bBrowse2_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 267);
            this.Controls.Add(this.bBrowse2);
            this.Controls.Add(this.bBrowse1);
            this.Controls.Add(this.tbDir2);
            this.Controls.Add(this.tbDir1);
            this.Controls.Add(this.buttonGo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.Text = "Поиск readonly файлов";
            //this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.TextBox tbDir1;
        private System.Windows.Forms.TextBox tbDir2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.Button bBrowse1;
        private System.Windows.Forms.Button bBrowse2;
    }
}

