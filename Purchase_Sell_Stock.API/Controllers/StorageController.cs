using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Purchase_Sell_Stock.IServices;
using Purchase_Sell_Stock.Services;
using Purchase_Sell_Stock.Model.OrderFunction;
using Purchase_Sell_Stock.Model.Storage;

namespace Purchase_Sell_Stock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        IStorage _istorage;
        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="storage"></param>
        public StorageController(IStorage storage)
        {
            _istorage = storage;
        }
        /// <summary>
        /// 出库订单的显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/OutboundorderShow")]
        public List<OutboundorderCombine> OutboundorderShow()
        {
            List<OutboundorderCombine> _outlist = _istorage.OutboundorderShow();
            return _outlist;
        }
    }
}
