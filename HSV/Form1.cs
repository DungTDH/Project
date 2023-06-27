using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Threading;
using System.Collections;
using System.IO;

namespace HSV
{
    public partial class Form1 : Form
    {

        //Frelds
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        Thread alarmThread;
        bool _runAlarmThread = true;
        object lockobject = new object();
        bool[] alarmBitArr = new bool[500];

        //Contructor

        public Form1()
        {
            InitializeComponent();

            MCAlarm.LoadAlarmTotal();
            MCAlarm.LoadAlarmHistoryFrequency();

            alarmThread = new Thread(AlarmThread);
            alarmThread.Start();

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            ReadDataProduct();

            //Form
            //this.Text = string.Empty;
            //this.ControlBox = false;
            //this.DoubleBuffered = true;
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

        }

        void AlarmThread()
        {
            while (_runAlarmThread)
            {
                lock (lockobject)
                {
                    Thread.Sleep(50);

                    if (Mitsubishi.Instance().PLC_Connect == true)
                    {
                        if (Mitsubishi.Instance().ReadAlarmStatus("D100", ref alarmBitArr))
                        {
                            int id_Alarm = 0;

                            for (int i = 0; i < MCAlarm.alarmCount; i++)
                            {
                                if (alarmBitArr[i] && !MCAlarm.AlarmExist)
                                {
                                    id_Alarm = i+1;
                                    MCAlarm.AlarmExist = true;
                                    string sAlarmText = "";
                                    foreach (Alarm al in MCAlarm.mAlarmListTotal)
                                    {
                                        if (al.ID == id_Alarm)
                                            sAlarmText = al.AlarmName;
                                    }
                                    Forms.AlarmPopup frmAlarmPopup = new Forms.AlarmPopup();
                                    frmAlarmPopup.SetInfo(id_Alarm, sAlarmText);
                                    frmAlarmPopup.ShowDialog();
                                    break;
                                }
                            }

                            bool bAlarmNotExist = true;
                            for (int i = 0; i < MCAlarm.alarmCount; i++)
                            {
                                if (alarmBitArr[i])
                                {
                                    bAlarmNotExist = false;
                                    if(!CheckExistAlarm(i+1,MCAlarm.mCurAlarmList))
                                    {
                                        Alarm newAlarm = GetAlarm(i + 1, MCAlarm.mAlarmListTotal);
                                        newAlarm.TimeSet = DateTime.Now;
                                        MCAlarm.mCurAlarmList.Add(newAlarm);
                                    }    
                                }
                                else
                                {
                                    if (CheckExistAlarm(i + 1, MCAlarm.mCurAlarmList))
                                    {
                                        Alarm resetAlarm = new Alarm();
                                        Alarm tempAlarm = MCAlarm.mCurAlarmList[MCAlarm.mCurAlarmList.FindIndex(a => a.ID == i + 1)];
                                        MCAlarm.mCurAlarmList.RemoveAt(MCAlarm.mCurAlarmList.FindIndex(a => a.ID == i + 1));

                                        resetAlarm.ID = tempAlarm.ID;
                                        resetAlarm.AlarmName = tempAlarm.AlarmName;
                                        resetAlarm.TimeSet = tempAlarm.TimeSet;
                                        resetAlarm.TimeReset = DateTime.Now;
                                        resetAlarm.Count = 1;
                                        resetAlarm.TotalTime = (int)(resetAlarm.TimeReset - resetAlarm.TimeSet).TotalSeconds;
                                        MCAlarm.mListAlarmHistory.Add(resetAlarm);
                                        MCAlarm.UpdateFrequency(); 
                                    }
                                }    
                            }
                            if (bAlarmNotExist)
                                MCAlarm.AlarmExist = false;



                        }
                    }

                }
            }
        }
        bool CheckExistAlarm(int id, List<Alarm> AlarmList)
        {
            bool iReturn = false;
            foreach(Alarm al in AlarmList)
            {
                if (al.ID == id)
                    iReturn = true;
            }    
            return iReturn;
        }
        Alarm GetAlarm(int id, List<Alarm> AlarmList)
        {
            Alarm aReturn = new Alarm();
            foreach(Alarm al in AlarmList)
            {
                if( al.ID == id)
                {
                    aReturn.ID = al.ID;
                    aReturn.AlarmName = al.AlarmName;
                }    
            }
            return aReturn;
        }

