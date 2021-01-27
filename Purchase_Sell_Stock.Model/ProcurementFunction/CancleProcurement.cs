using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Purchase_Sell_Stock.Model.ProcurementFunction
{
    /// <summary>
    /// 采购退货表
    /// </summary>
    [SugarTable("CancleProcurement")]
    public class CancleProcurement
    {
        /// <summary>
        /// 采购退货主键
        /// </summary>
        [SugarColumn(ColumnName = "CancleProcurementId",IsPrimaryKey =true,IsIdentity =true)]
        public int CancleProcurementId { get; set; }
        /// <summary>
        /// 退货单号
        /// </summary>
        [SugarColumn(ColumnName = "CancleProcurementNum")]
        public string CancleProcurementNum { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        [SugarColumn(ColumnName = "ProviderName")]
        public string ProviderName { get; set; }
        /// <summary>
        /// 退货方
        /// </summary>
        [SugarColumn(ColumnName = "CancleProcurementName")]
        public string CancleProcurementName { get; set; }
        /// <summary>
        /// 退货状态
        /// </summary>
        [SugarColumn(ColumnName = "CancleProcurementState")]
        public int CancleProcurementState { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(ColumnName = "CancleProcurementTime")]
        public DateTime CancleProcurementTime { get; set; }
        /// <summary>
        /// 店铺外键
        /// </summary>
        [SugarColumn(ColumnName = "StoreId")]
        public int StoreId { get; set; }
    }
}
