using Purchase_Sell_Stock.IServices;
using Purchase_Sell_Stock.Model.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.DAL;
using Purchase_Sell_Stock.Model.OrderFunction;

namespace Purchase_Sell_Stock.Services
{
    /// <summary>
    /// 用于仓储
    /// </summary>
    public class StorageBll : IStorage
    {
        //实例化
        StorageDal stdal = new StorageDal();
        public List<OutboundorderCombine> OutboundorderShow()
        {
            var _list= stdal.OutboundorderShow();
            return _list;
        }
    }
}
