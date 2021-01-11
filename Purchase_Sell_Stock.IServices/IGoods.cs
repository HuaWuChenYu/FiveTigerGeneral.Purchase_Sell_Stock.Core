using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model.GoodsFunction;

namespace Purchase_Sell_Stock.IServices
{
    public interface IGoods
    {
        /// <summary>
        /// 商品档案查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="goodsNum"></param>
        /// <param name="goodsName"></param>
        /// <param name="goodsType"></param>
        /// <param name="goodsClassify"></param>
        /// <returns></returns>
        List<T> GetGoodsList<T>(string goodsNum,string goodsName,string goodsType,string goodsClassify);
        List<T> GetGoodsTypeList<T>(string typeId, string typeName);
    }
}
