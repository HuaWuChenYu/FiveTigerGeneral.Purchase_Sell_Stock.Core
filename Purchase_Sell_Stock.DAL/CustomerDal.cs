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
        DBHelper dBDapper = SimplyFactoryDB.GetInstance("Dapper");
        DBHelper dBAdo = SimplyFactoryDB.GetInstance("Ado");
        SqlSugerDBHelper sqlSugerDB = new SqlSugerDBHelper();
        
        public List<Customer> GetCustomerShow(string customerName, string customerPhone, string customeridentity, int lableId, int whetherEnable)
        {
            string sql = $"select * from Customer";
            if (!string.IsNullOrEmpty(customerName))
            {
                sql += $" and CustomerName like '%{customerName}%'";
            }
            if (!string.IsNullOrEmpty(customerPhone))
            {
                sql += $" and CustomerPhone= '%{customerPhone}%'";
            }
            if (!string.IsNullOrEmpty(customeridentity))
            {
                sql += $" and Customeridentity= '%{customeridentity}%'";
            }
            if (lableId != 0)
            {
                sql += " and LableId= lableId";
            }
            if (whetherEnable != 0)
            {
                sql += " and WhetherEnable= whetherEnable";
            }
            List<Customer> list = dBAdo.GetList<Customer>(sql);
            return list;
        }
        /// <summary>
        /// 充值记录查询
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="customerPhone"></param>
        /// <param name="denominationId"></param>
        /// <returns></returns>
        public List<RechargCustomer> GetRechargeRecord(string customerName, string customerPhone, int denominationId)
        {
            string sql = $"select * from RechargeRecord a join Customer b on a.RechargeId=b.CustomerId join Denomination c on c.DenominationId=b.CustomerId";
            if (!string.IsNullOrEmpty(customerName))
            {
                sql += $" and CustomerName like '%{customerName}%'";
            }
            if (!string.IsNullOrEmpty(customerPhone))
            {
                sql += $" and CustomerPhone= '%{customerPhone}%'";
            }
            if (denominationId!=0)
            {
                sql +=$" and DenominationId= {denominationId}";
            }
            List<RechargCustomer> list = dBAdo.GetList<RechargCustomer>(sql);
            return list;
        }
       
        /// <summary>
        /// 添加标签
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int GetLable(Lable a)
        {
            string sql = $"insert into Lable values('{a.LableName}',0,'{a.LableExplain}','{DateTime.Now}')";
            var i= dBAdo.ExecuteNonQuery(sql);
            return i;
        }

        

        /// <summary>
        /// 用户标签
        /// </summary>
        /// <returns></returns>
        public List<Lable> GetLableShow()
        {
            string sql = $"select * from Lable";
            List<Lable> list = dBAdo.GetList<Lable>(sql);
            return list;
        }
        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int LableDelete(string ids)
        {
            string sql = $"delete Lable where LableId in ({ids})";
            return dBAdo.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 标签反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Lable> Ft(int id)
        {
            string sql = $"select * from Lable where LableId={id}";
            List<Lable> list = dBAdo.GetList<Lable>(sql);
            return list;
        }
        /// <summary>
        /// 标签修改
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public int Modify(Lable g)
        {
            string sql = $"update Lable set LableName='{g.LableName}', LableExplain='{g.LableExplain}' where LableId={g.LableId}";
            return dBAdo.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 充值面额
        /// </summary>
        /// <returns></returns>
        public List<Denomination> GetListDen()
        {
            string sql = "select * from Denomination";
            List<Denomination> list = dBAdo.GetList<Denomination>(sql);
            return list;
        }
        /// <summary>
        /// 新建面额
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int AddDenomination(Denomination a)
        {
            string sql = $"insert into Denomination values('{a.DenominationLable}','{a.DenominationMoney}','{a.ActuallyMoney}','{a.GivenMoney}',0,'{a.PeriodValidity}',0)";
            int i= dBAdo.ExecuteNonQuery(sql);
            return i;
        }
        /// <summary>
        /// 钱包查询
        /// </summary>
        /// <returns></returns>
        public List<wallet> GetWallet(string customerName, string customerPhone)
        {
            string sql = $"select * from PurseRecord a join Customer b on a.MounyId=b.CustomerId";
            if (!string.IsNullOrEmpty(customerName))
            {
                sql += $" and CustomerName like '%{customerName}%'";
            }
            if (!string.IsNullOrEmpty(customerPhone))
            {
                sql += $" and CustomerPhone= '%{customerPhone}%'";
            }
            List<wallet> list = dBAdo.GetList<wallet>(sql);
            return list;
        }
        /// <summary>
        /// 流水表
        /// </summary>
        /// <returns></returns>
        public List<Water> GetWater()
        {
            string sql = "select * from Water";
            List<Water> list = dBAdo.GetList<Water>(sql);
            return list;
        }
        public List<Water> LSFt(int ids)
        {
            string sql = $"select * from Water where LXId={ids}";
            List<Water> list = dBAdo.GetList<Water>(sql);
            return list;
        }
    }
}
