using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.OrderFunction
{
    public class CancelOrderOneViewModel
    {
        public string OrdersNum { get; set; }//订单编号
        public DateTime OrdersTime { get; set; }//下单时间
        public string StrOrdersTime { get {return OrdersTime.ToString("yyyy年MM月dd日 HH时mm分ss秒"); } }//下单时间
        public string PayWay { get; set; }//支付方式
        public string SellType { get; set; }//销售类型
        public decimal PayMoney { get; set; }//金额
        public int OrdersState { get; set; }//订单状态
        public string Adress { get; set; }//收货人地址
        public string CustomerName { get; set; }//收货人姓名
        public string CustomerPhone { get; set; }//收货人联系方式
        public DateTime CancelOrderTime { get; set; }//退单时间
        public string StrCancelOrderTime { get { return CancelOrderTime.ToString("yyyy年MM月dd日 HH时mm分ss秒"); } }//下单时间
        public string CancelOrderNumber { get; set; }//退单编号
        public int CancelOrderState { get; set; }//退单状态
        public string CancelOrderReason { get; set; }//退单原因
        public string CancelOrderPhoto { get; set; }//客户提供图片
    }
}
