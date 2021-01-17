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
using System.Linq;

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
        [Route("/api/OutboundorderCombinebackfill/{outboundorderid}")]
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
        [HttpGet]
        [Route("/api/Outboundordercommoditybackfill/{outboundorderid}")]
        public IActionResult Outboundordercommoditybackfill(int outboundorderid)
        {
            List<OutboundorderCombine> _list = _storage.Outboundordercommoditybackfill(outboundorderid);
            return Ok(new { code=0,msg="显示成功",count=_list.Count,data=_list });
        }
        /// <summary>
        /// 出库订单显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/OutboundorderShow")]
        public IActionResult OutboundorderShow(int? warehouseId=null,string  outboundorderOrderNumber="",string adress="",int? storagetypeId=null,
            DateTime? outboundordercreationtimeone=null, DateTime? outboundordercreationtimetwo=null)
        {
            var _list = _storage.OutboundorderShow();
            //发货方
            if (warehouseId!=null)
            {
                _list.Where(x => x.WarehouseId == warehouseId).ToList();
            }
            // 单号 
            if (!string.IsNullOrEmpty(outboundorderOrderNumber))
            {
                _list.Where(x => x.OutboundorderOrderNumber.Contains(outboundorderOrderNumber)).ToList();
            }
            //收货方
            if (!string.IsNullOrEmpty(adress))
            {
                _list.Where(x => x.Adress.Contains(adress)).ToList();
            }
            //出库类型
            if (storagetypeId!=null)
            {
                _list.Where(x => x.StorageTypeId == storagetypeId).ToList();
            }
            //创建时间
            //时间段 大于第一个时间 小于第二个时间
            if (outboundordercreationtimeone!=null&& outboundordercreationtimetwo!=null)
            {
                _list.Where(x => x.OutboundordercreationTime >= outboundordercreationtimeone && x.OutboundordercreationTime <= outboundordercreationtimetwo).ToList();
            }
            //当第一个时间有值并且第二个时间是空的 就查询与第一个时间相等的
            if (outboundordercreationtimeone!=null&& outboundordercreationtimetwo==null)
            {
                _list.Where(x => x.OutboundordercreationTime == outboundordercreationtimeone ).ToList();
            }
            //当第二个时间有值并且第一个时间是空的 就查询与第二个时间相等的
            if (outboundordercreationtimetwo != null && outboundordercreationtimeone == null)
            {
                _list.Where(x => x.OutboundordercreationTime == outboundordercreationtimetwo).ToList();
            }

            return Ok(new { code=0,msg="显示成功",count=_list.Count,data=_list });
        }
        #endregion

        #region 仓库
        /// <summary>
        /// 显示所有的仓库
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetWarehousesShow")]
        public List<Warehouse> GetWarehousesShow()
        {
            var _list = _storage.GetWarehousesShow();
            return _list;
        }
        /// <summary>
        /// 仓库类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetWarehouseTypesShow")]
        public List<WarehouseType> GetWarehouseTypesShow()
        {
            var _list = _storage.GetWarehouseTypesShow();
            return _list;
        }
        /// <summary>
        /// 出入库类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetStorageTypesShow")]
        public List<StorageType> GetStorageTypesShow()
        {
            var _list = _storage.GetStorageTypesShow();
            return _list;
        }

        #endregion
        /// <summary>
        /// 出库功能
        /// </summary>
        /// <param name="arr2"></param>
        /// <param name="arr4"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GoodsAmend/{arr2}/{arr4}/{sourcenumber}/{outboundorderId}")]
        public int GoodsAmend(string arr2, string arr4,string sourcenumber,int outboundorderId)
        {
            int i = _storage.GoodsAmend(arr2, arr4,sourcenumber, outboundorderId);
            return i;
        }
        /// <summary>
        /// 商品以及库存量的显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/commodityStocksandGoodsShow")]
        public IActionResult commodityStocksandGoodsShow()
        {
            var _list= _storage.commodityStocksandGoodsShow();
            
            return Ok(new { code=0,msg="显示成功",count=_list.Count, data=_list });
        }
        /// <summary>
        /// 商品流水
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/goodRunningWaterShow")]
        public IActionResult goodRunningWaterShow()
        {
            var _list= _storage.goodRunningWaterShow();
            return Ok(new { code = 0, msg = "显示成功", count = _list.Count, data = _list });
             
        }

    }
}
