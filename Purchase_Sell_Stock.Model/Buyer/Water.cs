using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Buyer
{
    /// <summary>
    /// 流水表
    /// </summary>
    public class Water
    {
        /// <summary>
        /// 类型Id
        /// </summary>
        public int LXId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string LeiX { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        public int DenominationMoney { get; set; }
        /// <summary>
        /// 实付金额
        /// </summary>
        public int ActuallyMoney { get; set; }
        /// <summary>
        /// 充值时间
        /// </summary>
        public DateTime PrepaidTime { get; set; }

    }
}
