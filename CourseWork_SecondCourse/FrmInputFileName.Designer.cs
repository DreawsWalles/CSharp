namespace project
{
    partial class FrmInputFileName
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Okey = new System.Windows.Forms.Button();
            this.Cansel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(283, 19);
            this.textBox1.TabIndex = 0;
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // Okey
            // 
            this.Okey.FlatAppearance.BorderSize = 0;
            this.Okey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Okey.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Okey.Location = new System.Drawing.Point(37, 48);
            this.Okey.Margin = new System.Windows.Forms.Padding(0);
            this.Okey.Name = "Okey";
            this.Okey.Size = new System.Drawing.Size(75, 23);
            this.Okey.TabIndex = 1;
            this.Okey.Text = "✓";
            this.Okey.UseVisualStyleBackColor = true;
            this.Okey.Click += new System.EventHandler(this.Okey_Click);
            this.Okey.MouseEnter += new System.EventHandler(this.Okey_MouseEnter);
            this.Okey.MouseLeave += new System.EventHandler(this.Okey_MouseLeave);
            // 
            // Cansel
            // 
            this.Cansel.FlatAppearance.BorderSize = 0;
            this.Cansel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cansel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Cansel.Location = new System.Drawing.Point(194, 48);
            this.Cansel.Margin = new System.Windows.Forms.Padding(0);
            this.Cansel.Name = "Cansel";
            this.Cansel.Size = new System.Drawing.Size(75, 23);
            this.Cansel.TabIndex = 2;
            this.Cansel.Text = "×";
            this.Cansel.UseVisualStyleBackColor = true;
            this.Cansel.Click += new System.EventHandler(this.Cansel_Click);
            this.Cansel.MouseEnter += new System.EventHandler(this.Cansel_MouseEnter);
            this.Cansel.MouseLeave += new System.EventHandler(this.Cansel_MouseLeave);
            // 
            // FormInputFileName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 83);
            this.Controls.Add(this.Cansel);
            this.Controls.Add(this.Okey);
            this.Controls.Add(this.textBox1);
            this.Name = "FormInputFileName";
            this.Text = "Input file name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Okey;
        private System.Windows.Forms.Button Cansel;
    }
}