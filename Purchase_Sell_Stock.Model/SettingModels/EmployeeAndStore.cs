using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.SettingModels
{
    /// <summary>
    /// 员工店铺表
    /// </summary>
    public class EmployeeAndStore
    {
        /// <summary>
        /// 员工店铺主键
        /// </summary>
        public int EmployeeAndStoreId { get; set; }
        /// <summary>
        /// 员工外键
        /// </summary>
        public int EmployeeAndStoreEmployeeId { get; set; }
        /// <summary>
        /// 店铺外键
        /// </summary>
        public int EmployeeAndStoreStoreId { get; set; }
    }
}
