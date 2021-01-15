using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.DAL;
using Purchase_Sell_Stock.IServices;
using Purchase_Sell_Stock.Model.Buyer;

namespace Purchase_Sell_Stock.Services
{
    /// <summary>
    /// 用于做客户
    /// </summary>
    public class CustomerBll : ICustomer
    {
        public List<T> GetCustomers<T>(int customerId, int lableId, int pageIdex, int pageSize, string customerName, string customerPhone, string customerIdentity, string whetherEnable)
        {
            throw new NotImplementedException();
        }

        public CustomerPaging GetCustomers<T>(int lableId, int pageIndex, int pageSize, string customerName, string customerPhone, string customerIdentity, string whetherEnable)
        {
            throw new NotImplementedException();
        }

        public List<RechargeRecord> GetRechargeRecord(string customerName, string customerPhone, int denominationId)
        {
            throw new NotImplementedException();
        }
    }
}
