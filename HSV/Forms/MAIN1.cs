using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HSV.Forms
{
    public partial class AUTO : Form
    {
        public AUTO()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbl03h_Click(object sender, EventArgs e)
        {

        }

        private void label58_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void AUTO_Load(object sender, EventArgs e)
        {
            tmrMain.Interval = 1000;
            tmrMain.Enabled = true;
        }



        private void rjButton3_Click(object sender, EventArgs e)
        {
            Mitsubishi.Instance().Open();
            if (Mitsubishi.Instance().PLC_Connect == true)
            {
                MessageBox.Show("Success!!!");             
            }

        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            Mitsubishi.Instance().Close();
            MessageBox.Show("Disconnect!!!");

        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1004");
            Mitsubishi.Instance().ResetBit("M1005");
        }

        private void btnBEGIN_Click(object sender, EventArgs e)
        {
            
           
        }

        private void btnENDUP_Click(object sender, EventArgs e)
        {
           
            
        }
        private void tmrMain_Tick(object sender, EventArgs e)
        {
                 
            Mitsubishi.Instance().ReadReal("D48", "D49", lblCurrentTacttime);
            Mitsubishi.Instance().ReadReal("D50", "D51", lblPreviousTactTime);
            Mitsubishi.Instance().ReadDint1("D60", lblShift1);
            Mitsubishi.Instance().ReadDint1("D66", lblShift2);
            
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl21h_Click(object sender, EventArgs e)
        {

        }
        #region Nút bấm
        private void btnRUN_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1000");
            btnRUN.BackColor = Color.Green;
        }

        private void btnRUN_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1000");
            btnRUN.BackColor = Color.Gray;
        }

        private void btnStop_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1001");
            btnStop.BackColor = Color.Green;
        }

        private void btnStop_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1001");
            btnStop.BackColor = Color.Red;
        }

        private void btnReset_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1002");
            btnReset.BackColor = Color.Green;
        }

        private void btnReset_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1002");
            btnReset.BackColor = Color.Gray;
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1003");
            btnORIGIN.BackColor = Color.Yellow;
        }

        private void button5_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1003");
            btnORIGIN.BackColor = Color.Gray;
        }

        private void btnAuto_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1004");
        }

        private void btnAuto_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1004");
        }

        private void btnManual_MouseDown(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1005");
        }

        private void btnManual_MouseUp(object sender, MouseEventArgs e)
        {
            Mitsubishi.Instance().ResetBit("M1005");
        }
        #endregion

        private void btnManual_Click(object sender, EventArgs e)
        {
            Mitsubishi.Instance().SetBit("M1005");
            Mitsubishi.Instance().ResetBit("M1004");
        }

        private void btnAuto_MouseDown_1(object sender, MouseEventArgs e)
        {
            btnAuto.BackColor = Color.Green;
        }

        private void btnAuto_MouseUp_1(object sender, MouseEventArgs e)
        {
            btnAuto.BackColor = Color.Gray;
        }

        private void btnManual_MouseDown_1(object sender, MouseEventArgs e)
        {
            btnManual.BackColor = Color.Green;
        }

        private void btnManual_MouseUp_1(object sender, MouseEventArgs e)
        {
            btnManual.BackColor = Color.Gray;
        }
    }
}
