using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace OtherSports_DataPushing.Layer
{
    class BusinessLy
    {
        MasterDL ObjMDL;
        Boolean BLFlag;

        //EXECUTE SQL QUERY COMMON AND RETURN INTEGER VALUE
        public Int32 ExeQueryStrIntBL(string Query, int DBValue)
        {
            Int32 RetInt = 0;
            ObjMDL = new MasterDL();
            RetInt = ObjMDL.ExeQueryStrDL(Query, DBValue);
            return RetInt;
        }
        //EXECUTE SQL QUERY COMMON AND RETURN DATA TABLE VALUE
        public DataTable ExeQueryStrRetDTBL(string Query, int DBValue)
        {
            DataTable Dt = new DataTable();
            ObjMDL = new MasterDL();
            Dt = ObjMDL.ExeQueryStrRetDTDL(Query, DBValue);
            return Dt;
        }
        public DataSet ExeQueryStrRetDsBL(string Query, int DBValue)
        {
            DataSet Ds = new DataSet();
            ObjMDL = new MasterDL();
            Ds = ObjMDL.ExeQueryStrRetDsDL(Query, DBValue);
            return Ds;
        }
        //EXECUTE SQL QUERY COMMON AND RETURN STRING VALUE
        public string ExeQueryStrRetStrBL(string Query, int DBValue)
        {
            string Retstr = "";
            ObjMDL = new MasterDL();
            Retstr = ObjMDL.ExeQueryStrRetStrDL(Query, DBValue);
            return Retstr;
        }
        //EXECUTE SQL QUERY COMMON AND RETURN BOOLEAN VALUE
        public Boolean ExeQueryRetBooDL(String Query, int DBValue)
        {
            ObjMDL = new MasterDL();
            BLFlag = ObjMDL.ExeQueryRetBooDL(Query, DBValue);
            return BLFlag;
        }
        public DateTime ExeQueryStrRetDateBL(string Query, int DBValue)
        {
            DateTime RetData = DateTime.Now;
            ObjMDL = new MasterDL();
            RetData = ObjMDL.ExeQueryStrRetDateDL(Query, DBValue);
            return RetData;
        }

    }
}
