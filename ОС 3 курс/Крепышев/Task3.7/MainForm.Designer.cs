namespace Task3._7
{
    partial class MainForm
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
            this.txbxInfo = new System.Windows.Forms.TextBox();
            this.btnDoTask = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbxMinAdress = new System.Windows.Forms.TextBox();
            this.txbxMaxAdress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetRange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbxInfo
            // 
            this.txbxInfo.Location = new System.Drawing.Point(12, 91);
            this.txbxInfo.Multiline = true;
            this.txbxInfo.Name = "txbxInfo";
            this.txbxInfo.ReadOnly = true;
            this.txbxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbxInfo.Size = new System.Drawing.Size(437, 287);
            this.txbxInfo.TabIndex = 2;
            // 
            // btnDoTask
            // 
            this.btnDoTask.Location = new System.Drawing.Point(273, 39);
            this.btnDoTask.Name = "btnDoTask";
            this.btnDoTask.Size = new System.Drawing.Size(176, 44);
            this.btnDoTask.TabIndex = 7;
            this.btnDoTask.Text = "Выполнить";
            this.btnDoTask.UseVisualStyleBackColor = true;
            this.btnDoTask.Click += new System.EventHandler(this.btnDoTask_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Диапазон лин. адресов:";
            // 
            // txbxMinAdress
            // 
            this.txbxMinAdress.Location = new System.Drawing.Point(55, 39);
            this.txbxMinAdress.Name = "txbxMinAdress";
            this.txbxMinAdress.Size = new System.Drawing.Size(212, 20);
            this.txbxMinAdress.TabIndex = 9;
            this.txbxMinAdress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbxMinAdress_KeyPress);
            // 
            // txbxMaxAdress
            // 
            this.txbxMaxAdress.Location = new System.Drawing.Point(55, 65);
            this.txbxMaxAdress.Name = "txbxMaxAdress";
            this.txbxMaxAdress.Size = new System.Drawing.Size(212, 20);
            this.txbxMaxAdress.TabIndex = 10;
            this.txbxMaxAdress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbxMaxAdress_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Min";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(13, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Max";
            // 
            // btnGetRange
            // 
            this.btnGetRange.Location = new System.Drawing.Point(273, 7);
            this.btnGetRange.Name = "btnGetRange";
            this.btnGetRange.Size = new System.Drawing.Size(176, 26);
            this.btnGetRange.TabIndex = 13;
            this.btnGetRange.Text = "Получить диапазон";
            this.btnGetRange.UseVisualStyleBackColor = true;
            this.btnGetRange.Click += new System.EventHandler(this.btnGetRange_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 390);
            this.Controls.Add(this.btnGetRange);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbxMaxAdress);
            this.Controls.Add(this.txbxMinAdress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDoTask);
            this.Controls.Add(this.txbxInfo);
            this.MaximumSize = new System.Drawing.Size(477, 428);
            this.MinimumSize = new System.Drawing.Size(477, 428);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txbxInfo;
        private System.Windows.Forms.Button btnDoTask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbxMinAdress;
        private System.Windows.Forms.TextBox txbxMaxAdress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGetRange;
    }
}

