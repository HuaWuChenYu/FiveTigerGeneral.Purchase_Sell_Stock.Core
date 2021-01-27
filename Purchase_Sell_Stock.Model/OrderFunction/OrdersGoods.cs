using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.OrderFunction
{
    /// <summary>
    /// 订单商品表
    /// </summary>
    public class OrdersGoods
    {
        /// <summary>
        /// 订单商品主键
        /// </summary>
        public int OrdersGoodsId { get; set; }
        /// <summary>
        /// 商品外键
        /// </summary>
        public int GoodsId { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int OrdersGoodsNum { get; set; }
        /// <summary>
        /// 订单外键
        /// </summary>
        public int OrdersId { get; set; }
        /// <summary>
        /// 已出库数量
        /// </summary>
        public int Ooutbound { get; set; }
    }
}
