using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.SettingModels
{
    /// <summary>
    /// 部门表
    /// </summary>
    public class Department
    {
        /// <summary>
        /// 部门主键
        /// </summary>
        public int DepartmentId { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        public string DepartmentNumber { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 部门父id
        /// </summary>
        public int DepartmentParentId { get; set; }
    }
}
