using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Purchase_Sell_Stock.DAL.GetDBHelper
{
    public class SqlSugerDBHelper : DBHelper
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
        /// <summary>
        /// Create SqlSugarClient
        /// </summary>
        /// <returns></returns>
        public SqlSugarClient GetInstance()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {

                ConnectionString = "Data Source=192.168.137.64;Initial Catalog=OurProject;Persist Security Info=True;User ID=sa;Password=123456",
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
            //Print sql
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
            return db;
        }
    }
}
