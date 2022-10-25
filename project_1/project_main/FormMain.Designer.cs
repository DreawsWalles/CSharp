namespace project_main
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnTaskOne = new System.Windows.Forms.Button();
            this.btnTaskTwo = new System.Windows.Forms.Button();
            this.btnTaskThree = new System.Windows.Forms.Button();
            this.btnTaskFour = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnTaskOne, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnTaskTwo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnTaskThree, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnTaskFour, 0, 4);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(799, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnTaskOne
            // 
            this.btnTaskOne.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTaskOne.Location = new System.Drawing.Point(299, 96);
            this.btnTaskOne.Name = "btnTaskOne";
            this.btnTaskOne.Size = new System.Drawing.Size(201, 32);
            this.btnTaskOne.TabIndex = 0;
            this.btnTaskOne.Text = "Задача №1";
            this.btnTaskOne.UseVisualStyleBackColor = true;
            this.btnTaskOne.Click += new System.EventHandler(this.btnTaskOne_Click);
            // 
            // btnTaskTwo
            // 
            this.btnTaskTwo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTaskTwo.Location = new System.Drawing.Point(299, 171);
            this.btnTaskTwo.Name = "btnTaskTwo";
            this.btnTaskTwo.Size = new System.Drawing.Size(201, 32);
            this.btnTaskTwo.TabIndex = 1;
            this.btnTaskTwo.Text = "Задача №2";
            this.btnTaskTwo.UseVisualStyleBackColor = true;
            this.btnTaskTwo.Click += new System.EventHandler(this.btnTaskTwo_Click);
            // 
            // btnTaskThree
            // 
            this.btnTaskThree.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTaskThree.Location = new System.Drawing.Point(299, 246);
            this.btnTaskThree.Name = "btnTaskThree";
            this.btnTaskThree.Size = new System.Drawing.Size(201, 32);
            this.btnTaskThree.TabIndex = 2;
            this.btnTaskThree.Text = "Задача №3";
            this.btnTaskThree.UseVisualStyleBackColor = true;
            this.btnTaskThree.Click += new System.EventHandler(this.btnTaskThree_Click);
            // 
            // btnTaskFour
            // 
            this.btnTaskFour.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTaskFour.Location = new System.Drawing.Point(299, 321);
            this.btnTaskFour.Name = "btnTaskFour";
            this.btnTaskFour.Size = new System.Drawing.Size(201, 32);
            this.btnTaskFour.TabIndex = 3;
            this.btnTaskFour.Text = "Задача №4";
            this.btnTaskFour.UseVisualStyleBackColor = true;
            this.btnTaskFour.Click += new System.EventHandler(this.btnTaskFour_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormMain";
            this.Text = "Выбор задания";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnTaskOne;
        private System.Windows.Forms.Button btnTaskTwo;
        private System.Windows.Forms.Button btnTaskThree;
        private System.Windows.Forms.Button btnTaskFour;
    }
}

