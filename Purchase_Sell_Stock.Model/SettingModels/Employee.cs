using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.SettingModels
{
    /// <summary>
    /// 员工表
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// 员工主键
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// 员工编号
        /// </summary>
        public string EmployeeNumber { get; set; }
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// 员工手机
        /// </summary>
        public string EmployeeContact { get; set; }
        /// <summary>
        /// 员工创建时间
        /// </summary>
        public DateTime EmployeeCreateTime { get; set; }
        /// <summary>
        /// 员工状态
        /// </summary>
        public bool EmployeeStates { get; set; }
        /// <summary>
        /// 员工部门外键
        /// </summary>
        public int EmployeeDepartmentId { get; set; }
        /// <summary>
        /// 员工用户外键
        /// </summary>
        public int EmployeeUserId { get; set; }
        /// <summary>
        /// 员工角色外键
        /// </summary>
        public int EmployeeRolesId { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RolesName { get; set; }
    }
}
