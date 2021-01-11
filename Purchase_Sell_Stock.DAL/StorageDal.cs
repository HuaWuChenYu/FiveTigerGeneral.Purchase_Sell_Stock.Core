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

namespace Purchase_Sell_Stock.DAL
{
    /// <summary>
    /// 用于仓储
    /// </summary>
    public class StorageDal
    {
        //实例化sugarhelper
        SqlSugerDBHelper sqlsugar = new SqlSugerDBHelper();
        //出库订单显示
        public List<OutboundorderCombine> OutboundorderShow()
        {
            //显示所有的入库订单
            var outboundorderlist = sqlsugar.GetInstance().Queryable<Outboundorder,Orders, Warehouse, Customer, StorageType>
            ((a, b, c, d, e) => new object[] { JoinType.Inner, a.OrdersId == b.OrdersId, JoinType.Inner, a.WarehouseId == c.WarehouseId, b.CustomerId == d.CustomerId, a.StorageTypeId == e.StorageTypeId })
            .Where((a, b, c, d, e) => b.OrdersState == 1)
            .Select((a, b, c, d, e) => new OutboundorderCombine
            {
                OutboundorderId = a.OutboundorderId,//订单id
                OutboundorderOrderNumber = a.OutboundorderOrderNumber,    //出库订单编号
                OrdersNum = b.OrdersNum,                                  //订单编号（来源单号）
                WarehouseName = c.WarehouseName,                          //仓库名称（发货方）
                CustomerName = d.CustomerName,                            //收货方名称（客户名称）
                Adress = d.Adress,                                        //收货方地址(客户地址)
                StorageTypeName = e.StorageTypeName,                      //出库类型
                OutboundorderNumber = a.OutboundorderNumber,               //商品数量
                OutboundorderState = a.OutboundorderState,                //状态
                OutboundordercreationTime = a.OutboundordercreationTime,  //创建时间
                OutboundorderTime = a.OutboundorderTime,                  //出库时间
                OutboundorderRemark = a.OutboundorderRemark,               //备注
            }).ToList();
            return outboundorderlist;

        }
        //订单商品
        public List<OutboundorderCombine> OutboundordercommodityShow()
        { //商品表  //订单表 //商品订单表
            var _list = sqlsugar.GetInstance().Queryable<Orders, OrdersGoods, Goods>((a, b, c) => new object[] {
             JoinType.Inner,b.OrdersId==a.OrdersId,
             JoinType.Inner,b.GoodsId==c.GoodsId,
            }).Select((a, b, c) => new OutboundorderCombine()
            {
                GoodsId = a.OrdersId, //商品编码
                GoodsSize = c.GoodsSize, //规格
                GoodsUnitName = c.GoodsUnitName,//单位
                OrdersGoodsNum = b.OrdersGoodsNum, //数量
            }).ToList();
            return _list;
        }
        
        //确定出库
        public int OutboundorderModify()
        {
             
            return 1;
        }


        //入库订单显示
        public List<IncomingorderCombine> IncomingorderShow()
        {
            return new List<IncomingorderCombine>();
        }
    }
}
