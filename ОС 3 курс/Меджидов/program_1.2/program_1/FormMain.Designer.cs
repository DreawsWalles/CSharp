namespace program_1
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.TbStack = new System.Windows.Forms.TextBox();
            this.TbInfo = new System.Windows.Forms.TextBox();
            this.BttStart = new System.Windows.Forms.Button();
            this.BttStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TbStack
            // 
            this.TbStack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TbStack.Location = new System.Drawing.Point(12, 12);
            this.TbStack.Multiline = true;
            this.TbStack.Name = "TbStack";
            this.TbStack.ReadOnly = true;
            this.TbStack.Size = new System.Drawing.Size(100, 287);
            this.TbStack.TabIndex = 0;
            this.TbStack.TabStop = false;
            // 
            // TbInfo
            // 
            this.TbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbInfo.Location = new System.Drawing.Point(118, 12);
            this.TbInfo.Multiline = true;
            this.TbInfo.Name = "TbInfo";
            this.TbInfo.ReadOnly = true;
            this.TbInfo.Size = new System.Drawing.Size(454, 287);
            this.TbInfo.TabIndex = 1;
            this.TbInfo.TabStop = false;
            // 
            // BttStart
            // 
            this.BttStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BttStart.BackgroundImage = global::program_1.Properties.Resources.start4;
            this.BttStart.Location = new System.Drawing.Point(12, 305);
            this.BttStart.Name = "BttStart";
            this.BttStart.Size = new System.Drawing.Size(100, 23);
            this.BttStart.TabIndex = 2;
            this.BttStart.Text = "     Старт";
            this.BttStart.UseVisualStyleBackColor = true;
            this.BttStart.Click += new System.EventHandler(this.BttStart_Click);
            // 
            // BttStop
            // 
            this.BttStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BttStop.BackgroundImage = global::program_1.Properties.Resources.stop1;
            this.BttStop.Location = new System.Drawing.Point(118, 305);
            this.BttStop.Name = "BttStop";
            this.BttStop.Size = new System.Drawing.Size(100, 23);
            this.BttStop.TabIndex = 3;
            this.BttStop.Text = "     Стоп";
            this.BttStop.UseVisualStyleBackColor = true;
            this.BttStop.Click += new System.EventHandler(this.BttStop_Click);
            // 
            // FormMain
            // 
            this.AcceptButton = this.BttStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(584, 336);
            this.Controls.Add(this.BttStop);
            this.Controls.Add(this.BttStart);
            this.Controls.Add(this.TbInfo);
            this.Controls.Add(this.TbStack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(245, 110);
            this.Name = "FormMain";
            this.Text = "1 - 1 - 3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbStack;
        private System.Windows.Forms.TextBox TbInfo;
        private System.Windows.Forms.Button BttStart;
        private System.Windows.Forms.Button BttStop;
    }
}

