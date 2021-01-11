using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Storage
{
    /// <summary>
    /// 商品库存表
    /// </summary>
    [SugarTable("CommodityStocks")]
    public class CommodityStocks
    {
        /// <summary>
        /// 库存主键id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "CommodityStocksId")]
        public int CommodityStocksId { get; set; }
        /// <summary>
        /// 商品外键
        /// </summary>
        [SugarColumn(ColumnName = "GoodsId")]
        public int GoodsId { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        [SugarColumn(ColumnName = "Inventory")]
        public int Inventory { get; set; }
        /// <summary>
        /// 可售库存
        /// </summary>
        [SugarColumn(ColumnName = "vendibilityInventory")]
        public int vendibilityInventory { get; set; }

    }
}
