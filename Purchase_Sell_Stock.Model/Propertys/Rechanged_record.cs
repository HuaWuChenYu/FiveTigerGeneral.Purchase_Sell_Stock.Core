using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Storage
{
    public class Rechanged_record
    {
        /// <summary>
        /// 充值表主键
        /// </summary>
        public int Rechanged_recordId { get; set; }

        /// <summary>
        /// 用户外键
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 充值时间
        /// </summary>
        public DateTime Rechanged_Time { get; set; }

        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal Rechange_Money { get; set; }

        /// <summary>
        /// 充值类型
        /// </summary>
        public string Rechange_Type { get; set; }
    }
}
