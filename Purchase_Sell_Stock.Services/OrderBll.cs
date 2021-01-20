using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.IServices;
using Purchase_Sell_Stock.DAL;
using Purchase_Sell_Stock.Model.OrderFunction;
using Purchase_Sell_Stock.Model.GoodsFunction;
namespace Purchase_Sell_Stock.Services
{
    /// <summary>
    /// 用于订单
    /// </summary>
    public class OrderBll : IOrder
    {
        OrderDal orderDal = DalFactory.GetDal<OrderDal>("Order");
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
        public OrderPaging<Orders> GetOrderList<Orders>(int orderState, string orderNum,string sellType, string time, string person, string phone, string payType , int pageIndex, int pageSize, int storeId)
        {
            return orderDal.GetOrderList<Orders>(orderState, orderNum,sellType, time, person, phone, payType, pageIndex, pageSize, storeId);
        }
        /// <summary>
        /// 订单明细上
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Orders GetOrderById_1(int orderId)
        {
            return orderDal.GetOrderById_1(orderId);
        }
        /// <summary>
        /// 订单明细下
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<Goods> GetOrderById_2(int orderId)
        {
            return orderDal.GetOrderById_2(orderId);
        }
    }
}
