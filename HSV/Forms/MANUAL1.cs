using ActUtlTypeLib;
using SymbolFactoryDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HSV.Forms
{
    public partial class MANUAL1 : Form
    {
        public MANUAL1()
        {
            InitializeComponent();

        }
        private void rjtFixX__TextChanged(object sender, EventArgs e)
        {

        }
        private void FormManual_Load(object sender, EventArgs e)
        {            
        }
        private void btnPosSet_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M51");
            btnPosSet.BackColor = Color.Green;
        }

        private void btnPosSet_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M51");
            btnPosSet.BackColor = Color.Gray;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M50");
            btnDownStoper.BackColor = Color.Green;
           
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M50");
            btnDownStoper.BackColor = Color.Gray;
        }

        private void btnCAMPUP_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M52");
            btnFixUp.BackColor = Color.Green;
        }

        private void btnCAMPUP_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M52");
            btnFixUp.BackColor = Color.Gray;
            
        }

        private void btnCAMPDOWN_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M53");
            btnFixDown.BackColor = Color.Green;
        }

        private void btnCAMPDOWN_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M53");
            btnFixDown.BackColor = Color.Gray;
        }

        private void btnLOCKSAFETY_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M54");
            btnLOCKSAFETY.BackColor = Color.Green;
        }

        private void btnLOCKSAFETY_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M54");
            btnLOCKSAFETY.BackColor = Color.Gray;
        }

        private void btnCONVEYOROK_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M55");
            btnCONVEYOROKON.BackColor = Color.Green;


        }

        private void btnCONVEYOROK_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M55");
            btnCONVEYOROKON.BackColor = Color.Gray;

        }

        private void btnCONVEYORNG_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M56");
            btnCONVEYORNGON.BackColor = Color.Green;
        }

        private void btnCONVEYORNG_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M56");
            btnCONVEYORNGON.BackColor = Color.Gray;
        }

        private void btnCONVEYOR_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M57");
            btnCONVEYORON.BackColor = Color.Green;
        }

        private void btnCONVEYOR_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M57");
            btnCONVEYORON.BackColor = Color.Gray;
        }

        private void btnSERVOON_Click(object sender, EventArgs e)
        {

            Mitsubishi.Instance().SetBit("M80");
            btnSERVOON.BackColor = Color.Green;
            btnSERVOOFF.BackColor = Color.Gray;

        }

        private void btnSERVOOFF_Click(object sender, EventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M80");
            btnSERVOON.BackColor = Color.Gray;
            btnSERVOOFF.BackColor = Color.Green;
            

        }
        private void btnAxisXUP_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M58");
            btnAxisXUP.BackColor = Color.Green;
        }

        private void btnAxisXUP_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M58");
            btnAxisXUP.BackColor = Color.Gray;
        }

        private void btnAxisXDOWN_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M59");
            btnAxisXDOWN.BackColor = Color.Green;
        }

        private void btnAxisXDOWN_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M59");
            btnAxisXDOWN.BackColor = Color.Gray;
        }

        private void btnAxisYUP_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M60");
            btnAxisYUP.BackColor = Color.Green;
        }

        private void btnAxisYUP_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M60");
            btnAxisYUP.BackColor = Color.Gray;
        }

        private void btnAxisYDOWN_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M61");
           btnAxisYDOWN.BackColor = Color.Green;
        }

        private void btnAxisYDOWN_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M61");
            btnAxisYDOWN.BackColor = Color.Gray;
        }

        private void btnAxisCamUP_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M62");
            btnAxisCamUP.BackColor = Color.Green;
        }

        private void btnAxisCamUP_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M62");
            btnAxisCamUP.BackColor = Color.Gray;
        }

        private void btnAxisCamDown_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M63");
            btnAxisCamDown.BackColor = Color.Green;
        }

        private void btnAxisCamDown_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M63");
            btnAxisCamDown.BackColor = Color.Gray;
        }

        private void btnHomeX_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M10");
            btnHomeX.BackColor = Color.Green;
        }

        private void btnHomeX_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M10");
            btnHomeX.BackColor = Color.Gray;
        }

        private void btnHomeY_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M11");
            btnHomeY.BackColor = Color.Green;
        }

        private void btnHomeY_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M11");
            btnHomeY.BackColor = Color.Gray;
        }

        private void btnHomeCam_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M12");
            btnHomeCam.BackColor = Color.Green;
        }

        private void btnHomeCam_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M12");
            btnHomeCam.BackColor = Color.Gray;
        }
        private void btnRESETX_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M81");
            btnRESETX.BackColor = Color.Green;
        }

        private void btnRESETX_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M81");
            btnRESETX.BackColor = Color.Gray;
        }
        private void btnRESETY_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M82");
            btnRESETY.BackColor = Color.Green;
        }
        private void btnRESETY_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M82");
            btnRESETY.BackColor = Color.Gray;
        }

        private void btnRESETCam_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M83");
            btnRESETCam.BackColor = Color.Green;
        }

        private void btnRESETCam_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M83");
            btnRESETCam.BackColor = Color.Gray;
        }

        //private void tmnMANUAL_Tick(object sender, EventArgs e)
        //{
        //    Mitsubishi.Instance().ReadInt("D30", lblAxisX);
        //    Mitsubishi.Instance().ReadInt("D18", lblAxisY);
        //    Mitsubishi.Instance().ReadInt("D32", lblAxisT);
        //    //Lock button
        //    Mitsubishi.Instance().GetHOME("D10", btnHomeX);
        //    Mitsubishi.Instance().GetHOME("D12", btnHomeY);
        //    Mitsubishi.Instance().GetHOME("D14", btnHomeCam);
        //    // Lock Button
        //    Mitsubishi.Instance().GetHOME1("M21", btnAxisXDOWN);
        //    Mitsubishi.Instance().GetHOME1("M22", btnAxisYDOWN);
        //    Mitsubishi.Instance().GetHOME1("M23", btnAxisCamDown);
        //    // CHECK Safety
        //    Mitsubishi.Instance().GetBitButton("Y25", btnSafetylamp);
        //    Mitsubishi.Instance().GetBitButton("M84", btnErAxisX);
        //    Mitsubishi.Instance().GetBitButton("M85", btnErAxisY);
        //    Mitsubishi.Instance().GetBitButton("M86", btnErAxisCAM);
        //    // MONITOR CHECK SYLEN
        //    Mitsubishi.Instance().GetBitButton("X12", btnPosSet);
        //    Mitsubishi.Instance().GetBitButton("X13", btnDownStoper);
        //    Mitsubishi.Instance().GetBitButton("X11", btnFixUp);
        //    Mitsubishi.Instance().GetBitButton("X10", btnFixDown);
        //}

        private void btnConveyorokOff_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M67");
            btnConveyorokOff.BackColor = Color.Green;
        }

        private void btnConveyorokOff_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M67");
            btnConveyorokOff.BackColor = Color.Gray;
        }

        private void btnConveyorngOff_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M68");
            btnConveyorngOff.BackColor = Color.Green;
        }

        private void btnConveyorngOff_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M68");
            btnConveyorngOff.BackColor = Color.Gray;
        }

        private void btnConveyorOff_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M69");
            btnConveyorOff.BackColor = Color.Green;
        }

        private void btnConveyorOff_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M69");
            btnConveyorOff.BackColor = Color.Gray;
        }

        private void tmnMANUAL_Tick_1(object sender, EventArgs e)
        {
            //Mitsubishi.Instance().ReadInt("D30", lblAxisX);
            //Mitsubishi.Instance().ReadInt("D18", lblAxisY);
            //Mitsubishi.Instance().ReadInt("D32", lblAxisT);
            //Lock button
            //Mitsubishi.Instance().GetHOME("D10", btnHomeX);
            //Mitsubishi.Instance().GetHOME("D12", btnHomeY);
            //Mitsubishi.Instance().GetHOME("D14", btnHomeCam);
            // Lock Button
            //Mitsubishi.Instance().GetHOME1("M21", btnAxisXDOWN);
            //Mitsubishi.Instance().GetHOME1("M22", btnAxisYDOWN);
            //Mitsubishi.Instance().GetHOME1("M23", btnAxisCamDown);
            // CHECK Safety
            //Mitsubishi.Instance().GetBitButton("Y25", btnSafetylamp);
            //Mitsubishi.Instance().GetBitButton("M84", btnErAxisX);
            //Mitsubishi.Instance().GetBitButton("M85", btnErAxisY);
            //Mitsubishi.Instance().GetBitButton("M86", btnErAxisCAM);
            // MONITOR CHECK SYLEN
            //Mitsubishi.Instance().GetBitButton("X12", btnPosSet);
            //Mitsubishi.Instance().GetBitButton("X13", btnDownStoper);
            //Mitsubishi.Instance().GetBitButton("X11", btnFixUp);
            //Mitsubishi.Instance().GetBitButton("X10", btnFixDown);
        }
    }
}
