using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model.Login;
using Purchase_Sell_Stock.DAL.GetDBHelper;

namespace Purchase_Sell_Stock.DAL
{
    public class LoginDal
    {
        DBHelper dBHelper = SimplyFactoryDB.GetInstance("Ado");
        DBHelper dBAdo = SimplyFactoryDB.GetInstance("Ado");
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public List<Users> Login(string phone, string pwd)
        {
            string sql = $"select * from Users where  UserPhone='{phone}' and UserPassword='{pwd}'";
             List<Users> list= dBAdo.GetList<Users>(sql);
            return list;
        }
        /// <summary>
        /// 短信登录
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public List<Users> Logins(string phone)
        {
            string sql = $"select * from Users where UserPhone='{phone}'";
            List<Users> list = dBAdo.GetList<Users>(sql);
            return list;
        }
        /// <summary>
        /// 忘记密码
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int Forget(Users g)
        {
            string sql = $"update Users set UserPhone={g.UserPhone} where UserPassword={g.UserPassword}";
            return dBAdo.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int Register(Users a)
        {
            string sql = $"insert into Users values('{a.UserAccount}','{a.UserPhone}','{a.UserPassword}')";
            return dBAdo.ExecuteNonQuery(sql);
        }
    }
}
