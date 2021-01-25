using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Purchase_Sell_Stock.Model.ProcurementFunction
{
    /// <summary>
    /// 采购退货商品表
    /// </summary>
    [SugarTable("CancleProcurementGoods")]
    public class CancleProcurementGoods
    {
        /// <summary>
        /// 采购退货商品表主键
        /// </summary>
        [SugarColumn(ColumnName = "ProcurementGoodsId",IsPrimaryKey =true,IsIdentity =true)]
        public int ProcurementGoodsId 	 { get; set; }
        [SugarColumn(ColumnName = "CancleProcurementId")]
        /// <summary>
        /// 采购退货表
        /// </summary>
        public int CancleProcurementId	  { get; set; }
        [SugarColumn(ColumnName = "CancleProcurementGoodsNum")]
        /// <summary>
        /// 采购退货商品数量
        /// </summary>
        public int CancleProcurementGoodsNum	 { get; set; }
        [SugarColumn(ColumnName = "GoodsId")]
        /// <summary>
        /// 商品外键
        /// </summary>
        public int GoodsId	  { get; set; }
        [SugarColumn(ColumnName = "Coutbound")]
        /// <summary>
        /// 已出库
        /// </summary>
        public int Coutbound { get; set; }

    }
}
