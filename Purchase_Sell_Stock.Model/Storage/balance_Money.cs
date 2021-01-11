using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Storage
{
    public class balance_Money
    {
        public int balance_MoneyId { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderFinshTime { get; set; }
        public decimal Income { get; set; }
        public decimal Balance_Money { get; set; }
        public string Income_Source { get; set; }
        public string Order_num { get; set; }
        public string Explain { get; set; }
    }
}
