using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.DAL.GetDBHelper
{
    public abstract class DBHelper
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public abstract List<T> GetList<T>();
        /// <summary>
        /// 进行增删改
        /// </summary>
        /// <returns></returns>
        public abstract int ExecuteNonQuery();
        /// <summary>
        /// 获取首行首列
        /// </summary>
        /// <returns></returns>
        public abstract object ExecuteScalar();
    }
}
