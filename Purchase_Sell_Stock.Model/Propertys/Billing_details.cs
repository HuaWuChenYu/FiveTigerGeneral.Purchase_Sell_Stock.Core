using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Storage
{
    public class Billing_details
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Billing_detailsId { get; set; }

        /// <summary>
        /// 入账日期
        /// </summary>
        public DateTime date_recorded { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Account_Type { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Account_Money { get; set; }

        /// <summary>
        /// 收入/支出
        /// </summary>
        public int InorOut { get; set; }

        /// <summary>
        /// 单据类型
        /// </summary>
        public string Order_type { get; set; }

        /// <summary>
        /// 单据编码
        /// </summary>
        public string Order_NUm { get; set; }
    }
}
