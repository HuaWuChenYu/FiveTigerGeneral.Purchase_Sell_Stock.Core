using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.DAL;
using Purchase_Sell_Stock.Model.Buyer;
using Purchase_Sell_Stock.Model.FirstFunction;
using Purchase_Sell_Stock.Model.GoodsFunction;
using Purchase_Sell_Stock.Model.Login;
using Purchase_Sell_Stock.Model.OrderFunction;
using Purchase_Sell_Stock.Model.ProcurementFunction;
using Purchase_Sell_Stock.Model.Propertys;
using Purchase_Sell_Stock.Model.Storage;
using Purchase_Sell_Stock.Model.SettingModels;
using Purchase_Sell_Stock.IServices;

namespace Purchase_Sell_Stock.Services
{
    public class FirstBll:IFirst
    {
        FirstDal dal = DalFactory.GetDal<FirstDal>("First");
        /// <summary>
        /// 获取店铺信息
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public Store GetStore(int storeId)
        {
            return dal.GetStore(storeId);
        }
        /// <summary>
        /// 获取帮助
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public List<Helps> GetHelp(int storeId)
        {
            return dal.GetHelp(storeId);
        }
        /// <summary>
        /// 获取消息
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public List<StoreMessage> GetStoreMessage(int storeId)
        {
            return dal.GetStoreMessage(storeId);
        }
        /// <summary>
        /// 新增订单数
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public int NewOrders(int storeId, int date)
        {
            return dal.NewOrders(storeId,date);
        }
        /// <summary>
        /// 支付金额
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public decimal orderMoney(int storeId, int date)
        {
            return dal.orderMoney(storeId, date);
        }
        /// <summary>
        /// 下单客户数
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public int orderUser(int storeId, int date)
        {
            return dal.orderUser(storeId, date);
        }
        /// <summary>
        /// 新增用户数
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public int newUser(int storeId, int date)
        {
            return dal.newUser(storeId, date);
        }
        /// <summary>
        /// 新增用户数
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public int activeUser(int storeId, int date)
        {
            return dal.activeUser(storeId, date);
        }
        /// <summary>
        /// 饼图
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public Cake Cake(int storeId)
        {
            return dal.Cake(storeId);
        }
        /// <summary>
        /// 商品销售排行
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public List<Goods> SellSum(int storeId)
        {
            return dal.SellSum(storeId);
        }
        /// <summary>
        /// 切换订单待办
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public List<Orders> ChangeOrder(int storeId)
        {
            return dal.ChangeOrder(storeId);
        }
        /// <summary>
        /// 切换入库待办
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public List<Incomingorder> ChangeIncomingorder(int storeId)
        {
            return dal.ChangeIncomingorder(storeId);
        }
        /// <summary>
        /// 切换采购待办
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public List<Procurement> ChangeProcurement(int storeId)
        {
            return dal.ChangeProcurement(storeId);
        }
    }
}
