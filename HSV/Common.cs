using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HSV
{
    class Common
    {
    }
    public class MCAlarm
    {
        public static Forms.AlarmPopup PopUpAlarm = new Forms.AlarmPopup();
        public static List<Alarm> mTempCurAlarmList = new List<Alarm>();
        public static bool AlarmExist = false;
        public static int alarmCount = 0;
        static string _alarmTotalFileName = "AlarmTotal.csv";
        static string _alarmHistoryFileName = DateTime.Now.ToString("yyyy_MM") + "_AlarmHistory.csv";
        static string _alarmFrequencyFileName = DateTime.Now.ToString("yyyy_MM") + "_AlarmFrequency.csv";
        public static List<Alarm> mAlarmListTotal = new List<Alarm>();
        public static List<Alarm> mCurAlarmList = new List<Alarm>();
        public static List<Alarm> mListAlarmHistory = new List<Alarm>();
        public static List<Alarm> mListAlarmFrequency = new List<Alarm>();
        public bool[] AlarmIDArray;
        public static void UpdateFrequency()
        {
            // Update Alarm frequency
            foreach (Alarm al in mListAlarmHistory)
            {
                bool isAdd = true;
                foreach (Alarm alF in mListAlarmFrequency)
                {
                    if (alF.ID == al.ID)
                    {
                        isAdd = false;
                        break;
                    }
                }
                if (isAdd)
                {
                    Alarm newAlarm = new Alarm();
                    newAlarm.ID = al.ID;
                    newAlarm.AlarmName = al.AlarmName;
                    mListAlarmFrequency.Add(newAlarm);
                }
            }
            foreach (Alarm al in mListAlarmFrequency)
            {
                int count = 0;
                int totaltime = 0;
                foreach (Alarm alH in mListAlarmHistory)
                {
                    if (alH.ID == al.ID)
                    {
                        count += 1;
                        totaltime += (int)(alH.TimeReset - alH.TimeSet).TotalSeconds;
                        // mListAlarmFrequency[mListAlarmFrequency.FindIndex(a => a.ID == al.ID)].Count += 1;
                        // mListAlarmFrequency[mListAlarmFrequency.FindIndex(a => a.ID == al.ID)].TotalTime += (int)(alH.TimeReset - alH.TimeSet).TotalSeconds;
                    }
                    al.Count = count;
                    al.TotalTime = totaltime;
                }

            }

        }

        public static void LoadAlarmTotal()
        {
            alarmCount = 0;
            string[] sAlarmList = System.IO.File.ReadAllLines(Application.StartupPath + "\\" + _alarmTotalFileName);
            for (int i = 0; i < sAlarmList.Length; i++)
            {
                Alarm alarm = new Alarm();
                string[] sAlarminfo = sAlarmList[i].Split(',');
                if (sAlarminfo.Length == 2)
                {
                    int iID = 0;
                    if (int.TryParse(sAlarminfo[0], out iID))
                    {
                        alarm.ID = iID;
                        alarm.AlarmName = sAlarminfo[1];
                        mAlarmListTotal.Add(alarm);
                        alarmCount++;
                    }
                }
            }
        }
        public static void LoadAlarmHistoryFrequency()
        {
            LoadAlarmHistory();
            LoadAlarmFrequency();
        }
        static void LoadAlarmHistory()
        {
            lock (saveLock)
            {
                //List<Alarm> listAlarm = new List<Alarm>();
                try
                {
                    string[] sAlarmList = System.IO.File.ReadAllLines(Application.StartupPath + "\\" + _alarmHistoryFileName);
                    for (int i = 0; i < sAlarmList.Length; i++)
                    {
                        Alarm alarm = new Alarm();
                        string[] sAlarminfo = sAlarmList[i].Split(',');
                        if (sAlarminfo.Length == 16)
                        {
                            int iID = 0;
                            if (int.TryParse(sAlarminfo[0], out iID))
                            {
                                alarm.ID = iID;
                                alarm.AlarmName = sAlarminfo[1];
                                int yyyySet = 0;
                                int ddSet = 0;
                                int MMSet = 0;
                                int hhSet = 0;
                                int mmSet = 0;
                                int ssSet = 0;
                                int yyyyReset = 0;
                                int ddReset = 0;
                                int MMReset = 0;
                                int hhReset = 0;
                                int mmReset = 0;
                                int ssReset = 0;
                                int totalTime = 0;
                                int count = 0;

                                int.TryParse(sAlarminfo[2], out yyyySet);
                                int.TryParse(sAlarminfo[3], out MMSet);
                                int.TryParse(sAlarminfo[4], out ddSet);
                                int.TryParse(sAlarminfo[5], out hhSet);
                                int.TryParse(sAlarminfo[6], out mmSet);
                                int.TryParse(sAlarminfo[7], out ssSet);

                                int.TryParse(sAlarminfo[8], out yyyyReset);
                                int.TryParse(sAlarminfo[9], out MMReset);
                                int.TryParse(sAlarminfo[10], out ddReset);
                                int.TryParse(sAlarminfo[11], out hhReset);
                                int.TryParse(sAlarminfo[12], out mmReset);
                                int.TryParse(sAlarminfo[13], out ssReset);

                                int.TryParse(sAlarminfo[14], out totalTime);
                                int.TryParse(sAlarminfo[15], out count);

                                DateTime timeSet = new DateTime(yyyySet, MMSet, ddSet, hhSet, mmSet, ssSet);
                                DateTime timeReset = new DateTime(yyyyReset, MMReset, ddReset, hhReset, mmReset, ssReset);

                                alarm.TimeSet = timeSet;
                                alarm.TimeReset = timeReset;
                                alarm.TotalTime = totalTime;
                                alarm.Count = count;
                                mListAlarmHistory.Add(alarm);
                            }

                        }
                    }
                }
                catch { }
            }
        }
        static void LoadAlarmFrequency()
        {
            lock (saveLock)
            {
                //List<Alarm> listAlarm = new List<Alarm>();
                try
                {
                    string[] sAlarmList = System.IO.File.ReadAllLines(Application.StartupPath + "\\" + _alarmFrequencyFileName);
                    for (int i = 0; i < sAlarmList.Length; i++)
                    {
                        Alarm alarm = new Alarm();
                        string[] sAlarminfo = sAlarmList[i].Split(',');
                        if (sAlarminfo.Length == 16)
                        {
                            int iID = 0;
                            if (int.TryParse(sAlarminfo[0], out iID))
                            {
                                alarm.ID = iID;
                                alarm.AlarmName = sAlarminfo[1];
                                int yyyySet = 0;
                                int ddSet = 0;
                                int MMSet = 0;
                                int hhSet = 0;
                                int mmSet = 0;
                                int ssSet = 0;
                                int yyyyReset = 0;
                                int ddReset = 0;
                                int MMReset = 0;
                                int hhReset = 0;
                                int mmReset = 0;
                                int ssReset = 0;
                                int totalTime = 0;
                                int count = 0;

                                int.TryParse(sAlarminfo[2], out yyyySet);
                                int.TryParse(sAlarminfo[3], out MMSet);
                                int.TryParse(sAlarminfo[4], out ddSet);
                                int.TryParse(sAlarminfo[5], out hhSet);
                                int.TryParse(sAlarminfo[6], out mmSet);
                                int.TryParse(sAlarminfo[7], out ssSet);

                                int.TryParse(sAlarminfo[8], out yyyyReset);
                                int.TryParse(sAlarminfo[9], out MMReset);
                                int.TryParse(sAlarminfo[10], out ddReset);
                                int.TryParse(sAlarminfo[11], out hhReset);
                                int.TryParse(sAlarminfo[12], out mmReset);
                                int.TryParse(sAlarminfo[13], out ssReset);

                                int.TryParse(sAlarminfo[14], out totalTime);
                                int.TryParse(sAlarminfo[15], out count);

                                DateTime timeSet = new DateTime(yyyySet, MMSet, ddSet, hhSet, mmSet, ssSet);
                                DateTime timeReset = new DateTime(yyyyReset, MMReset, ddReset, hhReset, mmReset, ssReset);

                                alarm.TimeSet = timeSet;
                                alarm.TimeReset = timeReset;
                                alarm.TotalTime = totalTime;
                                alarm.Count = count;
                                mListAlarmFrequency.Add(alarm);
                            }

                        }
                    }
                }
                catch { }
            }
        }
        public static void SaveAlarm()
        {
            SaveAlarmFrequency();
            SaveAlarmHistory();
        }
        static object saveLock = new object();
        static void SaveAlarmHistory()
        {
            string fileName = Application.StartupPath + "\\" + _alarmHistoryFileName;

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            try
            {
                using (StreamWriter w = File.AppendText(fileName))
                {
                    try
                    {
                        foreach (Alarm al in mListAlarmHistory)
                        {
                            string strAlarmInfo = "";
                            strAlarmInfo += al.ID.ToString() + ",";
                            strAlarmInfo += al.AlarmName + ",";
                            strAlarmInfo += al.TimeSet.Year.ToString() + ",";
                            strAlarmInfo += al.TimeSet.Month.ToString() + ",";
                            strAlarmInfo += al.TimeSet.Day.ToString() + ",";
                            strAlarmInfo += al.TimeSet.Hour.ToString() + ",";
                            strAlarmInfo += al.TimeSet.Minute.ToString() + ",";
                            strAlarmInfo += al.TimeSet.Second.ToString() + ",";

                            strAlarmInfo += al.TimeReset.Year.ToString() + ",";
                            strAlarmInfo += al.TimeReset.Month.ToString() + ",";
                            strAlarmInfo += al.TimeReset.Day.ToString() + ",";
                            strAlarmInfo += al.TimeReset.Hour.ToString() + ",";
                            strAlarmInfo += al.TimeReset.Minute.ToString() + ",";
                            strAlarmInfo += al.TimeReset.Second.ToString() + ",";

                            strAlarmInfo += al.TotalTime.ToString() + ",";
                            strAlarmInfo += al.Count.ToString();

                            w.WriteLine(strAlarmInfo);
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }
        static void SaveAlarmFrequency()
        {
            string fileName = Application.StartupPath + "\\" + _alarmFrequencyFileName;

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            try
            {
                using (StreamWriter w = File.AppendText(fileName))
                {
                    try
                    {
                        foreach (Alarm al in mListAlarmFrequency)
                        {
                            string strAlarmInfo = "";
                            strAlarmInfo += al.ID.ToString() + ",";
                            strAlarmInfo += al.AlarmName + ",";
                            strAlarmInfo += al.TimeSet.Year.ToString() + ",";
                            strAlarmInfo += al.TimeSet.Month.ToString() + ",";
                            strAlarmInfo += al.TimeSet.Day.ToString() + ",";
                            strAlarmInfo += al.TimeSet.Hour.ToString() + ",";
                            strAlarmInfo += al.TimeSet.Minute.ToString() + ",";
                            strAlarmInfo += al.TimeSet.Second.ToString() + ",";

                            strAlarmInfo += al.TimeReset.Year.ToString() + ",";
                            strAlarmInfo += al.TimeReset.Month.ToString() + ",";
                            strAlarmInfo += al.TimeReset.Day.ToString() + ",";
                            strAlarmInfo += al.TimeReset.Hour.ToString() + ",";
                            strAlarmInfo += al.TimeReset.Minute.ToString() + ",";
                            strAlarmInfo += al.TimeReset.Second.ToString() + ",";

                            strAlarmInfo += al.TotalTime.ToString() + ",";
                            strAlarmInfo += al.Count.ToString();

                            w.WriteLine(strAlarmInfo);
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }
    }

    public class Alarm
    {
        public bool AlarmStatus = false;
        public DateTime TimeSet = new DateTime();
        public int ID = 0;
        public string AlarmName = "";
        public DateTime TimeReset = new DateTime();
        public int TotalTime = 0;
        public int Count = 0;
    }

    public class ProductionHours
    {
        public int h00 = 0;
        public int h01 = 0;
        public int h02 = 0;
        public int h03 = 0;
        public int h04 = 0;
        public int h05 = 0;
        public int h06 = 0;
        public int h07 = 0;
        public int h08 = 0;
        public int h09 = 0;
        public int h10 = 0;
        public int h11 = 0;
        public int h12 = 0;
        public int h13 = 0;
        public int h14 = 0;
        public int h15 = 0;
        public int h16 = 0;
        public int h17 = 0;
        public int h18 = 0;
        public int h19 = 0;
        public int h20 = 0;
        public int h21 = 0;
        public int h22 = 0;
        public int h23 = 0;
    }


}
