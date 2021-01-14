using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Storage
{
    public class Amount_settledMoney
    {
        /// <summary>
        /// 待结算金额主键
        /// </summary>
        public int Amount_settleId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 待结算金额
        /// </summary>
        public decimal Amount_settledMoneys { get; set; }

        /// <summary>
        /// 订单提交时间
        /// </summary>
        public DateTime OrderSubmitTime { get; set; }

        /// <summary>
        /// 订单编码
        /// </summary>
        public string OrderUnm { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }
    }
}
