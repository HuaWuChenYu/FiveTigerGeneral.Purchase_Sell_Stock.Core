using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Buyer
{
    public class RechargeRecord//充值记录
    {
        public int RechargeId { get; set; }//充值ID
        public DateTime PrepaidTime { get; set; }//充值时间
        public int CustomerId { get; set; }//买家外键
        public string DenominationLable { get; set; }//面额标题
        public int StoreId { get; set; }//店铺外键
    }
}
