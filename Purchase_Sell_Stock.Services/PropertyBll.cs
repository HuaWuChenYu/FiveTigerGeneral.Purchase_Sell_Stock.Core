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

        public Coods_Page<balance_Money> balance_MoneyShowInfos(int pageIndex, int pageSize, string Order_num=null, string starttime_quantum=null, string endttime_quantum=null, string remark=null) 
        {
            return pd.balance_MoneyShowInfos( pageIndex,  pageSize,  Order_num, starttime_quantum,  endttime_quantum,  remark);
        }

        public List<Billing_details> Billing_detailsShowInfos()
        {
            return pd.Billing_detailsShowInfos();
        }

        public List<Rechanged_record> Rechanged_recordShowInfos()
        {
            return pd.Rechanged_recordShowInfos();
        }
    }
}
