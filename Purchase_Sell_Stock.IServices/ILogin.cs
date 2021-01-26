using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model.Login;

namespace Purchase_Sell_Stock.IServices
{
    public interface ILogin
    {
        /// <summary>
        /// 判断是不是员工还是老板
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int IsEmployeeOrBoss(int id);
        /// <summary>
        /// 账号登录
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        List<Users> Login(string phone, string pwd);
        /// <summary>
        /// 短信登录
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        List<Users> Logins(string phone);
        /// <summary>
        /// 忘记密码
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        int Forget(Users g);
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        int Register(Users a);

    }
}
