using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private IProcurement _procurement;

        public ProcurementController(IProcurement procurement)
        {
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
            return _procurement.GetProvidersShow();
        }
        #endregion

    }
}
