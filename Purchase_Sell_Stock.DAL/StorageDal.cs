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
            var outboundorderlist = sqlsugar.GetInstance().Queryable<Outboundorder, Orders, Warehouse, StorageType, Customer>
            ((a, b, c, d, e) => new object[] { JoinType.Inner, a.OrdersId == b.OrdersId, JoinType.Inner, a.WarehouseId == c.WarehouseId, JoinType.Inner, a.StorageTypeId == d.StorageTypeId, JoinType.Inner, b.CustomerId == e.CustomerId, })
            .Where((a, b, c, d, e) => b.OrdersState == 1)
            .Select((a, b, c, d, e) => new OutboundorderCombine
            {
                OrdersId = b.OrdersId, //订单id
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
            var _list = OutboundorderShow().FirstOrDefault(x => x.OutboundorderId == outboundorderid);
            return _list;
        }
        /// <summary>
        /// 反填商品信息
        /// </summary>
        /// <returns></returns>
        public List<OutboundorderCombine> Outboundordercommoditybackfill(int outboundorderid)//出单编号
        {
            //获取订单表中的订单编号（主键）
            var list_ordersnum = OutboundorderShow().FirstOrDefault(x => x.OutboundorderId == outboundorderid).OrdersId;
            //订单商品和商品表联查
            var list_goods = sqlsugar.GetInstance().Queryable<OrdersGoods, Goods>((a, b) => new object[] {
             JoinType.Inner,a.GoodsId==b.GoodsId
            }).Select((a, b) => new OutboundorderCombine
            {
                GoodsId = a.GoodsId,//商品编号
                GoodsName = b.GoodsName,//商品名称
                GoodsSize = b.GoodsSize,//规格
                GoodsUnitName = b.GoodsUnitName,//单位
                OrdersGoodsNum = a.OrdersGoodsNum,//总数量
                OutboundorderNumber = a.OrdersGoodsNum, //出库数量
            }).ToList();

            return list_goods;
        }

        //修改商品出库数量(对应的商品库存数量减) 
        public int GoodsAmend()
        {
            //查询出所有的库存
            //这里需要查询库存表 (库存表，商品表，库存表联查)
            sqlsugar.GetInstance().Queryable<CommodityStocks, Goods, Warehouse>((a, b, c) => new object[] {
             JoinType.Inner,a.GoodsId==b.GoodsId,JoinType.Inner,a.WarehouseId==c.WarehouseId
            }).Select((a, b, c) => new CommodityStocksandGoods
            {
                CommodityStocksId = a.CommodityStocksId,//库存id
                GoodsId = b.GoodsId, //商品编号
                Inventory = a.Inventory, //库存数量
                vendibilityInventory = a.vendibilityInventory, //可售库存数量
                WarehouseName = c.WarehouseName, //仓库名
            }).ToList();



            return 0;

        }
 

        /// <summary>
        /// 入库订单显示
        /// </summary>
        /// <returns></returns>
        public List<IncomingorderCombine> IncomingorderShow()
        {

            //入库订单    //采购订单 //仓库表
            var into_list = sqlsugar.GetInstance().Queryable<Incomingorder, Procurement, Warehouse,StorageType>
            ((a, b, c,d) => new object[] {
             JoinType.Inner,a.ProcurementId==b.ProcurementId, //入库订单与采购表关联
             JoinType.Inner,a.WarehouseName==c.WarehouseName, //仓库表与入库订单关联
              JoinType.Inner,a.StorageTypeName==d.StorageTypeName,//仓库表与类型表关联
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
        /// <summary>
        /// 入库详情信息
        /// </summary>
        /// <param name="incomingorderid"></param>
        /// <returns></returns>
        public IncomingorderCombine IncomingordermodityDetail(int incomingorderid) //入库订单Id
        {
            var _ado = IncomingorderShow().FirstOrDefault(x => x.IncomingorderId == incomingorderid);
            return _ado;
        }
        /// <summary>
        /// 反填入库商品
        /// </summary>
        /// <param name="incomingorderid"></param>
        /// <returns></returns>
        public List<IncomingorderCombine> IncomingordermodityGoods(int incomingorderid) ////入库订单Id
        {
            //通过入库订单的id查询出采购单的id 
            var _procurementid = IncomingorderShow().FirstOrDefault(x=>x.IncomingorderId==incomingorderid).ProcurementId;
            //将采购订单商品表 与 商品表关联
            var _list = sqlsugar.GetInstance().Queryable<ProcurementGoods, Goods>((a, b) => new object[] {
             JoinType.Inner,a.GoodsId==b.GoodsId
            }).Select((a, b) => new IncomingorderCombine
            {
                ProcurementGoodsId = a.ProcurementGoodsId,//采购订单表主键
                GoodsId = b.GoodsId, //商品编号
                GoodsName = b.GoodsName, //商品名称
                GoodsSize = b.GoodsSize, //规格
                GoodsUnitName = b.GoodsUnitName, //单位
                ProcurementGoodsNum = a.ProcurementGoodsNum, //总数量
                IncomingorderNumber = 0, //收货数量
            }).ToList();
            //在通过采购单的id去查询订单商品表 
            var ingood_list = _list.Where(x => x.ProcurementGoodsId == _procurementid).ToList();
            return ingood_list;
        }

    }
}
