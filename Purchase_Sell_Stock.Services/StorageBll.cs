﻿using Purchase_Sell_Stock.IServices;
using Purchase_Sell_Stock.Model.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.DAL;
using Purchase_Sell_Stock.Model.OrderFunction;

namespace Purchase_Sell_Stock.Services
{
    /// <summary>
    /// 用于仓储
    /// </summary>
    public class StorageBll : IStorage
    {
         
        //调用dal层
        StorageDal stdal = DalFactory.GetDal<StorageDal>("Storage");

        #region 入库 
        /// <summary>
        /// 入库订单的显示
        /// </summary>
        /// <returns></returns>
        public List<IncomingorderCombine> IncomingorderShow()
        {
            var _list = stdal.IncomingorderShow();
            return _list;
        }
        /// <summary>
        /// 反填入库信息
        /// </summary>
        /// <param name="incomingorderid"></param>
        /// <returns></returns>
        public IncomingorderCombine IncomingordermodityDetail(int incomingorderid)
        {
            var _list = stdal.IncomingordermodityDetail(incomingorderid);
            return _list;
        }
        /// <summary>
        /// 反填入库商品
        /// </summary>
        /// <param name="incomingorderid"></param>
        /// <returns></returns>
        public List<IncomingorderCombine> IncomingordermodityGoods(int incomingorderid)
        {
            var _list = stdal.IncomingordermodityGoods(incomingorderid);
            return _list;
        }
        #endregion


        #region 出库
        /// <summary>
        /// 反填详细信息
        /// </summary>
        /// <returns></returns>
        public OutboundorderCombine OutboundorderCombinebackfill(int outboundorderid)
        {
            var _list = stdal.OutboundorderCombinebackfill(outboundorderid);
            return _list;
        }

        
        /// <summary>
        /// 出库商品的反填
        /// </summary>
        /// <param name="outboundorderid"></param>
        /// <returns></returns>
        public List<OutboundorderCombine> Outboundordercommoditybackfill(int outboundorderid)
        {
            List<OutboundorderCombine> _list = stdal.Outboundordercommoditybackfill(outboundorderid);
            return _list;
        }
        /// <summary>
        /// 出库订单显示
        /// </summary>
        /// <returns></returns>
        public List<OutboundorderCombine> OutboundorderShow()
        {
            var _list= stdal.OutboundorderShow();
            return _list;
        }
        #endregion

    }
}
