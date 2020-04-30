using DevComponents.DotNetBar;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;

namespace VirtualKeyboard
{
    public partial class frmMain : Form
    {
        private Cmd cmd_buffer = new Cmd();
        public delegate void OutDelegate(string text);
        private bool isWrite = false;
        private bool isHand = false;
        private bool threadStop = false;
        private bool threadSendStop = false;
        private bool threadSend = false;
        private bool IsthreadSend = false;
        public int ThreadCount = 0;
        public int ReThreadCount = 0;
        public string readCardNumber = "";
        public int readCardIndex = 0;
        public int readCardCount = 0;
        public string cardData = "";
        private List<string> cardList = new List<string>();
        private List<string> threadCardList = new List<string>();
        public int delayIndex = 500;
        public string inipath;
        static object locker = new object();
        public static bool IsHysonn = false;
        public const string TITLEMESG = "提示";

        bool isOpened = false;//串口状态标志

        private static bool IsWriteInfo = false;

        IniFiles ini = new IniFiles(Application.StartupPath + @"\Config.ini");
        List<ManualResetEvent> manualEvents = new List<ManualResetEvent>();

        public bool beginMove = false;
        public int currentXPosition = 0;
        public int currentYPosition = 0;

        public const int HTLEFT = 10;
        public const int HTRIGHT = 11;
        public const int HTTOP = 12;
        public const int HTTOPLEFT = 13;
        public const int HTTOPRIGHT = 14;
        public const int HTBOTTOM = 15;
        public const int HTBOTTOMLEFT = 0x10;
        public const int HTBOTTOMRIGHT = 17;

