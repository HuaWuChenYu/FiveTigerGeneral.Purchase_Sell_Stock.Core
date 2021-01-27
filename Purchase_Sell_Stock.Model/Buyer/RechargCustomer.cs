using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model.Buyer;

namespace Purchase_Sell_Stock.Model.Buyer
{
    /// <summary>
    /// 充值记录
    /// </summary>
    public class RechargCustomer
    {
        /// <summary>
        /// 买家名称
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 买家手机号
        /// </summary>
        public string CustomerPhone { get; set; }
        /// <summary>
        /// 面额标题
        /// </summary>
        public string DenominationLable { get; set; }
        /// <summary>
        /// 实付金额
        /// </summary>
        public int ActuallyMoney { get; set; }
        /// <summary>
        /// 赠送金额
        /// </summary>
        public int GivenMoney { get; set; }
        /// <summary>
        /// 充值时间
        /// </summary>
        public DateTime PrepaidTime { get; set; }
    }
}
