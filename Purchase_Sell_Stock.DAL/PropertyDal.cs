using Purchase_Sell_Stock.DAL.GetDBHelper;
using Purchase_Sell_Stock.Model.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.DAL
{
    public class PropertyDal
    {

        /// <summary>
        /// 插入待结数据
        /// </summary>
        /// <returns></returns>

        DBHelper dB = GetDBHelper.SimplyFactoryDB.GetInstance("AdoDBHelper");
        public int AddAmount_settledInfos()
        {
            string sql = "insert  into Amount_settled values('1','20.33','2020-5-5','JD_10002','矿泉水')";
          
            return dB.ExecuteNonQuery("");
        }

        /// <summary>
        /// 插入余额数据
        /// </summary>
        /// <returns></returns>
        public int Addbalance_MoneyInfos()
        {
            string sql = "insert  into balance_Money values('1','20.33','2020-5-5','JD_10002','矿泉水')";
            return dB.ExecuteNonQuery("");
        }

       


    }
}
