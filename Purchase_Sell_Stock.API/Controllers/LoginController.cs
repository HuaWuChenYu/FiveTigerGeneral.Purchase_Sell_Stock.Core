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
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

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
        private readonly ILogger<CustomerController> _logined;

        public LoginController(ILogin login, ILogger<CustomerController> loggered)
        JwtBuilder _jwt;
        public LoginController(ILogin login, JwtBuilder _builder)
        {
            _login = login;
            _jwt = _builder;
            _logined = loggered;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("/api/Login/GetToken")]
        public string GetToken(Users users)
        {
            string token = _jwt.GetJwt(users);
            return token;
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
                int s = _login.IsEmployeeOrBoss(list[0].UserId);
                return s;
                _logined.LogInformation($"{users.UserPhone}登录成功");
                return 1;
            }
            return 0;
        }
        /// <summary>
        /// 短信登陆
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Logins")]
        public int Logins(Users users)
        {
            List<Users> list = _login.Logins(users.UserPhone);
            if (list.Count > 0)
            {
                int s = _login.IsEmployeeOrBoss(list[0].UserId);
                return s;
            }
            return 0;
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
            _logined.LogInformation($"{g}忘记密码");
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
            _logined.LogInformation($"注册{a}成功");
            return _login.Register(a);
        }
    }
}
