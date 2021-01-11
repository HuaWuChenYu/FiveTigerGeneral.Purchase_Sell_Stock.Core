using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Buyer
{
   public class Customer//买家表
    {
        public int CustomerId { get; set; }//买家编号
        public string CustomerName { get; set; }//买家名称
        public string CustomerPhone { get; set; }//买家手机号
        public string Customeridentity { get; set; }//买家身份
        public int LableId { get; set; }//买家标签外键
        public int Customertimes { get; set; }//消费次数
        public float Customerprice { get; set; }//单均价
        public int WalletBalance { get; set; }//钱包余额
        public DateTime RechargeTime { get; set; }//最近一次充值时间
        public string PurseState { get; set; }//钱包状态
        public int StoreId { get; set; }//店铺外键
    }
}
