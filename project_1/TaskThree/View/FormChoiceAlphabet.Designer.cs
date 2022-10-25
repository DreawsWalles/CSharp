namespace TaskThree
{
    partial class FormChoiceAlphabet
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAccept = new System.Windows.Forms.Button();
            this.rbtnEnglish = new System.Windows.Forms.RadioButton();
            this.rbtnRussian = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.rbtnCreate = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(373, 183);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnClose.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.Location = new System.Drawing.Point(3, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 28);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "<-";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnAccept, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.rbtnEnglish, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.rbtnRussian, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 38);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(367, 142);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAccept.Location = new System.Drawing.Point(89, 114);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(189, 26);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Продолжить";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // rbtnEnglish
            // 
            this.rbtnEnglish.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtnEnglish.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbtnEnglish.Location = new System.Drawing.Point(89, 5);
            this.rbtnEnglish.Name = "rbtnEnglish";
            this.rbtnEnglish.Size = new System.Drawing.Size(189, 24);
            this.rbtnEnglish.TabIndex = 4;
            this.rbtnEnglish.TabStop = true;
            this.rbtnEnglish.Text = "Английский алфавит";
            this.rbtnEnglish.UseVisualStyleBackColor = true;
            this.rbtnEnglish.CheckedChanged += new System.EventHandler(this.rbtnEnglish_CheckedChanged);
            // 
            // rbtnRussian
            // 
            this.rbtnRussian.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtnRussian.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbtnRussian.Location = new System.Drawing.Point(89, 40);
            this.rbtnRussian.Name = "rbtnRussian";
            this.rbtnRussian.Size = new System.Drawing.Size(189, 24);
            this.rbtnRussian.TabIndex = 5;
            this.rbtnRussian.TabStop = true;
            this.rbtnRussian.Text = "Русский алфавит";
            this.rbtnRussian.UseVisualStyleBackColor = true;
            this.rbtnRussian.CheckedChanged += new System.EventHandler(this.rbtnRussian_CheckedChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnCreate, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.comboBox1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.rbtnCreate, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 73);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(361, 34);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreate.Location = new System.Drawing.Point(201, 3);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(157, 28);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Создать алфавит";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(38, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(157, 27);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // rbtnCreate
            // 
            this.rbtnCreate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbtnCreate.AutoSize = true;
            this.rbtnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbtnCreate.Location = new System.Drawing.Point(19, 11);
            this.rbtnCreate.Name = "rbtnCreate";
            this.rbtnCreate.Size = new System.Drawing.Size(13, 12);
            this.rbtnCreate.TabIndex = 6;
            this.rbtnCreate.TabStop = true;
            this.rbtnCreate.UseVisualStyleBackColor = true;
            this.rbtnCreate.CheckedChanged += new System.EventHandler(this.rbtnCreate_CheckedChanged);
            // 
            // FormChoiceAlphabet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 184);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormChoiceAlphabet";
            this.Text = "Выберите алфавит";
            this.Load += new System.EventHandler(this.FormChoiceAlphabet_Load);
            this.Resize += new System.EventHandler(this.FormChoiceAlphabet_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.RadioButton rbtnEnglish;
        private System.Windows.Forms.RadioButton rbtnRussian;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton rbtnCreate;
    }
}