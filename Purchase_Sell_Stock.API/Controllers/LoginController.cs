using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Purchase_Sell_Stock.Model.Login;
using Purchase_Sell_Stock.Services;
using Newtonsoft.Json;
using Purchase_Sell_Stock.IServices;

namespace Purchase_Sell_Stock.API.Controllers
{
    /// <summary>
    /// 登录控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        LoginBll bll = new LoginBll();
        private ILogin _login;
        public LoginController(ILogin login)
        {
            _login = login;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Login")]
        public int Login(Users users)
        {
            List<Users> list = _login.Login(users.UserPhone, users.UserPassword);
            if (list.Count>0)
            {
                return 1;
            }
            return 0;
        }
        /// <summary>
        /// 短信登陆
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Logins")]
        
        public List<Users> Logins(string phone)
        {
            List<Users> list = _login.Logins(phone);
            return list;
        }
        /// <summary>
        /// 忘记密码
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Forgers")]
        
        public int Forgers(Users g)
        {
            return _login.Forget(g);
        }


        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Register")]
        public int Register(Users a)
        {
            return _login.Register(a);
        }
    }
}
