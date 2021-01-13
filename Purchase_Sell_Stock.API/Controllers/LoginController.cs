using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Purchase_Sell_Stock.Model.SettingModels;
using Purchase_Sell_Stock.Services;

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
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Login")]
        public List<Users> Login(string name, string pwd)
        {
            var list = bll.Login(name, pwd);
            return list;
        }
        [HttpPost]
        [Route("/api/Logins")]
        /// <summary>
        /// 短信登陆
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public List<Users> Logins(string phone)
        {
            var list = bll.Logins(phone);
            return list;
        }
        [HttpPost]
        [Route("/api/Forgers")]
        /// <summary>
        /// 忘记密码
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Users> Forgers(string name)
        {
            var list = bll.Forget(name);
            return list;
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
            int i = bll.Register(a);
            return i;
        }
    }
}
