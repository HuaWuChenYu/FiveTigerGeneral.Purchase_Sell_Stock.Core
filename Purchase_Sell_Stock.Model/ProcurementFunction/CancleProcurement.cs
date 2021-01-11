using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.ProcurementFunction
{
    /// <summary>
    /// 采购退货表
    /// </summary>
    public class CancleProcurement
    {
        /// <summary>
        /// 采购退货主键
        /// </summary>
        public int CancleProcurementId { get; set; }
        /// <summary>
        /// 退货单号
        /// </summary>
        public string CancleProcurementNum { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public string ProviderName { get; set; }
        /// <summary>
        /// 退货方
        /// </summary>
        public string CancleProcurementName { get; set; }
        /// <summary>
        /// 退货状态
        /// </summary>
        public int CancleProcurementState { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CancleProcurementTime { get; set; }
        /// <summary>
        /// 店铺外键
        /// </summary>
        public int StoreId { get; set; }
    }
}
