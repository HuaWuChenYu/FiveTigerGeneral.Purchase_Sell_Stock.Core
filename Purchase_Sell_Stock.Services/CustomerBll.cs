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
        CustomerDal dal = DalFactory.GetDal<CustomerDal>("Customer");
        /// <summary>
        /// 客户
        /// </summary>
        /// <summary>
        /// 添加标签
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int GetLable(Lable a)
        {
            return dal.GetLable(a);
        }
        /// <summary>
        /// 标签
        /// </summary>
        /// <returns></returns>
        public List<Lable> GetLableShow()
        {
            return dal.GetLableShow();
        }
        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int LableDelete(string ids)
        {
            return dal.LableDelete(ids);
        }
        /// <summary>
        /// 标签反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Lable> Ft(int id)
        {
            return dal.Ft(id);
        }
        /// <summary>
        /// 标签修改
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public int Modify(Lable g)
        {
            return dal.Modify(g);
        }
        /// <summary>
        /// 充值面额
        /// </summary>
        /// <returns></returns>
        public List<Denomination> GetListDen()
        {
            return dal.GetListDen();
        }
        /// <summary>
        /// 新建面额
        /// </summary>
        /// <returns></returns>
        public int AddDenomination(Denomination a)
        {
            return dal.AddDenomination(a);
        }
        /// <summary>
        /// 充值记录查询
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="customerPhone"></param>
        /// <param name="denominationId"></param>
        /// <returns></returns>
        public List<RechargeRecord> GetRechargeRecord(string customerName, string customerPhone, int denominationId, int cusId)
        {
            return dal.GetRechargeRecord(customerName, customerPhone, denominationId);
        }

        public List<Customer> GetCustomerShow(int customerId, string customerName, string customerPhone, string customeridentity, int lableId, int whetherEnable, int cusId)
        {
            return dal.GetCustomerShow(customerId, customerName, customerPhone, customeridentity, lableId, whetherEnable, cusId);
        }

        public List<Customer> GetCustomerShow()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomerShow(string customerName, string customerPhone, string customeridentity, int lableId, int whetherEnable, int cusId)
        {
            throw new NotImplementedException();
        }
    }
}
