using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Storage
{
    public class balance_Money
    {
        /// <summary>
        /// 余额表主键
        /// </summary>
        public int balance_MoneyId { get; set; }

        /// <summary>
        /// 用户外键
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 交易完成时间
        /// </summary>
        public DateTime OrderFinshTime { get; set; }

        /// <summary>
        /// 收入金额
        /// </summary>
        public decimal Income { get; set; }

        /// <summary>
        /// 余额
        /// </summary>
        public decimal Balance_Money { get; set; }

        /// <summary>
        /// 收入来源
        /// </summary>
        public string Income_Source { get; set; }

        /// <summary>
        /// 单据编码
        /// </summary>
        public string Order_num { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Explain { get; set; }
    }
}
