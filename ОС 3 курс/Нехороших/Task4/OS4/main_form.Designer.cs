namespace Task4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_form));
            this.dGV_matr = new System.Windows.Forms.DataGridView();
            this.numUpDown_p = new System.Windows.Forms.NumericUpDown();
            this.numUpDown_r = new System.Windows.Forms.NumericUpDown();
            this.lbl_r = new System.Windows.Forms.Label();
            this.lbl_p = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.dGV_graph = new System.Windows.Forms.DataGridView();
            this.Infotb = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_matr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_p)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_r)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_graph)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dGV_matr
            // 
            this.dGV_matr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_matr.Location = new System.Drawing.Point(12, 32);
            this.dGV_matr.Name = "dGV_matr";
            this.dGV_matr.Size = new System.Drawing.Size(415, 191);
            this.dGV_matr.TabIndex = 0;
            // 
            // numUpDown_p
            // 
            this.numUpDown_p.Location = new System.Drawing.Point(10, 95);
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
            3,
            0,
            0,
            0});
            // 
            // numUpDown_r
            // 
            this.numUpDown_r.Location = new System.Drawing.Point(10, 46);
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
            3,
            0,
            0,
            0});
            // 
            // lbl_r
            // 
            this.lbl_r.AutoSize = true;
            this.lbl_r.Location = new System.Drawing.Point(7, 30);
            this.lbl_r.Name = "lbl_r";
            this.lbl_r.Size = new System.Drawing.Size(90, 13);
            this.lbl_r.TabIndex = 9;
            this.lbl_r.Text = "кол-во ресурсов";
            // 
            // lbl_p
            // 
            this.lbl_p.AutoSize = true;
            this.lbl_p.Location = new System.Drawing.Point(7, 79);
            this.lbl_p.Name = "lbl_p";
            this.lbl_p.Size = new System.Drawing.Size(97, 13);
            this.lbl_p.TabIndex = 10;
            this.lbl_p.Text = "кол-во процессов";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(11, 148);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(99, 29);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "Старт";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(11, 189);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(99, 29);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "Стоп";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // dGV_graph
            // 
            this.dGV_graph.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_graph.Location = new System.Drawing.Point(12, 253);
            this.dGV_graph.Name = "dGV_graph";
            this.dGV_graph.Size = new System.Drawing.Size(415, 188);
            this.dGV_graph.TabIndex = 13;
            // 
            // Infotb
            // 
            this.Infotb.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Infotb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Infotb.Location = new System.Drawing.Point(446, 32);
            this.Infotb.Multiline = true;
            this.Infotb.Name = "Infotb";
            this.Infotb.ReadOnly = true;
            this.Infotb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Infotb.Size = new System.Drawing.Size(293, 409);
            this.Infotb.TabIndex = 46;
            this.Infotb.WordWrap = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_r);
            this.groupBox1.Controls.Add(this.numUpDown_r);
            this.groupBox1.Controls.Add(this.numUpDown_p);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.lbl_p);
            this.groupBox1.Location = new System.Drawing.Point(745, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 245);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Панель управления";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Информация о ресурсах, необходимых каждому процессу:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Ориентированных граф:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(443, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Описание процесса работы:";
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 479);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Infotb);
            this.Controls.Add(this.dGV_graph);
            this.Controls.Add(this.dGV_matr);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main_form";
            this.Text = "Метод Габермана";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.main_form_FormClosed);
            this.Load += new System.EventHandler(this.main_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_matr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_p)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_r)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_graph)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGV_matr;
        private System.Windows.Forms.NumericUpDown numUpDown_p;
        private System.Windows.Forms.NumericUpDown numUpDown_r;
        private System.Windows.Forms.Label lbl_r;
        private System.Windows.Forms.Label lbl_p;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.DataGridView dGV_graph;
        private System.Windows.Forms.TextBox Infotb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

