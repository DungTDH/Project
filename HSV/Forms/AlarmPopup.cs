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
    public partial class AlarmPopup : Form
    {
        int id = 0;
        string sAlarmText;
        public AlarmPopup()
        {
           
            InitializeComponent();
        }
        public void SetInfo(int AlarmID, string Text)
        {
            id = AlarmID;
            sAlarmText = Text;
            rjtAlarmID.Texts = id.ToString();
            rjtAlarmText.Texts = sAlarmText;
        }
        private void rjbConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AlarmPopup_Load(object sender, EventArgs e)
        {
           
        }
    }
}
