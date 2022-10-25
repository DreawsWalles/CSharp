namespace project
{
    partial class FrmColor
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
            this.button_dark = new System.Windows.Forms.Button();
            this.button_light_violet = new System.Windows.Forms.Button();
            this.button_accept = new System.Windows.Forms.Button();
            this.button_defaulte = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_dark
            // 
            this.button_dark.BackgroundImage = global::project.Properties.Resources.Dark;
            this.button_dark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_dark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_dark.Location = new System.Drawing.Point(360, 12);
            this.button_dark.Name = "button_dark";
            this.button_dark.Size = new System.Drawing.Size(296, 167);
            this.button_dark.TabIndex = 1;
            this.button_dark.Tag = "1";
            this.button_dark.UseVisualStyleBackColor = true;
            // 
            // button_light_violet
            // 
            this.button_light_violet.BackgroundImage = global::project.Properties.Resources.Light;
            this.button_light_violet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_light_violet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_light_violet.Location = new System.Drawing.Point(707, 12);
            this.button_light_violet.Name = "button_light_violet";
            this.button_light_violet.Size = new System.Drawing.Size(296, 167);
            this.button_light_violet.TabIndex = 2;
            this.button_light_violet.Tag = "2";
            this.button_light_violet.UseVisualStyleBackColor = true;
            // 
            // button_accept
            // 
            this.button_accept.FlatAppearance.BorderSize = 0;
            this.button_accept.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_accept.Location = new System.Drawing.Point(360, 202);
            this.button_accept.Name = "button_accept";
            this.button_accept.Size = new System.Drawing.Size(101, 31);
            this.button_accept.TabIndex = 3;
            this.button_accept.Text = "button4";
            this.button_accept.UseVisualStyleBackColor = true;
            this.button_accept.Click += new System.EventHandler(this.button_accept_Click);
            // 
            // button_defaulte
            // 
            this.button_defaulte.BackgroundImage = global::project.Properties.Resources.Default;
            this.button_defaulte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_defaulte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_defaulte.Location = new System.Drawing.Point(12, 12);
            this.button_defaulte.Name = "button_defaulte";
            this.button_defaulte.Size = new System.Drawing.Size(296, 167);
            this.button_defaulte.TabIndex = 0;
            this.button_defaulte.Tag = "0";
            this.button_defaulte.UseVisualStyleBackColor = true;
            // 
            // button_cancel
            // 
            this.button_cancel.FlatAppearance.BorderSize = 0;
            this.button_cancel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_cancel.Location = new System.Drawing.Point(555, 202);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(101, 31);
            this.button_cancel.TabIndex = 4;
            this.button_cancel.Text = "button1";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // FrmColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 245);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_accept);
            this.Controls.Add(this.button_light_violet);
            this.Controls.Add(this.button_dark);
            this.Controls.Add(this.button_defaulte);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmColor";
            this.Text = "FrmColor";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmColor_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_defaulte;
        private System.Windows.Forms.Button button_dark;
        private System.Windows.Forms.Button button_light_violet;
        private System.Windows.Forms.Button button_accept;
        private System.Windows.Forms.Button button_cancel;
    }
}