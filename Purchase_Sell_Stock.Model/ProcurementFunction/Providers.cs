using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Purchase_Sell_Stock.Model.ProcurementFunction
{
    /// <summary>
    /// 供应商表
    /// </summary>
    [SugarTable("Providers")]
    public class Providers
    {
        /// <summary>
        /// 供应商主键
        /// </summary>
        [SugarColumn(ColumnName = "ProviderId",IsPrimaryKey =true,IsIdentity =true)]
        public int ProviderId { get; set; }
        /// <summary>
        /// 供应商编码
        /// </summary>
        [SugarColumn(ColumnName = "ProvidersNum")]
        public string ProvidersNum { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        [SugarColumn(ColumnName = "ProvidersName")]
        public string ProvidersName { get; set; }
        /// <summary>
        /// 供应商类别
        /// </summary>
        [SugarColumn(ColumnName = "ProvidersType")]
        public string ProvidersType { get; set; }
        /// <summary>
        /// 供应商负责人
        /// </summary>
        [SugarColumn(ColumnName = "ProvidersPerson")]
        public string ProvidersPerson { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(ColumnName = "ProvidersTime")]
        public DateTime ProvidersTime { get; set; }
        /// <summary>
        /// 供应商创建人
        /// </summary>
        [SugarColumn(ColumnName = "ProvidersCreator")]
        public string ProvidersCreator { get; set; }
        /// <summary>
        /// 店铺外键
        /// </summary>
        [SugarColumn(ColumnName = "StoreId")]
        public int StoreId { get; set; }

        /// <summary>
        /// 供应商电话
        /// </summary>
        [SugarColumn(ColumnName = "ProvidersPhone")]
        public string ProvidersPhone { get; set; }
        /// <summary>
        /// 供应商地址
        /// </summary>
        [SugarColumn(ColumnName = "ProvidersAddress")]
        public string ProvidersAddress { get; set; }
    }
}
