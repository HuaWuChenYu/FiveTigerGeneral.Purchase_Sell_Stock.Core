using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Purchase_Sell_Stock.DAL.GetDBHelper
{
    public class DapperDBHelper : DBHelper
    {
        public override int ExecuteNonQuery(string sql)
        {
            throw new NotImplementedException();
        }

        public override int ExecuteNonQuery(string procName, SqlParameter[] parameter = null)
        {
            throw new NotImplementedException();
        }

        public override object ExecuteScalar(string sql)
        {
            throw new NotImplementedException();
        }

        public override List<T> GetList<T>(string sql)
        {
            throw new NotImplementedException();
        }

        public override List<T> GetList<T>(string procName, SqlParameter[] parameter = null)
        {
            throw new NotImplementedException();
        }
    }
}
