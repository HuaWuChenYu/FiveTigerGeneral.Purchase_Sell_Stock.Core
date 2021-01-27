using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Purchase_Sell_Stock.DAL.GetDBHelper;
using Purchase_Sell_Stock.Model.Propertys;
using Purchase_Sell_Stock.Model.Storage;
using Purchase_Sell_Stock.Services;

namespace Purchase_Sell_Stock.API.Controllers
{
    public class PropertyController : Controller
    {


        PropertyBll pb;
        public PropertyController(IServiceProvider service)
        {
            pb = service.GetService<PropertyBll>();
        }

        /// <summary>
        /// 插入对账详细数据
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Account_Type"></param>
        /// <param name="Account_Money"></param>
        /// <param name="InorOut"></param>
        /// <param name="Order_type"></param>
        /// <param name="Order_NUm"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/AddBilling_detailsInfos")]
        public int AddBilling_detailsInfos(int UserId, string Account_Type, decimal Account_Money, int InorOut, string Order_type, string Order_NUm)
        {
            var s = pb.AddBilling_detailsInfos(UserId, Account_Type, Account_Money, InorOut, Order_type, Order_NUm);
            return s;
        }
        /// <summary>
        /// 余额
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/Show")]
        public string PropertyShow(string Order_num, string starttime_quantum, string endttime_quantum, string remark, int pageIndex = 1, int pageSize = 3)
        {
            Coods_Page<balance_Money> ss = pb.balance_MoneyShowInfos(Order_num, starttime_quantum, endttime_quantum, remark, pageIndex, pageSize);
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
        /// 待结算金额
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/ShowAmount_settledMoney")]
        public string Amount_settledMoney(string OrderUnm, int pageIndex = 1, int pageSize = 2)
        {
            Coods_Page<Amount_settledMoney> am = pb.Amount_settledMoneyShowInfos(OrderUnm, pageIndex, pageSize);
            var jsondate = new
            {
                code = 0,
                msg = "",
                count = am.AllCount,
                data = am.list,
            };
            return JsonConvert.SerializeObject(jsondate);
        }

        /// <summary>
        /// 对账详细
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/ShowBilling_details")]
        public string ShowBilling_details(string UserId, string page, int pageIndex, int pageSize, string Account_Type, string Order_NUm, int InorOut, string Order_type, string statrtime, string endtime)
        {
            Coods_Page<Billing_details> ss = pb.Billing_detailsShowInfos(UserId, page, pageIndex, pageSize, Account_Type, Order_NUm, InorOut, Order_type, statrtime, endtime);
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
            List<Rechanged_record> ss = pb.Rechanged_recordShowInfos(pageIndex, pageSize).list;
            var jsondate = new
            {
                code = 0,
                msg = "",
                count = ss.Count,
                data = ss,
            };
            return JsonConvert.SerializeObject(jsondate);
        }
        DBHelper ado = DAL.GetDBHelper.SimplyFactoryDB.GetInstance("Ado");
        /// <returns></returns>
        [HttpPost]
        [Route("/api/tim")]
        public MoneyData Tim(string beginDate= "2021-1-1", string endDate= "2021-5-6")
        {
            
            string[] strArray = new string[12];
            DateTime oldDate = new DateTime();
            DateTime newDate = new DateTime();
            try
            {
                oldDate = Convert.ToDateTime(beginDate);
                newDate = Convert.ToDateTime(endDate);
            }
            catch
            {
            }

            int ts = newDate.Month - oldDate.Month;
            int differenceInMonths = ts;
            DateTime tempTime = oldDate;
            string tempStr = "";
            for (int i = 0; i <= differenceInMonths; i++)
            {
                if (i < strArray.Length)
                {
                    tempStr = tempTime.ToString("yyyy-MM");
                    strArray[i] = tempStr;
                    tempTime = tempTime.AddMonths(1);


                }

            }
            strArray = (from str in strArray where str != null select str).ToArray();
          
           
            string begintim = "select SUM(Account_Money)as Alipaymoney from Billing_details  where CONVERT(varchar(7),date_recorded,120)>=";
            string endtime = "and CONVERT(varchar(7),date_recorded,120)<=";

            string sql = $"{begintim}'{strArray.First()}'{endtime} '{strArray.Last()}'and  InorOut=1 and Order_type ='支付宝充值' group by CONVERT(varchar(7), date_recorded, 120) ";
            var alipayM = ado.GetList<Datastatistics>(sql);

            string sql1 = $"{begintim}'{strArray.First()}'{endtime} '{strArray.Last()}'and  InorOut=1 and Order_type ='订单完结' group by CONVERT(varchar(7), date_recorded, 120) ";
            var OrderFinshM = ado.GetList<Datastatistics>(sql1);
            ArrayList AliList = new ArrayList();
            ArrayList OrderList = new ArrayList();

            foreach (var item in alipayM)
            {
                AliList.Add(item.Alipaymoney);
            }
            foreach (var item in OrderFinshM)
            {
                OrderList.Add(item.Alipaymoney); 
            }
            MoneyData moneyData = new MoneyData() {
                arrtime = strArray,
                list= AliList,
                Orderlist=OrderList
            };
            return moneyData;
        }

        [HttpPost]
        [Route("/api/Reset")]
        public string Rechanged(string UserId="1") 
        {
            string sql = $"select StoreCoding,StoreName,Balance_Money from Employee a join EmployeeAndStore b on a.EmployeeId=b.EmployeeAndStoreEmployeeId join Store c on b.EmployeeAndStoreStoreId=c.StoreId join MoneyBalance d on a.EmployeeId=d.UserId where a.EmployeeId={UserId}";
            List<RechangedReSet>sets= ado.GetList<RechangedReSet>(sql);
            return JsonConvert.SerializeObject(sets);
        }

      
    }
}