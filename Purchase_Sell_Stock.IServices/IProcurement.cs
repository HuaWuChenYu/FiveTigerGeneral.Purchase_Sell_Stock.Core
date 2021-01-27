using Purchase_Sell_Stock.Model.GoodsFunction;
using Purchase_Sell_Stock.Model.ProcurementFunction;
using Purchase_Sell_Stock.Model.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.IServices
{
    public interface IProcurement
    {
        /// <summary>
        /// 显示采购订单
        /// </summary>
        /// <returns></returns>
        public List<Procurement> GetProcurementsShow();

        /// <summary>
        /// 商品表显示
        /// </summary>
        /// <returns></returns>
        public List<Goods> GetGoodsShow();


        /// <summary>
        /// 用于显示商品列表
        /// </summary>
        /// <param name="goodid"></param>
        /// <returns></returns>
        public List<Goodsbuyer> GetGoodsbuyersShow(string goodid);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public int AddProcurements(Procuert procuert);
        /// <summary>
        /// 审核通过
        /// </summary>
        /// <param name="ddd"></param>
        /// <returns></returns>
        public int UptProviders(int procurementId);

        #region 下拉
        /// <summary>
        /// 采购方(仓库)
        /// </summary>
        /// <returns></returns>
        public List<Warehouse> GetWarehousesShow();
        /// <summary>
        /// 供应商
        /// </summary>
        /// <returns></returns>
        public List<Providers> GetProvidersShow();
        #endregion
    }
}
