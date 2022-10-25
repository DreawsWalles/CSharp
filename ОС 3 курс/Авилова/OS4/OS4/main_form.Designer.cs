namespace OS4
{
    partial class main_form
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
            this.dGV_matr = new System.Windows.Forms.DataGridView();
            this.numUpDown_p = new System.Windows.Forms.NumericUpDown();
            this.numUpDown_r = new System.Windows.Forms.NumericUpDown();
            this.lbl_r = new System.Windows.Forms.Label();
            this.lbl_p = new System.Windows.Forms.Label();
            this.btn_run = new System.Windows.Forms.Button();
            this.btn_show = new System.Windows.Forms.Button();
            this.dGV_graph = new System.Windows.Forms.DataGridView();
            this.logTB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_matr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_p)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_r)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_graph)).BeginInit();
            this.SuspendLayout();
            // 
            // dGV_matr
            // 
            this.dGV_matr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_matr.Location = new System.Drawing.Point(12, 12);
            this.dGV_matr.Name = "dGV_matr";
            this.dGV_matr.Size = new System.Drawing.Size(721, 270);
            this.dGV_matr.TabIndex = 0;
            // 
            // numUpDown_p
            // 
            this.numUpDown_p.Location = new System.Drawing.Point(1193, 121);
            this.numUpDown_p.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUpDown_p.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDown_p.Name = "numUpDown_p";
            this.numUpDown_p.Size = new System.Drawing.Size(100, 20);
            this.numUpDown_p.TabIndex = 7;
            this.numUpDown_p.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numUpDown_r
            // 
            this.numUpDown_r.Location = new System.Drawing.Point(1192, 60);
            this.numUpDown_r.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUpDown_r.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDown_r.Name = "numUpDown_r";
            this.numUpDown_r.Size = new System.Drawing.Size(100, 20);
            this.numUpDown_r.TabIndex = 8;
            this.numUpDown_r.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lbl_r
            // 
            this.lbl_r.AutoSize = true;
            this.lbl_r.Location = new System.Drawing.Point(1190, 37);
            this.lbl_r.Name = "lbl_r";
            this.lbl_r.Size = new System.Drawing.Size(90, 13);
            this.lbl_r.TabIndex = 9;
            this.lbl_r.Text = "кол-во ресурсов";
            // 
            // lbl_p
            // 
            this.lbl_p.AutoSize = true;
            this.lbl_p.Location = new System.Drawing.Point(1190, 105);
            this.lbl_p.Name = "lbl_p";
            this.lbl_p.Size = new System.Drawing.Size(97, 13);
            this.lbl_p.TabIndex = 10;
            this.lbl_p.Text = "кол-во процессов";
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(1194, 208);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(99, 29);
            this.btn_run.TabIndex = 11;
            this.btn_run.Text = "Начать";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // btn_show
            // 
            this.btn_show.Location = new System.Drawing.Point(1192, 164);
            this.btn_show.Name = "btn_show";
            this.btn_show.Size = new System.Drawing.Size(99, 29);
            this.btn_show.TabIndex = 12;
            this.btn_show.Text = "Показать";
            this.btn_show.UseVisualStyleBackColor = true;
            this.btn_show.Click += new System.EventHandler(this.btn_show_Click);
            // 
            // dGV_graph
            // 
            this.dGV_graph.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_graph.Location = new System.Drawing.Point(12, 299);
            this.dGV_graph.Name = "dGV_graph";
            this.dGV_graph.Size = new System.Drawing.Size(721, 271);
            this.dGV_graph.TabIndex = 13;
            // 
            // logTB
            // 
            this.logTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logTB.Location = new System.Drawing.Point(748, 12);
            this.logTB.Multiline = true;
            this.logTB.Name = "logTB";
            this.logTB.ReadOnly = true;
            this.logTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTB.Size = new System.Drawing.Size(436, 558);
            this.logTB.TabIndex = 46;
            this.logTB.WordWrap = false;
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 571);
            this.Controls.Add(this.logTB);
            this.Controls.Add(this.dGV_graph);
            this.Controls.Add(this.btn_show);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.lbl_p);
            this.Controls.Add(this.lbl_r);
            this.Controls.Add(this.numUpDown_r);
            this.Controls.Add(this.numUpDown_p);
            this.Controls.Add(this.dGV_matr);
            this.Name = "main_form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.main_form_FormClosed);
            this.Load += new System.EventHandler(this.main_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_matr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_p)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_r)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_graph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGV_matr;
        private System.Windows.Forms.NumericUpDown numUpDown_p;
        private System.Windows.Forms.NumericUpDown numUpDown_r;
        private System.Windows.Forms.Label lbl_r;
        private System.Windows.Forms.Label lbl_p;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.Button btn_show;
        private System.Windows.Forms.DataGridView dGV_graph;
        private System.Windows.Forms.TextBox logTB;
    }
}

