using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Buyer
{
    public class wallet
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
        /// 钱包余额
        /// </summary>
        public string PurseMoney { get; set; }
        /// <summary>
        /// 冻结金额
        /// </summary>
        public string FreezeMoney { get; set; }
        /// <summary>
        /// 充值总额
        /// </summary>
        public int RechargeAmount { get; set; }
        /// <summary>
        /// 充值次数
        /// </summary>
        public string RechargeSum { get; set; }
        /// <summary>
        /// 最近一次充值时间
        /// </summary>
        public DateTime RechargeTime { get; set; }
        /// <summary>
        /// 钱包状态
        /// </summary>
        public string PurseState { get; set; }
    }
}
