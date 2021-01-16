using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.ProcurementFunction
{
    /// <summary>
    /// 采购退货商品表
    /// </summary>
    public class CancleProcurementGoods
    {
        /// <summary>
        /// 采购退货商品表主键
        /// </summary>
        public int ProcurementGoodsId 	 { get; set; }
        /// <summary>
        /// 采购退货表
        /// </summary>
        public int CancleProcurementId	  { get; set; }
        /// <summary>
        /// 采购退货商品数量
        /// </summary>
        public int CancleProcurementGoodsNum	 { get; set; }
        /// <summary>
        /// 商品外键
        /// </summary>
        public int GoodsId	  { get; set; }

    }
}
