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
        /// <summary>
        /// 订单发货
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public int ModifyOrderState(int orderId)
        {
            return orderDal.ModifyOrderState(orderId);
        }

        //=====================================================================//
        /// <summary>
        /// 查询退单
        /// </summary>
        /// <typeparam name="CancelOrder"></typeparam>
        /// <param name="CancelOrderNumber"></param>
        /// <param name="OrdersNum"></param>
        /// <param name="goState"></param>
        /// <param name="cancelState"></param>
        /// <param name="time"></param>
        /// <param name="storeId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public OrderPaging<CancelOrder> CancelOrderList<CancelOrder>(string CancelOrderNumber, string OrdersNum, int goState, int cancelState,string time, int storeId, int pageIndex, int pageSize)
        {
            return orderDal.CancelOrderList<CancelOrder>(CancelOrderNumber, OrdersNum, goState, cancelState, time, storeId, pageIndex,pageSize);
        }
        /// <summary>
        /// 退单明细
        /// </summary>
        /// <param name="cancelOrderId"></param>
        /// <returns></returns>
        public CancelOrderOneViewModel GetCancelOneById(int orderId)
        {
            return orderDal.GetCancelOneById(orderId);
        }
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public int ModifyCancelState(int orderId)
        {
            return orderDal.ModifyCancelState(orderId);
        }
        /// <summary>
        /// 查询评价
        /// </summary>
        /// <typeparam name="Comment"></typeparam>
        /// <param name="content"></param>
        /// <param name="person"></param>
        /// <param name="time"></param>
        /// <param name="type"></param>
        /// <param name="storeId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public OrderPaging<Comment> CommentList<Comment>(string content, string person, string time, string type, int storeId, int pageIndex, int pageSize)
        {
            return orderDal.CommentList<Comment>(content, person, time, type, storeId, pageIndex, pageSize);
        }
        /// <summary>
        /// 回复评价
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public int ReplyComment(int commentId, string content)
        {
            return orderDal.ReplyComment(commentId, content);
        }
    }
}
