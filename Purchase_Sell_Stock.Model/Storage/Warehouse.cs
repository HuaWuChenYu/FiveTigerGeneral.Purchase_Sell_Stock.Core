using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Storage
{
    /// <summary>
    /// 仓库表
    /// </summary>
    [SugarTable("Warehouse")]
    public class Warehouse
    {
        /// <summary>
        /// 仓库Id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "WarehouseId")]
        public int WarehouseId { get; set; }
        /// <summary>
        /// 仓库编号
        /// </summary>
        [SugarColumn(ColumnName = "WarehouseOrderNumber")]
        public string WarehouseOrderNumber { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        [SugarColumn(ColumnName = "WarehouseName")]
        public string WarehouseName { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        [SugarColumn(ColumnName = "WarehousePrincipal")]
        public string WarehousePrincipal { get; set; }
        /// <summary>
        /// 负责人电话
        /// </summary>
        [SugarColumn(ColumnName = "WarehousePrincipalPhone")]
        public string WarehousePrincipalPhone { get; set; }
        /// <summary>
        /// 仓库位置
        /// </summary>
        [SugarColumn(ColumnName = "Warehouselocation")]
        public string Warehouselocation { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnName = "WarehouseRemark")]
        public string WarehouseRemark { get; set; }
        /// <summary>
        /// 仓库状态（开启关闭）	
        /// </summary>
        [SugarColumn(ColumnName = "WarehouseState")]
        public int WarehouseState { get; set; }
        /// <summary>
        /// 仓库类型(仓库类型外键)	
        /// </summary>
        [SugarColumn(ColumnName = "WarehouseTypeId")]
        public int WarehouseTypeId { get; set; }

    }
}
