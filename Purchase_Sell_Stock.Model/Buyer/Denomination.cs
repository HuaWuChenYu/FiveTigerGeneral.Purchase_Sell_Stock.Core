using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Buyer
{
    public class Denomination//充值面额
    {
        public int DenominationId { get; set; }//面额主键
        public string DenominationLable { get; set; }//面额标题
        public int DenominationMoney { get; set; }//充值金额
        public int ActuallyMoney { get; set; }//实付金额
        public int GivenMoney { get; set; }//赠送金额
        public int Recgargenumber { get; set; }//已充值数量
        public string PeriodValidity { get; set; }//有效期
        public bool WhetherEnable { get; set; }//是否启动
        public int StoreId { get; set; }//店铺外键
    }
}
