using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.ProcurementFunction
{
    public class CancleProcurementGoods
    {
        public int ProcurementGoodsId { get; set; }
        public int CancleProcurementId { get; set; }
        public int CancleProcurementGoodsNum { get; set; }
        public int GoodsId { get; set; }
    }
}
