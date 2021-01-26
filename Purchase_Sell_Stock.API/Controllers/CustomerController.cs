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
using Microsoft.Extensions.Logging;

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
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(ICustomer customer,ILogger<CustomerController> logger)
        {
            _customer = customer;
            _logger = logger;
        }
        /// <summary>
        /// 全部客户
        /// </summary>
        
        [HttpGet]
        [Route("/api/GetCustomerShow")]
        public string GetCustomerShow(int pageIndex, int pageSize, string customerName, string customerPhone, string customeridentity, int lableId, int whetherEnable)
        {
            _logger.LogInformation("显示全部客户");
            List<Customer> list = _customer.GetCustomerShow(customerName, customerPhone, customeridentity, lableId, whetherEnable);
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
        public string GetRechargeRecord(int pageIndex,int pageSize, string customerName, string customerPhone, int denominationId )
        {
            _logger.LogInformation("充值记录查询");
            List<RechargCustomer> list = _customer.GetRechargeRecord(customerName, customerPhone, denominationId);
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
            _logger.LogInformation("添加标签");
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
            _logger.LogInformation("显示标签");
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
            _logger.LogInformation("删除标签");
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
            _logger.LogInformation("修改标签");
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
            _logger.LogInformation("反填标签");
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
            _logger.LogInformation("充值面额");
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
            _logger.LogInformation("新建面额");
            int i = _customer.AddDenomination(obj);
            return i;
        }
        /// <summary>
        /// 钱包查询
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("/api/GetWallet")]
        public string GetWallet(int pageIndex, int pageSize, string customerName, string customerPhone)
        {
            _logger.LogInformation("钱包查询显示");
            List<wallet> list = _customer.GetWallet(customerName, customerPhone);
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
        /// 流水表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("/api/GetWater")]
        public string GetWater(int pageIndex, int pageSize)
        {
            _logger.LogInformation("流水显示");
            List<Water> list = _customer.GetWater();
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
        /// 流水反填
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/LSFt/{ids}")]
        public Water LSFt(int ids)
        {
            _logger.LogInformation("流水反填功能");
            List<Water> lable = _customer.LSFt(ids);
            return lable[0];
        }
    }
}
