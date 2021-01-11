using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Buyer
{
   public  class Lable//买家标签
    {
        public int LableId { get; set; }//标签Id
        public string LableName { get; set; }//标签名称
        public int CustomerNumber { get; set; }//买家数量
        public string LableExplain { get; set; }//说明
        public DateTime LableTime { get; set; }//创建时间
    }
}
