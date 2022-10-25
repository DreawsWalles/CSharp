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
            this.tbDir1 = new System.Windows.Forms.TextBox();
            this.tbDir2 = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.bBrowse1 = new System.Windows.Forms.Button();
            this.bBrowse2 = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelRes1 = new System.Windows.Forms.Label();
            this.labelRes2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbDir1
            // 
            this.tbDir1.Location = new System.Drawing.Point(157, 51);
            this.tbDir1.Name = "tbDir1";
            this.tbDir1.ReadOnly = true;
            this.tbDir1.Size = new System.Drawing.Size(212, 20);
            this.tbDir1.TabIndex = 2;
            // 
            // tbDir2
            // 
            this.tbDir2.Location = new System.Drawing.Point(157, 115);
            this.tbDir2.Name = "tbDir2";
            this.tbDir2.ReadOnly = true;
            this.tbDir2.Size = new System.Drawing.Size(212, 20);
            this.tbDir2.TabIndex = 3;
            // 
            // bBrowse1
            // 
            this.bBrowse1.Location = new System.Drawing.Point(36, 48);
            this.bBrowse1.Name = "bBrowse1";
            this.bBrowse1.Size = new System.Drawing.Size(75, 23);
            this.bBrowse1.TabIndex = 4;
            this.bBrowse1.Text = "Обзор...";
            this.bBrowse1.UseVisualStyleBackColor = true;
            this.bBrowse1.Click += new System.EventHandler(this.bBrowse1_Click);
            // 
            // bBrowse2
            // 
            this.bBrowse2.Location = new System.Drawing.Point(36, 112);
            this.bBrowse2.Name = "bBrowse2";
            this.bBrowse2.Size = new System.Drawing.Size(75, 23);
            this.bBrowse2.TabIndex = 5;
            this.bBrowse2.Text = "Обзор...";
            this.bBrowse2.UseVisualStyleBackColor = true;
            this.bBrowse2.Click += new System.EventHandler(this.bBrowse2_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInfo.Location = new System.Drawing.Point(348, 19);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(251, 16);
            this.labelInfo.TabIndex = 6;
            this.labelInfo.Text = "Количество скрытых(только скрытых)";
            this.labelInfo.Visible = false;
            // 
            // labelRes1
            // 
            this.labelRes1.AutoSize = true;
            this.labelRes1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRes1.Location = new System.Drawing.Point(450, 51);
            this.labelRes1.Name = "labelRes1";
            this.labelRes1.Size = new System.Drawing.Size(0, 24);
            this.labelRes1.TabIndex = 7;
            // 
            // labelRes2
            // 
            this.labelRes2.AutoSize = true;
            this.labelRes2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRes2.Location = new System.Drawing.Point(450, 112);
            this.labelRes2.Name = "labelRes2";
            this.labelRes2.Size = new System.Drawing.Size(0, 24);
            this.labelRes2.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(400, 149);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Старт";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 184);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelRes2);
            this.Controls.Add(this.labelRes1);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.bBrowse2);
            this.Controls.Add(this.bBrowse1);
            this.Controls.Add(this.tbDir2);
            this.Controls.Add(this.tbDir1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.Text = "Сравнение скрытых и только скрытых файлов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDir1;
        private System.Windows.Forms.TextBox tbDir2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button bBrowse1;
        private System.Windows.Forms.Button bBrowse2;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelRes1;
        private System.Windows.Forms.Label labelRes2;
        private System.Windows.Forms.Button button2;
    }
}

