namespace TaskTwo
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNameFrst = new System.Windows.Forms.Label();
            this.lblFrequencyFrst = new System.Windows.Forms.Label();
            this.lblValueRamFrst = new System.Windows.Forms.Label();
            this.tbNameFrst = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tbFrequencyFrst = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tbValueRamFrst = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tbNameScnd = new System.Windows.Forms.TextBox();
            this.lblNameScnd = new System.Windows.Forms.Label();
            this.lblFrequencyScnd = new System.Windows.Forms.Label();
            this.lblValueRamScnd = new System.Windows.Forms.Label();
            this.lblHardDriveVolume = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tbFrequencyScnd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tbValueRamScnd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tbHardDiskValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnInfo = new System.Windows.Forms.Button();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnInfo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel9, 0, 0);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(547, 319);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 44);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(541, 227);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(533, 195);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Первый уровень";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 245F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lblNameFrst, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblFrequencyFrst, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblValueRamFrst, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbNameFrst, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel6, 1, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(527, 185);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblNameFrst
            // 
            this.lblNameFrst.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNameFrst.AutoSize = true;
            this.lblNameFrst.Location = new System.Drawing.Point(17, 21);
            this.lblNameFrst.Name = "lblNameFrst";
            this.lblNameFrst.Size = new System.Drawing.Size(225, 19);
            this.lblNameFrst.TabIndex = 0;
            this.lblNameFrst.Text = "Наименование процессора:";
            // 
            // lblFrequencyFrst
            // 
            this.lblFrequencyFrst.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFrequencyFrst.AutoSize = true;
            this.lblFrequencyFrst.Location = new System.Drawing.Point(62, 82);
            this.lblFrequencyFrst.Name = "lblFrequencyFrst";
            this.lblFrequencyFrst.Size = new System.Drawing.Size(180, 19);
            this.lblFrequencyFrst.TabIndex = 1;
            this.lblFrequencyFrst.Text = "Частота процессора:";
            // 
            // lblValueRamFrst
            // 
            this.lblValueRamFrst.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblValueRamFrst.AutoSize = true;
            this.lblValueRamFrst.Location = new System.Drawing.Point(8, 144);
            this.lblValueRamFrst.Name = "lblValueRamFrst";
            this.lblValueRamFrst.Size = new System.Drawing.Size(234, 19);
            this.lblValueRamFrst.TabIndex = 2;
            this.lblValueRamFrst.Text = "Объем оперативной памяти:";
            // 
            // tbNameFrst
            // 
            this.tbNameFrst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNameFrst.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNameFrst.Location = new System.Drawing.Point(248, 18);
            this.tbNameFrst.Name = "tbNameFrst";
            this.tbNameFrst.Size = new System.Drawing.Size(276, 25);
            this.tbNameFrst.TabIndex = 3;
            this.tbNameFrst.Text = "Название...";
            this.tbNameFrst.Enter += new System.EventHandler(this.tbNameFrst_Enter);
            this.tbNameFrst.Leave += new System.EventHandler(this.tbNameFrst_Leave);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel4.Controls.Add(this.tbFrequencyFrst, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(248, 64);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(276, 55);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // tbFrequencyFrst
            // 
            this.tbFrequencyFrst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFrequencyFrst.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbFrequencyFrst.Location = new System.Drawing.Point(3, 15);
            this.tbFrequencyFrst.Name = "tbFrequencyFrst";
            this.tbFrequencyFrst.Size = new System.Drawing.Size(228, 25);
            this.tbFrequencyFrst.TabIndex = 5;
            this.tbFrequencyFrst.Text = "Частота процессора...";
            this.tbFrequencyFrst.Enter += new System.EventHandler(this.tbFrequencyFrst_Enter);
            this.tbFrequencyFrst.Leave += new System.EventHandler(this.tbFrequencyFrst_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "МГЦ";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel6.Controls.Add(this.tbValueRamFrst, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(248, 125);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(276, 57);
            this.tableLayoutPanel6.TabIndex = 7;
            // 
            // tbValueRamFrst
            // 
            this.tbValueRamFrst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbValueRamFrst.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbValueRamFrst.Location = new System.Drawing.Point(3, 16);
            this.tbValueRamFrst.Name = "tbValueRamFrst";
            this.tbValueRamFrst.Size = new System.Drawing.Size(237, 25);
            this.tbValueRamFrst.TabIndex = 6;
            this.tbValueRamFrst.Text = "Объем оперативной памяти...";
            this.tbValueRamFrst.Enter += new System.EventHandler(this.tbValueRamFrst_Enter);
            this.tbValueRamFrst.Leave += new System.EventHandler(this.tbValueRamFrst_Leave);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "МБ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(533, 195);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Второй уровень";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 245F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tbNameScnd, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblNameScnd, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblFrequencyScnd, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblValueRamScnd, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblHardDriveVolume, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel7, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel8, 1, 3);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 6);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(527, 185);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tbNameScnd
            // 
            this.tbNameScnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNameScnd.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNameScnd.Location = new System.Drawing.Point(248, 10);
            this.tbNameScnd.Name = "tbNameScnd";
            this.tbNameScnd.Size = new System.Drawing.Size(276, 25);
            this.tbNameScnd.TabIndex = 4;
            this.tbNameScnd.Text = "Название...";
            this.tbNameScnd.Enter += new System.EventHandler(this.tbNameScnd_Enter);
            this.tbNameScnd.Leave += new System.EventHandler(this.tbNameScnd_Leave);
            // 
            // lblNameScnd
            // 
            this.lblNameScnd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNameScnd.AutoSize = true;
            this.lblNameScnd.Location = new System.Drawing.Point(17, 13);
            this.lblNameScnd.Name = "lblNameScnd";
            this.lblNameScnd.Size = new System.Drawing.Size(225, 19);
            this.lblNameScnd.TabIndex = 0;
            this.lblNameScnd.Text = "Наименование процессора:";
            // 
            // lblFrequencyScnd
            // 
            this.lblFrequencyScnd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFrequencyScnd.AutoSize = true;
            this.lblFrequencyScnd.Location = new System.Drawing.Point(62, 59);
            this.lblFrequencyScnd.Name = "lblFrequencyScnd";
            this.lblFrequencyScnd.Size = new System.Drawing.Size(180, 19);
            this.lblFrequencyScnd.TabIndex = 1;
            this.lblFrequencyScnd.Text = "Частота процессора:";
            // 
            // lblValueRamScnd
            // 
            this.lblValueRamScnd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblValueRamScnd.AutoSize = true;
            this.lblValueRamScnd.Location = new System.Drawing.Point(8, 105);
            this.lblValueRamScnd.Name = "lblValueRamScnd";
            this.lblValueRamScnd.Size = new System.Drawing.Size(234, 19);
            this.lblValueRamScnd.TabIndex = 2;
            this.lblValueRamScnd.Text = "Объем оперативной памяти:";
            // 
            // lblHardDriveVolume
            // 
            this.lblHardDriveVolume.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHardDriveVolume.AutoSize = true;
            this.lblHardDriveVolume.Location = new System.Drawing.Point(44, 152);
            this.lblHardDriveVolume.Name = "lblHardDriveVolume";
            this.lblHardDriveVolume.Size = new System.Drawing.Size(198, 19);
            this.lblHardDriveVolume.TabIndex = 3;
            this.lblHardDriveVolume.Text = "Объем жесткого диска:";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel5.Controls.Add(this.tbFrequencyScnd, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(248, 49);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(276, 40);
            this.tableLayoutPanel5.TabIndex = 8;
            // 
            // tbFrequencyScnd
            // 
            this.tbFrequencyScnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFrequencyScnd.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbFrequencyScnd.Location = new System.Drawing.Point(3, 7);
            this.tbFrequencyScnd.Name = "tbFrequencyScnd";
            this.tbFrequencyScnd.Size = new System.Drawing.Size(228, 25);
            this.tbFrequencyScnd.TabIndex = 6;
            this.tbFrequencyScnd.Text = "Частота процессора...";
            this.tbFrequencyScnd.Enter += new System.EventHandler(this.tbFrequencyScnd_Enter);
            this.tbFrequencyScnd.Leave += new System.EventHandler(this.tbFrequencyScnd_Leave);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "МГЦ";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel7.Controls.Add(this.tbValueRamScnd, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(248, 95);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(276, 40);
            this.tableLayoutPanel7.TabIndex = 9;
            // 
            // tbValueRamScnd
            // 
            this.tbValueRamScnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbValueRamScnd.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbValueRamScnd.Location = new System.Drawing.Point(3, 7);
            this.tbValueRamScnd.Name = "tbValueRamScnd";
            this.tbValueRamScnd.Size = new System.Drawing.Size(237, 25);
            this.tbValueRamScnd.TabIndex = 7;
            this.tbValueRamScnd.Text = "Объем оперативной памяти...";
            this.tbValueRamScnd.Enter += new System.EventHandler(this.tbValueRamScnd_Enter);
            this.tbValueRamScnd.Leave += new System.EventHandler(this.tbValueRamScnd_Leave);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(246, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "МБ";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel8.Controls.Add(this.tbHardDiskValue, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(248, 141);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(276, 41);
            this.tableLayoutPanel8.TabIndex = 10;
            // 
            // tbHardDiskValue
            // 
            this.tbHardDiskValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHardDiskValue.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbHardDiskValue.Location = new System.Drawing.Point(3, 8);
            this.tbHardDiskValue.Name = "tbHardDiskValue";
            this.tbHardDiskValue.Size = new System.Drawing.Size(237, 25);
            this.tbHardDiskValue.TabIndex = 8;
            this.tbHardDiskValue.Text = "Объем жесткого диска...";
            this.tbHardDiskValue.Enter += new System.EventHandler(this.tbHardDiskValue_Enter);
            this.tbHardDiskValue.Leave += new System.EventHandler(this.tbHardDiskValue_Leave);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(246, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "ГБ";
            // 
            // btnInfo
            // 
            this.btnInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnInfo.Location = new System.Drawing.Point(158, 287);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(231, 29);
            this.btnInfo.TabIndex = 1;
            this.btnInfo.Text = "Получить информацию";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.btnClose, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(541, 35);
            this.tableLayoutPanel9.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Компьютер";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.Location = new System.Drawing.Point(3, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 27);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "<-";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FotmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 321);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FotmMain";
            this.Text = "Второе задание";
            this.Load += new System.EventHandler(this.FotmMain_Load);
            this.Resize += new System.EventHandler(this.FotmMain_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblNameFrst;
        private System.Windows.Forms.Label lblFrequencyFrst;
        private System.Windows.Forms.Label lblValueRamFrst;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblNameScnd;
        private System.Windows.Forms.Label lblFrequencyScnd;
        private System.Windows.Forms.Label lblValueRamScnd;
        private System.Windows.Forms.Label lblHardDriveVolume;
        private System.Windows.Forms.TextBox tbNameFrst;
        private System.Windows.Forms.TextBox tbNameScnd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox tbFrequencyFrst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox tbFrequencyScnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TextBox tbValueRamFrst;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TextBox tbValueRamScnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TextBox tbHardDiskValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}

