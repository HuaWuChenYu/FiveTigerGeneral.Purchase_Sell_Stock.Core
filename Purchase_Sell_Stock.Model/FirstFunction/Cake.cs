using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.FirstFunction
{
    public class Cake
    {
        public int OrderCount { get; set; }//待发货订单
        public int CancelOrder { get; set; }//待退款订单
        public int OutCount { get; set; }//待出库订单
        public int GoCount { get; set; }//待入库订单
        public int CancelBuyCount { get; set; }//待采购退货订单
        public int BuyCount { get; set; }//待采购订单
    }
}
