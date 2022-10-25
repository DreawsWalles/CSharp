namespace Task3_ex17
{
    partial class Form_main
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
            this.components = new System.ComponentModel.Container();
            this.tb_all = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btn_execute = new System.Windows.Forms.Button();
            this.tb_res = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_showAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_all
            // 
            this.tb_all.Location = new System.Drawing.Point(12, 65);
            this.tb_all.Multiline = true;
            this.tb_all.Name = "tb_all";
            this.tb_all.ReadOnly = true;
            this.tb_all.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_all.Size = new System.Drawing.Size(325, 253);
            this.tb_all.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btn_execute
            // 
            this.btn_execute.Location = new System.Drawing.Point(343, 12);
            this.btn_execute.Name = "btn_execute";
            this.btn_execute.Size = new System.Drawing.Size(113, 27);
            this.btn_execute.TabIndex = 8;
            this.btn_execute.Text = "Выполнить";
            this.btn_execute.UseVisualStyleBackColor = true;
            this.btn_execute.Click += new System.EventHandler(this.btn_execute_Click);
            // 
            // tb_res
            // 
            this.tb_res.Location = new System.Drawing.Point(343, 65);
            this.tb_res.Multiline = true;
            this.tb_res.Name = "tb_res";
            this.tb_res.ReadOnly = true;
            this.tb_res.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_res.Size = new System.Drawing.Size(324, 253);
            this.tb_res.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Все процессы:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(340, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Требуемые процессы:";
            // 
            // btn_showAll
            // 
            this.btn_showAll.Location = new System.Drawing.Point(12, 12);
            this.btn_showAll.Name = "btn_showAll";
            this.btn_showAll.Size = new System.Drawing.Size(113, 27);
            this.btn_showAll.TabIndex = 15;
            this.btn_showAll.Text = "Показать";
            this.btn_showAll.UseVisualStyleBackColor = true;
            this.btn_showAll.Click += new System.EventHandler(this.btn_showAll_Click_1);
            // 
            // Form_main
            // 
            this.AcceptButton = this.btn_execute;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 328);
            this.Controls.Add(this.btn_showAll);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_res);
            this.Controls.Add(this.btn_execute);
            this.Controls.Add(this.tb_all);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_main";
            this.Text = "Требуемые процессы: ";
            this.Load += new System.EventHandler(this.Form_main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_all;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btn_execute;
        private System.Windows.Forms.TextBox tb_res;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_showAll;
    }
}

