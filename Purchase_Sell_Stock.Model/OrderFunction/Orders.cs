using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.OrderFunction
{
    /// <summary>
    /// 订单表
    /// </summary>
    public class Orders
    {
        /// <summary>
        /// 订单主键
        /// </summary>
        public int OrdersId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrdersNum { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OrdersTime { get; set; }
        public string StrOrdersTime { get { return OrdersTime.ToString("yyyy年MM月dd日 hh时MM分ss秒"); } }//下单时间显示
        /// <summary>
        /// 支付方式
        /// </summary>
        public string PayWay { get; set; }
        /// <summary>
        /// 销售类型
        /// </summary>
        public string SellType { get; set; }
        /// <summary>
        /// 实付金额
        /// </summary>
        public decimal PayMoney { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrdersState { get; set; }
        /// <summary>
        /// 发票抬头
        /// </summary>
        public string InvoiceTitle { get; set; }
        /// <summary>
        /// 发票代码
        /// </summary>
        public string InvoiceCode { get; set; }
        /// <summary>
        /// 发票类型
        /// </summary>
        public string InvoiceType { get; set; }
        /// <summary>
        /// 发票时间
        /// </summary>
        public DateTime InvoiceTime { get; set; }
        /// <summary>
        /// 发票状态
        /// </summary>
        public bool InvoiceState { get; set; }
        /// <summary>
        /// 客户外键
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// 店铺外键
        /// </summary>
        public int StoreId { get; set; }


        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 收货人手机号码
        /// </summary>
        public string CustomerPhone { get; set; }
    }
}
