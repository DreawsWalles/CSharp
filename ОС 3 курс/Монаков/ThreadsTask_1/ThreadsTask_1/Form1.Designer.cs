namespace ThreadsTask_1
{
    partial class Form1
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
            this.txtBoxReader = new System.Windows.Forms.TextBox();
            this.txtBoxBuffer = new System.Windows.Forms.TextBox();
            this.txtBoxWriter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnStopRunReaders = new System.Windows.Forms.Button();
            this.btnStopRunWriters = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBoxReader
            // 
            this.txtBoxReader.Location = new System.Drawing.Point(16, 108);
            this.txtBoxReader.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxReader.Multiline = true;
            this.txtBoxReader.Name = "txtBoxReader";
            this.txtBoxReader.ReadOnly = true;
            this.txtBoxReader.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxReader.Size = new System.Drawing.Size(235, 291);
            this.txtBoxReader.TabIndex = 0;
            this.txtBoxReader.TextChanged += new System.EventHandler(this.txtBoxBuffer_TextChanged);
            // 
            // txtBoxBuffer
            // 
            this.txtBoxBuffer.Location = new System.Drawing.Point(259, 109);
            this.txtBoxBuffer.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxBuffer.Multiline = true;
            this.txtBoxBuffer.Name = "txtBoxBuffer";
            this.txtBoxBuffer.ReadOnly = true;
            this.txtBoxBuffer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxBuffer.Size = new System.Drawing.Size(260, 291);
            this.txtBoxBuffer.TabIndex = 1;
            this.txtBoxBuffer.TextChanged += new System.EventHandler(this.txtBoxBuffer_TextChanged);
            // 
            // txtBoxWriter
            // 
            this.txtBoxWriter.Location = new System.Drawing.Point(527, 108);
            this.txtBoxWriter.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxWriter.Multiline = true;
            this.txtBoxWriter.Name = "txtBoxWriter";
            this.txtBoxWriter.ReadOnly = true;
            this.txtBoxWriter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxWriter.Size = new System.Drawing.Size(235, 291);
            this.txtBoxWriter.TabIndex = 2;
            this.txtBoxWriter.TextChanged += new System.EventHandler(this.txtBoxBuffer_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(63, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Читатели";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(336, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Буфер";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(588, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Писатели";
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(259, 430);
            this.btn.Margin = new System.Windows.Forms.Padding(4);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(100, 28);
            this.btn.TabIndex = 6;
            this.btn.Text = "Run";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Enabled = false;
            this.btnAbort.Location = new System.Drawing.Point(403, 430);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(100, 28);
            this.btnAbort.TabIndex = 7;
            this.btnAbort.Text = "Abort";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnStopRunReaders
            // 
            this.btnStopRunReaders.Enabled = false;
            this.btnStopRunReaders.Location = new System.Drawing.Point(32, 430);
            this.btnStopRunReaders.Margin = new System.Windows.Forms.Padding(4);
            this.btnStopRunReaders.Name = "btnStopRunReaders";
            this.btnStopRunReaders.Size = new System.Drawing.Size(154, 28);
            this.btnStopRunReaders.TabIndex = 8;
            this.btnStopRunReaders.Text = "Stop-Run Readers";
            this.btnStopRunReaders.UseVisualStyleBackColor = true;
            this.btnStopRunReaders.Click += new System.EventHandler(this.btnStopRunReaders_Click);
            // 
            // btnStopRunWriters
            // 
            this.btnStopRunWriters.Enabled = false;
            this.btnStopRunWriters.Location = new System.Drawing.Point(556, 430);
            this.btnStopRunWriters.Margin = new System.Windows.Forms.Padding(4);
            this.btnStopRunWriters.Name = "btnStopRunWriters";
            this.btnStopRunWriters.Size = new System.Drawing.Size(154, 28);
            this.btnStopRunWriters.TabIndex = 9;
            this.btnStopRunWriters.Text = "Stop-Run Writers";
            this.btnStopRunWriters.UseVisualStyleBackColor = true;
            this.btnStopRunWriters.Click += new System.EventHandler(this.btnStopRunWriters_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 485);
            this.Controls.Add(this.btnStopRunWriters);
            this.Controls.Add(this.btnStopRunReaders);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxWriter);
            this.Controls.Add(this.txtBoxBuffer);
            this.Controls.Add(this.txtBoxReader);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxReader;
        private System.Windows.Forms.TextBox txtBoxBuffer;
        private System.Windows.Forms.TextBox txtBoxWriter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Button btnStopRunReaders;
        private System.Windows.Forms.Button btnStopRunWriters;
    }
}