        [DllImport("user32.dll", EntryPoint = "keybd_eventK", SetLastError = true)]
        public static extern void keybd_eventK(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        [DllImport("user32.dll", EntryPoint = "keybd_event", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern void keybd_event(byte vk, byte scan, int flags, int extrainfo);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern short VkKeyScan(char key);

        private byte vk_Shift = 0x10;

        public void PutChr(string putstr)
        {
           
            for (int tmp = 0; tmp < putstr.Length; tmp++)
            {
                if (VkKeyScan(putstr[tmp]) > 256)
                {
                    keybd_event(vk_Shift, 0, 0, 0);
                    keybd_event(Convert.ToByte(putstr[tmp]), 0, 0, 0);
                    keybd_event(Convert.ToByte(putstr[tmp]), 0, 2, 0);
                    keybd_event(vk_Shift, 0, 2, 0);
                }
                else
                {
                    keybd_event((byte)VkKeyScan(putstr[tmp]), 0, 0, 0);
                    keybd_event((byte)VkKeyScan(putstr[tmp]), 0, 2, 0);
                }
            }
        }
        /// <summary>
        /// 设置可以改变窗体大小
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0084:
                    base.WndProc(ref m);
                    Point vPoint = new Point((int)m.LParam & 0xFFFF,
                        (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMLEFT;
                        else m.Result = (IntPtr)HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMRIGHT;
                        else m.Result = (IntPtr)HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)HTBOTTOM;
                    break;
                case 0x0201://鼠标左键按下的消息 
                    m.Msg = 0x00A1;//更改消息为非客户区按下鼠标 
                    m.LParam = IntPtr.Zero;//默认值 
                    m.WParam = new IntPtr(2);//鼠标放在标题栏内 
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        [DllImport("user32", EntryPoint = "GetWindowLong")]
        private static extern int GetWindowLong(IntPtr hwnd, int nIndex);
        [DllImport("user32", EntryPoint = "SetWindowLong")]
        private static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);
        private const int GWL_STYLE = (-16);
        private const int ES_NUMBER = 0x2000;
        protected void SetTextboxNumber(TextBox txtBox)
        {
            int CurrentStyle = GetWindowLong(txtBox.Handle, GWL_STYLE);
            CurrentStyle = CurrentStyle | ES_NUMBER;
            SetWindowLong(txtBox.Handle, GWL_STYLE, CurrentStyle);
            txtBox.ImeMode = ImeMode.Disable;
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void initForm()
        {
            button1.PerformClick();
            
            if (isOpened && !IsHysonn)
            {
                btnStart.PerformClick();
            }
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            RegistryKey keyCom = Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm");
            if (keyCom != null)
            {
                string[] sSubKeys = keyCom.GetValueNames();
                cmbPort.Items.Clear();
                foreach (string sName in sSubKeys)
                {
                    string sValue = (string)keyCom.GetValue(sName);
                    cmbPort.Items.Add(sValue);
                }
                if (cmbPort.Items.Count > 0)
                    cmbPort.SelectedIndex = 0;
            }
            btnStop.Enabled = false;
            btnStart.Enabled = false;
            cmbBaud.SelectedIndex = 2;
            Column1.Width = msgGrid.Width - 20;
            BtnRefresh(false);
            progressBarXShow(false);
            SetTextboxNumber(txtLeiBie);
            SetTextboxNumber(txtpinzhong);
            if (ini.ExistINIFile())
            {
                IsHysonn = Convert.ToBoolean(ini.IniReadValue("Public", "版本", "false"));

                if (IsHysonn)
                {
                    panelHysoon.Visible = false;
                    txtLei.Visible = false;
                    txtLeiBie.Visible = true;
                    txtpinzhong.Visible = true;
                    label11.Visible = true;
                    label12.Visible = true;
                   
                    txtLeiBie.Text = ini.IniReadValue("Public", "类别", "1");
                    txtpinzhong.Text = ini.IniReadValue("Public", "品种", "1");
                }
                else
                {
                    panelHysoon.Visible = true;
                    label11.Visible = false;
                    label12.Visible = false;
                    txtLei.Visible = true;
                    txtLeiBie.Visible = false;
                    txtpinzhong.Visible = false;
                    txtLei.Text = ini.IniReadValue("Public", "信息", "1");
                }

                cmbBaud.SelectedIndex = Convert.ToInt32(ini.IniReadValue("Public", "波特率", "0"));
               
                txtDelay.Value = Convert.ToInt32(ini.IniReadValue("Public", "扫描延时毫秒", "500"));
                txtZF.Value = Convert.ToInt32(ini.IniReadValue("Public", "重复读取过滤时间", "5"));
                chkKey.Checked = Convert.ToBoolean(ini.IniReadValue("Public", "键盘模拟输出", "true"));
                chkEnter.Checked = Convert.ToBoolean(ini.IniReadValue("Public", "输出双回车", "false"));

                int index = Convert.ToInt32(ini.IniReadValue("Public", "串口", "0"));

                if (cmbPort.Items.Count > index)
                    cmbPort.SelectedIndex = index;
            }

            Application.DoEvents();
            initForm();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            msgGrid.Rows.Clear();
            lbCount.Text = "0";
            IsthreadSend = false;
            if (!isOpened)
            {
                serialPort.PortName = cmbPort.Text;
                serialPort.BaudRate = Convert.ToInt32(cmbBaud.Text, 10);
                serialPort.Parity = Parity.Even;
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;
                try
                {
                    serialPort.Open();     //打开串口

                    if (!TestConnet())
                    {
                        try
                        {
                            MessageBoxEx.Show("连接设备失败！", TITLEMESG);
                            serialPort.Close();     //关闭串口
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        button1.Text = "关闭串口";
                        isOpened = true;
                        btnStop.Enabled = false;
                        btnStart.Enabled = true;
                        txtDelay.Enabled = true;
                        txtZF.Enabled = true;
                        BtnRefresh(true);
                    }


                }
                catch
                {
                    MessageBoxEx.Show("串口打开失败！", TITLEMESG);
                }
            }
            else
            {
                try
                {
                    serialPort.Close();     //关闭串口
                    button1.Text = "打开串口";
                    cmbPort.Enabled = true;//打开使能
                    cmbBaud.Enabled = true;
                    isOpened = false;
                    btnStop.Enabled = false;
                    btnStart.Enabled = false;
                    txtDelay.Enabled = true;
                    txtZF.Enabled = true;
                    BtnRefresh(false);
                }
                catch
                {
                    MessageBoxEx.Show("串口关闭失败！", TITLEMESG);
                }
            }

        }

        private bool TestConnet()
        {
            bool ret = false;
            if (serialPort.IsOpen)
            {
                string cmdStr = "D1 89 31 06 36 56";
                byte[] sendData = HexStringToByteArray(cmdStr);
                serialPort.Write(sendData, 0, sendData.Length);
                int intdex = 0;
                Thread.Sleep(500);
                while (true)
                {
                    Thread.Sleep(100);
                    int index = serialPort.BytesToRead;
                  
                    if (index > 0)
                    {
                        byte[] readBuffer = new byte[index];
                        int count = serialPort.Read(readBuffer, 0, index);
                        ret = true;
                        continue;
                    }
                    else
                    {
                        intdex++;
                        if (intdex >= 5)
                            break;
                        continue;
                    }
                }
               
            }
            else
            {
                ret = false;
            }
            return ret;
        }

        public void progressBarXShow(bool state)
        {
            progressBarX.Visible = state;
            label6.Visible = state;
            progressBarX.Value = 0;
            label6.Text = "";
        }
        public void BtnRefresh(bool state)
        {
            btnbatchRead.Enabled = state;
            btnBatchWrite.Enabled = state;
        }

        public bool IsNumber(string index)
        {
            try
            {
                if (Int32.Parse(index) >= 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        private string getCardNo(string caNo)
        {
            char[] charCard = new char[0];
            
            charCard = caNo.ToCharArray();
            if(charCard.Length > 14)
            {
                caNo = charCard[14].ToString() + charCard[15] + charCard[12] +
                charCard[13] + charCard[10] + charCard[11] +
                charCard[8] + charCard[9] + charCard[6] +
                charCard[7] + charCard[4] + charCard[5] +
                charCard[2] + charCard[3] + charCard[0] + charCard[1];
            }
            return caNo;
        }
        private void RefreshMacMsg(string msg)
        {
            try
            {
                if (msg != "")
                {
                    if (!findRows(msg))
                    {
                        msgGrid.Rows.Add();
                        msgGrid[0, msgGrid.RowCount - 1].Value = msg;
                        msgGrid.Rows[msgGrid.RowCount - 1].Selected = true;
                        msgGrid.CurrentCell = msgGrid.Rows[msgGrid.RowCount - 1].Cells[0];
                    }
                }
                lbCount.Text = msgGrid.RowCount.ToString();
            }
            catch
            {
                MessageBoxEx.Show("366", TITLEMESG);
            }
           
        }

        public bool findRows(string s)
        {
            bool ret = false;
            for (int x = 0; x < msgGrid.Rows.Count; x++)
            {
                if (msgGrid[0, x].Value.ToString() == s)
                {
                    ret = true;
                    break;
                }

            }
            return ret;
        }

        private void outText(string text)
        {
            if (msgGrid.InvokeRequired)
            {
                OutDelegate outDelegate = new OutDelegate(outText);
                this.BeginInvoke(outDelegate, new object[] { text });
                return;
            }
            lock(locker)
            {
                string[] tmp = new string[2];
                tmp = text.Split(',');
                switch (tmp[1])
                {
                    case "1":
                        RefreshMacMsg(tmp[0]);
                        break;
                    case "2":
                        if (Convert.ToInt32(tmp[0]) < msgGrid.RowCount)
                        {
                            msgGrid.Rows.Clear();
                            lbCount.Text = "0";
                            Thread.Sleep(100);
                        } 
                        break;
                }
            }
         
        }

        public bool FindThreadCardList(string card)
        {
            bool ret = false;
            try
            {
                for (int i = 0; i < threadCardList.Count; i++)
                {
                    if (threadCardList[i] == card)
                    {
                        ret = true;
                        break;
                    }
                }
            }
            catch
            {
                MessageBoxEx.Show("448", TITLEMESG);
            }
           

            return ret;
        }
        public bool FindCardList(string card)
        {
            bool ret = false;

            for (int i = 0; i < cardList.Count; i++)
            {
                if (cardList[i] == card)
                {
                    ret = true;
                    break;
                }
            }

            return ret;
        }

        private bool FindZero(string data)
        {
            char[] c = data.ToCharArray();
            for(int i=0;i<c.Length;i++)
            {
                if(c[i] != '0')
                {
                    return true;
                }
            }
            return false;
        }

        private bool FindFailChar(string data)
        {
            bool ret = false;
            try
            {
                char[] c = data.ToCharArray();
                for (int i = 0; i < c.Length; i++)
                {
                    if ((c[i] <= '9' && c[i] >= '0') || (c[i] <= 'Z' && c[i] >= 'A') || (c[i] <= 'z' && c[i] >= 'a' || c[i] == '\0'))
                    {
                        ret = true;
                    }
                    else
                    {
                        ret = false;
                        break;
                    }
                }
            }
            catch (Exception E)
            {
                MessageBoxEx.Show(E.Message + "493", TITLEMESG);
                if (serialPort.IsOpen) serialPort.Close();
            }


            return ret;
        }

        /// <summary>
        /// 读取字节数据
        /// </summary>
        private void ThreadRead(Object obj)
        {
            int ii = 0;
            string category = "";
            string readData = "";
            try
            {
                while (serialPort.IsOpen)
                {
                    Thread.Sleep(100);
                    ii = 0;
                    if (!serialPort.IsOpen)
                        break;
                    int index = serialPort.BytesToRead;

                    if (threadStop && index == 0)
                    {
                        threadStop = false;
                        break;
                    }

                    #region 字节读取

                    if (index > 0)
                    {
                        readCardCount = 0;
                        byte[] readBuffer = new byte[index];
                        ii = 1;
                        serialPort.Read(readBuffer, 0, index);
                        readData = byteToHexStr(readBuffer);
                        ii = 2;
                        if (readData.IndexOf("5AA58000") >= 0)
                        {
                            MessageBoxEx.Show("接受指令通讯包分析错误！", TITLEMESG);
                            continue;
                        }
                        else if (readData.IndexOf("5AA58100") >= 0)
                        {
                            MessageBoxEx.Show("连接设备错误！", TITLEMESG);
                            continue;
                        }
                        else if (readData.IndexOf("5AA58200") >= 0)
                        {
                            MessageBoxEx.Show("固件和软件版本错误！", TITLEMESG);
                            continue;
                        }

                        if (isHand && readData.Length > 3)
                        {
                            if (readData.IndexOf("02") != 0)
                                continue;

                            readCardNumber = readData.ToString().Substring(2, 2);
                            if (readCardNumber == "00")
                            {
                                outText("0" + ",2");
                                continue;
                            }
                            readCardIndex = Convert.ToInt32(readCardNumber, 16);
                            cardData = "";
                            threadSend = false;
                            isHand = false;
                        }
                       
                        cardData = cardData + readData;
                        if (cardData.Length > readCardIndex * 40 && cardData.Substring(cardData.Length-2,2) == "03")
                        {
                            threadSend = true;
                            outText(readCardIndex + ",2");
                            ii = 4;
                            for (int i = 0; i < readCardIndex; i++)
                            {
                                string cardNo = "";
                                ThreadCount = 0;
                                cardNo = cardData.Substring(6 + 40 * i, 16);
                                cardNo = getCardNo(cardNo);
                                if (cardNo.IndexOf("E") != 0)
                                    continue;
                                ii = 41;
                                if((6 + 16 + 40 * i + 24) > cardData.Length)
                                {
                                    break;
                                }

                                category = cardData.Substring(6 + 16 + 40 * i, 24);
                                if (!FindZero(category))
                                    continue;

                                category = ConvertHexToString(category);
                                ii = 5;
                                string Msg = "卡号：" + cardNo + "  信息：" + category;
                                outText(Msg + ",1");

                                if (!FindFailChar(category))
                                    continue;
                                ii = 6;
                                if (FindThreadCardList(Msg))
                                {
                                    continue;
                                }

                                threadCardList.Add(Msg);
                                ii = 7;
                                if (chkKey.Checked)
                                {
                                    if (chkKey.InvokeRequired)
                                    {
                                        chkKey.Invoke(new Action<String>(s =>
                                        {
                                            try
                                            {
                                                PutChr(s);
                                                Thread.Sleep(400);
                                                keybd_event((byte)Keys.Enter, 0, 0, 0);
                                                if (chkEnter.Checked)
                                                {
                                                    Thread.Sleep(400);
                                                    keybd_event((byte)Keys.Enter, 0, 0, 0);
                                                }
                                             
                                            }
                                            catch
                                            {

                                            }

                                        }), category);
                                    }
                                }

                            }
                        }
                    }
                    else
                    {
                        threadSend = true;
                    }

                    #endregion
                }
            }
            catch(Exception E)
            {
                MessageBoxEx.Show(E.Message+"615"+"  "+ii+ readData);
                if (serialPort.IsOpen) serialPort.Close();
            }
         
          
        }

        private int IsNum(string num)
        {
            int ret = 0;
            try
            {
                ret = int.Parse(num, System.Globalization.NumberStyles.HexNumber);
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        private void hysoon_DataReceived()
        {
            Thread.Sleep(500);
            string readData = "";
            int bsize = 0;
            while (serialPort.IsOpen)
            {
                Thread.Sleep(100);
                if (IsWriteInfo) continue;
                if(serialPort.IsOpen)
                bsize = serialPort.BytesToRead;
                if (bsize <= 0)
                {
                    break;
                }
                else
                {
                    byte[] tem = new byte[bsize];
                    serialPort.Read(tem, 0, bsize);
                    readData = byteToHexStr(tem);

                    if (readData.IndexOf("5AA58000") >= 0)
                    {
                        MessageBoxEx.Show("接受指令通讯包分析错误！", TITLEMESG);
                        return;
                    }
                    else if (readData.IndexOf("5AA58100") >= 0)
                    {
                        MessageBoxEx.Show("连接设备错误！", TITLEMESG);
                        return;
                    }
                    else if (readData.IndexOf("5AA58200") >= 0)
                    {
                        MessageBoxEx.Show("固件和软件版本错误！", TITLEMESG);
                        return;
                    }

                    if (isHand && readData.Length > 3)
                    {
                        if (readData.IndexOf("02") != 0)
                            continue;
                        readCardNumber = readData.Substring(2, 2);
                        if (readCardNumber == "00")
                        {
                            outText("0" + ",2");
                            continue;
                        }
                        readCardIndex = Convert.ToInt32(readCardNumber, 16);
                        cardData = "";
                        isHand = false;
                    }
                   
                    cardData = cardData + readData;
                    if (cardData.Length > readCardIndex * 40  && cardData.Substring(cardData.Length - 2, 2) == "03")
                    {
                        for (int i = 0; i < readCardIndex; i++)
                        {
                            string cardNo = cardData.Substring(6 + 40 * i, 16);
                            cardNo = getCardNo(cardNo);
                           // cardList.Add(cardNo);
                            //outText(cardNo + ",1");
                            string varieties = cardData.Substring(6 + 16 + 40 * i, 8);
                            string category = cardData.Substring(6 + 24 + 40 * i, 8);
                            // string money = cardData.Substring(6 + 36 + 40 * i, 4);
                            // int num = Convert.ToInt32(money, 16);
                            // double moneys = (double)num / 100;
                            int Cat = IsNum(category);
                            int Var = IsNum(varieties);

                            if (!isWrite && Cat > 0 && Var > 0)
                                outText("卡号：" + cardNo + "  类别：" + Cat + "    品种：" + Var + ",1");

                            if (FindCardList(cardNo))
                                continue;
                            cardList.Add(cardNo);
                        }
                    }
                }

            }
        }

        private void post_DataReceived()
        {
            Thread.Sleep(Convert.ToInt32(txtDelay.Value - 100));
            string readData = "";
            int index = 0;
            while (serialPort.IsOpen)
            {
                Thread.Sleep(200);
                int bsize = serialPort.BytesToRead;
                if (bsize <= 0)
                {
                    index++;
                    if(index >= 5 )
                    {
                        break;
                    }
                    continue;
                }
                else
                {
                    byte[] tem = new byte[bsize];
                    serialPort.Read(tem, 0, bsize);
                    readData = byteToHexStr(tem);

                    if (readData.IndexOf("5AA58000") >= 0)
                    {
                        MessageBoxEx.Show("接受指令通讯包分析错误！", TITLEMESG);
                        return;
                    }
                    else if (readData.IndexOf("5AA58100") >= 0)
                    {
                        MessageBoxEx.Show("连接设备错误！", TITLEMESG);
                        return;
                    }
                    else if (readData.IndexOf("5AA58200") >= 0)
                    {
                        MessageBoxEx.Show("固件和软件版本错误！", TITLEMESG);
                        return;
                    }

                    if (isHand && readData.Length > 3)
                    {
                        if (readData.IndexOf("02") != 0)
                            continue;
                        readCardNumber = readData.Substring(2, 2);
                        if (readCardNumber == "00")
                        {
                            outText("0" + ",2");
                            continue;
                        } 
                        readCardIndex = Convert.ToInt32(readCardNumber, 16);
                        cardData = "";
                        isHand = false;
                    }
                   
                    cardData = cardData + readData;
                    if (cardData.Length > readCardIndex * 40 && cardData.Substring(cardData.Length - 2, 2) == "03")
                    {
                        for (int i = 0; i < readCardIndex; i++)
                        {
                            string cardNo = "";
                            cardNo = cardData.Substring(6 + 40 * i, 16);
                            cardNo = getCardNo(cardNo);

                            if (!isWrite)
                            {
                                string category = cardData.Substring(6 + 16 + 40 * i, 24);
                                category = ConvertHexToString(category);
                                string Msg = "卡号：" + cardNo + "  信息：" + category;
                                outText(Msg + ",1");
                            }
                            if (FindCardList(cardNo))
                                continue;
                            cardList.Add(cardNo);
                        }
                    }
                }
               
            }
        }

   
        private byte[] Add_CRC_code(byte[] cmd_buf, int cmd_len)
        {
            uint current_crc_value;

            current_crc_value = 0xFFFF; //PRESET_VALUE;
            for (int i = 0; i < cmd_buf.Length; i++)
            {
                current_crc_value ^= ((uint)cmd_buf[i]);
                for (int j = 0; j < 8; j++)
                {
                    if ((current_crc_value & 0x0001) > 0)
                        current_crc_value = (current_crc_value >> 1) ^ 0x8408;  // x^16 + x^12 + x^5 + 1
                    else
                        current_crc_value = (current_crc_value >> 1);
                }
            }
            byte[] buf = new byte[cmd_len + 2];
            for (int i = 0; i < cmd_len; i++)
            {
                buf[i] = cmd_buf[i];
            }
            current_crc_value = ~current_crc_value;
            buf[cmd_len++] = (byte)(current_crc_value & 0xFF);
            current_crc_value >>= 8;
            buf[cmd_len++] = (byte)(current_crc_value & 0xFF);

            return buf;
        }

        public static byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        //字节数组转16进制字符串
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            msgGrid.Rows.Clear();
        }
        private string Check_sum(string str)
        {
            byte[] sendData = HexStringToByteArray(str);
            uint num = 0;
            for (int i = 0; i < sendData.Length; i++)
            {
                num = num + sendData[i];
            }
            str = num.ToString("X4");
            str = str.Substring(2);
            return str;
        }

        private string DataCheck_sum(string str)
        {
            byte[] sendData = HexStringToByteArray(str);
            uint num = 0;
            for (int i = 0; i < sendData.Length; i++)
            {
                num = num + sendData[i];
            }
            str = Convert.ToString(num, 16);
            if (str.Length > 2)
                str = str.Substring(1);
            else if (str.Length < 2)
                str = "0" + str;
            return str;
        }

        private string getUID(string str)
        {
            char[] msg = str.ToCharArray();
            str = "";
            for (int i = 0; i < msg.Length; i++)
            {
                str = str + msg[i];
                if (i % 2 != 0)
                    str = str + " ";
            }
            return str;
        }

        private string getData(string str)
        {
            byte[] sendData = HexStringToByteArray(str);
            byte[] msg = Add_CRC_code(sendData, sendData.Length);
            str = getUID(byteToHexStr(msg));
            return str;
        }

        private void msgGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnbatchRead_Click(object sender, EventArgs e)
        {
            BtnRefresh(false);
            IsWriteInfo = false;
            try
            {
                if (serialPort.IsOpen)
                {
                
                    cardList.Clear();
                    msgGrid.Rows.Clear();
                    string cmdStr = "D1 89 31 06 36 56";
                    byte[] sendData = HexStringToByteArray(cmdStr);
                    isHand = true;
                    Thread.Sleep(200);
                    serialPort.Write(sendData, 0, sendData.Length);

                    if(IsHysonn)
                    {
                        hysoon_DataReceived();
                    }
                    else
                    {
                        post_DataReceived();
                    }
                    
                }
                else
                {
                    MessageBoxEx.Show("串口未打开", TITLEMESG);
                }
            }
            catch
            {

            }
            finally
            {
                BtnRefresh(true);
            }
            
        }

        public string ConvertStringToHex(string strASCII, string separator = null)
        {
            StringBuilder sbHex = new StringBuilder();
            foreach (char chr in strASCII)
            {
                sbHex.Append(String.Format("{0:X2}", Convert.ToInt32(chr)));
                sbHex.Append(separator ?? string.Empty);
            }
            return sbHex.ToString();
        }

        public string ConvertHexToString(string HexValue, string separator = null)
        {
            HexValue = string.IsNullOrEmpty(separator) ? HexValue : HexValue.Replace(string.Empty, separator);
            StringBuilder sbStrValue = new StringBuilder();
            while (HexValue.Length > 0)
            {
                sbStrValue.Append(Convert.ToChar(Convert.ToUInt32(HexValue.Substring(0, 2), 16)).ToString());
                HexValue = HexValue.Substring(2);
            }
            return sbStrValue.ToString();
        }

        private string getSenData(string data,int index)
        {
            string newData = "";
            try
            {
                if (data.Length - (index - 1) * 8 >= 8)
                {
                    newData = data.Substring((index - 1) * 8, 8);
                }
                else
                {
                    newData = data.Substring((index - 1) * 8, data.Length - (index - 1) * 8);
                }
            }
            catch
            {

            }
            finally
            {
                if (newData == "")
                    newData = "0";
                if(newData.Length < 8)
                    newData = newData + 0.ToString("X"+(8 - newData.Length) +""); 
            }
            return newData;
        }

        public void SendReadData()
        {
            int index = 0;
            while (true)
            {
                Thread.Sleep(100);
                int length = serialPort.BytesToRead;
                byte[] readBuffer = new byte[length];
                int count = serialPort.Read(readBuffer, 0, length);
                if (count > 0)
                {
                    break;
                }
                else
                {
                    index++;
                    if (index > 5)
                        break;
                    continue;
                }
            }
        }

        private void HysoonYun()
        {
            try
            {
                msgGrid.Rows.Clear();
                if (txtLei.Text == "")
                {
                    MessageBox.Show("请输入信息!");
                    txtLei.Focus();
                    return;
                }
                if (serialPort.IsOpen)
                {
                    cardList.Clear();
                    string cmdStr = "D1 89 31 06 36 56";
                    byte[] sendData = HexStringToByteArray(cmdStr);
                    isWrite = true;
                    serialPort.Write(sendData, 0, sendData.Length);
                    isHand = true;
                   
                    post_DataReceived();
                    
                    if (cardList.Count == 0)
                    {
                        MessageBoxEx.Show("未读到卡号!", TITLEMESG);
                        return;
                    }
                    for (int a = 0; a < cardList.Count; a++)
                    {
                        string data = "";
                        for (int i = 1; i < 3; i++)
                        {
                            string UID = getUID(getCardNo(cardList[a].Replace(" ", "")));
                            string blockNumber = i.ToString("X2");

                            switch (i)
                            {
                                case 1:
                                    data = Convert.ToInt32(txtpinzhong.Text.ToString()).ToString("X8");
                                    break;
                                case 2:
                                    data = Convert.ToInt32(txtLei.Text.ToString()).ToString("X8");
                                    break;
                            }

                            cmd_buffer = new Cmd();
                            cmd_buffer.Command1 = "07";
                            cmd_buffer.Data1 = getData("23 21 " + UID + " " + blockNumber + " " + data);
                            string tmp = cmd_buffer.Data1.Replace(" ", "");
                            cmd_buffer.Datalen1 = (tmp.Length / 2).ToString("X2");

                            cmd_buffer.Checksum1 = Check_sum(cmd_buffer.Header1.Trim() + " " + cmd_buffer.Command1.Trim() + " " + cmd_buffer.Datalen1.Trim());
                            cmd_buffer.Data_checksum1 = DataCheck_sum(cmd_buffer.Data1.Trim());

                            sendData = HexStringToByteArray(cmd_buffer.Buf());
                            Thread.Sleep(10);
                            serialPort.Write(sendData, 0, sendData.Length);
                            SendReadData();
                        }
                        label6.Text = (a + 1) + "/" + cardList.Count + "  [" + cardList[a] + "]";
                        progressBarX.Value = (a + 1) * 100 / cardList.Count;
                        Application.DoEvents();
                    }
                    cardList.Clear();
                    cmdStr = "D1 89 31 06 36 56";
                    sendData = HexStringToByteArray(cmdStr);
                    IsWriteInfo = false;
                    isWrite = false;
                    isHand = true;
                    Thread.Sleep(200);
                    serialPort.Write(sendData, 0, sendData.Length);
                    hysoon_DataReceived();
                }
                else
                {
                    MessageBoxEx.Show("串口未打开", TITLEMESG);
                }
            }
            catch
            {
              
            }
        }

        private void btnBatchWrite_Click(object sender, EventArgs e)
        {
            BtnRefresh(false);
            progressBarXShow(true);
            IsWriteInfo = true;
            try
            {
                if (IsHysonn)
                {
                    HysoonYun();
                    return;
                }
                msgGrid.Rows.Clear();
                if (txtLei.Text=="")
                {
                    MessageBox.Show("请输入信息!");
                    txtLei.Focus();
                    return;
                }
                if (serialPort.IsOpen)
                {
                    cardList.Clear();
                    string cmdStr = "D1 89 31 06 36 56";
                    byte[] sendData = HexStringToByteArray(cmdStr);
                    isWrite = true;
                    Thread.Sleep(200);
                    serialPort.Write(sendData, 0, sendData.Length);
                    isHand = true;
                    post_DataReceived();
                    if(cardList.Count==0)
                    {
                        MessageBox.Show("未读到卡号!");
                        return;
                    }
                    for (int a = 0; a < cardList.Count; a++)
                    {
                       
                        string data = ConvertStringToHex(txtLei.Text.Trim());

                        string blockData = "";

                        for (int i = 1; i < 4; i++)
                        {
                            string UID = getUID(getCardNo(cardList[a].Replace(" ", "")));
                            string blockNumber = i.ToString("X2");
                            blockData = getSenData(data, i);
                            blockData = getUID(blockData);
                            cmd_buffer = new Cmd();
                            cmd_buffer.Command1 = "07";
                            cmd_buffer.Data1 = getData("23 21 " + UID + " " + blockNumber + " " + blockData);
                            string tmp = cmd_buffer.Data1.Replace(" ", "");
                            cmd_buffer.Datalen1 = (tmp.Length / 2).ToString("X2");

                            cmd_buffer.Checksum1 = Check_sum(cmd_buffer.Header1.Trim() + " " + cmd_buffer.Command1.Trim() + " " + cmd_buffer.Datalen1.Trim());
                            cmd_buffer.Data_checksum1 = DataCheck_sum(cmd_buffer.Data1.Trim());

                            sendData = HexStringToByteArray(cmd_buffer.Buf());
                            Thread.Sleep(10);
                            serialPort.Write(sendData, 0, sendData.Length);
                            SendReadData();
                        }
                        label6.Text = (a + 1) + "/" + cardList.Count + "  [" + cardList[a] + "]";
                        progressBarX.Value = (a + 1) * 100 / cardList.Count;
                        Application.DoEvents();
                    }
                    cardList.Clear();
                    cmdStr = "D1 89 31 06 36 56";
                    sendData = HexStringToByteArray(cmdStr);
                    isWrite = false;
                    isHand = true;
                    Thread.Sleep(200);
                    serialPort.Write(sendData, 0, sendData.Length);
                    post_DataReceived();
                }
                else
                {
                    MessageBoxEx.Show("串口未打开", TITLEMESG);
                }
            }
            catch
            {

            }
            finally
            {
                BtnRefresh(true);
                progressBarXShow(false);
            }
           
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="obj"></param>
        private void ThreadWrite(object obj)
        {
           try
            {
                while (serialPort.IsOpen)
                {
                    if (threadSendStop)
                    {
                        threadSendStop = false;
                        break;
                    }

                    if (threadSend)
                    {
                        threadSend = false;
                        string cmdStr = "D1 89 31 06 36 56";
                        byte[] sendData = HexStringToByteArray(cmdStr);
                        isHand = true;
                        serialPort.Write(sendData, 0, sendData.Length);
                        Thread.Sleep(delayIndex);
                    }
                }
            }
            catch(Exception E)
            {
                MessageBoxEx.Show(E.Message+"1233");
                if (serialPort.IsOpen) serialPort.Close();
            }
           
           
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.IniWriteValue("Public", "串口", cmbPort.SelectedIndex.ToString());
            ini.IniWriteValue("Public", "波特率", cmbBaud.SelectedIndex.ToString());
            ini.IniWriteValue("Public", "信息", txtLei.Text.Trim());
            ini.IniWriteValue("Public", "品种", txtpinzhong.Text.Trim());
            ini.IniWriteValue("Public", "类别", txtLeiBie.Text.Trim());
            ini.IniWriteValue("Public", "键盘模拟输出", chkKey.Checked.ToString());
            ini.IniWriteValue("Public", "输出双回车", chkEnter.Checked.ToString());
            ini.IniWriteValue("Public", "扫描延时毫秒", txtDelay.Text.Trim());
            ini.IniWriteValue("Public", "重复读取过滤时间", txtZF.Text.Trim());
            // 注意判断关闭事件reason来源于窗体按钮，否则用菜单退出时无法退出!
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //取消"关闭窗口"事件
                e.Cancel = true;
                //使关闭时窗口向右下角缩小的效果
                this.WindowState = FormWindowState.Minimized;
                this.notifyIcon.Visible = true;
                this.Hide();
                return;
            }

            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
          

            e.Cancel = false;
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            start();
        }

        public void start()
        {
            threadCardList.Clear();
            msgGrid.Rows.Clear();
            threadSend = true;
            delayIndex = Convert.ToInt32(txtDelay.Value);
            btnEnableb(false);
           
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadRead), 1);
           
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadWrite), 1);
           
        }

        private void btnWork_Click(object sender, EventArgs e)
        {
            btnEnableb(true);
        }

        private void btnEnableb(bool state)
        {
            IsthreadSend = !state;
            txtDelay.Enabled = state;
            threadStop = state;
            threadSendStop = state;
            btnStop.Enabled = !state;
            btnStart.Enabled = state;
            txtZF.Enabled = state;
            btnbatchRead.Enabled = state;
            btnBatchWrite.Enabled = state;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ThreadCount++;
            if (ThreadCount >= txtZF.Value)
            {
                ThreadCount = 0;
                threadCardList.Clear();
            }
            if(IsthreadSend)
            {
                ReThreadCount++;
                if (ReThreadCount >= 300)
                {
                    if(ReThreadCount == 300)
                    {
                        threadStop = true;
                        threadSendStop = true;
                        threadSend = true;
                    }
                    if (!threadSendStop && !threadStop)
                    {
                        RemoveAllCache();
                        threadSend = true;   
                        ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadRead), 1);
                        ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadWrite), 1);
                        ReThreadCount = 0;
                    }
                }
            }
           
        }

        /// <summary>
        /// 移除全部缓存
        /// </summary>
        public static void RemoveAllCache()
        {
            System.Web.Caching.Cache _cache = HttpRuntime.Cache;
            IDictionaryEnumerator CacheEnum = _cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                _cache.Remove(CacheEnum.Key.ToString());
            }
        }

