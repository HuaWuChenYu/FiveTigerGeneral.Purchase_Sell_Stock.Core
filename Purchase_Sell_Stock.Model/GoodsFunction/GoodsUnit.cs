using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.GoodsFunction
{
    /// <summary>
    /// 商品单位表
    /// </summary>
    public class GoodsUnit
    {
        /// <summary>
        /// 商品单位主键
        /// </summary>
        public int GoodsUnitId { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string GoodsUnitName { get; set; }
        /// <summary>
        /// 单位分组(下拉写死)
        /// </summary>
        public string GoodsUnitGroup { get; set; }
        /// <summary>
        /// 店铺外键
        /// </summary>
        public int StoreId { get; set; }
    }
}
