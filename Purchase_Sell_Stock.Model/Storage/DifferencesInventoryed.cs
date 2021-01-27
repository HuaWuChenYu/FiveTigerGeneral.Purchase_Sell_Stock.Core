using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string GoodName { get; set; }
        /// <summary>
        /// 发货方
        /// </summary>
        [SugarColumn(ColumnName = "Consigner")]
        public string Consigner { get; set; }
        /// <summary>
        /// 收货方
        /// </summary>
        [SugarColumn(ColumnName = "Receiving")]
        public string Receiving { get; set; }
        /// <summary>
        /// 单据类型
        /// </summary>
        [SugarColumn(ColumnName = "DocumentType")]
        public string DocumentType { get; set; }
        /// <summary>
        /// 单据编号
        /// </summary>
        [SugarColumn(ColumnName = "DocumentNumber")]
        public string DocumentNumber { get; set; }
        /// <summary>
        /// 差异类型
        /// </summary>
        [SugarColumn(ColumnName = "DifferentTypesName")]
        public string DifferentTypesName { get; set; }
        /// <summary>
        /// 差异数量
        /// </summary>
        [SugarColumn(ColumnName = "DifferentNumber")]
        public int DifferentNumber { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(ColumnName = "DifferencesInventoryedTime")]
        public DateTime DifferencesInventoryedTime { get; set; }
        /// <summary>
        /// 创建时间  用于转换
        /// </summary>
         
        //public string DifferencesInventoryedTimeed { get; set; }
    }
}
