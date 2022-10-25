namespace Task_3
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
            this.buttonTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 176);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(373, 134);
            this.txtDescription.TabIndex = 0;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(155, 318);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(81, 23);
            this.btnGet.TabIndex = 1;
            this.btnGet.Text = "Snapshot";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // treeViewModules
            // 
            this.treeViewModules.Location = new System.Drawing.Point(12, 28);
            this.treeViewModules.Name = "treeViewModules";
            this.treeViewModules.Size = new System.Drawing.Size(373, 142);
            this.treeViewModules.TabIndex = 2;
            this.treeViewModules.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewModules_NodeMouseClick);
            // 
            // buttonTask
            // 
            this.buttonTask.Location = new System.Drawing.Point(372, -1);
            this.buttonTask.Name = "buttonTask";
            this.buttonTask.Size = new System.Drawing.Size(25, 23);
            this.buttonTask.TabIndex = 3;
            this.buttonTask.Text = "?";
            this.buttonTask.UseVisualStyleBackColor = true;
            this.buttonTask.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 353);
            this.Controls.Add(this.buttonTask);
            this.Controls.Add(this.treeViewModules);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.txtDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Task 3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.TreeView treeViewModules;
        private System.Windows.Forms.Button buttonTask;
    }
}

