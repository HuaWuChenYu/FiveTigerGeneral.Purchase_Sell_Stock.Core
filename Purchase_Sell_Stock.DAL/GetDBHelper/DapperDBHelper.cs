using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Purchase_Sell_Stock.DAL.GetDBHelper
{
    public class DapperDBHelper : DBHelper
    {
        public override int ExecuteNonQuery(string sql)
        {
            using (IDbConnection conn=new SqlConnection(_locastr))
            {
                int n= conn.Execute(sql);
                return n;
            }
        }

        public override int ExecuteNonQuery(string procName, SqlParameter[] parameter = null)
        {
            throw new NotImplementedException();
        }

        public override object ExecuteScalar(string sql)
        {
            using(IDbConnection conn = new SqlConnection(_locastr))
            {
                return conn.ExecuteScalar(sql);
            }
            
        }

        public override List<T> GetList<T>(string sql)
        {
            using (IDbConnection conn = new SqlConnection(_locastr))
            {
                return conn.Query<T>(sql).ToList();
            }
        }

        public override List<T> GetList<T>(string procName, SqlParameter[] parameter = null)
        {
            throw new NotImplementedException();
        }
    }
}
