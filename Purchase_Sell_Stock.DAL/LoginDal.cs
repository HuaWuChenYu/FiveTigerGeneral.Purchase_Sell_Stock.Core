using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model.SettingModels;

namespace Purchase_Sell_Stock.DAL
{
    public class LoginDal
    {
        GetDBHelper.DBHelper db = new GetDBHelper.DBHelper();
        public List<Users> Login(string name, string pwd)
        {
            string sql = "";
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(pwd))
            {
                sql = $"select * from yh_Users where UserAccount='{name}' and UserPassword='{pwd}'";
            }
            return db.GetList<Users>(sql);
        }
    }
}
