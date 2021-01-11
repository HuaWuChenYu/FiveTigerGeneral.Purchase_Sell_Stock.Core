using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Storage
{
    public class Amount_settled
    {
        public int Amount_settleId { get; set; }
        public int OrderId { get; set; }
        public decimal Amount_settledMoney { get; set; }
        public DateTime OrderSubmitTime { get; set; }
        public string OrderUnm { get; set; }
        public string ProductName { get; set; }
    }
}
