using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Purchase_Sell_Stock.Model.SettingModels;
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
        private ILogin _login;
        public LoginController(ILogin login)
        {
            _login = login;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/Login")]
        public List<Users> Login(string name, string pwd)
        {
            List<Users> list = _login.Login(name, pwd);
            return list;
        }    
        [HttpGet]
        [Route("/api/Logins/{phone}")]
        /// <summary>
        /// 短信登陆
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public List<Users> Logins(string phone)
        {
            List<Users> list = _login.Logins(phone);
            return list;
        }
        [HttpGet]
        [Route("/api/Forgers")]
        /// <summary>
        /// 忘记密码
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int Forgers(Users g)
        {
            return _login.Forget(g);
        }

        [HttpPost]
        [Route("/api/Register")]
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int Register(Users a)
        {
            return _login.Register(a);
        }
    }
}
