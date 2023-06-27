using ActUtlTypeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SymbolFactoryDotNet;



namespace HSV
{
    public class Mitsubishi
    {
        ActUtlType plc = new ActUtlType();       
        public bool PLC_Connect = false;
        protected Mitsubishi()
        {


        }

        private static Mitsubishi _instance;

        public static Mitsubishi Instance()
        {
            if (_instance == null)
            {
                _instance = new Mitsubishi();



            }
            return _instance;
        }

        public bool Open()
        {
            
            plc.ActLogicalStationNumber = 1;
            if (plc.ActLogicalStationNumber == 1 )
            {
                plc.Open();
                PLC_Connect = true;
                return true;
            }
            else
            {
                PLC_Connect = false;
                return false;
            }


        }
        public void Close()
        {
            PLC_Connect = false;
            plc.Close();
        }
        public void SetBit(string Addr)
        {
            if (plc.ActLogicalStationNumber == 1)
            {
                plc.SetDevice(Addr, 1);

            }
        }

        // Write
        public void ResetBit(string Addr)
        {
            if (plc.ActLogicalStationNumber == 1)
            {
                plc.SetDevice(Addr, 0);
            }
        }
        public void WriteReal(string Addr, float Value)
        {
            if (plc.ActLogicalStationNumber == 1)
            {

                byte[] byteOut;
                int[] intOut = new int[2];
                byteOut = BitConverter.GetBytes(Value);
                intOut[0] = BitConverter.ToInt16(byteOut, 0);
                intOut[1] = BitConverter.ToInt16(byteOut, 2);
                plc.WriteDeviceBlock(Addr, 2, ref intOut[0]);

                //WriteReal("D200", Covert.ToSingle(txt.text);
            }
        }
        public void WriteDint(string Addr, string Value)
        {
            if (plc.ActLogicalStationNumber == 1)
            {
                Int32 ByteOut;
                Int32.TryParse(Value, out ByteOut);

                Int32[] Byte_Out = new Int32[2];
                Byte_Out[0] = ByteOut & 0xffff;
                Byte_Out[1] = (ByteOut >> 16) & 0xffff;
                plc.WriteDeviceBlock(Addr, 2, ref Byte_Out[0]);
            }
            // Write32bit("D200", txt.text);
        }

        public void WriteDint(string Addr, Int32 Value)
        {
            if (plc.ActLogicalStationNumber == 1)
            {
                Int32[] Byte_Out = new Int32[2];
                Byte_Out[0] = Value & 0xffff;
                Byte_Out[1] = (Value >> 16) & 0xffff;
                plc.WriteDeviceBlock(Addr, 2, ref Byte_Out[0]);
            }
        }
        public void Writeint(string Addr, string Value)
        {
            if (plc.ActLogicalStationNumber == 1)
            {
                plc.SetDevice(Addr, Convert.ToInt16(Value));
                //Writw16bit("D300", txt.text);
            }
        }
        public void WriteTime(string Addr, string Value)
        {
            if (plc.ActLogicalStationNumber == 1)
            {
                plc.SetDevice(Addr, Convert.ToInt16(Value));
                //WriteTime("D200",txt.text);

            }
        }
        // Read
        public bool ReadAxisCurrValue(string Add, ref Int32 CurX, ref Int32 CurY, ref Int32 CurT)
        {
            if (plc.ActLogicalStationNumber == 1)
            {
                int[] DataRespond = new int[6];
                if (plc.ReadDeviceBlock(Add, 6, out DataRespond[0]) == 0)
                {
                    CurX = ((DataRespond[1] << 16) | DataRespond[0]);
                    CurY = ((DataRespond[3] << 16) | DataRespond[2]);
                    CurT = ((DataRespond[5] << 16) | DataRespond[4]);
                    return true;
                }
            }
            return false;
        }

        public bool ReadServoSensorStatus( string Add, ref System.Collections.BitArray SensorArr)
        {
            if (plc.ActLogicalStationNumber == 1)
            {
                int[] DataRespond = new int[1];
                if (plc.ReadDeviceBlock(Add, 1, out DataRespond[0]) == 0)
                {
                    SensorArr = new System.Collections.BitArray(new int[] { DataRespond[0] });
                    return true;
                }
            }
            return false;
        }

        public bool ReadAlarmStatus(string Add, ref bool[] AlarmBitArr)
        {
            int icnt = 4;
            short[] iTemp_Bit = new short[100];
            int iRet = plc.ReadDeviceBlock2(Add, icnt, out iTemp_Bit[0]);
            int iTemp_Value = 0;
            if (iRet == 0)
            {
                for (int i = 0; i < icnt; i++)
                {
                    for (int k = 0; k < 16; k++)
                    {
                        iTemp_Value = (short)((iTemp_Bit[i] >> (((i * 16) + k) % 16)) & 0x0001);

                        if (iTemp_Value == 0)
                            AlarmBitArr[(i * 16) + k] = false;

                        else
                            AlarmBitArr[(i * 16) + k] = true;
                    }
                }
                return true;
            }
            else 
                return false;

        }

