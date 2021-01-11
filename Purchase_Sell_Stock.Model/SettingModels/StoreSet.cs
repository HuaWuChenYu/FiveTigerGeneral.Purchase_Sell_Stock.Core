using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.SettingModels
{
    /// <summary>
    /// 店铺设置表
    /// </summary>
    public class StoreSet
    {
        /// <summary>
        /// 店铺设置表主键
        /// </summary>
        public int StoreSetId { get; set; }
        /// <summary>
        /// 店铺分享文案
        /// </summary>
        public string StoreSetInformation { get; set; }
        /// <summary>
        /// 店铺分享海报
        /// </summary>
        public string StoreSetPoster { get; set; }
        /// <summary>
        /// 联系客服
        /// </summary>
        public bool StoreSetIsService { get; set; }
        /// <summary>
        /// 售空商品
        /// </summary>
        public bool StoreSetIsEmpty { get; set; }
        /// <summary>
        /// 商品评价
        /// </summary>
        public int StoreSetIsEvaluate { get; set; }
        /// <summary>
        /// 商品销量
        /// </summary>
        public bool StoreSetIsSales { get; set; }
        /// <summary>
        /// 库存扣减方法
        /// </summary>
        public bool StoreSetIsDeduction { get; set; }
        /// <summary>
        /// 自动取消订单时间
        /// </summary>
        public int StoreSetAtuoCancel { get; set; }
        /// <summary>
        /// 开票设置
        /// </summary>
        public bool StoreSetMakeInvoice { get; set; }
        /// <summary>
        /// 切换网店设置
        /// </summary>
        public int StoreSetChangeStore { get; set; }
        /// <summary>
        /// 店铺下单设置
        /// </summary>
        public bool StoreSetOrder { get; set; }
        /// <summary>
        /// 店铺运营模式
        /// </summary>
        public int StoreSetOperation { get; set; }
        /// <summary>
        /// 歇业原因
        /// </summary>
        public string StoreSetClose { get; set; }
        /// <summary>
        /// 店铺主键
        /// </summary>
        public int StoreId { get; set; }
    }
}
