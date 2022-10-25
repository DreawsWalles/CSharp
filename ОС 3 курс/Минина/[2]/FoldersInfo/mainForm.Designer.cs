namespace FoldersInfo
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
            this.tbFirstFolder = new System.Windows.Forms.TextBox();
            this.tbSecondFolder = new System.Windows.Forms.TextBox();
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.папкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выбратьПервуюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выбратьВторуюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.посчитатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbFirstFolder
            // 
            this.tbFirstFolder.Location = new System.Drawing.Point(12, 39);
            this.tbFirstFolder.Multiline = true;
            this.tbFirstFolder.Name = "tbFirstFolder";
            this.tbFirstFolder.ReadOnly = true;
            this.tbFirstFolder.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbFirstFolder.Size = new System.Drawing.Size(297, 400);
            this.tbFirstFolder.TabIndex = 3;
            // 
            // tbSecondFolder
            // 
            this.tbSecondFolder.Location = new System.Drawing.Point(327, 39);
            this.tbSecondFolder.Multiline = true;
            this.tbSecondFolder.Name = "tbSecondFolder";
            this.tbSecondFolder.ReadOnly = true;
            this.tbSecondFolder.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSecondFolder.Size = new System.Drawing.Size(297, 400);
            this.tbSecondFolder.TabIndex = 4;
            // 
            // mnsMain
            // 
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.папкаToolStripMenuItem,
            this.посчитатьToolStripMenuItem});
            this.mnsMain.Location = new System.Drawing.Point(0, 0);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Size = new System.Drawing.Size(638, 24);
            this.mnsMain.TabIndex = 5;
            // 
            // папкаToolStripMenuItem
            // 
            this.папкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выбратьПервуюToolStripMenuItem,
            this.выбратьВторуюToolStripMenuItem});
            this.папкаToolStripMenuItem.Name = "папкаToolStripMenuItem";
            this.папкаToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.папкаToolStripMenuItem.Text = "Папка";
            // 
            // выбратьПервуюToolStripMenuItem
            // 
            this.выбратьПервуюToolStripMenuItem.Name = "выбратьПервуюToolStripMenuItem";
            this.выбратьПервуюToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.выбратьПервуюToolStripMenuItem.Text = "Выбрать первую";
            this.выбратьПервуюToolStripMenuItem.Click += new System.EventHandler(this.выбратьПервуюToolStripMenuItem_Click);
            // 
            // выбратьВторуюToolStripMenuItem
            // 
            this.выбратьВторуюToolStripMenuItem.Name = "выбратьВторуюToolStripMenuItem";
            this.выбратьВторуюToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.выбратьВторуюToolStripMenuItem.Text = "Выбрать вторую";
            this.выбратьВторуюToolStripMenuItem.Click += new System.EventHandler(this.выбратьВторуюToolStripMenuItem_Click);
            // 
            // посчитатьToolStripMenuItem
            // 
            this.посчитатьToolStripMenuItem.Name = "посчитатьToolStripMenuItem";
            this.посчитатьToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.посчитатьToolStripMenuItem.Text = "Посчитать";
            this.посчитатьToolStripMenuItem.Click += new System.EventHandler(this.посчитатьToolStripMenuItem_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 451);
            this.Controls.Add(this.tbSecondFolder);
            this.Controls.Add(this.tbFirstFolder);
            this.Controls.Add(this.mnsMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.mnsMain;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сведения о файлах в папке";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbFirstFolder;
        private System.Windows.Forms.TextBox tbSecondFolder;
        private System.Windows.Forms.ToolStripMenuItem папкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem посчитатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выбратьПервуюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выбратьВторуюToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mnsMain;
    }
}

