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
        GoodsPaging<T> GetGoodsList<T>(int pageIndex ,int pageSize,string goodsName,string goodsType,string goodsClassify,int storeId);
        /// <summary>
        /// 商品分类查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeId"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        List<GoodsType> GetGoodsTypeList(int typeId, string typeName,int storeId);
        /// <summary>
        /// 商品品牌查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="brandId"></param>
        /// <param name="brandName"></param>
        /// <returns></returns>
        List<GoodsBrand> GetGoodsBrandList(int brandId, string brandName, int storeId);
        /// <summary>
        /// 商品单位查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="unitId"></param>
        /// <param name="unitName"></param>
        /// <returns></returns>
        List<GoodsUnit> GetGoodsUnitList(int unitId, string unitName, int storeId);
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        int AddGoods(Goods goods);
        /// <summary>
        /// 添加商品品牌
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        int AddGoodsBrand(GoodsBrand goods);
        /// <summary>
        /// 添加商品分类
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        int AddGoodsType(GoodsType goods);
        /// <summary>
        /// 添加商品单位
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        int AddGoodsUnit(GoodsUnit goods);

    }
}
