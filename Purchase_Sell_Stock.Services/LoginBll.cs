using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model.SettingModels;
using Purchase_Sell_Stock.DAL;

namespace Purchase_Sell_Stock.Services
{
    public class LoginBll
    {
        LoginDal dal = new LoginDal();

        public List<Users> Login(string name, string pwd)
        {
            return dal.Login(name, pwd);
        }
    }
}
