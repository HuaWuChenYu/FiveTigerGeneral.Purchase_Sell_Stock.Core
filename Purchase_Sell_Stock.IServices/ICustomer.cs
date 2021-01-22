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
        List<Customer> GetCustomerShow(string customerName,string customerPhone,string customeridentity,int lableId,int whetherEnable);
        /// <summary>
        /// 充值记录查询
        /// </summary>
        /// <param name="customerName"></param>int 
        /// <param name="customerPhone"></param>
        /// <param name="denominationId"></param>
        /// <returns></returns>
        List<RechargeRecord> GetRechargeRecord(string customerName, string customerPhone, int denominationId);
        /// <summary>
        /// 用户标签
        /// </summary>
        /// <returns></returns>
        List<Lable> GetLableShow();

        /// <summary>
        /// 添加标签
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        int GetLable(Lable a);
        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        int LableDelete(string ids);
        /// <summary>
        /// 标签反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Lable Ft(int id);
        /// <summary>
        /// 标签修改
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        int Modify(Lable g);
        /// <summary>
        /// 充值面额
        /// </summary>
        /// <returns></returns>
        List<Denomination> GetListDen();
        /// <summary>
        /// 添加面额
        /// </summary>
        /// <returns></returns>
        int AddDenomination(Denomination a);
        
    }
}
