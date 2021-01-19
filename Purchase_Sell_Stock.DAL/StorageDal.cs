using Purchase_Sell_Stock.DAL.GetDBHelper;
using Purchase_Sell_Stock.Model.Buyer;
using Purchase_Sell_Stock.Model.GoodsFunction;
using Purchase_Sell_Stock.Model.OrderFunction;
using Purchase_Sell_Stock.Model.ProcurementFunction;
using Purchase_Sell_Stock.Model.Storage;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Purchase_Sell_Stock.DAL
{
    /// <summary>
    /// 用于仓储
    /// </summary>
    public class StorageDal
    {
        //实例化sugarhelper
        SqlSugerDBHelper sqlsugar = new SqlSugerDBHelper();
        
        //定义变量用于计算每个商品的出库数量
        int[] OutNumber = new int [100];
        //定义把变量用于计算每个商品的入库数量
        int[] InNumber = new int[100];
        /// <summary>
        /// 出库订单显示
        /// </summary>
        /// <returns></returns>
        public List<OutboundorderCombine> OutboundorderShow()
        {
            List<OutboundorderCombine> outboundorderlist = new List<OutboundorderCombine>();

            //显示所有的出库订单   
            var outboundorderlists = sqlsugar.GetInstance().Queryable<Outboundorder, Orders, Warehouse, StorageType, Customer>
             ((a, b, c, d, e) => new object[] { JoinType.Inner, a.OrdersId == b.OrdersId, JoinType.Inner, a.WarehouseId == c.WarehouseId, JoinType.Inner, a.StorageTypeId == d.StorageTypeId, JoinType.Inner, b.CustomerId == e.CustomerId, })
             .Where((a, b, c, d, e) => b.OrdersState == 2)
             .Select((a, b, c, d, e) => new OutboundorderCombine
             {
                 OrdersId = b.OrdersId, //订单id
                OutboundorderId = a.OutboundorderId,//订单id
                OutboundorderOrderNumber = a.OutboundorderOrderNumber,    //出库订单编号
                OrdersNum = b.OrdersNum,                                  //订单编号（来源单号）
                WarehouseName = c.WarehouseName,                          //仓库名称（发货方）
                CustomerName = e.CustomerName,                            //收货方名称（客户名称）
                Adress = e.Adress,                                           //收货方地址(客户地址)
                CustomerPhone = e.CustomerPhone,                             //手机号
                StorageTypeName = d.StorageTypeName,                      //出库类型
                /*OutboundGoodsNum        = OutNumber, */              //商品数量
                OutboundorderState = a.OutboundorderState,                //状态
                OutboundordercreationTime = a.OutboundordercreationTime,  //创建时间
                OutboundorderTime = a.OutboundorderTime,                  //出库时间
                OutboundorderRemark = a.OutboundorderRemark,               //备注
            }).ToList();

            var outboundorderlistss = sqlsugar.GetInstance().Queryable<Outboundorder, CancleProcurement, Providers, StorageType>((a, b, c, d) => new object[] {
             JoinType.Inner,a.CancleProcurementId==b.CancleProcurementId,
             JoinType.Inner,b.ProviderName==c.ProvidersName,
             JoinType.Inner,a.StorageTypeId==d.StorageTypeId,
            }).Where((a, b, c, d) => a.StorageTypeId == 2).Where((a, b, c, d) => b.CancleProcurementState == 2).Select((a, b, c, d) => new OutboundorderCombine()
            {
                CancleProcurementId = a.CancleProcurementId,    //采购退货表id
                OutboundorderOrderNumber = a.OutboundorderOrderNumber,  //出货订单编号
                OutboundorderId = a.OutboundorderId,              //出库订单id
                OrdersNum = b.CancleProcurementNum,                //退货采购订单编号(来源单号)
                WarehouseName = b.CancleProcurementName,             //仓库,
                CustomerName = c.ProvidersName,                      //收货方(供应商)
                Adress = c.ProvidersAddress,                   //地址(地址没写)
                CustomerPhone = c.ProvidersPhone,                     //供应商电话
                StorageTypeName = d.StorageTypeName,                    //类型,
                OutboundorderState = a.OutboundorderState,                 //状态,
                OutboundordercreationTime = a.OutboundordercreationTime,          //创建时间,
                OutboundorderTime = a.OutboundorderTime,                  //出库时间,
                OutboundorderRemark = a.OutboundorderRemark,                //备注,
            }).ToList();

            List<OutboundorderCombine> listMerge2 = outboundorderlists.Concat(outboundorderlistss).ToList();//允许出现重复项
            return listMerge2;

        }

        /// <summary>
        /// 出货订单商品
        /// </summary>
        /// <param name="ordersnum"></param>
        /// <returns></returns>
        public List<OutboundorderCombine> OutboundordercommodityShow(string ordersnum)//ordersnum 订单编号
        { //商品表  //订单表 //商品订单表
            var _list = sqlsugar.GetInstance().Queryable<Orders, OrdersGoods, Goods>((a, b, c) => new object[] {
             JoinType.Inner,b.OrdersId==a.OrdersId,
             JoinType.Inner,b.GoodsId==c.GoodsId,
            }).Where((a, b, c) => a.OrdersState == 1 && a.OrdersNum.Contains(ordersnum)).Select((a, b, c) => new OutboundorderCombine()
            {
                GoodsId = a.OrdersId, //商品编码
                GoodsName = c.GoodsName,//商品名称
                GoodsSize = c.GoodsSize, //规格
                GoodsUnitName = c.GoodsUnitName,//单位
                OrdersGoodsNum = b.OrdersGoodsNum, //数量
                 
            }).ToList();
            return _list;
        }
        /// <summary>
        /// 退货订单商品
        /// </summary>
        /// <returns></returns>
        public List<OutboundorderCombine> OutboundorderCombinesTuiGoods(string ordersnum)
        {
            // select * from CancleProcurementGoods a join CancleProcurement b on a.CancleProcurementId=b.CancleProcurementId join Goods c on a.GoodsId=c.GoodsId where a.CancleProcurementId=1
            //商品表 //采购退货商品表 //采购表
            var _list = sqlsugar.GetInstance().Queryable<CancleProcurementGoods, CancleProcurement, Goods>((a, b, c) => new object[] {
             JoinType.Inner,a.CancleProcurementId==b.CancleProcurementId,
             JoinType.Inner,a.GoodsId==c.GoodsId,
            }).Where((a, b, c) => b.CancleProcurementState == 2).Select((a, b, c) => new OutboundorderCombine
            {
                GoodsId = c.GoodsId,   //商品编码
                GoodsSize = c.GoodsSize,//商品规格
                GoodsName = c.GoodsName,//商品名称
                GoodsUnitName = c.GoodsUnitName,//商品单位
                OrdersGoodsNum = a.CancleProcurementGoodsNum,//商品数量
                

            }).ToList();
            return null;
        }
        /// <summary>
        /// 反填详细信息
        /// </summary>
        /// <returns></returns>
        public OutboundorderCombine OutboundorderCombinebackfill(int outboundorderid) //出库订单id
        {
            //通过出库订单中的id来获取订单信息
            var _list = OutboundorderShow().FirstOrDefault(x => x.OutboundorderId == outboundorderid);
            return _list;
        }
        /// <summary>
        /// 反填商品信息
        /// </summary>
        /// <returns></returns>
        public List<OutboundorderCombine> Outboundordercommoditybackfill(int outboundorderid)//出单编号
        {
            //获取订单表中的订单编号（主键）
            var list_ordersnum = OutboundorderShow().FirstOrDefault(x => x.OutboundorderId == outboundorderid).OrdersNum;
            var _list = sqlsugar.GetInstance().Queryable<Orders, OrdersGoods, Goods>((a, b, c) => new object[] {
             JoinType.Inner,b.OrdersId==a.OrdersId,
             JoinType.Inner,b.GoodsId==c.GoodsId,
            }).Where((a, b, c) =>  a.OrdersNum.Contains(list_ordersnum)).Select((a, b, c) => new OutboundorderCombine()
            {
                GoodsId = a.OrdersId, //商品编码
                GoodsName = c.GoodsName,//商品名称
                GoodsSize = c.GoodsSize, //规格
                GoodsUnitName = c.GoodsUnitName,//单位
                OrdersGoodsNum = b.OrdersGoodsNum,
            }).ToList();
            for (int i = 0; i < _list.Count; i++)
            {
                _list[i].OutboundorderNumber = OutNumber[i];
            }
            //查询采购退货的商品
            var tui_list = sqlsugar.GetInstance().Queryable<CancleProcurementGoods, CancleProcurement, Goods>((a, b, c) => new object[] {
             JoinType.Inner,a.CancleProcurementId==b.CancleProcurementId,
             JoinType.Inner,a.GoodsId==c.GoodsId,
            }).Where((a, b, c) => b.CancleProcurementNum.Contains(list_ordersnum)).Select((a, b, c) => new OutboundorderCombine
            {
                GoodsId = c.GoodsId,   //商品编码
                GoodsSize = c.GoodsSize,//商品规格
                GoodsName = c.GoodsName,//商品名称
                GoodsUnitName = c.GoodsUnitName,//商品单位
                OrdersGoodsNum = a.CancleProcurementGoodsNum,//商品数量
                

            }).ToList();
            //循环赋值
            for (int i = 0; i < tui_list.Count; i++)
            {
                tui_list[i].OutboundorderNumber = OutNumber[i];
            }
             
           
            //将两个集合合并成一个集合
            List<OutboundorderCombine> _listall = _list.Concat(tui_list).ToList();
            return _listall;
        }

        //修改商品出库数量(对应的商品库存数量减)            //来源单号                     //出库数量
        public int GoodsAmend(/*string[] arr1,*/string arr2,string arr4,string sourcenumber, int outboundorderId)
        {
            //获取商品名称 商品编号，出库数量

            //查询出所有的库存
            //这里需要查询库存表 (库存表，商品表，库存表联查)
            var _list = sqlsugar.GetInstance().Queryable<CommodityStocks, Goods, Warehouse>((a, b, c) => new object[] {
             JoinType.Inner,a.GoodsId==b.GoodsId,JoinType.Inner,a.WarehouseId==c.WarehouseId
            }).Select((a, b, c) => new CommodityStocksandGoods
            {
                CommodityStocksId = a.CommodityStocksId,//库存id
                GoodsId = b.GoodsId, //商品编号
                GoodsName = b.GoodsName,//商品名称
                GoodsSize = b.GoodsSize,//商品规格
                GoodsUnitName = b.GoodsUnitName,//商品单位名称
                Inventory = a.Inventory, //库存数量
                vendibilityInventory = a.vendibilityInventory, //可售库存数量
                WarehouseId = c.WarehouseId,//仓库id
                WarehouseName = c.WarehouseName, //仓库名
                WarehousePrincipal = c.WarehousePrincipal,//执行人
            }).ToList();
            var d= arr2.ToString().Split(",");
            var m = arr4.ToString().Split(",");
            //var n= ordersgoodsnum.ToString().Split(",");
            
            //查看该订单所有的商品
            List<OutboundorderCombine> list = Outboundordercommoditybackfill(outboundorderId);
            var dit = 0;
            //流水账单
            var list_insert = 0;
            //实例化流水表
            GoodRunningWater runningWater = new GoodRunningWater();
            for (int i = 0; i < d.Length; i++)
            {
                var _dd= _list.Where(x => x.GoodsName.Contains(d[i])).FirstOrDefault();
                if (_dd.Inventory < 0 && _dd.Inventory < Convert.ToInt32(m[i]))
                {
                    OutboundorderCombinebackfill(outboundorderId).OutboundorderState = 0;
                    return 0;
                }
                //判断减的数量是或否等于要求的数量
                if (list[i].OrdersGoodsNum == Convert.ToInt32(m[i]))
                {
                    dit++;
                   
                }
                
                _dd.Inventory -= Convert.ToInt32(m[i]);
                
                _dd.vendibilityInventory-= Convert.ToInt32(m[i]);
                list[i].OutboundorderNumber += Convert.ToInt32(m[i]);
                OutNumber[i] = list[i].OutboundorderNumber;
                //如果库存量不够就返回库存量不足 无法出货
                //用于添加流水表
                runningWater.GoodsId = _dd.GoodsId;                             //商品编号
                runningWater.Inventory = _dd.Inventory;                         //库存
                runningWater.vendibilityInventory = _dd.vendibilityInventory;   //可售库存
                runningWater.GoodsName = _dd.GoodsName;                         //商品名称
                runningWater.WarehouseName = _dd.WarehouseName;                 //仓库
                runningWater.GoodsSize = _dd.GoodsSize;                         //商品规格
                runningWater.GoodsUnitName = _dd.GoodsUnitName;                 //商品单位
                runningWater.ChuKu = "-"+ m[i];                                 //出库数量
                runningWater.ResidueWarehouse = _dd.Inventory;                  //剩余库存
                runningWater.SourceNumber = sourcenumber;                       //来源单号
                if (runningWater.ChuKu.Contains("-"))
                {
                    runningWater.Source = "出库";
                }
                if (runningWater.ChuKu.Contains("+"))
                {
                    runningWater.Source = "入库";
                }//来源 
                runningWater.Operator = _dd.WarehousePrincipal;             //操作人                
                list_insert += sqlsugar.GetInstance().Insertable(runningWater).ExecuteCommand();
            }
            //状态改变
            if (dit==d.Count())
            {
                OutboundorderCombinebackfill(outboundorderId).OutboundorderState = 1;

            }
            

            return list_insert;

        }

        /// <summary>
        /// 商品以及商品库存显示
        /// </summary>
        /// <returns></returns>
        public List<CommodityStocksandGoods> commodityStocksandGoodsShow()
        {
            //这里需要查询库存表 (库存表，商品表，库存表联查)
            var _list = sqlsugar.GetInstance().Queryable<CommodityStocks, Goods, Warehouse>((a, b, c) => new object[] {
             JoinType.Inner,a.GoodsId==b.GoodsId,JoinType.Inner,a.WarehouseId==c.WarehouseId
            }).Select((a, b, c) => new CommodityStocksandGoods
            {
                CommodityStocksId = a.CommodityStocksId,//库存id
                GoodsId = b.GoodsId, //商品编号
                GoodsName = b.GoodsName,//商品名称
                GoodsSize = b.GoodsSize,//商品规格
                GoodsUnitName = b.GoodsUnitName,//商品单位名称
                Inventory = a.Inventory, //库存数量
                vendibilityInventory = a.vendibilityInventory, //可售库存数量
                WarehouseId = c.WarehouseId,//仓库id
                WarehouseName = c.WarehouseName, //仓库名
                WarehousePrincipal = c.WarehousePrincipal,//执行人
            }).ToList();
            return _list;
        }
        /// <summary>
        /// 流水记录表
        /// </summary>
        /// <returns></returns>
        public List<GoodRunningWater> goodRunningWaterShow()
        {
            var _list = sqlsugar.GetInstance().Queryable<GoodRunningWater>().ToList();
            return _list;
        }








        /// <summary>
        /// 入库订单显示
        /// </summary>
        /// <returns></returns>
        public List<IncomingorderCombine> IncomingorderShow()
        {

            //入库订单    //采购订单 //仓库表
            var into_list = sqlsugar.GetInstance().Queryable<Incomingorder, Procurement, Warehouse, StorageType>
            ((a, b, c, d) => new object[] {
             JoinType.Inner,a.ProcurementId==b.ProcurementId, //入库订单与采购表关联
             JoinType.Inner,a.WarehouseName==c.WarehouseName, //仓库表与入库订单关联
              JoinType.Inner,a.StorageTypeName==d.StorageTypeName,//仓库表与类型表关联
            }).Where((a, b, c,d) => b.ProcurementState == 2).Select((a, b, c,d) => new IncomingorderCombine
            {
                IncomingorderId = a.IncomingorderId, //入库订单的主键
                IncomingorderOrderNumber = a.IncomingorderOrderNumber,  //入库单号
                ProcurementNum = b.ProcurementNum,//来源单号
                WarehouseName = c.WarehouseName, //收货方
                ProviderName = b.ProviderName,//发货方(采购方)
                StorageTypeName = a.StorageTypeName,//入库类型
                ProvidersAddress=c.Warehouselocation,//收货方地址
                ProvidersPhone=c.WarehousePrincipalPhone,//收货方电话
                //IncomingorderNumber=a.IncomingorderNumber//商品总数
                IncomingorderState = a.IncomingorderState, //入库状态
                IncomingordercreationTime = a.IncomingordercreationTime,//创建时间
                IncomingorderTime = a.IncomingorderTime,//入库时间
                IncomingorderRemark = a.IncomingorderRemark//备注
            }).ToList();

            //退单表  //订单表 //订单商品表
                var tui_list = sqlsugar.GetInstance().Queryable<Incomingorder, CancelOrder, Orders, Customer, Warehouse, StorageType>((a, b, c, d, e, f) => new object[] {
              JoinType.Inner,a.CancelOrderId==b.CancelOrderId, //入库订单与退款单
              JoinType.Inner, b.OrdersId==c.OrdersId,
              JoinType.Inner,c.CustomerId==d.CustomerId,
              JoinType.Inner,a.WarehouseName==e.WarehouseName,
              JoinType.Inner,a.StorageTypeName==f.StorageTypeName

            }).Where((a, b, c, d, e, f) => f.StorageTypeId == 2 && b.CancelOrderState == 1).Select((a, b, c, d, e, f) => new IncomingorderCombine
            {
                IncomingorderId = a.IncomingorderId, //入库订单的主键
                IncomingorderOrderNumber = a.IncomingorderOrderNumber,  //入库单号
                ProcurementNum = b.CancelOrderNumber,//来源单号
                WarehouseName = e.WarehouseName, //收货方
                ProviderName = d.CustomerName,//发货方(下单方)
                StorageTypeName = f.StorageTypeName,//入库类型
                ProvidersAddress = e.Warehouselocation,//收货方地址
                ProvidersPhone = e.WarehousePrincipalPhone,//收货方电话
                //IncomingorderNumber=a.IncomingorderNumber//商品总数
                IncomingorderState = a.IncomingorderState, //入库状态
                IncomingordercreationTime = a.IncomingordercreationTime,//创建时间
                IncomingorderTime = a.IncomingorderTime,//入库时间
                IncomingorderRemark = a.IncomingorderRemark//备注
            }).ToList();
            List<IncomingorderCombine> _list = into_list.Concat(tui_list).ToList();
            return _list;
        }
        /// <summary>
        /// 入库订单商品
        /// </summary>
        /// <returns></returns>
        public List<IncomingorderCombine> IncomingordermodityShow(int incomingorderid)//采购表的id
        {               ////通过入库订单的id查询出采购单的id 
            var _procurementid = IncomingorderShow().FirstOrDefault(x => x.IncomingorderId == incomingorderid).ProcurementId;
            //将采购订单商品表 与 商品表关联
            var _list = sqlsugar.GetInstance().Queryable<ProcurementGoods, Goods>((a, b) => new object[] {
             JoinType.Inner,a.GoodsId==b.GoodsId
            }).Select((a, b) => new IncomingorderCombine
            {
                ProcurementGoodsId = a.ProcurementGoodsId,//采购订单表主键
                GoodsId = b.GoodsId, //商品编号
                GoodsName = b.GoodsName, //商品名称
                GoodsSize = b.GoodsSize, //规格
                GoodsUnitName = b.GoodsUnitName, //单位
                ProcurementGoodsNum = a.ProcurementGoodsNum, //总数量
                
            }).ToList();
            //在通过采购单的id去查询订单商品表 
            var ingood_list = _list.Where(x => x.ProcurementGoodsId == _procurementid && x.ProcurementState == 2).ToList();
            return ingood_list;

        }
        /// <summary>
        /// 入库详情信息
        /// </summary>
        /// <param name="incomingorderid"></param>
        /// <returns></returns>
        public IncomingorderCombine IncomingordermodityDetail(int incomingorderid) //入库订单Id
        {
            var _ado = IncomingorderShow().FirstOrDefault(x => x.IncomingorderId == incomingorderid);
            return _ado;
        }
        /// <summary>
        /// 反填入库商品
        /// </summary>
        /// <param name="incomingorderid"></param>
        /// <returns></returns>
        public List<IncomingorderCombine> IncomingordermodityGoods(int incomingorderid) ////入库订单Id
        {
            //根据入库订单id查询出来源单号 
            var procurementNum = IncomingorderShow().FirstOrDefault(x => x.IncomingorderId == incomingorderid).ProcurementNum;
            //采购订单表 //采购订单商品表 //商品表 联查  根据来源单号以及该单号的状态查询出该来源单号的商品数据
            var goods_list = sqlsugar.GetInstance().Queryable<Procurement, ProcurementGoods, Goods>((a, b, c) => new object[] {
             JoinType.Inner,b.ProcurementId==a.ProcurementId,
             JoinType.Inner,b.GoodsId==c.GoodsId,
            }).Where((a, b, c) => a.ProcurementNum == procurementNum).Select((a, b, c) => new IncomingorderCombine
            {
                GoodsId = c.GoodsId, //商品编码
                GoodsName = c.GoodsName,//商品名称
                GoodsSize = c.GoodsSize,//商品规格
                GoodsUnitName = c.GoodsUnitName,//商品单位
                ProcurementGoodsNum = b.ProcurementGoodsNum,//入库数量(商品数量)
                
            }).ToList();
            for (int i = 0; i < goods_list.Count; i++)
            {
                goods_list[i].IncomingorderNumber= InNumber[i];
            }

            //订单编号  查询出退单表所有的信息
            //var _ss = sqlsugar.GetInstance().Queryable<CancelOrder>().ToList();
            //根据订单状态 和 退单编号查询出订单号
            //var orders = _ss.FirstOrDefault(x => x.CancelOrderId == procurementid && x.CancelOrderState == 1).OrdersId;
            // 订单表 订单商品表 商品表  根据订单号和状态查询出该订单的商品
            var tui_list = sqlsugar.GetInstance().Queryable<CancelOrder, Orders, OrdersGoods, Goods>((a, b, c,d) => new object[] {
                JoinType.Inner,a.OrdersId==b.OrdersId, //退货表与订单表联查
                JoinType.Inner,c.OrdersId==b.OrdersId,
                JoinType.Inner,c.GoodsId==d.GoodsId,
            }).Where((a,b,c,d)=>a.CancelOrderNumber== procurementNum).Select((a, b, c,d) => new IncomingorderCombine
            {
                GoodsId = c.GoodsId, //商品编码
                GoodsName = d.GoodsName,//商品名称
                GoodsSize = d.GoodsSize,//商品规格
                GoodsUnitName = d.GoodsUnitName,//商品单位
                ProcurementGoodsNum = c.OrdersGoodsNum,//入库数量(商品数量)
                 
            }).ToList();
            for (int i = 0; i < tui_list.Count; i++)
            {
                tui_list[i].IncomingorderNumber = InNumber[i];
            }
            var _list = goods_list.Concat(tui_list).ToList();
            return _list;
        }
        /// <summary>
        /// 确定入库
        /// </summary>
        /// <returns></returns>
                                 //存商品名称 存入库数量
        public int Storage(string arr2, string arr4, string sourcenumber, int incomingorderid)
        {
            //首先获取商品的库存  库存 商品模型 仓库
            var _list = sqlsugar.GetInstance().Queryable<CommodityStocks, Goods, Warehouse>((a, b, c) => new object[] {
             JoinType.Inner,a.GoodsId==b.GoodsId,JoinType.Inner,a.WarehouseId==c.WarehouseId
            }).Select((a, b, c) => new CommodityStocksandGoods
            {
                CommodityStocksId = a.CommodityStocksId,//库存id
                GoodsId = b.GoodsId, //商品编号
                GoodsName = b.GoodsName,//商品名称
                GoodsSize = b.GoodsSize,//商品规格
                GoodsUnitName = b.GoodsUnitName,//商品单位名称
                Inventory = a.Inventory, //库存数量
                vendibilityInventory = a.vendibilityInventory, //可售库存数量
                WarehouseId = c.WarehouseId,//仓库id
                WarehouseName = c.WarehouseName, //仓库名
                WarehousePrincipal = c.WarehousePrincipal,//执行人
            }).ToList();
            //商品名称
            var d = arr2.ToString().Split(",");
            //入库数量
            var m = arr4.ToString().Split(",");
            //var n= ordersgoodsnum.ToString().Split(",");
            //流水账单
            var list_insert = 0;
            //查询出所有的单号所有的商品
            List<IncomingorderCombine> _listed = IncomingordermodityGoods(incomingorderid);
            //定义计数器  用来计算判断改变装填  计数器
            int dit = 0;
              
            GoodRunningWater runningWater = new GoodRunningWater();
            for (int i = 0; i < d.Length; i++)
            {
                var _dd = _list.Where(x => x.GoodsName.Contains(d[i])).FirstOrDefault();
                //判断单号上的商品的数量
                if (_listed[i].ProcurementGoodsNum < 0 && _listed[i].ProcurementGoodsNum < Convert.ToInt32(m[i]))
                {
                    OutboundorderCombinebackfill(incomingorderid).OutboundorderState = 0;
                    return 0;
                }
                //判断入库的数量是否等于入库的数量
                if (_listed[i].ProcurementGoodsNum == Convert.ToInt32(m[i]))
                {
                    dit++;
                   
                }
                
                runningWater.GoodsId = _dd.GoodsId;                         //商品编号
                runningWater.Inventory = _dd.Inventory;                     //库存
                runningWater.vendibilityInventory = _dd.vendibilityInventory;//可售库存
                runningWater.GoodsName = _dd.GoodsName;                     //商品名称
                runningWater.WarehouseName = _dd.WarehouseName;             //仓库
                runningWater.GoodsSize = _dd.GoodsSize;                     //商品规格
                runningWater.GoodsUnitName = _dd.GoodsUnitName;             //商品单位
                runningWater.ChuKu = "+" + m[i];                             //入库数量
                runningWater.ResidueWarehouse = _dd.Inventory;              //剩余库存
                runningWater.SourceNumber = sourcenumber;                         //来源
                if (runningWater.ChuKu.Contains("+"))
                {
                    runningWater.Source = "出库";
                }
                if (runningWater.ChuKu.Contains("+"))
                {
                    runningWater.Source = "入库";
                }//来源 
                runningWater.Operator = _dd.WarehousePrincipal;             //操作人    
                //执行完之后 在将库存量加进去

                _dd.Inventory += Convert.ToInt32(m[i]);
                _dd.vendibilityInventory += Convert.ToInt32(m[i]);
                //添加收货数量
                _listed[i].IncomingorderNumber += Convert.ToInt32(m[i]);
                //将这个收货数量赋值给一个数组  然后再将这个数组给了每个商品的收货数量
                InNumber[i] = _listed[i].IncomingorderNumber;
                list_insert += sqlsugar.GetInstance().Insertable(runningWater).ExecuteCommand();

            }
            if (dit == d.Count())
            {
                OutboundorderCombinebackfill(incomingorderid).OutboundorderState = 1;
            }
            //状态改变


            return list_insert;
        }


        /// <summary>
        /// 显示所有的仓库
        /// </summary>
        /// <returns></returns>

        public List<Warehouse> GetWarehousesShow()
        {
            var _list = sqlsugar.GetInstance().Queryable<Warehouse>().ToList();
            return _list;
        }
        /// <summary>
        /// 仓库类型
        /// </summary>
        /// <returns></returns>
        public List<WarehouseType> GetWarehouseTypesShow()
        {
            var _list = sqlsugar.GetInstance().Queryable<WarehouseType>().ToList();
            return _list;
        }
        /// <summary>
        /// 出入库类型
        /// </summary>
        /// <returns></returns>
        public List<StorageType> GetStorageTypesShow()
        {
            var _list = sqlsugar.GetInstance().Queryable<StorageType>().ToList();
            return _list;
        }

    }
}
