using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Storage
{
   public  class discount_coupon
    {
        /// <summary>
        /// 优惠券主键
        /// </summary>
        public int discount_couponId { get; set; }

        /// <summary>
        /// 进行状态 未开始/进行中/已结束
        /// </summary>
        public int Proceed_Type { get; set; }

        /// <summary>
        /// 商品外键
        /// </summary>
        public int Product_Id { get; set; }

        /// <summary>
        /// 优惠券名称
        /// </summary>
        public string discount_couponName { get; set; }

        /// <summary>
        /// 优惠券类型
        /// </summary>
        public int discount_coupon_Type { get; set; }

        /// <summary>
        /// 发行数量
        /// </summary>
        public int Issue_Count { get; set; }

        /// <summary>
        /// 使用门槛
        /// </summary>
        public int service_conditions { get; set; }

        /// <summary>
        /// 可用时间
        /// </summary>
        public DateTime Useable_Time { get; set; }

        /// <summary>
        /// 使用说明
        /// </summary>
        public string instructions { get; set; }
    }
}
