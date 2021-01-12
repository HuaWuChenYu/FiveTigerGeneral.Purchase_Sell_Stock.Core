using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model.GoodsFunction;

namespace Purchase_Sell_Stock.DAL
{
    public class GoodsPaging
    {
        public List<Goods> list { get; set; }
        public int Count { get; set; }
    }
}
