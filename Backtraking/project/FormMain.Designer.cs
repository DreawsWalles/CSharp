namespace project
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_add = new System.Windows.Forms.Button();
            this.button_random = new System.Windows.Forms.Button();
            this.button_task = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Location = new System.Drawing.Point(22, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(715, 169);
            this.panel1.TabIndex = 0;
            // 
            // button_add
            // 
            this.button_add.BackColor = System.Drawing.Color.White;
            this.button_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_add.FlatAppearance.BorderSize = 0;
            this.button_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_add.Location = new System.Drawing.Point(704, 204);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(33, 33);
            this.button_add.TabIndex = 1;
            this.button_add.UseVisualStyleBackColor = false;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            this.button_add.MouseEnter += new System.EventHandler(this.button_add_MouseEnter);
            this.button_add.MouseLeave += new System.EventHandler(this.button_add_MouseLeave);
            // 
            // button_random
            // 
            this.button_random.BackColor = System.Drawing.Color.White;
            this.button_random.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_random.FlatAppearance.BorderSize = 0;
            this.button_random.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_random.Location = new System.Drawing.Point(665, 204);
            this.button_random.Name = "button_random";
            this.button_random.Size = new System.Drawing.Size(33, 33);
            this.button_random.TabIndex = 2;
            this.button_random.UseVisualStyleBackColor = false;
            this.button_random.Click += new System.EventHandler(this.button_random_Click);
            this.button_random.MouseEnter += new System.EventHandler(this.button_random_MouseEnter);
            this.button_random.MouseLeave += new System.EventHandler(this.button_random_MouseLeave);
            // 
            // button_task
            // 
            this.button_task.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_task.FlatAppearance.BorderSize = 0;
            this.button_task.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_task.Location = new System.Drawing.Point(596, 209);
            this.button_task.Name = "button_task";
            this.button_task.Size = new System.Drawing.Size(54, 33);
            this.button_task.TabIndex = 3;
            this.button_task.UseVisualStyleBackColor = true;
            this.button_task.Click += new System.EventHandler(this.button_task_Click);
            this.button_task.MouseEnter += new System.EventHandler(this.button_task_MouseEnter);
            this.button_task.MouseLeave += new System.EventHandler(this.button_task_MouseLeave);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(763, 254);
            this.Controls.Add(this.button_task);
            this.Controls.Add(this.button_random);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.panel1);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_random;
        private System.Windows.Forms.Button button_task;
    }
}

