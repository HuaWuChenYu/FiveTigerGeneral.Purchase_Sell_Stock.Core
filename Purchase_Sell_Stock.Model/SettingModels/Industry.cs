using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.SettingModels
{
    /// <summary>
    /// 行业表
    /// </summary>
    public class Industry
    {
        /// <summary>
        /// 行业表主键
        /// </summary>
        public int IndustryId { get; set; }
        /// <summary>
        /// 行业名称
        /// </summary>
        public string IndustryName { get; set; }
    }
}
