namespace Task2
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
            this.tbPath1 = new System.Windows.Forms.TextBox();
            this.tbPath2 = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lbl_info = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.lbl_ = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._lbl_ = new System.Windows.Forms.Label();
            this.lbl_abs = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbPath1
            // 
            this.tbPath1.Location = new System.Drawing.Point(48, 85);
            this.tbPath1.Margin = new System.Windows.Forms.Padding(4);
            this.tbPath1.Name = "tbPath1";
            this.tbPath1.ReadOnly = true;
            this.tbPath1.Size = new System.Drawing.Size(394, 22);
            this.tbPath1.TabIndex = 2;
            this.tbPath1.DoubleClick += new System.EventHandler(this.tbPath1_DoubleClick);
            // 
            // tbPath2
            // 
            this.tbPath2.Location = new System.Drawing.Point(48, 145);
            this.tbPath2.Margin = new System.Windows.Forms.Padding(4);
            this.tbPath2.Name = "tbPath2";
            this.tbPath2.ReadOnly = true;
            this.tbPath2.Size = new System.Drawing.Size(394, 22);
            this.tbPath2.TabIndex = 3;
            this.tbPath2.DoubleClick += new System.EventHandler(this.tbPath2_DoubleClick);
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_info.Location = new System.Drawing.Point(481, 23);
            this.lbl_info.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(154, 20);
            this.lbl_info.TabIndex = 6;
            this.lbl_info.Text = "Размер в байтах:";
            this.lbl_info.Visible = false;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl.Location = new System.Drawing.Point(496, 78);
            this.lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(74, 29);
            this.lbl.TabIndex = 7;
            this.lbl.Text = "size1";
            this.lbl.Visible = false;
            // 
            // lbl_
            // 
            this.lbl_.AutoSize = true;
            this.lbl_.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_.Location = new System.Drawing.Point(496, 138);
            this.lbl_.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_.Name = "lbl_";
            this.lbl_.Size = new System.Drawing.Size(74, 29);
            this.lbl_.TabIndex = 8;
            this.lbl_.Text = "size2";
            this.lbl_.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(48, 185);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 28);
            this.button2.TabIndex = 10;
            this.button2.Text = "Старт";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(44, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Выберите каталоги:";
            // 
            // _lbl_
            // 
            this._lbl_.AutoSize = true;
            this._lbl_.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._lbl_.Location = new System.Drawing.Point(681, 104);
            this._lbl_.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lbl_.Name = "_lbl_";
            this._lbl_.Size = new System.Drawing.Size(204, 29);
            this._lbl_.TabIndex = 12;
            this._lbl_.Text = "abs(size1-size2)";
            this._lbl_.Visible = false;
            // 
            // lbl_abs
            // 
            this.lbl_abs.AutoSize = true;
            this.lbl_abs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_abs.Location = new System.Drawing.Point(682, 23);
            this.lbl_abs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_abs.Name = "lbl_abs";
            this.lbl_abs.Size = new System.Drawing.Size(84, 20);
            this.lbl_abs.TabIndex = 13;
            this.lbl_abs.Text = "Разница:";
            this.lbl_abs.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 226);
            this.Controls.Add(this.lbl_abs);
            this.Controls.Add(this._lbl_);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbl_);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.tbPath2);
            this.Controls.Add(this.tbPath1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "Task2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPath1;
        private System.Windows.Forms.TextBox tbPath2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lbl_;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _lbl_;
        private System.Windows.Forms.Label lbl_abs;
    }
}

