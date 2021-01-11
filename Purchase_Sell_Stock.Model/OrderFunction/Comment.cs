using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.OrderFunction
{
    /// <summary>
    /// 评论表
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// 评论主键
        /// </summary>
        public int CommentId { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string CommentContent { get; set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime CommentTime { get; set; }
        /// <summary>
        /// 订单外键
        /// </summary>
        public int OrdersId { get; set; }
        /// <summary>
        /// 店铺外键
        /// </summary>
        public int StoreId { get; set; }
    }
}
