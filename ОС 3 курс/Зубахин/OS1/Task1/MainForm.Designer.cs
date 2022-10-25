namespace Task1
{
    partial class main_frm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ReaderTB = new System.Windows.Forms.TextBox();
            this.mainTB = new System.Windows.Forms.TextBox();
            this.WriterTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Run = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btn_Writers = new System.Windows.Forms.Button();
            this.btn_mainBuf = new System.Windows.Forms.Button();
            this.btn_Readers = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buf_size = new System.Windows.Forms.NumericUpDown();
            this.ThreadsBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonTask = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.buf_size)).BeginInit();
            this.ThreadsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReaderTB
            // 
            this.ReaderTB.Location = new System.Drawing.Point(6, 44);
            this.ReaderTB.Multiline = true;
            this.ReaderTB.Name = "ReaderTB";
            this.ReaderTB.ReadOnly = true;
            this.ReaderTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ReaderTB.Size = new System.Drawing.Size(169, 181);
            this.ReaderTB.TabIndex = 5;
            this.ReaderTB.TextChanged += new System.EventHandler(this.txtBoxBuffer_TextChanged);
            // 
            // mainTB
            // 
            this.mainTB.Location = new System.Drawing.Point(9, 302);
            this.mainTB.Multiline = true;
            this.mainTB.Name = "mainTB";
            this.mainTB.ReadOnly = true;
            this.mainTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mainTB.Size = new System.Drawing.Size(295, 77);
            this.mainTB.TabIndex = 6;
            this.mainTB.TextChanged += new System.EventHandler(this.txtBoxBuffer_TextChanged);
            // 
            // WriterTB
            // 
            this.WriterTB.Location = new System.Drawing.Point(184, 44);
            this.WriterTB.Multiline = true;
            this.WriterTB.Name = "WriterTB";
            this.WriterTB.ReadOnly = true;
            this.WriterTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.WriterTB.Size = new System.Drawing.Size(169, 181);
            this.WriterTB.TabIndex = 7;
            this.WriterTB.TextChanged += new System.EventHandler(this.txtBoxBuffer_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Readers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(181, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Writers";
            // 
            // btn_Run
            // 
            this.btn_Run.BackColor = System.Drawing.Color.Transparent;
            this.btn_Run.FlatAppearance.BorderSize = 0;
            this.btn_Run.Location = new System.Drawing.Point(202, 400);
            this.btn_Run.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(75, 25);
            this.btn_Run.TabIndex = 0;
            this.btn_Run.Text = "Start";
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Click += new System.EventHandler(this.btnrun_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.BackColor = System.Drawing.Color.Transparent;
            this.btnAbort.Enabled = false;
            this.btnAbort.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAbort.Location = new System.Drawing.Point(293, 400);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(76, 25);
            this.btnAbort.TabIndex = 1;
            this.btnAbort.Text = "Abort";
            this.btnAbort.UseVisualStyleBackColor = false;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btn_Writers
            // 
            this.btn_Writers.Enabled = false;
            this.btn_Writers.Location = new System.Drawing.Point(224, 231);
            this.btn_Writers.Name = "btn_Writers";
            this.btn_Writers.Size = new System.Drawing.Size(78, 25);
            this.btn_Writers.TabIndex = 4;
            this.btn_Writers.Text = "Start/Stop";
            this.btn_Writers.UseVisualStyleBackColor = true;
            this.btn_Writers.Click += new System.EventHandler(this.btnWriters_Click);
            // 
            // btn_mainBuf
            // 
            this.btn_mainBuf.Enabled = false;
            this.btn_mainBuf.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_mainBuf.Location = new System.Drawing.Point(316, 316);
            this.btn_mainBuf.Name = "btn_mainBuf";
            this.btn_mainBuf.Size = new System.Drawing.Size(44, 51);
            this.btn_mainBuf.TabIndex = 3;
            this.btn_mainBuf.Text = "►\r\n ▌▌\r\n";
            this.btn_mainBuf.UseVisualStyleBackColor = true;
            this.btn_mainBuf.Click += new System.EventHandler(this.btn_mainBuf_Click);
            // 
            // btn_Readers
            // 
            this.btn_Readers.Enabled = false;
            this.btn_Readers.Location = new System.Drawing.Point(48, 231);
            this.btn_Readers.Name = "btn_Readers";
            this.btn_Readers.Size = new System.Drawing.Size(78, 25);
            this.btn_Readers.TabIndex = 2;
            this.btn_Readers.Text = "Start/Stop";
            this.btn_Readers.UseVisualStyleBackColor = true;
            this.btn_Readers.Click += new System.EventHandler(this.btn_Readers_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(9, 404);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Buffer size:";
            // 
            // buf_size
            // 
            this.buf_size.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buf_size.Location = new System.Drawing.Point(71, 402);
            this.buf_size.Margin = new System.Windows.Forms.Padding(2);
            this.buf_size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.buf_size.Name = "buf_size";
            this.buf_size.Size = new System.Drawing.Size(99, 20);
            this.buf_size.TabIndex = 9;
            this.buf_size.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // ThreadsBox
            // 
            this.ThreadsBox.Controls.Add(this.ReaderTB);
            this.ThreadsBox.Controls.Add(this.WriterTB);
            this.ThreadsBox.Controls.Add(this.btn_Readers);
            this.ThreadsBox.Controls.Add(this.label1);
            this.ThreadsBox.Controls.Add(this.btn_Writers);
            this.ThreadsBox.Controls.Add(this.label3);
            this.ThreadsBox.Location = new System.Drawing.Point(3, 25);
            this.ThreadsBox.Name = "ThreadsBox";
            this.ThreadsBox.Size = new System.Drawing.Size(366, 258);
            this.ThreadsBox.TabIndex = 10;
            this.ThreadsBox.TabStop = false;
            this.ThreadsBox.Text = "Threads";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Actions";
            // 
            // buttonTask
            // 
            this.buttonTask.Location = new System.Drawing.Point(345, -1);
            this.buttonTask.Name = "buttonTask";
            this.buttonTask.Size = new System.Drawing.Size(25, 23);
            this.buttonTask.TabIndex = 8;
            this.buttonTask.Text = "?";
            this.buttonTask.UseVisualStyleBackColor = true;
            this.buttonTask.Click += new System.EventHandler(this.button1_Click);
            // 
            // main_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 435);
            this.Controls.Add(this.buttonTask);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mainTB);
            this.Controls.Add(this.ThreadsBox);
            this.Controls.Add(this.buf_size);
            this.Controls.Add(this.btn_mainBuf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btn_Run);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "main_frm";
            this.Text = "Task1";
            ((System.ComponentModel.ISupportInitialize)(this.buf_size)).EndInit();
            this.ThreadsBox.ResumeLayout(false);
            this.ThreadsBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ReaderTB;
        private System.Windows.Forms.TextBox mainTB;
        private System.Windows.Forms.TextBox WriterTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Run;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Button btn_Writers;
        private System.Windows.Forms.Button btn_mainBuf;
        private System.Windows.Forms.Button btn_Readers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown buf_size;
        private System.Windows.Forms.GroupBox ThreadsBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonTask;
    }
}

