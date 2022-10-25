namespace Task2_ex7
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
            this.fileBrowerFirst = new System.Windows.Forms.FolderBrowserDialog();
            this.fileBrowerSecond = new System.Windows.Forms.FolderBrowserDialog();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuFirstSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSecondSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFullResults = new System.Windows.Forms.ToolStripMenuItem();
            this.tbFirstPath = new System.Windows.Forms.TextBox();
            this.tbSecondPath = new System.Windows.Forms.TextBox();
            this.lblFirstD = new System.Windows.Forms.Label();
            this.lblSecondD = new System.Windows.Forms.Label();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFirstSelect,
            this.menuSecondSelect,
            this.menuFullResults});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(629, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "mainMenu";
            // 
            // menuFirstSelect
            // 
            this.menuFirstSelect.Name = "menuFirstSelect";
            this.menuFirstSelect.Size = new System.Drawing.Size(156, 20);
            this.menuFirstSelect.Text = "Выбрать первый каталог";
            this.menuFirstSelect.Click += new System.EventHandler(this.selectFirstDirectoryToolStripMenuItem_Click);
            // 
            // menuSecondSelect
            // 
            this.menuSecondSelect.Name = "menuSecondSelect";
            this.menuSecondSelect.Size = new System.Drawing.Size(153, 20);
            this.menuSecondSelect.Text = "Выбрать второй каталог";
            this.menuSecondSelect.Click += new System.EventHandler(this.selectSecondDirectoryToolStripMenuItem_Click);
            // 
            // menuFullResults
            // 
            this.menuFullResults.Enabled = false;
            this.menuFullResults.Name = "menuFullResults";
            this.menuFullResults.Size = new System.Drawing.Size(127, 20);
            this.menuFullResults.Text = "Выполнить задание";
            this.menuFullResults.Click += new System.EventHandler(this.mainMenuFullResults_Click);
            // 
            // tbFirstPath
            // 
            this.tbFirstPath.Location = new System.Drawing.Point(12, 56);
            this.tbFirstPath.Name = "tbFirstPath";
            this.tbFirstPath.ReadOnly = true;
            this.tbFirstPath.Size = new System.Drawing.Size(298, 20);
            this.tbFirstPath.TabIndex = 3;
            // 
            // tbSecondPath
            // 
            this.tbSecondPath.Location = new System.Drawing.Point(316, 56);
            this.tbSecondPath.Name = "tbSecondPath";
            this.tbSecondPath.ReadOnly = true;
            this.tbSecondPath.Size = new System.Drawing.Size(298, 20);
            this.tbSecondPath.TabIndex = 4;
            // 
            // lblFirstD
            // 
            this.lblFirstD.AutoSize = true;
            this.lblFirstD.Location = new System.Drawing.Point(12, 40);
            this.lblFirstD.Name = "lblFirstD";
            this.lblFirstD.Size = new System.Drawing.Size(90, 13);
            this.lblFirstD.TabIndex = 5;
            this.lblFirstD.Text = "Первый каталог";
            // 
            // lblSecondD
            // 
            this.lblSecondD.AutoSize = true;
            this.lblSecondD.Location = new System.Drawing.Point(316, 39);
            this.lblSecondD.Name = "lblSecondD";
            this.lblSecondD.Size = new System.Drawing.Size(86, 13);
            this.lblSecondD.TabIndex = 6;
            this.lblSecondD.Text = "Второй каталог";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 93);
            this.Controls.Add(this.lblSecondD);
            this.Controls.Add(this.lblFirstD);
            this.Controls.Add(this.tbSecondPath);
            this.Controls.Add(this.tbFirstPath);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(645, 132);
            this.MinimumSize = new System.Drawing.Size(645, 132);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fileBrowerFirst;
        private System.Windows.Forms.FolderBrowserDialog fileBrowerSecond;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuFirstSelect;
        private System.Windows.Forms.ToolStripMenuItem menuSecondSelect;
        private System.Windows.Forms.TextBox tbFirstPath;
        private System.Windows.Forms.TextBox tbSecondPath;
        private System.Windows.Forms.ToolStripMenuItem menuFullResults;
        private System.Windows.Forms.Label lblFirstD;
        private System.Windows.Forms.Label lblSecondD;
    }
}

