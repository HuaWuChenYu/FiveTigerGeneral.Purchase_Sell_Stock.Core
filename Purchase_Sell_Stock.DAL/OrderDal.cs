using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Purchase_Sell_Stock.DAL.GetDBHelper;
using Purchase_Sell_Stock.Model.OrderFunction;
using Purchase_Sell_Stock.Model.GoodsFunction;
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
        public OrderPaging<Orders> GetOrderList<Orders>(int orderState,string orderNum,string sellType,string time,string person,string phone,string payType,int pageIndex, int pageSize,int storeId)
        {
            string sql = $"1 = 1 and od.StoreId = {storeId}";
            if (!string.IsNullOrEmpty(orderNum))
            {
                sql += $" and OrdersNum like '%{orderNum}%'";
            }
            if (!string.IsNullOrEmpty(sellType))
            {
                sql += $" and SellType = '{sellType}'";
            }
            if (!string.IsNullOrEmpty(time))
            {
                sql += $" and OrdersTime >= '{Convert.ToDateTime( time)}'";
            }
            if (!string.IsNullOrEmpty(person))
            {
                sql += $" and CustomerName like '%{person}%'";
            }
            if (!string.IsNullOrEmpty(phone))
            {
                sql += $" and CustomerPhone like '%{phone}%'";
            }
            if (!string.IsNullOrEmpty(payType))
            {
                sql += $" and PayWay = '{payType}'";
            }
            if (orderState > 0)
            {
                sql += $" and OrdersState = {orderState}";
            }
            SqlParameter[] para = new SqlParameter[] {
                new SqlParameter(){ParameterName="@TableFields",DbType=DbType.String,Value= "od.*,cu.CustomerName,cu.CustomerPhone"},
                new SqlParameter(){ParameterName="@TableName",DbType=DbType.String,Value= "Customer cu join Orders od on cu.CustomerId = od.CustomerId"},
                new SqlParameter(){ParameterName="@SqlWhere",DbType=DbType.String,Value= sql },
                new SqlParameter(){ParameterName="@OrderBy",DbType=DbType.String,Value= "OrdersState"},
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
        /// <summary>
        /// 订单明细上
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Orders GetOrderById_1(int orderId)
        {
            string sql = "select * from Orders od join Customer cu on od.CustomerId = cu.CustomerId where OrdersId = @orderId";
            Orders orders = dBDapper.GetList<Orders>(sql,new { orderId})[0];
            return orders;
        }
        /// <summary>
        /// 订单明细下
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<Goods> GetOrderById_2(int orderId)
        {
            string sql = "select gd.*,og.OrdersGoodsNum from OrdersGoods og join Goods gd on og.GoodsId = gd.GoodsId where OrdersId = @orderId";
            List<Goods> list = dBDapper.GetList<Goods>(sql, new { orderId });
            return list;
        }
        /// <summary>
        /// 订单发货
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public int ModifyOrderState(int orderId)
        {
            string sql = "update Orders set OrdersState = 3 where OrdersId = @orderId";
            int i = dBDapper.ExecuteNonQuery(sql, new { orderId });
            return i;
        }

        //=======================================================//
        /// <summary>
        /// 查询退单
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="CancelOrderNumber"></param>
        /// <param name="PayMoney"></param>
        /// <param name="goState"></param>
        /// <param name="cancelState"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public OrderPaging<CancelOrder> CancelOrderList<CancelOrder>(string cancelOrderNumber, string ordersNum, int goState, int cancelState, string time, int storeId, int pageIndex, int pageSize)
        {
            string sql = $"1 = 1 and od.StoreId = {storeId}";
            if (!string.IsNullOrEmpty(cancelOrderNumber))
            {
                sql += $" and CancelOrderNumber like '%{cancelOrderNumber}%'";
            }
            if (!string.IsNullOrEmpty(ordersNum))
            {
                sql += $" and OrdersNum like '%{ordersNum}%'";
            }
            if (!string.IsNullOrEmpty(time))
            {
                sql += $" and CancelOrderTime >= '{Convert.ToDateTime(time)}'";
            }
            if (goState > 0)
            {
                sql += $" and OrdersState = '{goState}'";
            }
            if (cancelState > 0)
            {
                sql += $" and CancelOrderState = '{cancelState}'";
            }
            SqlParameter[] para = new SqlParameter[] {
                new SqlParameter(){ParameterName="@TableFields",DbType=DbType.String,Value= "co.*,OrdersState,OrdersNum,PayMoney"},
                new SqlParameter(){ParameterName="@TableName",DbType=DbType.String,Value= "CancelOrder co join Orders od on co.OrdersId = od.OrdersId"},
                new SqlParameter(){ParameterName="@SqlWhere",DbType=DbType.String,Value= sql },
                new SqlParameter(){ParameterName="@OrderBy",DbType=DbType.String,Value= "CancelOrderState"},
                new SqlParameter(){ParameterName="@PageIndex",DbType=DbType.Int32,Value=pageIndex },
                new SqlParameter(){ParameterName="@PageSize",DbType=DbType.Int32,Value= pageSize},
                new SqlParameter(){ParameterName="@TotalCount",DbType=DbType.Int32,Direction=ParameterDirection.Output},
            };
            List<CancelOrder> listOrder = dBAdo.GetList<CancelOrder>("Proc_Paging", para);
            OrderPaging<CancelOrder> paging = new OrderPaging<CancelOrder>()
            {
                Count = Convert.ToInt32(para[6].Value),
                list = listOrder
            };
            return paging;
        }
        /// <summary>
        /// 退单明细
        /// </summary>
        /// <param name="cancelOrderId"></param>
        /// <returns></returns>
        public CancelOrderOneViewModel GetCancelOneById(int orderId)
        {
            string sql = "select * from CancelOrder co join Orders od on co.OrdersId = od.OrdersId join Customer cm on cm.CustomerId = od.CustomerId where od.OrdersId = @orderId";
            CancelOrderOneViewModel cancelModel = dBDapper.GetList<CancelOrderOneViewModel>(sql, new { orderId })[0];
            return cancelModel;
        }
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public int ModifyCancelState(int orderId)
        {
            string sql = "update CancelOrder set CancelOrderState = 2 where OrdersId = @orderId";
            int i = dBDapper.ExecuteNonQuery(sql, new { orderId });
            return i;
        }

        //================================================================//

        /// <summary>
        /// 查询评价
        /// </summary>
        /// <typeparam name="Comment"></typeparam>
        /// <param name="content"></param>
        /// <param name="person"></param>
        /// <param name="time"></param>
        /// <param name="type"></param>
        /// <param name="storeId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public OrderPaging<Comment> CommentList<Comment>(string content, string person, string time, string type, int storeId, int pageIndex, int pageSize)
        {
            string sql = $"1 = 1 and od.StoreId = {storeId}";
            if (!string.IsNullOrEmpty(content))
            {
                sql += $" and CommentContent like '%{content}%'";
            }
            if (!string.IsNullOrEmpty(person))
            {
                sql += $" and CustomerName like '%{person}%'";
            }
            if (!string.IsNullOrEmpty(time))
            {
                sql += $" and CommentTime >= '{Convert.ToDateTime(time)}'";
            }
            if (!string.IsNullOrEmpty(type))
            {
                sql += $" and CommentType = '{type}'";
            }
            SqlParameter[] para = new SqlParameter[] {
                new SqlParameter(){ParameterName="@TableFields",DbType=DbType.String,Value= "cm.*,CustomerName,OrdersNum"},
                new SqlParameter(){ParameterName="@TableName",DbType=DbType.String,Value= "Comment cm join Orders od on od.OrdersId = cm.OrdersId join Customer cu on cu.CustomerId = od.CustomerId"},
                new SqlParameter(){ParameterName="@SqlWhere",DbType=DbType.String,Value= sql },
                new SqlParameter(){ParameterName="@OrderBy",DbType=DbType.String,Value= "CommentTime desc"},
                new SqlParameter(){ParameterName="@PageIndex",DbType=DbType.Int32,Value=pageIndex },
                new SqlParameter(){ParameterName="@PageSize",DbType=DbType.Int32,Value= pageSize},
                new SqlParameter(){ParameterName="@TotalCount",DbType=DbType.Int32,Direction=ParameterDirection.Output},
            };
            List<Comment> listOrder = dBAdo.GetList<Comment>("Proc_Paging", para);
            OrderPaging<Comment> paging = new OrderPaging<Comment>()
            {
                Count = Convert.ToInt32(para[6].Value),
                list = listOrder
            };
            return paging;
        }
        /// <summary>
        /// 回复评价
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public int ReplyComment(int commentId, string content)
        {
            string sql = "update Comment set Reply = @content where CommentId = @commentId";
            int i = dBDapper.ExecuteNonQuery(sql, new { commentId,content });
            return i;
        }

    }
}
