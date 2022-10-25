namespace task3
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
            this.btnResult = new System.Windows.Forms.Button();
            this.btnShapshot = new System.Windows.Forms.Button();
            this.listBoxResult = new System.Windows.Forms.ListBox();
            this.tbCurrentItem = new System.Windows.Forms.TextBox();
            this.lbCurrentItem = new System.Windows.Forms.Label();
            this.treeViewProcesses = new System.Windows.Forms.TreeView();
            this.lbResult = new System.Windows.Forms.Label();
            this.lbProcesses = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnConditionTask = new System.Windows.Forms.Button();
            this.folderBrowserDialog10 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog11 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // btnResult
            // 
            this.btnResult.Location = new System.Drawing.Point(699, 98);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(103, 38);
            this.btnResult.TabIndex = 21;
            this.btnResult.Text = "Выполнить задачу";
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // btnShapshot
            // 
            this.btnShapshot.Location = new System.Drawing.Point(699, 38);
            this.btnShapshot.Name = "btnShapshot";
            this.btnShapshot.Size = new System.Drawing.Size(103, 38);
            this.btnShapshot.TabIndex = 20;
            this.btnShapshot.Text = "Сделать снимок процессов";
            this.btnShapshot.UseVisualStyleBackColor = true;
            this.btnShapshot.Click += new System.EventHandler(this.btnShapshot_Click);
            // 
            // listBoxResult
            // 
            this.listBoxResult.FormattingEnabled = true;
            this.listBoxResult.Location = new System.Drawing.Point(453, 33);
            this.listBoxResult.Name = "listBoxResult";
            this.listBoxResult.Size = new System.Drawing.Size(240, 290);
            this.listBoxResult.TabIndex = 30;
            // 
            // tbCurrentItem
            // 
            this.tbCurrentItem.Location = new System.Drawing.Point(224, 31);
            this.tbCurrentItem.Multiline = true;
            this.tbCurrentItem.Name = "tbCurrentItem";
            this.tbCurrentItem.ReadOnly = true;
            this.tbCurrentItem.Size = new System.Drawing.Size(223, 292);
            this.tbCurrentItem.TabIndex = 29;
            // 
            // lbCurrentItem
            // 
            this.lbCurrentItem.AutoSize = true;
            this.lbCurrentItem.Location = new System.Drawing.Point(221, 13);
            this.lbCurrentItem.Name = "lbCurrentItem";
            this.lbCurrentItem.Size = new System.Drawing.Size(133, 13);
            this.lbCurrentItem.TabIndex = 28;
            this.lbCurrentItem.Text = "Информация об объекте";
            // 
            // treeViewProcesses
            // 
            this.treeViewProcesses.Location = new System.Drawing.Point(12, 31);
            this.treeViewProcesses.Name = "treeViewProcesses";
            this.treeViewProcesses.Size = new System.Drawing.Size(206, 292);
            this.treeViewProcesses.TabIndex = 27;
            this.treeViewProcesses.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewProcesses_NodeMouseClick);
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Location = new System.Drawing.Point(450, 13);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(59, 13);
            this.lbResult.TabIndex = 26;
            this.lbResult.Text = "Результат";
            // 
            // lbProcesses
            // 
            this.lbProcesses.AutoSize = true;
            this.lbProcesses.Location = new System.Drawing.Point(9, 13);
            this.lbProcesses.Name = "lbProcesses";
            this.lbProcesses.Size = new System.Drawing.Size(105, 13);
            this.lbProcesses.TabIndex = 25;
            this.lbProcesses.Text = "Текущие процессы";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(699, 221);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(103, 38);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(699, 285);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(103, 38);
            this.btnExit.TabIndex = 23;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnConditionTask
            // 
            this.btnConditionTask.Location = new System.Drawing.Point(699, 160);
            this.btnConditionTask.Name = "btnConditionTask";
            this.btnConditionTask.Size = new System.Drawing.Size(103, 38);
            this.btnConditionTask.TabIndex = 22;
            this.btnConditionTask.Text = "Условие задачи";
            this.btnConditionTask.UseVisualStyleBackColor = true;
            this.btnConditionTask.Click += new System.EventHandler(this.btnConditionTask_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 338);
            this.Controls.Add(this.btnResult);
            this.Controls.Add(this.btnShapshot);
            this.Controls.Add(this.listBoxResult);
            this.Controls.Add(this.tbCurrentItem);
            this.Controls.Add(this.lbCurrentItem);
            this.Controls.Add(this.treeViewProcesses);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.lbProcesses);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnConditionTask);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnResult;
        private System.Windows.Forms.Button btnShapshot;
        private System.Windows.Forms.ListBox listBoxResult;
        private System.Windows.Forms.TextBox tbCurrentItem;
        private System.Windows.Forms.Label lbCurrentItem;
        private System.Windows.Forms.TreeView treeViewProcesses;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.Label lbProcesses;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnConditionTask;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog10;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog11;
    }
}

