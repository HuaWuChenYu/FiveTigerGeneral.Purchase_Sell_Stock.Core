using Purchase_Sell_Stock.DAL;
using Purchase_Sell_Stock.IServices;
using Purchase_Sell_Stock.Model.GoodsFunction;
using Purchase_Sell_Stock.Model.ProcurementFunction;
using Purchase_Sell_Stock.Model.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Services
{
    /// <summary>
    /// 用于采购
    /// </summary>
    public class ProcurementBll : IProcurement
    {
        //调用dal层    
        ProcurementDal stdal = DalFactory.GetDal<ProcurementDal>("Procurement");
        /// <summary>
        /// 采购单显示
        /// </summary>
        /// <returns></returns>
        public List<Procurement> GetProcurementsShow()
        {
            var _list = stdal.GetProcurementsShow();
            return _list;
        }
        /// <summary>
        /// 商品表显示
        /// </summary>
        /// <returns></returns>
        public List<Goods> GetGoodsShow()
        {
            return stdal.GetGoodsShow();
        }


        /// <summary>
        /// 用于显示商品列表
        /// </summary>
        /// <param name="goodid"></param>
        /// <returns></returns>
        public List<Goodsbuyer> GetGoodsbuyersShow(string goodid)
        {
            return stdal.GetGoodsbuyersShow(goodid);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public int AddProcurements(Procuert procuert)
        {
            return stdal.AddProcurements(procuert);
        }
        /// <summary>
        /// 审核通过
        /// </summary>
        /// <param name="procurementId"></param>
        /// <returns></returns>
        public int UptProviders(int procurementId)
        {
            return stdal.UptProviders(procurementId);
        }

        #region 下拉
        /// <summary>
        /// 采购方(仓库)
        /// </summary>
        /// <returns></returns>
        public List<Warehouse> GetWarehousesShow()
        {
            return stdal.GetWarehousesShow();
        }
        /// <summary>
        /// 供应商
        /// </summary>
        /// <returns></returns>
        public List<Providers> GetProvidersShow()
        {
            return stdal.GetProvidersShow();
        }

     

        #endregion
    }
}
