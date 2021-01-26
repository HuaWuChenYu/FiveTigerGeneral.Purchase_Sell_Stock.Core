using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model.Buyer;
using Purchase_Sell_Stock.Model.FirstFunction;
using Purchase_Sell_Stock.Model.GoodsFunction;
using Purchase_Sell_Stock.Model.Login;
using Purchase_Sell_Stock.Model.OrderFunction;
using Purchase_Sell_Stock.Model.ProcurementFunction;
using Purchase_Sell_Stock.Model.Propertys;
using Purchase_Sell_Stock.Model.Storage;
using Purchase_Sell_Stock.Model.SettingModels;
using Purchase_Sell_Stock.DAL.GetDBHelper;

namespace Purchase_Sell_Stock.DAL
{
    public class FirstDal
    {
        DBHelper dapper = SimplyFactoryDB.GetInstance("Dapper");
        /// <summary>
        /// 获取店铺信息
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public Store GetStore(int storeId)
        {
            string str = "select * from Store where StoreId = @storeId";
            Store store = dapper.GetList<Store>(str, new { storeId })[0];
            return store;
        }
        /// <summary>
        /// 获取帮助
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public List<Helps> GetHelp(int storeId)
        {
            string str = "select top 3 * from Helps where StoreId = @storeId";
            List<Helps> helps = dapper.GetList<Helps>(str, new { storeId });
            return helps;
        }
        /// <summary>
        /// 获取消息
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public List<StoreMessage> GetStoreMessage(int storeId)
        {
            string str = "select top 3 * from StoreMessage where StoreId = @storeId";
            List<StoreMessage> messages = dapper.GetList<StoreMessage>(str, new { storeId });
            return messages;
        }
        /// <summary>
        /// 新增订单数
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public int NewOrders(int storeId, int date)
        {
            string str = "select count(*) from Orders where StoreId = @storeId and DATEDIFF(DAY,OrdersTime,getdate()) <= @date";
            int i = Convert.ToInt32(dapper.ExecuteScalar(str, new { storeId, date }));
            return i;
        }
        /// <summary>
        /// 支付金额
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public decimal orderMoney(int storeId, int date)
        {
            string str = "select sum(PayMoney) from Orders where StoreId = @storeId and DATEDIFF(DAY,OrdersTime,getdate()) <= @date";
            if (dapper.ExecuteScalar(str, new { storeId, date }) == null)
            {
                return 0;
            }
            decimal i = Convert.ToInt32(dapper.ExecuteScalar(str, new { storeId, date }));
            return i;
        }
        /// <summary>
        /// 下单客户数
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public int orderUser(int storeId, int date)
        {
            string str = "select count(distinct CustomerName) from Orders od join Customer ct on od.CustomerId = ct.CustomerId where od.StoreId = @storeId and DATEDIFF(DAY,OrdersTime,getdate()) <= @date";
            int i = Convert.ToInt32(dapper.ExecuteScalar(str, new { storeId, date }));
            return i;
        }
        /// <summary>
        /// 新增用户数
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public int newUser(int storeId, int date)
        {
            string str = "select count(distinct CustomerName) from Orders od join Customer cu on cu.CustomerId = od.CustomerId where od.StoreId = @storeId and DATEDIFF(DAY,OrdersTime,getdate()) <= @date and CustomerName in" +
            "(select CustomerName from Orders od join Customer cu on cu.CustomerId = od.CustomerId group by CustomerName having count(*) = 1)";
            int i = Convert.ToInt32(dapper.ExecuteScalar(str, new { storeId, date }));
            return i;
        }
        /// <summary>
        /// 新增用户数
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public int activeUser(int storeId, int date)
        {
            string str = "select count(distinct CustomerName) from Orders od join Customer cu on cu.CustomerId = od.CustomerId where od.StoreId = @storeId and DATEDIFF(DAY,OrdersTime,getdate()) <= @date and CustomerName in" +
            "(select CustomerName from Orders od join Customer cu on cu.CustomerId = od.CustomerId group by CustomerName having count(*) >= 3)";
            int i = Convert.ToInt32(dapper.ExecuteScalar(str, new { storeId, date }));
            return i;
        }
        /// <summary>
        /// 饼图数据
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public Cake Cake(int storeId)
        {
            Cake cake = new Cake();
            //待发货订单
            string orderSql = "select count(*) from Orders where StoreId = @storeId and OrdersState = 2";
            int _order = Convert.ToInt32(dapper.ExecuteScalar(orderSql, new { storeId }));
            //待审核退款订单
            string cancelOrderSql = "select count(*) from CancelOrder co join Orders od on co.OrdersId = od.OrdersId where StoreId = @storeId and CancelOrderState = 1";
            int _cancelOrder = Convert.ToInt32(dapper.ExecuteScalar(cancelOrderSql, new { storeId }));
            //待审核出库订单
            string outSql = "select count(*) from Outboundorder ob join Orders od on od.OrdersId = ob.OrdersId where StoreId = @storeId and OutboundorderState = 1";
            int _out = Convert.ToInt32(dapper.ExecuteScalar(outSql, new { storeId }));
            //待审核入库订单
            string goSql = "select count(*) from Incomingorder im join Procurement po on po.ProcurementId = im.ProcurementId where StoreId = @storeId and IncomingorderState = 1";
            int _go = Convert.ToInt32(dapper.ExecuteScalar(goSql, new { storeId }));
            //待审核采购退货单
            string _cancelBuySql = "select count(*) from CancleProcurement where StoreId = @storeId and CancleProcurementState = 0";
            int _cancelBuy = Convert.ToInt32(dapper.ExecuteScalar(_cancelBuySql, new { storeId }));
            //待审核采购订单
            string buySql = "select count(*) from Procurement where StoreId = @storeId and ProcurementState = 0";
            int _buy = Convert.ToInt32(dapper.ExecuteScalar(buySql, new { storeId }));
            cake.BuyCount = _buy;
            cake.CancelBuyCount = _cancelBuy;
            cake.GoCount = _go;
            cake.CancelOrder = _cancelOrder;
            cake.OutCount = _out;
            cake.OrderCount = _order;
            return cake;
        }
        /// <summary>
        /// 商品销售排行
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public List<Goods> SellSum(int storeId)
        {
            string sql = "select top 10 ROW_NUMBER() over(order by GoodsName) Num,GoodsName,sum(OrdersGoodsNum) GoodsSum from OrdersGoods og join Orders od on og.OrdersId = od.OrdersId join Goods gd on gd.GoodsId = og.GoodsId" +
                " group by GoodsName,od.StoreId having od.StoreId = @storeId order by sum(OrdersGoodsNum) desc";
            List<Goods> list = dapper.GetList<Goods>(sql, new { storeId });
            return list;
        }
        /// <summary>
        /// 切换订单待办
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public List<Orders> ChangeOrder(int storeId)
        {
            string str = "select * from Orders where OrdersState = 2 and StoreId = @storeId";
            List<Orders> list = dapper.GetList<Orders>(str,new { storeId});
            return list;
        }
        /// <summary>
        /// 切换入库待办
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public List<Incomingorder> ChangeIncomingorder(int storeId)
        {
            string str = "select * from Incomingorder ig join Procurement pm on pm.ProcurementId = ig.ProcurementId where StoreId = @storeId";
            List<Incomingorder> list = dapper.GetList<Incomingorder>(str, new { storeId });
            return list;
        }
        /// <summary>
        /// 切换采购待办
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public List<Procurement> ChangeProcurement(int storeId)
        {
            string str = "select * from Procurement where StoreId = @storeId";
            List<Procurement> list = dapper.GetList<Procurement>(str, new { storeId });
            return list;
        }
    }
}
