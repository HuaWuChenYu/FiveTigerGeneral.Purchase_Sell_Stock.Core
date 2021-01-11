using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.SettingModels
{
    /// <summary>
    /// 权限表
    /// </summary>
    public class Powers
    {
        /// <summary>
        /// 权限表主键
        /// </summary>
        public int PowersId { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string PowersName { get; set; }
        /// <summary>
        /// 权限路径
        /// </summary>
        public string PowersURL { get; set; }
        /// <summary>
        /// 上级ID
        /// </summary>
        public int PowersParentId { get; set; }

    }
}
