using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace OtherSports_DataPushing.Layer
{
    class DBConnection
    {
        #region "DATA BASE VARIALBLE DECLARATION"
        public SqlConnection con;
        SqlDataAdapter Ada;
        SqlCommand SqlCmd;
        SqlCommandBuilder SqlCmdBld;
        #endregion

        #region "DATA BASE CONNECTION CODING"
        public SqlConnection SqlConnectionDB(int i)
        {
            if (i == 1)
                con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectString"]);
            else if (i == 2)
                con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectFrom"]);
            else if (i == 3)
                con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectString2"]);
            return con;
        }
        #endregion
    }
}
