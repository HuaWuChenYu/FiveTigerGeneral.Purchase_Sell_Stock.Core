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
        List<T> GetCustomers<T>(int customerId, int lableId, int pageIdex,int pageSize,    string customerName, string customerPhone, string customerIdentity,  string whetherEnable);
        /// <summary>
        /// 充值记录查询
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="customerPhone"></param>
        /// <param name="denominationId"></param>
        /// <returns></returns>
        List<RechargeRecord> GetRechargeRecord(string customerName, string customerPhone, int denominationId);
        CustomerPaging GetCustomers<T>(int lableId, int pageIndex, int pageSize, string customerName, string customerPhone, string customerIdentity, string whetherEnable);

        //List<>
    }
}
