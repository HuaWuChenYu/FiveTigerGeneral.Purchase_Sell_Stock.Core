using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Purchase_Sell_Stock.Model.Storage
{
    
    /// <summary>
    /// 差异库存表
    /// </summary>
    [SugarTable("DifferencesInventoryed")]
    public class DifferencesInventoryed
    {
        /// <summary>
        /// 差异库存id
        /// </summary>
        [SugarColumn(IsPrimaryKey =true,IsIdentity =true,ColumnName = "DifferencesInventoryedId")]
        public int DifferencesInventoryedId { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        [SugarColumn(ColumnName = "GoodId")]
        public int GoodId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [SugarColumn(ColumnName = "GoodName")]
        public int GoodName { get; set; }
        /// <summary>
        /// 发货方
        /// </summary>
        [SugarColumn(ColumnName = "Consigner")]
        public int Consigner { get; set; }
        /// <summary>
        /// 收货方
        /// </summary>
        [SugarColumn(ColumnName = "Receiving")]
        public int Receiving { get; set; }
        /// <summary>
        /// 单据类型
        /// </summary>
        [SugarColumn(ColumnName = "DocumentType")]
        public int DocumentType { get; set; }
        /// <summary>
        /// 单据编号
        /// </summary>
        [SugarColumn(ColumnName = "DocumentNumber")]
        public int DocumentNumber { get; set; }
        /// <summary>
        /// 差异类型
        /// </summary>
        [SugarColumn(ColumnName = "DifferentTypesName")]
        public int DifferentTypesName { get; set; }
        /// <summary>
        /// 差异数量
        /// </summary>
        [SugarColumn(ColumnName = "DifferentNumber")]
        public int DifferentNumber { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(ColumnName = "DifferencesInventoryedTime")]
        public int DifferencesInventoryedTime { get; set; }
    }
}
