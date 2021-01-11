using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Storage
{
    /// <summary>
    /// 入库订单表
    /// </summary>
    [SugarTable("Incomingorder")]
    public class Incomingorder
    {
        /// <summary>
        /// 入库订单Id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "IncomingorderId")]
        public int IncomingorderId { get; set; }
        /// <summary>
        /// 入库订单单号
        /// </summary>
        [SugarColumn(ColumnName = "IncomingorderOrderNumber")]
        public string IncomingorderOrderNumber { get; set; }
        /// <summary>
        /// 采购表外键	
        /// </summary>
        [SugarColumn(ColumnName = "ProcurementId")]
        public int ProcurementId { get; set; }
        /// <summary>
        /// 出入库类型名称
        /// </summary>
        [SugarColumn(ColumnName = "StorageTypeName")]
        public string StorageTypeName { get; set; }
        /// <summary>
        /// 状态（待入库 部分入库 已入库）
        /// </summary>
        [SugarColumn(ColumnName = "IncomingorderState")]
        public int IncomingorderState { get; set; }
        /// <summary>
        /// 收货方（仓库外键）
        /// </summary>
        [SugarColumn(ColumnName = "WarehouseName")]
        public string WarehouseName { get; set; }
        /// <summary>
        /// 收货数量（默认值0）
        /// </summary>
        [SugarColumn(ColumnName = "IncomingorderNumber")]
        public int IncomingorderNumber { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(ColumnName = "IncomingordercreationTime")]
        public DateTime IncomingordercreationTime { get; set; }
        /// <summary>
        /// 入库时间
        /// </summary>
        [SugarColumn(ColumnName = "IncomingorderTime")]
        public DateTime IncomingorderTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnName = "IncomingorderRemark")]
        public string IncomingorderRemark { get; set; }
    }
}
