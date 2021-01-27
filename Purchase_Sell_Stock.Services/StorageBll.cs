using Purchase_Sell_Stock.IServices;
using Purchase_Sell_Stock.Model.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.DAL;
using Purchase_Sell_Stock.Model.OrderFunction;

namespace Purchase_Sell_Stock.Services
{
    /// <summary>
    /// 用于仓储
    /// </summary>
    public class StorageBll : IStorage
    {
         
        //调用dal层
        StorageDal stdal = DalFactory.GetDal<StorageDal>("Storage");

        #region 入库 
        /// <summary>
        /// 入库订单的显示
        /// </summary>
        /// <returns></returns>
        public List<IncomingorderCombine> IncomingorderShow( )
        {
            var _list = stdal.IncomingorderShow( );
            return _list;
        }
        /// <summary>
        /// 反填入库信息
        /// </summary>
        /// <param name="incomingorderid"></param>
        /// <returns></returns>
        public IncomingorderCombine IncomingordermodityDetail(int incomingorderid)
        {
            var _list = stdal.IncomingordermodityDetail(incomingorderid);
            return _list;
        }
        /// <summary>
        /// 反填入库商品
        /// </summary>
        /// <param name="incomingorderid"></param>
        /// <returns></returns>
        public List<IncomingorderCombine> IncomingordermodityGoods(int incomingorderid)
        {
            var _list = stdal.IncomingordermodityGoods(incomingorderid);
            return _list;
        }
        /// <summary>
        /// 确定入库
        /// </summary>
        /// <param name="arr2"></param>
        /// <param name="arr4"></param>
        /// <param name="procurementId"></param>
        /// <param name="incomingorderid"></param>
        /// <returns></returns>
        public int Storage(string arr2, string arr4, string sourcenumber, int incomingorderid, string providerName, string warehouseName)
        {
            return stdal.Storage(arr2, arr4, sourcenumber, incomingorderid,providerName, warehouseName);
        }

        #endregion
        #region 出库
        /// <summary>
        /// 反填详细信息
        /// </summary>
        /// <returns></returns>
        public OutboundorderCombine OutboundorderCombinebackfill(int outboundorderid)
        {
            var _list = stdal.OutboundorderCombinebackfill(outboundorderid);
            return _list;
        }

        
        /// <summary>
        /// 出库商品的反填
        /// </summary>
        /// <param name="outboundorderid"></param>
        /// <returns></returns>
        public List<OutboundorderCombine> Outboundordercommoditybackfill(int outboundorderid)
        {
            List<OutboundorderCombine> _list = stdal.Outboundordercommoditybackfill(outboundorderid);
            return _list;
        }
        /// <summary>
        /// 出库订单显示
        /// </summary>
        /// <returns></returns>
        public List<OutboundorderCombine> OutboundorderShow()
        {
            var _list= stdal.OutboundorderShow();
            return _list;
        }
       
        /// <summary>
        /// 出库功能
        /// </summary>
        /// <param name="arr2"></param>
        /// <param name="arr4"></param>
        /// <returns></returns>
        public int GoodsAmend(string  arr2, string arr4,string sourcenumber,/*string ordersgoodsnum,*/int outboundorderId, string warehouseName, string customerName)
        {
            int i= stdal.GoodsAmend(arr2, arr4,sourcenumber, outboundorderId,  warehouseName, customerName);
            return i;
        }


        #endregion
        #region 商品流水 商品差异 商品库存
        /// <summary>
        /// 商品以及库存量的显示
        /// </summary>
        /// <returns></returns>
        public List<CommodityStocksandGoods> commodityStocksandGoodsShow()
        {
            return stdal.commodityStocksandGoodsShow();
        }
        /// <summary>
        /// 单个商品的流水记录
        /// </summary>
        /// <param name="goodsid"></param>
        /// <returns></returns>
        public List<GoodRunningWater> Goodsflowingwater(int goodsid)
        {
            return stdal.Goodsflowingwater(goodsid);
        }
        /// <summary>
        /// 商品流水
        /// </summary>
        /// <returns></returns>
        public List<GoodRunningWater> goodRunningWaterShow()
        {
            return stdal.goodRunningWaterShow();
        }
        /// <summary>
        /// 差异库存表
        /// </summary>
        /// <returns></returns>
        public List<DifferencesInventoryed> DifferencesInventoryedShow()
        {
            return stdal.DifferencesInventoryedShow();
        }
        /// <summary>
        /// 差异类型
        /// </summary>
        /// <returns></returns>
        public List<DifferentTypes> DifferentTypesShow()
        {
            return stdal.DifferentTypesShow();
        }


        #endregion
        #region 仓库
        /// <summary>
        /// 所有仓库
        /// </summary>
        /// <returns></returns>
        public List<Warehouse> GetWarehousesShow()
        {
            var _list = stdal.GetWarehousesShow();
            return _list;
        }
      
        /// <summary>
        /// 仓库类型
        /// </summary>
        /// <returns></returns>
        public List<WarehouseType> GetWarehouseTypesShow()
        {
            var _list = stdal.GetWarehouseTypesShow();
            return _list;
        }
        /// <summary>
        /// 出入库类型
        /// </summary>
        /// <returns></returns>
        public List<StorageType> GetStorageTypesShow()
        {
            var _list = stdal.GetStorageTypesShow();
            return _list;
        }
        /// <summary>
        /// 添加仓库
        /// </summary>
        /// <param name="ws"></param>
        /// <returns></returns>
        public int AddWarehouses(Warehouse ws)
        {
            return stdal.AddWarehouses(ws);
        }
        /// <summary>
        /// 反填仓库
        /// </summary>
        /// <param name="WarehouseId"></param>
        /// <returns></returns>
        public Warehouse BackfillWarehouse(int WarehouseId)
        {
            return stdal.BackfillWarehouse(WarehouseId);
        }
        /// <summary>
        /// 修改仓库
        /// </summary>
        /// <param name="ws"></param>
        /// <returns></returns>
        public int ModifyWarehouse(Warehouse ws)
        {
            return stdal.ModifyWarehouse(ws);
        }

      
        #endregion

    }
}
