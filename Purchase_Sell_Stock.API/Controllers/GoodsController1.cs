using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Purchase_Sell_Stock.DAL;
using Purchase_Sell_Stock.Model.GoodsFunction;
using Purchase_Sell_Stock.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Purchase_Sell_Stock.API.Controllers
{
    /// <summary>
    /// 商品模块
    /// </summary>
    public class GoodsController1 : ControllerBase
    {
        /// <summary>
        /// 获取商品档案
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="goodsName"></param>
        /// <param name="goodsType"></param>
        /// <param name="goodsClassify"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetGoodsList")]
        public GoodsPaging GetGoodsList<T>(int pageIndex=1, int pageSize=2, string goodsName="", string goodsType="", string goodsClassify="")
        {
            GoodsPaging goodsPaging = DalFactory.GetDal<GoodsDal>("Goods").GetGoodsList<Goods>(pageIndex, pageSize, goodsName, goodsType, goodsClassify);
            return goodsPaging;
        }
    }
}
