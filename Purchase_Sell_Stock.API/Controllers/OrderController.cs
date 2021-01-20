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
    }
}
