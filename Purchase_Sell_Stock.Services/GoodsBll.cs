using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.DAL;
using Purchase_Sell_Stock.Model.GoodsFunction;
using Purchase_Sell_Stock.IServices;

namespace Purchase_Sell_Stock.Services
{
    public class GoodsBll : IGoods
    {
        GoodsDal goods1 = DalFactory.GetDal<GoodsDal>("Goods");

        ///<summary>
        /// 商品品牌查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="brandId"></param>
        /// <param name="brandName"></param>
        /// <returns></returns>
        public List<GoodsBrand> GetGoodsBrandList(int brandId, string brandName,int storeId)
        {
            return goods1.GetGoodsBrandList<GoodsBrand>(brandId,brandName, storeId);
        }
        /// <summary>
        /// 商品档案查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="goodsNum"></param>
        /// <param name="goodsName"></param>
        /// <param name="goodsType"></param>
        /// <param name="goodsClassify"></param>
        /// <returns></returns>
        public GoodsPaging<Goods> GetGoodsList<Goods>(int pageIndex, int pageSize,string goodsName, string goodsType, string goodsClassify, int storeId)
        {
            GoodsPaging<Goods> goodsPaging = goods1.GetGoodsList<Goods>(pageIndex, pageSize, goodsName, goodsType, goodsClassify,storeId);
            return goodsPaging;
        }
        /// <summary>
        /// 商品分类查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeId"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public List<GoodsType> GetGoodsTypeList(int typeId, string typeName,int storeId)
        {
            return goods1.GetGoodsTypeList<GoodsType>(typeId,typeName, storeId);
        }
        /// <summary>
        /// 商品单位查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="unitId"></param>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public List<GoodsUnit> GetGoodsUnitList(int unitId, string unitName, int storeId)
        {
            return goods1.GetGoodsUnitList<GoodsUnit>(unitId, unitName, storeId);
        }
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public int AddGoods(Goods goods)
        {
            return goods1.AddGoods(goods);
        }
        /// <summary>
        /// 添加商品分类
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns> v  
        public int AddGoodsType(GoodsType goods)
        {
            return goods1.AddGoodsType(goods);
        }
        /// <summary>
        /// 添加商品品牌
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns> v  
        public int AddGoodsBrand(GoodsBrand goods)
        {
            return goods1.AddGoodsBrand(goods);
        }
        /// <summary>
        /// 添加商品单位
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns> v  
        public int AddGoodsUnit(GoodsUnit goods)
        {
            return goods1.AddGoodsUnit(goods);
        }
        /// <summary>
        /// 修改上下架
        /// </summary>
        /// <param name="goodId"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public int ModifyState(int goodId)
        {
            return goods1.ModifyState(goodId);
        }
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="goodsIds"></param>
        /// <returns></returns>
        public int DeleteGoods(string goodIds)
        {
            return goods1.DeleteGoods(goodIds);
        }
        /// <summary>
        /// 根据Id查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Goods> GetGoodsById(int goodsId)
        {
            return goods1.GetGoodsById(goodsId);
        }
        /// <summary>
        /// 修改商品单位
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public int ModifyGoods(Goods goods)
        {
            int i = goods1.ModifyGoods(goods);
            return i;
        }
    }
}
