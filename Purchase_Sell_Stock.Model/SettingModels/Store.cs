using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.SettingModels
{
    /// <summary>
    /// 店铺表
    /// </summary>
    public class Store
    {
        /// <summary>
        /// 店铺主键
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// 店铺编码
        /// </summary>
        public string StoreCoding { get; set; }
        /// <summary>
        /// 店铺名
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// 归属城市
        /// </summary>
        public string StoreCity { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string StoreLinkman { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string StorePrincipal { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string StoreLinkmanPhone { get; set; }
        /// <summary>
        /// 负责人电话
        /// </summary>
        public string StorePrincipalPhone { get; set; }
        /// <summary>
        /// 店铺NumID
        /// </summary>
        public string StoreNumID { get; set; }
        /// <summary>
        /// 状态(使用中,运营中)
        /// </summary>
        public int StoreStates { get; set; }
        /// <summary>
        /// 有效时间(用于显示有效期剩余天数) 
        /// </summary>
        public DateTime StoreEffectiveDate { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime StoreCreateDate { get; set; }
        /// <summary>
        /// 店铺logo
        /// </summary>
        public string StoreLogo { get; set; }
        /// <summary>
        /// 店铺简介
        /// </summary>
        public string StoreIntroduction { get; set; }
        /// <summary>
        /// 行业id(外键)
        /// </summary>
        public int StoreIndustryId { get; set; }
        /// <summary>
        /// 店铺分类id(外键)
        /// </summary>
        public int StoreClassifyId { get; set; }
        /// <summary>
        /// 公司主体(外键)
        /// </summary>
        public int StoreCompanyId { get; set; }
        /// <summary>
        /// 店铺设置表主键
        /// </summary>
        public int StoreStoreSetId { get; set; }
        
    }
}
