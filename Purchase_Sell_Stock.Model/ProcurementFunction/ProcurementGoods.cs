using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.ProcurementFunction
{
    /// <summary>
    /// 采购商品表
    /// </summary>
    public class ProcurementGoods
    {
        /// <summary>
        /// 采购商品表主键
        /// </summary>
        public int ProcurementGoodsId { get; set; }
        /// <summary>
        /// 采购表外键
        /// </summary>
        public int ProcurementId { get; set; }
        /// <summary>
        /// 采购商品数量
        /// </summary>
        public int ProcurementGoodsNum { get; set; }
        /// <summary>
        /// 商品外键
        /// </summary>
        public int GoodsId { get; set; }
    }
}
