namespace task224_os
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
            this.tbSupCon = new System.Windows.Forms.TextBox();
            this.lblSupCon = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnTask = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbR = new System.Windows.Forms.RadioButton();
            this.rbW = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSupCon
            // 
            this.tbSupCon.Location = new System.Drawing.Point(12, 25);
            this.tbSupCon.Multiline = true;
            this.tbSupCon.Name = "tbSupCon";
            this.tbSupCon.Size = new System.Drawing.Size(214, 286);
            this.tbSupCon.TabIndex = 0;
            // 
            // lblSupCon
            // 
            this.lblSupCon.AutoSize = true;
            this.lblSupCon.Location = new System.Drawing.Point(12, 9);
            this.lblSupCon.Name = "lblSupCon";
            this.lblSupCon.Size = new System.Drawing.Size(59, 13);
            this.lblSupCon.TabIndex = 1;
            this.lblSupCon.Text = "Процессы";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(251, 259);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(92, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Старт";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(251, 288);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(92, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Стоп";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnTask
            // 
            this.btnTask.Location = new System.Drawing.Point(251, 25);
            this.btnTask.Name = "btnTask";
            this.btnTask.Size = new System.Drawing.Size(92, 23);
            this.btnTask.TabIndex = 9;
            this.btnTask.Text = "Условие";
            this.btnTask.UseVisualStyleBackColor = true;
            this.btnTask.Click += new System.EventHandler(this.btnTask_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAll);
            this.groupBox1.Controls.Add(this.rbW);
            this.groupBox1.Controls.Add(this.rbR);
            this.groupBox1.Location = new System.Drawing.Point(251, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(114, 134);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выберите:";
            // 
            // rbR
            // 
            this.rbR.AutoSize = true;
            this.rbR.Location = new System.Drawing.Point(10, 28);
            this.rbR.Name = "rbR";
            this.rbR.Size = new System.Drawing.Size(73, 17);
            this.rbR.TabIndex = 0;
            this.rbR.Text = "Читатель";
            this.rbR.UseVisualStyleBackColor = true;
            this.rbR.CheckedChanged += new System.EventHandler(this.rbR_CheckedChanged);
            // 
            // rbW
            // 
            this.rbW.AutoSize = true;
            this.rbW.Location = new System.Drawing.Point(10, 61);
            this.rbW.Name = "rbW";
            this.rbW.Size = new System.Drawing.Size(74, 17);
            this.rbW.TabIndex = 1;
            this.rbW.Text = "Писатель";
            this.rbW.UseVisualStyleBackColor = true;
            this.rbW.CheckedChanged += new System.EventHandler(this.rbW_CheckedChanged);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(10, 97);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(95, 17);
            this.rbAll.TabIndex = 2;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "Все работают";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 323);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTask);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblSupCon);
            this.Controls.Add(this.tbSupCon);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSupCon;
        private System.Windows.Forms.Label lblSupCon;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnTask;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbW;
        private System.Windows.Forms.RadioButton rbR;
        private System.Windows.Forms.RadioButton rbAll;
    }
}

