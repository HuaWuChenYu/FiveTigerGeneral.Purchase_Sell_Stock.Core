using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.SettingModels
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class Users
    {
        /// <summary>
        /// 用户主键
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 用户账号
        /// </summary>
        public int UserAccount { get; set; }
        /// <summary>
        /// 用户手机号
        /// </summary>
        public int UserPhone { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public int UserPassword { get; set; }
    }
}
