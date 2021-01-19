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
        public string GetOrderList(int orderState, string orderNum, string orderBelong, string sellType, string time, string person, string phone, string payType, string dispatchWay, int pageIndex, int pageSize, int storeId)
        {
            OrderPaging<Orders> orderPaging = _order.GetOrderList<Orders>(orderState, orderNum, orderBelong, sellType, time, person, phone, payType, dispatchWay, pageIndex, pageSize, storeId);
            var jsonData = new
            {
                code = 0,
                msg = "",
                count = orderPaging.Count,
                data = orderPaging.list
            };
            return JsonConvert.SerializeObject(jsonData);
        }
    }
}
