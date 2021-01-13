using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Propertys
{
    public class Coods_Page<T> where T:class,new()
    {
        public int AllCount { get; set; }
        public List<T> list { get; set; }
    }
}
