using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Purchase_Sell_Stock.Model;
using Purchase_Sell_Stock.Model.Storage;
using Purchase_Sell_Stock.Services;
using Purchase_Sell_Stock.IServices;

namespace Purchase_Sell_Stock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        /// <summary>
        /// 定义一个接口
        /// </summary>
        IStorage _storage;
        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="storage"></param>
        public StorageController(IStorage storage)
        {
            _storage = storage;
        }
        #region 入库 
        /// <summary>
        /// 入库订单的显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/IncomingorderShow")]
        public List<IncomingorderCombine> IncomingorderShow()
        {
            var _list = _storage.IncomingorderShow();
            return _list;
        }
        /// <summary>
        /// 反填入库信息
        /// </summary>
        /// <param name="incomingorderid"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/IncomingordermodityDetail")]
        public IncomingorderCombine IncomingordermodityDetail(int incomingorderid)
        {
            var _list = _storage.IncomingordermodityDetail(incomingorderid);
            return _list;
        }
        /// <summary>
        /// 反填入库商品
        /// </summary>
        /// <param name="incomingorderid"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/IncomingordermodityGoods")]
        public List<IncomingorderCombine> IncomingordermodityGoods(int incomingorderid)
        {
            var _list = _storage.IncomingordermodityGoods(incomingorderid);
            return _list;
        }

        #endregion


        #region 出库
        /// <summary>
        /// 反填详细信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/OutboundorderCombinebackfill")]
        public OutboundorderCombine OutboundorderCombinebackfill(int outboundorderid)
        {
            var _list = _storage.OutboundorderCombinebackfill(outboundorderid);
            return _list;
        }


        /// <summary>
        /// 出库商品的反填
        /// </summary>
        /// <param name="outboundorderid"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Outboundordercommoditybackfill")]
        public List<OutboundorderCombine> Outboundordercommoditybackfill(int outboundorderid)
        {
            List<OutboundorderCombine> _list = _storage.Outboundordercommoditybackfill(outboundorderid);
            return _list;
        }
        /// <summary>
        /// 出库订单显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/OutboundorderShow")]
        public List<OutboundorderCombine> OutboundorderShow()
        {
            var _list = _storage.OutboundorderShow();
            return _list;
        }
        #endregion


    }
}
