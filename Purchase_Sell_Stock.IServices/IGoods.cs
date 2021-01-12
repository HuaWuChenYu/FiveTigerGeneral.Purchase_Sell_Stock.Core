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
        List<T> GetGoodsList<T>(int pageIndex ,int pageSize,string goodsNum,string goodsName,string goodsType,string goodsClassify);
        /// <summary>
        /// 商品分类查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeId"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        List<T> GetGoodsTypeList<T>(int typeId, string typeName);
        /// <summary>
        /// 商品品牌查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="brandId"></param>
        /// <param name="brandName"></param>
        /// <returns></returns>
        List<T> GetGoodsBrandList<T>(int brandId, string brandName);
        /// <summary>
        /// 商品单位查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="unitId"></param>
        /// <param name="unitName"></param>
        /// <returns></returns>
        List<T> GetGoodsUnitList<T>(int unitId, string unitName);

    }
}
