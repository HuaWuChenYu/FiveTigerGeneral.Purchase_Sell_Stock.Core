using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model.OrderFunction;

namespace Purchase_Sell_Stock.IServices
{
    public interface IOrder
    {
        OrderPaging<T> GetGoodsList<T>(int pageIndex,int pageSize,string ordersNum,string ordersBelong, DateTime ordersTime,string PayWay);
    }
}
