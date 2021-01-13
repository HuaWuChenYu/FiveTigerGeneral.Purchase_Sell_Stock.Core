using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Storage
{
    public class CommodityStocksandGoods
    {
        /// <summary>
        /// 库存主键id
        /// </summary>
        public int CommodityStocksId { get; set; }
        /// <summary>
        /// 商品外键
        /// </summary>
        public int GoodsId { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public int Inventory { get; set; }
        /// <summary>
        /// 可售库存
        /// </summary>
        public int vendibilityInventory { get; set; }
       
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 仓库主键
        /// </summary>
        public int WarehouseId { get; set; }
        /// <summary>
        /// 仓库编号
        /// </summary>
        public string WarehouseOrderNumber { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WarehouseName { get; set; }
    }
}
