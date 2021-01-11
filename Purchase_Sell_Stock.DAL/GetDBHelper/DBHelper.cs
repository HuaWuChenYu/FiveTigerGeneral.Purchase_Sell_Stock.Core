using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

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
        /// 应用存储过程获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procName"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public abstract List<T> GetList<T>(string procName, SqlParameter[] parameter = null);
        /// <summary>
        /// 进行增删改
        /// </summary>
        /// <returns></returns>
        public abstract int ExecuteNonQuery(string sql);
        /// <summary>
        /// 进行存储过程的增删改
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public abstract int ExecuteNonQuery(string procName,SqlParameter[] parameter=null);
        /// <summary>
        /// 获取首行首列
        /// </summary>
        /// <returns></returns>
        public abstract object ExecuteScalar(string sql);

    }
}
