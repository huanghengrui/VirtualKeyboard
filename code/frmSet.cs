using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VirtualKeyboard
{
    public partial class frmSet : Form
    {
        public bool IsOpen = false;
        IniFiles ini = new IniFiles(Application.StartupPath + @"\Config.ini");

        public frmSet()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            IsOpen = chkKaiJi.Checked;
            this.DialogResult = DialogResult.OK;
        }

        private void btnESC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSet_Load(object sender, EventArgs e)
        {
            if (ini.ExistINIFile())
            {
                chkKaiJi.Checked = Convert.ToBoolean(ini.IniReadValue("Public", "开启开机自启", "true"));
            }
        }

        private void btnClosess_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnClosess_MouseEnter(object sender, EventArgs e)
        {
            btnClosess.SymbolColor = Color.Red;
        }

        private void btnClosess_MouseLeave(object sender, EventArgs e)
        {
            btnClosess.SymbolColor = Color.White;
        }

        private void frmSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.IniWriteValue("Public", "开启开机自启", chkKaiJi.Checked.ToString());
        }
    }
}
