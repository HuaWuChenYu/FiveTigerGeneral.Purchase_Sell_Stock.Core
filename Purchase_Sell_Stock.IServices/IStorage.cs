using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model;
using Purchase_Sell_Stock.Model.Storage;
using Purchase_Sell_Stock.Model.OrderFunction;

namespace Purchase_Sell_Stock.IServices
{
    public interface IStorage
    {
        /// <summary>
        /// 出库显示方法
        /// </summary>
        /// <returns></returns>
        List<OutboundorderCombine> OutboundorderShow();
        /// <summary>
        /// 详情信息
        /// </summary>
        /// <returns></returns>
        OutboundorderCombine OutboundorderCombinebackfill(int outboundorderid);//出库订单id
        /// <summary>
        /// 详情商品的显示
        /// </summary>
        /// <param name="outboundorderid"></param>
        /// <returns></returns>
        List<OutboundorderCombine> Outboundordercommoditybackfill(int outboundorderid);//出库订单id




        /// <summary>
        /// 入库订单显示
        /// </summary>
        /// <returns></returns>
        List<IncomingorderCombine> IncomingorderShow( );
        /// <summary>
        /// 反填入库订单信息
        /// </summary>
        /// <returns></returns>
        IncomingorderCombine IncomingordermodityDetail(int incomingorderid);
        /// <summary>
        /// 反填入库订单商品
        /// </summary>
        /// <param name="incomingorderid"></param>
        /// <returns></returns>
        List<IncomingorderCombine> IncomingordermodityGoods(int incomingorderid);
        /// <summary>
        /// 确定入库
        /// </summary>
        /// <param name="arr2"></param>
        /// <param name="arr4"></param>
        /// <param name="procurementId"></param>
        /// <param name="outboundorderId"></param>
        /// <returns></returns>
        int Storage(string arr2, string arr4, string sourcenumber, int incomingorderid);


        /// <summary>
        /// 显示所有的仓库
        /// </summary>
        /// <returns></returns>
        List<Warehouse> GetWarehousesShow();
        /// <summary>
        /// 显示仓库类型
        /// </summary>
        /// <returns></returns>
        List<WarehouseType> GetWarehouseTypesShow();
        /// <summary>
        /// 出入库类型
        /// </summary>
        /// <returns></returns>
        List<StorageType> GetStorageTypesShow();
        /// <summary>
        /// 出库功能
        /// </summary>
        /// <param name="arr2"></param>
        /// <param name="arr4"></param>
        /// <returns></returns>
        int GoodsAmend(string arr2, string arr4, string sourcenumber, /*string ordersgoodsnum,*/ int outboundorderId);

        /// <summary>
        /// 商品 及商品的库存
        /// </summary>
        /// <returns></returns>
        List<CommodityStocksandGoods> commodityStocksandGoodsShow();
        /// <summary>
        /// 流水记录表
        /// </summary>
        /// <returns></returns>
        List<GoodRunningWater> goodRunningWaterShow();

    }
}
