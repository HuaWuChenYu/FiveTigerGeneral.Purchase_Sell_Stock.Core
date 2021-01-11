using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.GoodsFunction
{
    /// <summary>
    /// 商品分类递归表
    /// </summary>
    public class GoodsBrand
    {
        /// <summary>
        /// 
        /// </summary>
        public int GoodsTypeId { get; set; }
        public string GoodsTypeName { get; set; }
        public int GoodsTypePId { get; set; }
        public int StoreId { get; set; }
    }
}
