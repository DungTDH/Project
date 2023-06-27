using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HSV.Forms
{
    public partial class TEACH31 : Form
    {

        JogSpeed _curJogSpeed = JogSpeed.Slow;
        ServoSelect _curServo = ServoSelect.None;
        TeachPos _curTechPos = TeachPos.Load;
        Thread mainThread;
        bool _threadRun = true;
        BitArray sensorArrTemp = new BitArray(16);

        public TEACH31()
        {
            InitializeComponent();
        }
        object lockobject = new object();
        void ThreadRun()
        {
            while (_threadRun)
            {
                lock (lockobject)
                {
                    Thread.Sleep(50);
                    //Get data servo from PLC
                    if (Mitsubishi.Instance().PLC_Connect == true)
                    {
                        Mitsubishi.Instance().ReadAxisCurrValue("D30", ref ServoTeaching.CurrentPosX,
                            ref ServoTeaching.CurrentPosY, ref ServoTeaching.CurrentPosT);
                        Mitsubishi.Instance().ReadServoSensorStatus("D20", ref sensorArrTemp);
                        ServoTeaching.senAxisX.LimitUp = sensorArrTemp[0];
                        ServoTeaching.senAxisX.DOG = sensorArrTemp[1];
                        ServoTeaching.senAxisX.LimitDn = sensorArrTemp[2];
                        ServoTeaching.senAxisY.LimitUp = sensorArrTemp[3];
                        ServoTeaching.senAxisY.DOG = sensorArrTemp[4];
                        ServoTeaching.senAxisY.LimitDn = sensorArrTemp[5];
                        ServoTeaching.senAxisT.LimitUp = sensorArrTemp[6];
                        ServoTeaching.senAxisT.DOG = sensorArrTemp[7];
                        ServoTeaching.senAxisT.LimitDn = sensorArrTemp[8];
                        ServoTeaching.ServoOnStatus = sensorArrTemp[9];
                    }

                    //Show data to HMI
                    ServoStatusUpdate();
                }
            }
        }
        private void FormTeaching_Load(object sender, EventArgs e)
        {
            PosSelectUpdateColor();
            ServoSelectUpdateColor();
            JogSpeedUpdate();

            mainThread = new Thread(ThreadRun);
            mainThread.Start();
            mainThread.IsBackground = true;

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        #region HMI Update

        delegate void SetTextCallback(string data);
        delegate void SetColorCallback(bool data);
        public void CurrentXView(System.String data)
        {
            if (this.rjtCurrentX.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(CurrentXView);
                this.Invoke(d, new object[] { data });
            }
            else
            {
                rjtCurrentX.Texts = data;
            }

        }
        public void CurrentYView(System.String data)
        {
            if (this.rjtCurrentY.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(CurrentYView);
                this.Invoke(d, new object[] { data });
            }
            else
            {
                rjtCurrentY.Texts = data;
            }
        }
        public void CurrentTView(System.String data)
        {
            if (this.rjtCurrentT.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(CurrentTView);
                this.Invoke(d, new object[] { data });
            }
            else
            {
                rjtCurrentT.Texts = data;
            }
        }
        public void SensorXLimitUpView(System.Boolean data)
        {
            if (this.btnXLimitUp.InvokeRequired)
            {
                SetColorCallback d = new SetColorCallback(SensorXLimitUpView);
                this.Invoke(d, new object[] { data });
            }
            else
            {
                if (data)
                    btnXLimitUp.BackColor = Color.Red;
                else
                    btnXLimitUp.BackColor = Color.FromArgb(220, 220, 220);
            }
        }
        public void SensorXLimitDnView(System.Boolean data)
        {
            if (this.btnXLimitDn.InvokeRequired)
            {
                SetColorCallback d = new SetColorCallback(SensorXLimitDnView);
                this.Invoke(d, new object[] { data });
            }
            else
            {
                if (data)
                    btnXLimitDn.BackColor = Color.Red;
                else
                    btnXLimitDn.BackColor = Color.FromArgb(220, 220, 220);
            }
        }
        public void SensorXHomeView(System.Boolean data)
        {
            if (this.btnXHome.InvokeRequired)
            {
                SetColorCallback d = new SetColorCallback(SensorXHomeView);
                this.Invoke(d, new object[] { data });
            }
            else
            {
                if (data)
                    btnXHome.BackColor = Color.Red;
                else
                    btnXHome.BackColor = Color.FromArgb(220, 220, 220);
            }
        }

        public void SensorYLimitUpView(System.Boolean data)
        {
            if (this.btnYLimitUp.InvokeRequired)
            {
                SetColorCallback d = new SetColorCallback(SensorYLimitUpView);
                this.Invoke(d, new object[] { data });
            }
            else
            {
                if (data)
                    btnYLimitUp.BackColor = Color.Red;
                else
                    btnYLimitUp.BackColor = Color.FromArgb(220, 220, 220);
            }
        }
        public void SensorYLimitDnView(System.Boolean data)
        {
            if (this.btnYLimitDn.InvokeRequired)
            {
                SetColorCallback d = new SetColorCallback(SensorYLimitDnView);
                this.Invoke(d, new object[] { data });
            }
            else
            {
                if (data)
                    btnYLimitDn.BackColor = Color.Red;
                else
                    btnYLimitDn.BackColor = Color.FromArgb(220, 220, 220);
            }
        }
        public void SensorYHomeView(System.Boolean data)
        {
            if (this.btnYHome.InvokeRequired)
            {
                SetColorCallback d = new SetColorCallback(SensorYHomeView);
                this.Invoke(d, new object[] { data });
            }
            else
            {
                if (data)
                    btnYHome.BackColor = Color.Red;
                else
                    btnYHome.BackColor = Color.FromArgb(220, 220, 220);
            }
        }
        public void SensorTLimitUpView(System.Boolean data)
        {
            if (this.btnTLimitUp.InvokeRequired)
            {
                SetColorCallback d = new SetColorCallback(SensorTLimitUpView);
                this.Invoke(d, new object[] { data });
            }
            else
            {
                if (data)
                    btnTLimitUp.BackColor = Color.Red;
                else
                    btnTLimitUp.BackColor = Color.FromArgb(220, 220, 220);
            }
        }
        public void SensorTLimitDnView(System.Boolean data)
        {
            if (this.btnTLimitDn.InvokeRequired)
            {
                SetColorCallback d = new SetColorCallback(SensorTLimitDnView);
                this.Invoke(d, new object[] { data });
            }
            else
            {
                if (data)
                    btnTLimitDn.BackColor = Color.Red;
                else
                    btnTLimitDn.BackColor = Color.FromArgb(220, 220, 220);
            }
        }
        public void SensorTHomeView(System.Boolean data)
        {
            if (this.btnTHome.InvokeRequired)
            {
                SetColorCallback d = new SetColorCallback(SensorTHomeView);
                this.Invoke(d, new object[] { data });
            }
            else
            {
                if (data)
                    btnTHome.BackColor = Color.Red;
                else
                    btnTHome.BackColor = Color.FromArgb(220, 220, 220);
            }
        }

        public void ServoOnStatusChange(System.Boolean data)
        {
            if (this.btnServoOn.InvokeRequired)
            {
                SetColorCallback d = new SetColorCallback(ServoOnStatusChange);
                this.Invoke(d, new object[] { data });
            }
            else
            {
                if (data)
                    btnServoOn.BackColor = Color.Red;
                else
                    btnServoOn.BackColor = Color.FromArgb(220, 220, 220);
            }
        }

        void ServoStatusUpdate()
        {
            CurrentXView(ServoTeaching.CurrentPosX.ToString());
            CurrentYView(ServoTeaching.CurrentPosY.ToString());
            CurrentTView(ServoTeaching.CurrentPosT.ToString());

            SensorXLimitUpView(ServoTeaching.senAxisX.LimitUp);
            SensorXLimitDnView(ServoTeaching.senAxisX.LimitDn);
            SensorXHomeView(ServoTeaching.senAxisX.DOG);

            SensorYLimitUpView(ServoTeaching.senAxisY.LimitUp);
            SensorYLimitDnView(ServoTeaching.senAxisY.LimitDn);
            SensorYHomeView(ServoTeaching.senAxisY.DOG);

            SensorTLimitUpView(ServoTeaching.senAxisT.LimitUp);
            SensorTLimitDnView(ServoTeaching.senAxisT.LimitDn);
            SensorTHomeView(ServoTeaching.senAxisT.DOG);

            ServoOnStatusChange(ServoTeaching.ServoOnStatus);

        }
        void ServoDataUpdateInfo(TeachPos pos)
        {
            switch (pos)
            {
                case TeachPos.Load:
                    rjtTargetX.Texts = ServoTeaching.LoadPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.LoadPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.LoadPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.LoadPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.LoadPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.LoadPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.LoadPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.LoadPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.LoadPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.LoadPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.LoadPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.LoadPos.SpeedT.ToString();
                    break;
                case TeachPos.UnloadOK:
                    rjtTargetX.Texts = ServoTeaching.UnLoadOKPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.UnLoadOKPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.UnLoadOKPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.UnLoadOKPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.UnLoadOKPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.UnLoadOKPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.UnLoadOKPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.UnLoadOKPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.UnLoadOKPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.UnLoadOKPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.UnLoadOKPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.UnLoadOKPos.SpeedT.ToString();
                    break;
                case TeachPos.UnloadNG:
                    rjtTargetX.Texts = ServoTeaching.UnLoadNGPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.UnLoadNGPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.UnLoadNGPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.UnLoadNGPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.UnLoadNGPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.UnLoadNGPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.UnLoadNGPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.UnLoadNGPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.UnLoadNGPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.UnLoadNGPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.UnLoadNGPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.UnLoadNGPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc1Start:
                    rjtTargetX.Texts = ServoTeaching.Proc1StartPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc1StartPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc1StartPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc1StartPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc1StartPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc1StartPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc1StartPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc1StartPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc1StartPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc1StartPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc1StartPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc1StartPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc1End:
                    rjtTargetX.Texts = ServoTeaching.Proc1EndPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc1EndPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc1EndPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc1EndPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc1EndPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc1EndPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc1EndPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc1EndPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc1EndPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc1EndPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc1EndPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc1EndPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc2Start:
                    rjtTargetX.Texts = ServoTeaching.Proc2StartPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc2StartPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc2StartPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc2StartPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc2StartPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc2StartPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc2StartPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc2StartPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc2StartPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc2StartPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc2StartPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc2StartPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc2End:
                    rjtTargetX.Texts = ServoTeaching.Proc2EndPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc2EndPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc2EndPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc2EndPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc2EndPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc2EndPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc2EndPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc2EndPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc2EndPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc2EndPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc2EndPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc2EndPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc3Start:
                    rjtTargetX.Texts = ServoTeaching.Proc3StartPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc3StartPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc3StartPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc3StartPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc3StartPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc3StartPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc3StartPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc3StartPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc3StartPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc3StartPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc3StartPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc3StartPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc3End:
                    rjtTargetX.Texts = ServoTeaching.Proc3EndPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc3EndPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc3EndPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc3EndPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc3EndPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc3EndPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc3EndPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc3EndPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc3EndPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc3EndPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc3EndPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc3EndPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc4Start:
                    rjtTargetX.Texts = ServoTeaching.Proc4StartPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc4StartPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc4StartPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc4StartPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc4StartPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc4StartPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc4StartPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc4StartPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc4StartPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc4StartPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc4StartPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc4StartPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc4End:
                    rjtTargetX.Texts = ServoTeaching.Proc4EndPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc4EndPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc4EndPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc4EndPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc4EndPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc4EndPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc4EndPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc4EndPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc4EndPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc4EndPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc4EndPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc4EndPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc5Start:
                    rjtTargetX.Texts = ServoTeaching.Proc5StartPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc5StartPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc5StartPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc5StartPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc5StartPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc5StartPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc5StartPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc5StartPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc5StartPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc5StartPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc5StartPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc5StartPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc5End:
                    rjtTargetX.Texts = ServoTeaching.Proc5EndPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc5EndPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc5EndPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc5EndPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc5EndPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc5EndPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc5EndPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc5EndPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc5EndPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc5EndPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc5EndPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc5EndPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc6Start:
                    rjtTargetX.Texts = ServoTeaching.Proc6StartPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc6StartPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc6StartPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc6StartPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc6StartPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc6StartPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc6StartPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc6StartPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc6StartPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc6StartPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc6StartPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc6StartPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc6End:
                    rjtTargetX.Texts = ServoTeaching.Proc6EndPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc6EndPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc6EndPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc6EndPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc6EndPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc6EndPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc6EndPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc6EndPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc6EndPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc6EndPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc6EndPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc6EndPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc7Start:
                    rjtTargetX.Texts = ServoTeaching.Proc7StartPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc7StartPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc7StartPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc7StartPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc7StartPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc7StartPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc7StartPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc7StartPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc7StartPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc7StartPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc7StartPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc7StartPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc7End:
                    rjtTargetX.Texts = ServoTeaching.Proc7EndPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc7EndPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc7EndPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc7EndPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc7EndPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc7EndPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc7EndPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc7EndPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc7EndPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc7EndPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc7EndPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc7EndPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc8Start:
                    rjtTargetX.Texts = ServoTeaching.Proc8StartPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc8StartPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc8StartPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc8StartPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc8StartPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc8StartPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc8StartPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc8StartPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc8StartPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc8StartPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc8StartPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc8StartPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc8End:
                    rjtTargetX.Texts = ServoTeaching.Proc8EndPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc8EndPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc8EndPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc8EndPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc8EndPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc8EndPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc8EndPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc8EndPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc8EndPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc8EndPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc8EndPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc8EndPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc9Start:
                    rjtTargetX.Texts = ServoTeaching.Proc9StartPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc9StartPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc9StartPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc9StartPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc9StartPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc9StartPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc9StartPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc9StartPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc9StartPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc9StartPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc9StartPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc9StartPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc9End:
                    rjtTargetX.Texts = ServoTeaching.Proc9EndPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc9EndPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc9EndPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc9EndPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc9EndPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc9EndPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc9EndPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc9EndPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc9EndPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc9EndPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc9EndPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc9EndPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc10Start:
                    rjtTargetX.Texts = ServoTeaching.Proc10StartPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc10StartPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc10StartPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc10StartPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc10StartPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc10StartPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc10StartPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc10StartPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc10StartPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc10StartPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc10StartPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc10StartPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc10End:
                    rjtTargetX.Texts = ServoTeaching.Proc10EndPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc10EndPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc10EndPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc10EndPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc10EndPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc10EndPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc10EndPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc10EndPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc10EndPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc10EndPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc10EndPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc10EndPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc11Start:
                    rjtTargetX.Texts = ServoTeaching.Proc11StartPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc11StartPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc11StartPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc11StartPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc11StartPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc11StartPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc11StartPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc11StartPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc11StartPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc11StartPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc11StartPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc11StartPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc11End:
                    rjtTargetX.Texts = ServoTeaching.Proc11EndPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc11EndPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc11EndPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc11EndPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc11EndPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc11EndPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc11EndPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc11EndPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc11EndPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc11EndPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc11EndPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc11EndPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc12Start:
                    rjtTargetX.Texts = ServoTeaching.Proc12StartPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc12StartPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc12StartPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc12StartPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc12StartPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc12StartPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc12StartPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc12StartPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc12StartPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc12StartPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc12StartPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc12StartPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc12End:
                    rjtTargetX.Texts = ServoTeaching.Proc12EndPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc12EndPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc12EndPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc12EndPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc12EndPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc12EndPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc12EndPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc12EndPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc12EndPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc12EndPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc12EndPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc12EndPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc13Start:
                    rjtTargetX.Texts = ServoTeaching.Proc13StartPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc13StartPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc13StartPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc13StartPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc13StartPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc13StartPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc13StartPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc13StartPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc13StartPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc13StartPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc13StartPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc13StartPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc13End:
                    rjtTargetX.Texts = ServoTeaching.Proc13EndPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc13EndPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc13EndPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc13EndPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc13EndPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc13EndPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc13EndPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc13EndPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc13EndPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc13EndPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc13EndPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc13EndPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc14Start:
                    rjtTargetX.Texts = ServoTeaching.Proc14StartPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc14StartPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc14StartPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc14StartPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc14StartPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc14StartPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc14StartPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc14StartPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc14StartPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc14StartPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc14StartPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc14StartPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc14End:
                    rjtTargetX.Texts = ServoTeaching.Proc14EndPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc14EndPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc14EndPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc14EndPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc14EndPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc14EndPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc14EndPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc14EndPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc14EndPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc14EndPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc14EndPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc14EndPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc15Start:
                    rjtTargetX.Texts = ServoTeaching.Proc15StartPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc15StartPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc15StartPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc15StartPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc15StartPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc15StartPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc15StartPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc15StartPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc15StartPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc15StartPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc15StartPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc15StartPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc15End:
                    rjtTargetX.Texts = ServoTeaching.Proc15EndPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc15EndPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc15EndPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc15EndPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc15EndPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc15EndPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc15EndPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc15EndPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc15EndPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc15EndPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc15EndPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc15EndPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc16Start:
                    rjtTargetX.Texts = ServoTeaching.Proc16StartPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc16StartPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc16StartPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc16StartPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc16StartPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc16StartPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc16StartPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc16StartPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc16StartPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc16StartPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc16StartPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc16StartPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc16End:
                    rjtTargetX.Texts = ServoTeaching.Proc16EndPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc16EndPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc16EndPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc16EndPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc16EndPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc16EndPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc16EndPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc16EndPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc16EndPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc16EndPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc16EndPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc16EndPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc17Start:
                    rjtTargetX.Texts = ServoTeaching.Proc17StartPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc17StartPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc17StartPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc17StartPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc17StartPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc17StartPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc17StartPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc17StartPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc17StartPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc17StartPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc17StartPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc17StartPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc17End:
                    rjtTargetX.Texts = ServoTeaching.Proc17EndPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc17EndPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc17EndPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc17EndPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc17EndPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc17EndPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc17EndPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc17EndPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc17EndPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc17EndPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc17EndPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc17EndPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc18Start:
                    rjtTargetX.Texts = ServoTeaching.Proc18StartPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc18StartPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc18StartPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc18StartPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc18StartPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc18StartPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc18StartPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc18StartPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc18StartPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc18StartPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc18StartPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc18StartPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc18End:
                    rjtTargetX.Texts = ServoTeaching.Proc18EndPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc18EndPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc18EndPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc18EndPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc18EndPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc18EndPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc18EndPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc18EndPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc18EndPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc18EndPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc18EndPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc18EndPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc19Start:
                    rjtTargetX.Texts = ServoTeaching.Proc19StartPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc19StartPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc19StartPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc19StartPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc19StartPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc19StartPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc19StartPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc19StartPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc19StartPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc19StartPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc19StartPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc19StartPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc19End:
                    rjtTargetX.Texts = ServoTeaching.Proc19EndPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc19EndPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc19EndPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc19EndPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc19EndPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc19EndPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc19EndPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc19EndPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc19EndPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc19EndPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc19EndPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc19EndPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc20Start:
                    rjtTargetX.Texts = ServoTeaching.Proc20StartPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc20StartPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc20StartPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc20StartPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc20StartPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc20StartPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc20StartPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc20StartPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc20StartPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc20StartPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc20StartPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc20StartPos.SpeedT.ToString();
                    break;
                case TeachPos.Proc20End:
                    rjtTargetX.Texts = ServoTeaching.Proc20EndPos.TargetX.ToString();
                    rjtTargetY.Texts = ServoTeaching.Proc20EndPos.TargetY.ToString();
                    rjtTargetT.Texts = ServoTeaching.Proc20EndPos.TargetT.ToString();
                    rjtFixX.Texts = ServoTeaching.Proc20EndPos.FixX.ToString();
                    rjtFixY.Texts = ServoTeaching.Proc20EndPos.FixY.ToString();
                    rjtFixT.Texts = ServoTeaching.Proc20EndPos.FixT.ToString();
                    rjtOffsetX.Texts = ServoTeaching.Proc20EndPos.OffsetX.ToString();
                    rjtOffsetY.Texts = ServoTeaching.Proc20EndPos.OffsetY.ToString();
                    rjtOffsetT.Texts = ServoTeaching.Proc20EndPos.OffsetT.ToString();
                    rjtSpeedX.Texts = ServoTeaching.Proc20EndPos.SpeedX.ToString();
                    rjtSpeedY.Texts = ServoTeaching.Proc20EndPos.SpeedY.ToString();
                    rjtSpeedT.Texts = ServoTeaching.Proc20EndPos.SpeedT.ToString();
                    break;
            }

        }
        void JogSpeedUpdate()
        {
            switch (_curJogSpeed)
            {
                case JogSpeed.Slow:
                    btnJogSlow.BackColor = Color.Cyan;
                    btnJogMid.BackColor = Color.FromArgb(220, 220, 220);
                    btnJogHight.BackColor = Color.FromArgb(220, 220, 220);
                    //Mitsubishi.Instance().SetBit("M1350");
                    //Mitsubishi.Instance().ResetBit("1351");
                   
                    break;
                case JogSpeed.Mid:
                    btnJogSlow.BackColor = Color.FromArgb(220, 220, 220);
                    btnJogMid.BackColor = Color.Cyan;
                    btnJogHight.BackColor = Color.FromArgb(220, 220, 220);
                    
                    //Mitsubishi.Instance().SetBit("M1351");
                    //Mitsubishi.Instance().ResetBit("M1350");
                    break;
                case JogSpeed.Hight:
                    btnJogSlow.BackColor = Color.FromArgb(220, 220, 220);
                    btnJogMid.BackColor = Color.FromArgb(220, 220, 220);
                    btnJogHight.BackColor = Color.Cyan;
                    //Mitsubishi.Instance().ResetBit("M1170");
                    //Mitsubishi.Instance().ResetBit("M1171");
                    //Mitsubishi.Instance().SetBit("M1172");
                    break;
            }

        }
        void ServoSelectUpdateColor()
        {
            switch (_curServo)
            {
                case ServoSelect.X:
                    btnAxisX.BackColor = Color.Cyan;
                    btnAxisY.BackColor = Color.FromArgb(220, 220, 220);
                    btnAxisT.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case ServoSelect.Y:
                    btnAxisX.BackColor = Color.FromArgb(220, 220, 220);
                    btnAxisY.BackColor = Color.Cyan;
                    btnAxisT.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case ServoSelect.T:
                    btnAxisX.BackColor = Color.FromArgb(220, 220, 220);
                    btnAxisY.BackColor = Color.FromArgb(220, 220, 220);
                    btnAxisT.BackColor = Color.Cyan;
                    break;

            }

        }

        void PosSelectUpdateColor()
        {
            switch (_curTechPos)
            {
                case TeachPos.Load:
                    btnLoadPos.BackColor = Color.Cyan;
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.UnloadOK:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.Cyan;
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.UnloadNG:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.Cyan;
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc1Start:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.Cyan;
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc1End:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.Cyan;
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc2Start:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.Cyan;
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc2End:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.Cyan;
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc3Start:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.Cyan;
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc3End:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.Cyan;
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc4Start:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.Cyan;
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc4End:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.Cyan;
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc5Start:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.Cyan;
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc5End:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.Cyan;
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc6Start:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.Cyan;
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc6End:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.Cyan;
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc7Start:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.Cyan;
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc7End:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.Cyan;
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc8Start:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.Cyan;
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc8End:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.Cyan;
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc9Start:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.Cyan;
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc9End:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.Cyan;
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);

                    break;
                case TeachPos.Proc10Start:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.Cyan;
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc10End:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.Cyan;
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc11Start:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.Cyan;
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc11End:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.Cyan;
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc12Start:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.Cyan;
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc12End:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.Cyan;
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc13Start:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.Cyan;
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc13End:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.Cyan;
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc14Start:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.Cyan;
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc14End:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.Cyan;
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc15Start:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.Cyan;
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc15End:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.Cyan;
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc16Start:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.Cyan;
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc16End:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.Cyan;
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc17Start:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.Cyan;
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc17End:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.Cyan;
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc18Start:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.Cyan;
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc18End:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.Cyan;
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc19Start:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.Cyan;
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc19End:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.Cyan;
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc20Start:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.Cyan;
                    btnProc20End.BackColor = Color.FromArgb(220, 220, 220);
                    break;
                case TeachPos.Proc20End:
                    btnLoadPos.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadOK.BackColor = Color.FromArgb(220, 220, 220);
                    btnUnLoadNG.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc1End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc2End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc3End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc4End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc5End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc6End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc7End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc8End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc9End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc10End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc11End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc12End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc13End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc14End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc15End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc16End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc17End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc18End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc19End.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20Start.BackColor = Color.FromArgb(220, 220, 220);
                    btnProc20End.BackColor = Color.Cyan;
                    break;
            }
        }

        #endregion

        void PosSelect(object sender, EventArgs e)
        {
            PosSelectUpdateColor();
            ReadTeachingData();
            ServoDataUpdateInfo(_curTechPos);

        }
        private void btnLoadPos_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Load;
            PosSelect(sender, e);
        }

        private void btnUnLoadOK_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.UnloadOK;
            PosSelect(sender, e);
        }

        private void btnUnLoadNG_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.UnloadNG;
            PosSelect(sender, e);
        }

        private void btnProc1Start_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc1Start;
            PosSelect(sender, e);
        }

        private void btnProc1End_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc1End;
            PosSelect(sender, e);
        }

        private void btnProc2Start_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc2Start;
            PosSelect(sender, e);
        }

        private void btnProc2End_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc2End;
            PosSelect(sender, e);
        }

        private void btnProc3Start_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc3Start;
            PosSelect(sender, e);
        }

        private void btnProc3End_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc3End;
            PosSelect(sender, e);
        }

        private void btnProc4Start_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc4Start;
            PosSelect(sender, e);
        }

        private void btnProc4End_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc4End;
            PosSelect(sender, e);
        }

        private void btnProc5Start_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc5Start;
            PosSelect(sender, e);
        }
        private void btnProc5End_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc5End;
            PosSelect(sender, e);
        }

        private void btnProc6Start_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc6Start;
            PosSelect(sender, e);
        }
        private void btnProc6End_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc6End;
            PosSelect(sender, e);
        }
        private void btnProc7Start_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc7Start;
            PosSelect(sender, e);
        }
        private void btnProc7End_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc7End;
            PosSelect(sender, e);
        }
        private void btnProc8Start_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc8Start;
            PosSelect(sender, e);
        }
        private void btnProc8End_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc8End;
            PosSelect(sender, e);
        }
        private void btnProc9Start_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc9Start;
            PosSelect(sender, e);
        }
        private void btnProc9End_Click_1(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc9End;
            PosSelect(sender, e);
        }
        private void btnProc10Start_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc10Start;
            PosSelect(sender, e);
        }

        private void btnProc10End_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc10End;
            PosSelect(sender, e);
        }
        private void btnProc11Start_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc11Start;
            PosSelect(sender, e);
        }

        private void btnProc11End_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc11End;
            PosSelect(sender, e);
        }
        private void btnProc12Start_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc12Start;
            PosSelect(sender, e);
        }

        private void btnProc12End_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc12End;
            PosSelect(sender, e);
        }

        private void btnProc13Start_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc13Start;
            PosSelect(sender, e);
        }
        private void btnProc13End_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc13End;
            PosSelect(sender, e);
        }

        private void btnProc14Start_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc14Start;
            PosSelect(sender, e);
        }
        private void btnProc14End_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc14End;
            PosSelect(sender, e);
        }

        private void btnProc15Start_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc15Start;
            PosSelect(sender, e);
        }

        private void btnProc15End_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc15End;
            PosSelect(sender, e);
        }

        private void btnProc16Start_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc16Start;
            PosSelect(sender, e);
        }

        private void btnProc16End_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc16End;
            PosSelect(sender, e);
        }

        private void btnProc17Start_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc17Start;
            PosSelect(sender, e);
            MessageBox.Show(" UPDATE VER1.1 !!!");
        }

        private void btnProc17End_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc17End;
            PosSelect(sender, e);
            MessageBox.Show(" UPDATE VER1.1 !!!");
        }

        private void btnProc18Start_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc18Start;
            PosSelect(sender, e);
        }

        private void btnProc18End_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc18End;
            PosSelect(sender, e);
        }

        private void btnProc19Start_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc19Start;
            PosSelect(sender, e);
            MessageBox.Show(" UPDATE VER1.1 !!!");
        }

        private void btnProc19End_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc19End;
            PosSelect(sender, e);
            MessageBox.Show(" UPDATE VER1.1 !!!");
        }

        private void btnProc20Start_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc20Start;
            PosSelect(sender, e);
        }

        private void btnProc20End_Click(object sender, EventArgs e)
        {
            _curTechPos = TeachPos.Proc20End;
            PosSelect(sender, e);
        }

        private void btnAxisX_Click(object sender, EventArgs e)
        {
            _curServo = ServoSelect.X;
            ServoSelectUpdateColor();
        }

        private void btnAxisY_Click(object sender, EventArgs e)
        {
            _curServo = ServoSelect.Y;
            ServoSelectUpdateColor();
        }

        private void btnAxisT_Click(object sender, EventArgs e)
        {
            _curServo = ServoSelect.T;
            ServoSelectUpdateColor();
        }

        private void btnJogSlow_Click(object sender, EventArgs e)
        {
            _curJogSpeed = JogSpeed.Slow;
            JogSpeedUpdate();
        }

        private void btnJogMid_Click(object sender, EventArgs e)
        {
            _curJogSpeed = JogSpeed.Mid;
            JogSpeedUpdate();
        }

        private void btnJogHight_Click(object sender, EventArgs e)
        {
            _curJogSpeed = JogSpeed.Hight;
            JogSpeedUpdate();
        }

        private void FormTeaching_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (_threadRun)
            {
                _threadRun = false;
                Thread.Sleep(50);
                mainThread.Abort();
                mainThread.Join();
                mainThread = null;
            }
        }

        private void btnPosSet_Click(object sender, EventArgs e)
        {
            switch (_curTechPos)
            {
                case TeachPos.Load:
                    ServoTeaching.LoadPos.OffsetX = 0;
                    ServoTeaching.LoadPos.OffsetY = 0;
                    ServoTeaching.LoadPos.OffsetT = 0;
                    ServoTeaching.LoadPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.LoadPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.LoadPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.UnloadOK:
                    ServoTeaching.UnLoadOKPos.OffsetX = 0;
                    ServoTeaching.UnLoadOKPos.OffsetY = 0;
                    ServoTeaching.UnLoadOKPos.OffsetT = 0;
                    ServoTeaching.UnLoadOKPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.UnLoadOKPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.UnLoadOKPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.UnloadNG:
                    ServoTeaching.UnLoadNGPos.OffsetX = 0;
                    ServoTeaching.UnLoadNGPos.OffsetY = 0;
                    ServoTeaching.UnLoadNGPos.OffsetT = 0;
                    ServoTeaching.UnLoadNGPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.UnLoadNGPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.UnLoadNGPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc1Start:
                    ServoTeaching.Proc1StartPos.OffsetX = 0;
                    ServoTeaching.Proc1StartPos.OffsetY = 0;
                    ServoTeaching.Proc1StartPos.OffsetT = 0;
                    ServoTeaching.Proc1StartPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc1StartPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc1StartPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc1End:
                    ServoTeaching.Proc1EndPos.OffsetX = 0;
                    ServoTeaching.Proc1EndPos.OffsetY = 0;
                    ServoTeaching.Proc1EndPos.OffsetT = 0;
                    ServoTeaching.Proc1EndPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc1EndPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc1EndPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc2Start:
                    ServoTeaching.Proc2StartPos.OffsetX = 0;
                    ServoTeaching.Proc2StartPos.OffsetY = 0;
                    ServoTeaching.Proc2StartPos.OffsetT = 0;
                    ServoTeaching.Proc2StartPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc2StartPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc2StartPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc2End:
                    ServoTeaching.Proc2EndPos.OffsetX = 0;
                    ServoTeaching.Proc2EndPos.OffsetY = 0;
                    ServoTeaching.Proc2EndPos.OffsetT = 0;
                    ServoTeaching.Proc2EndPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc2EndPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc2EndPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc3Start:
                    ServoTeaching.Proc3StartPos.OffsetX = 0;
                    ServoTeaching.Proc3StartPos.OffsetY = 0;
                    ServoTeaching.Proc3StartPos.OffsetT = 0;
                    ServoTeaching.Proc3StartPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc3StartPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc3StartPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc3End:
                    ServoTeaching.Proc3EndPos.OffsetX = 0;
                    ServoTeaching.Proc3EndPos.OffsetY = 0;
                    ServoTeaching.Proc3EndPos.OffsetT = 0;
                    ServoTeaching.Proc3EndPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc3EndPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc3EndPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc4Start:
                    ServoTeaching.Proc4StartPos.OffsetX = 0;
                    ServoTeaching.Proc4StartPos.OffsetY = 0;
                    ServoTeaching.Proc4StartPos.OffsetT = 0;
                    ServoTeaching.Proc4StartPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc4StartPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc4StartPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc4End:
                    ServoTeaching.Proc4EndPos.OffsetX = 0;
                    ServoTeaching.Proc4EndPos.OffsetY = 0;
                    ServoTeaching.Proc4EndPos.OffsetT = 0;
                    ServoTeaching.Proc4EndPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc4EndPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc4EndPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc5Start:
                    ServoTeaching.Proc5StartPos.OffsetX = 0;
                    ServoTeaching.Proc5StartPos.OffsetY = 0;
                    ServoTeaching.Proc5StartPos.OffsetT = 0;
                    ServoTeaching.Proc5StartPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc5StartPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc5StartPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc5End:
                    ServoTeaching.Proc5EndPos.OffsetX = 0;
                    ServoTeaching.Proc5EndPos.OffsetY = 0;
                    ServoTeaching.Proc5EndPos.OffsetT = 0;
                    ServoTeaching.Proc5EndPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc5EndPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc5EndPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc6Start:
                    ServoTeaching.Proc6StartPos.OffsetX = 0;
                    ServoTeaching.Proc6StartPos.OffsetY = 0;
                    ServoTeaching.Proc6StartPos.OffsetT = 0;
                    ServoTeaching.Proc6StartPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc6StartPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc6StartPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc6End:
                    ServoTeaching.Proc6EndPos.OffsetX = 0;
                    ServoTeaching.Proc6EndPos.OffsetY = 0;
                    ServoTeaching.Proc6EndPos.OffsetT = 0;
                    ServoTeaching.Proc6EndPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc6EndPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc6EndPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc7Start:
                    ServoTeaching.Proc7StartPos.OffsetX = 0;
                    ServoTeaching.Proc7StartPos.OffsetY = 0;
                    ServoTeaching.Proc7StartPos.OffsetT = 0;
                    ServoTeaching.Proc7StartPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc7StartPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc7StartPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc7End:
                    ServoTeaching.Proc7EndPos.OffsetX = 0;
                    ServoTeaching.Proc7EndPos.OffsetY = 0;
                    ServoTeaching.Proc7EndPos.OffsetT = 0;
                    ServoTeaching.Proc7EndPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc7EndPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc7EndPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc8Start:
                    ServoTeaching.Proc8StartPos.OffsetX = 0;
                    ServoTeaching.Proc8StartPos.OffsetY = 0;
                    ServoTeaching.Proc8StartPos.OffsetT = 0;
                    ServoTeaching.Proc8StartPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc8StartPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc8StartPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc8End:
                    ServoTeaching.Proc8EndPos.OffsetX = 0;
                    ServoTeaching.Proc8EndPos.OffsetY = 0;
                    ServoTeaching.Proc8EndPos.OffsetT = 0;
                    ServoTeaching.Proc8EndPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc8EndPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc8EndPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc9Start:
                    ServoTeaching.Proc9StartPos.OffsetX = 0;
                    ServoTeaching.Proc9StartPos.OffsetY = 0;
                    ServoTeaching.Proc9StartPos.OffsetT = 0;
                    ServoTeaching.Proc9StartPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc9StartPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc9StartPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc9End:
                    ServoTeaching.Proc9EndPos.OffsetX = 0;
                    ServoTeaching.Proc9EndPos.OffsetY = 0;
                    ServoTeaching.Proc9EndPos.OffsetT = 0;
                    ServoTeaching.Proc9EndPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc9EndPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc9EndPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc10Start:
                    ServoTeaching.Proc10StartPos.OffsetX = 0;
                    ServoTeaching.Proc10StartPos.OffsetY = 0;
                    ServoTeaching.Proc10StartPos.OffsetT = 0;
                    ServoTeaching.Proc10StartPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc10StartPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc10StartPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc10End:
                    ServoTeaching.Proc10EndPos.OffsetX = 0;
                    ServoTeaching.Proc10EndPos.OffsetY = 0;
                    ServoTeaching.Proc10EndPos.OffsetT = 0;
                    ServoTeaching.Proc10EndPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc10EndPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc10EndPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc11Start:
                    ServoTeaching.Proc11StartPos.OffsetX = 0;
                    ServoTeaching.Proc11StartPos.OffsetY = 0;
                    ServoTeaching.Proc11StartPos.OffsetT = 0;
                    ServoTeaching.Proc11StartPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc11StartPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc11StartPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc11End:
                    ServoTeaching.Proc11EndPos.OffsetX = 0;
                    ServoTeaching.Proc11EndPos.OffsetY = 0;
                    ServoTeaching.Proc11EndPos.OffsetT = 0;
                    ServoTeaching.Proc11EndPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc11EndPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc11EndPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc12Start:
                    ServoTeaching.Proc12StartPos.OffsetX = 0;
                    ServoTeaching.Proc12StartPos.OffsetY = 0;
                    ServoTeaching.Proc12StartPos.OffsetT = 0;
                    ServoTeaching.Proc12StartPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc12StartPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc12StartPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc12End:
                    ServoTeaching.Proc12EndPos.OffsetX = 0;
                    ServoTeaching.Proc12EndPos.OffsetY = 0;
                    ServoTeaching.Proc12EndPos.OffsetT = 0;
                    ServoTeaching.Proc12EndPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc12EndPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc12EndPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc13Start:
                    ServoTeaching.Proc13StartPos.OffsetX = 0;
                    ServoTeaching.Proc13StartPos.OffsetY = 0;
                    ServoTeaching.Proc13StartPos.OffsetT = 0;
                    ServoTeaching.Proc13StartPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc13StartPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc13StartPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc13End:
                    ServoTeaching.Proc13EndPos.OffsetX = 0;
                    ServoTeaching.Proc13EndPos.OffsetY = 0;
                    ServoTeaching.Proc13EndPos.OffsetT = 0;
                    ServoTeaching.Proc13EndPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc13EndPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc13EndPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc14Start:
                    ServoTeaching.Proc14StartPos.OffsetX = 0;
                    ServoTeaching.Proc14StartPos.OffsetY = 0;
                    ServoTeaching.Proc14StartPos.OffsetT = 0;
                    ServoTeaching.Proc14StartPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc14StartPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc14StartPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc14End:
                    ServoTeaching.Proc14EndPos.OffsetX = 0;
                    ServoTeaching.Proc14EndPos.OffsetY = 0;
                    ServoTeaching.Proc14EndPos.OffsetT = 0;
                    ServoTeaching.Proc14EndPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc14EndPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc14EndPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc15Start:
                    ServoTeaching.Proc15StartPos.OffsetX = 0;
                    ServoTeaching.Proc15StartPos.OffsetY = 0;
                    ServoTeaching.Proc15StartPos.OffsetT = 0;
                    ServoTeaching.Proc15StartPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc15StartPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc15StartPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc15End:
                    ServoTeaching.Proc15EndPos.OffsetX = 0;
                    ServoTeaching.Proc15EndPos.OffsetY = 0;
                    ServoTeaching.Proc15EndPos.OffsetT = 0;
                    ServoTeaching.Proc15EndPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc15EndPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc15EndPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc16Start:
                    ServoTeaching.Proc16StartPos.OffsetX = 0;
                    ServoTeaching.Proc16StartPos.OffsetY = 0;
                    ServoTeaching.Proc16StartPos.OffsetT = 0;
                    ServoTeaching.Proc16StartPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc16StartPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc16StartPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc16End:
                    ServoTeaching.Proc16EndPos.OffsetX = 0;
                    ServoTeaching.Proc16EndPos.OffsetY = 0;
                    ServoTeaching.Proc16EndPos.OffsetT = 0;
                    ServoTeaching.Proc16EndPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc16EndPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc16EndPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc17Start:
                    ServoTeaching.Proc17StartPos.OffsetX = 0;
                    ServoTeaching.Proc17StartPos.OffsetY = 0;
                    ServoTeaching.Proc17StartPos.OffsetT = 0;
                    ServoTeaching.Proc17StartPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc17StartPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc17StartPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc17End:
                    ServoTeaching.Proc17EndPos.OffsetX = 0;
                    ServoTeaching.Proc17EndPos.OffsetY = 0;
                    ServoTeaching.Proc17EndPos.OffsetT = 0;
                    ServoTeaching.Proc17EndPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc17EndPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc17EndPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc18Start:
                    ServoTeaching.Proc18StartPos.OffsetX = 0;
                    ServoTeaching.Proc18StartPos.OffsetY = 0;
                    ServoTeaching.Proc18StartPos.OffsetT = 0;
                    ServoTeaching.Proc18StartPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc18StartPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc18StartPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc18End:
                    ServoTeaching.Proc18EndPos.OffsetX = 0;
                    ServoTeaching.Proc18EndPos.OffsetY = 0;
                    ServoTeaching.Proc18EndPos.OffsetT = 0;
                    ServoTeaching.Proc18EndPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc18EndPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc18EndPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc19Start:
                    ServoTeaching.Proc19StartPos.OffsetX = 0;
                    ServoTeaching.Proc19StartPos.OffsetY = 0;
                    ServoTeaching.Proc19StartPos.OffsetT = 0;
                    ServoTeaching.Proc19StartPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc19StartPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc19StartPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc19End:
                    ServoTeaching.Proc19EndPos.OffsetX = 0;
                    ServoTeaching.Proc19EndPos.OffsetY = 0;
                    ServoTeaching.Proc19EndPos.OffsetT = 0;
                    ServoTeaching.Proc19EndPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc19EndPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc19EndPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc20Start:
                    ServoTeaching.Proc20StartPos.OffsetX = 0;
                    ServoTeaching.Proc20StartPos.OffsetY = 0;
                    ServoTeaching.Proc20StartPos.OffsetT = 0;
                    ServoTeaching.Proc20StartPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc20StartPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc20StartPos.FixT = ServoTeaching.CurrentPosT;
                    break;
                case TeachPos.Proc20End:
                    ServoTeaching.Proc20EndPos.OffsetX = 0;
                    ServoTeaching.Proc20EndPos.OffsetY = 0;
                    ServoTeaching.Proc20EndPos.OffsetT = 0;
                    ServoTeaching.Proc20EndPos.FixX = ServoTeaching.CurrentPosX;
                    ServoTeaching.Proc20EndPos.FixY = ServoTeaching.CurrentPosY;
                    ServoTeaching.Proc20EndPos.FixT = ServoTeaching.CurrentPosT;
                    break;
            }
        }

        private void btnPosMove_MouseDown(object sender, MouseEventArgs e)
        {
            switch (_curTechPos)
            {
                case TeachPos.Load:
                    Mitsubishi.Instance().SetBit("M1340");
                    break;
                case TeachPos.UnloadOK:
                    Mitsubishi.Instance().SetBit("M1341");
                    break;
                case TeachPos.UnloadNG:
                    Mitsubishi.Instance().SetBit("M1342");
                    break;
                case TeachPos.Proc1Start:
                    Mitsubishi.Instance().SetBit("M1300");
                    break;
                case TeachPos.Proc1End:
                    Mitsubishi.Instance().SetBit("M1320");
                    break;
                case TeachPos.Proc2Start:
                    Mitsubishi.Instance().SetBit("M1301");
                    break;
                case TeachPos.Proc2End:
                    Mitsubishi.Instance().SetBit("M1321");
                    break;
                case TeachPos.Proc3Start:
                    Mitsubishi.Instance().SetBit("M1302");
                    break;
                case TeachPos.Proc3End:
                    Mitsubishi.Instance().SetBit("M1322");
                    break;
                case TeachPos.Proc4Start:
                    Mitsubishi.Instance().SetBit("M1303");
                    break;
                case TeachPos.Proc4End:
                    Mitsubishi.Instance().SetBit("M1323");
                    break;
                case TeachPos.Proc5Start:
                    Mitsubishi.Instance().SetBit("M1304");
                    break;
                case TeachPos.Proc5End:
                    Mitsubishi.Instance().SetBit("M1324");
                    break;
                case TeachPos.Proc6Start:
                    Mitsubishi.Instance().SetBit("M1305");
                    break;
                case TeachPos.Proc6End:
                    Mitsubishi.Instance().SetBit("M1325");
                    break;
                case TeachPos.Proc7Start:
                    Mitsubishi.Instance().SetBit("M1306");
                    break;
                case TeachPos.Proc7End:
                    Mitsubishi.Instance().SetBit("M1326");
                    break;
                case TeachPos.Proc8Start:
                    Mitsubishi.Instance().SetBit("M1307");
                    break;
                case TeachPos.Proc8End:
                    Mitsubishi.Instance().SetBit("M1327");
                    break;
                case TeachPos.Proc9Start:
                    Mitsubishi.Instance().SetBit("M1308");
                    break;
                case TeachPos.Proc9End:
                    Mitsubishi.Instance().SetBit("M1328");
                    break;
                case TeachPos.Proc10Start:
                    Mitsubishi.Instance().SetBit("M1309");
                    break;
                case TeachPos.Proc10End:
                    Mitsubishi.Instance().SetBit("M1329");
                    break;
                case TeachPos.Proc11Start:
                    Mitsubishi.Instance().SetBit("M1310");
                    break;
                case TeachPos.Proc11End:
                    Mitsubishi.Instance().SetBit("M1330");
                    break;
                case TeachPos.Proc12Start:
                    Mitsubishi.Instance().SetBit("M1311");
                    break;
                case TeachPos.Proc12End:
                    Mitsubishi.Instance().SetBit("M1331");
                    break;
                case TeachPos.Proc13Start:
                    Mitsubishi.Instance().SetBit("M1312");
                    break;
                case TeachPos.Proc13End:
                    Mitsubishi.Instance().SetBit("M1332");
                    break;
                case TeachPos.Proc14Start:
                    Mitsubishi.Instance().SetBit("M1313");
                    break;
                case TeachPos.Proc14End:
                    Mitsubishi.Instance().SetBit("M1333");
                    break;
                case TeachPos.Proc15Start:
                    Mitsubishi.Instance().SetBit("M1314");
                    break;
                case TeachPos.Proc15End:
                    Mitsubishi.Instance().SetBit("M1334");
                    break;
                case TeachPos.Proc16Start:
                    Mitsubishi.Instance().SetBit("M1315");
                    break;
                case TeachPos.Proc16End:
                    Mitsubishi.Instance().SetBit("M1335");
                    break;
                case TeachPos.Proc17Start:
                    Mitsubishi.Instance().SetBit("M1316");
                    break;
                case TeachPos.Proc17End:
                    Mitsubishi.Instance().SetBit("M1336");
                    break;
                case TeachPos.Proc18Start:
                    Mitsubishi.Instance().SetBit("M1317");
                    break;
                case TeachPos.Proc18End:
                    Mitsubishi.Instance().SetBit("M1337");
                    break;
                case TeachPos.Proc19Start:
                    Mitsubishi.Instance().SetBit("M1318");
                    break;
                case TeachPos.Proc19End:
                    Mitsubishi.Instance().SetBit("M1338");
                    break;
                case TeachPos.Proc20Start:
                    Mitsubishi.Instance().SetBit("M1319");
                    break;
                case TeachPos.Proc20End:
                    Mitsubishi.Instance().SetBit("M1339");
                    break;
            }
        }

        private void btnPosMove_MouseUp(object sender, MouseEventArgs e)
        {
            switch (_curTechPos)
            {

                case TeachPos.Load:
                    Mitsubishi.Instance().ResetBit("M1340");
                    break;
                case TeachPos.UnloadOK:
                    Mitsubishi.Instance().ResetBit("M1341");
                    break;
                case TeachPos.UnloadNG:
                    Mitsubishi.Instance().ResetBit("M1342");
                    break;
                case TeachPos.Proc1Start:
                    Mitsubishi.Instance().ResetBit("M1300");
                    break;
                case TeachPos.Proc1End:
                    Mitsubishi.Instance().ResetBit("M1320");
                    break;
                case TeachPos.Proc2Start:
                    Mitsubishi.Instance().ResetBit("M1301");
                    break;
                case TeachPos.Proc2End:
                    Mitsubishi.Instance().ResetBit("M1321");
                    break;
                case TeachPos.Proc3Start:
                    Mitsubishi.Instance().ResetBit("M1302");
                    break;
                case TeachPos.Proc3End:
                    Mitsubishi.Instance().ResetBit("M1322");
                    break;
                case TeachPos.Proc4Start:
                    Mitsubishi.Instance().ResetBit("M1303");
                    break;
                case TeachPos.Proc4End:
                    Mitsubishi.Instance().ResetBit("M1323");
                    break;
                case TeachPos.Proc5Start:
                    Mitsubishi.Instance().ResetBit("M1304");
                    break;
                case TeachPos.Proc5End:
                    Mitsubishi.Instance().ResetBit("M1324");
                    break;
                case TeachPos.Proc6Start:
                    Mitsubishi.Instance().ResetBit("M1305");
                    break;
                case TeachPos.Proc6End:
                    Mitsubishi.Instance().ResetBit("M1325");
                    break;
                case TeachPos.Proc7Start:
                    Mitsubishi.Instance().ResetBit("M1306");
                    break;
                case TeachPos.Proc7End:
                    Mitsubishi.Instance().ResetBit("M1326");
                    break;
                case TeachPos.Proc8Start:
                    Mitsubishi.Instance().ResetBit("M1307");
                    break;
                case TeachPos.Proc8End:
                    Mitsubishi.Instance().ResetBit("M1327");
                    break;
                case TeachPos.Proc9Start:
                    Mitsubishi.Instance().ResetBit("M1308");
                    break;
                case TeachPos.Proc9End:
                    Mitsubishi.Instance().ResetBit("M1328");
                    break;
                case TeachPos.Proc10Start:
                    Mitsubishi.Instance().ResetBit("M1309");
                    break;
                case TeachPos.Proc10End:
                    Mitsubishi.Instance().ResetBit("M1329");
                    break;
                case TeachPos.Proc11Start:
                    Mitsubishi.Instance().ResetBit("M1310");
                    break;
                case TeachPos.Proc11End:
                    Mitsubishi.Instance().ResetBit("M1330");
                    break;
                case TeachPos.Proc12Start:
                    Mitsubishi.Instance().ResetBit("M1311");
                    break;
                case TeachPos.Proc12End:
                    Mitsubishi.Instance().ResetBit("M1331");
                    break;
                case TeachPos.Proc13Start:
                    Mitsubishi.Instance().ResetBit("M1312");
                    break;
                case TeachPos.Proc13End:
                    Mitsubishi.Instance().ResetBit("M1332");
                    break;
                case TeachPos.Proc14Start:
                    Mitsubishi.Instance().ResetBit("M1313");
                    break;
                case TeachPos.Proc14End:
                    Mitsubishi.Instance().ResetBit("M1333");
                    break;
                case TeachPos.Proc15Start:
                    Mitsubishi.Instance().ResetBit("M1314");
                    break;
                case TeachPos.Proc15End:
                    Mitsubishi.Instance().ResetBit("M1334");
                    break;
                case TeachPos.Proc16Start:
                    Mitsubishi.Instance().ResetBit("M1315");
                    break;
                case TeachPos.Proc16End:
                    Mitsubishi.Instance().ResetBit("M1335");
                    break;
                case TeachPos.Proc17Start:
                    Mitsubishi.Instance().ResetBit("M1316");
                    break;
                case TeachPos.Proc17End:
                    Mitsubishi.Instance().ResetBit("M1336");
                    break;
                case TeachPos.Proc18Start:
                    Mitsubishi.Instance().ResetBit("M1317");
                    break;
                case TeachPos.Proc18End:
                    Mitsubishi.Instance().ResetBit("M1337");
                    break;
                case TeachPos.Proc19Start:
                    Mitsubishi.Instance().ResetBit("M1318");
                    break;
                case TeachPos.Proc19End:
                    Mitsubishi.Instance().ResetBit("M1338");
                    break;
                case TeachPos.Proc20Start:
                    Mitsubishi.Instance().ResetBit("M1319");
                    break;
                case TeachPos.Proc20End:
                    Mitsubishi.Instance().ResetBit("M1339");
                    break;

            }
        }

        private void btnJogUp_MouseDown(object sender, MouseEventArgs e)
        {
            switch (_curServo)
            {
                case ServoSelect.X:
                    Mitsubishi.Instance().SetBit("M58");
                    break;
                case ServoSelect.Y:
                    Mitsubishi.Instance().SetBit("M60");
                    break;
                case ServoSelect.T:
                    Mitsubishi.Instance().SetBit("M62");
                    break;
            }
        }

        private void btnJogUp_MouseUp(object sender, MouseEventArgs e)
        {
            switch (_curServo)
            {
                case ServoSelect.X:
                    Mitsubishi.Instance().ResetBit("M58");
                    break;
                case ServoSelect.Y:
                    Mitsubishi.Instance().ResetBit("M60");
                    break;
                case ServoSelect.T:
                    Mitsubishi.Instance().ResetBit("M62");
                    break;
            }
        }

        private void btnJogDn_MouseDown(object sender, MouseEventArgs e)
        {
            switch (_curServo)
            {
                case ServoSelect.X:
                    Mitsubishi.Instance().SetBit("M59");
                    break;
                case ServoSelect.Y:
                    Mitsubishi.Instance().SetBit("M61");
                    break;
                case ServoSelect.T:
                    Mitsubishi.Instance().SetBit("M63");
                    break;
            }
        }

        private void btnJogDn_MouseUp(object sender, MouseEventArgs e)
        {
            switch (_curServo)
            {
                case ServoSelect.X:
                    Mitsubishi.Instance().ResetBit("M59");
                    break;
                case ServoSelect.Y:
                    Mitsubishi.Instance().ResetBit("M61");
                    break;
                case ServoSelect.T:
                    Mitsubishi.Instance().ResetBit("M63");
                    break;
            }
        }

        private void btnHome_MouseDown(object sender, MouseEventArgs e)
        {
            switch (_curServo)
            {
                case ServoSelect.X:
                    Mitsubishi.Instance().SetBit("M10");
                    break;
                case ServoSelect.Y:
                    Mitsubishi.Instance().SetBit("M11");
                    break;
                case ServoSelect.T:
                    Mitsubishi.Instance().SetBit("M12");
                    break;
            }
        }

        private void btnHome_MouseUp(object sender, MouseEventArgs e)
        {
            switch (_curServo)
            {
                case ServoSelect.X:
                    Mitsubishi.Instance().ResetBit("M10");
                    break;
                case ServoSelect.Y:
                    Mitsubishi.Instance().ResetBit("M11");
                    break;
                case ServoSelect.T:
                    Mitsubishi.Instance().ResetBit("M12");
                    break;
            }
        }

        private void btnMoveStop_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1169");
        }

        private void btnMoveStop_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1169");
        }

        private void btnSaveTeach_Click(object sender, EventArgs e)
        {
            WriteTeachingData();
            MessageBox.Show("OK");
        }

        void CalculateTarget()
        {
            ServoTeaching.LoadPos.TargetX = ServoTeaching.LoadPos.FixX + ServoTeaching.LoadPos.OffsetX;
            ServoTeaching.LoadPos.TargetY = ServoTeaching.LoadPos.FixY + ServoTeaching.LoadPos.OffsetY;
            ServoTeaching.LoadPos.TargetT = ServoTeaching.LoadPos.FixT + ServoTeaching.LoadPos.OffsetT;

            ServoTeaching.UnLoadOKPos.TargetX = ServoTeaching.UnLoadOKPos.FixX + ServoTeaching.UnLoadOKPos.OffsetX;
            ServoTeaching.UnLoadOKPos.TargetY = ServoTeaching.UnLoadOKPos.FixY + ServoTeaching.UnLoadOKPos.OffsetY;
            ServoTeaching.UnLoadOKPos.TargetT = ServoTeaching.UnLoadOKPos.FixT + ServoTeaching.UnLoadOKPos.OffsetT;

            ServoTeaching.UnLoadNGPos.TargetX = ServoTeaching.UnLoadNGPos.FixX + ServoTeaching.UnLoadNGPos.OffsetX;
            ServoTeaching.UnLoadNGPos.TargetY = ServoTeaching.UnLoadNGPos.FixY + ServoTeaching.UnLoadNGPos.OffsetY;
            ServoTeaching.UnLoadNGPos.TargetT = ServoTeaching.UnLoadNGPos.FixT + ServoTeaching.UnLoadNGPos.OffsetT;

            ServoTeaching.Proc1StartPos.TargetX = ServoTeaching.Proc1StartPos.FixX + ServoTeaching.Proc1StartPos.OffsetX;
            ServoTeaching.Proc1StartPos.TargetY = ServoTeaching.Proc1StartPos.FixY + ServoTeaching.Proc1StartPos.OffsetY;
            ServoTeaching.Proc1StartPos.TargetT = ServoTeaching.Proc1StartPos.FixT + ServoTeaching.Proc1StartPos.OffsetT;

            ServoTeaching.Proc1EndPos.TargetX = ServoTeaching.Proc1EndPos.FixX + ServoTeaching.Proc1EndPos.OffsetX;
            ServoTeaching.Proc1EndPos.TargetY = ServoTeaching.Proc1EndPos.FixY + ServoTeaching.Proc1EndPos.OffsetY;
            ServoTeaching.Proc1EndPos.TargetT = ServoTeaching.Proc1EndPos.FixT + ServoTeaching.Proc1EndPos.OffsetT;

            ServoTeaching.Proc2StartPos.TargetX = ServoTeaching.Proc2StartPos.FixX + ServoTeaching.Proc2StartPos.OffsetX;
            ServoTeaching.Proc2StartPos.TargetY = ServoTeaching.Proc2StartPos.FixY + ServoTeaching.Proc2StartPos.OffsetY;
            ServoTeaching.Proc2StartPos.TargetT = ServoTeaching.Proc2StartPos.FixT + ServoTeaching.Proc2StartPos.OffsetT;

            ServoTeaching.Proc2EndPos.TargetX = ServoTeaching.Proc2EndPos.FixX + ServoTeaching.Proc2EndPos.OffsetX;
            ServoTeaching.Proc2EndPos.TargetY = ServoTeaching.Proc2EndPos.FixY + ServoTeaching.Proc2EndPos.OffsetY;
            ServoTeaching.Proc2EndPos.TargetT = ServoTeaching.Proc2EndPos.FixT + ServoTeaching.Proc2EndPos.OffsetT;

            ServoTeaching.Proc3StartPos.TargetX = ServoTeaching.Proc3StartPos.FixX + ServoTeaching.Proc3StartPos.OffsetX;
            ServoTeaching.Proc3StartPos.TargetY = ServoTeaching.Proc3StartPos.FixY + ServoTeaching.Proc3StartPos.OffsetY;
            ServoTeaching.Proc3StartPos.TargetT = ServoTeaching.Proc3StartPos.FixT + ServoTeaching.Proc3StartPos.OffsetT;

            ServoTeaching.Proc3EndPos.TargetX = ServoTeaching.Proc3EndPos.FixX + ServoTeaching.Proc3EndPos.OffsetX;
            ServoTeaching.Proc3EndPos.TargetY = ServoTeaching.Proc3EndPos.FixY + ServoTeaching.Proc3EndPos.OffsetY;
            ServoTeaching.Proc3EndPos.TargetT = ServoTeaching.Proc3EndPos.FixT + ServoTeaching.Proc3EndPos.OffsetT;

            ServoTeaching.Proc4StartPos.TargetX = ServoTeaching.Proc4StartPos.FixX + ServoTeaching.Proc4StartPos.OffsetX;
            ServoTeaching.Proc4StartPos.TargetY = ServoTeaching.Proc4StartPos.FixY + ServoTeaching.Proc4StartPos.OffsetY;
            ServoTeaching.Proc4StartPos.TargetT = ServoTeaching.Proc4StartPos.FixT + ServoTeaching.Proc4StartPos.OffsetT;

            ServoTeaching.Proc4EndPos.TargetX = ServoTeaching.Proc4EndPos.FixX + ServoTeaching.Proc4EndPos.OffsetX;
            ServoTeaching.Proc4EndPos.TargetY = ServoTeaching.Proc4EndPos.FixY + ServoTeaching.Proc4EndPos.OffsetY;
            ServoTeaching.Proc4EndPos.TargetT = ServoTeaching.Proc4EndPos.FixT + ServoTeaching.Proc4EndPos.OffsetT;

            ServoTeaching.Proc5StartPos.TargetX = ServoTeaching.Proc5StartPos.FixX + ServoTeaching.Proc5StartPos.OffsetX;
            ServoTeaching.Proc5StartPos.TargetY = ServoTeaching.Proc5StartPos.FixY + ServoTeaching.Proc5StartPos.OffsetY;
            ServoTeaching.Proc5StartPos.TargetT = ServoTeaching.Proc5StartPos.FixT + ServoTeaching.Proc5StartPos.OffsetT;

            ServoTeaching.Proc5EndPos.TargetX = ServoTeaching.Proc5EndPos.FixX + ServoTeaching.Proc5EndPos.OffsetX;
            ServoTeaching.Proc5EndPos.TargetY = ServoTeaching.Proc5EndPos.FixY + ServoTeaching.Proc5EndPos.OffsetY;
            ServoTeaching.Proc5EndPos.TargetT = ServoTeaching.Proc5EndPos.FixT + ServoTeaching.Proc5EndPos.OffsetT;

            ServoTeaching.Proc6StartPos.TargetX = ServoTeaching.Proc6StartPos.FixX + ServoTeaching.Proc6StartPos.OffsetX;
            ServoTeaching.Proc6StartPos.TargetY = ServoTeaching.Proc6StartPos.FixY + ServoTeaching.Proc6StartPos.OffsetY;
            ServoTeaching.Proc6StartPos.TargetT = ServoTeaching.Proc6StartPos.FixT + ServoTeaching.Proc6StartPos.OffsetT;

            ServoTeaching.Proc6EndPos.TargetX = ServoTeaching.Proc6EndPos.FixX + ServoTeaching.Proc6EndPos.OffsetX;
            ServoTeaching.Proc6EndPos.TargetY = ServoTeaching.Proc6EndPos.FixY + ServoTeaching.Proc6EndPos.OffsetY;
            ServoTeaching.Proc6EndPos.TargetT = ServoTeaching.Proc6EndPos.FixT + ServoTeaching.Proc6EndPos.OffsetT;

            ServoTeaching.Proc7StartPos.TargetX = ServoTeaching.Proc7StartPos.FixX + ServoTeaching.Proc7StartPos.OffsetX;
            ServoTeaching.Proc7StartPos.TargetY = ServoTeaching.Proc7StartPos.FixY + ServoTeaching.Proc7StartPos.OffsetY;
            ServoTeaching.Proc7StartPos.TargetT = ServoTeaching.Proc7StartPos.FixT + ServoTeaching.Proc7StartPos.OffsetT;

            ServoTeaching.Proc7EndPos.TargetX = ServoTeaching.Proc7EndPos.FixX + ServoTeaching.Proc7EndPos.OffsetX;
            ServoTeaching.Proc7EndPos.TargetY = ServoTeaching.Proc7EndPos.FixY + ServoTeaching.Proc7EndPos.OffsetY;
            ServoTeaching.Proc7EndPos.TargetT = ServoTeaching.Proc7EndPos.FixT + ServoTeaching.Proc7EndPos.OffsetT;

            ServoTeaching.Proc8StartPos.TargetX = ServoTeaching.Proc8StartPos.FixX + ServoTeaching.Proc8StartPos.OffsetX;
            ServoTeaching.Proc8StartPos.TargetY = ServoTeaching.Proc8StartPos.FixY + ServoTeaching.Proc8StartPos.OffsetY;
            ServoTeaching.Proc8StartPos.TargetT = ServoTeaching.Proc8StartPos.FixT + ServoTeaching.Proc8StartPos.OffsetT;

            ServoTeaching.Proc8EndPos.TargetX = ServoTeaching.Proc8EndPos.FixX + ServoTeaching.Proc8EndPos.OffsetX;
            ServoTeaching.Proc8EndPos.TargetY = ServoTeaching.Proc8EndPos.FixY + ServoTeaching.Proc8EndPos.OffsetY;
            ServoTeaching.Proc8EndPos.TargetT = ServoTeaching.Proc8EndPos.FixT + ServoTeaching.Proc8EndPos.OffsetT;

            ServoTeaching.Proc9StartPos.TargetX = ServoTeaching.Proc9StartPos.FixX + ServoTeaching.Proc9StartPos.OffsetX;
            ServoTeaching.Proc9StartPos.TargetY = ServoTeaching.Proc9StartPos.FixY + ServoTeaching.Proc9StartPos.OffsetY;
            ServoTeaching.Proc9StartPos.TargetT = ServoTeaching.Proc9StartPos.FixT + ServoTeaching.Proc9StartPos.OffsetT;

            ServoTeaching.Proc9EndPos.TargetX = ServoTeaching.Proc9EndPos.FixX + ServoTeaching.Proc9EndPos.OffsetX;
            ServoTeaching.Proc9EndPos.TargetY = ServoTeaching.Proc9EndPos.FixY + ServoTeaching.Proc9EndPos.OffsetY;
            ServoTeaching.Proc9EndPos.TargetT = ServoTeaching.Proc9EndPos.FixT + ServoTeaching.Proc9EndPos.OffsetT;

            ServoTeaching.Proc10StartPos.TargetX = ServoTeaching.Proc10StartPos.FixX + ServoTeaching.Proc10StartPos.OffsetX;
            ServoTeaching.Proc10StartPos.TargetY = ServoTeaching.Proc10StartPos.FixY + ServoTeaching.Proc10StartPos.OffsetY;
            ServoTeaching.Proc10StartPos.TargetT = ServoTeaching.Proc10StartPos.FixT + ServoTeaching.Proc10StartPos.OffsetT;

            ServoTeaching.Proc10EndPos.TargetX = ServoTeaching.Proc10EndPos.FixX + ServoTeaching.Proc10EndPos.OffsetX;
            ServoTeaching.Proc10EndPos.TargetY = ServoTeaching.Proc10EndPos.FixY + ServoTeaching.Proc10EndPos.OffsetY;
            ServoTeaching.Proc10EndPos.TargetT = ServoTeaching.Proc10EndPos.FixT + ServoTeaching.Proc10EndPos.OffsetT;

            ServoTeaching.Proc11StartPos.TargetX = ServoTeaching.Proc11StartPos.FixX + ServoTeaching.Proc11StartPos.OffsetX;
            ServoTeaching.Proc11StartPos.TargetY = ServoTeaching.Proc11StartPos.FixY + ServoTeaching.Proc11StartPos.OffsetY;
            ServoTeaching.Proc11StartPos.TargetT = ServoTeaching.Proc11StartPos.FixT + ServoTeaching.Proc11StartPos.OffsetT;

            ServoTeaching.Proc11EndPos.TargetX = ServoTeaching.Proc11EndPos.FixX + ServoTeaching.Proc11EndPos.OffsetX;
            ServoTeaching.Proc11EndPos.TargetY = ServoTeaching.Proc11EndPos.FixY + ServoTeaching.Proc11EndPos.OffsetY;
            ServoTeaching.Proc11EndPos.TargetT = ServoTeaching.Proc11EndPos.FixT + ServoTeaching.Proc11EndPos.OffsetT;

            ServoTeaching.Proc12StartPos.TargetX = ServoTeaching.Proc12StartPos.FixX + ServoTeaching.Proc12StartPos.OffsetX;
            ServoTeaching.Proc12StartPos.TargetY = ServoTeaching.Proc12StartPos.FixY + ServoTeaching.Proc12StartPos.OffsetY;
            ServoTeaching.Proc12StartPos.TargetT = ServoTeaching.Proc12StartPos.FixT + ServoTeaching.Proc12StartPos.OffsetT;

            ServoTeaching.Proc12EndPos.TargetX = ServoTeaching.Proc12EndPos.FixX + ServoTeaching.Proc12EndPos.OffsetX;
            ServoTeaching.Proc12EndPos.TargetY = ServoTeaching.Proc12EndPos.FixY + ServoTeaching.Proc12EndPos.OffsetY;
            ServoTeaching.Proc12EndPos.TargetT = ServoTeaching.Proc12EndPos.FixT + ServoTeaching.Proc12EndPos.OffsetT;

            ServoTeaching.Proc13StartPos.TargetX = ServoTeaching.Proc13StartPos.FixX + ServoTeaching.Proc13StartPos.OffsetX;
            ServoTeaching.Proc13StartPos.TargetY = ServoTeaching.Proc13StartPos.FixY + ServoTeaching.Proc13StartPos.OffsetY;
            ServoTeaching.Proc13StartPos.TargetT = ServoTeaching.Proc13StartPos.FixT + ServoTeaching.Proc13StartPos.OffsetT;

            ServoTeaching.Proc13EndPos.TargetX = ServoTeaching.Proc13EndPos.FixX + ServoTeaching.Proc13EndPos.OffsetX;
            ServoTeaching.Proc13EndPos.TargetY = ServoTeaching.Proc13EndPos.FixY + ServoTeaching.Proc13EndPos.OffsetY;
            ServoTeaching.Proc13EndPos.TargetT = ServoTeaching.Proc13EndPos.FixT + ServoTeaching.Proc13EndPos.OffsetT;

            ServoTeaching.Proc14StartPos.TargetX = ServoTeaching.Proc14StartPos.FixX + ServoTeaching.Proc14StartPos.OffsetX;
            ServoTeaching.Proc14StartPos.TargetY = ServoTeaching.Proc14StartPos.FixY + ServoTeaching.Proc14StartPos.OffsetY;
            ServoTeaching.Proc14StartPos.TargetT = ServoTeaching.Proc14StartPos.FixT + ServoTeaching.Proc14StartPos.OffsetT;

            ServoTeaching.Proc14EndPos.TargetX = ServoTeaching.Proc14EndPos.FixX + ServoTeaching.Proc14EndPos.OffsetX;
            ServoTeaching.Proc14EndPos.TargetY = ServoTeaching.Proc14EndPos.FixY + ServoTeaching.Proc14EndPos.OffsetY;
            ServoTeaching.Proc14EndPos.TargetT = ServoTeaching.Proc14EndPos.FixT + ServoTeaching.Proc14EndPos.OffsetT;

            ServoTeaching.Proc15StartPos.TargetX = ServoTeaching.Proc15StartPos.FixX + ServoTeaching.Proc15StartPos.OffsetX;
            ServoTeaching.Proc15StartPos.TargetY = ServoTeaching.Proc15StartPos.FixY + ServoTeaching.Proc15StartPos.OffsetY;
            ServoTeaching.Proc15StartPos.TargetT = ServoTeaching.Proc15StartPos.FixT + ServoTeaching.Proc15StartPos.OffsetT;

            ServoTeaching.Proc15EndPos.TargetX = ServoTeaching.Proc15EndPos.FixX + ServoTeaching.Proc15EndPos.OffsetX;
            ServoTeaching.Proc15EndPos.TargetY = ServoTeaching.Proc15EndPos.FixY + ServoTeaching.Proc15EndPos.OffsetY;
            ServoTeaching.Proc15EndPos.TargetT = ServoTeaching.Proc15EndPos.FixT + ServoTeaching.Proc15EndPos.OffsetT;

            ServoTeaching.Proc16StartPos.TargetX = ServoTeaching.Proc16StartPos.FixX + ServoTeaching.Proc16StartPos.OffsetX;
            ServoTeaching.Proc16StartPos.TargetY = ServoTeaching.Proc16StartPos.FixY + ServoTeaching.Proc16StartPos.OffsetY;
            ServoTeaching.Proc16StartPos.TargetT = ServoTeaching.Proc16StartPos.FixT + ServoTeaching.Proc16StartPos.OffsetT;

            ServoTeaching.Proc16EndPos.TargetX = ServoTeaching.Proc16EndPos.FixX + ServoTeaching.Proc16EndPos.OffsetX;
            ServoTeaching.Proc16EndPos.TargetY = ServoTeaching.Proc16EndPos.FixY + ServoTeaching.Proc16EndPos.OffsetY;
            ServoTeaching.Proc16EndPos.TargetT = ServoTeaching.Proc16EndPos.FixT + ServoTeaching.Proc16EndPos.OffsetT;

            ServoTeaching.Proc17StartPos.TargetX = ServoTeaching.Proc17StartPos.FixX + ServoTeaching.Proc17StartPos.OffsetX;
            ServoTeaching.Proc17StartPos.TargetY = ServoTeaching.Proc17StartPos.FixY + ServoTeaching.Proc17StartPos.OffsetY;
            ServoTeaching.Proc17StartPos.TargetT = ServoTeaching.Proc17StartPos.FixT + ServoTeaching.Proc17StartPos.OffsetT;

            ServoTeaching.Proc17EndPos.TargetX = ServoTeaching.Proc17EndPos.FixX + ServoTeaching.Proc17EndPos.OffsetX;
            ServoTeaching.Proc17EndPos.TargetY = ServoTeaching.Proc17EndPos.FixY + ServoTeaching.Proc17EndPos.OffsetY;
            ServoTeaching.Proc17EndPos.TargetT = ServoTeaching.Proc17EndPos.FixT + ServoTeaching.Proc17EndPos.OffsetT;

            ServoTeaching.Proc18StartPos.TargetX = ServoTeaching.Proc18StartPos.FixX + ServoTeaching.Proc18StartPos.OffsetX;
            ServoTeaching.Proc18StartPos.TargetY = ServoTeaching.Proc18StartPos.FixY + ServoTeaching.Proc18StartPos.OffsetY;
            ServoTeaching.Proc18StartPos.TargetT = ServoTeaching.Proc18StartPos.FixT + ServoTeaching.Proc18StartPos.OffsetT;

            ServoTeaching.Proc18EndPos.TargetX = ServoTeaching.Proc18EndPos.FixX + ServoTeaching.Proc18EndPos.OffsetX;
            ServoTeaching.Proc18EndPos.TargetY = ServoTeaching.Proc18EndPos.FixY + ServoTeaching.Proc18EndPos.OffsetY;
            ServoTeaching.Proc18EndPos.TargetT = ServoTeaching.Proc18EndPos.FixT + ServoTeaching.Proc18EndPos.OffsetT;

            ServoTeaching.Proc19StartPos.TargetX = ServoTeaching.Proc19StartPos.FixX + ServoTeaching.Proc19StartPos.OffsetX;
            ServoTeaching.Proc19StartPos.TargetY = ServoTeaching.Proc19StartPos.FixY + ServoTeaching.Proc19StartPos.OffsetY;
            ServoTeaching.Proc19StartPos.TargetT = ServoTeaching.Proc19StartPos.FixT + ServoTeaching.Proc19StartPos.OffsetT;

            ServoTeaching.Proc19EndPos.TargetX = ServoTeaching.Proc19EndPos.FixX + ServoTeaching.Proc19EndPos.OffsetX;
            ServoTeaching.Proc19EndPos.TargetY = ServoTeaching.Proc19EndPos.FixY + ServoTeaching.Proc19EndPos.OffsetY;
            ServoTeaching.Proc19EndPos.TargetT = ServoTeaching.Proc19EndPos.FixT + ServoTeaching.Proc19EndPos.OffsetT;

            ServoTeaching.Proc20StartPos.TargetX = ServoTeaching.Proc20StartPos.FixX + ServoTeaching.Proc20StartPos.OffsetX;
            ServoTeaching.Proc20StartPos.TargetY = ServoTeaching.Proc20StartPos.FixY + ServoTeaching.Proc20StartPos.OffsetY;
            ServoTeaching.Proc20StartPos.TargetT = ServoTeaching.Proc20StartPos.FixT + ServoTeaching.Proc20StartPos.OffsetT;

            ServoTeaching.Proc20EndPos.TargetX = ServoTeaching.Proc20EndPos.FixX + ServoTeaching.Proc20EndPos.OffsetX;
            ServoTeaching.Proc20EndPos.TargetY = ServoTeaching.Proc20EndPos.FixY + ServoTeaching.Proc20EndPos.OffsetY;
            ServoTeaching.Proc20EndPos.TargetT = ServoTeaching.Proc20EndPos.FixT + ServoTeaching.Proc20EndPos.OffsetT;



        }

        private void rjtFixX__TextChanged(object sender, EventArgs e)
        {
            Int32 data = 0;
            if (Int32.TryParse(rjtFixX.Texts, out data))
            {
                FixXChange(data);
                CalculateTarget();
                ServoDataUpdateInfo(_curTechPos);
            }
        }

        private void rjtFixY__TextChanged(object sender, EventArgs e)
        {
            Int32 data = 0;
            if (Int32.TryParse(rjtFixY.Texts, out data))
            {
                FixYChange(data);
                CalculateTarget();
                ServoDataUpdateInfo(_curTechPos);
            }
        }

        private void rjtFixT__TextChanged(object sender, EventArgs e)
        {
            Int32 data = 0;
            if (Int32.TryParse(rjtFixT.Texts, out data))
            {
                FixTChange(data);
                CalculateTarget();
                ServoDataUpdateInfo(_curTechPos);
            }
        }

        private void rjtOffsetX__TextChanged(object sender, EventArgs e)
        {
          
                Int32 data = 0;
                if (Int32.TryParse(rjtOffsetX.Texts, out data))
                {
                    OffsetXChange(data);
                    CalculateTarget();
                    ServoDataUpdateInfo(_curTechPos);
               
                }
          
        }

        private void rjtOffsetY__TextChanged(object sender, EventArgs e)
        {
            Int32 data = 0;
            if (Int32.TryParse(rjtOffsetY.Texts, out data))
            {
                OffsetYChange(data);
                CalculateTarget();
                ServoDataUpdateInfo(_curTechPos);
            }
        }

        private void rjtOffsetT__TextChanged(object sender, EventArgs e)
        {
            Int32 data = 0;
            if (Int32.TryParse(rjtOffsetT.Texts, out data))
            {
                OffsetTChange(data);
                CalculateTarget();
                ServoDataUpdateInfo(_curTechPos);
            }
        }

        private void rjtSpeedX__TextChanged(object sender, EventArgs e)
        {
            Int32 data = 0;
            if (Int32.TryParse(rjtSpeedX.Texts, out data))
            {
                SpeedXChange(data);
            }
        }

        private void rjtSpeedY__TextChanged(object sender, EventArgs e)
        {
            Int32 data = 0;
            if (Int32.TryParse(rjtSpeedY.Texts, out data))
            {
                SpeedYChange(data);
            }
        }

        private void rjtSpeedT__TextChanged(object sender, EventArgs e)
        {
            Int32 data = 0;
            if (Int32.TryParse(rjtSpeedT.Texts, out data))
            {
                SpeedTChange(data);
            }
        }
        void FixXChange(Int32 ValueData)
        {
            switch (_curTechPos)
            {
                case TeachPos.Load:
                    ServoTeaching.LoadPos.FixX = ValueData;
                    break;
                case TeachPos.UnloadOK:
                    ServoTeaching.UnLoadOKPos.FixX = ValueData;
                    break;
                case TeachPos.UnloadNG:
                    ServoTeaching.UnLoadNGPos.FixX = ValueData;
                    break;
                case TeachPos.Proc1Start:
                    ServoTeaching.Proc1StartPos.FixX = ValueData;
                    break;
                case TeachPos.Proc1End:
                    ServoTeaching.Proc1EndPos.FixX = ValueData;
                    break;
                case TeachPos.Proc2Start:
                    ServoTeaching.Proc2StartPos.FixX = ValueData;
                    break;
                case TeachPos.Proc2End:
                    ServoTeaching.Proc2EndPos.FixX = ValueData;
                    break;
                case TeachPos.Proc3Start:
                    ServoTeaching.Proc3StartPos.FixX = ValueData;
                    break;
                case TeachPos.Proc3End:
                    ServoTeaching.Proc3EndPos.FixX = ValueData;
                    break;
                case TeachPos.Proc4Start:
                    ServoTeaching.Proc4StartPos.FixX = ValueData;
                    break;
                case TeachPos.Proc4End:
                    ServoTeaching.Proc4EndPos.FixX = ValueData;
                    break;
                case TeachPos.Proc5Start:
                    ServoTeaching.Proc5StartPos.FixX = ValueData;
                    break;
                case TeachPos.Proc5End:
                    ServoTeaching.Proc5EndPos.FixX = ValueData;
                    break;
                case TeachPos.Proc6Start:
                    ServoTeaching.Proc6StartPos.FixX = ValueData;
                    break;
                case TeachPos.Proc6End:
                    ServoTeaching.Proc6EndPos.FixX = ValueData;
                    break;
                case TeachPos.Proc7Start:
                    ServoTeaching.Proc7StartPos.FixX = ValueData;
                    break;
                case TeachPos.Proc7End:
                    ServoTeaching.Proc7EndPos.FixX = ValueData;
                    break;
                case TeachPos.Proc8Start:
                    ServoTeaching.Proc8StartPos.FixX = ValueData;
                    break;
                case TeachPos.Proc8End:
                    ServoTeaching.Proc8EndPos.FixX = ValueData;
                    break;
                case TeachPos.Proc9Start:
                    ServoTeaching.Proc9StartPos.FixX = ValueData;
                    break;
                case TeachPos.Proc9End:
                    ServoTeaching.Proc9EndPos.FixX = ValueData;
                    break;
                case TeachPos.Proc10Start:
                    ServoTeaching.Proc10StartPos.FixX = ValueData;
                    break;
                case TeachPos.Proc10End:
                    ServoTeaching.Proc10EndPos.FixX = ValueData;
                    break;
                case TeachPos.Proc11Start:
                    ServoTeaching.Proc11StartPos.FixX = ValueData;
                    break;
                case TeachPos.Proc11End:
                    ServoTeaching.Proc11EndPos.FixX = ValueData;
                    break;
                case TeachPos.Proc12Start:
                    ServoTeaching.Proc12StartPos.FixX = ValueData;
                    break;
                case TeachPos.Proc12End:
                    ServoTeaching.Proc12EndPos.FixX = ValueData;
                    break;
                case TeachPos.Proc13Start:
                    ServoTeaching.Proc13StartPos.FixX = ValueData;
                    break;
                case TeachPos.Proc13End:
                    ServoTeaching.Proc13EndPos.FixX = ValueData;
                    break;
                case TeachPos.Proc14Start:
                    ServoTeaching.Proc14StartPos.FixX = ValueData;
                    break;
                case TeachPos.Proc14End:
                    ServoTeaching.Proc14EndPos.FixX = ValueData;
                    break;
                case TeachPos.Proc15Start:
                    ServoTeaching.Proc15StartPos.FixX = ValueData;
                    break;
                case TeachPos.Proc15End:
                    ServoTeaching.Proc15EndPos.FixX = ValueData;
                    break;
                case TeachPos.Proc16Start:
                    ServoTeaching.Proc16StartPos.FixX = ValueData;
                    break;
                case TeachPos.Proc16End:
                    ServoTeaching.Proc16EndPos.FixX = ValueData;
                    break;
                case TeachPos.Proc17Start:
                    ServoTeaching.Proc17StartPos.FixX = ValueData;
                    break;
                case TeachPos.Proc17End:
                    ServoTeaching.Proc17EndPos.FixX = ValueData;
                    break;
                case TeachPos.Proc18Start:
                    ServoTeaching.Proc18StartPos.FixX = ValueData;
                    break;
                case TeachPos.Proc18End:
                    ServoTeaching.Proc18EndPos.FixX = ValueData;
                    break;
                case TeachPos.Proc19Start:
                    ServoTeaching.Proc19StartPos.FixX = ValueData;
                    break;
                case TeachPos.Proc19End:
                    ServoTeaching.Proc19EndPos.FixX = ValueData;
                    break;
                case TeachPos.Proc20Start:
                    ServoTeaching.Proc20StartPos.FixX = ValueData;
                    break;
                case TeachPos.Proc20End:
                    ServoTeaching.Proc20EndPos.FixX = ValueData;
                    break;

            }
        }
        void FixYChange(Int32 ValueData)
        {
            switch (_curTechPos)
            {
                case TeachPos.Load:
                    ServoTeaching.LoadPos.FixY = ValueData;
                    break;
                case TeachPos.UnloadOK:
                    ServoTeaching.UnLoadOKPos.FixY = ValueData;
                    break;
                case TeachPos.UnloadNG:
                    ServoTeaching.UnLoadNGPos.FixY = ValueData;
                    break;
                case TeachPos.Proc1Start:
                    ServoTeaching.Proc1StartPos.FixY = ValueData;
                    break;
                case TeachPos.Proc1End:
                    ServoTeaching.Proc1EndPos.FixY = ValueData;
                    break;
                case TeachPos.Proc2Start:
                    ServoTeaching.Proc2StartPos.FixY = ValueData;
                    break;
                case TeachPos.Proc2End:
                    ServoTeaching.Proc2EndPos.FixY = ValueData;
                    break;
                case TeachPos.Proc3Start:
                    ServoTeaching.Proc3StartPos.FixY = ValueData;
                    break;
                case TeachPos.Proc3End:
                    ServoTeaching.Proc3EndPos.FixY = ValueData;
                    break;
                case TeachPos.Proc4Start:
                    ServoTeaching.Proc4StartPos.FixY = ValueData;
                    break;
                case TeachPos.Proc4End:
                    ServoTeaching.Proc4EndPos.FixY = ValueData;
                    break;
                case TeachPos.Proc5Start:
                    ServoTeaching.Proc5StartPos.FixY = ValueData;
                    break;
                case TeachPos.Proc5End:
                    ServoTeaching.Proc5EndPos.FixY = ValueData;
                    break;
                case TeachPos.Proc6Start:
                    ServoTeaching.Proc6StartPos.FixY = ValueData;
                    break;
                case TeachPos.Proc6End:
                    ServoTeaching.Proc6EndPos.FixY = ValueData;
                    break;
                case TeachPos.Proc7Start:
                    ServoTeaching.Proc7StartPos.FixY = ValueData;
                    break;
                case TeachPos.Proc7End:
                    ServoTeaching.Proc7EndPos.FixY = ValueData;
                    break;
                case TeachPos.Proc8Start:
                    ServoTeaching.Proc8StartPos.FixY = ValueData;
                    break;
                case TeachPos.Proc8End:
                    ServoTeaching.Proc8EndPos.FixY = ValueData;
                    break;
                case TeachPos.Proc9Start:
                    ServoTeaching.Proc9StartPos.FixY = ValueData;
                    break;
                case TeachPos.Proc9End:
                    ServoTeaching.Proc9EndPos.FixY = ValueData;
                    break;
                case TeachPos.Proc10Start:
                    ServoTeaching.Proc10StartPos.FixY = ValueData;
                    break;
                case TeachPos.Proc10End:
                    ServoTeaching.Proc10EndPos.FixY = ValueData;
                    break;
                case TeachPos.Proc11Start:
                    ServoTeaching.Proc11StartPos.FixY = ValueData;
                    break;
                case TeachPos.Proc11End:
                    ServoTeaching.Proc11EndPos.FixY = ValueData;
                    break;
                case TeachPos.Proc12Start:
                    ServoTeaching.Proc12StartPos.FixY = ValueData;
                    break;
                case TeachPos.Proc12End:
                    ServoTeaching.Proc12EndPos.FixY = ValueData;
                    break;
                case TeachPos.Proc13Start:
                    ServoTeaching.Proc13StartPos.FixY = ValueData;
                    break;
                case TeachPos.Proc13End:
                    ServoTeaching.Proc13EndPos.FixY = ValueData;
                    break;
                case TeachPos.Proc14Start:
                    ServoTeaching.Proc14StartPos.FixY = ValueData;
                    break;
                case TeachPos.Proc14End:
                    ServoTeaching.Proc14EndPos.FixY = ValueData;
                    break;
                case TeachPos.Proc15Start:
                    ServoTeaching.Proc15StartPos.FixY = ValueData;
                    break;
                case TeachPos.Proc15End:
                    ServoTeaching.Proc15EndPos.FixY = ValueData;
                    break;
                case TeachPos.Proc16Start:
                    ServoTeaching.Proc16StartPos.FixY = ValueData;
                    break;
                case TeachPos.Proc16End:
                    ServoTeaching.Proc16EndPos.FixY = ValueData;
                    break;
                case TeachPos.Proc17Start:
                    ServoTeaching.Proc17StartPos.FixY = ValueData;
                    break;
                case TeachPos.Proc17End:
                    ServoTeaching.Proc17EndPos.FixY = ValueData;
                    break;
                case TeachPos.Proc18Start:
                    ServoTeaching.Proc18StartPos.FixY = ValueData;
                    break;
                case TeachPos.Proc18End:
                    ServoTeaching.Proc18EndPos.FixY = ValueData;
                    break;
                case TeachPos.Proc19Start:
                    ServoTeaching.Proc19StartPos.FixY = ValueData;
                    break;
                case TeachPos.Proc19End:
                    ServoTeaching.Proc19EndPos.FixY = ValueData;
                    break;
                case TeachPos.Proc20Start:
                    ServoTeaching.Proc20StartPos.FixY = ValueData;
                    break;
                case TeachPos.Proc20End:
                    ServoTeaching.Proc20EndPos.FixY = ValueData;
                    break;


            }
        }
        void FixTChange(Int32 ValueData)
        {
            switch (_curTechPos)
            {
                case TeachPos.Load:
                    ServoTeaching.LoadPos.FixT = ValueData;
                    break;
                case TeachPos.UnloadOK:
                    ServoTeaching.UnLoadOKPos.FixT = ValueData;
                    break;
                case TeachPos.UnloadNG:
                    ServoTeaching.UnLoadNGPos.FixT = ValueData;
                    break;
                case TeachPos.Proc1Start:
                    ServoTeaching.Proc1StartPos.FixT = ValueData;
                    break;
                case TeachPos.Proc1End:
                    ServoTeaching.Proc1EndPos.FixT = ValueData;
                    break;
                case TeachPos.Proc2Start:
                    ServoTeaching.Proc2StartPos.FixT = ValueData;
                    break;
                case TeachPos.Proc2End:
                    ServoTeaching.Proc2EndPos.FixT = ValueData;
                    break;
                case TeachPos.Proc3Start:
                    ServoTeaching.Proc3StartPos.FixT = ValueData;
                    break;
                case TeachPos.Proc3End:
                    ServoTeaching.Proc3EndPos.FixT = ValueData;
                    break;
                case TeachPos.Proc4Start:
                    ServoTeaching.Proc4StartPos.FixT = ValueData;
                    break;
                case TeachPos.Proc4End:
                    ServoTeaching.Proc4EndPos.FixT = ValueData;
                    break;
                case TeachPos.Proc5Start:
                    ServoTeaching.Proc5StartPos.FixT = ValueData;
                    break;
                case TeachPos.Proc5End:
                    ServoTeaching.Proc5EndPos.FixT = ValueData;
                    break;
                case TeachPos.Proc6Start:
                    ServoTeaching.Proc6StartPos.FixT = ValueData;
                    break;
                case TeachPos.Proc6End:
                    ServoTeaching.Proc6EndPos.FixT = ValueData;
                    break;
                case TeachPos.Proc7Start:
                    ServoTeaching.Proc7StartPos.FixT = ValueData;
                    break;
                case TeachPos.Proc7End:
                    ServoTeaching.Proc7EndPos.FixT = ValueData;
                    break;
                case TeachPos.Proc8Start:
                    ServoTeaching.Proc8StartPos.FixT = ValueData;
                    break;
                case TeachPos.Proc8End:
                    ServoTeaching.Proc8EndPos.FixT = ValueData;
                    break;
                case TeachPos.Proc9Start:
                    ServoTeaching.Proc9StartPos.FixT = ValueData;
                    break;
                case TeachPos.Proc9End:
                    ServoTeaching.Proc9EndPos.FixT = ValueData;
                    break;
                case TeachPos.Proc10Start:
                    ServoTeaching.Proc10StartPos.FixT = ValueData;
                    break;
                case TeachPos.Proc10End:
                    ServoTeaching.Proc10EndPos.FixT = ValueData;
                    break;
                case TeachPos.Proc11Start:
                    ServoTeaching.Proc11StartPos.FixT = ValueData;
                    break;
                case TeachPos.Proc11End:
                    ServoTeaching.Proc11EndPos.FixT = ValueData;
                    break;
                case TeachPos.Proc12Start:
                    ServoTeaching.Proc12StartPos.FixT = ValueData;
                    break;
                case TeachPos.Proc12End:
                    ServoTeaching.Proc12EndPos.FixT = ValueData;
                    break;
                case TeachPos.Proc13Start:
                    ServoTeaching.Proc13StartPos.FixT = ValueData;
                    break;
                case TeachPos.Proc13End:
                    ServoTeaching.Proc13EndPos.FixT = ValueData;
                    break;
                case TeachPos.Proc14Start:
                    ServoTeaching.Proc14StartPos.FixT = ValueData;
                    break;
                case TeachPos.Proc14End:
                    ServoTeaching.Proc14EndPos.FixT = ValueData;
                    break;
                case TeachPos.Proc15Start:
                    ServoTeaching.Proc15StartPos.FixT = ValueData;
                    break;
                case TeachPos.Proc15End:
                    ServoTeaching.Proc15EndPos.FixT = ValueData;
                    break;
                case TeachPos.Proc16Start:
                    ServoTeaching.Proc16StartPos.FixT = ValueData;
                    break;
                case TeachPos.Proc16End:
                    ServoTeaching.Proc16EndPos.FixT = ValueData;
                    break;
                case TeachPos.Proc17Start:
                    ServoTeaching.Proc17StartPos.FixT = ValueData;
                    break;
                case TeachPos.Proc17End:
                    ServoTeaching.Proc17EndPos.FixT = ValueData;
                    break;
                case TeachPos.Proc18Start:
                    ServoTeaching.Proc18StartPos.FixT = ValueData;
                    break;
                case TeachPos.Proc18End:
                    ServoTeaching.Proc18EndPos.FixT = ValueData;
                    break;
                case TeachPos.Proc19Start:
                    ServoTeaching.Proc19StartPos.FixT = ValueData;
                    break;
                case TeachPos.Proc19End:
                    ServoTeaching.Proc19EndPos.FixT = ValueData;
                    break;
                case TeachPos.Proc20Start:
                    ServoTeaching.Proc20StartPos.FixT = ValueData;
                    break;
                case TeachPos.Proc20End:
                    ServoTeaching.Proc20EndPos.FixT = ValueData;
                    break;

            }
        }
        void OffsetXChange(Int32 ValueData)
        {
            switch (_curTechPos)
            {
                case TeachPos.Load:
                    ServoTeaching.LoadPos.OffsetX = ValueData;
                    break;
                case TeachPos.UnloadOK:
                    ServoTeaching.UnLoadOKPos.OffsetX = ValueData;
                    break;
                case TeachPos.UnloadNG:
                    ServoTeaching.UnLoadNGPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc1Start:
                    ServoTeaching.Proc1StartPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc1End:
                    ServoTeaching.Proc1EndPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc2Start:
                    ServoTeaching.Proc2StartPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc2End:
                    ServoTeaching.Proc2EndPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc3Start:
                    ServoTeaching.Proc3StartPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc3End:
                    ServoTeaching.Proc3EndPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc4Start:
                    ServoTeaching.Proc4StartPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc4End:
                    ServoTeaching.Proc4EndPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc5Start:
                    ServoTeaching.Proc5StartPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc5End:
                    ServoTeaching.Proc5EndPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc6Start:
                    ServoTeaching.Proc6StartPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc6End:
                    ServoTeaching.Proc6EndPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc7Start:
                    ServoTeaching.Proc7StartPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc7End:
                    ServoTeaching.Proc7EndPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc8Start:
                    ServoTeaching.Proc8StartPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc8End:
                    ServoTeaching.Proc8EndPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc9Start:
                    ServoTeaching.Proc8StartPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc9End:
                    ServoTeaching.Proc9EndPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc10Start:
                    ServoTeaching.Proc10StartPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc10End:
                    ServoTeaching.Proc10EndPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc11Start:
                    ServoTeaching.Proc11StartPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc11End:
                    ServoTeaching.Proc11EndPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc12Start:
                    ServoTeaching.Proc12StartPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc12End:
                    ServoTeaching.Proc12EndPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc13Start:
                    ServoTeaching.Proc13StartPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc13End:
                    ServoTeaching.Proc13EndPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc14Start:
                    ServoTeaching.Proc14StartPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc14End:
                    ServoTeaching.Proc14EndPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc15Start:
                    ServoTeaching.Proc15StartPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc15End:
                    ServoTeaching.Proc15EndPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc16Start:
                    ServoTeaching.Proc16StartPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc16End:
                    ServoTeaching.Proc16EndPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc17Start:
                    ServoTeaching.Proc17StartPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc17End:
                    ServoTeaching.Proc17EndPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc18Start:
                    ServoTeaching.Proc18StartPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc18End:
                    ServoTeaching.Proc18EndPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc19Start:
                    ServoTeaching.Proc19StartPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc19End:
                    ServoTeaching.Proc19EndPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc20Start:
                    ServoTeaching.Proc20StartPos.OffsetX = ValueData;
                    break;
                case TeachPos.Proc20End:
                    ServoTeaching.Proc20EndPos.OffsetX = ValueData;
                    break;

            }
        }
        void OffsetYChange(Int32 ValueData)
        {
            switch (_curTechPos)
            {
                case TeachPos.Load:
                    ServoTeaching.LoadPos.OffsetY = ValueData;
                    break;
                case TeachPos.UnloadOK:
                    ServoTeaching.UnLoadOKPos.OffsetY = ValueData;
                    break;
                case TeachPos.UnloadNG:
                    ServoTeaching.UnLoadNGPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc1Start:
                    ServoTeaching.Proc1StartPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc1End:
                    ServoTeaching.Proc1EndPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc2Start:
                    ServoTeaching.Proc2StartPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc2End:
                    ServoTeaching.Proc2EndPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc3Start:
                    ServoTeaching.Proc3StartPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc3End:
                    ServoTeaching.Proc3EndPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc4Start:
                    ServoTeaching.Proc4StartPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc4End:
                    ServoTeaching.Proc4EndPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc5Start:
                    ServoTeaching.Proc5StartPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc5End:
                    ServoTeaching.Proc5EndPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc6Start:
                    ServoTeaching.Proc6StartPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc6End:
                    ServoTeaching.Proc6EndPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc7Start:
                    ServoTeaching.Proc7StartPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc7End:
                    ServoTeaching.Proc7EndPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc8Start:
                    ServoTeaching.Proc8StartPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc8End:
                    ServoTeaching.Proc8EndPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc9Start:
                    ServoTeaching.Proc9StartPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc9End:
                    ServoTeaching.Proc9EndPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc10Start:
                    ServoTeaching.Proc10StartPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc10End:
                    ServoTeaching.Proc10EndPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc11Start:
                    ServoTeaching.Proc11StartPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc11End:
                    ServoTeaching.Proc11EndPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc12Start:
                    ServoTeaching.Proc12StartPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc12End:
                    ServoTeaching.Proc12EndPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc13Start:
                    ServoTeaching.Proc13StartPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc13End:
                    ServoTeaching.Proc13EndPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc14Start:
                    ServoTeaching.Proc14StartPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc14End:
                    ServoTeaching.Proc14EndPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc15Start:
                    ServoTeaching.Proc15StartPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc15End:
                    ServoTeaching.Proc15EndPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc16Start:
                    ServoTeaching.Proc16StartPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc16End:
                    ServoTeaching.Proc16EndPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc17Start:
                    ServoTeaching.Proc17StartPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc17End:
                    ServoTeaching.Proc17EndPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc18Start:
                    ServoTeaching.Proc18StartPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc18End:
                    ServoTeaching.Proc18EndPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc19Start:
                    ServoTeaching.Proc19StartPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc19End:
                    ServoTeaching.Proc19EndPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc20Start:
                    ServoTeaching.Proc20StartPos.OffsetY = ValueData;
                    break;
                case TeachPos.Proc20End:
                    ServoTeaching.Proc20EndPos.OffsetY = ValueData;
                    break;


            }
        }
        void OffsetTChange(Int32 ValueData)
        {
            switch (_curTechPos)
            {
                case TeachPos.Load:
                    ServoTeaching.LoadPos.OffsetT = ValueData;
                    break;
                case TeachPos.UnloadOK:
                    ServoTeaching.UnLoadOKPos.OffsetT = ValueData;
                    break;
                case TeachPos.UnloadNG:
                    ServoTeaching.UnLoadNGPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc1Start:
                    ServoTeaching.Proc1StartPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc1End:
                    ServoTeaching.Proc1EndPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc2Start:
                    ServoTeaching.Proc2StartPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc2End:
                    ServoTeaching.Proc2EndPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc3Start:
                    ServoTeaching.Proc3StartPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc3End:
                    ServoTeaching.Proc3EndPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc4Start:
                    ServoTeaching.Proc4StartPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc4End:
                    ServoTeaching.Proc4EndPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc5Start:
                    ServoTeaching.Proc5StartPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc5End:
                    ServoTeaching.Proc5EndPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc6Start:
                    ServoTeaching.Proc6StartPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc6End:
                    ServoTeaching.Proc6EndPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc7Start:
                    ServoTeaching.Proc7StartPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc7End:
                    ServoTeaching.Proc7EndPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc8Start:
                    ServoTeaching.Proc8StartPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc8End:
                    ServoTeaching.Proc8EndPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc9Start:
                    ServoTeaching.Proc9StartPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc9End:
                    ServoTeaching.Proc9EndPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc10Start:
                    ServoTeaching.Proc10StartPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc10End:
                    ServoTeaching.Proc10EndPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc11Start:
                    ServoTeaching.Proc11StartPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc11End:
                    ServoTeaching.Proc11EndPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc12Start:
                    ServoTeaching.Proc12StartPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc12End:
                    ServoTeaching.Proc12EndPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc13Start:
                    ServoTeaching.Proc13StartPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc13End:
                    ServoTeaching.Proc13EndPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc14Start:
                    ServoTeaching.Proc14StartPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc14End:
                    ServoTeaching.Proc14EndPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc15Start:
                    ServoTeaching.Proc15StartPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc15End:
                    ServoTeaching.Proc15EndPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc16Start:
                    ServoTeaching.Proc16StartPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc16End:
                    ServoTeaching.Proc16EndPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc17Start:
                    ServoTeaching.Proc17StartPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc17End:
                    ServoTeaching.Proc17EndPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc18Start:
                    ServoTeaching.Proc18StartPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc18End:
                    ServoTeaching.Proc18EndPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc19Start:
                    ServoTeaching.Proc19StartPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc19End:
                    ServoTeaching.Proc19EndPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc20Start:
                    ServoTeaching.Proc20StartPos.OffsetT = ValueData;
                    break;
                case TeachPos.Proc20End:
                    ServoTeaching.Proc20EndPos.OffsetT = ValueData;
                    break;

            }
        }
        void SpeedXChange(Int32 ValueData)
        {
            switch (_curTechPos)
            {
                case TeachPos.Load:
                    ServoTeaching.LoadPos.SpeedX = ValueData;
                    break;
                case TeachPos.UnloadOK:
                    ServoTeaching.UnLoadOKPos.SpeedX = ValueData;
                    break;
                case TeachPos.UnloadNG:
                    ServoTeaching.UnLoadNGPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc1Start:
                    ServoTeaching.Proc1StartPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc1End:
                    ServoTeaching.Proc1EndPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc2Start:
                    ServoTeaching.Proc2StartPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc2End:
                    ServoTeaching.Proc2EndPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc3Start:
                    ServoTeaching.Proc3StartPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc3End:
                    ServoTeaching.Proc3EndPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc4Start:
                    ServoTeaching.Proc4StartPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc4End:
                    ServoTeaching.Proc4EndPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc5Start:
                    ServoTeaching.Proc5StartPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc5End:
                    ServoTeaching.Proc5EndPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc6Start:
                    ServoTeaching.Proc6StartPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc6End:
                    ServoTeaching.Proc6EndPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc7Start:
                    ServoTeaching.Proc7StartPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc7End:
                    ServoTeaching.Proc7EndPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc8Start:
                    ServoTeaching.Proc8StartPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc8End:
                    ServoTeaching.Proc8EndPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc9Start:
                    ServoTeaching.Proc9StartPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc9End:
                    ServoTeaching.Proc9EndPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc10Start:
                    ServoTeaching.Proc10StartPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc10End:
                    ServoTeaching.Proc10EndPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc11Start:
                    ServoTeaching.Proc11StartPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc11End:
                    ServoTeaching.Proc11EndPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc12Start:
                    ServoTeaching.Proc12StartPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc12End:
                    ServoTeaching.Proc12EndPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc13Start:
                    ServoTeaching.Proc13StartPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc13End:
                    ServoTeaching.Proc13EndPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc14Start:
                    ServoTeaching.Proc14StartPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc14End:
                    ServoTeaching.Proc14EndPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc15Start:
                    ServoTeaching.Proc15StartPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc15End:
                    ServoTeaching.Proc15EndPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc16Start:
                    ServoTeaching.Proc16StartPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc16End:
                    ServoTeaching.Proc16EndPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc17Start:
                    ServoTeaching.Proc17StartPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc17End:
                    ServoTeaching.Proc17EndPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc18Start:
                    ServoTeaching.Proc18StartPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc18End:
                    ServoTeaching.Proc18EndPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc19Start:
                    ServoTeaching.Proc19StartPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc19End:
                    ServoTeaching.Proc19EndPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc20Start:
                    ServoTeaching.Proc20StartPos.SpeedX = ValueData;
                    break;
                case TeachPos.Proc20End:
                    ServoTeaching.Proc20EndPos.SpeedX = ValueData;
                    break;
            }
        }
        void SpeedYChange(Int32 ValueData)
        {
            switch (_curTechPos)
            {
                case TeachPos.Load:
                    ServoTeaching.LoadPos.SpeedY = ValueData;
                    break;
                case TeachPos.UnloadOK:
                    ServoTeaching.UnLoadOKPos.SpeedY = ValueData;
                    break;
                case TeachPos.UnloadNG:
                    ServoTeaching.UnLoadNGPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc1Start:
                    ServoTeaching.Proc1StartPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc1End:
                    ServoTeaching.Proc1EndPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc2Start:
                    ServoTeaching.Proc2StartPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc2End:
                    ServoTeaching.Proc2EndPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc3Start:
                    ServoTeaching.Proc3StartPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc3End:
                    ServoTeaching.Proc3EndPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc4Start:
                    ServoTeaching.Proc4StartPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc4End:
                    ServoTeaching.Proc4EndPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc5Start:
                    ServoTeaching.Proc5StartPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc5End:
                    ServoTeaching.Proc5EndPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc6Start:
                    ServoTeaching.Proc6StartPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc6End:
                    ServoTeaching.Proc6EndPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc7Start:
                    ServoTeaching.Proc7StartPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc7End:
                    ServoTeaching.Proc7EndPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc8Start:
                    ServoTeaching.Proc8StartPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc8End:
                    ServoTeaching.Proc8EndPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc9Start:
                    ServoTeaching.Proc9StartPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc9End:
                    ServoTeaching.Proc9EndPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc10Start:
                    ServoTeaching.Proc10StartPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc10End:
                    ServoTeaching.Proc10EndPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc11Start:
                    ServoTeaching.Proc11StartPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc11End:
                    ServoTeaching.Proc11EndPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc12Start:
                    ServoTeaching.Proc12StartPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc12End:
                    ServoTeaching.Proc12EndPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc13Start:
                    ServoTeaching.Proc13StartPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc13End:
                    ServoTeaching.Proc13EndPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc14Start:
                    ServoTeaching.Proc14StartPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc14End:
                    ServoTeaching.Proc14EndPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc15Start:
                    ServoTeaching.Proc15StartPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc15End:
                    ServoTeaching.Proc15EndPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc16Start:
                    ServoTeaching.Proc16StartPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc16End:
                    ServoTeaching.Proc16EndPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc17Start:
                    ServoTeaching.Proc17StartPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc17End:
                    ServoTeaching.Proc17EndPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc18Start:
                    ServoTeaching.Proc18StartPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc18End:
                    ServoTeaching.Proc18EndPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc19Start:
                    ServoTeaching.Proc19StartPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc19End:
                    ServoTeaching.Proc19EndPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc20Start:
                    ServoTeaching.Proc20StartPos.SpeedY = ValueData;
                    break;
                case TeachPos.Proc20End:
                    ServoTeaching.Proc20EndPos.SpeedY = ValueData;
                    break;
            }
        }

        void SpeedTChange(Int32 ValueData)
        {
            switch (_curTechPos)
            {
                case TeachPos.Load:
                    ServoTeaching.LoadPos.SpeedT = ValueData;
                    break;
                case TeachPos.UnloadOK:
                    ServoTeaching.UnLoadOKPos.SpeedT = ValueData;
                    break;
                case TeachPos.UnloadNG:
                    ServoTeaching.UnLoadNGPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc1Start:
                    ServoTeaching.Proc1StartPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc1End:
                    ServoTeaching.Proc1EndPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc2Start:
                    ServoTeaching.Proc2StartPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc2End:
                    ServoTeaching.Proc2EndPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc3Start:
                    ServoTeaching.Proc3StartPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc3End:
                    ServoTeaching.Proc3EndPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc4Start:
                    ServoTeaching.Proc4StartPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc4End:
                    ServoTeaching.Proc4EndPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc5Start:
                    ServoTeaching.Proc5StartPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc5End:
                    ServoTeaching.Proc5EndPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc6Start:
                    ServoTeaching.Proc6StartPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc6End:
                    ServoTeaching.Proc6EndPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc7Start:
                    ServoTeaching.Proc7StartPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc7End:
                    ServoTeaching.Proc7EndPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc8Start:
                    ServoTeaching.Proc8StartPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc8End:
                    ServoTeaching.Proc8EndPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc9Start:
                    ServoTeaching.Proc9StartPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc9End:
                    ServoTeaching.Proc9EndPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc10Start:
                    ServoTeaching.Proc10StartPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc10End:
                    ServoTeaching.Proc10EndPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc11Start:
                    ServoTeaching.Proc11StartPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc11End:
                    ServoTeaching.Proc11EndPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc12Start:
                    ServoTeaching.Proc12StartPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc12End:
                    ServoTeaching.Proc12EndPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc13Start:
                    ServoTeaching.Proc13StartPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc13End:
                    ServoTeaching.Proc13EndPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc14Start:
                    ServoTeaching.Proc14StartPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc14End:
                    ServoTeaching.Proc14EndPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc15Start:
                    ServoTeaching.Proc15StartPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc15End:
                    ServoTeaching.Proc15EndPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc16Start:
                    ServoTeaching.Proc16StartPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc16End:
                    ServoTeaching.Proc16EndPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc17Start:
                    ServoTeaching.Proc17StartPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc17End:
                    ServoTeaching.Proc17EndPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc18Start:
                    ServoTeaching.Proc18StartPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc18End:
                    ServoTeaching.Proc18EndPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc19Start:
                    ServoTeaching.Proc19StartPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc19End:
                    ServoTeaching.Proc19EndPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc20Start:
                    ServoTeaching.Proc20StartPos.SpeedT = ValueData;
                    break;
                case TeachPos.Proc20End:
                    ServoTeaching.Proc20EndPos.SpeedT = ValueData;
                    break;
            }
        }

        void ReadTeachingData()
        {

            switch (_curTechPos)
            {
                case TeachPos.Load:
                    //Load Pos


                    Mitsubishi.Instance().ReadDint("R6160", ref ServoTeaching.LoadPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6560", ref ServoTeaching.LoadPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6886", ref ServoTeaching.LoadPos.FixT);
                    ////Mitsubishi.Instance().WriteDint("R6050", ServoTeaching.LoadPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6250", ServoTeaching.LoadPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6250", ServoTeaching.LoadPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6162", ref ServoTeaching.LoadPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6562", ref ServoTeaching.LoadPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.LoadPos.SpeedT);
                    break;
                case TeachPos.UnloadOK:
                    //UnLoadOK Pos
                    Mitsubishi.Instance().ReadDint("R6164", ref ServoTeaching.UnLoadOKPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6564", ref ServoTeaching.UnLoadOKPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6888", ref ServoTeaching.UnLoadOKPos.FixT);


                    ////Mitsubishi.Instance().WriteDint("R6052", ServoTeaching.UnLoadOKPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6252", ServoTeaching.UnLoadOKPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6252", ServoTeaching.UnLoadOKPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6166", ref ServoTeaching.UnLoadOKPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6566", ref ServoTeaching.UnLoadOKPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.UnLoadOKPos.SpeedT);
                    break;
                case TeachPos.UnloadNG:
                    //UnLoadNG Pos
                    Mitsubishi.Instance().ReadDint("R6168", ref ServoTeaching.UnLoadNGPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6568", ref ServoTeaching.UnLoadNGPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6890", ref ServoTeaching.UnLoadNGPos.FixT);


                    ////Mitsubishi.Instance().WriteDint("R6054", ServoTeaching.UnLoadNGPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6254", ServoTeaching.UnLoadNGPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6254", ServoTeaching.UnLoadNGPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6170", ref ServoTeaching.UnLoadNGPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6570", ref ServoTeaching.UnLoadNGPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.UnLoadNGPos.SpeedT);
                    break;
                case TeachPos.Proc1Start:

                    //Proc1 Start Pos

                    Mitsubishi.Instance().ReadDint("R6000", ref ServoTeaching.Proc1StartPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6400", ref ServoTeaching.Proc1StartPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6800", ref ServoTeaching.Proc1StartPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6056", ServoTeaching.Proc1StartPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6256", ServoTeaching.Proc1StartPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6256", ServoTeaching.Proc1StartPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6002", ref ServoTeaching.Proc1StartPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6402", ref ServoTeaching.Proc1StartPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc1StartPos.SpeedT);
                    break;
                case TeachPos.Proc1End:
                    //Proc1 End Pos
                    Mitsubishi.Instance().ReadDint("R6080", ref ServoTeaching.Proc1EndPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6480", ref ServoTeaching.Proc1EndPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6846", ref ServoTeaching.Proc1EndPos.FixT);


                    ////Mitsubishi.Instance().WriteDint("R6058", ServoTeaching.Proc1EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6258", ServoTeaching.Proc1EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6258", ServoTeaching.Proc1EndPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6082", ref ServoTeaching.Proc1EndPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6482", ref ServoTeaching.Proc1EndPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc1EndPos.SpeedT);
                    break;
                case TeachPos.Proc2Start:

                    //Proc2 Start Pos
                    Mitsubishi.Instance().ReadDint("R6004", ref ServoTeaching.Proc2StartPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6404", ref ServoTeaching.Proc2StartPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6804", ref ServoTeaching.Proc2StartPos.FixT);


                    ////Mitsubishi.Instance().WriteDint("R6060", ServoTeaching.Proc2StartPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6260", ServoTeaching.Proc2StartPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6260", ServoTeaching.Proc2StartPos.OffsetT);


                    Mitsubishi.Instance().ReadDint("R6006", ref ServoTeaching.Proc2StartPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6406", ref ServoTeaching.Proc2StartPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc2StartPos.SpeedT);
                    break;
                case TeachPos.Proc2End:

                    //Proc2 End Pos
                    Mitsubishi.Instance().ReadDint("R6084", ref ServoTeaching.Proc2EndPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6484", ref ServoTeaching.Proc2EndPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6848", ref ServoTeaching.Proc2EndPos.FixT);
                    ////Mitsubishi.Instance().WriteDint("R6062", ServoTeaching.Proc2EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6262", ServoTeaching.Proc2EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6262", ServoTeaching.Proc2EndPos.OffsetT);


                    Mitsubishi.Instance().ReadDint("R6086", ref ServoTeaching.Proc2EndPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6486", ref ServoTeaching.Proc2EndPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc2EndPos.SpeedT);
                    break;
                case TeachPos.Proc3Start:
                    //Proc3 Start Pos
                    Mitsubishi.Instance().ReadDint("R6008", ref ServoTeaching.Proc3StartPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6408", ref ServoTeaching.Proc3StartPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6808", ref ServoTeaching.Proc3StartPos.FixT);


                    ////Mitsubishi.Instance().WriteDint("R6064", ServoTeaching.Proc3StartPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6264", ServoTeaching.Proc3StartPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6264", ServoTeaching.Proc3StartPos.OffsetT);


                    Mitsubishi.Instance().ReadDint("R6010", ref ServoTeaching.Proc3StartPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6410", ref ServoTeaching.Proc3StartPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc3StartPos.SpeedT);
                    break;
                case TeachPos.Proc3End:
                    //Proc3 End Pos
                    Mitsubishi.Instance().ReadDint("R6088", ref ServoTeaching.Proc3EndPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6488", ref ServoTeaching.Proc3EndPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6850", ref ServoTeaching.Proc3EndPos.FixT);


                    ////Mitsubishi.Instance().WriteDint("R6066", ServoTeaching.Proc3EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6266", ServoTeaching.Proc3EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6266", ServoTeaching.Proc3EndPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6090", ref ServoTeaching.Proc3EndPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6490", ref ServoTeaching.Proc3EndPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc3EndPos.SpeedT);
                    break;
                case TeachPos.Proc4Start:
                    //Proc4 Start Pos
                    Mitsubishi.Instance().ReadDint("R6012", ref ServoTeaching.Proc4StartPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6412", ref ServoTeaching.Proc4StartPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6812", ref ServoTeaching.Proc4StartPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6068", ServoTeaching.Proc4StartPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6268", ServoTeaching.Proc4StartPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6268", ServoTeaching.Proc4StartPos.OffsetT);
                    Mitsubishi.Instance().ReadDint("R6014", ref ServoTeaching.Proc4StartPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6414", ref ServoTeaching.Proc4StartPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc4StartPos.SpeedT);
                    break;
                case TeachPos.Proc4End:
                    //Proc4 End Pos
                    Mitsubishi.Instance().ReadDint("R6092", ref ServoTeaching.Proc4EndPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6492", ref ServoTeaching.Proc4EndPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6852", ref ServoTeaching.Proc4EndPos.FixT);


                    ////Mitsubishi.Instance().WriteDint("R6070", ServoTeaching.Proc4EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6270", ServoTeaching.Proc4EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6270", ServoTeaching.Proc4EndPos.OffsetT);
                    ///
                    Mitsubishi.Instance().ReadDint("R6094", ref ServoTeaching.Proc4EndPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6494", ref ServoTeaching.Proc4EndPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc4EndPos.SpeedT);
                    break;
                case TeachPos.Proc5Start:
                    //Proc5 Start Pos
                    Mitsubishi.Instance().ReadDint("R6016", ref ServoTeaching.Proc5StartPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6416", ref ServoTeaching.Proc5StartPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6816", ref ServoTeaching.Proc5StartPos.FixT);


                    ////Mitsubishi.Instance().WriteDint("R6072", ServoTeaching.Proc5StartPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6272", ServoTeaching.Proc5StartPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6272", ServoTeaching.Proc5StartPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6018", ref ServoTeaching.Proc5StartPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6418", ref ServoTeaching.Proc5StartPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc5StartPos.SpeedT);
                    break;
                case TeachPos.Proc5End:
                    //Proc5 End Pos
                    Mitsubishi.Instance().ReadDint("R6096", ref ServoTeaching.Proc5EndPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6496", ref ServoTeaching.Proc5EndPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6854", ref ServoTeaching.Proc5EndPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6074", ServoTeaching.Proc5EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6274", ServoTeaching.Proc5EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6274", ServoTeaching.Proc5EndPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6098", ref ServoTeaching.Proc5EndPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6498", ref ServoTeaching.Proc5EndPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc5EndPos.SpeedT);

                    break;
                case TeachPos.Proc6Start:
                    //Proc6 Start Pos
                    Mitsubishi.Instance().ReadDint("R6020", ref ServoTeaching.Proc6StartPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6420", ref ServoTeaching.Proc6StartPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6818", ref ServoTeaching.Proc6StartPos.FixT);


                    ////Mitsubishi.Instance().WriteDint("R6076", ServoTeaching.Proc6StartPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6276", ServoTeaching.Proc6StartPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6276", ServoTeaching.Proc6StartPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6022", ref ServoTeaching.Proc6StartPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6422", ref ServoTeaching.Proc6StartPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc6StartPos.SpeedT);

                    break;
                case TeachPos.Proc6End:
                    //Proc6 End Pos
                    Mitsubishi.Instance().ReadDint("R6100", ref ServoTeaching.Proc6EndPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6500", ref ServoTeaching.Proc6EndPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6856", ref ServoTeaching.Proc6EndPos.FixT);


                    ////Mitsubishi.Instance().WriteDint("R6078", ServoTeaching.Proc6EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6278", ServoTeaching.Proc6EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6278", ServoTeaching.Proc6EndPos.OffsetT);
                    Mitsubishi.Instance().ReadDint("R6102", ref ServoTeaching.Proc6EndPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6502", ref ServoTeaching.Proc6EndPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc6EndPos.SpeedT);

                    break;
                case TeachPos.Proc7Start:
                    //Proc7 Start Pos
                    Mitsubishi.Instance().ReadDint("R6024", ref ServoTeaching.Proc7StartPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6424", ref ServoTeaching.Proc7StartPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6820", ref ServoTeaching.Proc7StartPos.FixT);


                    ////Mitsubishi.Instance().WriteDint("R6080", ServoTeaching.Proc7StartPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6280", ServoTeaching.Proc7StartPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6280", ServoTeaching.Proc7StartPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6026", ref ServoTeaching.Proc7StartPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6426", ref ServoTeaching.Proc7StartPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc7StartPos.SpeedT);
                    break;
                case TeachPos.Proc7End:
                    //Proc7 End Pos
                    Mitsubishi.Instance().ReadDint("R6104", ref ServoTeaching.Proc7EndPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6504", ref ServoTeaching.Proc7EndPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6858", ref ServoTeaching.Proc7EndPos.FixT);


                    ////Mitsubishi.Instance().WriteDint("R6082", ServoTeaching.Proc7EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6282", ServoTeaching.Proc7EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6282", ServoTeaching.Proc7EndPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6106", ref ServoTeaching.Proc7EndPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6506", ref ServoTeaching.Proc7EndPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc7EndPos.SpeedT);

                    break;
                case TeachPos.Proc8Start:
                    //Proc8 Start Pos
                    Mitsubishi.Instance().ReadDint("R6028", ref ServoTeaching.Proc8StartPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6428", ref ServoTeaching.Proc8StartPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6822", ref ServoTeaching.Proc8StartPos.FixT);


                    ////Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc8StartPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc8StartPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc8StartPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6030", ref ServoTeaching.Proc8StartPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6430", ref ServoTeaching.Proc8StartPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc8StartPos.SpeedT);

                    break;
                case TeachPos.Proc8End:
                    //Proc8 End Pos
                    Mitsubishi.Instance().ReadDint("R6108", ref ServoTeaching.Proc8EndPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6508", ref ServoTeaching.Proc8EndPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6860", ref ServoTeaching.Proc8EndPos.FixT);


                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc8EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc8EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc8EndPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6110", ref ServoTeaching.Proc8EndPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6510", ref ServoTeaching.Proc8EndPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc8EndPos.SpeedT);

                    break;
                case TeachPos.Proc9Start:
                    //Proc9 Start Pos
                    Mitsubishi.Instance().ReadDint("R6032", ref ServoTeaching.Proc9StartPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6432", ref ServoTeaching.Proc9StartPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6823", ref ServoTeaching.Proc9StartPos.FixT);


                    //Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc9StartPos.OffsetX);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc9StartPos.OffsetY);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc9StartPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6034", ref ServoTeaching.Proc9StartPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6434", ref ServoTeaching.Proc9StartPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc9StartPos.SpeedT);

                    break;
                case TeachPos.Proc9End:
                    //Proc9 End Pos
                    Mitsubishi.Instance().ReadDint("R6112", ref ServoTeaching.Proc9EndPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6512", ref ServoTeaching.Proc9EndPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6862", ref ServoTeaching.Proc9EndPos.FixT);


                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc9EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc9EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc9EndPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6114", ref ServoTeaching.Proc9EndPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6514", ref ServoTeaching.Proc9EndPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc9EndPos.SpeedT);

                    break;
                case TeachPos.Proc10Start:
                    //Proc10 Start Pos
                    Mitsubishi.Instance().ReadDint("R6036", ref ServoTeaching.Proc10StartPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6436", ref ServoTeaching.Proc10StartPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6824", ref ServoTeaching.Proc10StartPos.FixT);


                    //Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc10StartPos.OffsetX);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc10StartPos.OffsetY);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc10StartPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6038", ref ServoTeaching.Proc10StartPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6438", ref ServoTeaching.Proc10StartPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc10StartPos.SpeedT);
                    break;
                case TeachPos.Proc10End:
                    //Proc10 End Pos
                    Mitsubishi.Instance().ReadDint("R6116", ref ServoTeaching.Proc10EndPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6516", ref ServoTeaching.Proc10EndPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6864", ref ServoTeaching.Proc10EndPos.FixT);


                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc10EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc10EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc10EndPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6118", ref ServoTeaching.Proc10EndPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6518", ref ServoTeaching.Proc10EndPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc10EndPos.SpeedT);

                    break;
                case TeachPos.Proc11Start:
                    //Proc11 Start Pos
                    Mitsubishi.Instance().ReadDint("R6040", ref ServoTeaching.Proc11StartPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6440", ref ServoTeaching.Proc11StartPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6826", ref ServoTeaching.Proc11StartPos.FixT);


                    //Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc11StartPos.OffsetX);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc11StartPos.OffsetY);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc11StartPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6042", ref ServoTeaching.Proc11StartPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6442", ref ServoTeaching.Proc11StartPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc11StartPos.SpeedT);

                    break;
                case TeachPos.Proc11End:
                    //Proc11 End Pos
                    Mitsubishi.Instance().ReadDint("R6120", ref ServoTeaching.Proc11EndPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6520", ref ServoTeaching.Proc11EndPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6866", ref ServoTeaching.Proc11EndPos.FixT);


                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc11EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc11EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc11EndPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6122", ref ServoTeaching.Proc11EndPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6522", ref ServoTeaching.Proc11EndPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc11EndPos.SpeedT);

                    break;
                case TeachPos.Proc12Start:
                    //Proc12 Start Pos

                    Mitsubishi.Instance().ReadDint("R6044", ref ServoTeaching.Proc12StartPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6444", ref ServoTeaching.Proc12StartPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6828", ref ServoTeaching.Proc12StartPos.FixT);
                    //Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc12StartPos.OffsetX);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc12StartPos.OffsetY);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc12StartPos.OffsetT);
                    Mitsubishi.Instance().ReadDint("R6046", ref ServoTeaching.Proc12StartPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6446", ref ServoTeaching.Proc12StartPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc12StartPos.SpeedT);

                    break;
                case TeachPos.Proc12End:
                    //Proc12 End Pos                                            

                    Mitsubishi.Instance().ReadDint("R6124", ref ServoTeaching.Proc12EndPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6524", ref ServoTeaching.Proc12EndPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6868", ref ServoTeaching.Proc12EndPos.FixT);
                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc12EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc12EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc12EndPos.OffsetT);
                    Mitsubishi.Instance().ReadDint("R6126", ref ServoTeaching.Proc12EndPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6526", ref ServoTeaching.Proc12EndPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc12EndPos.SpeedT);

                    break;
                case TeachPos.Proc13Start:
                    //Proc13 Start Pos

                    Mitsubishi.Instance().ReadDint("R6048", ref ServoTeaching.Proc13StartPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6448", ref ServoTeaching.Proc13StartPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6830", ref ServoTeaching.Proc13StartPos.FixT);
                    //Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc13StartPos.OffsetX);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc13StartPos.OffsetY);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc13StartPos.OffsetT);
                    Mitsubishi.Instance().ReadDint("R6050", ref ServoTeaching.Proc13StartPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6450", ref ServoTeaching.Proc13StartPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc13StartPos.SpeedT);

                    break;
                case TeachPos.Proc13End:
                    //Proc13 End Pos                                            

                    Mitsubishi.Instance().ReadDint("R6128", ref ServoTeaching.Proc13EndPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6528", ref ServoTeaching.Proc13EndPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6870", ref ServoTeaching.Proc13EndPos.FixT);
                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc13EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc13EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc13EndPos.OffsetT);
                    Mitsubishi.Instance().ReadDint("R6130", ref ServoTeaching.Proc13EndPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6530", ref ServoTeaching.Proc13EndPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc13EndPos.SpeedT);

                    break;
                case TeachPos.Proc14Start:
                    //Proc14 Start Pos

                    Mitsubishi.Instance().ReadDint("R6052", ref ServoTeaching.Proc14StartPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6452", ref ServoTeaching.Proc14StartPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6832", ref ServoTeaching.Proc14StartPos.FixT);
                    //Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc14StartPos.OffsetX);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc14StartPos.OffsetY);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc14StartPos.OffsetT);
                    Mitsubishi.Instance().ReadDint("R6054", ref ServoTeaching.Proc14StartPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6454", ref ServoTeaching.Proc14StartPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc14StartPos.SpeedT);

                    break;
                case TeachPos.Proc14End:
                    //Proc14 End Pos                                            

                    Mitsubishi.Instance().ReadDint("R6132", ref ServoTeaching.Proc14EndPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6532", ref ServoTeaching.Proc14EndPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6872", ref ServoTeaching.Proc14EndPos.FixT);
                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc14EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc14EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc14EndPos.OffsetT);
                    Mitsubishi.Instance().ReadDint("R6134", ref ServoTeaching.Proc14EndPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6534", ref ServoTeaching.Proc14EndPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc14EndPos.SpeedT);

                    break;
                case TeachPos.Proc15Start:
                    //Proc15 Start Pos

                    Mitsubishi.Instance().ReadDint("R6056", ref ServoTeaching.Proc15StartPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6456", ref ServoTeaching.Proc15StartPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6834", ref ServoTeaching.Proc15StartPos.FixT);
                    //Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc15StartPos.OffsetX);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc15StartPos.OffsetY);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc15StartPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6058", ref ServoTeaching.Proc15StartPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6458", ref ServoTeaching.Proc15StartPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc15StartPos.SpeedT);
                    break;
                case TeachPos.Proc15End:
                    //Proc15 End Pos                                            
                    Mitsubishi.Instance().ReadDint("R6136", ref ServoTeaching.Proc15EndPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6536", ref ServoTeaching.Proc15EndPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6874", ref ServoTeaching.Proc15EndPos.FixT);
                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc15EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc15EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc15EndPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6138", ref ServoTeaching.Proc15EndPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6538", ref ServoTeaching.Proc15EndPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc15EndPos.SpeedT);
                    break;
                case TeachPos.Proc16Start:
                    //Proc16 Start Pos

                    Mitsubishi.Instance().ReadDint("R6060", ref ServoTeaching.Proc16StartPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6460", ref ServoTeaching.Proc16StartPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6836", ref ServoTeaching.Proc16StartPos.FixT);
                    //Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc16StartPos.OffsetX);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc16StartPos.OffsetY);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc16StartPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6062", ref ServoTeaching.Proc16StartPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6462", ref ServoTeaching.Proc16StartPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc16StartPos.SpeedT);
                    break;
                case TeachPos.Proc16End:
                    //Proc16 End Pos                                            

                    Mitsubishi.Instance().ReadDint("R6140", ref ServoTeaching.Proc16EndPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6540", ref ServoTeaching.Proc16EndPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6876", ref ServoTeaching.Proc16EndPos.FixT);
                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc16EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc16EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc16EndPos.OffsetT);
                    Mitsubishi.Instance().ReadDint("R6142", ref ServoTeaching.Proc16EndPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6542", ref ServoTeaching.Proc16EndPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc16EndPos.SpeedT);

                    break;
                case TeachPos.Proc17Start:
                    //Proc17 Start Pos

                    Mitsubishi.Instance().ReadDint("R6064", ref ServoTeaching.Proc17StartPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6464", ref ServoTeaching.Proc17StartPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6838", ref ServoTeaching.Proc17StartPos.FixT);
                    //Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc17StartPos.OffsetX);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc17StartPos.OffsetY);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc17StartPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6066", ref ServoTeaching.Proc17StartPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6466", ref ServoTeaching.Proc17StartPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc17StartPos.SpeedT);

                    break;
                case TeachPos.Proc17End:
                    //Proc17 End Pos                                            
                    Mitsubishi.Instance().ReadDint("R6144", ref ServoTeaching.Proc17EndPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6544", ref ServoTeaching.Proc17EndPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6878", ref ServoTeaching.Proc17EndPos.FixT);
                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc17EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc17EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc17EndPos.OffsetT);
                    Mitsubishi.Instance().ReadDint("R6146", ref ServoTeaching.Proc17EndPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6546", ref ServoTeaching.Proc17EndPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc17EndPos.SpeedT);

                    break;
                case TeachPos.Proc18Start:
                    //Proc18 Start Pos

                    Mitsubishi.Instance().ReadDint("R6068", ref ServoTeaching.Proc18StartPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6468", ref ServoTeaching.Proc18StartPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6840", ref ServoTeaching.Proc18StartPos.FixT);
                    //Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc18StartPos.OffsetX);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc18StartPos.OffsetY);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc18StartPos.OffsetT);
                    Mitsubishi.Instance().ReadDint("R6070", ref ServoTeaching.Proc18StartPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6470", ref ServoTeaching.Proc18StartPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc18StartPos.SpeedT);

                    break;
                case TeachPos.Proc18End:
                    //Proc18 End Pos                                            

                    Mitsubishi.Instance().ReadDint("R6148", ref ServoTeaching.Proc18EndPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6548", ref ServoTeaching.Proc18EndPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6880", ref ServoTeaching.Proc18EndPos.FixT);
                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc18EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc18EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc18EndPos.OffsetT);
                    Mitsubishi.Instance().ReadDint("R6150", ref ServoTeaching.Proc18EndPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6550", ref ServoTeaching.Proc18EndPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc18EndPos.SpeedT);

                    break;
                case TeachPos.Proc19Start:
                    //Proc19 Start Pos
                    Mitsubishi.Instance().ReadDint("R6072", ref ServoTeaching.Proc19StartPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6472", ref ServoTeaching.Proc19StartPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6842", ref ServoTeaching.Proc19StartPos.FixT);

                    //Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc19StartPos.OffsetX);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc19StartPos.OffsetY);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc19StartPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6074", ref ServoTeaching.Proc19StartPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6474", ref ServoTeaching.Proc19StartPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc19StartPos.SpeedT);
                    break;
                case TeachPos.Proc19End:
                    //Proc19 End Pos                                            

                    Mitsubishi.Instance().ReadDint("R6152", ref ServoTeaching.Proc19EndPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6552", ref ServoTeaching.Proc19EndPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6882", ref ServoTeaching.Proc19EndPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc19EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc19EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc19EndPos.OffsetT);
                    Mitsubishi.Instance().ReadDint("R6154", ref ServoTeaching.Proc19EndPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6554", ref ServoTeaching.Proc19EndPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc19EndPos.SpeedT);

                    break;
                case TeachPos.Proc20Start:
                    //Proc20 Start Pos

                    Mitsubishi.Instance().ReadDint("R6076", ref ServoTeaching.Proc20StartPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6476", ref ServoTeaching.Proc20StartPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6844", ref ServoTeaching.Proc20StartPos.FixT);
                    //Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc20StartPos.OffsetX);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc20StartPos.OffsetY);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc20StartPos.OffsetT);
                    Mitsubishi.Instance().ReadDint("R6078", ref ServoTeaching.Proc20StartPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6478", ref ServoTeaching.Proc20StartPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc20StartPos.SpeedT);
                    break;
                case TeachPos.Proc20End:
                    //Proc20 End Pos                                            
                    Mitsubishi.Instance().ReadDint("R6156", ref ServoTeaching.Proc20EndPos.FixX);
                    Mitsubishi.Instance().ReadDint("R6556", ref ServoTeaching.Proc20EndPos.FixY);
                    Mitsubishi.Instance().ReadDint("R6884", ref ServoTeaching.Proc20EndPos.FixT);
                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc20EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc20EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc20EndPos.OffsetT);

                    Mitsubishi.Instance().ReadDint("R6158", ref ServoTeaching.Proc20EndPos.SpeedX);
                    Mitsubishi.Instance().ReadDint("R6558", ref ServoTeaching.Proc20EndPos.SpeedY);
                    Mitsubishi.Instance().ReadDint("R6802", ref ServoTeaching.Proc20EndPos.SpeedT);
                    break;
            }
        }
        void WriteTeachingData()
        {
            switch (_curTechPos)
            {
                case TeachPos.Load:
                    //Load Pos
                    Mitsubishi.Instance().WriteDint("R6160", ServoTeaching.LoadPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6560", ServoTeaching.LoadPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6886", ServoTeaching.LoadPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6050", ServoTeaching.LoadPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6250", ServoTeac  hing.LoadPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6250", ServoTeaching.LoadPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6162", ServoTeaching.LoadPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6562", ServoTeaching.LoadPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.LoadPos.SpeedT);
                    break;
                case TeachPos.UnloadOK:
                    //UnLoadOK Pos
                    Mitsubishi.Instance().WriteDint("R6164", ServoTeaching.UnLoadOKPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6564", ServoTeaching.UnLoadOKPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6888", ServoTeaching.UnLoadOKPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6052", ServoTeaching.UnLoadOKPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6252", ServoTeaching.UnLoadOKPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6252", ServoTeaching.UnLoadOKPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6166", ServoTeaching.UnLoadOKPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6566", ServoTeaching.UnLoadOKPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.UnLoadOKPos.SpeedT);
                    break;
                case TeachPos.UnloadNG:
                    //UnLoadNG Pos
                    Mitsubishi.Instance().WriteDint("R6168", ServoTeaching.UnLoadNGPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6568", ServoTeaching.UnLoadNGPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6890", ServoTeaching.UnLoadNGPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6054", ServoTeaching.UnLoadNGPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6254", ServoTeaching.UnLoadNGPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6254", ServoTeaching.UnLoadNGPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6170", ServoTeaching.UnLoadNGPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6570", ServoTeaching.UnLoadNGPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.UnLoadNGPos.SpeedT);
                    break;
                case TeachPos.Proc1Start:

                    //Proc1 Start Pos
                    Mitsubishi.Instance().WriteDint("R6000", ServoTeaching.Proc1StartPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6400", ServoTeaching.Proc1StartPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6800", ServoTeaching.Proc1StartPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6056", ServoTeaching.Proc1StartPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6256", ServoTeaching.Proc1StartPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6256", ServoTeaching.Proc1StartPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6002", ServoTeaching.Proc1StartPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6402", ServoTeaching.Proc1StartPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc1StartPos.SpeedT);
                    break;
                case TeachPos.Proc1End:
                    //Proc1 End Pos
                    Mitsubishi.Instance().WriteDint("R6080", ServoTeaching.Proc1EndPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6480", ServoTeaching.Proc1EndPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6846", ServoTeaching.Proc1EndPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6058", ServoTeaching.Proc1EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6258", ServoTeaching.Proc1EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6258", ServoTeaching.Proc1EndPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6082", ServoTeaching.Proc1EndPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6482", ServoTeaching.Proc1EndPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc1EndPos.SpeedT);
                    break;
                case TeachPos.Proc2Start:

                    //Proc2 Start Pos
                    Mitsubishi.Instance().WriteDint("R6004", ServoTeaching.Proc2StartPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6404", ServoTeaching.Proc2StartPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6804", ServoTeaching.Proc2StartPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6060", ServoTeaching.Proc2StartPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6260", ServoTeaching.Proc2StartPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6260", ServoTeaching.Proc2StartPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6006", ServoTeaching.Proc2StartPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6406", ServoTeaching.Proc2StartPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc2StartPos.SpeedT);
                    break;
                case TeachPos.Proc2End:

                    //Proc2 End Pos
                    Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc2EndPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6484", ServoTeaching.Proc2EndPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6848", ServoTeaching.Proc2EndPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6062", ServoTeaching.Proc2EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6262", ServoTeaching.Proc2EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6262", ServoTeaching.Proc2EndPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc2EndPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6486", ServoTeaching.Proc2EndPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc2EndPos.SpeedT);
                    break;
                case TeachPos.Proc3Start:
                    //Proc3 Start Pos
                    Mitsubishi.Instance().WriteDint("R6008", ServoTeaching.Proc3StartPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6408", ServoTeaching.Proc3StartPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6808", ServoTeaching.Proc3StartPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6064", ServoTeaching.Proc3StartPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6264", ServoTeaching.Proc3StartPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6264", ServoTeaching.Proc3StartPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6010", ServoTeaching.Proc3StartPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6410", ServoTeaching.Proc3StartPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc3StartPos.SpeedT);
                    break;
                case TeachPos.Proc3End:
                    //Proc3 End Pos
                    Mitsubishi.Instance().WriteDint("R6088", ServoTeaching.Proc3EndPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6488", ServoTeaching.Proc3EndPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6850", ServoTeaching.Proc3EndPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6066", ServoTeaching.Proc3EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6266", ServoTeaching.Proc3EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6266", ServoTeaching.Proc3EndPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6090", ServoTeaching.Proc3EndPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6490", ServoTeaching.Proc3EndPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc3EndPos.SpeedT);
                    break;
                case TeachPos.Proc4Start:
                    //Proc4 Start Pos
                    Mitsubishi.Instance().WriteDint("R6012", ServoTeaching.Proc4StartPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6412", ServoTeaching.Proc4StartPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6812", ServoTeaching.Proc4StartPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6068", ServoTeaching.Proc4StartPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6268", ServoTeaching.Proc4StartPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6268", ServoTeaching.Proc4StartPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6014", ServoTeaching.Proc4StartPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6414", ServoTeaching.Proc4StartPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc4StartPos.SpeedT);
                    break;
                case TeachPos.Proc4End:
                    //Proc4 End Pos
                    Mitsubishi.Instance().WriteDint("R6092", ServoTeaching.Proc4EndPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6492", ServoTeaching.Proc4EndPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6852", ServoTeaching.Proc4EndPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6070", ServoTeaching.Proc4EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6270", ServoTeaching.Proc4EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6270", ServoTeaching.Proc4EndPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6094", ServoTeaching.Proc4EndPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6494", ServoTeaching.Proc4EndPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc4EndPos.SpeedT);
                    break;
                case TeachPos.Proc5Start:
                    //Proc5 Start Pos
                    Mitsubishi.Instance().WriteDint("R6016", ServoTeaching.Proc5StartPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6416", ServoTeaching.Proc5StartPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6816", ServoTeaching.Proc5StartPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6072", ServoTeaching.Proc5StartPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6272", ServoTeaching.Proc5StartPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6272", ServoTeaching.Proc5StartPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6018", ServoTeaching.Proc5StartPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6418", ServoTeaching.Proc5StartPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc5StartPos.SpeedT);
                    break;
                case TeachPos.Proc5End:
                    //Proc5 End Pos
                    Mitsubishi.Instance().WriteDint("R6096", ServoTeaching.Proc5EndPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6496", ServoTeaching.Proc5EndPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6854", ServoTeaching.Proc5EndPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6074", ServoTeaching.Proc5EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6274", ServoTeaching.Proc5EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6274", ServoTeaching.Proc5EndPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6098", ServoTeaching.Proc5EndPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6498", ServoTeaching.Proc5EndPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc5EndPos.SpeedT);
                    break;
                case TeachPos.Proc6Start:
                    //Proc6 Start Pos
                    Mitsubishi.Instance().WriteDint("R6020", ServoTeaching.Proc6StartPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6420", ServoTeaching.Proc6StartPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6818", ServoTeaching.Proc6StartPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6076", ServoTeaching.Proc6StartPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6276", ServoTeaching.Proc6StartPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6276", ServoTeaching.Proc6StartPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6022", ServoTeaching.Proc6StartPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6422", ServoTeaching.Proc6StartPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc6StartPos.SpeedT);
                    break;
                case TeachPos.Proc6End:
                    //Proc6 End Pos
                    Mitsubishi.Instance().WriteDint("R6100", ServoTeaching.Proc6EndPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6500", ServoTeaching.Proc6EndPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6856", ServoTeaching.Proc6EndPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6078", ServoTeaching.Proc6EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6278", ServoTeaching.Proc6EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6278", ServoTeaching.Proc6EndPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6102", ServoTeaching.Proc6EndPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6502", ServoTeaching.Proc6EndPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc6EndPos.SpeedT);
                    break;
                case TeachPos.Proc7Start:
                    //Proc7 Start Pos
                    Mitsubishi.Instance().WriteDint("R6024", ServoTeaching.Proc7StartPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6424", ServoTeaching.Proc7StartPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6820", ServoTeaching.Proc7StartPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6080", ServoTeaching.Proc7StartPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6280", ServoTeaching.Proc7StartPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6280", ServoTeaching.Proc7StartPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6026", ServoTeaching.Proc7StartPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6426", ServoTeaching.Proc7StartPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc7StartPos.SpeedT);
                    break;
                case TeachPos.Proc7End:
                    //Proc7 End Pos
                    Mitsubishi.Instance().WriteDint("R6104", ServoTeaching.Proc7EndPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6504", ServoTeaching.Proc7EndPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6858", ServoTeaching.Proc7EndPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6082", ServoTeaching.Proc7EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6282", ServoTeaching.Proc7EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6282", ServoTeaching.Proc7EndPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6106", ServoTeaching.Proc7EndPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6506", ServoTeaching.Proc7EndPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc7EndPos.SpeedT);
                    break;
                case TeachPos.Proc8Start:
                    //Proc8 Start Pos
                    Mitsubishi.Instance().WriteDint("R6028", ServoTeaching.Proc8StartPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6428", ServoTeaching.Proc8StartPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6822", ServoTeaching.Proc8StartPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc8StartPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc8StartPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc8StartPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6030", ServoTeaching.Proc8StartPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6430", ServoTeaching.Proc8StartPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc8StartPos.SpeedT);
                    break;
                case TeachPos.Proc8End:
                    //Proc8 End Pos
                    Mitsubishi.Instance().WriteDint("R6108", ServoTeaching.Proc8EndPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6508", ServoTeaching.Proc8EndPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6860", ServoTeaching.Proc8EndPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc8EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc8EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc8EndPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6110", ServoTeaching.Proc8EndPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6510", ServoTeaching.Proc8EndPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc8EndPos.SpeedT);
                    break;
                case TeachPos.Proc9Start:
                    //Proc9 Start Pos
                    Mitsubishi.Instance().WriteDint("R6032", ServoTeaching.Proc9StartPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6432", ServoTeaching.Proc9StartPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6823", ServoTeaching.Proc9StartPos.FixT);

                    //Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc9StartPos.OffsetX);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc9StartPos.OffsetY);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc9StartPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6034", ServoTeaching.Proc9StartPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6434", ServoTeaching.Proc9StartPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc9StartPos.SpeedT);
                    break;
                case TeachPos.Proc9End:
                    //Proc9 End Pos                                            
                    Mitsubishi.Instance().WriteDint("R6112", ServoTeaching.Proc9EndPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6512", ServoTeaching.Proc9EndPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6862", ServoTeaching.Proc9EndPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc9EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc9EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc9EndPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6114", ServoTeaching.Proc9EndPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6514", ServoTeaching.Proc9EndPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc9EndPos.SpeedT);
                    break;
                case TeachPos.Proc10Start:
                    //Proc10 Start Pos
                    Mitsubishi.Instance().WriteDint("R6036", ServoTeaching.Proc10StartPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6436", ServoTeaching.Proc10StartPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6824", ServoTeaching.Proc10StartPos.FixT);

                    //Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc10StartPos.OffsetX);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc10StartPos.OffsetY);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc10StartPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6038", ServoTeaching.Proc10StartPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6438", ServoTeaching.Proc10StartPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc10StartPos.SpeedT);
                    break;
                case TeachPos.Proc10End:
                    //Proc10 End Pos                                            
                    Mitsubishi.Instance().WriteDint("R6116", ServoTeaching.Proc10EndPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6516", ServoTeaching.Proc10EndPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6864", ServoTeaching.Proc10EndPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc10EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc10EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc10EndPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6118", ServoTeaching.Proc10EndPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6518", ServoTeaching.Proc10EndPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc10EndPos.SpeedT);
                    break;
                case TeachPos.Proc11Start:
                    //Proc11 Start Pos
                    Mitsubishi.Instance().WriteDint("R6040", ServoTeaching.Proc11StartPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6440", ServoTeaching.Proc11StartPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6826", ServoTeaching.Proc11StartPos.FixT);

                    //Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc11StartPos.OffsetX);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc11StartPos.OffsetY);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc11StartPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6042", ServoTeaching.Proc11StartPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6442", ServoTeaching.Proc11StartPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc11StartPos.SpeedT);
                    break;
                case TeachPos.Proc11End:
                    //Proc11 End Pos                                            
                    Mitsubishi.Instance().WriteDint("R6120", ServoTeaching.Proc11EndPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6520", ServoTeaching.Proc11EndPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6866", ServoTeaching.Proc11EndPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc11EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc11EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc11EndPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6122", ServoTeaching.Proc11EndPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6522", ServoTeaching.Proc11EndPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc11EndPos.SpeedT);
                    break;
                case TeachPos.Proc12Start:
                    //Proc12 Start Pos
                    Mitsubishi.Instance().WriteDint("R6044", ServoTeaching.Proc12StartPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6444", ServoTeaching.Proc12StartPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6828", ServoTeaching.Proc12StartPos.FixT);

                    //Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc12StartPos.OffsetX);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc12StartPos.OffsetY);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc12StartPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6046", ServoTeaching.Proc12StartPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6446", ServoTeaching.Proc12StartPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc12StartPos.SpeedT);
                    break;
                case TeachPos.Proc12End:
                    //Proc12 End Pos                                            
                    Mitsubishi.Instance().WriteDint("R6124", ServoTeaching.Proc12EndPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6524", ServoTeaching.Proc12EndPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6868", ServoTeaching.Proc12EndPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc12EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc12EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc12EndPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6126", ServoTeaching.Proc12EndPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6526", ServoTeaching.Proc12EndPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc12EndPos.SpeedT);
                    break;
                case TeachPos.Proc13Start:
                    //Proc13 Start Pos
                    Mitsubishi.Instance().WriteDint("R6048", ServoTeaching.Proc13StartPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6448", ServoTeaching.Proc13StartPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6830", ServoTeaching.Proc13StartPos.FixT);

                    //Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc13StartPos.OffsetX);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc13StartPos.OffsetY);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc13StartPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6050", ServoTeaching.Proc13StartPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6450", ServoTeaching.Proc13StartPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc13StartPos.SpeedT);
                    break;
                case TeachPos.Proc13End:
                    //Proc13 End Pos                                            
                    Mitsubishi.Instance().WriteDint("R6128", ServoTeaching.Proc13EndPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6528", ServoTeaching.Proc13EndPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6870", ServoTeaching.Proc13EndPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc13EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc13EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc13EndPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6130", ServoTeaching.Proc13EndPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6530", ServoTeaching.Proc13EndPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc13EndPos.SpeedT);
                    break;
                case TeachPos.Proc14Start:
                    //Proc14 Start Pos
                    Mitsubishi.Instance().WriteDint("R6052", ServoTeaching.Proc14StartPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6452", ServoTeaching.Proc14StartPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6832", ServoTeaching.Proc14StartPos.FixT);

                    //Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc14StartPos.OffsetX);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc14StartPos.OffsetY);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc14StartPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6054", ServoTeaching.Proc14StartPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6454", ServoTeaching.Proc14StartPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc14StartPos.SpeedT);
                    break;
                case TeachPos.Proc14End:
                    //Proc14 End Pos                                            
                    Mitsubishi.Instance().WriteDint("R6132", ServoTeaching.Proc14EndPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6532", ServoTeaching.Proc14EndPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6872", ServoTeaching.Proc14EndPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc14EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc14EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc14EndPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6134", ServoTeaching.Proc14EndPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6534", ServoTeaching.Proc14EndPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc14EndPos.SpeedT);
                    break;
                case TeachPos.Proc15Start:
                    //Proc15 Start Pos
                    Mitsubishi.Instance().WriteDint("R6056", ServoTeaching.Proc15StartPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6456", ServoTeaching.Proc15StartPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6834", ServoTeaching.Proc15StartPos.FixT);

                    //Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc15StartPos.OffsetX);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc15StartPos.OffsetY);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc15StartPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6058", ServoTeaching.Proc15StartPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6458", ServoTeaching.Proc15StartPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc15StartPos.SpeedT);
                    break;
                case TeachPos.Proc15End:
                    //Proc15 End Pos                                            
                    Mitsubishi.Instance().WriteDint("R6136", ServoTeaching.Proc15EndPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6536", ServoTeaching.Proc15EndPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6874", ServoTeaching.Proc15EndPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc15EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc15EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc15EndPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6138", ServoTeaching.Proc15EndPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6538", ServoTeaching.Proc15EndPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc15EndPos.SpeedT);
                    break;
                case TeachPos.Proc16Start:
                    //Proc16 Start Pos
                    Mitsubishi.Instance().WriteDint("R6060", ServoTeaching.Proc16StartPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6460", ServoTeaching.Proc16StartPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6836", ServoTeaching.Proc16StartPos.FixT);

                    //Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc16StartPos.OffsetX);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc16StartPos.OffsetY);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc16StartPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6062", ServoTeaching.Proc16StartPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6462", ServoTeaching.Proc16StartPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc16StartPos.SpeedT);
                    break;
                case TeachPos.Proc16End:
                    //Proc16 End Pos                                            
                    Mitsubishi.Instance().WriteDint("R6140", ServoTeaching.Proc16EndPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6540", ServoTeaching.Proc16EndPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6876", ServoTeaching.Proc16EndPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc16EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc16EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc16EndPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6142", ServoTeaching.Proc16EndPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6542", ServoTeaching.Proc16EndPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc16EndPos.SpeedT);
                    break;
                case TeachPos.Proc17Start:
                    //Proc17 Start Pos
                    Mitsubishi.Instance().WriteDint("R6064", ServoTeaching.Proc17StartPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6464", ServoTeaching.Proc17StartPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6838", ServoTeaching.Proc17StartPos.FixT);

                    //Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc17StartPos.OffsetX);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc17StartPos.OffsetY);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc17StartPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6066", ServoTeaching.Proc17StartPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6466", ServoTeaching.Proc17StartPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc17StartPos.SpeedT);
                    break;
                case TeachPos.Proc17End:
                    //Proc17 End Pos                                            
                    Mitsubishi.Instance().WriteDint("R6144", ServoTeaching.Proc17EndPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6544", ServoTeaching.Proc17EndPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6878", ServoTeaching.Proc17EndPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc17EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc17EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc17EndPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6146", ServoTeaching.Proc17EndPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6546", ServoTeaching.Proc17EndPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc17EndPos.SpeedT);
                    break;
                case TeachPos.Proc18Start:
                    //Proc18 Start Pos
                    Mitsubishi.Instance().WriteDint("R6068", ServoTeaching.Proc18StartPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6468", ServoTeaching.Proc18StartPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6840", ServoTeaching.Proc18StartPos.FixT);

                    //Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc18StartPos.OffsetX);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc18StartPos.OffsetY);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc18StartPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6070", ServoTeaching.Proc18StartPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6470", ServoTeaching.Proc18StartPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc18StartPos.SpeedT);
                    break;
                case TeachPos.Proc18End:
                    //Proc18 End Pos                                            
                    Mitsubishi.Instance().WriteDint("R6148", ServoTeaching.Proc18EndPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6548", ServoTeaching.Proc18EndPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6880", ServoTeaching.Proc18EndPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc18EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc18EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc18EndPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6150", ServoTeaching.Proc18EndPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6550", ServoTeaching.Proc18EndPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc18EndPos.SpeedT);
                    break;
                case TeachPos.Proc19Start:
                    //Proc19 Start Pos
                    Mitsubishi.Instance().WriteDint("R6072", ServoTeaching.Proc19StartPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6472", ServoTeaching.Proc19StartPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6842", ServoTeaching.Proc19StartPos.FixT);

                    //Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc19StartPos.OffsetX);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc19StartPos.OffsetY);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc19StartPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6074", ServoTeaching.Proc19StartPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6474", ServoTeaching.Proc19StartPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc19StartPos.SpeedT);
                    break;
                case TeachPos.Proc19End:
                    //Proc19 End Pos                                            
                    Mitsubishi.Instance().WriteDint("R6152", ServoTeaching.Proc19EndPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6552", ServoTeaching.Proc19EndPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6882", ServoTeaching.Proc19EndPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc19EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc19EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc19EndPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6154", ServoTeaching.Proc19EndPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6554", ServoTeaching.Proc19EndPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc19EndPos.SpeedT);
                    break;
                case TeachPos.Proc20Start:
                    //Proc20 Start Pos
                    Mitsubishi.Instance().WriteDint("R6076", ServoTeaching.Proc20StartPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6476", ServoTeaching.Proc20StartPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6844", ServoTeaching.Proc20StartPos.FixT);

                    //Mitsubishi.Instance().WriteDint("R6084", ServoTeaching.Proc20StartPos.OffsetX);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc20StartPos.OffsetY);
                    //Mitsubishi.Instance().WriteDint("R6284", ServoTeaching.Proc20StartPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6078", ServoTeaching.Proc20StartPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6478", ServoTeaching.Proc20StartPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc20StartPos.SpeedT);
                    break;
                case TeachPos.Proc20End:
                    //Proc20 End Pos                                            
                    Mitsubishi.Instance().WriteDint("R6156", ServoTeaching.Proc20EndPos.FixX);
                    Mitsubishi.Instance().WriteDint("R6556", ServoTeaching.Proc20EndPos.FixY);
                    Mitsubishi.Instance().WriteDint("R6884", ServoTeaching.Proc20EndPos.FixT);

                    ////Mitsubishi.Instance().WriteDint("R6086", ServoTeaching.Proc20EndPos.OffsetX);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc20EndPos.OffsetY);
                    ////Mitsubishi.Instance().WriteDint("R6286", ServoTeaching.Proc20EndPos.OffsetT);

                    Mitsubishi.Instance().WriteDint("R6158", ServoTeaching.Proc20EndPos.SpeedX);
                    Mitsubishi.Instance().WriteDint("R6558", ServoTeaching.Proc20EndPos.SpeedY);
                    Mitsubishi.Instance().WriteDint("R6802", ServoTeaching.Proc20EndPos.SpeedT);
                    break;


            }
        }
        #region Teach
        private void btnServoOn_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1173");
        }

        private void btnServoOn_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1173");
        }

        private void btnSaveTeach_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M7");
        }

        private void btnSaveTeach_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M7");
        }

        private void btnProcess1_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1500");
        }

        private void btnProcess1_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1500");
        }

        private void btnProcess2_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1501");

        }

        private void btnProcess2_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1501");
        }

        private void btnProcess3_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1502");
        }

        private void btnProcess3_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1502");
        }

        private void btnProcess4_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1503");
        }

        private void btnProcess4_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1503");
        }

        private void btnProcess5_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1504");
        }

        private void btnProcess5_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1504");

        }

        private void btnProcess6_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1505");
        }

        private void btnProcess6_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1505");
        }

        private void btnProcess7_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1506");
        }

        private void btnProcess7_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1506");
        }

        private void btnProcess8_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1507");
        }

        private void btnProcess8_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1507");
        }

        private void btnProcess9_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1508");
        }

        private void btnProcess9_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1509");
        }

        private void btnProcess10_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1509");
        }

        private void btnProcess10_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1509");
        }

        private void btnProcess11_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1510");
        }

        private void btnProcess11_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1510");
        }

        private void btnProcess12_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1511");
        }

        private void btnProcess12_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1511");
        }

        private void btnProcess13_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1512");
        }

        private void btnProcess13_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1512");
        }

        private void btnProcess14_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1513");
        }

        private void btnProcess14_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1513");
        }

        private void btnProcess15_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1514");
        }

        private void btnProcess15_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1514");
        }

        private void btnProcess16_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1515");
        }

        private void btnProcess16_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1516");
        }

        private void btnProcess17_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1516");
        }

        private void btnProcess17_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1516");
        }

        private void btnProcess18_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1517");
        }

        private void btnProcess18_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1518");
        }

        private void btnProcess19_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1518");
        }

        private void btnProcess19_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1519");
        }

        private void btnProcess20_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1519");
        }

        private void btnProcess20_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1519");
        }
        #endregion

        private void btnJogSlow_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1350");
            btnJogSlow.BackColor = Color.Cyan;
        }

        private void btnJogSlow_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1350");
            btnJogSlow.BackColor = Color.WhiteSmoke;
        }

        private void btnJogMid_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1351");
            btnJogMid.BackColor = Color.Cyan;
        }

        private void btnJogMid_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1351");
            btnJogMid.BackColor = Color.WhiteSmoke;
        }

        private void btnJOGCAM_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1352");
        }

        private void btnJOGCAM_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1352");
        }

        #region UPDATE
        private void btnProcess1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" UPDATE VER1.1 !!!");
        }

        private void btnProcess2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" UPDATE VER1.1 !!!");
        }

        private void btnProcess3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" UPDATE VER1.1 !!!");
        }

        private void btnProcess4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" UPDATE VER1.1 !!!");
        }

        private void btnProcess5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" UPDATE VER1.1 !!!");
        }

        private void btnProcess6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" UPDATE VER1.1 !!!");
        }

        private void btnProcess7_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" UPDATE VER1.1 !!!");
        }

        private void btnProcess8_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" UPDATE VER1.1 !!!");
        }

        private void btnProcess9_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" UPDATE VER1.1 !!!");
        }

        private void btnProcess10_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" UPDATE VER1.1 !!!");
        }

        private void btnProcess11_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" UPDATE VER1.1 !!!");
        }

        private void btnProcess12_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" UPDATE VER1.1 !!!");
        }

        private void btnProcess13_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" UPDATE VER1.1 !!!");
        }

        private void btnProcess14_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" UPDATE VER1.1 !!!");
        }

        private void btnProcess15_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" UPDATE VER1.1 !!!");
        }

        private void btnProcess16_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" UPDATE VER1.1 !!!");
        }

        private void btnProcess17_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" UPDATE VER1.1 !!!");
        }

        private void btnProcess18_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" UPDATE VER1.1 !!!");
        }

        private void btnProcess19_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" UPDATE VER1.1 !!!");
        }

        private void btnProcess20_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" UPDATE VER1.1 !!!");
        }
    }
    #endregion CHECk


    public class ServoTeaching
    {
        public static PosInfo LoadPos = new PosInfo();
        public static PosInfo UnLoadOKPos = new PosInfo();
        public static PosInfo UnLoadNGPos = new PosInfo();
        public static PosInfo Proc1StartPos = new PosInfo();
        public static PosInfo Proc1EndPos = new PosInfo();
        public static PosInfo Proc2StartPos = new PosInfo();
        public static PosInfo Proc2EndPos = new PosInfo();
        public static PosInfo Proc3StartPos = new PosInfo();
        public static PosInfo Proc3EndPos = new PosInfo();
        public static PosInfo Proc4StartPos = new PosInfo();
        public static PosInfo Proc4EndPos = new PosInfo();
        public static PosInfo Proc5StartPos = new PosInfo();
        public static PosInfo Proc5EndPos = new PosInfo();
        public static PosInfo Proc6StartPos = new PosInfo();
        public static PosInfo Proc6EndPos = new PosInfo();
        public static PosInfo Proc7StartPos = new PosInfo();
        public static PosInfo Proc7EndPos = new PosInfo();
        public static PosInfo Proc8StartPos = new PosInfo();
        public static PosInfo Proc8EndPos = new PosInfo();
        public static PosInfo Proc9StartPos = new PosInfo();
        public static PosInfo Proc9EndPos = new PosInfo();
        public static PosInfo Proc10StartPos = new PosInfo();
        public static PosInfo Proc10EndPos = new PosInfo();
        public static PosInfo Proc11StartPos = new PosInfo();
        public static PosInfo Proc11EndPos = new PosInfo();
        public static PosInfo Proc12StartPos = new PosInfo();
        public static PosInfo Proc12EndPos = new PosInfo();
        public static PosInfo Proc13StartPos = new PosInfo();
        public static PosInfo Proc13EndPos = new PosInfo();
        public static PosInfo Proc14StartPos = new PosInfo();
        public static PosInfo Proc14EndPos = new PosInfo();
        public static PosInfo Proc15StartPos = new PosInfo();
        public static PosInfo Proc15EndPos = new PosInfo();
        public static PosInfo Proc16StartPos = new PosInfo();
        public static PosInfo Proc16EndPos = new PosInfo();
        public static PosInfo Proc17StartPos = new PosInfo();
        public static PosInfo Proc17EndPos = new PosInfo();
        public static PosInfo Proc18StartPos = new PosInfo();
        public static PosInfo Proc18EndPos = new PosInfo();
        public static PosInfo Proc19StartPos = new PosInfo();
        public static PosInfo Proc19EndPos = new PosInfo();
        public static PosInfo Proc20StartPos = new PosInfo();
        public static PosInfo Proc20EndPos = new PosInfo();
        public static Int32 CurrentPosX = 0;
        public static Int32 CurrentPosY = 0;
        public static Int32 CurrentPosT = 0;
        public static ServoSensor senAxisX = new ServoSensor();
        public static ServoSensor senAxisY = new ServoSensor();
        public static ServoSensor senAxisT = new ServoSensor();
        public static bool ServoOnStatus = false;
    }
    public class PosInfo
    {
        public Int32 TargetX = 0;
        public Int32 TargetY = 0;
        public Int32 TargetT = 0;
        public Int32 FixX = 0;
        public Int32 FixY = 0;
        public Int32 FixT = 0;
        public Int32 OffsetX = 0;
        public Int32 OffsetY = 0;
        public Int32 OffsetT = 0;
        public Int32 SpeedX = 0;
        public Int32 SpeedY = 0;
        public Int32 SpeedT = 0;
    }
    public class ServoSensor
    {
        public bool LimitUp;
        public bool LimitDn;
        public bool DOG;
    }
    public enum JogSpeed
    {
        Slow = 0,
        Mid,
        Hight,
    }
    public enum ServoSelect
    {
        None = 0,
        X,
        Y,
        T,
    }
    public enum TeachPos
    {
        Load,
        UnloadOK,
        UnloadNG,
        Proc1Start,
        Proc1End,
        Proc2Start,
        Proc2End,
        Proc3Start,
        Proc3End,
        Proc4Start,
        Proc4End,
        Proc5Start,
        Proc5End,
        Proc6Start,
        Proc6End,
        Proc7Start,
        Proc7End,
        Proc8Start,
        Proc8End,
        Proc9Start,
        Proc9End,
        Proc10Start,
        Proc10End,
        Proc11Start,
        Proc11End,
        Proc12Start,
        Proc12End,
        Proc13Start,
        Proc13End,
        Proc14Start,
        Proc14End,
        Proc15Start,
        Proc15End,
        Proc16Start,
        Proc16End,
        Proc17Start,
        Proc17End,
        Proc18Start,
        Proc18End,
        Proc19Start,
        Proc19End,
        Proc20Start,
        Proc20End,
    }
}
