using Dapper;
using NetTaste;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
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
        /// 存储过程
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override int ExecuteNonQuery(string procName, DynamicParameters parameters = null)
        {
            using (IDbConnection conn = new SqlConnection(_locastr))
            {
                int row = conn.Execute(procName, parameters, null, null, CommandType.StoredProcedure);
                return row;
            }
        }
        /// <summary>
        /// 返回执行行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public override int ExecuteNonQuery(string sql, object param)
        {
            using (IDbConnection conn = new SqlConnection(_locastr))
            {
                int n = conn.Execute(sql, param);
                return n;
            }
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
        /// 返回首行首列值
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public override object ExecuteScalar(string sql, object param)
        {
            using (IDbConnection conn = new SqlConnection(_locastr))
            {
                object row = conn.ExecuteScalar(sql,param);
                return row;
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
        /// 传两个参数  进行获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public override List<T> GetList<T>(string sql, object param)
        {
            using (IDbConnection conn = new SqlConnection(_locastr))
            {
                var multiple = conn.QueryMultiple(sql, param);
                List<T> list = multiple.Read<T>().ToList();
                return list;
            }
        }
        /// <summary>
        /// 存储过程获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procName"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override List<T> GetList<T>(string procName, DynamicParameters parameters = null)
        {
            using (IDbConnection conn = new SqlConnection(_locastr))
            {
                var multiple = conn.QueryMultiple(procName, parameters, commandType: CommandType.StoredProcedure);
                List<T> list = multiple.Read<T>().ToList();
                return list;
                //======================================
                //           DynamicParameters dp = new DynamicParameters();
                //           dp.Add("@MemberId", "2019595");
                //           dp.Add("@Name", "张三");
                //           dp.Add("@Name2", "", DbType.String, ParameterDirection.Output);
                //           List<T> list= conn.Query("QueryMember", dp, commandType: CommandType.StoredProcedure).ToList();
                //           string errorMsg = dp.Get<string>("@errorMsg");
                //           int errorFlag = dp.Get<int>("@errorFlag");
                //           retrun errorMsg;
                //           //====================================
                //           dynamic dynamicModel = new DynamicModel();
                //           List<string> myList = new List<string>();
                //           List<string> myValueList = new List<string>();
                //           foreach (SqlParameter p in parameter)
                //           {
                //               myList.Add(p.ParameterName);
                //               myValueList.Add(p.Value.ToString());
                //           }
                //           for (int i = 0; i < myList.Count; i++)
                //           {
                //               string myAttr = myList[i];
                //               dynamicModel.PropertyName = myAttr;
                //               dynamicModel.Property = myValueList[i];
                //           }

                //           object obj = dynamicModel.DicProperty;
                //           //一个对象里面有很多属性和值
                //           List<T> info = conn.Query<T>(procName, (object)dynamicModel.DicProperty,
                //commandType: CommandType.StoredProcedure).ToList();
                //           return info;
                var obj = new
                {
                    Id = 1
                };
                //foreach (SqlParameter p in parameter)
                //{

                //}
                List<T> info = conn.Query<T>(procName, new
                {

                },
     commandType: CommandType.StoredProcedure).ToList();
                return info;
            }

        }
    }
}
