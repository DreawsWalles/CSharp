namespace Task1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbBuff = new System.Windows.Forms.TextBox();
            this.tboutput = new System.Windows.Forms.TextBox();
            this.start = new System.Windows.Forms.Button();
            this.newstart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbBuff
            // 
            this.tbBuff.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbBuff.Location = new System.Drawing.Point(18, 40);
            this.tbBuff.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbBuff.Multiline = true;
            this.tbBuff.Name = "tbBuff";
            this.tbBuff.ReadOnly = true;
            this.tbBuff.Size = new System.Drawing.Size(98, 370);
            this.tbBuff.TabIndex = 2;
            // 
            // tboutput
            // 
            this.tboutput.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tboutput.Location = new System.Drawing.Point(128, 40);
            this.tboutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboutput.Multiline = true;
            this.tboutput.Name = "tboutput";
            this.tboutput.ReadOnly = true;
            this.tboutput.Size = new System.Drawing.Size(416, 370);
            this.tboutput.TabIndex = 3;
            // 
            // start
            // 
            this.start.Image = ((System.Drawing.Image)(resources.GetObject("start.Image")));
            this.start.Location = new System.Drawing.Point(432, 422);
            this.start.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(52, 40);
            this.start.TabIndex = 0;
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // newstart
            // 
            this.newstart.Image = global::Task1.Properties.Resources.stop;
            this.newstart.Location = new System.Drawing.Point(494, 422);
            this.newstart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.newstart.Name = "newstart";
            this.newstart.Size = new System.Drawing.Size(52, 40);
            this.newstart.TabIndex = 1;
            this.newstart.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.newstart.UseVisualStyleBackColor = true;
            this.newstart.Click += new System.EventHandler(this.newstart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Информация:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Буфер:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 480);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newstart);
            this.Controls.Add(this.start);
            this.Controls.Add(this.tboutput);
            this.Controls.Add(this.tbBuff);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Task 223";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbBuff;
        private System.Windows.Forms.TextBox tboutput;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button newstart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

