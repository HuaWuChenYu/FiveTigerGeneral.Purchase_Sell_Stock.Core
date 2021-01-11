using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.OrderFunction
{
    /// <summary>
    /// 退单表
    /// </summary>
    public class CancelOrder
    {
        /// <summary>
        /// 退单主键
        /// </summary>
        public int CancelOrderId { get; set; }
        /// <summary>
        /// 退单时间
        /// </summary>
        public DateTime CancelOrderTime { get; set; }
        /// <summary>
        /// 退单申请时间
        /// </summary>
        public DateTime CancelOrderApplyTime { get; set; }
        /// <summary>
        /// 退款状态
        /// </summary>
        public int CancelOrderState { get; set; }
        /// <summary>
        /// 退款原因
        /// </summary>
        public string CancelOrderReason { get; set; }
        /// <summary>
        /// 退款图片
        /// </summary>
        public string CancelOrderPhoto { get; set; }
        /// <summary>
        /// 订单外键
        /// </summary>
        public int OrdersId { get; set; }
    }
}
