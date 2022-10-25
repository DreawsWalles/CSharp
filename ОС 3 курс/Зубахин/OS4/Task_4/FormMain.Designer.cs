namespace Task_4
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
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonGo = new System.Windows.Forms.Button();
            this.buttonTask = new System.Windows.Forms.Button();
            this.groupBoxParam = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericProbability = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericQuantum = new System.Windows.Forms.NumericUpDown();
            this.numericMaxTicket = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.groupBoxParam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericProbability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxTicket)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxLog
            // 
            this.textBoxLog.BackColor = System.Drawing.Color.Black;
            this.textBoxLog.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.textBoxLog.Location = new System.Drawing.Point(12, 154);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(566, 251);
            this.textBoxLog.TabIndex = 0;
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(394, 26);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(90, 24);
            this.buttonGo.TabIndex = 1;
            this.buttonGo.Text = "Simulate";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // buttonTask
            // 
            this.buttonTask.BackColor = System.Drawing.SystemColors.Control;
            this.buttonTask.Cursor = System.Windows.Forms.Cursors.Help;
            this.buttonTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTask.Location = new System.Drawing.Point(302, 109);
            this.buttonTask.Name = "buttonTask";
            this.buttonTask.Size = new System.Drawing.Size(25, 23);
            this.buttonTask.TabIndex = 2;
            this.buttonTask.Text = "?";
            this.buttonTask.UseVisualStyleBackColor = false;
            this.buttonTask.Click += new System.EventHandler(this.buttonTask_Click);
            // 
            // groupBoxParam
            // 
            this.groupBoxParam.Controls.Add(this.label1);
            this.groupBoxParam.Controls.Add(this.numericProbability);
            this.groupBoxParam.Controls.Add(this.label4);
            this.groupBoxParam.Controls.Add(this.label2);
            this.groupBoxParam.Controls.Add(this.numericQuantum);
            this.groupBoxParam.Controls.Add(this.numericMaxTicket);
            this.groupBoxParam.Location = new System.Drawing.Point(12, 12);
            this.groupBoxParam.Name = "groupBoxParam";
            this.groupBoxParam.Size = new System.Drawing.Size(315, 121);
            this.groupBoxParam.TabIndex = 3;
            this.groupBoxParam.TabStop = false;
            this.groupBoxParam.Text = "Параметры";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Вероятность создания процесса";
            // 
            // numericProbability
            // 
            this.numericProbability.Location = new System.Drawing.Point(125, 41);
            this.numericProbability.Name = "numericProbability";
            this.numericProbability.Size = new System.Drawing.Size(57, 20);
            this.numericProbability.TabIndex = 10;
            this.numericProbability.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Квант времени";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Количество билетов";
            // 
            // numericQuantum
            // 
            this.numericQuantum.Location = new System.Drawing.Point(9, 89);
            this.numericQuantum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericQuantum.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericQuantum.Name = "numericQuantum";
            this.numericQuantum.Size = new System.Drawing.Size(57, 20);
            this.numericQuantum.TabIndex = 3;
            this.numericQuantum.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericMaxTicket
            // 
            this.numericMaxTicket.Location = new System.Drawing.Point(9, 41);
            this.numericMaxTicket.Name = "numericMaxTicket";
            this.numericMaxTicket.Size = new System.Drawing.Size(57, 20);
            this.numericMaxTicket.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Лог";
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(394, 102);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(89, 24);
            this.buttonExit.TabIndex = 11;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(394, 64);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(90, 24);
            this.buttonStop.TabIndex = 12;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 411);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonTask);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.groupBoxParam);
            this.Controls.Add(this.buttonGo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "Task 4 Lottery scheduler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.groupBoxParam.ResumeLayout(false);
            this.groupBoxParam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericProbability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxTicket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Button buttonTask;
        private System.Windows.Forms.GroupBox groupBoxParam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericQuantum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericMaxTicket;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericProbability;
    }
}

