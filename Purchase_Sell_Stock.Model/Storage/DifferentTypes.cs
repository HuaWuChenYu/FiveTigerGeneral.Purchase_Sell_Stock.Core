using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Storage
{
    /// <summary>
    /// 差异类型表
    /// </summary>
    [SugarTable("DifferentTypes")]
    public class DifferentTypes
    {
        /// <summary>
        /// 差异类型表id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "DifferentTypesId")]
        public int DifferentTypesId { get; set; }
        /// <summary>
        /// 差异类型名称
        /// </summary>
        [SugarColumn(ColumnName = "DifferentTypesName")]
        public string DifferentTypesName { get; set; }

    }
}
