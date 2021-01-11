using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Storage
{
    /// <summary>
    /// 仓库类型表
    /// </summary>
    [SugarTable("WarehouseType")]
    public class WarehouseType
    {
        /// <summary>
        /// 仓库类型id	
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "WarehouseTypeId")]
        public int WarehouseTypeId { get; set; }
        /// <summary>
        /// 仓库类型	
        /// </summary>
        [SugarColumn(ColumnName = "WarehouseTypeName")]
        public string WarehouseTypeName { get; set; }
        /// <summary>
        /// 商品库存id
        /// </summary>
        [SugarColumn(ColumnName = "CommodityStocksId")]
        public int CommodityStocksId { get; set; }

    }
}
