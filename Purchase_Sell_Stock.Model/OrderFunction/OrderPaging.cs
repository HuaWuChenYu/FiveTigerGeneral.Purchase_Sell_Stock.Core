using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model.GoodsFunction;

namespace Purchase_Sell_Stock.Model.OrderFunction
{
    public class OrderPaging<T>
    {
        public List<T> list { get; set; }
        public int Count { get; set; }
    }
}
