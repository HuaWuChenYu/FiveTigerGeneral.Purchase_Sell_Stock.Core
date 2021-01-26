using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Purchase_Sell_Stock.Model.Propertys;
using Purchase_Sell_Stock.Model.Storage;
using Purchase_Sell_Stock.Services;

namespace Purchase_Sell_Stock.API.Controllers
{
    [Authorize]
    public class PropertyController : Controller
    {
    
        List<Amount_settledMoney> am;
        List<Billing_details> bd;
        Coods_Page<Rechanged_record> Rechanged_record;
        Coods_Page<balance_Money> balance_Money;
        private readonly ILogger<CustomerController> _logger;
        PropertyBll pb;

        public PropertyController(IServiceProvider service, ILogger<CustomerController> logger)
        {
            _logger = logger;
            pb = service.GetService<PropertyBll>();  
        }

        /// <summary>
        /// 余额
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/Show")]
        public string PropertyShow(string Order_num, string starttime_quantum, string endttime_quantum,string remark,int pageIndex=1,int pageSize=3)
        {
            _logger.LogInformation("余额显示成功");
            Coods_Page<balance_Money> ss = pb.balance_MoneyShowInfos(Order_num, starttime_quantum,endttime_quantum, remark, pageIndex, pageSize);
            var jsondate = new
            {
                code = 0,
                msg = "",
                count =ss.AllCount ,
                data = ss.list,
            };
            return JsonConvert.SerializeObject(jsondate);
        }

        /// <summary>
        /// 待结算金额
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/ShowAmount_settledMoney")]
        public List<Amount_settledMoney> Amount_settledMoney()
        {
            _logger.LogInformation("待结算金额显示成功");
            return am;
        }

        /// <summary>
        /// 对账详细
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/ShowBilling_details")]
        public string ShowBilling_details(string page, int pageIndex, int pageSize, string Account_Type, string Order_NUm, int InorOut, string Order_type, string statrtime, string endtime)
        {
            _logger.LogInformation("对账明细显示成功");
            Coods_Page<Billing_details> ss = pb.Billing_detailsShowInfos(page, pageIndex, pageSize, Account_Type, Order_NUm, InorOut, Order_type, statrtime, endtime);
            var jsondate = new
            {
                code = 0,
                msg = "",
                count = ss.AllCount,
                data = ss.list,
            };
            return JsonConvert.SerializeObject(jsondate);
        }

        /// <summary>
        /// 充值记录
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/ShowRechanged_record")]
        public string ShowRechanged_record(int pageIndex = 1, int pageSize = 3)
        {
            _logger.LogInformation("重置记录显示成功");
            List<Rechanged_record> ss = pb.Rechanged_recordShowInfos(pageIndex, pageSize).list;
            var jsondate = new
            {
                code = 0,
                msg = "",
                count = Rechanged_record.AllCount,
                data = ss,
            };
            return JsonConvert.SerializeObject(jsondate);
        }
    }
}