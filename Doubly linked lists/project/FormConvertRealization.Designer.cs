namespace project
{
    partial class FormConvertElement
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
            this.Array = new System.Windows.Forms.Button();
            this.List = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Array
            // 
            this.Array.BackColor = System.Drawing.Color.DarkCyan;
            this.Array.FlatAppearance.BorderSize = 0;
            this.Array.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.Array.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.Array.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Array.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Array.ForeColor = System.Drawing.Color.Thistle;
            this.Array.Location = new System.Drawing.Point(65, 23);
            this.Array.Name = "Array";
            this.Array.Size = new System.Drawing.Size(107, 31);
            this.Array.TabIndex = 0;
            this.Array.Text = "Array";
            this.Array.UseVisualStyleBackColor = false;
            this.Array.Click += new System.EventHandler(this.Array_Click);
            // 
            // List
            // 
            this.List.BackColor = System.Drawing.Color.DarkCyan;
            this.List.FlatAppearance.BorderSize = 0;
            this.List.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.List.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.List.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.List.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.List.ForeColor = System.Drawing.Color.Thistle;
            this.List.Location = new System.Drawing.Point(65, 84);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(107, 31);
            this.List.TabIndex = 1;
            this.List.Text = "List";
            this.List.UseVisualStyleBackColor = false;
            this.List.Click += new System.EventHandler(this.List_Click);
            // 
            // FormConvertElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(237, 149);
            this.Controls.Add(this.List);
            this.Controls.Add(this.Array);
            this.Name = "FormConvertElement";
            this.Text = "FormConvertElement";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Array;
        private System.Windows.Forms.Button List;
    }
}