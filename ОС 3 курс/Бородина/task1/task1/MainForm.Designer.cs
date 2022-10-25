namespace task1
{
    partial class MainForm
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
            this.writerTB = new System.Windows.Forms.TextBox();
            this.mainTB = new System.Windows.Forms.TextBox();
            this.readerTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnReaders = new System.Windows.Forms.Button();
            this.btnWriters = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // writerTB
            // 
            this.writerTB.Location = new System.Drawing.Point(451, 48);
            this.writerTB.Multiline = true;
            this.writerTB.Name = "writerTB";
            this.writerTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.writerTB.Size = new System.Drawing.Size(199, 279);
            this.writerTB.TabIndex = 1;
            // 
            // mainTB
            // 
            this.mainTB.Location = new System.Drawing.Point(232, 48);
            this.mainTB.Multiline = true;
            this.mainTB.Name = "mainTB";
            this.mainTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mainTB.Size = new System.Drawing.Size(199, 279);
            this.mainTB.TabIndex = 2;
            // 
            // readerTB
            // 
            this.readerTB.Location = new System.Drawing.Point(12, 48);
            this.readerTB.Multiline = true;
            this.readerTB.Name = "readerTB";
            this.readerTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.readerTB.Size = new System.Drawing.Size(199, 279);
            this.readerTB.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "READERS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "BUFFER";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(513, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "WRITERS";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(243, 342);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 7;
            this.btnRun.Text = "RUN";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnrun_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(340, 342);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnReaders
            // 
            this.btnReaders.Location = new System.Drawing.Point(61, 342);
            this.btnReaders.Name = "btnReaders";
            this.btnReaders.Size = new System.Drawing.Size(75, 23);
            this.btnReaders.TabIndex = 9;
            this.btnReaders.Text = "PAUSE";
            this.btnReaders.UseVisualStyleBackColor = true;
            this.btnReaders.Click += new System.EventHandler(this.btn_Readers_Click);
            // 
            // btnWriters
            // 
            this.btnWriters.Location = new System.Drawing.Point(516, 342);
            this.btnWriters.Name = "btnWriters";
            this.btnWriters.Size = new System.Drawing.Size(75, 23);
            this.btnWriters.TabIndex = 10;
            this.btnWriters.Text = "PAUSE";
            this.btnWriters.UseVisualStyleBackColor = true;
            this.btnWriters.Click += new System.EventHandler(this.btnWriters_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 377);
            this.Controls.Add(this.btnWriters);
            this.Controls.Add(this.btnReaders);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.readerTB);
            this.Controls.Add(this.mainTB);
            this.Controls.Add(this.writerTB);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox writerTB;
        private System.Windows.Forms.TextBox mainTB;
        private System.Windows.Forms.TextBox readerTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnReaders;
        private System.Windows.Forms.Button btnWriters;
    }
}

