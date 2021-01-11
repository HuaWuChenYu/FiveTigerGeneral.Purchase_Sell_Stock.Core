using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Purchase_Sell_Stock.DAL.GetDBHelper;
using Purchase_Sell_Stock.Model.SettingModels;

namespace Purchase_Sell_Stock.DAL
{
    /// <summary>
    /// 用于设置
    /// </summary>
    public class SetDal
    {
        DBHelper dBHelper= SimplyFactoryDB.GetInstance("Dapper");
        public List<Classify> ClassifiesShow()
        {
            List<Classify> clist= dBHelper.GetList<Classify>("");
            clist.Add(new Classify() { ClassifyId = 1, ClassifyName = "海鲜" });
            return clist;
        }
    }
}
