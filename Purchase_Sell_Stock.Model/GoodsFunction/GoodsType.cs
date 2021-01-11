using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.GoodsFunction
{
    /// <summary>
    /// 商品分类表
    /// </summary>
    public class GoodsType
    {
        /// <summary>
        /// 商品分类主键
        /// </summary>
        public int GoodsTypeId { get; set; }
        /// <summary>
        /// 商品分类名称
        /// </summary>
        public string GoodsTypeName { get; set; }
        /// <summary>
        /// 上级ID
        /// </summary>
        public int GoodsTypePId { get; set; }
        /// <summary>
        /// 店铺外键
        /// </summary>
        public int StoreId { get; set; }
    }
}
