using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WriterAndReaders
{
    partial class FormMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnStopRunReaders = new System.Windows.Forms.Button();
            this.btnStopRunWriters = new System.Windows.Forms.Button();
            this.txtBoxWriter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBoxReader
            // 
            this.txtBoxReader.Location = new System.Drawing.Point(24, 32);
            this.txtBoxReader.Multiline = true;
            this.txtBoxReader.Name = "txtBoxReader";
            this.txtBoxReader.ReadOnly = true;
            this.txtBoxReader.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxReader.Size = new System.Drawing.Size(242, 237);
            this.txtBoxReader.TabIndex = 0;
            this.txtBoxReader.TextChanged += new System.EventHandler(this.txtBoxBuffer_TextChanged);
            // 
            // txtBoxBuffer
            // 
            this.txtBoxBuffer.Location = new System.Drawing.Point(272, 32);
            this.txtBoxBuffer.Multiline = true;
            this.txtBoxBuffer.Name = "txtBoxBuffer";
            this.txtBoxBuffer.ReadOnly = true;
            this.txtBoxBuffer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxBuffer.Size = new System.Drawing.Size(236, 237);
            this.txtBoxBuffer.TabIndex = 1;
            this.txtBoxBuffer.TextChanged += new System.EventHandler(this.txtBoxBuffer_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(83, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Readers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(325, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Buffer > Reader";
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(294, 275);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(75, 23);
            this.btn.TabIndex = 6;
            this.btn.Text = "Run";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Enabled = false;
            this.btnAbort.Location = new System.Drawing.Point(412, 275);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(75, 23);
            this.btnAbort.TabIndex = 7;
            this.btnAbort.Text = "Abort";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnStopRunReaders
            // 
            this.btnStopRunReaders.Enabled = false;
            this.btnStopRunReaders.Location = new System.Drawing.Point(87, 275);
            this.btnStopRunReaders.Name = "btnStopRunReaders";
            this.btnStopRunReaders.Size = new System.Drawing.Size(116, 23);
            this.btnStopRunReaders.TabIndex = 8;
            this.btnStopRunReaders.Text = "Stop Readers";
            this.btnStopRunReaders.UseVisualStyleBackColor = true;
            this.btnStopRunReaders.Click += new System.EventHandler(this.btnStopRunReaders_Click);
            // 
            // btnStopRunWriters
            // 
            this.btnStopRunWriters.Enabled = false;
            this.btnStopRunWriters.Location = new System.Drawing.Point(566, 275);
            this.btnStopRunWriters.Name = "btnStopRunWriters";
            this.btnStopRunWriters.Size = new System.Drawing.Size(116, 23);
            this.btnStopRunWriters.TabIndex = 9;
            this.btnStopRunWriters.Text = "Stop Writer";
            this.btnStopRunWriters.UseVisualStyleBackColor = true;
            this.btnStopRunWriters.Click += new System.EventHandler(this.btnStopRunWriters_Click);
            // 
            // txtBoxWriter
            // 
            this.txtBoxWriter.Location = new System.Drawing.Point(514, 32);
            this.txtBoxWriter.Multiline = true;
            this.txtBoxWriter.Name = "txtBoxWriter";
            this.txtBoxWriter.ReadOnly = true;
            this.txtBoxWriter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxWriter.Size = new System.Drawing.Size(223, 237);
            this.txtBoxWriter.TabIndex = 2;
            this.txtBoxWriter.TextChanged += new System.EventHandler(this.txtBoxBuffer_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(562, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Writer > Buffer";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 311);
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
            this.Name = "FormMain";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtBoxReader;
        private TextBox txtBoxBuffer;
        private Label label1;
        private Label label2;
        private Button btn;
        private Button btnAbort;
        private Button btnStopRunReaders;
        private Button btnStopRunWriters;
        private TextBox txtBoxWriter;
        private Label label3;
    }
}

