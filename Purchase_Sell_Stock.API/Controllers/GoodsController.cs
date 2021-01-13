using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Purchase_Sell_Stock.Model.GoodsFunction;
using Purchase_Sell_Stock.Services;
using Purchase_Sell_Stock.IServices;


namespace Purchase_Sell_Stock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private IGoods _goods1;
        public GoodsController(IGoods goods)
        {
            _goods1 = goods;
        }
        [HttpGet]
        [Route("/api/GetGoodsList")]
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
        public GoodsPaging GetGoodsList(int pageIndex, int pageSize, string goodsName, string goodsType, string goodsClassify)
        {
            GoodsPaging goodsPaging = _goods1.GetGoodsList(1, 2, "", "", "");
            return goodsPaging;
        }
    }
}
