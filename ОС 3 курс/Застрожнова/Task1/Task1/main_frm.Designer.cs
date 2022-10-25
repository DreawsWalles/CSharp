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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_frm));
            this.ReaderTB = new System.Windows.Forms.TextBox();
            this.mainTB = new System.Windows.Forms.TextBox();
            this.WriterTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Run = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btn_Writers = new System.Windows.Forms.Button();
            this.btn_mainBuf = new System.Windows.Forms.Button();
            this.btn_Readers = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buf_size = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.buf_size)).BeginInit();
            this.SuspendLayout();
            // 
            // ReaderTB
            // 
            this.ReaderTB.Location = new System.Drawing.Point(21, 147);
            this.ReaderTB.Margin = new System.Windows.Forms.Padding(4);
            this.ReaderTB.Multiline = true;
            this.ReaderTB.Name = "ReaderTB";
            this.ReaderTB.ReadOnly = true;
            this.ReaderTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ReaderTB.Size = new System.Drawing.Size(235, 291);
            this.ReaderTB.TabIndex = 5;
            this.ReaderTB.TextChanged += new System.EventHandler(this.txtBoxBuffer_TextChanged);
            // 
            // mainTB
            // 
            this.mainTB.Location = new System.Drawing.Point(264, 148);
            this.mainTB.Margin = new System.Windows.Forms.Padding(4);
            this.mainTB.Multiline = true;
            this.mainTB.Name = "mainTB";
            this.mainTB.ReadOnly = true;
            this.mainTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mainTB.Size = new System.Drawing.Size(260, 291);
            this.mainTB.TabIndex = 6;
            this.mainTB.TextChanged += new System.EventHandler(this.txtBoxBuffer_TextChanged);
            // 
            // WriterTB
            // 
            this.WriterTB.Location = new System.Drawing.Point(532, 147);
            this.WriterTB.Margin = new System.Windows.Forms.Padding(4);
            this.WriterTB.Multiline = true;
            this.WriterTB.Name = "WriterTB";
            this.WriterTB.ReadOnly = true;
            this.WriterTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.WriterTB.Size = new System.Drawing.Size(235, 291);
            this.WriterTB.TabIndex = 7;
            this.WriterTB.TextChanged += new System.EventHandler(this.txtBoxBuffer_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(91, 119);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Readers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(361, 119);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Buffer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(612, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Writers";
            // 
            // btn_Run
            // 
            this.btn_Run.BackColor = System.Drawing.Color.Transparent;
            this.btn_Run.FlatAppearance.BorderSize = 0;
            this.btn_Run.Image = ((System.Drawing.Image)(resources.GetObject("btn_Run.Image")));
            this.btn_Run.Location = new System.Drawing.Point(434, 13);
            this.btn_Run.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(100, 90);
            this.btn_Run.TabIndex = 0;
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Click += new System.EventHandler(this.btnrun_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.BackColor = System.Drawing.Color.Transparent;
            this.btnAbort.Enabled = false;
            this.btnAbort.Image = ((System.Drawing.Image)(resources.GetObject("btnAbort.Image")));
            this.btnAbort.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAbort.Location = new System.Drawing.Point(624, 13);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(102, 90);
            this.btnAbort.TabIndex = 1;
            this.btnAbort.UseVisualStyleBackColor = false;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btn_Writers
            // 
            this.btn_Writers.Enabled = false;
            this.btn_Writers.Image = ((System.Drawing.Image)(resources.GetObject("btn_Writers.Image")));
            this.btn_Writers.Location = new System.Drawing.Point(624, 446);
            this.btn_Writers.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Writers.Name = "btn_Writers";
            this.btn_Writers.Size = new System.Drawing.Size(62, 51);
            this.btn_Writers.TabIndex = 4;
            this.btn_Writers.UseVisualStyleBackColor = true;
            this.btn_Writers.Click += new System.EventHandler(this.btnWriters_Click);
            // 
            // btn_mainBuf
            // 
            this.btn_mainBuf.Enabled = false;
            this.btn_mainBuf.Image = ((System.Drawing.Image)(resources.GetObject("btn_mainBuf.Image")));
            this.btn_mainBuf.Location = new System.Drawing.Point(360, 446);
            this.btn_mainBuf.Margin = new System.Windows.Forms.Padding(4);
            this.btn_mainBuf.Name = "btn_mainBuf";
            this.btn_mainBuf.Size = new System.Drawing.Size(64, 51);
            this.btn_mainBuf.TabIndex = 3;
            this.btn_mainBuf.UseVisualStyleBackColor = true;
            this.btn_mainBuf.Click += new System.EventHandler(this.btn_mainBuf_Click);
            // 
            // btn_Readers
            // 
            this.btn_Readers.Enabled = false;
            this.btn_Readers.Image = ((System.Drawing.Image)(resources.GetObject("btn_Readers.Image")));
            this.btn_Readers.Location = new System.Drawing.Point(96, 446);
            this.btn_Readers.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Readers.Name = "btn_Readers";
            this.btn_Readers.Size = new System.Drawing.Size(62, 51);
            this.btn_Readers.TabIndex = 2;
            this.btn_Readers.UseVisualStyleBackColor = true;
            this.btn_Readers.Click += new System.EventHandler(this.btn_Readers_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(152, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "Buffer Size";
            // 
            // buf_size
            // 
            this.buf_size.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buf_size.Location = new System.Drawing.Point(157, 64);
            this.buf_size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.buf_size.Name = "buf_size";
            this.buf_size.Size = new System.Drawing.Size(132, 26);
            this.buf_size.TabIndex = 9;
            this.buf_size.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // main_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 506);
            this.Controls.Add(this.buf_size);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_Readers);
            this.Controls.Add(this.btn_mainBuf);
            this.Controls.Add(this.btn_Writers);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btn_Run);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WriterTB);
            this.Controls.Add(this.mainTB);
            this.Controls.Add(this.ReaderTB);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "main_frm";
            this.Text = "Task1";
            ((System.ComponentModel.ISupportInitialize)(this.buf_size)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ReaderTB;
        private System.Windows.Forms.TextBox mainTB;
        private System.Windows.Forms.TextBox WriterTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Run;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Button btn_Writers;
        private System.Windows.Forms.Button btn_mainBuf;
        private System.Windows.Forms.Button btn_Readers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown buf_size;
    }
}

