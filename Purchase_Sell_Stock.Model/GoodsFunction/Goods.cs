using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Purchase_Sell_Stock.Model.GoodsFunction
{
    /// <summary>
    /// 商品模型
    /// </summary>
    [SugarTable("Goods")]
    public class Goods
    {
        /// <summary>
        /// 商品主键
        /// </summary>
        [SugarColumn(ColumnName = "GoodsId",IsPrimaryKey =true,IsIdentity =true)]
        public int GoodsId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [SugarColumn(ColumnName = "GoodsName")]
        public string GoodsName { get; set; }
        /// <summary>
        /// 商品图片
        /// </summary>
        [SugarColumn(ColumnName = "GoodsPhoto")]
        public string GoodsPhoto { get; set; }

        /// <summary>
        /// 商品规格
        /// </summary>
        [SugarColumn(ColumnName = "GoodsSize")]
        public string GoodsSize { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
      
        [SugarColumn(ColumnName = "Price")]
        public float Price { get; set; }
        /// <summary>
        /// 进货价格
        /// </summary>
       
        [SugarColumn(ColumnName = "ProcurementPrice")]
        public float ProcurementPrice { get; set; }
        /// <summary>
        /// 商品上下架状态
        /// </summary>
        [SugarColumn(ColumnName = "GoodsState")]
        public bool GoodsState { get; set; }
        /// <summary>
        /// 商品类型
        /// </summary>
        [SugarColumn(ColumnName = "Goodsclassify")]
        public string Goodsclassify { get; set; }
        /// <summary>
        /// 商品分类名称
        /// </summary>
        [SugarColumn(ColumnName = "GoodsTypeName")]
        public string GoodsTypeName { get; set; }
        /// <summary>
        /// 商品单位名称
        /// </summary>
        [SugarColumn(ColumnName = "GoodsUnitName")]
        public string GoodsUnitName { get; set; }
        /// <summary>
        /// 商品品牌外键
        /// </summary>
        [SugarColumn(ColumnName = "GoodsBrandName")]
        public string GoodsBrandName { get; set; }
        /// <summary>
        /// 店铺外键
        /// </summary>
        [SugarColumn(ColumnName = "StoreId")]
        public int StoreId { get; set; }


        /// <summary>
        /// 商品数量
        /// </summary>
        public int OrdersGoodsNum { get; set; }
        /// <summary>
        /// 小计
        /// </summary>
        public double AllPrice { get { return Math.Round(Price * OrdersGoodsNum * 100) / 100; } }
        /// <summary>
        /// 商品排行销量
        /// </summary>
        public int GoodsSum { get; set; }
        /// <summary>
        /// 排行
        /// </summary>
        public int Num { get; set; }
    }
}
