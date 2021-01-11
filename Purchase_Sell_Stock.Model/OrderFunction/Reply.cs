using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.OrderFunction
{
    /// <summary>
    /// 回复评论表
    /// </summary>
    public class Reply
    {
        /// <summary>
        /// 回复评论主键
        /// </summary>
        public int ReplyId { get; set; }
        /// <summary>
        /// 回复内容
        /// </summary>
        public string ReplyContent { get; set; }
        /// <summary>
        /// 评论外键
        /// </summary>
        public int CommentId { get; set; }
    }
}
