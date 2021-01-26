using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purchase_Sell_Stock.IServices;
using Purchase_Sell_Stock.Model.GoodsFunction;
using Purchase_Sell_Stock.Model.ProcurementFunction;
using Purchase_Sell_Stock.Model.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Purchase_Sell_Stock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcurementController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private IProcurement _procurement;

        public ProcurementController(IProcurement procurement, ILogger<CustomerController> logger)
        {
            _logger = logger;
            _procurement = procurement;
        }

        /// <summary>
        /// 采购单显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetProcurementsShow")]
        public IActionResult GetProcurementsShow()
        {
            _logger.LogInformation("采购订单显示");
            var _list = _procurement.GetProcurementsShow();

            return Ok(new { code = 0, msg = "显示成功", count = _list.Count, data = _list });
        }
        /// <summary>
        /// 商品表显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetGoodsShow")]
        public IActionResult GetGoodsShow()
        {
            _logger.LogInformation("选择商品显示");
            var _list = _procurement.GetGoodsShow();
            return Ok(new { code = 0, msg = "显示成功", count = _list.Count, data = _list });
        }



        /// <summary>
        ///  添加
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="procuert"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/AddProcurements")]
        public int AddProcurements(Procuert procuert)
        {
            _logger.LogInformation("添加");
            return _procurement.AddProcurements( procuert);
        }
        /// <summary>
        /// 用于显示商品列表
        /// </summary>
        /// <param name="goodid"></param>
        /// <param name="procurementGoodsNum"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetGoodsbuyersShow/{goodid}")]
        public IActionResult GetGoodsbuyersShow(string goodid)
        {
            _logger.LogInformation("选中商品显示");
            var _list= _procurement.GetGoodsbuyersShow(goodid);
            if (_list!=null)
            {
                return Ok(new { code = 0, msg = "显示成功", count = _list.Count, data = _list });
            }
            else
            {
                return Ok("");
            }
        }
        /// <summary>
        /// 审核通过
        /// </summary>
        /// <param name="procurementId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/UptProviders/{procurementId}")]
        public int UptProviders(int procurementId)
        {
            _logger.LogInformation("审核通过");
            return _procurement.UptProviders(procurementId);
        }

        #region 下拉
        [HttpGet]
        [Route("/api/WarehousesShow")]
        /// <summary>
        /// 采购方(仓库)
        /// </summary>
        /// <returns></returns>
        public List<Warehouse> GetWarehousesShow()
        {
            _logger.LogInformation("采购方加载成功");
            return _procurement.GetWarehousesShow();
        }
        [HttpGet]
        [Route("/api/GetProvidersShow")]
        /// <summary>
        /// 供应商
        /// </summary>
        /// <returns></returns>
        public List<Providers> GetProvidersShow()
        {
            _logger.LogInformation("供应商加载成功");
            return _procurement.GetProvidersShow();
        }
        #endregion

    }
}
