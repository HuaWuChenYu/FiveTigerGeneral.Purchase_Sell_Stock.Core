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
        OrderPaging<T> GetOrderList<T>(int orderState, string orderNum, string sellType, string time, string person, string phone, string payType, int pageIndex, int pageSize, int storeId);
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
        /// <summary>
        /// 订单发货
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        int ModifyOrderState(int orderId);

        //--------------------------------------------------------------------------------//

        /// <summary>
        /// 查询退单
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cancelOrderId"></param>
        /// <param name="PayMoney"></param>
        /// <param name="goState"></param>
        /// <param name="cancelState"></param>
        /// <returns></returns>
        OrderPaging<T> CancelOrderList<T>(string cancelOrderNumber, string ordersNum, int goState, int cancelState, string time, int storeId, int pageIndex, int pageSize);
        /// <summary>
        /// 退单明细
        /// </summary>
        /// <param name="cancelOrderId"></param>
        /// <returns></returns>
        CancelOrderOneViewModel GetCancelOneById(int cancelOrderId);
        /// <summary>
        /// 修改退款状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        int ModifyCancelState(int orderId);

        //======================================================================//
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
        OrderPaging<Comment> CommentList<Comment>(string content, string person, string time, string type, int storeId, int pageIndex, int pageSize);
        /// <summary>
        /// 回复评价
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        int ReplyComment(int commentId,string content);
    }
}
