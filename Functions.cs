using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Locker
{
    class Functions
    {
        private SqlConnection Con;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;

        private string ConStr;
        public static int[] attemptsCounter=new int[24];
        public Functions()
        {
            ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Mohammed course\EE499\project v6\Locker.mdf;Integrated Security=True";
          //  ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Mohaed\Locker\Locker.mdf;Integrated Security=True";
            Con = new SqlConnection(ConStr);
            cmd = new SqlCommand();
            cmd.Connection = Con;

        }


       public static void StartKey()
        {
            
            Process[] pname = Process.GetProcessesByName("osk");
            if (pname.Length == 0)
            {
                
                Process process = new Process();
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.WorkingDirectory = "c:\\";
                process.StartInfo.FileName = "c:\\WINDOWS\\system32\\osk.exe";
                //process.StartInfo.Verb = "runas";
                process.Start();
            }
        }
        public DataTable GetData(string Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, ConStr);
            sda.Fill(dt);
            return dt;
        }
        public int SetData(string Query)
        {
            int cnt = 0;
            if(Con.State == ConnectionState.Closed)
            {
                Con.Open();

            }
            cmd.CommandText = Query;
            cnt = cmd.ExecuteNonQuery();
            Con.Close();
            return cnt;
        }
    }
}
