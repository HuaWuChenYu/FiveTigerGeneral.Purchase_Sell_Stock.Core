using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Buyer
{
    /// <summary>
    /// 买家标签
    /// </summary>
    public class Lable
    {
        /// <summary>
        /// 标签Id
        /// </summary>
        public int LableId { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        public string LableName { get; set; }
        /// <summary>
        /// 买家数量
        /// </summary>
        public int CustomerNumber { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string LableExplain { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime LableTime { get; set; }
    }
}
