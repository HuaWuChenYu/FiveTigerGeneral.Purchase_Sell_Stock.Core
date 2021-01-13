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
        public List<Customer> GetCustomer()
        {
            List<Customer> list = dBHelper.GetList<Customer>($"select * from Customer");
            return list;
        }
        //public List<>
    }
}