        private void txtLei_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar <= '9' && e.KeyChar >= '0' || e.KeyChar <= 'Z' && e.KeyChar >= 'A' || e.KeyChar <= 'z' && e.KeyChar >= 'a' || e.KeyChar == 8 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnClosess_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            btnClosess.Location = new Point(this.Width- btnClosess.Width,3);
            label9.Location = new Point(10, 8);
            btnMin.Location = new Point(this.Width - btnClosess.Width- btnMin.Width-5, 3);

            if(this.WindowState ==　FormWindowState.Minimized)
            {
                this.Visible = false;
                this.notifyIcon.Visible = true;
            }
            
            Application.DoEvents();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void panTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                beginMove = true;
                currentXPosition = MousePosition.X;//鼠标的x坐标为当前窗体左上角x坐标
                currentYPosition = MousePosition.Y;//鼠标的y坐标为当前窗体左上角y坐标
            }
        }

        private void panTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (beginMove && e.Button == MouseButtons.Left)
            {
                int lx = MousePosition.X - currentXPosition;
                int ty = MousePosition.Y - currentYPosition;
                if (Math.Abs(lx) > 10 || Math.Abs(ty) > 10)
                {
                    if (this.WindowState == FormWindowState.Maximized)
                    {
                        this.WindowState = FormWindowState.Normal;
                    }
                    this.Left += lx;//根据鼠标x坐标确定窗体的左边坐标x
                    this.Top += ty;//根据鼠标的y坐标窗体的顶部，即Y坐标
                    currentXPosition = MousePosition.X;
                    currentYPosition = MousePosition.Y;
                }

            }
        }

        private void panTitle_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentXPosition = 0; //设置初始状态
                currentYPosition = 0;
                beginMove = false;
            }
        }

        private void btnClosess_MouseEnter(object sender, EventArgs e)
        {
            btnClosess.SymbolColor = Color.Red;
        }
      
        private void btnClosess_MouseLeave(object sender, EventArgs e)
        {
            btnClosess.SymbolColor = Color.White;
        }

        private void btnMin_MouseEnter(object sender, EventArgs e)
        {
            btnMin.SymbolColor = Color.Gainsboro;
        }

        private void btnMin_MouseLeave(object sender, EventArgs e)
        {
            btnMin.SymbolColor = Color.White;
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible)
            {
                this.WindowState = FormWindowState.Minimized;
                this.notifyIcon.Visible = true;
                this.Hide();
            }
            else
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }

        private void CloseItem_Click(object sender, EventArgs e)
        {
            this.notifyIcon.Visible = false;
            this.Close();
            this.Dispose();
            ini.IniWriteValue("Public", "串口", cmbPort.SelectedIndex.ToString());
            ini.IniWriteValue("Public", "波特率", cmbBaud.SelectedIndex.ToString());
            ini.IniWriteValue("Public", "信息", txtLei.Text.Trim());
            ini.IniWriteValue("Public", "品种", txtpinzhong.Text.Trim());
            ini.IniWriteValue("Public", "类别", txtLeiBie.Text.Trim());
            ini.IniWriteValue("Public", "键盘模拟输出", chkKey.Checked.ToString());
            ini.IniWriteValue("Public", "输出双回车", chkEnter.Checked.ToString());
            ini.IniWriteValue("Public", "扫描延时毫秒", txtDelay.Text.Trim());
            ini.IniWriteValue("Public", "重复读取过滤时间", txtZF.Text.Trim());
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void openItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void labelX1_Click(object sender, EventArgs e)
        {
            frmSet frm = new frmSet();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                SetMeStart(frm.IsOpen);
            }
        }

        private void labelX1_MouseLeave(object sender, EventArgs e)
        {
            btnSet.SymbolColor = Color.White;
        }

        private void labelX1_MouseEnter(object sender, EventArgs e)
        {
            btnSet.SymbolColor = Color.Gainsboro;
        }

        /// <summary>
        /// 将本程序设为开启自启
        /// </summary>
        /// <param name="onOff">自启开关</param>
        /// <returns></returns>
        public bool SetMeStart(bool onOff)
        {
            bool isOk = false;
            string appName = Process.GetCurrentProcess().MainModule.ModuleName;
            string appPath = Process.GetCurrentProcess().MainModule.FileName;
            isOk = SetAutoStart(onOff, appName, appPath);
            return isOk;
        }

        /// <summary>
        /// 将应用程序设为或不设为开机启动
        /// </summary>
        /// <param name="onOff">自启开关</param>
        /// <param name="appName">应用程序名</param>
        /// <param name="appPath">应用程序完全路径</param>
        public bool SetAutoStart(bool onOff, string appName, string appPath)
        {
            bool isOk = true;
            //如果从没有设为开机启动设置到要设为开机启动
            if (!IsExistKey(appName) && onOff)
            {
                isOk = SelfRunning(onOff, appName, @appPath);
            }
            //如果从设为开机启动设置到不要设为开机启动
            else if (IsExistKey(appName) && !onOff)
            {
                isOk = SelfRunning(onOff, appName, @appPath);
            }
            return isOk;
        }

        /// <summary>
        /// 判断注册键值对是否存在，即是否处于开机启动状态
        /// </summary>
        /// <param name="keyName">键值名</param>
        /// <returns></returns>
        private bool IsExistKey(string keyName)
        {
            try
            {
                bool _exist = false;
                RegistryKey local = Registry.LocalMachine;
                RegistryKey runs = local.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                if (runs == null)
                {
                    RegistryKey key2 = local.CreateSubKey("SOFTWARE");
                    RegistryKey key3 = key2.CreateSubKey("Microsoft");
                    RegistryKey key4 = key3.CreateSubKey("Windows");
                    RegistryKey key5 = key4.CreateSubKey("CurrentVersion");
                    RegistryKey key6 = key5.CreateSubKey("Run");
                    runs = key6;
                }
                string[] runsName = runs.GetValueNames();
                foreach (string strName in runsName)
                {
                    if (strName.ToUpper() == keyName.ToUpper())
                    {
                        _exist = true;
                        return _exist;
                    }
                }
                return _exist;

            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 写入或删除注册表键值对,即设为开机启动或开机不启动
        /// </summary>
        /// <param name="isStart">是否开机启动</param>
        /// <param name="exeName">应用程序名</param>
        /// <param name="path">应用程序路径带程序名</param>
        /// <returns></returns>
        private bool SelfRunning(bool isStart, string exeName, string path)
        {
            try
            {
                RegistryKey local = Registry.LocalMachine;
                RegistryKey key = local.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                if (key == null)
                {
                    local.CreateSubKey("SOFTWARE//Microsoft//Windows//CurrentVersion//Run");
                }
                //若开机自启动则添加键值对
                if (isStart)
                {
                    key.SetValue(exeName, path);
                    key.Close();
                }
                else//否则删除键值对
                {
                    string[] keyNames = key.GetValueNames();
                    foreach (string keyName in keyNames)
                    {
                        if (keyName.ToUpper() == exeName.ToUpper())
                        {
                            key.DeleteValue(exeName);
                            key.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string ss = ex.Message;
                return false;
                //throw;
            }

            return true;
        }

     
     
    }
    class Cmd
    {
        private string Header = "55 AA";
        private string Command = "00";
        private string Datalen = "00";
        private string Checksum = "00";
        private string Data = "00";
        private string Data_checksum = "00";

        public string Header1
        {
            get { return Header; }
            set { Header = value; }
        }

        public string Command1
        {
            get { return Command; }
            set { Command = value; }
        }

        public string Datalen1
        {
            get { return Datalen; }
            set { Datalen = value; }
        }

        public string Checksum1
        {
            get { return Checksum; }
            set { Checksum = value; }
        }

        public string Data1
        {
            get { return Data; }
            set { Data = value; }
        }

        public string Data_checksum1
        {
            get { return Data_checksum; }
            set { Data_checksum = value; }
        }

        public string Buf()
        {
            string str = Header1.Trim() + " " + Command1.Trim() + " " + Datalen1.Trim() + " " + Checksum1.Trim() + " " + Data1.Trim() + " " + Data_checksum1.Trim();
            str = str.ToUpper();
            return str;
        }
    }
}
