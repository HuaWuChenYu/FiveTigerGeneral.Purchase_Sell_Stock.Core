using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.SettingModels
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class Roles
    {
        /// <summary>
        /// 角色表主键
        /// </summary>
        public int RolesId { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RolesName { get; set; }
        /// <summary>
        /// 角色类型表外键
        /// </summary>
        public int RolesRoleTypeId { get; set; }
    }
}
