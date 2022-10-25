namespace ProcessInfo
{
    partial class mainForm
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
            this.btnCreateSnapshot = new System.Windows.Forms.Button();
            this.lblTextID = new System.Windows.Forms.Label();
            this.lblTextName = new System.Windows.Forms.Label();
            this.lblTextMemory = new System.Windows.Forms.Label();
            this.lblCountID = new System.Windows.Forms.Label();
            this.lblCaption = new System.Windows.Forms.Label();
            this.lblMemorySize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCreateSnapshot
            // 
            this.btnCreateSnapshot.Location = new System.Drawing.Point(12, 158);
            this.btnCreateSnapshot.Name = "btnCreateSnapshot";
            this.btnCreateSnapshot.Size = new System.Drawing.Size(354, 43);
            this.btnCreateSnapshot.TabIndex = 0;
            this.btnCreateSnapshot.Text = "Остановить";
            this.btnCreateSnapshot.UseVisualStyleBackColor = true;
            this.btnCreateSnapshot.Click += new System.EventHandler(this.btnCreateSnapshot_Click);
            // 
            // lblTextID
            // 
            this.lblTextID.AutoSize = true;
            this.lblTextID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTextID.ForeColor = System.Drawing.Color.Red;
            this.lblTextID.Location = new System.Drawing.Point(8, 25);
            this.lblTextID.Name = "lblTextID";
            this.lblTextID.Size = new System.Drawing.Size(32, 24);
            this.lblTextID.TabIndex = 1;
            this.lblTextID.Text = "ID:";
            // 
            // lblTextName
            // 
            this.lblTextName.AutoSize = true;
            this.lblTextName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTextName.ForeColor = System.Drawing.Color.Red;
            this.lblTextName.Location = new System.Drawing.Point(8, 74);
            this.lblTextName.Name = "lblTextName";
            this.lblTextName.Size = new System.Drawing.Size(192, 24);
            this.lblTextName.TabIndex = 2;
            this.lblTextName.Text = "Название процесса:";
            // 
            // lblTextMemory
            // 
            this.lblTextMemory.AutoSize = true;
            this.lblTextMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTextMemory.ForeColor = System.Drawing.Color.Red;
            this.lblTextMemory.Location = new System.Drawing.Point(8, 125);
            this.lblTextMemory.Name = "lblTextMemory";
            this.lblTextMemory.Size = new System.Drawing.Size(159, 24);
            this.lblTextMemory.TabIndex = 3;
            this.lblTextMemory.Text = "Занятая память:";
            // 
            // lblCountID
            // 
            this.lblCountID.AutoSize = true;
            this.lblCountID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCountID.Location = new System.Drawing.Point(206, 25);
            this.lblCountID.Name = "lblCountID";
            this.lblCountID.Size = new System.Drawing.Size(20, 24);
            this.lblCountID.TabIndex = 4;
            this.lblCountID.Text = "0";
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCaption.Location = new System.Drawing.Point(206, 74);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(0, 24);
            this.lblCaption.TabIndex = 5;
            // 
            // lblMemorySize
            // 
            this.lblMemorySize.AutoSize = true;
            this.lblMemorySize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMemorySize.Location = new System.Drawing.Point(206, 125);
            this.lblMemorySize.Name = "lblMemorySize";
            this.lblMemorySize.Size = new System.Drawing.Size(20, 24);
            this.lblMemorySize.TabIndex = 6;
            this.lblMemorySize.Text = "0";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 213);
            this.Controls.Add(this.lblMemorySize);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.lblCountID);
            this.Controls.Add(this.lblTextMemory);
            this.Controls.Add(this.lblTextName);
            this.Controls.Add(this.lblTextID);
            this.Controls.Add(this.btnCreateSnapshot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Моментальные снимки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateSnapshot;
        private System.Windows.Forms.Label lblTextID;
        private System.Windows.Forms.Label lblTextName;
        private System.Windows.Forms.Label lblTextMemory;
        private System.Windows.Forms.Label lblCountID;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Label lblMemorySize;
    }
}

