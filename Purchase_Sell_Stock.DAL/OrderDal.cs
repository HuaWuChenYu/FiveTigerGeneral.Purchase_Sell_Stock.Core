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

        public OrderPaging<Orders> GetGoodsList<Orders>(int pageIndex, int pageSize, string goodsName, string goodsType, string goodsClassify, int storeId)
        {
            string sql = $"1 = 1 and StoreId = {storeId}";
            if (!string.IsNullOrEmpty(goodsName))
            {
                goodsName = goodsName.Substring(1);
                sql += $" and GoodsName like '%{goodsName}%'";
            }
            if (!string.IsNullOrEmpty(goodsType))
            {
                sql += $" and GoodsTypeName = '{goodsType}'";
            }
            if (!string.IsNullOrEmpty(goodsClassify))
            {
                sql += $" and Goodsclassify = '{goodsClassify}'";
            }
            SqlParameter[] para = new SqlParameter[] {
                new SqlParameter(){ParameterName="@TableFields",DbType=DbType.String,Value= "*"},
                new SqlParameter(){ParameterName="@TableName",DbType=DbType.String,Value= "Goods"},
                new SqlParameter(){ParameterName="@SqlWhere",DbType=DbType.String,Value= sql },
                new SqlParameter(){ParameterName="@OrderBy",DbType=DbType.String,Value= "GoodsId"},
                new SqlParameter(){ParameterName="@PageIndex",DbType=DbType.Int32,Value=pageIndex },
                new SqlParameter(){ParameterName="@PageSize",DbType=DbType.Int32,Value= pageSize},
                new SqlParameter(){ParameterName="@TotalCount",DbType=DbType.Int32,Direction=ParameterDirection.Output},
            };
            List<Orders> listGoods = dBAdo.GetList<Orders>("Proc_Paging", para);
            OrderPaging<Orders> paging = new OrderPaging<Orders>()
            {
                Count = Convert.ToInt32(para[6].Value),
                list = listGoods
            };
            return paging;
        }
    }
}
