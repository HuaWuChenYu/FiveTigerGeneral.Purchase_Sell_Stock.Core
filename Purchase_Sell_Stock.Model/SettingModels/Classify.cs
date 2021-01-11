using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.SettingModels
{
    /// <summary>
    /// 店铺分类表
    /// </summary>
    public class Classify   
    {
        /// <summary>
        /// 店铺分类主键
        /// </summary>
        public int ClassifyId { get; set; }
        /// <summary>
        /// 店铺分类名称
        /// </summary>
        public string ClassifyName { get; set; }
    }
}
