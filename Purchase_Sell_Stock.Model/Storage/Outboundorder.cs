using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Storage
{
    /// <summary>
    /// 出库订单表
    /// </summary>
    [SugarTable("Outboundorder")]
    public class Outboundorder
    {
        /// <summary>
        /// 出库订单Id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "OutboundorderId")]
        public int OutboundorderId { get; set; }
        /// <summary>
        /// 出库订单编号
        /// </summary>
        [SugarColumn(ColumnName = "OutboundorderOrderNumber")]
        public string OutboundorderOrderNumber { get; set; }
        /// <summary>
        /// 订单外键
        /// </summary>
        [SugarColumn(ColumnName = "OrdersId")]
        public int OrdersId { get; set; }
        /// <summary>
        /// 出库类型外键
        /// </summary>
        [SugarColumn(ColumnName = "StorageTypeId")]
        public int StorageTypeId { get; set; }
        /// <summary>
        /// 状态（待出库 部分出库 已出库）
        /// </summary>
        [SugarColumn(ColumnName = "OutboundorderState")]
        public int OutboundorderState { get; set; }
        /// <summary>
        /// 出库数量（默认值0）
        /// </summary>
        [SugarColumn(ColumnName = "OutboundorderNumber")]
        public int OutboundorderNumber { get; set; }
        /// <summary>
        /// 发货方（仓库）（仓库外键）
        /// </summary>
        [SugarColumn(ColumnName = "WarehouseId")]
        public int WarehouseId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(ColumnName = "OutboundordercreationTime")]
        public DateTime OutboundordercreationTime { get; set; }
        /// <summary>
        /// 出库时间	
        /// </summary>
        [SugarColumn(ColumnName = "OutboundorderTime")]
        public DateTime OutboundorderTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnName = "OutboundorderRemark")]
        public string OutboundorderRemark { get; set; }


       
    }
}
