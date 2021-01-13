using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model.Buyer;

namespace Purchase_Sell_Stock.Model.Buyer
{
    /// <summary>
    /// 买家表分页
    /// </summary>
    public class CustomerPaging
    {
        public List<Customer> list { get; set; }
        public int Count { get; set; }
    }
}
