using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model;
using Purchase_Sell_Stock.Model.Storage;
using SqlSugar;
using Purchase_Sell_Stock.DAL.GetDBHelper;
using Purchase_Sell_Stock.Model.Buyer;
using Purchase_Sell_Stock.Model.OrderFunction;
using Purchase_Sell_Stock.Model.GoodsFunction;
using Purchase_Sell_Stock.Model.ProcurementFunction;
using System.Linq.Expressions;
using System.Linq;

namespace Purchase_Sell_Stock.DAL
{
    /// <summary>
    /// 用于仓储
    /// </summary>
    public class StorageDal
    {
        //实例化sugarhelper
        SqlSugerDBHelper sqlsugar = new SqlSugerDBHelper();
        /// <summary>
        /// 出库订单显示
        /// </summary>
        /// <returns></returns>
        //定义变量用于出库页面的数量
        //int OutNumber = 0;
        public List<OutboundorderCombine> OutboundorderShow()
        {     
            //显示所有的出库订单   
            var outboundorderlist = sqlsugar.GetInstance().Queryable<Outboundorder, Orders, Warehouse,StorageType, Customer>
            ((a, b, c, d, e) => new object[] { JoinType.Inner, a.OrdersId == b.OrdersId,JoinType.Inner, a.WarehouseId == c.WarehouseId,  JoinType.Inner, a.StorageTypeId == d.StorageTypeId, JoinType.Inner, b.CustomerId == e.CustomerId, })
            .Where((a, b, c, d, e) => b.OrdersState == 1)
            .Select((a, b, c, d, e) => new OutboundorderCombine
            {
                OutboundorderId = a.OutboundorderId,//订单id
                OutboundorderOrderNumber = a.OutboundorderOrderNumber,    //出库订单编号
                OrdersNum = b.OrdersNum,                                  //订单编号（来源单号）
                WarehouseName = c.WarehouseName,                          //仓库名称（发货方）
                CustomerName = e.CustomerName,                            //收货方名称（客户名称）
                                                                         //收货方地址(客户地址)
                StorageTypeName = d.StorageTypeName,                      //出库类型
                /*OutboundGoodsNum = OutNumber, */              //商品数量
                OutboundorderState = a.OutboundorderState,                //状态
                OutboundordercreationTime = a.OutboundordercreationTime,  //创建时间
                OutboundorderTime = a.OutboundorderTime,                  //出库时间
                OutboundorderRemark = a.OutboundorderRemark,               //备注
            }).ToList();

            return outboundorderlist;

        }
        /// <summary>
        /// 订单商品
        /// </summary>
        /// <param name="ordersnum"></param>
        /// <returns></returns>
        public List<OutboundorderCombine> OutboundordercommodityShow(string ordersnum)//ordersnum 订单编号
        { //商品表  //订单表 //商品订单表
            var _list = sqlsugar.GetInstance().Queryable<Orders, OrdersGoods, Goods>((a, b, c) => new object[] {
             JoinType.Inner,b.OrdersId==a.OrdersId,
             JoinType.Inner,b.GoodsId==c.GoodsId,
            }).Where((a, b, c) => a.OrdersState == 1 && a.OrdersNum.Contains(ordersnum)).Select((a, b, c) => new OutboundorderCombine()
            {
                GoodsId = a.OrdersId, //商品编码
                GoodsSize = c.GoodsSize, //规格
                GoodsUnitName = c.GoodsUnitName,//单位
                OrdersGoodsNum = b.OrdersGoodsNum, //数量
                OutboundorderNumber = 0            //出库数量
            }).ToList();
            return _list;
        }
        /// <summary>
        /// 反填详细信息
        /// </summary>
        /// <returns></returns>
        public OutboundorderCombine OutboundorderCombinebackfill(int outboundorderid) //出库订单id
        {
            //通过出库订单中的id来获取订单信息
            var _list= OutboundorderShow().FirstOrDefault(x=>x.OutboundorderId==outboundorderid);
            
            return _list;
        }



        /// <summary>
        /// 入库订单显示
        /// </summary>
        /// <returns></returns>
        public List<IncomingorderCombine> IncomingorderShow()
        {

            //入库订单    //采购订单 //仓库表  //退货订单\
            var into_list = sqlsugar.GetInstance().Queryable<Incomingorder, Procurement, Warehouse>
            ((a, b, c) => new object[] {
             JoinType.Inner,a.ProcurementId==b.ProcurementId, //入库订单与采购表关联
             JoinType.Inner,a.WarehouseName==c.WarehouseName,
            }).Where((a, b, c) => b.ProcurementState == 1).Select((a, b, c) => new IncomingorderCombine
            {
                IncomingorderId = a.IncomingorderId, //入库订单的主键
                IncomingorderOrderNumber = a.IncomingorderOrderNumber,  //入库单号
                ProcurementId = b.ProcurementId,//来源单号
                WarehouseName = c.WarehouseName, //收货方
                ProviderName = b.ProviderName,//发货方(采购方)
                StorageTypeName = a.StorageTypeName,//入库类型
                //IncomingorderNumber=a.IncomingorderNumber//商品总数
                IncomingorderState = a.IncomingorderState, //入库状态
                IncomingordercreationTime = a.IncomingordercreationTime,//创建时间
                IncomingorderTime = a.IncomingorderTime,//入库时间
                IncomingorderRemark = a.IncomingorderRemark//备注
            }).ToList();
            return into_list;
        }
        /// <summary>
        /// 入库订单商品
        /// </summary>
        /// <returns></returns>
        public List<IncomingorderCombine> IncomingordermodityShow(int procurementid)//采购表的id
        {
            //采购订单表 //采购订单商品表 //商品表
            var goods_list = sqlsugar.GetInstance().Queryable<Procurement, ProcurementGoods, Goods>((a, b, c) => new object[] {
             JoinType.Inner,b.ProcurementId==a.ProcurementId,
             JoinType.Inner,b.GoodsId==c.GoodsId,
            }).Where((a, b, c) => b.ProcurementId == procurementid).Select((a, b, c) => new IncomingorderCombine
            {
                GoodsId = c.GoodsId, //商品编码
                GoodsName = c.GoodsName,//商品名称
                GoodsSize = c.GoodsSize,//商品规格
                GoodsUnitName = c.GoodsUnitName,//商品单位
                ProcurementGoodsNum = b.ProcurementGoodsNum,//入库数量(商品数量)
                IncomingorderNuming = 0,//已入库数量
            }).ToList();
            return goods_list;
        }

    }
}
