using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Purchase_Sell_Stock.IServices;
using Purchase_Sell_Stock.Services;
using Purchase_Sell_Stock.Model.Buyer;
using Newtonsoft.Json;

namespace Purchase_Sell_Stock.API.Controllers
{
    /// <summary>
    /// 客户控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomer _customer;
        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }
        /// <summary>
        /// 全部客户
        /// </summary>
        
        [HttpGet]
        [Route("/api/GetCustomerShow")]
        public string GetCustomerShow(int pageIndex, int pageSize, string customerName, string customerPhone, string customeridentity, int lableId, int whetherEnable,int cusId)
        {
            List<Customer> list = _customer.GetCustomerShow(customerName, customerPhone, customeridentity, lableId, whetherEnable, cusId);
            var dataJson = new
            {
                code = 0,
                msg = "",
                count = list.Count,
                data = list.Skip((pageIndex - 1) * pageSize).Take(pageSize)
            };
            string str = JsonConvert.SerializeObject(dataJson);
            return str;
        }
        /// <summary>
        /// 充值记录查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="customerName"></param>
        /// <param name="customerPhone"></param>
        /// <param name="denominationId"></param>
        /// <param name="cusId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetRechargeRecord")]
        public string GetRechargeRecord(int pageIndex,int pageSize, string customerName, string customerPhone, int denominationId ,int cusId)
        {
            List<RechargeRecord> list = _customer.GetRechargeRecord(customerName, customerPhone, denominationId, cusId);
            var dataJson = new
            {
                code = 0,
                msg = "",
                count = list.Count,
                data = list.Skip((pageIndex - 1) * pageSize).Take(pageSize)
            };
            string str = JsonConvert.SerializeObject(dataJson);
            return str;
        }
        /// <summary>
        /// 添加标签
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/GetLable")]
        public int GetLable([FromBody]Lable obj)
        {
            int i = _customer.GetLable(obj);
            return i;
        }
        /// <summary>
        /// 显示标签
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetLableShow")]
        public string GetLableShow(int pageIndex, int pageSize)
        {
            List<Lable> list = _customer.GetLableShow();
            var dataJson = new
            {
                code = 0,
                msg = "",
                count = list.Count,
                data = list.Skip((pageIndex - 1) * pageSize).Take(pageSize)
            };
            string str = JsonConvert.SerializeObject(dataJson);
            return str;
        }
        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/LableDelete")]
        public int LableDelete(string ids)
        {
            return _customer.LableDelete(ids);
        }
        /// <summary>
        /// 修改标签
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Modify")]
        public int Modify([FromBody] Lable obj)
        {
            return _customer.Modify(obj);
        }
        /// <summary>
        /// 标签反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/Ft/{id}")]
        public Lable Ft(int id)
        {
            List<Lable> lable = _customer.Ft(id);
            return lable[0];
        }
        /// <summary>
        /// 充值面额
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetListDen")]
        public string GetListDen(int pageIndex, int pageSize)
        {
            List<Denomination> list = _customer.GetListDen();
            var dataJson = new
            {
                code = 0,
                msg = "",
                count = list.Count,
                data = list.Skip((pageIndex - 1) * pageSize).Take(pageSize)
            };
            string str = JsonConvert.SerializeObject(dataJson);
            return str;
        }
        /// <summary>
        /// 新建面额
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/AddDenomination")]
        public int AddDenomination([FromBody] Denomination obj)
        {
            int i = _customer.AddDenomination(obj);
            return i;
        }
        
    }
}
