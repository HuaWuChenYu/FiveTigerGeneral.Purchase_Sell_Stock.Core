using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Storage
{
    public class Rechanged_record
    {
        public int Rechanged_recordId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime Rechanged_Time { get; set; }
        public decimal Rechange_Money { get; set; }
        public string Rechange_Type { get; set; }
    }
}
