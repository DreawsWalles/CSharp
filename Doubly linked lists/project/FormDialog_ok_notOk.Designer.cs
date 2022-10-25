namespace project
{
    partial class FormDialog_ok_notOk
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
            this.label1 = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.Cansel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.DarkOrange;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // ok
            // 
            this.ok.BackColor = System.Drawing.Color.OrangeRed;
            this.ok.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.ok.FlatAppearance.BorderSize = 0;
            this.ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.OrangeRed;
            this.ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chartreuse;
            this.ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ok.ForeColor = System.Drawing.SystemColors.Control;
            this.ok.Location = new System.Drawing.Point(6, 86);
            this.ok.Margin = new System.Windows.Forms.Padding(0);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(76, 28);
            this.ok.TabIndex = 1;
            this.ok.Text = "✓";
            this.ok.UseVisualStyleBackColor = false;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            this.ok.MouseEnter += new System.EventHandler(this.ok_MouseEnter);
            this.ok.MouseLeave += new System.EventHandler(this.ok_MouseLeave);
            // 
            // Cansel
            // 
            this.Cansel.BackColor = System.Drawing.Color.OrangeRed;
            this.Cansel.FlatAppearance.BorderSize = 0;
            this.Cansel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.OrangeRed;
            this.Cansel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkRed;
            this.Cansel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cansel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Cansel.ForeColor = System.Drawing.SystemColors.Control;
            this.Cansel.Location = new System.Drawing.Point(115, 89);
            this.Cansel.Margin = new System.Windows.Forms.Padding(0);
            this.Cansel.Name = "Cansel";
            this.Cansel.Size = new System.Drawing.Size(75, 29);
            this.Cansel.TabIndex = 2;
            this.Cansel.Text = "✖";
            this.Cansel.UseVisualStyleBackColor = false;
            this.Cansel.Click += new System.EventHandler(this.Cansel_Click);
            // 
            // FormDialog_ok_notOk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(226, 134);
            this.Controls.Add(this.Cansel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.label1);
            this.Name = "FormDialog_ok_notOk";
            this.Text = "Information";
            this.SizeChanged += new System.EventHandler(this.FormDialog_ok_notOk_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button Cansel;
    }
}