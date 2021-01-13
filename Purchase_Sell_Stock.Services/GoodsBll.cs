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
        //DalFactory dalFactory = new DalFactory();

        ///<summary>
        /// 商品品牌查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="brandId"></param>
        /// <param name="brandName"></param>
        /// <returns></returns>
        public List<GoodsBrand> GetGoodsBrandList(int brandId, string brandName)
        {
            return DalFactory.GetDal<GoodsDal>("Goods").GetGoodsBrandList<GoodsBrand>(brandId,brandName);


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
        public GoodsPaging GetGoodsList(int pageIndex, int pageSize,string goodsName, string goodsType, string goodsClassify)
        {
            GoodsPaging goodsPaging= DalFactory.GetDal<GoodsDal>("Goods").GetGoodsList<Goods>(pageIndex, pageSize, goodsName, goodsType, goodsClassify);
            return goodsPaging;
        }
        /// <summary>
        /// 商品分类查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeId"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public List<GoodsType> GetGoodsTypeList(int typeId, string typeName)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 商品单位查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="unitId"></param>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public List<GoodsUnit> GetGoodsUnitList(int unitId, string unitName)
        {
            throw new NotImplementedException();
        }
    }
}
