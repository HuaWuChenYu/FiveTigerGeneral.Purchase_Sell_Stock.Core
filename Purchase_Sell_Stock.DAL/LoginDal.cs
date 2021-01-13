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
            List<Users> users = dBHelper.GetList < Users>("");
            users.Add(new Users()
            {
                UserId = 1,
                //UserAccount = "海鲜"
            });
            return users;
        }
        //public List<Users> Forter(string name)
        //{ 
            
        //}
    }
}
