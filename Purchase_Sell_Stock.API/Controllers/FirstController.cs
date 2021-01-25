using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Purchase_Sell_Stock.Model.Buyer;
using Purchase_Sell_Stock.Model.FirstFunction;
using Purchase_Sell_Stock.Model.GoodsFunction;
using Purchase_Sell_Stock.Model.Login;
using Purchase_Sell_Stock.Model.OrderFunction;
using Purchase_Sell_Stock.Model.ProcurementFunction;
using Purchase_Sell_Stock.Model.Propertys;
using Purchase_Sell_Stock.Model.Storage;
using Purchase_Sell_Stock.Model.SettingModels;
using Purchase_Sell_Stock.Services;
using Purchase_Sell_Stock.IServices;
using Newtonsoft.Json;

namespace Purchase_Sell_Stock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstController : ControllerBase
    {
        private IFirst _first;
        public FirstController(IFirst first) {
            _first = first;
        }
        [HttpGet]
        [Route("/api/GetStore/{storeId}")]
        /// <summary>
        /// 获取店铺信息
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public Store GetStore(int storeId)
        {
            Store store = _first.GetStore(storeId);
            return store;
        }
        [HttpGet]
        [Route("/api/GetHelp/{storeId}")]
        /// <summary>
        /// 获取帮助
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public string GetHelp(int storeId)
        {
            List<Helps> list = _first.GetHelp(storeId);
            var jsonData = new
            {
                code = 0,
                msg = "",
                count = list.Count,
                data = list
            };
            return JsonConvert.SerializeObject(jsonData);
        }
        [HttpGet]
        [Route("/api/GetStoreMessage/{storeId}")]
        /// <summary>
        /// 获取消息
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public string GetStoreMessage(int storeId)
        {
            List<StoreMessage> list = _first.GetStoreMessage(storeId);
            var jsonData = new
            {
                code = 0,
                msg = "",
                count = list.Count,
                data = list
            };
            return JsonConvert.SerializeObject(jsonData);
        }
        [HttpGet]
        [Route("/api/NewOrders/{storeId}/{date}")]
        /// <summary>
        /// 新增订单数
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public int NewOrders(int storeId, int date)
        {
            return _first.NewOrders(storeId, date);
        }
        [HttpGet]
        [Route("/api/orderMoney/{storeId}/{date}")]
        /// <summary>
        /// 支付金额
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public decimal orderMoney(int storeId, int date)
        {
            return _first.orderUser(storeId, date);
        }
        [HttpGet]
        [Route("/api/orderUser/{storeId}/{date}")]
        /// <summary>
        /// 下单客户数
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public int orderUser(int storeId, int date)
        {
            return _first.orderUser(storeId, date);
        }
        [HttpGet]
        [Route("/api/newUser/{storeId}/{date}")]
        /// <summary>
        /// 新增用户数
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public int newUser(int storeId, int date)
        {
            return _first.newUser(storeId, date);
        }
        [HttpGet]
        [Route("/api/activeUser/{storeId}/{date}")]
        /// <summary>
        /// 新增用户数
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public int activeUser(int storeId, int date)
        {
            return _first.activeUser(storeId, date);
        }
        [HttpGet]
        [Route("/api/Cake/{storeId}")]
        /// <summary>
        /// 饼图
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public Cake Cake(int storeId)
        {
            return _first.Cake(storeId);
        }
        [HttpGet]
        [Route("/api/SellSum/{storeId}")]
        /// <summary>
        /// 商品销售排行
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public string SellSum(int storeId)
        {
            List<Goods> list = _first.SellSum(storeId);
            return JsonConvert.SerializeObject(new { code=0,msg="",count=list.Count,data=list});
        }
        [HttpGet]
        [Route("/api/ChangeOrder/{storeId}")]
        /// <summary>
        /// 切换订单待办
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public string ChangeOrder(int storeId,int pageIndex,int pageSize)
        {
            List<Orders> list = _first.ChangeOrder(storeId);
            int a = list.Count;
            list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return JsonConvert.SerializeObject(new { code = 0, msg = "", count = a, data = list });
        }
        [HttpGet]
        [Route("/api/ChangeIncomingorder/{storeId}")]
        /// <summary>
        /// 切换入库待办
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public string ChangeIncomingorder(int storeId, int pageIndex, int pageSize)
        {
            List<Incomingorder> list = _first.ChangeIncomingorder(storeId);
            int a = list.Count;
            list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return JsonConvert.SerializeObject(new { code = 0, msg = "", count = a, data = list });
        }
        [HttpGet]
        [Route("/api/ChangeProcurement/{storeId}")]
        /// <summary>
        /// 切换采购待办
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public string ChangeProcurement(int storeId, int pageIndex, int pageSize)
        {
            List<Procurement> list = _first.ChangeProcurement(storeId);
            int a = list.Count;
            list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return JsonConvert.SerializeObject(new { code = 0, msg = "", count = a, data = list });
        }
    }
}
