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
    public partial class ARLAM : Form
    {
        public ARLAM()
        {
            InitializeComponent();
        }
        AlarmView currentView = AlarmView.Current;
        private void timer1_Tick(object sender, EventArgs e)
        {
            dgvAlarm.Rows.Clear();
            switch(currentView)
            {
                case AlarmView.Current:
                    foreach (Alarm al in MCAlarm.mCurAlarmList)
                    {
                        dgvAlarm.Rows.Add(al.TimeSet.ToString("yyyy-MM-dd, hh:mm:ss"), al.ID, al.AlarmName,"","","");
                    }
                    break;
                case AlarmView.History:
                    foreach (Alarm al in MCAlarm.mListAlarmHistory)
                    {
                        dgvAlarm.Rows.Add(al.TimeSet.ToString("yyyy-MM-dd, hh:mm:ss"), al.ID, al.AlarmName,
                            al.TimeReset.ToString("yyyy-MM-dd, hh:mm:ss"),al.TotalTime,al.Count);
                    }
                    break;
                case AlarmView.Frequency:
                    foreach (Alarm al in MCAlarm.mListAlarmFrequency)
                    {
                        dgvAlarm.Rows.Add("", al.ID, al.AlarmName,"", al.TotalTime, al.Count);
                    }
                    break;
                case AlarmView.All:
                    foreach (Alarm al in MCAlarm.mAlarmListTotal)
                    {
                        dgvAlarm.Rows.Add("", al.ID, al.AlarmName,"", "", "");
                    }
                    timer1.Enabled = false;
                    break;
            }    
              
            
        }

        private void btnCurrentAlarm_Click(object sender, EventArgs e)
        {
            currentView = AlarmView.Current;
            timer1.Enabled = true;
        }

        private void btnHistoryAlarm_Click(object sender, EventArgs e)
        {
            currentView = AlarmView.History;
            timer1.Enabled = true;
        }

        private void btnAlarmFrequency_Click(object sender, EventArgs e)
        {
            currentView = AlarmView.Frequency;
            timer1.Enabled = true;
        }

        private void btnAlarmAll_Click(object sender, EventArgs e)
        {
            currentView = AlarmView.All;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            MCAlarm.mListAlarmHistory.Clear();
            MCAlarm.mListAlarmFrequency.Clear();
            MessageBox.Show("Compled Clear Alarm History and Frequency");
        }
    }
    public enum AlarmView
    {
        Current,
        History,
        Frequency,
        All,
    }
}
