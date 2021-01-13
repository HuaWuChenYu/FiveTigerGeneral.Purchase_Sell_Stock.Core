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
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public List<Users> Login(string name, string pwd)
        {
            string sql = "";
            if (!string.IsNullOrEmpty(name)&&!string.IsNullOrEmpty(pwd))
            {
                sql = $"select * Users where UserAccount={name} and UserPassword={pwd}";
            }
            return dBHelper.GetList<Users>(sql);
        }
        /// <summary>
        /// 短信登录
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public List<Users> Logins(string phone)
        {
            string sql = $"";
            if (!string.IsNullOrEmpty(phone))
            {
                sql = $"select * from Users where UserPhone={phone}";
            }
            return dBHelper.GetList<Users>(sql);
        }
        /// <summary>
        /// 忘记密码
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Users> Forget(string name)
        {
            string sql = $"";
            if (!string.IsNullOrEmpty(name))
            {
                sql = $"select * from Users where UserName={name}";
            }
            return dBHelper.GetList<Users>(sql);
        }
        /// <summary>
        /// 注册s
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int Register(Users a)
        {
            string sql = $"insert into Users values({a.UserPhone})";
            return dBHelper.ExecuteNonQuery(sql);
        }
    }
}
