namespace project.ApproximateRepresentationOfFunctions
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.comboBoxFunctions = new System.Windows.Forms.ComboBox();
            this.leftBorder = new System.Windows.Forms.TextBox();
            this.lblLeftBorder = new System.Windows.Forms.Label();
            this.lblErrorLeftBorder = new System.Windows.Forms.Label();
            this.rightBorder = new System.Windows.Forms.TextBox();
            this.lblRightBorder = new System.Windows.Forms.Label();
            this.lblErrorRightBorder = new System.Windows.Forms.Label();
            this.trackBarN = new System.Windows.Forms.TrackBar();
            this.lblTrackBarNName = new System.Windows.Forms.Label();
            this.lblTrackBarNSize = new System.Windows.Forms.Label();
            this.trackBarK = new System.Windows.Forms.TrackBar();
            this.lblTrackBarKName = new System.Windows.Forms.Label();
            this.lblTrackBarKSize = new System.Windows.Forms.Label();
            this.LblTitle = new System.Windows.Forms.Label();
            this.panelParams = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.stepen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ravnomernoe_razbienie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chebyshevskoe_razbienie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSuccess = new System.Windows.Forms.Label();
            this.lblProcess = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarK)).BeginInit();
            this.panelParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxFunctions
            // 
            this.comboBoxFunctions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFunctions.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxFunctions.FormattingEnabled = true;
            this.comboBoxFunctions.Location = new System.Drawing.Point(18, 35);
            this.comboBoxFunctions.Name = "comboBoxFunctions";
            this.comboBoxFunctions.Size = new System.Drawing.Size(430, 23);
            this.comboBoxFunctions.TabIndex = 0;
            this.comboBoxFunctions.SelectedIndexChanged += new System.EventHandler(this.comboBoxFunctions_SelectedIndexChanged);
            // 
            // leftBorder
            // 
            this.leftBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leftBorder.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.leftBorder.ForeColor = System.Drawing.SystemColors.MenuText;
            this.leftBorder.Location = new System.Drawing.Point(155, 121);
            this.leftBorder.Name = "leftBorder";
            this.leftBorder.Size = new System.Drawing.Size(52, 23);
            this.leftBorder.TabIndex = 1;
            this.leftBorder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.leftBorder_KeyPress);
            this.leftBorder.Leave += new System.EventHandler(this.leftBorder_Leave);
            // 
            // lblLeftBorder
            // 
            this.lblLeftBorder.AutoSize = true;
            this.lblLeftBorder.BackColor = System.Drawing.Color.White;
            this.lblLeftBorder.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLeftBorder.Location = new System.Drawing.Point(14, 121);
            this.lblLeftBorder.Name = "lblLeftBorder";
            this.lblLeftBorder.Size = new System.Drawing.Size(126, 19);
            this.lblLeftBorder.TabIndex = 2;
            this.lblLeftBorder.Text = "Левая граница";
            // 
            // lblErrorLeftBorder
            // 
            this.lblErrorLeftBorder.AutoSize = true;
            this.lblErrorLeftBorder.BackColor = System.Drawing.Color.White;
            this.lblErrorLeftBorder.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblErrorLeftBorder.ForeColor = System.Drawing.Color.Red;
            this.lblErrorLeftBorder.Location = new System.Drawing.Point(18, 144);
            this.lblErrorLeftBorder.Name = "lblErrorLeftBorder";
            this.lblErrorLeftBorder.Size = new System.Drawing.Size(43, 13);
            this.lblErrorLeftBorder.TabIndex = 3;
            this.lblErrorLeftBorder.Text = "label1";
            // 
            // rightBorder
            // 
            this.rightBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightBorder.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rightBorder.Location = new System.Drawing.Point(155, 157);
            this.rightBorder.Name = "rightBorder";
            this.rightBorder.Size = new System.Drawing.Size(52, 23);
            this.rightBorder.TabIndex = 4;
            this.rightBorder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rightBorder_KeyPress);
            this.rightBorder.Leave += new System.EventHandler(this.rightBorder_Leave);
            // 
            // lblRightBorder
            // 
            this.lblRightBorder.AutoSize = true;
            this.lblRightBorder.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRightBorder.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRightBorder.Location = new System.Drawing.Point(14, 161);
            this.lblRightBorder.Name = "lblRightBorder";
            this.lblRightBorder.Size = new System.Drawing.Size(135, 19);
            this.lblRightBorder.TabIndex = 5;
            this.lblRightBorder.Text = "Правая граница";
            // 
            // lblErrorRightBorder
            // 
            this.lblErrorRightBorder.AutoSize = true;
            this.lblErrorRightBorder.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblErrorRightBorder.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblErrorRightBorder.ForeColor = System.Drawing.Color.Red;
            this.lblErrorRightBorder.Location = new System.Drawing.Point(18, 180);
            this.lblErrorRightBorder.Name = "lblErrorRightBorder";
            this.lblErrorRightBorder.Size = new System.Drawing.Size(43, 13);
            this.lblErrorRightBorder.TabIndex = 6;
            this.lblErrorRightBorder.Text = "label1";
            // 
            // trackBarN
            // 
            this.trackBarN.Location = new System.Drawing.Point(14, 290);
            this.trackBarN.Maximum = 100;
            this.trackBarN.Minimum = 1;
            this.trackBarN.Name = "trackBarN";
            this.trackBarN.Size = new System.Drawing.Size(430, 45);
            this.trackBarN.TabIndex = 7;
            this.trackBarN.Value = 25;
            this.trackBarN.ValueChanged += new System.EventHandler(this.trackBarN_ValueChanged);
            // 
            // lblTrackBarNName
            // 
            this.lblTrackBarNName.AutoSize = true;
            this.lblTrackBarNName.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTrackBarNName.Location = new System.Drawing.Point(21, 268);
            this.lblTrackBarNName.Name = "lblTrackBarNName";
            this.lblTrackBarNName.Size = new System.Drawing.Size(171, 19);
            this.lblTrackBarNName.TabIndex = 8;
            this.lblTrackBarNName.Text = "Степень полинома =";
            // 
            // lblTrackBarNSize
            // 
            this.lblTrackBarNSize.AutoSize = true;
            this.lblTrackBarNSize.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTrackBarNSize.Location = new System.Drawing.Point(198, 268);
            this.lblTrackBarNSize.Name = "lblTrackBarNSize";
            this.lblTrackBarNSize.Size = new System.Drawing.Size(63, 19);
            this.lblTrackBarNSize.TabIndex = 9;
            this.lblTrackBarNSize.Text = "label1";
            // 
            // trackBarK
            // 
            this.trackBarK.Location = new System.Drawing.Point(18, 351);
            this.trackBarK.Maximum = 100;
            this.trackBarK.Minimum = 10;
            this.trackBarK.Name = "trackBarK";
            this.trackBarK.Size = new System.Drawing.Size(430, 45);
            this.trackBarK.TabIndex = 10;
            this.trackBarK.Value = 10;
            this.trackBarK.ValueChanged += new System.EventHandler(this.trackBarK_ValueChanged);
            // 
            // lblTrackBarKName
            // 
            this.lblTrackBarKName.AutoSize = true;
            this.lblTrackBarKName.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTrackBarKName.Location = new System.Drawing.Point(21, 332);
            this.lblTrackBarKName.Name = "lblTrackBarKName";
            this.lblTrackBarKName.Size = new System.Drawing.Size(207, 19);
            this.lblTrackBarKName.TabIndex = 11;
            this.lblTrackBarKName.Text = "Количество разбиений =";
            // 
            // lblTrackBarKSize
            // 
            this.lblTrackBarKSize.AutoSize = true;
            this.lblTrackBarKSize.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTrackBarKSize.Location = new System.Drawing.Point(234, 332);
            this.lblTrackBarKSize.Name = "lblTrackBarKSize";
            this.lblTrackBarKSize.Size = new System.Drawing.Size(63, 19);
            this.lblTrackBarKSize.TabIndex = 12;
            this.lblTrackBarKSize.Text = "label1";
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblTitle.Location = new System.Drawing.Point(14, 10);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(80, 22);
            this.LblTitle.TabIndex = 13;
            this.LblTitle.Text = "Функция";
            // 
            // panelParams
            // 
            this.panelParams.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelParams.Controls.Add(this.lblErrorRightBorder);
            this.panelParams.Controls.Add(this.LblTitle);
            this.panelParams.Controls.Add(this.lblRightBorder);
            this.panelParams.Controls.Add(this.lblErrorLeftBorder);
            this.panelParams.Controls.Add(this.comboBoxFunctions);
            this.panelParams.Controls.Add(this.lblLeftBorder);
            this.panelParams.Controls.Add(this.trackBarN);
            this.panelParams.Controls.Add(this.rightBorder);
            this.panelParams.Controls.Add(this.lblTrackBarNName);
            this.panelParams.Controls.Add(this.leftBorder);
            this.panelParams.Controls.Add(this.lblTrackBarKSize);
            this.panelParams.Controls.Add(this.lblTrackBarNSize);
            this.panelParams.Controls.Add(this.lblTrackBarKName);
            this.panelParams.Controls.Add(this.trackBarK);
            this.panelParams.Location = new System.Drawing.Point(1141, 24);
            this.panelParams.Name = "panelParams";
            this.panelParams.Size = new System.Drawing.Size(463, 399);
            this.panelParams.TabIndex = 14;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(24, 24);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1092, 399);
            this.chart1.TabIndex = 15;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(24, 442);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(1092, 473);
            this.chart2.TabIndex = 16;
            this.chart2.Text = "chart2";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stepen,
            this.ravnomernoe_razbienie,
            this.chebyshevskoe_razbienie});
            this.dataGridView1.Location = new System.Drawing.Point(1141, 442);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(463, 473);
            this.dataGridView1.TabIndex = 17;
            // 
            // stepen
            // 
            this.stepen.HeaderText = "Степень";
            this.stepen.Name = "stepen";
            // 
            // ravnomernoe_razbienie
            // 
            this.ravnomernoe_razbienie.HeaderText = "Равномерное разбиение";
            this.ravnomernoe_razbienie.Name = "ravnomernoe_razbienie";
            // 
            // chebyshevskoe_razbienie
            // 
            this.chebyshevskoe_razbienie.HeaderText = "Чебышевское разбиение";
            this.chebyshevskoe_razbienie.Name = "chebyshevskoe_razbienie";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.lblSuccess);
            this.panel2.Controls.Add(this.lblProcess);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Location = new System.Drawing.Point(0, 932);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1628, 30);
            this.panel2.TabIndex = 18;
            // 
            // lblSuccess
            // 
            this.lblSuccess.AutoSize = true;
            this.lblSuccess.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSuccess.Location = new System.Drawing.Point(1514, 7);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(90, 19);
            this.lblSuccess.TabIndex = 2;
            this.lblSuccess.Text = "Выполнено";
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblProcess.Location = new System.Drawing.Point(1240, 7);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(198, 19);
            this.lblProcess.TabIndex = 1;
            this.lblProcess.Text = "Выполнение построения";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(1460, 3);
            this.progressBar1.Maximum = 101;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(144, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 0;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1629, 962);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panelParams);
            this.Name = "Form1";
            this.Text = "Интерполяция функций многочленом Ньютона";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarK)).EndInit();
            this.panelParams.ResumeLayout(false);
            this.panelParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxFunctions;
        private System.Windows.Forms.TextBox leftBorder;
        private System.Windows.Forms.Label lblLeftBorder;
        private System.Windows.Forms.Label lblErrorLeftBorder;
        private System.Windows.Forms.TextBox rightBorder;
        private System.Windows.Forms.Label lblRightBorder;
        private System.Windows.Forms.Label lblErrorRightBorder;
        private System.Windows.Forms.TrackBar trackBarN;
        private System.Windows.Forms.Label lblTrackBarNName;
        private System.Windows.Forms.Label lblTrackBarNSize;
        private System.Windows.Forms.TrackBar trackBarK;
        private System.Windows.Forms.Label lblTrackBarKName;
        private System.Windows.Forms.Label lblTrackBarKSize;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.Panel panelParams;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn stepen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ravnomernoe_razbienie;
        private System.Windows.Forms.DataGridViewTextBoxColumn chebyshevskoe_razbienie;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProcess;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label lblSuccess;
    }
}

