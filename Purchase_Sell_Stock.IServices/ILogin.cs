using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model.SettingModels;

namespace Purchase_Sell_Stock.IServices
{
    public interface ILogin
    {
        List<Users> Login(string name, string pwd);
        List<Users> Logins(string phone);
        List<Users> Forget(string name);
        int Register(Users a);

    }
}
