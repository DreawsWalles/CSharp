namespace project
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Title = new System.Windows.Forms.Label();
            this.button_big = new System.Windows.Forms.Button();
            this.button_Small = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Consolas", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Title.Location = new System.Drawing.Point(12, 24);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(280, 22);
            this.Title.TabIndex = 0;
            this.Title.Text = "Выберите размерность набора";
            // 
            // button_big
            // 
            this.button_big.BackColor = System.Drawing.Color.ForestGreen;
            this.button_big.FlatAppearance.BorderSize = 0;
            this.button_big.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_big.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_big.ForeColor = System.Drawing.Color.Snow;
            this.button_big.Location = new System.Drawing.Point(58, 61);
            this.button_big.Name = "button_big";
            this.button_big.Size = new System.Drawing.Size(193, 31);
            this.button_big.TabIndex = 1;
            this.button_big.Text = "Размерность > 10";
            this.button_big.UseVisualStyleBackColor = false;
            this.button_big.Click += new System.EventHandler(this.button_big_Click);
            this.button_big.KeyUp += new System.Windows.Forms.KeyEventHandler(this.button_big_KeyUp);
            // 
            // button_Small
            // 
            this.button_Small.BackColor = System.Drawing.Color.ForestGreen;
            this.button_Small.FlatAppearance.BorderSize = 0;
            this.button_Small.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Small.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Small.ForeColor = System.Drawing.Color.Snow;
            this.button_Small.Location = new System.Drawing.Point(58, 116);
            this.button_Small.Name = "button_Small";
            this.button_Small.Size = new System.Drawing.Size(193, 31);
            this.button_Small.TabIndex = 2;
            this.button_Small.Text = "Размерность 10";
            this.button_Small.UseVisualStyleBackColor = false;
            this.button_Small.Click += new System.EventHandler(this.button_Small_Click);
            this.button_Small.KeyUp += new System.Windows.Forms.KeyEventHandler(this.button_Small_KeyUp);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(309, 163);
            this.Controls.Add(this.button_Small);
            this.Controls.Add(this.button_big);
            this.Controls.Add(this.Title);
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.Text = "Form1";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button button_big;
        private System.Windows.Forms.Button button_Small;
    }
}

