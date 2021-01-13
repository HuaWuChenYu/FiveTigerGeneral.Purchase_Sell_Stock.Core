﻿using Purchase_Sell_Stock.Model.Propertys;
using Purchase_Sell_Stock.Model.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.IServices
{
    public interface IProperty
    {
        /// <summary>
        /// 插入待结数据
        /// </summary>
        /// <returns></returns>
        int AddAmount_settledInfos();

        /// <summary>
        /// 插入余额数据
        /// </summary>
        /// <returns></returns>
        int Addbalance_MoneyInfos();

        /// <summary>
        /// 插入充值记录数据
        /// </summary>
        /// <returns></returns>
        int AddRechanged_recordInfos();

        /// <summary>
        /// 插入详细账单数据
        /// </summary>
        /// <returns></returns>
        /// 
        int AddBilling_detailsInfos();

        /// <summary>
        /// 显示待结算信息
        /// </summary>
        /// <returns></returns>
        List<Amount_settledMoney> Amount_settledMoneyShowInfos();

        /// <summary>
        /// 显示余额信息
        /// </summary>
        /// <returns></returns>
        Coods_Page<balance_Money> balance_MoneyShowInfos(int pageIndex, int pageSize, string Order_num, string starttime_quantum, string endttime_quantum, string remark);

        /// <summary>
        /// 显示充值记录信息
        /// </summary>
        /// <returns></returns>
        List<Rechanged_record> Rechanged_recordShowInfos();

        /// <summary>
        /// 显示详细账单信息
        /// </summary>
        /// <returns></returns>
        List<Billing_details> Billing_detailsShowInfos();
    }
}
