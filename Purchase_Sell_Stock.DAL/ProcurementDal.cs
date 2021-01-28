using Purchase_Sell_Stock.DAL.GetDBHelper;
using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model.ProcurementFunction;
using Purchase_Sell_Stock.Model.Buyer;
using Purchase_Sell_Stock.Model.GoodsFunction;
using Purchase_Sell_Stock.Model.Login;
using Purchase_Sell_Stock.Model.OrderFunction;
using Purchase_Sell_Stock.Model.Propertys;
using Purchase_Sell_Stock.Model.SettingModels;
using Purchase_Sell_Stock.Model.Storage;
using System.Linq;
using SqlSugar;

namespace Purchase_Sell_Stock.DAL
{
    /// <summary>
    /// 用于采购
    /// </summary>
    public class ProcurementDal
    {
        //实例化sugarhelper
        SqlSugerDBHelper sqlsugar = new SqlSugerDBHelper();

        /// <summary>
        /// 显示采购订单
        /// </summary>
        /// <returns></returns>
        public List<Procurement> GetProcurementsShow()
        {
            var _list = sqlsugar.GetInstance().Queryable<Procurement>().ToList();
            return _list;
        }
        /// <summary>
        /// 商品表显示
        /// </summary>
        /// <returns></returns>
        public List<Goods> GetGoodsShow()
        {
            var _list = sqlsugar.GetInstance().Queryable<Goods>().ToList();
            return _list;
        }



        /// <summary>
        /// 用于显示商品列表
        /// </summary>
        /// <param name="goodid"></param>
        /// <returns></returns>
        public List<Goodsbuyer> GetGoodsbuyersShow(string goodid)
        {
            //将字符串转换为数组
            //用于商品编号
            var goodided= goodid.Split(",");
            //实例化一个集合
            List<Goodsbuyer> list = new List<Goodsbuyer>();
            if (goodid=="0")
            {
                return null;
            }
            //查询出对应的商品
            for (int i = 0; i < goodided.Length; i++)
            {
                var dd = Convert.ToInt32(goodided[i]);
                //查出匹配的对象
                var _listed = sqlsugar.GetInstance().Queryable<Goods>().Where(x => x.GoodsId ==dd).First();
                if (_listed!=null)
                {
                    //实例化一个类
                    Goodsbuyer goodsbuyer = new Goodsbuyer();
                    //将获取到的值传入对象中
                    goodsbuyer.GoodsId = _listed.GoodsId;//商品编号
                    goodsbuyer.GoodsName = _listed.GoodsName; //商品名称
                    goodsbuyer.GoodsSize = _listed.GoodsSize;//商品规格
                    goodsbuyer.GoodsUnitName = _listed.GoodsUnitName;//单位
                    goodsbuyer.ProcurementPrice = Convert.ToInt32(_listed.ProcurementPrice);//进货价格
                    goodsbuyer.Total = Convert.ToInt32(_listed.ProcurementPrice);
                    //将对象加入到集合中
                    list.Add(goodsbuyer);
                }
                else
                {
                    return null;
                }
            }
            return list;

        }
        /// <summary>
        ///  添加
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="procurementGoodsNumed">数量</param>
        /// <param name="totaled">合计</param>
        /// <param name="goodid">商品编号</param>
        /// <returns></returns>
        public int AddProcurements(Procuert procuert)
        {
            //通过仓库名称获取仓库负责人
            var Wname= sqlsugar.GetInstance().Queryable<Warehouse>().Where(x => x.WarehouseName.Contains(procuert.ProcurementName)).First();
            //采购单号
            procuert.ProcurementNum = Guid.NewGuid().ToString();
            procuert.ProcurementCreator = Wname.WarehousePrincipal;
            procuert.ProcurementState = 0;
            procuert.StoreId = 1;
            var _list = sqlsugar.GetInstance().Insertable<Procurement>(new {
                
                ProcurementNum= procuert.ProcurementNum,
                ProviderName=procuert.ProviderName,
                ProcurementName=procuert.ProcurementName,
                ProcurementCreator=procuert.ProcurementCreator,
                ProcurementState=procuert.ProcurementState,
                ProcurementTime=procuert.ProcurementTime,
                StoreId=procuert.StoreId,
            }).ExecuteCommand();
            var ulist = sqlsugar.GetInstance().Queryable<Procurement>().ToList();
            var uprocurement = ulist.OrderByDescending(p => p.ProcurementId).FirstOrDefault();
            AddProcurementGoods(uprocurement.ProcurementId, procuert);
            return _list;
        }
        
        /// <summary>
        /// 添加采购表
        /// </summary>
        /// <param name="procurementId"></param>
        /// <returns></returns>
        public int AddProcurementGoods(int procurementId, Procuert procuert)
        {
            var count = 0;
            //转换为数组
            var goodids =  procuert.goodid.Split(",");
            var procurementGoodsNumeds = procuert.procurementGoodsNumed.Split(",");
            
            for (int i = 0; i < procurementGoodsNumeds.Length; i++)
            {
                var _list = GetGoodsShow().Where(x => x.GoodsId == Convert.ToInt32(goodids[i])).FirstOrDefault();
                count += sqlsugar.GetInstance().Insertable<ProcurementGoods>(new { 
                    ProcurementId= procurementId,  //采购表外键
                    ProcurementGoodsNum= Convert.ToInt32(procurementGoodsNumeds[i]),//采购商品数量
                    GoodsId= _list.GoodsId, //商品id
                    Total= Convert.ToInt32(Convert.ToInt32(procurementGoodsNumeds[i])*_list.ProcurementPrice),
                    Poutbound =0, //已入库
                }).ExecuteCommand();
            }
            return count;
        }

        #region 下拉
        /// <summary>
        /// 采购方(仓库)
        /// </summary>
        /// <returns></returns>
        public List<Warehouse> GetWarehousesShow()
        {
            var _list = sqlsugar.GetInstance().Queryable<Warehouse>().ToList();
            return _list;
        }
        /// <summary>
        /// 供应商
        /// </summary>
        /// <returns></returns>
        public List<Providers> GetProvidersShow()
        {
            var _list = sqlsugar.GetInstance().Queryable<Providers>().ToList();
            return _list;
        }
        #endregion


        #region 修改
        /// <summary>
        /// 审核通过
        /// </summary>
        /// <param name="ddd"></param>
        /// <returns></returns>
        public int UptProviders(int procurementId)
        {
            int i = sqlsugar.GetInstance().Updateable<Procurement>(new { ProcurementState=2 }).Where(x=>x.ProcurementId== procurementId).ExecuteCommand();
            if (i>0)
            {
               var Wname= sqlsugar.GetInstance().Queryable<Procurement>().Where(x => x.ProcurementId == procurementId).First();
                sqlsugar.GetInstance().Insertable<Incomingorder>(new {
                    IncomingorderOrderNumber=Guid.NewGuid(), //入库订单编号
                    ProcurementId= procurementId,//采购表外键
                    StorageTypeName="采购",      //入库类型
                    IncomingorderState=0,        //入库状态
                    WarehouseName= Wname.ProcurementName,//仓库
                    IncomingordercreationTime=DateTime.Now,//创建时间
                    IncomingorderTime=DateTime.Now,//入库时间
                    IncomingorderRemark= "采购",
                    CancelOrderId=0,
                }).ExecuteCommand();
            }
            return i;
        }
        #endregion
    }
}
