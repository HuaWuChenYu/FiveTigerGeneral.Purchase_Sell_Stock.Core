using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model;
using Purchase_Sell_Stock.Model.Storage;
using Purchase_Sell_Stock.Model.OrderFunction;

namespace Purchase_Sell_Stock.IServices
{
    public interface IStorage
    {
        //出库显示方法
        List<OutboundorderCombine> OutboundorderShow();
    }
}
