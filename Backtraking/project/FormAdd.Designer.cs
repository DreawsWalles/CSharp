namespace project
{
    partial class FormAdd
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
            this.Up = new System.Windows.Forms.NumericUpDown();
            this.Down = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Up)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Down)).BeginInit();
            this.SuspendLayout();
            // 
            // Up
            // 
            this.Up.Location = new System.Drawing.Point(118, 12);
            this.Up.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.Up.Name = "Up";
            this.Up.Size = new System.Drawing.Size(33, 20);
            this.Up.TabIndex = 0;
            // 
            // Down
            // 
            this.Down.Location = new System.Drawing.Point(118, 42);
            this.Down.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.Down.Name = "Down";
            this.Down.Size = new System.Drawing.Size(33, 20);
            this.Down.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 50);
            this.panel1.TabIndex = 2;
            // 
            // button_ok
            // 
            this.button_ok.FlatAppearance.BorderSize = 0;
            this.button_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ok.Location = new System.Drawing.Point(158, 21);
            this.button_ok.Margin = new System.Windows.Forms.Padding(0);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(22, 32);
            this.button_ok.TabIndex = 3;
            this.button_ok.Text = "✓";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            this.button_ok.MouseEnter += new System.EventHandler(this.button_ok_MouseEnter);
            this.button_ok.MouseLeave += new System.EventHandler(this.button_ok_MouseLeave);
            // 
            // button_cancel
            // 
            this.button_cancel.FlatAppearance.BorderSize = 0;
            this.button_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_cancel.Location = new System.Drawing.Point(190, 21);
            this.button_cancel.Margin = new System.Windows.Forms.Padding(0);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(24, 32);
            this.button_cancel.TabIndex = 4;
            this.button_cancel.Text = "✖";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            this.button_cancel.MouseEnter += new System.EventHandler(this.button_cancel_MouseEnter);
            this.button_cancel.MouseLeave += new System.EventHandler(this.button_cancel_MouseLeave);
            // 
            // FormAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 81);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Down);
            this.Controls.Add(this.Up);
            this.Name = "FormAdd";
            this.Text = "FormAdd";
            ((System.ComponentModel.ISupportInitialize)(this.Up)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Down)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown Up;
        private System.Windows.Forms.NumericUpDown Down;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
    }
}