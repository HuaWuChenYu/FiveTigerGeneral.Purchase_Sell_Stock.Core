using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model.OrderFunction;
using Purchase_Sell_Stock.Model.GoodsFunction;

namespace Purchase_Sell_Stock.IServices
{
    
    public interface IOrder
    {
        /// <summary>
        /// 查询订单
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orderState"></param>
        /// <param name="orderNum"></param>
        /// <param name="orderBelong"></param>
        /// <param name="sellType"></param>
        /// <param name="time"></param>
        /// <param name="person"></param>
        /// <param name="phone"></param>
        /// <param name="payType"></param>
        /// <param name="dispatchWay"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        OrderPaging<T> GetOrderList<T>(int orderState, string orderNum,string sellType, string time, string person, string phone, string payType, int pageIndex, int pageSize, int storeId);
        /// <summary>
        /// 订单明细上
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Orders GetOrderById_1(int orderId);
        /// <summary>
        /// 订单明细下
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        List<Goods> GetOrderById_2(int orderId);
    }
}
