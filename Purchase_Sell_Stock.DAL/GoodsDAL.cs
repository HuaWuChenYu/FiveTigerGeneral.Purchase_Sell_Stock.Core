using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Purchase_Sell_Stock.DAL.GetDBHelper;
using Purchase_Sell_Stock.Model.GoodsFunction;
using System.Data;

namespace Purchase_Sell_Stock.DAL
{
    /// <summary>
    /// 商品表
    /// </summary>
    public class GoodsDal
    {
        DBHelper dBDapper = SimplyFactoryDB.GetInstance("Dapper");
        DBHelper dBAdo = SimplyFactoryDB.GetInstance("Ado");
        /// <summary>
        /// 查询商品
        /// </summary>
        /// <typeparam name="Goods"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="goodsName"></param>
        /// <param name="goodsType"></param>
        /// <param name="goodsClassify"></param>
        /// <returns></returns>
        public GoodsPaging<Goods> GetGoodsList<Goods>(int pageIndex, int pageSize, string goodsName, string goodsType, string goodsClassify)
        {
            string sql = $"1 = 1";
            if (!string.IsNullOrEmpty(goodsName))
            {
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
            List<Goods> listGoods = dBAdo.GetList<Goods>("Proc_Paging", para);
            GoodsPaging<Goods> paging = new GoodsPaging<Goods>()
            {
                Count = Convert.ToInt32(para[6].Value),
                list = listGoods
            };
            return paging;
        }
        /// <summary>
        /// 商品分类查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeId"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public List<GoodsType> GetGoodsTypeList<GoodsType>(int typeId, string typeName)
        {
            string sql = "select * from GoodsType where 1 = 1";
            if (typeId != 0)
            {
                sql += " and GoodsTypeId = @id" + ",new {id=" + $"{typeId}" + "}";
            }
            if (!string.IsNullOrEmpty(typeName))
            {
                sql += " and GoodsTypeName = @name" + ",new {name=" + $"{typeName}" + "}";
            }
            List<GoodsType> list = dBDapper.GetList<GoodsType>(sql);
            return list;
        }
        /// <summary>
        /// 商品品牌查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="brandId"></param>
        /// <param name="brandName"></param>
        /// <returns></returns>
        public List<GoodsBrand> GetGoodsBrandList<GoodsBrand>(int brandId, string brandName)
        {
            string sql = "select * from GoodsBrand where 1 = 1";
            if (brandId != 0)
            {
                sql += " and GoodsBrandId = @id";
            }
            if (!string.IsNullOrEmpty(brandName))
            {
                sql += " and GoodsBrandName = @name";
            }
            List<GoodsBrand> list = dBDapper.GetList<GoodsBrand>(sql);
            return list;
        }
        /// <summary>
        /// 商品单位查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="unitId"></param>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public List<GoodsUnit> GetGoodsUnitList<GoodsType>(int unitId, string unitName)
        {
            string sql = "select * from GoodsUnit where 1 = 1";
            if (unitId != 0)
            {
                sql += " and GoodsUnitId = @id" + ",new {id=" + $"{unitId}" + "}";
            }
            if (!string.IsNullOrEmpty(unitName))
            {
                sql += " and GoodsUnitName = @name" + ",new {name=" + $"{unitName}" + "}";
            }
            List<GoodsUnit> list = dBDapper.GetList<GoodsUnit>(sql);
            return list;
        }
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public int AddGoods(Goods goods)
        {
            string sql = $"insert into Goods values(@GoodsName,@GoodsPhoto,@GoodsSize,@Price,@ProcurementPrice,@GoodsState,@Goodsclassify,@GoodsTypeName,@GoodsUnitName,@GoodsBrandName,@StoreId)";
            int i = dBDapper.ExecuteNonQuery(sql);
            //int i = dBDapper.ExecuteNonQuery(sql, new { goods });
            return i;
        }
    }
}
