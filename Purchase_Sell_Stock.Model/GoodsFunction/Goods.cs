using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.GoodsFunction
{
    /// <summary>
    /// 商品模型
    /// </summary>
    public class Goods
    {
        /// <summary>
        /// 商品主键
        /// </summary>
        public int GoodsId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 商品图片
        /// </summary>
        public string GoodsPhoto { get; set; }

        /// <summary>
        /// 商品规格
        /// </summary>
        public string GoodsSize { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public float Price { get; set; }
        /// <summary>
        /// 进货价格
        /// </summary>
        public float ProcurementPrice { get; set; }
        /// <summary>
        /// 商品上下架状态
        /// </summary>
        public bool GoodsState { get; set; }
        /// <summary>
        /// 商品类型
        /// </summary>
        public string Goodsclassify { get; set; }
        /// <summary>
        /// 商品分类名称
        /// </summary>
        public string GoodsTypeName { get; set; }
        /// <summary>
        /// 商品单位名称
        /// </summary>
        public string GoodsUnitName { get; set; }
        /// <summary>
        /// 商品品牌外键
        /// </summary>
        public string GoodsBrandName { get; set; }
        /// <summary>
        /// 店铺外键
        /// </summary>
        public int StoreId { get; set; }


        /// <summary>
        /// 商品数量
        /// </summary>
        public int OrdersGoodsNum { get; set; }
        public double AllPrice { get { return Math.Round(Price * OrdersGoodsNum * 100) / 100; } }//小计

        public int GoodsSum { get; set; }//商品排行销量
        public int Num { get; set; }//排行
    }
}
