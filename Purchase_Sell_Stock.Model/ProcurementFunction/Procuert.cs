using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.ProcurementFunction
{
    /// <summary>
    /// 用于穿值
    /// </summary>
    public class Procuert
    {
        public string procurementGoodsNumed { get; set; }
        public string goodid { get; set; }
        /// <summary>
        /// 采购表主键
        /// </summary>
      
        public int ProcurementId { get; set; }
        /// <summary>
        /// 采购单号
        /// </summary>
        
        public string ProcurementNum { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        
        public string ProviderName { get; set; }
        /// <summary>
        /// 采购方
        /// </summary>
       
        public string ProcurementName { get; set; }
        /// <summary>
        /// 采购创建人
        /// </summary>
     
        public string ProcurementCreator { get; set; }
        /// <summary>
        /// 采购单状态
        /// </summary>
      
        public int ProcurementState { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
       
        public DateTime ProcurementTime { get; set; }
        /// <summary>
        /// 店铺外键
        /// </summary>
     
        public int StoreId { get; set; }
    }
}
