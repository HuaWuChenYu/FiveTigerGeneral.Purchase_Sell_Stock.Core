using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.SettingModels
{
    /// <summary>
    /// 角色类型表
    /// </summary>
    public class RoleType
    {
        /// <summary>
        /// 角色类型主键
        /// </summary>
        public int RoleTypeId { get; set; }
        /// <summary>
        /// 角色类型名
        /// </summary>
        public string RoleTypeName { get; set; }

        public int id { get { return RoleTypeId; } set { value = RoleTypeId; } }//节点Id
        public string name { get; set; }//节点名称
        public string title { get { return RoleTypeName; } set { value = RoleTypeName; } }//节点名称
        public bool spread { get; set; } = true; //是否展开状态（默认false）

        public List<Roles> children { get; set; }//子节点结合
    }
}
