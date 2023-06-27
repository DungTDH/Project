using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ActUtlTypeLib;
using SymbolFactoryDotNet;


namespace HSV.Forms
{
    public partial class FormManual : Form
    {
        public FormManual()
        {
            InitializeComponent();

        }
        private void rjtFixX__TextChanged(object sender, EventArgs e)
        {

        }
        private void FormManual_Load(object sender, EventArgs e)
        {
            tmnMANUAL.Interval = 100;
            tmnMANUAL.Enabled = true;
        }
        private void btnPosSet_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M51");
        }

        private void btnPosSet_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M51");
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M50");
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M50");
        }

        private void btnCAMPUP_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M52");
        }

        private void btnCAMPUP_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M52");
        }

        private void btnCAMPDOWN_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M53");
        }

        private void btnCAMPDOWN_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M53");
        }

        private void btnLOCKSAFETY_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M54");
        }

        private void btnLOCKSAFETY_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M54");
        }

        private void btnCONVEYOROK_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M55");
        }

        private void btnCONVEYOROK_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M55");

        }

        private void btnCONVEYORNG_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M56");
        }

        private void btnCONVEYORNG_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M56");
        }

        private void btnCONVEYOR_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M57");
        }

        private void btnCONVEYOR_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M57");
        }

        private void btnSERVOON_Click(object sender, EventArgs e)
        {
               
            Mitsubishi.Instance().SetBit("M80");
            

            //plc.Open();
            //plc.ActLogicalStationNumber = 1;
        }

        private void btnSERVOOFF_Click(object sender, EventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M80");
            
        }
        private void btnAxisXUP_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M58");
        }

        private void btnAxisXUP_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M58");
        }

        private void btnAxisXDOWN_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M59");
        }

        private void btnAxisXDOWN_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M59");
        }

        private void btnAxisYUP_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M60");
        }

        private void btnAxisYUP_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M60");
        }

        private void btnAxisYDOWN_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M61");
        }

        private void btnAxisYDOWN_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M61");
        }

        private void btnAxisCamUP_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M62");
        }

        private void btnAxisCamUP_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M62");
        }

        private void btnAxisCamDown_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M63");
        }

        private void btnAxisCamDown_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M63");
        }

        private void btnHomeX_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M10");
        }

        private void btnHomeX_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M10");
        }

        private void btnHomeY_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M11");
        }

        private void btnHomeY_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M11");
        }

        private void btnHomeCam_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M12");
        }

        private void btnHomeCam_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M12");
        }
        private void btnRESETX_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M81");
        }

        private void btnRESETX_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M81");
        }
        private void btnRESETY_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M82");
        }
        private void btnRESETY_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M82");
        }

        private void btnRESETCam_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M83");
        }

        private void btnRESETCam_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M83");
        }

        private void tmnMANUAL_Tick(object sender, EventArgs e)
        {
            Mitsubishi.Instance().ReadInt("D30", lblAxisX);
            Mitsubishi.Instance().ReadInt("D18", lblAxisY);
            Mitsubishi.Instance().ReadInt("D32", lblAxisT);
            //Lock button
            Mitsubishi.Instance().GetHOME("D10", btnHomeX);
            Mitsubishi.Instance().GetHOME("D12", btnHomeY);
            Mitsubishi.Instance().GetHOME("D14", btnHomeCam);
            // Lock Button
            Mitsubishi.Instance().GetHOME1("M21", btnAxisXDOWN);
            Mitsubishi.Instance().GetHOME1("M22", btnAxisYDOWN);
            Mitsubishi.Instance().GetHOME1("M23", btnAxisCamDown);
            // CHECK Safety
            Mitsubishi.Instance().GetBitButton("Y25", btnSafetylamp);
            Mitsubishi.Instance().GetBitButton("M84", btnErAxisX);
            Mitsubishi.Instance().GetBitButton("M85", btnErAxisY);
            Mitsubishi.Instance().GetBitButton("M86", btnErAxisCAM);
            // MONITOR CHECK SYLEN
            Mitsubishi.Instance().GetBitButton("X12", btnPosSet);
            Mitsubishi.Instance().GetBitButton("X13", btnDownStoper);
            Mitsubishi.Instance().GetBitButton("X11", btnFixUp);
            Mitsubishi.Instance().GetBitButton("X10", btnFixDown);
        }

        private void btnConveyorokOff_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M67");
        }

        private void btnConveyorokOff_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M67");
        }

        private void btnConveyorngOff_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M68");
        }

        private void btnConveyorngOff_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M68");
        }

        private void btnConveyorOff_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M69");
        }

        private void btnConveyorOff_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M69");
        }
    }
}
