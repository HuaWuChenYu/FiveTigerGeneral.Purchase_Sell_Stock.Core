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
        string connStr = "Data Source=192.168.137.64;Initial Catalog=OurProject;User ID=sa;Password=123456";
        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override int ExecuteNonQuery(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
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

            using (SqlConnection conn = new SqlConnection(connStr))
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
            using (SqlConnection conn = new SqlConnection(connStr))
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
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                List<T> list = ConvertTableToList<T>(dt);
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
            using (SqlConnection conn = new SqlConnection(connStr))
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
                List<T> list = ConvertTableToList<T>(dt);
                return list;
            }
        }
        /// <summary>
        /// 将DataTable装换为List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        private List<T> ConvertTableToList<T>(DataTable dt)
        {
            var props = typeof(T).GetProperties();
            //实例化泛型集合
            List<T> list = new List<T>();
            //循环数据表中的数据
            foreach (DataRow item in dt.Rows)
            {
                //泛型对象实例化必须要加引用类型的约束
                T t = (T)Activator.CreateInstance(typeof(T));
                //循环属性 
                foreach (var prop in props)
                {
                    //判断属性与数据表中的列名是否一致
                    if (dt.Columns.Contains(prop.Name))
                    {
                        //取值 赋给t对象          通过属性名去查询列名
                        prop.SetValue(t, item[prop.Name]);
                    }
                }
                //添加
                list.Add(t);
            }
            return list;
        }
    }
}
