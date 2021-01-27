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
        public string StrCommentTime { get { return CommentTime.ToString("yyyy年MM月dd日 HH时mm分ss秒"); } }//评价时间
        /// <summary>
        /// 订单外键
        /// </summary>
        public int OrdersId { get; set; }
        /// <summary>
        /// 店铺外键
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// 回复
        /// </summary>
        public string Reply { get; set; }


        public string CustomerName { get; set; }//客户姓名
        public string OrdersNum { get; set; }//订单编号
    }
}
