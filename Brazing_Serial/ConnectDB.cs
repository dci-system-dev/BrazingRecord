﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Web;
using System.Threading.Tasks;
using System.Configuration;
namespace LineMonitorDemo.Connection
{
    class ConnectDB
    {
        private bool useDB = true;
        //private string connStr = System.Configuration.ConfigurationSettings.AppSettings["DesignMachineMonitoring.Properties.Settings.ETD_YCConnectionString"];
        private string connStr = "Data Source=192.168.226.145;Initial Catalog=dbIoTFac2; Persist Security Info=True; User ID=sa;Password=decjapan;";
        //private string connStr = "Data Source=192.168.226.234;Initial Catalog=ETD_YC; Persist Security Info=True; User ID=sa;Password=decjapan;";


        //Property ObjectManages As Object

        /// <summary>
        /// Query table by string and return table 
        /// </summary>
        /// <param name="queryStr">String of sql query</param>
        /// <returns>DataTable</returns>
        /// <remarks></remarks>
        public DataTable Query(string queryStr)
        {


            if (useDB)
            {
                SqlConnection conn = new SqlConnection(connStr);
                SqlDataAdapter adapter = new SqlDataAdapter(queryStr, conn);
                DataTable dTable = new DataTable();
                DataSet dSet = new DataSet();

                try
                {
                    adapter.Fill(dSet, "dataTable");
                    return dSet.Tables["dataTable"];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return dTable;
                }

            }
            else
            {
                return new DataTable();
            }

        }

        /// <summary>
        /// Query table by string and return table 
        /// </summary>
        /// <param name="commandDb">CommandDB for query</param>
        /// <returns>DataTable</returns>
        /// <remarks></remarks>
        public DataTable Query(SqlCommand commandDb)
        {


            if (useDB)
            {
                SqlConnection conn = new SqlConnection(connStr);
                commandDb.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(commandDb);
                DataTable dTable = new DataTable();
                DataSet dSet = new DataSet();

                try
                {
                    adapter.Fill(dSet, "dataTable");
                    return dSet.Tables["dataTable"];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return dTable;
                }

            }
            else
            {
                return new DataTable();
            }

            //=================================================================================
        }

        /// <summary>
        /// Execute คำสั่ง sql
        /// </summary>
        /// <param name="exeStr">String of sql</param>
        /// <remarks></remarks>

        public void ExecuteCommand(string exeStr)
        {
            if (useDB)
            {
                SqlConnection conn = new SqlConnection(connStr);
                try
                {
                    SqlCommand commandDb = new SqlCommand(exeStr, conn);
                    ExecuteCommand(commandDb);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }

        }

        /// <summary>
        /// ExecuteCommand
        /// </summary>
        /// <param name="commandDb">commanddb for execute</param>
        /// <remarks></remarks>
        public void ExecuteCommand(SqlCommand commandDb)
        {
            if (useDB)
            {
                SqlConnection conn = new SqlConnection(connStr);
                try
                {
                    commandDb.Connection = conn;
                    conn.Open();
                    commandDb.ExecuteNonQuery();
                    conn.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }
        /// <summary>
        /// Execute หลายๆคำสั่ง พร้อมการ Rollback เมื่อคำสั่งไม่สำเร็จทั้งชุด
        /// </summary>
        /// <param name="exeStr"></param>
        /// <remarks></remarks>
        public void ExecuteCommand(List<string> exeStr)
        {
            if (useDB)
            {
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand commandDb = new SqlCommand();
                conn.Open();

                SqlTransaction transaction = null;
                // Start a local transaction
                transaction = conn.BeginTransaction("SampleTransaction");

                commandDb.Connection = conn;
                commandDb.Transaction = transaction;

                try
                {

                    for (int index = 0; index <= exeStr.Count - 1; index++)
                    {
                        commandDb.CommandText = exeStr[index];
                        commandDb.ExecuteNonQuery();

                    }

                    //Commit
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    //Rollback
                    transaction.Rollback();
                    Console.WriteLine(ex.ToString());
                }

                conn.Close();
            }
        }

        /// <summary>
        /// Execute หลายๆคำสั่ง พร้อมการ Rollback เมื่อคำสั่งไม่สำเร็จทั้งชุด
        /// </summary>
        /// <param name="commandDb"></param>
        /// <remarks></remarks>
        public void ExecuteCommand(List<SqlCommand> commandDb)
        {
            if (useDB)
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();

                SqlTransaction transaction = null;
                // Start a local transaction
                transaction = conn.BeginTransaction("SampleTransaction");

                try
                {

                    for (int index = 0; index <= commandDb.Count - 1; index++)
                    {
                        commandDb[index].Connection = conn;
                        commandDb[index].Transaction = transaction;
                        commandDb[index].ExecuteNonQuery();

                    }

                    //Commit
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    //Rollback
                    transaction.Rollback();
                    Console.WriteLine(ex.ToString());
                }

                conn.Close();
            }
        }


    }
}
