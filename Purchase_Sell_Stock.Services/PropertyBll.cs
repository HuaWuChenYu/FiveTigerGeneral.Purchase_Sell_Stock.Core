using Purchase_Sell_Stock.Model.Storage;
using System;
using System.Collections.Generic;
using Purchase_Sell_Stock.IServices;
using Purchase_Sell_Stock.DAL;
using Purchase_Sell_Stock.Model.Propertys;

namespace Purchase_Sell_Stock.Services
{

    public class PropertyBll : IProperty
    {
        PropertyDal pd = new PropertyDal();
        public int AddAmount_settledInfos()
        {
            return pd.AddAmount_settledInfos();
        }

        public int Addbalance_MoneyInfos()
        {
            return pd.Addbalance_MoneyInfos();

        }

        public int AddBilling_detailsInfos()
        {
            return pd.AddBilling_detailsInfos();
        }

        public int AddRechanged_recordInfos()
        {
            return pd.AddRechanged_recordInfos();
        }

        public List<Amount_settledMoney> Amount_settledMoneyShowInfos()
        {
            return pd.Amount_settledMoneyShowInfos();
        }

        public Coods_Page<balance_Money> balance_MoneyShowInfos(string Order_num, string starttime_quantum, string endttime_quantum, string remark, int pageIndex, int pageSize)
        {
            Coods_Page < balance_Money > sd= pd.balance_MoneyShowInfos(Order_num, starttime_quantum, endttime_quantum, remark, pageIndex, pageSize);
            foreach (var item in sd.list)
            {
                item.OrderFinshTime.ToString("yyyyMMdd");
            }
            return sd;
        }

        //public Coods_Page<Billing_details> Billing_detailsShowInfos(string page, int pageIndex, int pageSize, string Account_Type = null, string Order_NUm = null, int? InorOut = null, string Order_type = null, DateTime? statrtime = null, DateTime? endtime = null)
        //{
        //    return pd.Billing_detailsShowInfos(page, pageIndex, pageSize, Account_Type, Order_NUm, InorOut, Order_type, statrtime, endtime);
        //}

        public Coods_Page<Billing_details> Billing_detailsShowInfos(string page, int pageIndex, int pageSize, string Account_Type, string Order_NUm, int InorOut, string Order_type, string statrtime, string endtime)
        {
            return pd.Billing_detailsShowInfos(page, pageIndex, pageSize, Account_Type, Order_NUm, InorOut, Order_type, statrtime, endtime);
        }

        public Coods_Page<Rechanged_record> Rechanged_recordShowInfos(int pageIndex, int pageSize)
        {
            return pd.Rechanged_recordShowInfos();
        }
    }
}
