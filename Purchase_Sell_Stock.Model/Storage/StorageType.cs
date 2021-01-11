using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Storage
{
    /// <summary>
    /// 出入库类型表
    /// </summary>
    [SugarTable("StorageType")]
    public class StorageType
    {
        /// <summary>
        /// 出入库类型id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "StorageTypeId")]
        public int StorageTypeId { get; set; }
        /// <summary>
        /// 出入库类型名称
        /// </summary>
        [SugarColumn(ColumnName = "StorageTypeName")]
        public string StorageTypeName { get; set; }

    }
}
