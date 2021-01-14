using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model;
using Purchase_Sell_Stock.Model.Storage;
using Purchase_Sell_Stock.Model.OrderFunction;

namespace Purchase_Sell_Stock.IServices
{
    public interface IStorage
    {
        /// <summary>
        /// 出库显示方法
        /// </summary>
        /// <returns></returns>
        List<OutboundorderCombine> OutboundorderShow();
        /// <summary>
        /// 详情信息
        /// </summary>
        /// <returns></returns>
        OutboundorderCombine OutboundorderCombinebackfill(int outboundorderid);//出库订单id
        /// <summary>
        /// 详情商品的显示
        /// </summary>
        /// <param name="outboundorderid"></param>
        /// <returns></returns>
        List<OutboundorderCombine> Outboundordercommoditybackfill(int outboundorderid);//出库订单id




        /// <summary>
        /// 入库订单显示
        /// </summary>
        /// <returns></returns>
        List<IncomingorderCombine> IncomingorderShow();
        /// <summary>
        /// 反填入库订单信息
        /// </summary>
        /// <returns></returns>
        IncomingorderCombine IncomingordermodityDetail(int incomingorderid);
        /// <summary>
        /// 反填入库订单商品
        /// </summary>
        /// <param name="incomingorderid"></param>
        /// <returns></returns>
        List<IncomingorderCombine> IncomingordermodityGoods(int incomingorderid);
    }
}
