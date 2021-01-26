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
using Microsoft.Extensions.Logging;

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
        private readonly ILogger<StorageController> _logger;
        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="storage"></param>
        public StorageController(IStorage storage,ILogger<StorageController> logger)
        {
            _storage = storage;
            _logger = logger;
        }
        #region 入库 
        /// <summary>
        /// 入库订单的显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/IncomingorderShow")]
        public IActionResult IncomingorderShow(string incomingorderOrderNumber="",string providerName="",string warehouseName="",DateTime? incomingordercreationTime=null,DateTime? incomingordercreationTimeed=null)
        {
            _logger.LogInformation("入库订单显示");
            var _list = _storage.IncomingorderShow( );
            if (!string.IsNullOrEmpty(incomingorderOrderNumber))
            {
                _list = _list.Where(x => x.IncomingorderOrderNumber.Contains(incomingorderOrderNumber)).ToList();
            }
            if (!string.IsNullOrEmpty(providerName))
            {
                _list = _list.Where(x => x.ProviderName.Contains(providerName)).ToList();
            }
            if (!string.IsNullOrEmpty(warehouseName))
            {
                _list = _list.Where(x => x.WarehouseName.Contains(warehouseName)).ToList();
            }
            if (incomingordercreationTime!=null)
            {
                _list = _list.Where(x => x.IncomingordercreationTime >= incomingordercreationTime).ToList();
            }
            if (incomingordercreationTimeed!=null)
            {
                _list = _list.Where(x => x.IncomingordercreationTime <= incomingordercreationTimeed).ToList();
            }
            if (incomingordercreationTime!=null&& incomingordercreationTimeed!=null)
            {
                _list = _list.Where(x => x.IncomingordercreationTime >= incomingordercreationTime && x.IncomingordercreationTime <= incomingordercreationTimeed).ToList();
            }
            return Ok(new { code=0,msg="显示成功",count=_list.Count,data=_list });
        }
        /// <summary>
        /// 反填入库信息
        /// </summary>
        /// <param name="incomingorderid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/IncomingordermodityDetail/{incomingorderid}")]
        public IncomingorderCombine IncomingordermodityDetail(int incomingorderid)
        {
            _logger.LogInformation("反填入库信息功能");
            var _list = _storage.IncomingordermodityDetail(incomingorderid);
            return _list;
        }
        /// <summary>
        /// 反填入库商品
        /// </summary>
        /// <param name="incomingorderid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/IncomingordermodityGoods/{incomingorderid}")]
        public IActionResult IncomingordermodityGoods(int incomingorderid)
        {
            _logger.LogInformation("反填入库商品功能");
            var _list = _storage.IncomingordermodityGoods(incomingorderid);

            return Ok(new { code=0,msg="显示成功",count=_list.Count,data=_list});
        }
        /// <summary>
        /// 确定入库
        /// </summary>
        /// <param name="arr2"></param>
        /// <param name="arr4"></param>
        /// <param name="procurementId"></param>
        /// <param name="incomingorderid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/Storage/{arr2}/{arr4}/{sourcenumber}/{incomingorderid}/{providerName}/{warehouseName}")]
        public int Storage(string arr2, string arr4, string sourcenumber, int incomingorderid, string providerName, string warehouseName)
        {
            _logger.LogInformation("确定入库功能");
            var _list = _storage.Storage(arr2, arr4, sourcenumber, incomingorderid,providerName,warehouseName);
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
            _logger.LogInformation("出库详情信息显示");
            var _list = _storage.OutboundorderCombinebackfill(outboundorderid);
            return _list;
        }
        /// <summary>
        /// 出库功能
        /// </summary>
        /// <param name="arr2"></param>
        /// <param name="arr4"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GoodsAmend/{arr2}/{arr4}/{sourcenumber}/{outboundorderId}/{warehouseName}/{customerName}")]
        public int GoodsAmend(string arr2, string arr4, string sourcenumber, int outboundorderId, string warehouseName, string customerName)
        {
            _logger.LogInformation("确定出库功能");
            int i = _storage.GoodsAmend(arr2, arr4, sourcenumber, outboundorderId, warehouseName, customerName);
            return i;
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
            _logger.LogInformation("出库商品反填");
            List<OutboundorderCombine> _list = _storage.Outboundordercommoditybackfill(outboundorderid);
            return Ok(new { code=0,msg="显示成功",count=_list.Count,data=_list });
        }
        /// <summary>
        /// 出库订单显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/OutboundorderShow")]
        public IActionResult OutboundorderShow(string warehouseName ="",string  outboundorderOrderNumber="",string adress="",string storageTypeName = "",
            DateTime? outboundordercreationtimeone=null, DateTime? outboundordercreationtimetwo=null)
        {
            _logger.LogInformation("出库订单显示");
            var _list = _storage.OutboundorderShow();
            //发货方
            if (!string.IsNullOrEmpty(warehouseName))
            {
                _list= _list.Where(x => x.WarehouseName.Contains(warehouseName)).ToList();
            }
            // 单号 
            if (!string.IsNullOrEmpty(outboundorderOrderNumber))
            {
                _list = _list.Where(x => x.OutboundorderOrderNumber.Contains(outboundorderOrderNumber)).ToList();
            }
            //收货方
            if (!string.IsNullOrEmpty(adress))
            {
                _list = _list.Where(x => x.Adress.Contains(adress)).ToList();
            }
            //出库类型
            if (!string.IsNullOrEmpty(storageTypeName))
            {
                _list = _list.Where(x => x.StorageTypeName.Contains(storageTypeName)).ToList();
            }
            //创建时间
            //时间段 大于第一个时间 小于第二个时间
            if (outboundordercreationtimeone!=null&& outboundordercreationtimetwo!=null)
            {
                _list = _list.Where(x => x.OutboundordercreationTime >= outboundordercreationtimeone && x.OutboundordercreationTime <= outboundordercreationtimetwo).ToList();
            }
            //当第一个时间有值并且第二个时间是空的 就查询与第一个时间相等的
            if (outboundordercreationtimeone!=null&& outboundordercreationtimetwo==null)
            {
                _list = _list.Where(x => x.OutboundordercreationTime == outboundordercreationtimeone ).ToList();
            }
            //当第二个时间有值并且第一个时间是空的 就查询与第二个时间相等的
            if (outboundordercreationtimetwo != null && outboundordercreationtimeone == null)
            {
                _list = _list.Where(x => x.OutboundordercreationTime == outboundordercreationtimetwo).ToList();
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
        public IActionResult GetWarehousesShow(string warehouseOrderNumber="",string warehouseName="", int? warehouseTypeId=null)
        {
            _logger.LogInformation("仓库显示功能");
            var _list = _storage.GetWarehousesShow();
            if (!string.IsNullOrEmpty(warehouseOrderNumber))
            {
                _list = _list.Where(x => x.WarehouseOrderNumber.Contains(warehouseOrderNumber)).ToList();
            }
            if (!string.IsNullOrEmpty(warehouseName))
            {
                _list = _list.Where(x => x.WarehouseName.Contains(warehouseName)).ToList();
            }
            if (warehouseTypeId!=null)
            {
                _list = _list.Where(x => x.WarehouseTypeId == warehouseTypeId).ToList();
            }

            return Ok(new { code=0,msg="显示成功",count=_list.Count,data=_list});
        }
        /// <summary>
        /// 显示所有的仓库
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetWarehousesShowed")]
        public List<Warehouse> GetWarehousesShowed()
        {
            _logger.LogInformation("仓库下拉功能");
            var _list = _storage.GetWarehousesShow();
            return _list;
        }
        /// <summary>
        /// 添加仓库
        /// </summary>
        /// <param name="ws"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/AddWarehouses")]
        public int AddWarehouses(Warehouse ws)
        {
            _logger.LogInformation("添加仓库");
            return _storage.AddWarehouses(ws);
        }
        /// <summary>
        /// 反填仓库
        /// </summary>
        /// <param name="WarehouseId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/BackfillWarehouse/{WarehouseId}")]
        public Warehouse BackfillWarehouse(int WarehouseId)
        {
            _logger.LogInformation("反填仓库");
            return _storage.BackfillWarehouse(WarehouseId);
        }
        /// <summary>
        /// 修改仓库
        /// </summary>
        /// <param name="ws"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/ModifyWarehouse")]
        public int ModifyWarehouse(Warehouse ws)
        {
            _logger.LogInformation("修改仓库");
            return _storage.ModifyWarehouse(ws);
        }

        /// <summary>
        /// 仓库类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetWarehouseTypesShow")]
        public List<WarehouseType> GetWarehouseTypesShow()
        {
            _logger.LogInformation("仓库类型功能");
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
            _logger.LogInformation("出入库类型功能");
            var _list = _storage.GetStorageTypesShow();
            return _list;
        }

        #endregion
        #region 商品流水 商品差异 商品库存
        /// <summary>
        /// 商品以及库存量的显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/commodityStocksandGoodsShow")]
        public IActionResult commodityStocksandGoodsShow(string warehouseName="",string goodsName="", int? goodsId=null)
        {
            _logger.LogInformation("商品以及库存量显示功能");
            var _list= _storage.commodityStocksandGoodsShow();
            if (!string.IsNullOrEmpty(warehouseName))  //仓库
            {
                _list = _list.Where(x => x.WarehouseName.Contains(warehouseName)).ToList();
            }
            if (!string.IsNullOrEmpty(goodsName))  //商品名称
            {
                _list = _list.Where(x => x.GoodsName.Contains(goodsName)).ToList();
            }
            if (goodsId!=null)                  //商品id
            {
                _list = _list.Where(x => x.GoodsId == goodsId).ToList();
            }
            return Ok(new { code=0,msg="显示成功",count=_list.Count, data=_list });
        }
        /// <summary>
        /// 单个商品的流水记录
        /// </summary>
        /// <param name="goodsid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/Goodsflowingwater/{goodsid}")]
        public IActionResult Goodsflowingwater(int goodsid,string warehouseName="",string goodsName="",string Source="",string sourceNumber="")
        {
            _logger.LogInformation("单个商品的流水记录");
            var _list= _storage.Goodsflowingwater(goodsid);
            //根据仓库查询
            if (!string.IsNullOrEmpty(warehouseName))
            {
                _list = _list.Where(x => x.WarehouseName.Contains(warehouseName)).ToList();
            }
            //根据商品名称
            if (!string.IsNullOrEmpty(goodsName))
            {
                _list = _list.Where(x => x.GoodsName.Contains(goodsName)).ToList();
            }
            //根据来源
            if (!string.IsNullOrEmpty(Source))
            {
                _list = _list.Where(x => x.Source.Contains(Source)).ToList();
            }
            //根据来源单号
            if (!string.IsNullOrEmpty(sourceNumber))
            {
                _list = _list.Where(x => x.SourceNumber.Contains(sourceNumber)).ToList();
            }
            return Ok(new { code = 0, msg = "显示成功", count = _list.Count, data = _list });
        }

        /// <summary>
        /// 商品流水
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/goodRunningWaterShow")]
        public IActionResult goodRunningWaterShow()
        {
            _logger.LogInformation("商品流水功能");
            var _list= _storage.goodRunningWaterShow();
            return Ok(new { code = 0, msg = "显示成功", count = _list.Count, data = _list });
             
        }
        
        /// <summary>
        /// 差异库存表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/DifferencesInventoryedShow")]
        public IActionResult DifferencesInventoryedShow(string Consigner="",string Receiving="",string DocumentType="",string DocumentNumber="",string DifferentTypesName="",string DifferencesInventoryedTime="")
        {
            _logger.LogInformation("差异库存显示");
            var _list= _storage.DifferencesInventoryedShow();
            //foreach (var item in _list)
            //{
            //   item.DifferencesInventoryedTimeed = item.DifferencesInventoryedTime.ToString("yyyy-MM-dd");
            //}
            if (!string.IsNullOrEmpty(Consigner))
            {
                _list = _list.Where(x => x.Consigner.Contains(Consigner)).ToList();
            }
            if (!string.IsNullOrEmpty(Receiving))
            {
                _list = _list.Where(x => x.Receiving.Contains(Receiving)).ToList();
            }
            if (!string.IsNullOrEmpty(DocumentType))
            {
                _list = _list.Where(x => x.DocumentType.Contains(DocumentType)).ToList();
            }
            if (!string.IsNullOrEmpty(DocumentNumber))
            {
                _list = _list.Where(x => x.DocumentNumber.Contains(DocumentNumber)).ToList();
            }
            if (!string.IsNullOrEmpty(DifferentTypesName))
            {
                _list = _list.Where(x => x.DifferentTypesName.Contains(DifferentTypesName)).ToList();
            }
            if (!string.IsNullOrEmpty(DifferencesInventoryedTime))
            { // yyyy*mm-dd

                _list = _list.Where(x =>x.DifferencesInventoryedTime.ToString("yyyy-MM-dd")==DifferencesInventoryedTime).ToList();
            }
            return Ok(new { code = 0, msg = "显示成功", count = _list.Count, data = _list });
        }

        /// <summary>
        /// 差异类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/DifferentTypesShow")]
        public List<DifferentTypes> DifferentTypesShow()
        {
            _logger.LogInformation("差异类型显示");
            var _list = _storage.DifferentTypesShow();
            return _list;
        }
        #endregion
    }
}
