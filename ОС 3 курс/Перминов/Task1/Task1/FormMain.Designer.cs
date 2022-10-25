namespace Task1
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
            this.textBoxMain = new System.Windows.Forms.TextBox();
            this.textBoxWriters = new System.Windows.Forms.TextBox();
            this.textBoxReaders = new System.Windows.Forms.TextBox();
            this.labelThreadMain = new System.Windows.Forms.Label();
            this.labelThreadWriters = new System.Windows.Forms.Label();
            this.labelThreadReaders = new System.Windows.Forms.Label();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonWritersChangeState = new System.Windows.Forms.Button();
            this.buttonReadersChangeState = new System.Windows.Forms.Button();
            this.groupBoxChangeState = new System.Windows.Forms.GroupBox();
            this.groupBoxControl = new System.Windows.Forms.GroupBox();
            this.groupBoxClear = new System.Windows.Forms.GroupBox();
            this.buttonClearReaders = new System.Windows.Forms.Button();
            this.buttonClearWriters = new System.Windows.Forms.Button();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.buttonClearMain = new System.Windows.Forms.Button();
            this.groupBoxChangeState.SuspendLayout();
            this.groupBoxControl.SuspendLayout();
            this.groupBoxClear.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxMain
            // 
            this.textBoxMain.BackColor = System.Drawing.Color.White;
            this.textBoxMain.Location = new System.Drawing.Point(12, 29);
            this.textBoxMain.Multiline = true;
            this.textBoxMain.Name = "textBoxMain";
            this.textBoxMain.ReadOnly = true;
            this.textBoxMain.Size = new System.Drawing.Size(157, 366);
            this.textBoxMain.TabIndex = 0;
            this.textBoxMain.TextChanged += new System.EventHandler(this.textBoxMain_TextChanged);
            // 
            // textBoxWriters
            // 
            this.textBoxWriters.BackColor = System.Drawing.Color.White;
            this.textBoxWriters.Location = new System.Drawing.Point(175, 29);
            this.textBoxWriters.Multiline = true;
            this.textBoxWriters.Name = "textBoxWriters";
            this.textBoxWriters.ReadOnly = true;
            this.textBoxWriters.Size = new System.Drawing.Size(156, 173);
            this.textBoxWriters.TabIndex = 1;
            this.textBoxWriters.TextChanged += new System.EventHandler(this.textBoxWriters_TextChanged);
            // 
            // textBoxReaders
            // 
            this.textBoxReaders.BackColor = System.Drawing.Color.White;
            this.textBoxReaders.Location = new System.Drawing.Point(175, 222);
            this.textBoxReaders.Multiline = true;
            this.textBoxReaders.Name = "textBoxReaders";
            this.textBoxReaders.ReadOnly = true;
            this.textBoxReaders.Size = new System.Drawing.Size(156, 173);
            this.textBoxReaders.TabIndex = 2;
            this.textBoxReaders.TextChanged += new System.EventHandler(this.textBoxReaders_TextChanged);
            // 
            // labelThreadMain
            // 
            this.labelThreadMain.AutoSize = true;
            this.labelThreadMain.Location = new System.Drawing.Point(56, 13);
            this.labelThreadMain.Name = "labelThreadMain";
            this.labelThreadMain.Size = new System.Drawing.Size(67, 13);
            this.labelThreadMain.TabIndex = 3;
            this.labelThreadMain.Text = "Thread Main";
            // 
            // labelThreadWriters
            // 
            this.labelThreadWriters.AutoSize = true;
            this.labelThreadWriters.Location = new System.Drawing.Point(213, 13);
            this.labelThreadWriters.Name = "labelThreadWriters";
            this.labelThreadWriters.Size = new System.Drawing.Size(77, 13);
            this.labelThreadWriters.TabIndex = 4;
            this.labelThreadWriters.Text = "Thread Writers";
            // 
            // labelThreadReaders
            // 
            this.labelThreadReaders.AutoSize = true;
            this.labelThreadReaders.Location = new System.Drawing.Point(213, 206);
            this.labelThreadReaders.Name = "labelThreadReaders";
            this.labelThreadReaders.Size = new System.Drawing.Size(84, 13);
            this.labelThreadReaders.TabIndex = 5;
            this.labelThreadReaders.Text = "Thread Readers";
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(6, 19);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(76, 23);
            this.buttonRun.TabIndex = 6;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(6, 48);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(76, 23);
            this.buttonStop.TabIndex = 7;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonWritersChangeState
            // 
            this.buttonWritersChangeState.Location = new System.Drawing.Point(6, 19);
            this.buttonWritersChangeState.Name = "buttonWritersChangeState";
            this.buttonWritersChangeState.Size = new System.Drawing.Size(76, 23);
            this.buttonWritersChangeState.TabIndex = 8;
            this.buttonWritersChangeState.Text = "Writers";
            this.buttonWritersChangeState.UseVisualStyleBackColor = true;
            this.buttonWritersChangeState.Click += new System.EventHandler(this.buttonWritersChangeState_Click);
            // 
            // buttonReadersChangeState
            // 
            this.buttonReadersChangeState.Location = new System.Drawing.Point(6, 47);
            this.buttonReadersChangeState.Name = "buttonReadersChangeState";
            this.buttonReadersChangeState.Size = new System.Drawing.Size(76, 23);
            this.buttonReadersChangeState.TabIndex = 9;
            this.buttonReadersChangeState.Text = "Readers";
            this.buttonReadersChangeState.UseVisualStyleBackColor = true;
            this.buttonReadersChangeState.Click += new System.EventHandler(this.buttonReadersChangeState_Click);
            // 
            // groupBoxChangeState
            // 
            this.groupBoxChangeState.Controls.Add(this.buttonReadersChangeState);
            this.groupBoxChangeState.Controls.Add(this.buttonWritersChangeState);
            this.groupBoxChangeState.Location = new System.Drawing.Point(337, 126);
            this.groupBoxChangeState.Name = "groupBoxChangeState";
            this.groupBoxChangeState.Size = new System.Drawing.Size(88, 76);
            this.groupBoxChangeState.TabIndex = 10;
            this.groupBoxChangeState.TabStop = false;
            this.groupBoxChangeState.Text = "Change State";
            // 
            // groupBoxControl
            // 
            this.groupBoxControl.Controls.Add(this.buttonRun);
            this.groupBoxControl.Controls.Add(this.buttonStop);
            this.groupBoxControl.Location = new System.Drawing.Point(337, 29);
            this.groupBoxControl.Name = "groupBoxControl";
            this.groupBoxControl.Size = new System.Drawing.Size(88, 77);
            this.groupBoxControl.TabIndex = 10;
            this.groupBoxControl.TabStop = false;
            this.groupBoxControl.Text = "Control";
            // 
            // groupBoxClear
            // 
            this.groupBoxClear.Controls.Add(this.buttonClearAll);
            this.groupBoxClear.Controls.Add(this.buttonClearMain);
            this.groupBoxClear.Controls.Add(this.buttonClearReaders);
            this.groupBoxClear.Controls.Add(this.buttonClearWriters);
            this.groupBoxClear.Location = new System.Drawing.Point(337, 222);
            this.groupBoxClear.Name = "groupBoxClear";
            this.groupBoxClear.Size = new System.Drawing.Size(88, 135);
            this.groupBoxClear.TabIndex = 11;
            this.groupBoxClear.TabStop = false;
            this.groupBoxClear.Text = "Clear Output";
            // 
            // buttonClearReaders
            // 
            this.buttonClearReaders.Location = new System.Drawing.Point(6, 47);
            this.buttonClearReaders.Name = "buttonClearReaders";
            this.buttonClearReaders.Size = new System.Drawing.Size(76, 23);
            this.buttonClearReaders.TabIndex = 9;
            this.buttonClearReaders.Text = "Readers";
            this.buttonClearReaders.UseVisualStyleBackColor = true;
            this.buttonClearReaders.Click += new System.EventHandler(this.buttonClearReaders_Click);
            // 
            // buttonClearWriters
            // 
            this.buttonClearWriters.Location = new System.Drawing.Point(6, 19);
            this.buttonClearWriters.Name = "buttonClearWriters";
            this.buttonClearWriters.Size = new System.Drawing.Size(76, 23);
            this.buttonClearWriters.TabIndex = 8;
            this.buttonClearWriters.Text = "Writers";
            this.buttonClearWriters.UseVisualStyleBackColor = true;
            this.buttonClearWriters.Click += new System.EventHandler(this.buttonClearWriters_Click);
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Location = new System.Drawing.Point(6, 104);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(76, 23);
            this.buttonClearAll.TabIndex = 11;
            this.buttonClearAll.Text = "All";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // buttonClearMain
            // 
            this.buttonClearMain.Location = new System.Drawing.Point(6, 76);
            this.buttonClearMain.Name = "buttonClearMain";
            this.buttonClearMain.Size = new System.Drawing.Size(76, 23);
            this.buttonClearMain.TabIndex = 10;
            this.buttonClearMain.Text = "Main";
            this.buttonClearMain.UseVisualStyleBackColor = true;
            this.buttonClearMain.Click += new System.EventHandler(this.buttonClearMain_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 407);
            this.Controls.Add(this.groupBoxClear);
            this.Controls.Add(this.groupBoxControl);
            this.Controls.Add(this.groupBoxChangeState);
            this.Controls.Add(this.labelThreadReaders);
            this.Controls.Add(this.labelThreadWriters);
            this.Controls.Add(this.labelThreadMain);
            this.Controls.Add(this.textBoxReaders);
            this.Controls.Add(this.textBoxWriters);
            this.Controls.Add(this.textBoxMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Readers and Writers";
            this.groupBoxChangeState.ResumeLayout(false);
            this.groupBoxControl.ResumeLayout(false);
            this.groupBoxClear.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMain;
        private System.Windows.Forms.TextBox textBoxWriters;
        private System.Windows.Forms.TextBox textBoxReaders;
        private System.Windows.Forms.Label labelThreadMain;
        private System.Windows.Forms.Label labelThreadWriters;
        private System.Windows.Forms.Label labelThreadReaders;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonWritersChangeState;
        private System.Windows.Forms.Button buttonReadersChangeState;
        private System.Windows.Forms.GroupBox groupBoxChangeState;
        private System.Windows.Forms.GroupBox groupBoxControl;
        private System.Windows.Forms.GroupBox groupBoxClear;
        private System.Windows.Forms.Button buttonClearAll;
        private System.Windows.Forms.Button buttonClearMain;
        private System.Windows.Forms.Button buttonClearReaders;
        private System.Windows.Forms.Button buttonClearWriters;
    }
}

