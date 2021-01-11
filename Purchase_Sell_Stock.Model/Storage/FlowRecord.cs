using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Purchase_Sell_Stock.Model.Storage
{
    /// <summary>
    /// 库存流水记录表
    /// </summary>
    [SugarTable("FlowRecord")]
    public class FlowRecord
    {
        /// <summary>
        /// 库存流水记录表主键id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "FlowRecordId")]
        public int FlowRecordId { get; set; }
        /// <summary>
        /// 出库订单表外键
        /// </summary>
        [SugarColumn(ColumnName = "OutboundorderId")]
        public int OutboundorderId { get; set; }
        /// <summary>
        /// 入库订单表外键
        /// </summary>
        [SugarColumn(ColumnName = "IncomingorderId")]
        public int IncomingorderId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(ColumnName = "FlowRecordCreationTime")]
        public DateTime FlowRecordCreationTime { get; set; }
        /// <summary>
        /// 剩余库存（商品库存表外键）
        /// </summary>
        [SugarColumn(ColumnName = "CommodityStocksId")]
        public int CommodityStocksId { get; set; }

    }
}
