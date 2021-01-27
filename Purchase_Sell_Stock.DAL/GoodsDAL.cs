using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
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
        SqlSugerDBHelper sqlSugerDB = new SqlSugerDBHelper();
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
        public GoodsPaging<Goods> GetGoodsList<Goods>(int pageIndex, int pageSize, string goodsName, string goodsType, string goodsClassify, int storeId)
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
        public List<GoodsType> GetGoodsTypeList<GoodsType>(int typeId, string typeName, int storeId)
        {
            string sql = "select * from GoodsType where 1 = 1 and StoreId = @StoreId and GoodsTypePId != 0";
            if (typeId != 0)
            {
                sql += " and GoodsTypeId = @typeId";
            }
            if (!string.IsNullOrEmpty(typeName))
            {
                sql += " and GoodsTypeName = @typeName";
            }

            List<GoodsType> list = dBDapper.GetList<GoodsType>(sql, new { typeId, typeName, storeId });
            return list;
        }
        /// <summary>
        /// 商品品牌查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="brandId"></param>
        /// <param name="brandName"></param>
        /// <returns></returns>
        public List<GoodsBrand> GetGoodsBrandList<GoodsBrand>(int brandId, string brandName, int storeId)
        {
            string sql = "select * from GoodsBrand where 1 = 1 and StoreId = @storeId";
            if (brandId != 0)
            {
                sql += " and GoodsBrandId = @brandId";
            }
            if (!string.IsNullOrEmpty(brandName))
            {
                sql += " and GoodsBrandName like @brandName";
            }
            List<GoodsBrand> list = dBDapper.GetList<GoodsBrand>(sql, new { brandId, brandName = '%' + brandName + '%', storeId });
            return list;
        }
        /// <summary>
        /// 删除品牌
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public int DelBrand(int brandId) 
        {
            string sql = "delete GoodsBrand where GoodsBrandId = @brandId";
            return dBDapper.ExecuteNonQuery(sql,new { brandId });
        }
        /// <summary>
        /// 商品单位查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="unitId"></param>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public List<GoodsUnit> GetGoodsUnitList<GoodsType>(int unitId, string unitName, int storeId)
        {
            string sql = "select * from GoodsUnit where 1 = 1 and StoreId = @storeId";
            if (unitId != 0)
            {
                sql += " and GoodsUnitId = @unitId";
            }
            if (!string.IsNullOrEmpty(unitName))
            {
                sql += " and GoodsUnitName like @unitName";
            }
            List<GoodsUnit> list = dBDapper.GetList<GoodsUnit>(sql,new { unitId , storeId, unitName = '%' + unitName + '%' });
            return list;
        }
        /// <summary>
        /// 删除单位
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public int DelUnit(int unitId)
        {
            string sql = "delete GoodsUnit where GoodsUnitId = @unitId";
            return dBDapper.ExecuteNonQuery(sql, new { unitId });
        }
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns> v  
        public int AddGoods(Goods goods)
        {
            string sql = $"insert into Goods values(@GoodsName,@GoodsPhoto,@GoodsSize,@Price,@ProcurementPrice,1,@Goodsclassify,@GoodsTypeName,@GoodsUnitName,@GoodsBrandName,@StoreId)";
            int i = dBDapper.ExecuteNonQuery(sql, goods);
            return i;
        }
        /// <summary>
        /// 添加商品分类
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns> v  
        public int AddGoodsType(GoodsType goods)
        {
            string sql = $"insert into GoodsType values(@GoodsTypeName,@GoodsTypePId,@StoreId)";
            int i = dBDapper.ExecuteNonQuery(sql, goods);
            return i;
        }
        /// <summary>
        /// 添加商品品牌
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns> v  
        public int AddGoodsBrand(GoodsBrand goods)
        {
            string sql = $"insert into GoodsBrand values(@GoodsBrandName,@StoreId)";
            int i = dBDapper.ExecuteNonQuery(sql, goods);
            return i;
        }
        /// <summary>
        /// 添加商品单位
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns> v  
        public int AddGoodsUnit(GoodsUnit goods)
        {
            string sql = $"insert into GoodsUnit values(@GoodsUnitName,@GoodsUnitGroup,@StoreId)";
            int i = dBDapper.ExecuteNonQuery(sql, goods);
            return i;
        }
        /// <summary>
        /// 修改上下架
        /// </summary>
        /// <param name="goodId"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public int ModifyState(int goodId)
        {
            string sql = $"update Goods set GoodsState = GoodsState-1 where GoodsId = @goodId";
            int i = dBDapper.ExecuteNonQuery(sql, new { goodId});
            return i;
        }
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="goodsIds"></param>
        /// <returns></returns>
        public int DeleteGoods(string goodsIds)
        {
            string sql = $"delete Goods where GoodsId in (@goodsIds)";
            int i = dBDapper.ExecuteNonQuery(sql, new { goodsIds});
            return i;
        }
        /// <summary>
        /// 根据Id查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Goods> GetGoodsById(int goodsId)
        {
            string sql = $"select * from Goods where GoodsId = @goodsId";
            List<Goods> list = dBDapper.GetList<Goods>(sql,new { goodsId });
            return list;
        }
        /// <summary>
        /// 修改商品单位
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public int ModifyGoods(Goods goods)
        {
            string sql = $"update Goods set GoodsName=@GoodsName,GoodsPhoto=@GoodsPhoto,GoodsSize=@GoodsSize,Price=@Price,ProcurementPrice=@ProcurementPrice,Goodsclassify=@Goodsclassify,GoodsTypeName=@GoodsTypeName,GoodsUnitName=@GoodsUnitName,GoodsBrandName=@GoodsBrandName where GoodsId = @GoodsId";
            int i = dBDapper.ExecuteNonQuery(sql, goods);
            return i;
        }
    }
}
