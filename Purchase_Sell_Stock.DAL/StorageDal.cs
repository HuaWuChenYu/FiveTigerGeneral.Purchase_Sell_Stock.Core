using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model;
using Purchase_Sell_Stock.Model.Storage;

namespace Purchase_Sell_Stock.DAL
{
    /// <summary>
    /// 用于仓储
    /// </summary>
    public class StorageDal
    {
        //出库订单显示
        public List<Outboundorder> OutboundorderShow()
        {
            return new List<Outboundorder>();
        }
        //入库订单显示
        public List<Incomingorder> IncomingorderShow()
        {
            return new List<Incomingorder>();
        }
    }
}
