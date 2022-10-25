namespace project
{
    partial class FormInputElement
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
            this.Accept = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_name = new System.Windows.Forms.Button();
            this.button_date = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LavenderBlush;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(12, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(343, 23);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // Accept
            // 
            this.Accept.BackColor = System.Drawing.Color.OrangeRed;
            this.Accept.FlatAppearance.BorderSize = 0;
            this.Accept.FlatAppearance.MouseDownBackColor = System.Drawing.Color.OrangeRed;
            this.Accept.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chartreuse;
            this.Accept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Accept.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Accept.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Accept.Location = new System.Drawing.Point(37, 103);
            this.Accept.Name = "Accept";
            this.Accept.Size = new System.Drawing.Size(107, 35);
            this.Accept.TabIndex = 1;
            this.Accept.Text = "Принять";
            this.Accept.UseVisualStyleBackColor = false;
            this.Accept.Click += new System.EventHandler(this.Accept_Click);
            this.Accept.MouseEnter += new System.EventHandler(this.Accept_MouseEnter);
            this.Accept.MouseLeave += new System.EventHandler(this.Accept_MouseLeave);
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.OrangeRed;
            this.close.FlatAppearance.BorderSize = 0;
            this.close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.OrangeRed;
            this.close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.close.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.close.Location = new System.Drawing.Point(226, 103);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(107, 35);
            this.close.TabIndex = 2;
            this.close.Text = "Закрыть";
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // button_name
            // 
            this.button_name.BackColor = System.Drawing.Color.DarkCyan;
            this.button_name.FlatAppearance.BorderSize = 0;
            this.button_name.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.button_name.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.button_name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_name.ForeColor = System.Drawing.Color.Thistle;
            this.button_name.Location = new System.Drawing.Point(296, 3);
            this.button_name.Name = "button_name";
            this.button_name.Size = new System.Drawing.Size(59, 23);
            this.button_name.TabIndex = 4;
            this.button_name.Text = "name";
            this.button_name.UseVisualStyleBackColor = false;
            this.button_name.Click += new System.EventHandler(this.button_name_Click);
            // 
            // button_date
            // 
            this.button_date.BackColor = System.Drawing.Color.DarkCyan;
            this.button_date.FlatAppearance.BorderSize = 0;
            this.button_date.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.button_date.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.button_date.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_date.ForeColor = System.Drawing.Color.Thistle;
            this.button_date.Location = new System.Drawing.Point(226, 3);
            this.button_date.Name = "button_date";
            this.button_date.Size = new System.Drawing.Size(59, 23);
            this.button_date.TabIndex = 5;
            this.button_date.Text = "date";
            this.button_date.UseVisualStyleBackColor = false;
            this.button_date.Click += new System.EventHandler(this.button_date_Click);
            // 
            // FormInputElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(371, 150);
            this.Controls.Add(this.button_date);
            this.Controls.Add(this.button_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.Accept);
            this.Controls.Add(this.textBox1);
            this.Name = "FormInputElement";
            this.Text = "FormInputElement";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormInputElement_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Accept;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_name;
        private System.Windows.Forms.Button button_date;
    }
}