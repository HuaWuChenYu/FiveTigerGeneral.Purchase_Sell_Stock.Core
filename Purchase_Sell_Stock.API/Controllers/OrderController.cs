using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Purchase_Sell_Stock.Model.OrderFunction;
using Purchase_Sell_Stock.Services;
using Purchase_Sell_Stock.IServices;
using Newtonsoft.Json;
using Purchase_Sell_Stock.Model.GoodsFunction;
using Microsoft.AspNetCore.Authorization;

namespace Purchase_Sell_Stock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class OrderController : ControllerBase
    {
        private IOrder _order;
        public OrderController(IOrder order)
        {
            _order = order;
        }

        [HttpGet]
        [Route("/api/GetOrderList/{storeId}")]
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
        public string GetOrderList(int orderState, string orderNum, string sellType, string time, string person, string phone, string payType, int pageIndex, int pageSize, int storeId)
        {
            OrderPaging<Orders> orderPaging = _order.GetOrderList<Orders>(orderState, orderNum, sellType, time, person, phone, payType, pageIndex, pageSize, storeId);
            var jsonData = new
            {
                code = 0,
                msg = "",
                count = orderPaging.Count,
                data = orderPaging.list
            };
            return JsonConvert.SerializeObject(jsonData);
        }
        [HttpGet]
        [Route("/api/GetOrderById_1/{orderId}")]
        /// <summary>
        /// 订单明细上
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Orders GetOrderById_1(int orderId)
        {
            return _order.GetOrderById_1(orderId);
        }
        [HttpGet]
        [Route("/api/GetOrderById_2/{orderId}")]
        /// <summary>
        /// 订单明细下
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public string GetOrderById_2(int orderId)
        {
            List<Goods> list = _order.GetOrderById_2(orderId);
            var dataJson = new
            {
                code = 0,
                msg = "",
                count = list.Count,
                data = list
            };
            return JsonConvert.SerializeObject(dataJson);
        }
        [HttpPost]
        [Route("/api/ModifyOrderState/{orderId}")]
        /// <summary>
        /// 订单发货
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public int ModifyOrderState(int orderId)
        {
            return _order.ModifyOrderState(orderId);
        }


        //========================================================//
        [HttpGet]
        [Route("/api/CancelOrderList/{storeId}")]
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
        public string CancelOrderList(string CancelOrderNumber, string OrdersNum, int goState, int cancelState, string time, int storeId, int pageIndex, int pageSize)
        {
            OrderPaging<CancelOrder> cancelOrderPaging= _order.CancelOrderList<CancelOrder>(CancelOrderNumber, OrdersNum, goState, cancelState, time, storeId, pageIndex, pageSize);
            var jsonData = new
            {
                code = 0,
                msg = "",
                count = cancelOrderPaging.Count,
                data = cancelOrderPaging.list
            };
            return JsonConvert.SerializeObject(jsonData);
        }
        [HttpGet]
        [Route("/api/GetCancelOneById/{orderId}")]
        /// <summary>
        /// 退单明细
        /// </summary>
        /// <param name="cancelOrderId"></param>
        /// <returns></returns>
        public CancelOrderOneViewModel GetCancelOneById(int orderId)
        {
            CancelOrderOneViewModel obj= _order.GetCancelOneById(orderId);
            return obj;
        }
        [HttpPost]
        [Route("/api/ModifyCancelState/{orderId}")]
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public int ModifyCancelState(int orderId)
        {
            return _order.ModifyCancelState(orderId);
        }
        [HttpGet]
        [Route("/api/CancelCommentList/{storeId}")]
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
        public string CancelCommentList(string content, string person, string time, string type, int storeId, int pageIndex, int pageSize)
        {
            OrderPaging<Comment> comment = _order.CommentList<Comment>(content, person, time, type, storeId, pageIndex, pageSize);
            var jsonData = new
            {
                code = 0,
                msg = "",
                count = comment.Count,
                data = comment.list
            };
            return JsonConvert.SerializeObject(jsonData);
        }
        [HttpPost]
        [Route("/api/ReplyComment")]
        /// <summary>
        /// 回复评价
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public int ReplyComment(Comment comment)
        {
            return _order.ReplyComment(comment.CommentId, comment.CommentContent);
        }
    }
}
