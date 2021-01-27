using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Buyer
{
    /// <summary>
    /// 买家表
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// 买家编号
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// 买家名称
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 买家手机号
        /// </summary>
        public string CustomerPhone { get; set; }
        /// <summary>
        /// 买家身份
        /// </summary>
        public string Customeridentity { get; set; }
        /// <summary>
        /// 买家标签外键
        /// </summary>
        public int LableId { get; set; }
        /// <summary>
        /// 消费次数
        /// </summary>
        public int Customertimes { get; set; }
        /// <summary>
        /// 单均价
        /// </summary>
        public decimal Customerprice { get; set; }
        /// <summary>
        /// 钱包余额
        /// </summary>
        public int WalletBalance { get; set; }
        /// <summary>
        /// 最近一次充值时间
        /// </summary>
        public DateTime RechargeTime { get; set; }
        /// <summary>
        /// 钱包状态
        /// </summary>
        public string PurseState { get; set; }
        /// <summary>
        /// 店铺外键
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Adress { get; set; }
    }
}