        public bool ReadDint(string Add1, ref Int32 Value)
        {
            if (plc.ActLogicalStationNumber == 1)
            {
                int[] DataRespond = new int[2];
                if (plc.ReadDeviceBlock(Add1, 2, out DataRespond[0]) == 0)
                {
                    Value = ((DataRespond[1] << 16) | DataRespond[0]);
                    return true;
                }
            }
            return false;
        }
        public void ReadDint1(string Add1, Label lb)
        {
            if (plc.ActLogicalStationNumber == 1)
            {
                int[] DataRespond = new int[2];
                plc.ReadDeviceBlock(Add1, 2, out DataRespond[0]);
                Int32 Data = ((DataRespond[1] << 16) | DataRespond[0]);
                lb.Text = Data.ToString();
            }
        }

        public void ReadInt(string Addr, Label lb)
        {
            if (plc.ActLogicalStationNumber == 1)
            {
                short Val;
                plc.GetDevice2(Addr, out Val);
                lb.Text = Convert.ToString(Val);
                //ReaData("D10",label,0);

            }
        }
        public void ReadBit(string Addr, Label lb)
        {
            if (plc.ActLogicalStationNumber == 1)
            {
                int Value;
                plc.GetDevice(Addr, out Value);
                lb.Text = Convert.ToString(Value);
                //txt.Text = Value.ToString();

            }
        } 
            public void ReadReal(string Addr1, string Addr2, Label lb)
        {
            if (plc.ActLogicalStationNumber == 1)
            {
                short Val1;
                plc.GetDevice2(Addr1, out Val1);
                short Val2;
                plc.GetDevice2(Addr2, out Val2);
                lb.Text = fReadReal(Val1, Val2).ToString("0.00");

            }
        }
        public void GetHOME(string Addr, Button sd)
        {
            if (plc.ActLogicalStationNumber == 1)
            {
                int Val;
                plc.GetDevice(Addr, out Val);
                Addr = Val.ToString();
                if (Addr == "0")
                {
                    sd.BackColor = Color.Gray;
                    sd.Enabled = false;
                }
                else
                {
                    sd.BackColor = Color.Green;
                    sd.Enabled = true;
                }
            }

        }
        public void GetHOME1(string Addr, Button sd)
        {
            if (plc.ActLogicalStationNumber == 1)
            {
                int Val;
                plc.GetDevice(Addr, out Val);
                Addr = Val.ToString();
                if (Addr == "0")
                {
                    sd.Enabled = false;
                }
                else
                {
                    sd.Enabled = true;
                }
            }

        }
        public void GetBitButton(string Addr, Button sd)
        {
            if (plc.ActLogicalStationNumber == 1)
            {
                int Val;
                plc.GetDevice(Addr, out Val);
                Addr = Val.ToString();
                if (Addr == "0")
                {
                    sd.BackColor = Color.Gray;
                }
                else if (Addr == "1")
                {
                    sd.BackColor = Color.Green;
                }

            }
        }
        private float fReadReal(Int16 Val1, Int16 Val2)
        {
            var ByteVal1 = BitConverter.GetBytes(Val1);
            var ByteVal2 = BitConverter.GetBytes(Val2);
            byte[] temp2 = new byte[4];
            temp2[0] = ByteVal1[0];
            temp2[1] = ByteVal1[1];
            temp2[2] = ByteVal2[0];
            temp2[3] = ByteVal2[1];
            return System.BitConverter.ToSingle(temp2, 0);

        }

        public void GetBit(string Addr, StandardControl sd)
        {
            if (plc.ActLogicalStationNumber == 1)
            {
                int Val;
                plc.GetDevice(Addr, out Val);
                Addr = Val.ToString();
                if (Addr == "0")
                {
                    ON_OFF_ARLAM(sd, 0);
                }
                else if (Addr == "1")
                {
                    ON_OFF_ARLAM(sd, 1);
                }
                else
                {
                    ON_OFF_ARLAM(sd, 2);
                }
            }
        
        }

        private void ON_OFF_ARLAM(StandardControl sd, byte Value)
        {
            if (Value == 0) // Do
            {
                sd.DiscreteValue1 = true;
                sd.DiscreteValue2 = false;
                sd.DiscreteValue3 = false;
            }
            else if (Value == 1) // Xanh
            {
                sd.DiscreteValue1 = false;
                sd.DiscreteValue2 = true;
                sd.DiscreteValue3 = false;

            }
            else //Vang, nhap nhay
            {
                sd.DiscreteValue1 = false;
                sd.DiscreteValue2 = false;
                sd.DiscreteValue3 = true;
            }
        }
    }
}
