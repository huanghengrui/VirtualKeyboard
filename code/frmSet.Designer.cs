namespace VirtualKeyboard
{
    partial class frmSet
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.label9 = new System.Windows.Forms.Label();
            this.btnClosess = new DevComponents.DotNetBar.LabelX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnESC = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.chkKaiJi = new System.Windows.Forms.CheckBox();
            this.panelEx1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.Color.Transparent;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.label9);
            this.panelEx1.Controls.Add(this.btnClosess);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(1, 1);
            this.panelEx1.Margin = new System.Windows.Forms.Padding(0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(258, 32);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.None;
            this.panelEx1.Style.BorderWidth = 0;
            this.panelEx1.Style.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelEx1.Style.ForeColor.Color = System.Drawing.Color.White;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(13, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 14);
            this.label9.TabIndex = 2;
            this.label9.Text = "设置";
            // 
            // btnClosess
            // 
            this.btnClosess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.btnClosess.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.btnClosess.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClosess.Location = new System.Drawing.Point(224, 4);
            this.btnClosess.Name = "btnClosess";
            this.btnClosess.Size = new System.Drawing.Size(29, 25);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnESC);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.chkKaiJi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 110);
            this.panel1.TabIndex = 40;
            // 
            // btnESC
            // 
            this.btnESC.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnESC.Location = new System.Drawing.Point(176, 74);
            this.btnESC.Name = "btnESC";
            this.btnESC.Size = new System.Drawing.Size(57, 25);
            this.btnESC.TabIndex = 12;
            this.btnESC.Text = "取消";
            this.btnESC.Click += new System.EventHandler(this.btnESC_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.Location = new System.Drawing.Point(99, 74);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(57, 25);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkKaiJi
            // 
            this.chkKaiJi.AutoSize = true;
            this.chkKaiJi.Location = new System.Drawing.Point(75, 31);
            this.chkKaiJi.Name = "chkKaiJi";
            this.chkKaiJi.Size = new System.Drawing.Size(108, 16);
            this.chkKaiJi.TabIndex = 0;
            this.chkKaiJi.Text = "开启开机自启动";
            this.chkKaiJi.UseVisualStyleBackColor = true;
            // 
            // frmSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.ClientSize = new System.Drawing.Size(260, 144);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSet";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSet_FormClosing);
            this.Load += new System.EventHandler(this.frmSet_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.LabelX btnClosess;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkKaiJi;
        private DevComponents.DotNetBar.ButtonX btnESC;
        private DevComponents.DotNetBar.ButtonX btnOK;
    }
}