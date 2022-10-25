namespace project
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.existsElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.converrtRealizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeMutableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currnet_list = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label_type = new System.Windows.Forms.Label();
            this.existsElementConditionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1904, 29);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.FileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FileToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(46, 25);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(132, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(132, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(132, 26);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createListToolStripMenuItem,
            this.closeListToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.cleanListToolStripMenuItem,
            this.addElementToolStripMenuItem,
            this.existsElementToolStripMenuItem,
            this.converrtRealizationToolStripMenuItem,
            this.convertTypeToolStripMenuItem,
            this.changeMutableToolStripMenuItem,
            this.existsElementConditionToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(70, 25);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // createListToolStripMenuItem
            // 
            this.createListToolStripMenuItem.Name = "createListToolStripMenuItem";
            this.createListToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.createListToolStripMenuItem.Text = "Create list";
            this.createListToolStripMenuItem.Click += new System.EventHandler(this.createListToolStripMenuItem_Click);
            // 
            // closeListToolStripMenuItem
            // 
            this.closeListToolStripMenuItem.Name = "closeListToolStripMenuItem";
            this.closeListToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.closeListToolStripMenuItem.Text = "Close list";
            this.closeListToolStripMenuItem.Click += new System.EventHandler(this.closeListToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.closeAllToolStripMenuItem.Text = "Close all";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // cleanListToolStripMenuItem
            // 
            this.cleanListToolStripMenuItem.Name = "cleanListToolStripMenuItem";
            this.cleanListToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.cleanListToolStripMenuItem.Text = "Clean list";
            this.cleanListToolStripMenuItem.Click += new System.EventHandler(this.cleanListToolStripMenuItem_Click);
            // 
            // addElementToolStripMenuItem
            // 
            this.addElementToolStripMenuItem.Name = "addElementToolStripMenuItem";
            this.addElementToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.addElementToolStripMenuItem.Text = "Add element";
            this.addElementToolStripMenuItem.Click += new System.EventHandler(this.addElementToolStripMenuItem_Click);
            // 
            // existsElementToolStripMenuItem
            // 
            this.existsElementToolStripMenuItem.Name = "existsElementToolStripMenuItem";
            this.existsElementToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.existsElementToolStripMenuItem.Text = "Exists element";
            this.existsElementToolStripMenuItem.Click += new System.EventHandler(this.existsElementToolStripMenuItem_Click);
            // 
            // converrtRealizationToolStripMenuItem
            // 
            this.converrtRealizationToolStripMenuItem.Name = "converrtRealizationToolStripMenuItem";
            this.converrtRealizationToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.converrtRealizationToolStripMenuItem.Text = "Convert realization";
            this.converrtRealizationToolStripMenuItem.Click += new System.EventHandler(this.converrtRealizationToolStripMenuItem_Click);
            // 
            // convertTypeToolStripMenuItem
            // 
            this.convertTypeToolStripMenuItem.Name = "convertTypeToolStripMenuItem";
            this.convertTypeToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.convertTypeToolStripMenuItem.Text = "Convert type";
            this.convertTypeToolStripMenuItem.Click += new System.EventHandler(this.convertTypeToolStripMenuItem_Click);
            // 
            // changeMutableToolStripMenuItem
            // 
            this.changeMutableToolStripMenuItem.Name = "changeMutableToolStripMenuItem";
            this.changeMutableToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.changeMutableToolStripMenuItem.Text = "Change mutable";
            this.changeMutableToolStripMenuItem.Click += new System.EventHandler(this.changeMutableToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutProgramToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutProgramToolStripMenuItem
            // 
            this.aboutProgramToolStripMenuItem.Name = "aboutProgramToolStripMenuItem";
            this.aboutProgramToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.aboutProgramToolStripMenuItem.Text = "About program";
            this.aboutProgramToolStripMenuItem.Click += new System.EventHandler(this.aboutProgramToolStripMenuItem_Click);
            // 
            // currnet_list
            // 
            this.currnet_list.BackColor = System.Drawing.Color.DarkViolet;
            this.currnet_list.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currnet_list.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.currnet_list.Location = new System.Drawing.Point(1814, 47);
            this.currnet_list.Name = "currnet_list";
            this.currnet_list.Size = new System.Drawing.Size(90, 30);
            this.currnet_list.TabIndex = 4;
            this.currnet_list.Text = "24242424";
            this.currnet_list.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(40, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1677, 29);
            this.panel1.TabIndex = 5;
            this.panel1.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.panel1_ControlAdded);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.menuStrip2);
            this.panel2.Location = new System.Drawing.Point(1881, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(23, 21);
            this.panel2.TabIndex = 8;
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip2.Size = new System.Drawing.Size(23, 25);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "▼\t";
            this.menuStrip2.Click += new System.EventHandler(this.menuStrip2_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.Snow;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(36, 25);
            this.toolStripMenuItem1.Text = "▼";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.DarkCyan;
            this.panel3.Location = new System.Drawing.Point(40, 82);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1677, 935);
            this.panel3.TabIndex = 9;
            // 
            // label_type
            // 
            this.label_type.AutoSize = true;
            this.label_type.BackColor = System.Drawing.Color.DarkViolet;
            this.label_type.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_type.ForeColor = System.Drawing.Color.White;
            this.label_type.Location = new System.Drawing.Point(1771, 5);
            this.label_type.Name = "label_type";
            this.label_type.Size = new System.Drawing.Size(50, 22);
            this.label_type.TabIndex = 11;
            this.label_type.Text = "type";
            // 
            // existsElementConditionToolStripMenuItem
            // 
            this.existsElementConditionToolStripMenuItem.Name = "existsElementConditionToolStripMenuItem";
            this.existsElementConditionToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
            this.existsElementConditionToolStripMenuItem.Text = "Find element condition";
            this.existsElementConditionToolStripMenuItem.Click += new System.EventHandler(this.existsElementConditionToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.label_type);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.currnet_list);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Program";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.FormMain_ControlAdded);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseClick);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cleanListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem existsElementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addElementToolStripMenuItem;
        public System.Windows.Forms.Label currnet_list;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeListToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label_type;
        private System.Windows.Forms.ToolStripMenuItem converrtRealizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeMutableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem existsElementConditionToolStripMenuItem;
    }
}