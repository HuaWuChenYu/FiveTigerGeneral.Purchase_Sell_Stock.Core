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

namespace Purchase_Sell_Stock.IServices
{
    public interface IFirst
    {
        /// <summary>
        /// 获取店铺信息
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        Store GetStore(int storeId);
        /// <summary>
        /// 获取帮助
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        List<Helps> GetHelp(int storeId);
        /// <summary>
        /// 获取消息
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        List<StoreMessage> GetStoreMessage(int storeId);
        /// <summary>
        /// 新增订单数
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        int NewOrders(int storeId, int date);
        /// <summary>
        /// 支付金额
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        decimal orderMoney(int storeId, int date);
        /// <summary>
        /// 下单用户数
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        int orderUser(int storeId,int date);
        /// <summary>
        /// 新增用户数
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        int newUser(int storeId,int date);
        /// <summary>
        /// 活跃用户数
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        int activeUser(int storeId, int date);
        /// <summary>
        /// 饼图数据
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        Cake Cake(int storeId);
        /// <summary>
        /// 商品销售排行
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        List<Goods> SellSum(int storeId);
        /// <summary>
        /// 切换订单待办
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        List<Orders> ChangeOrder(int storeId);
        /// <summary>
        /// 切换入库待办
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        List<Incomingorder> ChangeIncomingorder(int storeId);
        /// <summary>
        /// 切换采购待办
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        List<Procurement> ChangeProcurement(int storeId);
    }
}
