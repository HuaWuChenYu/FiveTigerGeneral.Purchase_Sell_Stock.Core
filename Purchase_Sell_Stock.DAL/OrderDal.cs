using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Purchase_Sell_Stock.DAL.GetDBHelper;
using Purchase_Sell_Stock.Model.OrderFunction;
using System.Data;

namespace Purchase_Sell_Stock.DAL
{
    /// <summary>
    /// 订单
    /// </summary>
    public class OrderDal
    {
        DBHelper dBDapper = SimplyFactoryDB.GetInstance("Dapper");
        DBHelper dBAdo = SimplyFactoryDB.GetInstance("Ado");
        SqlSugerDBHelper sqlSugerDB = new SqlSugerDBHelper();

        /// <summary>
        /// 查询订单
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orderState"></param>
        /// <param name="orderNum"></param>
        /// <param name="orderBelong"></param>
        /// <param name="sellType"></param>
        /// <param name="time"></param>
        /// <param name="person"></param>
        /// <param name="phone"></param>
        /// <param name="payType"></param>
        /// <param name="dispatchWay"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public OrderPaging<Orders> GetOrderList<Orders>(int orderState,string orderNum,string orderBelong,string sellType,string time,string person,string phone,string payType,string dispatchWay,int pageIndex, int pageSize,int storeId)
        {
            string sql = $"1 = 1 and od.StoreId = {storeId}";
            if (!string.IsNullOrEmpty(orderNum))
            {
                sql += $" and OrdersNum = {orderNum}";
            }
            if (!string.IsNullOrEmpty(orderBelong))
            {
                sql += $" and OrdersBelong = {orderBelong}";
            }
            if (!string.IsNullOrEmpty(sellType))
            {
                sql += $" and SellType = {sellType}";
            }
            if (!string.IsNullOrEmpty(time))
            {
                sql += $" and DispatchTime > {Convert.ToDateTime( time)}";
            }
            if (!string.IsNullOrEmpty(person))
            {
                sql += $" and CustomerName = {person}";
            }
            if (!string.IsNullOrEmpty(phone))
            {
                sql += $" and OrdersNum = {phone}";
            }
            if (!string.IsNullOrEmpty(payType))
            {
                sql += $" and DispatchWay = {payType}";
            }
            if (!string.IsNullOrEmpty(dispatchWay))
            {
                sql += $" and OrdersNum = {dispatchWay}";
            }
            if (orderState > 0)
            {
                sql += $" and OrdersState = {orderState}";
            }
            SqlParameter[] para = new SqlParameter[] {
                new SqlParameter(){ParameterName="@TableFields",DbType=DbType.String,Value= "od.*,cu.CustomerName,cu.CustomerPhone"},
                new SqlParameter(){ParameterName="@TableName",DbType=DbType.String,Value= "Customer cu join Orders od on cu.CustomerId = od.CustomerId"},
                new SqlParameter(){ParameterName="@SqlWhere",DbType=DbType.String,Value= sql },
                new SqlParameter(){ParameterName="@OrderBy",DbType=DbType.String,Value= "OrdersId"},
                new SqlParameter(){ParameterName="@PageIndex",DbType=DbType.Int32,Value=pageIndex },
                new SqlParameter(){ParameterName="@PageSize",DbType=DbType.Int32,Value= pageSize},
                new SqlParameter(){ParameterName="@TotalCount",DbType=DbType.Int32,Direction=ParameterDirection.Output},
            };
            List<Orders> listOrder = dBAdo.GetList<Orders>("Proc_Paging", para);
            OrderPaging<Orders> paging = new OrderPaging<Orders>()
            {
                Count = Convert.ToInt32(para[6].Value),
                list = listOrder
            };
            return paging;
        }
    }
}
