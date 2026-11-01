// 12/08/2026

using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace StandardMetals.CommonLibrary
{
    public static class LogInfo
    {
        private static string fileName;

        static LogInfo()
        {
            // fileName = @"C:\Users\Priti\Desktop\MVC\StandartMetalsERP\StandartMetalsERP\StandardMetals.WebApp\LogError\" + "Log_" + DateTime.Now.ToString("ddMMyyyy") + ".txt";
            // fileName = @"D:\F\Apps\LMS\StandartMetalsERP\StandardMetals.WebApp\LogError\" + "Log_" + DateTime.Now.ToString("ddMMyyyy") + ".txt";
            fileName = @"D:\AalimEx Softcode\SM Project\StandartMetalsERP\StandardMetals.WebApp\LogError\" + "Log_" + DateTime.Now.ToString("ddMMyyyy") + ".txt";
            // D:\F\Apps\LMS\StandartMetalsERP\StandardMetals.WebApp
            //D:\F\Apps\MVC-Priti\Prod\StandartMetalsERP\StandartMetalsERP\StandardMetals.WebApp\LogError
        }

        public static void LogDetailToFile(string logText)
        {
            FileInfo fi = new FileInfo(fileName);

            try
            {
                if (fi.Exists)
                {
                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                        sw.WriteLine("Log Date = " + DateTime.Now.ToString());
                        sw.WriteLine("Step= " + logText);
                        sw.WriteLine("---------------------------------------xxxxxxxx------------------------------------");
                    }
                }
                else
                {
                    using (StreamWriter sw = fi.CreateText())
                    {
                        sw.WriteLine("Log Date = " + DateTime.Now.ToString());
                        sw.WriteLine("Step= " + logText);
                        sw.WriteLine("---------------------------------------xxxxxxxx------------------------------------");
                    }
                }

                LoginDetailToDB(logText, null);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        public static void LogDetailToFile(string logText, Exception ex)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                        sw.WriteLine("----------------------------------Exception-----------------------------------------");
                        sw.WriteLine("Log Date = " + DateTime.Now.ToString());
                        sw.WriteLine("Error = " + ex.Message);
                        sw.WriteLine("Stack Trace = " + ex.StackTrace);
                        sw.WriteLine("---------------------------------------xxxxxxxx------------------------------------");
                    }
                }
                else
                {
                    using (StreamWriter sw = File.CreateText(fileName))
                    {
                        sw.WriteLine("----------------------------------Exception-----------------------------------------");
                        sw.WriteLine("Log Date = " + DateTime.Now.ToString());
                        sw.WriteLine("Error = " + ex.Message);
                        sw.WriteLine("Stack Trace = " + ex.StackTrace);
                        sw.WriteLine("---------------------------------------xxxxxxxx------------------------------------");
                    }
                }

                LoginDetailToDB(logText, ex);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        public static string LoginDetailToDB(string logText, Exception ex)
        {
            string strCon = @"Data Source=ONKAR\SQLEXPRESS16;Initial Catalog=aaliml4n_MVC_ERPNEW1;Integrated Security=True";
            string resultMessage = "Success";

            try
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand("SpLogtoDB", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LogText", logText);
                        cmd.Parameters.AddWithValue("@ExceptionMessage", ex != null ? ex.Message : string.Empty);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception Ex)
            {
                resultMessage = "Error: " + Ex.Message;
                Console.WriteLine(Ex.ToString());
            }

            return resultMessage;
        }
    }
}