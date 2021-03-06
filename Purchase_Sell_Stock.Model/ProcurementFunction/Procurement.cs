﻿using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Purchase_Sell_Stock.Model.ProcurementFunction
{
    /// <summary>
    /// 采购表
    /// </summary>
    [SugarTable("Procurement")]
    public class Procurement
    {
        /// <summary>
        /// 采购表主键
        /// </summary>
        [SugarColumn(ColumnName = "ProcurementId",IsIdentity =true,IsPrimaryKey =true)]
        public int ProcurementId { get; set; }
        /// <summary>
        /// 采购单号
        /// </summary>
        [SugarColumn(ColumnName = "ProcurementNum")]
        public string ProcurementNum { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        [SugarColumn(ColumnName = "ProviderName")]
        public string ProviderName { get; set; }
        /// <summary>
        /// 采购方
        /// </summary>
        [SugarColumn(ColumnName = "ProcurementName")]
        public string ProcurementName { get; set; }
        /// <summary>
        /// 采购创建人
        /// </summary>
        [SugarColumn(ColumnName = "ProcurementCreator")]
        public string ProcurementCreator { get; set; }
        /// <summary>
        /// 采购单状态
        /// </summary>
        [SugarColumn(ColumnName = "ProcurementState")]
        public int ProcurementState { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(ColumnName = "ProcurementTime")]
        public DateTime ProcurementTime { get; set; }
        /// <summary>
        /// 店铺外键
        /// </summary>
        [SugarColumn(ColumnName = "StoreId")]
        public int StoreId { get; set; }
    }
}
