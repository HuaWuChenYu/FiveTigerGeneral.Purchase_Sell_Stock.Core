using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model.Login;
using Purchase_Sell_Stock.DAL;
using Purchase_Sell_Stock.IServices;

namespace Purchase_Sell_Stock.Services
{
    public class LoginBll:ILogin
    {
        LoginDal dal = new LoginDal();
        /// <summary>
        /// 判断是不是员工还是老板
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int IsEmployeeOrBoss(int id)
        {
            return dal.IsEmployeeOrBoss(id);
        }
        /// <summary>
        /// 忘记密码
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public int Forget(Users g)
        {
            return dal.Register(g);
        }
        /// <summary>
        /// 账号登录
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public List<Users> Login(string phone, string pwd)
        {
            return dal.Login(phone, pwd);
        }
        /// <summary>
        /// 短信登录
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public List<Users> Logins(string phone)
        {
            return dal.Logins(phone);
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int Register(Users a)
        {
            return dal.Register(a);
        }
    }
}
