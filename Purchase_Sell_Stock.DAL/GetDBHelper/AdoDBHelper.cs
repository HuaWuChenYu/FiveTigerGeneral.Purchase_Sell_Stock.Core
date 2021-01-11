using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace Purchase_Sell_Stock.DAL.GetDBHelper
{
    public class AdoDBHelper : DBHelper
    {
        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override int ExecuteNonQuery(string sql)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql,conn);
                return cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// 增删改_存储过程
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override int ExecuteNonQuery(string procName, SqlParameter[] parameter = null)
        {
            
            using (SqlConnection conn = new SqlConnection())
            {
                conn.Open();
                //实例化命令对象
                SqlCommand cmd = new SqlCommand(procName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameter != null)
                {
                    cmd.Parameters.AddRange(parameter);
                }
                //执行命令
                cmd.Parameters.Clear();
                return cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// 返回首行首列
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override object ExecuteScalar(string sql)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.Open();
                //实例化命令对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override List<T> GetList<T>(string sql)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                List<T> list = ConvertTableToList<List<T>>(dt);
                return list;
            }
        }
        /// <summary>
        /// 查询存储过程
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procName"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override List<T> GetList<T>(string procName, SqlParameter[] parameter = null)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand(procName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameter != null)
                {
                    cmd.Parameters.AddRange(parameter);
                }
                //实例化适配器
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                List<T> list = ConvertTableToList<List<T>>(dt);
                return list;
            }
        }
        /// <summary>
        /// 将DataTable装换为List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public static T ConvertTableToList<T>(DataTable dt)
        {
            var str = JsonConvert.SerializeObject(dt);
            var list = JsonConvert.DeserializeObject<T>(str);
            return list;
        }
    }
}
