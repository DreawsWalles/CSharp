namespace OS.Task3
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
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.treeViewModules = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMax_size = new System.Windows.Forms.TextBox();
            this.btnFaund = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(297, 55);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(267, 263);
            this.txtDescription.TabIndex = 0;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(206, 12);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(159, 23);
            this.btnGet.TabIndex = 1;
            this.btnGet.Text = "Снимок процессов";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // treeViewModules
            // 
            this.treeViewModules.Location = new System.Drawing.Point(12, 55);
            this.treeViewModules.Name = "treeViewModules";
            this.treeViewModules.Size = new System.Drawing.Size(279, 263);
            this.treeViewModules.TabIndex = 2;
            this.treeViewModules.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewModules_NodeMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Список процессов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Информация о процессе";
            // 
            // txtMax_size
            // 
            this.txtMax_size.Location = new System.Drawing.Point(680, 55);
            this.txtMax_size.Multiline = true;
            this.txtMax_size.Name = "txtMax_size";
            this.txtMax_size.ReadOnly = true;
            this.txtMax_size.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMax_size.Size = new System.Drawing.Size(267, 263);
            this.txtMax_size.TabIndex = 5;
            // 
            // btnFaund
            // 
            this.btnFaund.Location = new System.Drawing.Point(733, 12);
            this.btnFaund.Name = "btnFaund";
            this.btnFaund.Size = new System.Drawing.Size(159, 23);
            this.btnFaund.TabIndex = 6;
            this.btnFaund.Text = "Найти";
            this.btnFaund.UseVisualStyleBackColor = true;
            this.btnFaund.Click += new System.EventHandler(this.btnFaund_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 341);
            this.Controls.Add(this.btnFaund);
            this.Controls.Add(this.txtMax_size);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeViewModules);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.txtDescription);
            this.Name = "FormMain";
            this.Text = "OS 3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.TreeView treeViewModules;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMax_size;
        private System.Windows.Forms.Button btnFaund;
    }
}

