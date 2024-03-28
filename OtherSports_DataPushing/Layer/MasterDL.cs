using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace OtherSports_DataPushing.Layer
{
    class MasterDL
    {
        #region VARIABLE DECLARATION

        #region "SQL VARIABLE"

        SqlConnection con;
        SqlDataAdapter Ada;
        SqlCommand Sqlcmd;
        DataSet Dset;
        DataTable Dt;


        #endregion

        Boolean TrueOrFalse;

        DBConnection Objcon;
        string RetrunStr;
        #endregion

        // EXECUTE QUERY AND RETURN VALUE INTEGER FORMATE
        public int ExeQueryStrDL(string Query, int DBValue)
        {
            Int32 BallId = 0;
            Objcon = new DBConnection();
            try
            {
                con = Objcon.SqlConnectionDB(DBValue);
                if (con.State == ConnectionState.Closed) con.Open();
                Sqlcmd = new SqlCommand(Query, con);
                BallId = int.Parse(Sqlcmd.ExecuteScalar().ToString());
            }
            catch
            {
                return BallId;
            }
            finally
            {
                con.Close();
            }
            return BallId;
        }
        // EXECUTE VALUE AND RETURN VALUE BOOLEAN TYPE
        public Boolean ExeQueryRetBooDL(String Query, int DBValue)
        {
            Boolean Result = false;
            Objcon = new DBConnection();
            try
            {
                con = Objcon.SqlConnectionDB(DBValue);
                if (con.State == ConnectionState.Closed) con.Open();
                Sqlcmd = new SqlCommand(Query, con);
                Sqlcmd.CommandTimeout = 0;
                Sqlcmd.ExecuteNonQuery();
                Result = true;
            }
            catch(Exception ex)
            {
                WriteToLog(ex.Message);
                WriteToLog(Query);
                return Result;
            }
            finally
            {
                con.Close();
            }
            return Result;

        }
        public DataTable ExeQueryStrRetDTDL(string Query, int DBValue)
            {
            Objcon = new DBConnection();
            Dt = new DataTable();
            try
            {
                con = Objcon.SqlConnectionDB(DBValue);
                if (con.State == ConnectionState.Closed) con.Open();
                Sqlcmd = new SqlCommand(Query, con);
                Ada = new SqlDataAdapter(Sqlcmd);
                Ada.Fill(Dt);
            }
            catch
            {
                return Dt;
            }
            finally
            {
                con.Close();
            }
            return Dt;
        }
        public DataSet ExeQueryStrRetDsDL(string Query, int DBValue)
        {
            Objcon = new DBConnection();
            Dset = new DataSet();
            try
            {
                con = Objcon.SqlConnectionDB(DBValue);
                if (con.State == ConnectionState.Closed) con.Open();
                Sqlcmd = new SqlCommand(Query, con);
                Ada = new SqlDataAdapter(Sqlcmd);
                Ada.SelectCommand.CommandTimeout = 10000;
                Ada.Fill(Dset);
            }
            catch
            {
                return Dset;
            }
            finally
            {
                con.Close();
            }
            return Dset;
        }
        public String ExeQueryStrRetStrDL(string Query, int DBValue)
        {
            RetrunStr = string.Empty;
            Objcon = new DBConnection();
            try
            {
                con = Objcon.SqlConnectionDB(DBValue);
                if (con.State == ConnectionState.Closed) con.Open();
                Sqlcmd = new SqlCommand(Query, con);
                Sqlcmd.CommandTimeout = 0;
                RetrunStr = Sqlcmd.ExecuteScalar().ToString();
            }
            catch
            {
                return RetrunStr;
            }
            finally
            {
                con.Close();
            }
            return RetrunStr;
        }
        // EXECUTE QUERY AND RETURN VALUE DATETIME FORMATE
        public DateTime ExeQueryStrRetDateDL(string Query, int DBValue)
        {
            DateTime DateTimeVal = DateTime.Now;
            Objcon = new DBConnection();
            try
            {
                con = Objcon.SqlConnectionDB(DBValue);
                if (con.State == ConnectionState.Closed) con.Open();
                Sqlcmd = new SqlCommand(Query, con);
                DateTimeVal = Convert.ToDateTime(Sqlcmd.ExecuteScalar());
            }
            catch
            {
                return DateTimeVal;
            }
            finally
            {
                con.Close();
            }
            return DateTimeVal;
        }
        public Boolean BulkCopyDL(string TableName, DataTable Dt, int DBValue)
        {
            Boolean RetBool = false;
            Dset = new DataSet();
            Objcon = new DBConnection();

            try
            {
                con = Objcon.SqlConnectionDB(DBValue);
                if (con.State == ConnectionState.Closed) con.Open();
                SqlBulkCopy Sqlbul = new SqlBulkCopy(con);
                Sqlbul.DestinationTableName = TableName;
                Sqlbul.WriteToServer(Dt);
                RetBool = true;
            }
            catch
            {
                return RetBool;
            }
            finally
            {
                con.Close();
            }
            return RetBool;
        }
        public void WriteToLog(string text)
        {
            //if (EnLog.Checked == true)
            //{
            string sTemp = System.Windows.Forms.Application.StartupPath + "\\Loadtime_Log_" + DateTime.Now.ToString("dd_MM") + ".txt";
            FileStream Fs = new FileStream(sTemp, FileMode.OpenOrCreate | FileMode.Append);
            StreamWriter st = new StreamWriter(Fs);
            string dttemp = DateTime.Now.ToString("[dd:MM:yyyy] [HH:mm:ss:ffff]"); //"[" + DateTime.Now.Day + ":" + DateTime.Now.Month + ":" + DateTime.Now.Year + "] [" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + ":" + DateTime.Now.Millisecond + "]";
            st.WriteLine(dttemp + "\t" + text);
            st.Close();
            // }
        }
    }
}
