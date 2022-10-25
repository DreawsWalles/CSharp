
namespace project
{
    partial class FormCreate
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
            this.label2 = new System.Windows.Forms.Label();
            this.NameObject = new System.Windows.Forms.TextBox();
            this.SizeObject = new System.Windows.Forms.TextBox();
            this.Accept = new System.Windows.Forms.Button();
            this.Cansel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(29, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(30, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // NameObject
            // 
            this.NameObject.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameObject.Location = new System.Drawing.Point(138, 17);
            this.NameObject.Name = "NameObject";
            this.NameObject.Size = new System.Drawing.Size(119, 23);
            this.NameObject.TabIndex = 2;
            // 
            // SizeObject
            // 
            this.SizeObject.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SizeObject.Location = new System.Drawing.Point(138, 48);
            this.SizeObject.Name = "SizeObject";
            this.SizeObject.Size = new System.Drawing.Size(119, 23);
            this.SizeObject.TabIndex = 3;
            // 
            // Accept
            // 
            this.Accept.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.Accept.FlatAppearance.BorderSize = 0;
            this.Accept.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleGreen;
            this.Accept.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.Accept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Accept.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Accept.Location = new System.Drawing.Point(57, 97);
            this.Accept.Name = "Accept";
            this.Accept.Size = new System.Drawing.Size(75, 23);
            this.Accept.TabIndex = 4;
            this.Accept.Text = "Создать";
            this.Accept.UseVisualStyleBackColor = true;
            this.Accept.Click += new System.EventHandler(this.Accept_Click);
            // 
            // Cansel
            // 
            this.Cansel.FlatAppearance.BorderSize = 0;
            this.Cansel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Salmon;
            this.Cansel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Salmon;
            this.Cansel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cansel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Cansel.Location = new System.Drawing.Point(192, 96);
            this.Cansel.Name = "Cansel";
            this.Cansel.Size = new System.Drawing.Size(75, 23);
            this.Cansel.TabIndex = 5;
            this.Cansel.Text = "Отменить";
            this.Cansel.UseVisualStyleBackColor = true;
            // 
            // FormCreate
            // 
            this.AcceptButton = this.Accept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cansel;
            this.ClientSize = new System.Drawing.Size(347, 135);
            this.Controls.Add(this.Cansel);
            this.Controls.Add(this.Accept);
            this.Controls.Add(this.SizeObject);
            this.Controls.Add(this.NameObject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCreate";
            this.Text = "Form";
            this.Load += new System.EventHandler(this.FormCreate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NameObject;
        private System.Windows.Forms.TextBox SizeObject;
        private System.Windows.Forms.Button Accept;
        private System.Windows.Forms.Button Cansel;
    }
}