        //Structs
        private struct RGBColor
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);






        }

        //Methoss
        private void ActivateButton(object senderBtn, Color color)
        {
            if(senderBtn != null)
            {
                DisableButton();

                // Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border Button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();


                //Icon Current ChildForm
                iconCurentChildFo.IconChar = currentBtn.IconChar;
                iconCurentChildFo.IconColor = color;





            }
        }

        private void OpenChildForm(Form childForm)
        {
            if(currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDeskTop.Controls.Add(childForm);
            panelDeskTop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lbTitleChillForm.Text = childForm.Text;

        }
        private void DisableButton()
        {
            if(currentBtn != null)
            {
               
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;

                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;

            }
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColor.color1);
            OpenChildForm(new Forms.AUTO());
           
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColor.color2);
            OpenChildForm(new Forms.MANUAL1());
        }

        private void btnArlam_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColor.color3);
            OpenChildForm(new Forms.ARLAM());
        }

        private void btnIO_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender, RGBColor.color4);
            //OpenChildForm(new Forms.MONITOR1());
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            if(txtPassWord.Texts.Equals("HSV2021"))
            {
                ActivateButton(sender, RGBColor.color5);
                OpenChildForm(new Forms.TEACH31());
                txtPassWord.Texts = "";
                MessageBox.Show("Ready");
            }
            else
            {
                MessageBox.Show("Re-en in the Password");
            }
           
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColor.color6);
            OpenChildForm(new Forms.FormsProduct());

        }

        private void PBIMG_Click(object sender, EventArgs e)
        {
            
            Reset();
            if(currentChildForm != null)
            {

                currentChildForm.Close();

            }
        }

        private void Reset()
        {
            DisableButton();

            leftBorderBtn.Visible = false;

            iconCurentChildFo.IconChar =IconChar.Home;
            iconCurentChildFo.IconColor = Color.MediumPurple;
            lbTitleChillForm.Text = "HOME";
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        //Grag Form
        private void pictureTilleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void PC1_Click(object sender, EventArgs e)
        {
            this.Close();
            Mitsubishi.Instance().ResetBit("M1004");
            Mitsubishi.Instance().ResetBit("M80");
            Mitsubishi.Instance().ResetBit("D210");
            Mitsubishi.Instance().ResetBit("D220");
            Mitsubishi.Instance().ResetBit("D230");
            
        }



        private void btnM2_Click(object sender, EventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M2");
        }

        private void btnM1_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1");
        }

        private void btnM1_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (_runAlarmThread)
            {
                _runAlarmThread = false;
                Thread.Sleep(50);
                alarmThread.Abort();
                alarmThread.Join();
                alarmThread = null;
                MCAlarm.SaveAlarm();
            }
          
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetDesktopLocation(960, 0);
        }
        int CurrentHour = 0;
        int LastHour = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Mitsubishi.Instance().ReadInt("D10", lbltest);
            CurrentHour = DateTime.Now.Hour;
            int iProduc = 0;
            int.TryParse(lbltest.Text, out iProduc);
            switch (CurrentHour)
            {
                case 0:
                    productionHours.h00 = iProduc;
                    break;
                case 1:
                    productionHours.h01 = iProduc;
                    break;
                case 2:
                    productionHours.h02 = iProduc;
                    break;
                case 3:
                    productionHours.h03 = iProduc;
                    break;
                case 4:
                    productionHours.h04 = iProduc;
                    break;
                case 5:
                    productionHours.h05 = iProduc;
                    break;
                case 6:
                    productionHours.h06 = iProduc;
                    break;
                case 7:
                    productionHours.h07 = iProduc;
                    break;
                case 8:
                    productionHours.h08 = iProduc;
                    break;
                case 9:
                    productionHours.h09 = iProduc;
                    break;
                case 10:
                    productionHours.h10 = iProduc;
                    break;
                case 11:
                    productionHours.h11 = iProduc;
                    break;
                case 12:
                    productionHours.h12 = iProduc;
                    break;
                case 13:
                    productionHours.h13 = iProduc;
                    break;
                case 14:
                    productionHours.h14 = iProduc;
                    break;
                case 15:
                    productionHours.h15 = iProduc;
                    break;
                case 16:
                    productionHours.h16 = iProduc;
                    break;
                case 17:
                    productionHours.h17 = iProduc;
                    break;
                case 18:
                    productionHours.h18 = iProduc;
                    break;
                case 19:
                    productionHours.h19 = iProduc;
                    break;
                case 20:
                    productionHours.h20 = iProduc;
                    break;
                case 21:
                    productionHours.h21 = iProduc;
                    break;
                case 22:
                    productionHours.h22 = iProduc;
                    break;
                case 23:
                    productionHours.h23 = iProduc;
                    break;
            }

            string sDataProduct = "";
            sDataProduct += productionHours.h00 + ",";
            sDataProduct += productionHours.h01 + ",";
            sDataProduct += productionHours.h02 + ",";
            sDataProduct += productionHours.h03 + ",";
            sDataProduct += productionHours.h04 + ",";
            sDataProduct += productionHours.h05 + ",";
            sDataProduct += productionHours.h06 + ",";
            sDataProduct += productionHours.h07 + ",";
            sDataProduct += productionHours.h08 + ",";
            sDataProduct += productionHours.h09 + ",";
            sDataProduct += productionHours.h10 + ",";
            sDataProduct += productionHours.h11 + ",";
            sDataProduct += productionHours.h12 + ",";
            sDataProduct += productionHours.h13 + ",";
            sDataProduct += productionHours.h14 + ",";
            sDataProduct += productionHours.h15 + ",";
            sDataProduct += productionHours.h16 + ",";
            sDataProduct += productionHours.h17 + ",";
            sDataProduct += productionHours.h18 + ",";
            sDataProduct += productionHours.h19 + ",";
            sDataProduct += productionHours.h20 + ",";
            sDataProduct += productionHours.h21 + ",";
            sDataProduct += productionHours.h22 + ",";
            sDataProduct += productionHours.h23 ;

            if (CurrentHour != LastHour)
            {
                if (File.Exists("Production.txt"))
                    File.Delete("Production.txt");
                using (StreamWriter w = File.AppendText("Production.txt"))
                {
                    w.WriteLine(sDataProduct) ;
                }
                LastHour = CurrentHour;
            }

            //lblProductHours00.Text = productionHours.h00.ToString();
            //lblProductHours01.Text = productionHours.h01.ToString();



        }
        void ReadDataProduct()
        {
            try
            {
                using (StreamReader readtext = new StreamReader("Production.txt"))
                {
                    string readText = readtext.ReadLine();
                    string[] sProductArr = readText.Split(',');
                    if (sProductArr.Length == 24)
                    {
                        int tempData = 0;
                        int.TryParse(sProductArr[0], out tempData);
                        productionHours.h00 = tempData;
                        int.TryParse(sProductArr[1], out tempData);
                        productionHours.h01 = tempData;
                        int.TryParse(sProductArr[2], out tempData);
                        productionHours.h02 = tempData;
                        int.TryParse(sProductArr[3], out tempData);
                        productionHours.h03 = tempData;
                        int.TryParse(sProductArr[4], out tempData);
                        productionHours.h04 = tempData;
                        int.TryParse(sProductArr[5], out tempData);
                        productionHours.h05 = tempData;
                        int.TryParse(sProductArr[6], out tempData);
                        productionHours.h06 = tempData;
                        int.TryParse(sProductArr[7], out tempData);
                        productionHours.h07 = tempData;
                        int.TryParse(sProductArr[8], out tempData);
                        productionHours.h08 = tempData;
                        int.TryParse(sProductArr[9], out tempData);
                        productionHours.h09 = tempData;
                        int.TryParse(sProductArr[10], out tempData);
                        productionHours.h10 = tempData;
                        int.TryParse(sProductArr[11], out tempData);
                        productionHours.h11 = tempData;
                        int.TryParse(sProductArr[12], out tempData);
                        productionHours.h12 = tempData;
                        int.TryParse(sProductArr[13], out tempData);
                        productionHours.h13 = tempData;
                        int.TryParse(sProductArr[14], out tempData);
                        productionHours.h14 = tempData;
                        int.TryParse(sProductArr[15], out tempData);
                        productionHours.h15 = tempData;
                        int.TryParse(sProductArr[16], out tempData);
                        productionHours.h16 = tempData;
                        int.TryParse(sProductArr[17], out tempData);
                        productionHours.h17 = tempData;
                        int.TryParse(sProductArr[18], out tempData);
                        productionHours.h18 = tempData;
                        int.TryParse(sProductArr[19], out tempData);
                        productionHours.h19 = tempData;
                        int.TryParse(sProductArr[20], out tempData);
                        productionHours.h20 = tempData;
                        int.TryParse(sProductArr[21], out tempData);
                        productionHours.h21 = tempData;
                        int.TryParse(sProductArr[22], out tempData);
                        productionHours.h22 = tempData;
                        int.TryParse(sProductArr[23], out tempData);
                        productionHours.h23 = tempData;
                    }
                }
            }
            catch { }
        }

        ProductionHours productionHours = new ProductionHours();

   }
}
