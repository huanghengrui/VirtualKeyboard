namespace VirtualKeyboard
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new DevComponents.DotNetBar.ButtonX();
            this.cmbBaud = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbPort = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.msgGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLei = new System.Windows.Forms.TextBox();
            this.button3 = new DevComponents.DotNetBar.ButtonX();
            this.btnbatchRead = new DevComponents.DotNetBar.ButtonX();
            this.btnBatchWrite = new DevComponents.DotNetBar.ButtonX();
            this.styleManager = new DevComponents.DotNetBar.StyleManager(this.components);
            this.lbCount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnStop = new DevComponents.DotNetBar.ButtonX();
            this.chkEnter = new System.Windows.Forms.CheckBox();
            this.btnStart = new DevComponents.DotNetBar.ButtonX();
            this.chkKey = new System.Windows.Forms.CheckBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtZF = new System.Windows.Forms.NumericUpDown();
            this.txtDelay = new System.Windows.Forms.NumericUpDown();
            this.progressBarX = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnSet = new DevComponents.DotNetBar.LabelX();
            this.btnMin = new DevComponents.DotNetBar.LabelX();
            this.label9 = new System.Windows.Forms.Label();
            this.btnClosess = new DevComponents.DotNetBar.LabelX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.panelHysoon = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtpinzhong = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtLeiBie = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.msgGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDelay)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.panelHysoon.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmbBaud);
            this.groupBox1.Controls.Add(this.cmbPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button1.Location = new System.Drawing.Point(335, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "打开串口";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbBaud
            // 
            this.cmbBaud.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaud.ForeColor = System.Drawing.Color.Black;
            this.cmbBaud.FormattingEnabled = true;
            this.cmbBaud.ItemHeight = 16;
            this.cmbBaud.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "115200"});
            this.cmbBaud.Location = new System.Drawing.Point(221, 18);
            this.cmbBaud.Name = "cmbBaud";
            this.cmbBaud.Size = new System.Drawing.Size(90, 22);
            this.cmbBaud.TabIndex = 3;
            // 
            // cmbPort
            // 
            this.cmbPort.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPort.ForeColor = System.Drawing.Color.Black;
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.ItemHeight = 16;
            this.cmbPort.Location = new System.Drawing.Point(63, 18);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(94, 22);
            this.cmbPort.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "串  口：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.msgGrid);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 167);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接收数据";
            // 
            // msgGrid
            // 
            this.msgGrid.AllowUserToAddRows = false;
            this.msgGrid.AllowUserToDeleteRows = false;
            this.msgGrid.AllowUserToResizeColumns = false;
            this.msgGrid.AllowUserToResizeRows = false;
            this.msgGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.msgGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.msgGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.msgGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.msgGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.msgGrid.ColumnHeadersVisible = false;
            this.msgGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.msgGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.msgGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgGrid.EnableHeadersVisualStyles = false;
            this.msgGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.msgGrid.Location = new System.Drawing.Point(3, 17);
            this.msgGrid.MultiSelect = false;
            this.msgGrid.Name = "msgGrid";
            this.msgGrid.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.msgGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.msgGrid.RowHeadersVisible = false;
            this.msgGrid.RowTemplate.Height = 23;
            this.msgGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.msgGrid.Size = new System.Drawing.Size(428, 147);
            this.msgGrid.TabIndex = 4;
            this.msgGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.msgGrid_DataError);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // txtLei
            // 
            this.txtLei.Location = new System.Drawing.Point(24, 34);
            this.txtLei.MaxLength = 12;
            this.txtLei.Name = "txtLei";
            this.txtLei.Size = new System.Drawing.Size(169, 21);
            this.txtLei.TabIndex = 7;
            this.txtLei.Text = "1";
            this.txtLei.Visible = false;
            this.txtLei.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLei_KeyPress);
            // 
            // button3
            // 
            this.button3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(350, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "清空";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnbatchRead
            // 
            this.btnbatchRead.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnbatchRead.Location = new System.Drawing.Point(233, 34);
            this.btnbatchRead.Name = "btnbatchRead";
            this.btnbatchRead.Size = new System.Drawing.Size(85, 25);
            this.btnbatchRead.TabIndex = 10;
            this.btnbatchRead.Text = "读取信息";
            this.btnbatchRead.Click += new System.EventHandler(this.btnbatchRead_Click);
            // 
            // btnBatchWrite
            // 
            this.btnBatchWrite.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBatchWrite.Location = new System.Drawing.Point(336, 34);
            this.btnBatchWrite.Name = "btnBatchWrite";
            this.btnBatchWrite.Size = new System.Drawing.Size(85, 25);
            this.btnBatchWrite.TabIndex = 11;
            this.btnBatchWrite.Text = "写入信息";
            this.btnBatchWrite.Click += new System.EventHandler(this.btnBatchWrite_Click);
            // 
            // styleManager
            // 
            this.styleManager.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016;
            this.styleManager.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // lbCount
            // 
            this.lbCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(50, 12);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(11, 12);
            this.lbCount.TabIndex = 16;
            this.lbCount.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "扫描延时时间:";
            // 
            // btnStop
            // 
            this.btnStop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStop.Location = new System.Drawing.Point(335, 10);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(85, 25);
            this.btnStop.TabIndex = 19;
            this.btnStop.Text = "停止扫描";
            this.btnStop.Click += new System.EventHandler(this.btnWork_Click);
            // 
            // chkEnter
            // 
            this.chkEnter.AutoSize = true;
            this.chkEnter.Location = new System.Drawing.Point(133, 16);
            this.chkEnter.Name = "chkEnter";
            this.chkEnter.Size = new System.Drawing.Size(84, 16);
            this.chkEnter.TabIndex = 20;
            this.chkEnter.Text = "输出双回车";
            this.chkEnter.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStart.Location = new System.Drawing.Point(232, 10);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(85, 25);
            this.btnStart.TabIndex = 21;
            this.btnStart.Text = "开启扫描";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // chkKey
            // 
            this.chkKey.AutoSize = true;
            this.chkKey.Checked = true;
            this.chkKey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKey.Location = new System.Drawing.Point(17, 16);
            this.chkKey.Name = "chkKey";
            this.chkKey.Size = new System.Drawing.Size(96, 16);
            this.chkKey.TabIndex = 22;
            this.chkKey.Text = "模拟键盘输出";
            this.chkKey.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "重复读取过滤时间:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(410, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "秒";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(179, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "毫秒";
            // 
            // txtZF
            // 
            this.txtZF.Location = new System.Drawing.Point(338, 50);
            this.txtZF.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtZF.Name = "txtZF";
            this.txtZF.Size = new System.Drawing.Size(66, 21);
            this.txtZF.TabIndex = 27;
            this.txtZF.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // txtDelay
            // 
            this.txtDelay.Location = new System.Drawing.Point(102, 50);
            this.txtDelay.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.txtDelay.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.Size = new System.Drawing.Size(70, 21);
            this.txtDelay.TabIndex = 28;
            this.txtDelay.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // progressBarX
            // 
            this.progressBarX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.progressBarX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBarX.Location = new System.Drawing.Point(90, 9);
            this.progressBarX.Name = "progressBarX";
            this.progressBarX.Size = new System.Drawing.Size(97, 18);
            this.progressBarX.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(196, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 30;
            this.label6.Text = "0";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 31;
            this.label8.Text = "数量：";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.Color.Transparent;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnSet);
            this.panelEx1.Controls.Add(this.btnMin);
            this.panelEx1.Controls.Add(this.label9);
            this.panelEx1.Controls.Add(this.btnClosess);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(1, 1);
            this.panelEx1.Margin = new System.Windows.Forms.Padding(0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(434, 31);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.None;
            this.panelEx1.Style.BorderWidth = 0;
            this.panelEx1.Style.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelEx1.Style.ForeColor.Color = System.Drawing.Color.White;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 35;
            this.panelEx1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panTitle_MouseDown);
            this.panelEx1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panTitle_MouseMove);
            this.panelEx1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panTitle_MouseUp);
            // 
            // btnSet
            // 
            this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.btnSet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.btnSet.Location = new System.Drawing.Point(338, 4);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(25, 25);
            this.btnSet.Symbol = "58834";
            this.btnSet.SymbolColor = System.Drawing.Color.White;
            this.btnSet.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.btnSet.SymbolSize = 13F;
            this.btnSet.TabIndex = 4;
            this.btnSet.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnSet.Click += new System.EventHandler(this.labelX1_Click);
            this.btnSet.MouseEnter += new System.EventHandler(this.labelX1_MouseEnter);
            this.btnSet.MouseLeave += new System.EventHandler(this.labelX1_MouseLeave);
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.btnMin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.btnMin.Location = new System.Drawing.Point(368, 3);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(27, 25);
            this.btnMin.Symbol = "57691";
            this.btnMin.SymbolColor = System.Drawing.Color.White;
            this.btnMin.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.btnMin.SymbolSize = 13F;
            this.btnMin.TabIndex = 3;
            this.btnMin.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            this.btnMin.MouseEnter += new System.EventHandler(this.btnMin_MouseEnter);
            this.btnMin.MouseLeave += new System.EventHandler(this.btnMin_MouseLeave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(13, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 14);
            this.label9.TabIndex = 2;
            this.label9.Text = "顺盘服务程序";
            // 
            // btnClosess
            // 
            this.btnClosess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.btnClosess.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.btnClosess.Location = new System.Drawing.Point(401, 4);
            this.btnClosess.Name = "btnClosess";
            this.btnClosess.Size = new System.Drawing.Size(33, 25);
            this.btnClosess.Symbol = "57676";
            this.btnClosess.SymbolColor = System.Drawing.Color.White;
            this.btnClosess.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.btnClosess.SymbolSize = 13F;
            this.btnClosess.TabIndex = 1;
            this.btnClosess.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnClosess.Click += new System.EventHandler(this.btnClosess_Click);
            this.btnClosess.MouseEnter += new System.EventHandler(this.btnClosess_MouseEnter);
            this.btnClosess.MouseLeave += new System.EventHandler(this.btnClosess_MouseLeave);
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.Color.Transparent;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.groupBox2);
            this.panelEx2.Controls.Add(this.panelHysoon);
            this.panelEx2.Controls.Add(this.groupBox3);
            this.panelEx2.Controls.Add(this.groupBox1);
            this.panelEx2.Controls.Add(this.panel2);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(1, 32);
            this.panelEx2.Margin = new System.Windows.Forms.Padding(0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(434, 418);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.None;
            this.panelEx2.Style.BorderWidth = 0;
            this.panelEx2.Style.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelEx2.Style.ForeColor.Color = System.Drawing.Color.White;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 42;
            // 
            // panelHysoon
            // 
            this.panelHysoon.Controls.Add(this.chkEnter);
            this.panelHysoon.Controls.Add(this.label4);
            this.panelHysoon.Controls.Add(this.label3);
            this.panelHysoon.Controls.Add(this.label7);
            this.panelHysoon.Controls.Add(this.label10);
            this.panelHysoon.Controls.Add(this.chkKey);
            this.panelHysoon.Controls.Add(this.txtZF);
            this.panelHysoon.Controls.Add(this.btnStop);
            this.panelHysoon.Controls.Add(this.btnStart);
            this.panelHysoon.Controls.Add(this.txtDelay);
            this.panelHysoon.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHysoon.Location = new System.Drawing.Point(0, 127);
            this.panelHysoon.Name = "panelHysoon";
            this.panelHysoon.Size = new System.Drawing.Size(434, 87);
            this.panelHysoon.TabIndex = 33;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtpinzhong);
            this.groupBox3.Controls.Add(this.btnbatchRead);
            this.groupBox3.Controls.Add(this.btnBatchWrite);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtLeiBie);
            this.groupBox3.Controls.Add(this.txtLei);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 54);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(434, 73);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "信息";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 10;
            this.label12.Text = "品种:";
            this.label12.Visible = false;
            // 
            // txtpinzhong
            // 
            this.txtpinzhong.Location = new System.Drawing.Point(58, 46);
            this.txtpinzhong.MaxLength = 12;
            this.txtpinzhong.Name = "txtpinzhong";
            this.txtpinzhong.Size = new System.Drawing.Size(144, 21);
            this.txtpinzhong.TabIndex = 11;
            this.txtpinzhong.Text = "1";
            this.txtpinzhong.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 8;
            this.label11.Text = "类别:";
            this.label11.Visible = false;
            // 
            // txtLeiBie
            // 
            this.txtLeiBie.Location = new System.Drawing.Point(58, 18);
            this.txtLeiBie.MaxLength = 12;
            this.txtLeiBie.Name = "txtLeiBie";
            this.txtLeiBie.Size = new System.Drawing.Size(144, 21);
            this.txtLeiBie.TabIndex = 9;
            this.txtLeiBie.Text = "1";
            this.txtLeiBie.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.progressBarX);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.lbCount);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 381);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(434, 37);
            this.panel2.TabIndex = 34;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "顺盘服务程序";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openItem,
            this.CloseItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(125, 48);
            // 
            // openItem
            // 
            this.openItem.Name = "openItem";
            this.openItem.Size = new System.Drawing.Size(124, 22);
            this.openItem.Text = "打开面板";
            this.openItem.Click += new System.EventHandler(this.openItem_Click);
            // 
            // CloseItem
            // 
            this.CloseItem.Name = "CloseItem";
            this.CloseItem.Size = new System.Drawing.Size(124, 22);
            this.CloseItem.Text = "退出";
            this.CloseItem.Click += new System.EventHandler(this.CloseItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.ClientSize = new System.Drawing.Size(436, 451);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "顺盘对接收银软件工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.msgGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDelay)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.panelEx2.ResumeLayout(false);
            this.panelHysoon.ResumeLayout(false);
            this.panelHysoon.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX button1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbBaud;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevComponents.DotNetBar.ButtonX button3;
        private System.Windows.Forms.TextBox txtLei;
        private DevComponents.DotNetBar.Controls.DataGridViewX msgGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private DevComponents.DotNetBar.ButtonX btnbatchRead;
        private DevComponents.DotNetBar.ButtonX btnBatchWrite;
        private DevComponents.DotNetBar.StyleManager styleManager;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.ButtonX btnStop;
        private System.Windows.Forms.CheckBox chkEnter;
        private DevComponents.DotNetBar.ButtonX btnStart;
        private System.Windows.Forms.CheckBox chkKey;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown txtZF;
        private System.Windows.Forms.NumericUpDown txtDelay;
        private DevComponents.DotNetBar.Controls.ProgressBarX progressBarX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX btnClosess;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.LabelX btnMin;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem CloseItem;
        private System.Windows.Forms.ToolStripMenuItem openItem;
        private DevComponents.DotNetBar.LabelX btnSet;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtpinzhong;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtLeiBie;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelHysoon;
    }
}

