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
        /// 实例化
        /// </summary>
        CustomerBll bll = new CustomerBll();
        [HttpGet]
        [Route("api/GetCustomers/{pageIndex}/{pageSize}/{customerName}/{customerPhone}/{customerIdentity}/{lableId}/{whetherEnable}/{customerId}")]
        public string GetCustomers(int customerId, int lableId, int pageIndex, int pageSize, string customerName="", string customerPhone="", string customerIdentity="", string whetherEnable="")
        {
            CustomerPaging customerPaging = _customer.GetCustomers<Customer>(lableId, pageIndex, pageSize, customerName, customerPhone, customerIdentity, whetherEnable);
            var dataJson = new
            {
                code = 0,
                msg = "",
                count = customerPaging.Count,
                data = customerPaging
            };
            return JsonConvert.SerializeObject(dataJson);
        }
    }
}
