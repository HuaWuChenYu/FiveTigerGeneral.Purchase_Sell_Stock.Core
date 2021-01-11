using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Storage
{
   public  class discount_coupon
    {
        public int discount_couponId { get; set; }
        public int Proceed_Type { get; set; }
        public int Product_Id { get; set; }
        public string discount_couponName { get; set; }
        public int discount_coupon_Type { get; set; }
        public int Issue_Count { get; set; }
        public int service_conditions { get; set; }
        public DateTime Useable_Time { get; set; }
        public string instructions { get; set; }
    }
}
