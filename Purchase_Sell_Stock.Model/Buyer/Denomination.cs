using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Buyer
{
    /// <summary>
    /// 充值面额
    /// </summary>
    public class Denomination
    {
        /// <summary>
        /// 面额主键
        /// </summary>
        public int DenominationId { get; set; }
        /// <summary>
        /// 面额标题
        /// </summary>
        public string DenominationLable { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        public int DenominationMoney { get; set; }
        /// <summary>
        /// 实付金额
        /// </summary>
        public int ActuallyMoney { get; set; }
        /// <summary>
        /// 赠送金额
        /// </summary>
        public int GivenMoney { get; set; }
        /// <summary>
        /// 已充值数量
        /// </summary>
        public int Recgargenumber { get; set; }
        /// <summary>
        /// 有效期
        /// </summary>
        public string PeriodValidity { get; set; }
        /// <summary>
        /// 是否启动
        /// </summary>
        public bool WhetherEnable { get; set; }
    }
}
