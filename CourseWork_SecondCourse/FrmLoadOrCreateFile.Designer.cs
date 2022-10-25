namespace project
{
    partial class FrmLoadOrCreateFile
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
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonCansel = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonEn = new System.Windows.Forms.Button();
            this.buttonRu = new System.Windows.Forms.Button();
            this.button_int = new System.Windows.Forms.Button();
            this.button_string = new System.Windows.Forms.Button();
            this.button_double = new System.Windows.Forms.Button();
            this.button_char = new System.Windows.Forms.Button();
            this.button_MyType = new System.Windows.Forms.Button();
            this.button_Float = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(72, 422);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(423, 23);
            this.textBox1.TabIndex = 1;
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // buttonOpen
            // 
            this.buttonOpen.FlatAppearance.BorderSize = 0;
            this.buttonOpen.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOpen.Location = new System.Drawing.Point(516, 421);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 2;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonCreate.FlatAppearance.BorderSize = 0;
            this.buttonCreate.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCreate.Location = new System.Drawing.Point(736, 359);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(155, 37);
            this.buttonCreate.TabIndex = 4;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = false;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonCansel
            // 
            this.buttonCansel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCansel.FlatAppearance.BorderSize = 0;
            this.buttonCansel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCansel.Location = new System.Drawing.Point(615, 421);
            this.buttonCansel.Name = "buttonCansel";
            this.buttonCansel.Size = new System.Drawing.Size(75, 23);
            this.buttonCansel.TabIndex = 3;
            this.buttonCansel.Text = "Cancel";
            this.buttonCansel.UseVisualStyleBackColor = true;
            this.buttonCansel.Click += new System.EventHandler(this.ButtonCansel_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.Location = new System.Drawing.Point(12, 425);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(54, 19);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "File:";
            // 
            // buttonEn
            // 
            this.buttonEn.FlatAppearance.BorderSize = 0;
            this.buttonEn.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEn.Location = new System.Drawing.Point(897, 12);
            this.buttonEn.Name = "buttonEn";
            this.buttonEn.Size = new System.Drawing.Size(28, 23);
            this.buttonEn.TabIndex = 5;
            this.buttonEn.Text = "En";
            this.buttonEn.UseVisualStyleBackColor = true;
            this.buttonEn.Click += new System.EventHandler(this.buttonEn_Click);
            // 
            // buttonRu
            // 
            this.buttonRu.FlatAppearance.BorderSize = 0;
            this.buttonRu.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRu.Location = new System.Drawing.Point(863, 13);
            this.buttonRu.Name = "buttonRu";
            this.buttonRu.Size = new System.Drawing.Size(28, 22);
            this.buttonRu.TabIndex = 6;
            this.buttonRu.Text = "RU";
            this.buttonRu.UseVisualStyleBackColor = true;
            this.buttonRu.Click += new System.EventHandler(this.buttonRu_Click);
            // 
            // button_int
            // 
            this.button_int.FlatAppearance.BorderSize = 0;
            this.button_int.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_int.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_int.Location = new System.Drawing.Point(736, 204);
            this.button_int.Name = "button_int";
            this.button_int.Size = new System.Drawing.Size(155, 28);
            this.button_int.TabIndex = 11;
            this.button_int.Tag = "4";
            this.button_int.Text = "int";
            this.button_int.UseVisualStyleBackColor = true;
            // 
            // button_string
            // 
            this.button_string.FlatAppearance.BorderSize = 0;
            this.button_string.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_string.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_string.Location = new System.Drawing.Point(736, 153);
            this.button_string.Name = "button_string";
            this.button_string.Size = new System.Drawing.Size(155, 28);
            this.button_string.TabIndex = 10;
            this.button_string.Tag = "3";
            this.button_string.Text = "string";
            this.button_string.UseVisualStyleBackColor = true;
            // 
            // button_double
            // 
            this.button_double.FlatAppearance.BorderSize = 0;
            this.button_double.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_double.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_double.Location = new System.Drawing.Point(736, 104);
            this.button_double.Name = "button_double";
            this.button_double.Size = new System.Drawing.Size(155, 28);
            this.button_double.TabIndex = 9;
            this.button_double.Tag = "2";
            this.button_double.Text = "double";
            this.button_double.UseVisualStyleBackColor = true;
            // 
            // button_char
            // 
            this.button_char.FlatAppearance.BorderSize = 0;
            this.button_char.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_char.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_char.Location = new System.Drawing.Point(736, 52);
            this.button_char.Name = "button_char";
            this.button_char.Size = new System.Drawing.Size(155, 28);
            this.button_char.TabIndex = 8;
            this.button_char.Tag = "1";
            this.button_char.Text = "char";
            this.button_char.UseVisualStyleBackColor = true;
            // 
            // button_MyType
            // 
            this.button_MyType.FlatAppearance.BorderSize = 0;
            this.button_MyType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_MyType.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_MyType.Location = new System.Drawing.Point(736, 257);
            this.button_MyType.Name = "button_MyType";
            this.button_MyType.Size = new System.Drawing.Size(155, 28);
            this.button_MyType.TabIndex = 12;
            this.button_MyType.Tag = "5";
            this.button_MyType.Text = "My Type";
            this.button_MyType.UseVisualStyleBackColor = true;
            // 
            // button_Float
            // 
            this.button_Float.FlatAppearance.BorderSize = 0;
            this.button_Float.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Float.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Float.Location = new System.Drawing.Point(736, 309);
            this.button_Float.Name = "button_Float";
            this.button_Float.Size = new System.Drawing.Size(155, 28);
            this.button_Float.TabIndex = 13;
            this.button_Float.Tag = "6";
            this.button_Float.Text = "Float";
            this.button_Float.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 19;
            this.listBox1.Location = new System.Drawing.Point(12, 16);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(678, 384);
            this.listBox1.TabIndex = 0;
            // 
            // buttonColor
            // 
            this.buttonColor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonColor.BackgroundImage = global::project.Properties.Resources.Color_circle;
            this.buttonColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonColor.FlatAppearance.BorderSize = 0;
            this.buttonColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonColor.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonColor.Location = new System.Drawing.Point(834, 12);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(23, 23);
            this.buttonColor.TabIndex = 7;
            this.buttonColor.UseVisualStyleBackColor = false;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // FrmLoadOrCreateFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(937, 467);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button_Float);
            this.Controls.Add(this.button_MyType);
            this.Controls.Add(this.button_char);
            this.Controls.Add(this.button_double);
            this.Controls.Add(this.button_string);
            this.Controls.Add(this.button_int);
            this.Controls.Add(this.buttonColor);
            this.Controls.Add(this.buttonRu);
            this.Controls.Add(this.buttonEn);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonCansel);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.textBox1);
            this.KeyPreview = true;
            this.Name = "FrmLoadOrCreateFile";
            this.Text = "FrmLoadOrCreateFile";
            this.SizeChanged += new System.EventHandler(this.FrmLoadOrCreateFile_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form_KeyUp);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.form_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonCansel;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonEn;
        private System.Windows.Forms.Button buttonRu;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.Button button_int;
        private System.Windows.Forms.Button button_string;
        private System.Windows.Forms.Button button_double;
        private System.Windows.Forms.Button button_char;
        private System.Windows.Forms.Button button_MyType;
        private System.Windows.Forms.Button button_Float;
        private System.Windows.Forms.ListBox listBox1;
    }
}