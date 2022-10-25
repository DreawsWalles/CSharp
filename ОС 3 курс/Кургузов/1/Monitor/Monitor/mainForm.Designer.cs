namespace Monitor
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
            this.nudBufferSize = new System.Windows.Forms.NumericUpDown();
            this.lblBufferSize = new System.Windows.Forms.Label();
            this.nudActionsNumber = new System.Windows.Forms.NumericUpDown();
            this.lblCountActions = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.nudThreadsNumber = new System.Windows.Forms.NumericUpDown();
            this.lblThreadsNumber = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tbReader = new System.Windows.Forms.TextBox();
            this.tbBuffer = new System.Windows.Forms.TextBox();
            this.tbWriter = new System.Windows.Forms.TextBox();
            this.lblReader = new System.Windows.Forms.Label();
            this.lblBuffer = new System.Windows.Forms.Label();
            this.lblWriter = new System.Windows.Forms.Label();
            this.pbBufferSizeCurrent = new System.Windows.Forms.ProgressBar();
            this.btnStartReader = new System.Windows.Forms.Button();
            this.btnStopReader = new System.Windows.Forms.Button();
            this.btnStartWriter = new System.Windows.Forms.Button();
            this.btnStopWriter = new System.Windows.Forms.Button();
            this.pbMaxBufferSize = new System.Windows.Forms.ProgressBar();
            this.lblIsBuzy = new System.Windows.Forms.Label();
            this.lblSizeMax = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblMaxBufferSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudBufferSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudActionsNumber)).BeginInit();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreadsNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // nudBufferSize
            // 
            this.nudBufferSize.Location = new System.Drawing.Point(20, 25);
            this.nudBufferSize.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudBufferSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBufferSize.Name = "nudBufferSize";
            this.nudBufferSize.Size = new System.Drawing.Size(54, 20);
            this.nudBufferSize.TabIndex = 0;
            this.nudBufferSize.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // lblBufferSize
            // 
            this.lblBufferSize.AutoSize = true;
            this.lblBufferSize.Location = new System.Drawing.Point(23, 9);
            this.lblBufferSize.Name = "lblBufferSize";
            this.lblBufferSize.Size = new System.Drawing.Size(46, 13);
            this.lblBufferSize.TabIndex = 1;
            this.lblBufferSize.Text = "Размер";
            // 
            // nudActionsNumber
            // 
            this.nudActionsNumber.Location = new System.Drawing.Point(81, 25);
            this.nudActionsNumber.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudActionsNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudActionsNumber.Name = "nudActionsNumber";
            this.nudActionsNumber.Size = new System.Drawing.Size(54, 20);
            this.nudActionsNumber.TabIndex = 2;
            this.nudActionsNumber.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblCountActions
            // 
            this.lblCountActions.AutoSize = true;
            this.lblCountActions.Location = new System.Drawing.Point(78, 9);
            this.lblCountActions.Name = "lblCountActions";
            this.lblCountActions.Size = new System.Drawing.Size(57, 13);
            this.lblCountActions.TabIndex = 3;
            this.lblCountActions.Text = "Действия";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(276, 17);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Создать";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // pnlSettings
            // 
            this.pnlSettings.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlSettings.Controls.Add(this.nudThreadsNumber);
            this.pnlSettings.Controls.Add(this.lblThreadsNumber);
            this.pnlSettings.Controls.Add(this.btnDelete);
            this.pnlSettings.Controls.Add(this.lblBufferSize);
            this.pnlSettings.Controls.Add(this.btnCreate);
            this.pnlSettings.Controls.Add(this.nudBufferSize);
            this.pnlSettings.Controls.Add(this.nudActionsNumber);
            this.pnlSettings.Controls.Add(this.lblCountActions);
            this.pnlSettings.Location = new System.Drawing.Point(12, 12);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(488, 56);
            this.pnlSettings.TabIndex = 5;
            // 
            // nudThreadsNumber
            // 
            this.nudThreadsNumber.Location = new System.Drawing.Point(144, 25);
            this.nudThreadsNumber.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudThreadsNumber.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudThreadsNumber.Name = "nudThreadsNumber";
            this.nudThreadsNumber.Size = new System.Drawing.Size(54, 20);
            this.nudThreadsNumber.TabIndex = 25;
            this.nudThreadsNumber.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblThreadsNumber
            // 
            this.lblThreadsNumber.AutoSize = true;
            this.lblThreadsNumber.Location = new System.Drawing.Point(149, 9);
            this.lblThreadsNumber.Name = "lblThreadsNumber";
            this.lblThreadsNumber.Size = new System.Drawing.Size(44, 13);
            this.lblThreadsNumber.TabIndex = 25;
            this.lblThreadsNumber.Text = "Потоки";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(391, 17);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tbReader
            // 
            this.tbReader.Location = new System.Drawing.Point(12, 90);
            this.tbReader.Multiline = true;
            this.tbReader.Name = "tbReader";
            this.tbReader.ReadOnly = true;
            this.tbReader.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbReader.Size = new System.Drawing.Size(149, 197);
            this.tbReader.TabIndex = 6;
            // 
            // tbBuffer
            // 
            this.tbBuffer.Location = new System.Drawing.Point(177, 90);
            this.tbBuffer.Multiline = true;
            this.tbBuffer.Name = "tbBuffer";
            this.tbBuffer.ReadOnly = true;
            this.tbBuffer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbBuffer.Size = new System.Drawing.Size(153, 197);
            this.tbBuffer.TabIndex = 7;
            // 
            // tbWriter
            // 
            this.tbWriter.Location = new System.Drawing.Point(347, 90);
            this.tbWriter.Multiline = true;
            this.tbWriter.Name = "tbWriter";
            this.tbWriter.ReadOnly = true;
            this.tbWriter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbWriter.Size = new System.Drawing.Size(153, 197);
            this.tbWriter.TabIndex = 8;
            // 
            // lblReader
            // 
            this.lblReader.AutoSize = true;
            this.lblReader.Location = new System.Drawing.Point(58, 71);
            this.lblReader.Name = "lblReader";
            this.lblReader.Size = new System.Drawing.Size(55, 13);
            this.lblReader.TabIndex = 9;
            this.lblReader.Text = "Читатели";
            // 
            // lblBuffer
            // 
            this.lblBuffer.AutoSize = true;
            this.lblBuffer.Location = new System.Drawing.Point(230, 71);
            this.lblBuffer.Name = "lblBuffer";
            this.lblBuffer.Size = new System.Drawing.Size(47, 13);
            this.lblBuffer.TabIndex = 10;
            this.lblBuffer.Text = "Буффер";
            // 
            // lblWriter
            // 
            this.lblWriter.AutoSize = true;
            this.lblWriter.Location = new System.Drawing.Point(397, 71);
            this.lblWriter.Name = "lblWriter";
            this.lblWriter.Size = new System.Drawing.Size(56, 13);
            this.lblWriter.TabIndex = 11;
            this.lblWriter.Text = "Писатели";
            // 
            // pbBufferSizeCurrent
            // 
            this.pbBufferSizeCurrent.Location = new System.Drawing.Point(177, 308);
            this.pbBufferSizeCurrent.Name = "pbBufferSizeCurrent";
            this.pbBufferSizeCurrent.Size = new System.Drawing.Size(153, 23);
            this.pbBufferSizeCurrent.TabIndex = 12;
            // 
            // btnStartReader
            // 
            this.btnStartReader.Location = new System.Drawing.Point(24, 308);
            this.btnStartReader.Name = "btnStartReader";
            this.btnStartReader.Size = new System.Drawing.Size(114, 23);
            this.btnStartReader.TabIndex = 13;
            this.btnStartReader.Text = "Старт";
            this.btnStartReader.UseVisualStyleBackColor = true;
            this.btnStartReader.Click += new System.EventHandler(this.btnStartReader_Click);
            // 
            // btnStopReader
            // 
            this.btnStopReader.Location = new System.Drawing.Point(24, 355);
            this.btnStopReader.Name = "btnStopReader";
            this.btnStopReader.Size = new System.Drawing.Size(114, 23);
            this.btnStopReader.TabIndex = 14;
            this.btnStopReader.Text = "Стоп";
            this.btnStopReader.UseVisualStyleBackColor = true;
            this.btnStopReader.Click += new System.EventHandler(this.btnStopReader_Click);
            // 
            // btnStartWriter
            // 
            this.btnStartWriter.Location = new System.Drawing.Point(364, 308);
            this.btnStartWriter.Name = "btnStartWriter";
            this.btnStartWriter.Size = new System.Drawing.Size(114, 23);
            this.btnStartWriter.TabIndex = 15;
            this.btnStartWriter.Text = "Старт";
            this.btnStartWriter.UseVisualStyleBackColor = true;
            this.btnStartWriter.Click += new System.EventHandler(this.btnStartWriter_Click);
            // 
            // btnStopWriter
            // 
            this.btnStopWriter.Location = new System.Drawing.Point(364, 355);
            this.btnStopWriter.Name = "btnStopWriter";
            this.btnStopWriter.Size = new System.Drawing.Size(114, 23);
            this.btnStopWriter.TabIndex = 16;
            this.btnStopWriter.Text = "Стоп";
            this.btnStopWriter.UseVisualStyleBackColor = true;
            this.btnStopWriter.Click += new System.EventHandler(this.btnStopWriter_Click);
            // 
            // pbMaxBufferSize
            // 
            this.pbMaxBufferSize.Location = new System.Drawing.Point(177, 355);
            this.pbMaxBufferSize.Maximum = 0;
            this.pbMaxBufferSize.Name = "pbMaxBufferSize";
            this.pbMaxBufferSize.Size = new System.Drawing.Size(153, 23);
            this.pbMaxBufferSize.TabIndex = 17;
            // 
            // lblIsBuzy
            // 
            this.lblIsBuzy.AutoSize = true;
            this.lblIsBuzy.Location = new System.Drawing.Point(174, 292);
            this.lblIsBuzy.Name = "lblIsBuzy";
            this.lblIsBuzy.Size = new System.Drawing.Size(65, 13);
            this.lblIsBuzy.TabIndex = 18;
            this.lblIsBuzy.Text = "Заполненo ";
            // 
            // lblSizeMax
            // 
            this.lblSizeMax.AutoSize = true;
            this.lblSizeMax.Location = new System.Drawing.Point(174, 339);
            this.lblSizeMax.Name = "lblSizeMax";
            this.lblSizeMax.Size = new System.Drawing.Size(46, 13);
            this.lblSizeMax.TabIndex = 19;
            this.lblSizeMax.Text = "Размер";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(117, 396);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 20;
            this.btnStart.Text = "Начать";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Location = new System.Drawing.Point(310, 396);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(75, 23);
            this.btnAbort.TabIndex = 21;
            this.btnAbort.Text = "Завершить";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(238, 292);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(13, 13);
            this.lblPercent.TabIndex = 22;
            this.lblPercent.Text = "0";
            // 
            // lblMaxBufferSize
            // 
            this.lblMaxBufferSize.AutoSize = true;
            this.lblMaxBufferSize.Location = new System.Drawing.Point(223, 339);
            this.lblMaxBufferSize.Name = "lblMaxBufferSize";
            this.lblMaxBufferSize.Size = new System.Drawing.Size(13, 13);
            this.lblMaxBufferSize.TabIndex = 23;
            this.lblMaxBufferSize.Text = "0";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 437);
            this.Controls.Add(this.lblMaxBufferSize);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblSizeMax);
            this.Controls.Add(this.lblIsBuzy);
            this.Controls.Add(this.pbMaxBufferSize);
            this.Controls.Add(this.btnStopWriter);
            this.Controls.Add(this.btnStartWriter);
            this.Controls.Add(this.btnStopReader);
            this.Controls.Add(this.btnStartReader);
            this.Controls.Add(this.pbBufferSizeCurrent);
            this.Controls.Add(this.lblWriter);
            this.Controls.Add(this.lblBuffer);
            this.Controls.Add(this.lblReader);
            this.Controls.Add(this.tbWriter);
            this.Controls.Add(this.tbBuffer);
            this.Controls.Add(this.tbReader);
            this.Controls.Add(this.pnlSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Синхронизация потоков с помощью Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudBufferSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudActionsNumber)).EndInit();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreadsNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudBufferSize;
        private System.Windows.Forms.Label lblBufferSize;
        private System.Windows.Forms.NumericUpDown nudActionsNumber;
        private System.Windows.Forms.Label lblCountActions;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.TextBox tbReader;
        private System.Windows.Forms.TextBox tbBuffer;
        private System.Windows.Forms.TextBox tbWriter;
        private System.Windows.Forms.Label lblReader;
        private System.Windows.Forms.Label lblBuffer;
        private System.Windows.Forms.Label lblWriter;
        private System.Windows.Forms.ProgressBar pbBufferSizeCurrent;
        private System.Windows.Forms.Button btnStartReader;
        private System.Windows.Forms.Button btnStopReader;
        private System.Windows.Forms.Button btnStartWriter;
        private System.Windows.Forms.Button btnStopWriter;
        private System.Windows.Forms.ProgressBar pbMaxBufferSize;
        private System.Windows.Forms.Label lblIsBuzy;
        private System.Windows.Forms.Label lblSizeMax;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Label lblMaxBufferSize;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblThreadsNumber;
        private System.Windows.Forms.NumericUpDown nudThreadsNumber;
    }
}

