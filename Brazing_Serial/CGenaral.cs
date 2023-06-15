using LineMonitorDemo.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Brazing_Serial
{
    class CGenaral
    {
        public static string IP = "192.168.100.100";
        public static int Port = 9004;
        public static string Line = "1";
        public static string[] empAdmin = { "41104", "41105" };

        
        public string GetcheckBrazing(string station, string Line, System.Windows.Forms.Label LB_LI, System.Windows.Forms.Label LB_ST)
        {
            ConnectDB con = new ConnectDB();
            ConnectDBSCM conSCM = new ConnectDBSCM(); 
            SqlCommand sql = new SqlCommand();
            DataTable dt = new DataTable();
            string PDDate = "";
            string PDShift = "";
            string ST = "";
            string ED = "";
            ST = DateTime.Now.AddHours(-8).ToString("yyyy-MM-dd") + " 08:00";
            ED = DateTime.Now.AddHours(-8).AddDays(1).ToString("yyyy-MM-dd") + " 08:00";
            PDDate = DateTime.Now.AddHours(-8).ToString("yyyy-MM-dd");
            if (DateTime.Now >= Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("00")
                + "-" + DateTime.Now.Day.ToString("00") + " 20:00:00"))
            {
                // Night Shift


                PDShift = "N";

            }
            else if (DateTime.Now >= Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("00")
            + "-" + DateTime.Now.Day.ToString("00") + " 08:00:00") && DateTime.Now < Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("00")
                + "-" + DateTime.Now.Day.ToString("00") + " 20:00:00"))
            {
                // Day Shift


                PDShift = "D";
            }
            else if (DateTime.Now < Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("00")
               + "-" + DateTime.Now.Day.ToString("00") + " 08:00:00"))
            {


                PDShift = "N";
            }
            //sql.CommandText = @"SELECT [EmpCode] FROM [dbIoTFac2].[dbo].[Brazing_ManPower] where Brazing_StationNo = @station and PDDate = @pddate and PDShift =  @shift and Line = @Line and Status = 'IN'";
            //sql.Parameters.Add(new SqlParameter("@station", station));
            //sql.Parameters.Add(new SqlParameter("@Line", Line));
            //sql.Parameters.Add(new SqlParameter("@pddate", PDDate));
            //sql.Parameters.Add(new SqlParameter("@shift", PDShift));
            //dt = con.Query(sql);


            // MODIFY > ปรับมาใช้ 226.86 BY.PEERAPONG.K
            LB_LI.Text = Line;
            LB_ST.Text = station;
            sql.CommandText = @"SELECT CODE FROM [dbSCM].[dbo].[SKC_DictMstr] WHERE DICT_TYPE = 'STATION' AND REF_CODE = @LINE AND NOTE = @STCODE"; // NOTE อ้างอิง STATION IN LINE RUNNING 1 2 3 4 ...
            sql.Parameters.Add(new SqlParameter("@LINE", Line));
            sql.Parameters.Add(new SqlParameter("@STCODE", station));
            dt = conSCM.Query(sql);
            if (dt.Rows.Count > 0)
            {
                SqlCommand sql_checkin = new SqlCommand();
                sql_checkin.CommandText = @"SELECT TOP (1) *  FROM [dbSCM].[dbo].[SKC_CheckInOutLog] WHERE DICT_CODE = @STCODE ORDER BY CHK_DATE DESC";
                sql_checkin.Parameters.Add(new SqlParameter("@STCODE", dt.Rows[0]["CODE"]));
                DataTable dtCheckIn = conSCM.Query(sql_checkin);
                try
                {
                    if (dtCheckIn.Rows.Count > 0)
                    {
                        return dtCheckIn.Rows[0]["CHK_EMPCODE"].ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                catch (Exception)
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
            // END MODIFY 

            //try
            //{
            //    if (dt.Rows.Count > 0)
            //    {
            //        return dt.Rows[0]["EmpCode"].ToString();
            //    }
            //    else
            //    {
            //        return "";
            //    }
                
            //}
            //catch (Exception)
            //{


            //}
            //return "";

        }
    }
}
