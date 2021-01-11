using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.SettingModels
{
    /// <summary>
    /// 角色权限表
    /// </summary>
    public class RolesAndPowers
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int RolesAndPowersId { get; set; }
        /// <summary>
        /// 角色外键
        /// </summary>
        public int RolesAndPowersRolesId { get; set; }
        /// <summary>
        /// 权限外键
        /// </summary>
        public int RolesAndPowersPowersId { get; set; }
    }
}
