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
        /// <summary>
        /// sql语句 执行命令返回影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override int ExecuteNonQuery(string sql)
        {
            using (IDbConnection conn = new SqlConnection(_locastr))
            {
                int n = conn.Execute(sql);
                return n;
            }
        }
        /// <summary>
        /// 通过存储过程执行sql语句返回影响行数
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override int ExecuteNonQuery(string procName, SqlParameter[] parameter = null)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// sql语句获取首行首列值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override object ExecuteScalar(string sql)
        {
            using (IDbConnection conn = new SqlConnection(_locastr))
            {
                return conn.ExecuteScalar(sql);
            }

        }
        /// <summary>
        /// sql 语句获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override List<T> GetList<T>(string sql)
        {
            using (IDbConnection conn = new SqlConnection(_locastr))
            {
                return conn.Query<T>(sql).ToList();
            }
        }
        /// <summary>
        /// 存储过程获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procName"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override List<T> GetList<T>(string procName, SqlParameter[] parameter = null)
        {
            using (IDbConnection conn = new SqlConnection(_locastr))
            {
                var obj = new
                {
                    Id = 1
                };
                foreach (SqlParameter p in parameter)
                {
                    
                }
                List<T> info = conn.Query<T>(procName, new
                {
                    
                },
     commandType: CommandType.StoredProcedure).ToList();
                return info;
            }

        }
    }
}
