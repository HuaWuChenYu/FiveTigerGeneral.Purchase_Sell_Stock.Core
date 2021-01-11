using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Storage
{
    public class Billing_details
    {
        public int Billing_detailsId { get; set; }
        public DateTime date_recorded { get; set; }
        public string Account_Type { get; set; }
        public decimal Account_Money { get; set; }
        public int InorOut { get; set; }
        public string Order_type { get; set; }
        public string Order_NUm { get; set; }
    }
}
