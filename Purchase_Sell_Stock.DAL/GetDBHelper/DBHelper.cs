using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using NetTaste;

namespace Purchase_Sell_Stock.DAL.GetDBHelper
{
    public abstract class DBHelper
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string _locastr = null;
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public abstract List<T> GetList<T>(string sql);
        /// <summary>
        /// 进行增删改
        /// </summary>
        /// <returns></returns>
        public abstract int ExecuteNonQuery(string sql);
        /// <summary>
        /// Dapper 获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public virtual List<T> GetList<T>(string sql, object param)
        {
            return new List<T>();
        }
        /// <summary>
        /// Dapper  影响的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public virtual int ExecuteNonQuery(string sql, object param)
        {
            return default;
        }
        /// <summary>
        /// ADO专用 进行存储过程的增删改
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public virtual int ExecuteNonQuery(string procName, SqlParameter[] parameter = null)
        {
            return default;
        }
        /// <summary>
        /// Dapper专用 进行存储过程的增删改
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public virtual int ExecuteNonQuery(string procName, DynamicParameters parameters = null)
        {
            return default;
        }
        /// <summary>
        /// 获取首行首列
        /// </summary>
        /// <returns></returns>
        public abstract object ExecuteScalar(string sql);
        /// <summary>
        /// Dapper  返回首行首列的值
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public virtual object ExecuteScalar(string sql, object param)
        {
            return new object();
        }
        /// <summary>
        /// Dapper专用存储过程
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual List<T> GetList<T>(string procName, DynamicParameters parameters = null)
        {
            return new List<T>();
        }
        /// <summary>
        /// ADO专用 应用存储过程获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procName"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public virtual List<T> GetList<T>(string procName, SqlParameter[] parameter = null)
        {
            return new List<T>();
        }
    }
}
