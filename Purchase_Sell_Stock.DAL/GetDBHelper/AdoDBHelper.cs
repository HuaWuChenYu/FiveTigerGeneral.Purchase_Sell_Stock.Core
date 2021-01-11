using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Purchase_Sell_Stock.DAL.GetDBHelper
{
    public class AdoDBHelper : DBHelper
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
            return new List<T>();
        }

        public override List<T> GetList<T>(string procName, SqlParameter[] parameter = null)
        {
            throw new NotImplementedException();
        }
    }
}
