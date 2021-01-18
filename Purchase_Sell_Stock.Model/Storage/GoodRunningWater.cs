using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Purchase_Sell_Stock.Model.Storage
{
    [SugarTable("GoodRunningWater")]
    public class GoodRunningWater
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "GoodRunningWaterId")]
        public int GoodRunningWaterId { get; set; }
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

        /// <summary>
        /// 商品名称
        /// </summary>
        [SugarColumn(ColumnName = "GoodsName")]
        public string GoodsName { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        [SugarColumn(ColumnName = "WarehouseName")]
        public string WarehouseName { get; set; }
        /// <summary>
        /// 商品规格
        /// </summary>
        [SugarColumn(ColumnName = "GoodsSize")]
        public string GoodsSize { get; set; }
        /// <summary>
        /// 商品单位名称
        /// </summary>
        [SugarColumn(ColumnName = "GoodsUnitName")]
        public string GoodsUnitName { get; set; }
        /// <summary>
        /// 出入库
        /// </summary>
        [SugarColumn(ColumnName = "ChuKu")]
        public string ChuKu { get; set; }
        /// <summary>
        /// 剩余库存
        /// </summary>
        [SugarColumn(ColumnName = "ResidueWarehouse")]
        public int ResidueWarehouse { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        [SugarColumn(ColumnName = "Source")]
        public string Source { get; set; }
        /// <summary>
        /// 来源单号
        /// </summary>
        [SugarColumn(ColumnName = "SourceNumber")]
        public string SourceNumber { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [SugarColumn(ColumnName = "Operator")]
        public string Operator { get; set; }
    }
}
