using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Purchase_Sell_Stock.Model.ProcurementFunction
{
    /// <summary>
    /// 采购商品表
    /// </summary>
    [SugarTable("ProcurementGoods")]
    public class ProcurementGoods
    {
        /// <summary>
        /// 采购商品表主键
        /// </summary>
        [SugarColumn(ColumnName = "ProcurementGoodsId",IsPrimaryKey =true,IsIdentity =true)]
        public int ProcurementGoodsId { get; set; }
        /// <summary>
        /// 采购表外键
        /// </summary>
        [SugarColumn(ColumnName = "ProcurementId")]
        public int ProcurementId { get; set; }
        /// <summary>
        /// 采购商品数量
        /// </summary>
        [SugarColumn(ColumnName = "ProcurementGoodsNum")]
        public int ProcurementGoodsNum { get; set; }
        /// <summary>
        /// 商品外键
        /// </summary>
        [SugarColumn(ColumnName = "GoodsId")]
        public int GoodsId { get; set; }
        /// <summary>
        /// 已入库的数量
        /// </summary>
        [SugarColumn(ColumnName = "Poutbound")]
        public int Poutbound { get; set; }
        /// <summary>
        /// 合计
        /// </summary>
        [SugarColumn(ColumnName = "Total")]
        public int Total { get; set; }
    }
}
