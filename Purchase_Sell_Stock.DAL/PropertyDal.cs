using Purchase_Sell_Stock.DAL.GetDBHelper;
using Purchase_Sell_Stock.Model.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.DAL
{
    public class PropertyDal
    {
       
        //待结算数据插入
        public int Add()
        {
            string sql = "insert  into Amount_settled values('1','20.33','2020-5-5','JD_10002','矿泉水')";
            DBHelper dB= GetDBHelper.SimplyFactoryDB.GetInstance("AdoDBHelper");
            return dB.ExecuteNonQuery();
        }

       
       
        public List<Amount_settled> amount_SettledsShow() 
        {
            List<Amount_settled> am = new List<Amount_settled>();
            for (int i = 0; i < 6; i++)
            {
                am.Add(new Amount_settled { Amount_settleId = i, OrderId = '1', Amount_settledMoney = 20.33m, OrderSubmitTime = DateTime.Now, OrderUnm = "JD_1002", ProductName = "菲菲" });
            }
            return am;
        }


    }
}
