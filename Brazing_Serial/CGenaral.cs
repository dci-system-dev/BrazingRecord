using LineMonitorDemo.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

        
        public string GetcheckBrazing(string station, string Line)
        {
            ConnectDB con = new ConnectDB();
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
            sql.CommandText = @"SELECT [EmpCode]

  FROM [dbIoTFac2].[dbo].[Brazing_ManPower]
  where Brazing_StationNo = @station and PDDate = @pddate and PDShift =  @shift and Line = @Line and Status = 'IN'";
            sql.Parameters.Add(new SqlParameter("@station", station));
            sql.Parameters.Add(new SqlParameter("@Line", Line));
            sql.Parameters.Add(new SqlParameter("@pddate", PDDate));
            sql.Parameters.Add(new SqlParameter("@shift", PDShift));
            dt = con.Query(sql);
            try
            {
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["EmpCode"].ToString();
                }
                else
                {
                    return "";
                }
                
            }
            catch (Exception)
            {


            }
            return "";

        }
    }
}
