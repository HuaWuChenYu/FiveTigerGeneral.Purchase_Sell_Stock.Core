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
            List<Users> users = dBHelper.GetList < Users>($"select * from Users UserAccount={name} where UserPassword={pwd}");
            return users;
        }
        public int ZhuCe(Users a)
        {
            int i = dBHelper.ExecuteNonQuery($"insert into Users values('{a.UserPhone}')");
            return i;
        }
    }
}
