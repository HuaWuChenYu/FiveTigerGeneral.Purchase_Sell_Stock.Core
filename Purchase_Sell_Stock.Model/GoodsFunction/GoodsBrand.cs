using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.GoodsFunction
{
    /// <summary>
    /// 商品品牌表
    /// </summary>
    public class GoodsBrand
    {
        /// <summary>
        /// 商品品牌表主键
        /// </summary>
        public int GoodsBrandId { get; set; }
        /// <summary>
        /// 商品品牌表名称
        /// </summary>
        public string GoodsBrandName { get; set; }
        /// <summary>
        /// 店铺外键
        /// </summary>
        public int StoreId { get; set; }
    }
}
