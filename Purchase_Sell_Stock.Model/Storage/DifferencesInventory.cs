using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Purchase_Sell_Stock.Model.Storage
{
    /// <summary>
    ///  差异库存表
    /// </summary>
    [SugarTable("DifferencesInventory")]
   
    public class DifferencesInventory
    {
        /// <summary>
        /// 差异库存主键Id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "DifferencesInventoryId")]
        public int DifferencesInventoryId { get; set; }
        /// <summary>
        /// 出库订单表外键
        /// </summary>
        [SugarColumn(ColumnName = "OutboundorderId")]
        public int OutboundorderId { get; set; }
        /// <summary>
        /// 差异类型外键
        /// </summary>
        [SugarColumn(ColumnName = "DifferentTypesId")]
        public int DifferentTypesId { get; set; }
        /// <summary>
        /// 差异数量
        /// </summary>
        [SugarColumn(ColumnName = "DifferencesInventoryNumber")]
        public int DifferencesInventoryNumber { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(ColumnName = "DifferencesInventoryCreationTime")]
        public DateTime DifferencesInventoryCreationTime { get; set; }
    }
}
