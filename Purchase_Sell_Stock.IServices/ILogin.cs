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
        int Forget(Users g);
        int Register(Users a);

    }
}
