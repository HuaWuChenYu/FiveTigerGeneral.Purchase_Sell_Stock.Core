using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model.SettingModels;
using Purchase_Sell_Stock.DAL.GetDBHelper;
using Purchase_Sell_Stock.Model.Buyer;
using System.Data.SqlClient;
using System.Data;

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
        public CustomerPaging GetCustomerList<Customer>(int pageIndex, int pageSize, int customerId, string customerName, string customerPhone, string customerIdentity, int lableId, string whetherEnable)
        {
            string sql = $"select * from Customer where 1=1";
            if (customerId != 0)
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
            if (lableId != 0)
            {
                sql += $" and LableId=@labId" + ",new {labId=" + $"{lableId}" + "}";
            }
            if (!string.IsNullOrEmpty(whetherEnable))
            {
                sql += $" and WhetherEnable=@Enable" + ",new {Enable=" + $"{whetherEnable}" + "}";
            }
            SqlParameter[] para = new SqlParameter[] {
                new SqlParameter(){ParameterName="@TableFields",DbType=DbType.String,Value= "*"},
                new SqlParameter(){ParameterName="@TableName",DbType=DbType.String,Value= "Goods"},
                new SqlParameter(){ParameterName="@SqlWhere",DbType=DbType.String,Value= sql },
                new SqlParameter(){ParameterName="@OrderBy",DbType=DbType.String,Value= "GoodsId"},
                new SqlParameter(){ParameterName="@PageIndex",DbType=DbType.Int32,Value=pageIndex },
                new SqlParameter(){ParameterName="@PageSize",DbType=DbType.Int32,Value= pageSize},
                new SqlParameter(){ParameterName="@@TotalCount",DbType=DbType.Int32,Direction=ParameterDirection.Output},
            };
            List<Customer> lists = SimplyFactoryDB.GetInstance("Ado").GetList<Customer>("",para);
            CustomerPaging paging = new CustomerPaging()
            {
                Count = Convert.ToInt32(para[6].Value),
                list = lists as List<Model.Buyer.Customer>
            };
            return paging;
        }
        public List<RechargeRecord> GetRechargeRecord(string customerName, string customerPhone, int denominationId)
        {
            string sql = $"select * from RechargeRecord where 1=1";
            if (!string.IsNullOrEmpty(customerName))
            {
                sql += " and CustomerName=@name" + ",new {name=" + $"{customerName}" + "}";
            }
            if (!string.IsNullOrEmpty(customerPhone))
            {
                sql += " and CustomerPhone=@phone" + ",new {phone=" + $"{customerPhone}" + "}";
            }
            if (denominationId!=0)
            {
                sql += " and DenominationId=@id" + ",new {id=" + $"{denominationId}" + "}";
            }
            List<RechargeRecord> list = SimplyFactoryDB.GetInstance("Dapper").GetList<RechargeRecord>(sql);
            return list;
        }
    }
}
