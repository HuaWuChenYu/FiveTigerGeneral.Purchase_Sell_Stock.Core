using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model.SettingModels;
using Purchase_Sell_Stock.DAL;
using Purchase_Sell_Stock.IServices;

namespace Purchase_Sell_Stock.Services
{
    public class LoginBll:ILogin
    {
        LoginDal dal = new LoginDal();

        public int Forget(Users g)
        {
            return dal.Register(g);
        }

        public List<Users> Login(string name, string pwd)
        {
            return dal.Login(name, pwd);
        }

        public List<Users> Logins(string phone)
        {
            return dal.Logins(phone);
        }

        public int Register(Users a)
        {
            return dal.Register(a);
        }
    }
}
