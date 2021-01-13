using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Purchase_Sell_Stock.Services;
using Purchase_Sell_Stock.Model.SettingModels;

namespace Purchase_Sell_Stock.API.Controllers
{
    /// <summary>
    /// 客户控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        /// <summary>
        /// 实例化
        /// </summary>
        CustomerBll bll = new CustomerBll();
        


    }
}
