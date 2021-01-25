using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.ProcurementFunction
{
    public class Goodsbuyer
    {
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

        /// <summary>
        /// 采购商品表主键
        /// </summary>
        public int ProcurementGoodsId { get; set; }
        /// <summary>
        /// 采购商品数量
        /// </summary>
        public int ProcurementGoodsNum { get; set; }
        /// <summary>
        /// 商品外键
        /// </summary>
        public int GoodsId { get; set; }
 
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }
 

        /// <summary>
        /// 商品规格
        /// </summary>
        public string GoodsSize { get; set; }
        /// <summary>
        /// 进货价格
        /// </summary>
        public int ProcurementPrice { get; set; }
 
 
 
        /// <summary>
        /// 商品单位名称
        /// </summary>
        public string GoodsUnitName { get; set; }
        /// <summary>
        /// 合计
        /// </summary>

        public int Total { get; set; }



    }
}
