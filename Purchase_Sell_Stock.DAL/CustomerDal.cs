using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model.SettingModels;
using Purchase_Sell_Stock.DAL.GetDBHelper;
using Purchase_Sell_Stock.Model.Buyer;

namespace Purchase_Sell_Stock.DAL
{
    
    /// <summary>
    /// 用于做客户
    /// </summary>
    public class CustomerDal
    {
        DBHelper dBHelper = SimplyFactoryDB.GetInstance("Ado");
        /// <summary>
        /// 显示出全部的客户
        /// </summary>
        /// <returns></returns>
        /// 
        public List<Customer> GetCustomer()
        {
            List<Customer> list = dBHelper.GetList<Customer>($"select * from Customer");
            return list;
        }
        public List<Customer> GetCustomers(int customerId, string customerName, string customerPhone, string customerIdentity, int lableId, string whetherEnable)
        {
            string sql = $"select * from Customer where 1=1";
            if (customerId!=0)
            {
                sql += $" and CustomerId=@id" + ",new {id=" + $"{customerId}" + "}";
            }
            if (!string.IsNullOrEmpty(customerName))
            {
                sql += $" and CustomerName=@name" + ",new {name=" + $"{customerName}" + "}";
            }
            if (!string.IsNullOrEmpty(customerPhone))
            {
                sql += $" and CustomerPhone=@phone" + ",new {phone=" + $"{customerPhone}" + "}";
            }
            if (!string.IsNullOrEmpty(customerIdentity))
            {
                sql += $" and CustomerIdentity=@identity" + ",new {identity=" + $"{customerIdentity}" + "}";
            }
            if (lableId!=0)
            {
                sql += $" and LableId=@labId" + ",new {labId=" + $"{lableId}" + "}";
            }
            if (!string.IsNullOrEmpty(whetherEnable))
            {
                sql += $" and WhetherEnable=@Enable" + ",new {Enable=" + $"{whetherEnable}" + "}";
            }
            List<Customer> list = SimplyFactoryDB.GetInstance("Dapper").GetList<Customer>(sql);
            return list;
        }
        //public List<>
    }
}
