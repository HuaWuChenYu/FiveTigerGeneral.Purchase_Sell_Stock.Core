using Purchase_Sell_Stock.DAL;
using System.Collections.Generic;
using Purchase_Sell_Stock.Model.SettingModels;
using Purchase_Sell_Stock.IServices;

namespace Purchase_Sell_Stock.Services
{
    /// <summary>
    /// 用于设置
    /// </summary>
    public class SetBll :ISet
    {   
        SetDal _dal = DalFactory.GetDal<SetDal>("Set");
        public List<Classify> ClassifiesShow()
        {
            return _dal.ClassifiesShow();
        }
    }
}
