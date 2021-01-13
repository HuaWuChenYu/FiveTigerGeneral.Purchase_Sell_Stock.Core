using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model.Buyer;

namespace Purchase_Sell_Stock.IServices
{
    public interface ICustomer
    {
        /// <summary>
        /// 全部用户查询
        /// </summary>
        List<T> GetCustomers<T>(int customerId, string customerName, string customerPhone, string customerIdentity, int lableId, string whetherEnable);

        List<RechargeRecord> GetRechargeRecord(string customerName, string customerPhone, int denominationId);
    }
}
