namespace n1
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
            this.ReaderTextBox = new System.Windows.Forms.TextBox();
            this.BufferTextBox = new System.Windows.Forms.TextBox();
            this.WritersTextBox = new System.Windows.Forms.TextBox();
            this.ReaderLabel = new System.Windows.Forms.Label();
            this.BufferLabel = new System.Windows.Forms.Label();
            this.WriterLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReaderTextBox
            // 
            this.ReaderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReaderTextBox.Location = new System.Drawing.Point(12, 71);
            this.ReaderTextBox.Multiline = true;
            this.ReaderTextBox.Name = "ReaderTextBox";
            this.ReaderTextBox.ReadOnly = true;
            this.ReaderTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ReaderTextBox.Size = new System.Drawing.Size(201, 344);
            this.ReaderTextBox.TabIndex = 0;
            // 
            // BufferTextBox
            // 
            this.BufferTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BufferTextBox.Location = new System.Drawing.Point(219, 71);
            this.BufferTextBox.Multiline = true;
            this.BufferTextBox.Name = "BufferTextBox";
            this.BufferTextBox.ReadOnly = true;
            this.BufferTextBox.Size = new System.Drawing.Size(201, 344);
            this.BufferTextBox.TabIndex = 3;
            // 
            // WritersTextBox
            // 
            this.WritersTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WritersTextBox.Location = new System.Drawing.Point(426, 71);
            this.WritersTextBox.Multiline = true;
            this.WritersTextBox.Name = "WritersTextBox";
            this.WritersTextBox.ReadOnly = true;
            this.WritersTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.WritersTextBox.Size = new System.Drawing.Size(201, 344);
            this.WritersTextBox.TabIndex = 4;
            // 
            // ReaderLabel
            // 
            this.ReaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReaderLabel.AutoSize = true;
            this.ReaderLabel.Location = new System.Drawing.Point(78, 55);
            this.ReaderLabel.Name = "ReaderLabel";
            this.ReaderLabel.Size = new System.Drawing.Size(58, 13);
            this.ReaderLabel.TabIndex = 5;
            this.ReaderLabel.Text = "Читатель:";
            // 
            // BufferLabel
            // 
            this.BufferLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BufferLabel.AutoSize = true;
            this.BufferLabel.Location = new System.Drawing.Point(294, 55);
            this.BufferLabel.Name = "BufferLabel";
            this.BufferLabel.Size = new System.Drawing.Size(42, 13);
            this.BufferLabel.TabIndex = 6;
            this.BufferLabel.Text = "Буфер:";
            // 
            // WriterLabel
            // 
            this.WriterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WriterLabel.AutoSize = true;
            this.WriterLabel.Location = new System.Drawing.Point(499, 55);
            this.WriterLabel.Name = "WriterLabel";
            this.WriterLabel.Size = new System.Drawing.Size(59, 13);
            this.WriterLabel.TabIndex = 7;
            this.WriterLabel.Text = "Писатель:";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(12, 12);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(201, 36);
            this.StartButton.TabIndex = 8;
            this.StartButton.Text = "Старт";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.Enabled = false;
            this.PauseButton.Location = new System.Drawing.Point(219, 12);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(201, 36);
            this.PauseButton.TabIndex = 9;
            this.PauseButton.Text = "Пауза";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(426, 12);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(201, 36);
            this.StopButton.TabIndex = 10;
            this.StopButton.Text = "Стоп";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 427);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.WriterLabel);
            this.Controls.Add(this.BufferLabel);
            this.Controls.Add(this.ReaderLabel);
            this.Controls.Add(this.WritersTextBox);
            this.Controls.Add(this.BufferTextBox);
            this.Controls.Add(this.ReaderTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Task #1   2.3.2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ReaderTextBox;
        private System.Windows.Forms.TextBox BufferTextBox;
        private System.Windows.Forms.TextBox WritersTextBox;
        private System.Windows.Forms.Label ReaderLabel;
        private System.Windows.Forms.Label BufferLabel;
        private System.Windows.Forms.Label WriterLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button StopButton;
    }
}

