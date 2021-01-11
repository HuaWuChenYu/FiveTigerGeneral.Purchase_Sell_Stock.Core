using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model.SettingModels;
using Purchase_Sell_Stock.DAL.GetDBHelper;

namespace Purchase_Sell_Stock.DAL
{
    public class LoginDal
    {
        DBHelper dBHelper = SimplyFactoryDB.GetInstance("Ado");
        public List<Users> Login(string name, string pwd)
        {
            string sql = "";
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(pwd))
            {
                sql = $"select * from yh_Users where UserAccount='{name}' and UserPassword='{pwd}'";
            }
            return dBHelper.GetList<Users>();
        }
    }
}
