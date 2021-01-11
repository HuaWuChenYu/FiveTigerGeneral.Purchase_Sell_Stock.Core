using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.DAL.GetDBHelper;
using Purchase_Sell_Stock.Model.GoodsFunction;

namespace Purchase_Sell_Stock.DAL
{
    /// <summary>
    /// 商品表
    /// </summary>
    public class GoodsDal
    {
        /// <summary>
        /// 获取全部商品
        /// </summary>
        /// <returns></returns>
        public List<Goods> GetList()
        {
            string sql = "select * from Goods";
            List<Goods> list = SimplyFactoryDB.GetInstance("Dapper").GetList<Goods>(sql);
            return list;
        }
        

    }
}
