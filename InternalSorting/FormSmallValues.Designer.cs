namespace project
{
    partial class FormSmallValues
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_sort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 265);
            this.panel1.TabIndex = 0;
            // 
            // button_sort
            // 
            this.button_sort.BackColor = System.Drawing.Color.ForestGreen;
            this.button_sort.FlatAppearance.BorderSize = 0;
            this.button_sort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_sort.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_sort.ForeColor = System.Drawing.SystemColors.Control;
            this.button_sort.Location = new System.Drawing.Point(319, 307);
            this.button_sort.Name = "button_sort";
            this.button_sort.Size = new System.Drawing.Size(122, 36);
            this.button_sort.TabIndex = 1;
            this.button_sort.Text = "Сортировать";
            this.button_sort.UseVisualStyleBackColor = false;
            this.button_sort.Click += new System.EventHandler(this.button_sort_Click);
            // 
            // FormSmallValues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_sort);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "FormSmallValues";
            this.Text = "FormSmallValues";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormSmallValues_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_sort;
    }
}