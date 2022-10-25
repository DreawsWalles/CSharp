namespace ThreadPriority
{
    partial class Form1
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
            this.textBoxOrig = new System.Windows.Forms.TextBox();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonMakeTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxOrig
            // 
            this.textBoxOrig.Location = new System.Drawing.Point(9, 40);
            this.textBoxOrig.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxOrig.Multiline = true;
            this.textBoxOrig.Name = "textBoxOrig";
            this.textBoxOrig.ReadOnly = true;
            this.textBoxOrig.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOrig.Size = new System.Drawing.Size(270, 265);
            this.textBoxOrig.TabIndex = 1;
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(293, 40);
            this.textBoxResult.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ReadOnly = true;
            this.textBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResult.Size = new System.Drawing.Size(270, 265);
            this.textBoxResult.TabIndex = 1;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(116, 333);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(162, 29);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Подгрузить процессы";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonMakeTask
            // 
            this.buttonMakeTask.Location = new System.Drawing.Point(293, 333);
            this.buttonMakeTask.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonMakeTask.Name = "buttonMakeTask";
            this.buttonMakeTask.Size = new System.Drawing.Size(157, 29);
            this.buttonMakeTask.TabIndex = 3;
            this.buttonMakeTask.Text = "Выполнить задание";
            this.buttonMakeTask.UseVisualStyleBackColor = true;
            this.buttonMakeTask.Click += new System.EventHandler(this.buttonMakeTask_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 411);
            this.Controls.Add(this.buttonMakeTask);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.textBoxOrig);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "FormPriority";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxOrig;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonMakeTask;
    }
}

