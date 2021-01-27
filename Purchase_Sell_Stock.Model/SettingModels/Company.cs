using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.SettingModels
{
    /// <summary>
    /// 公司主体表
    /// </summary>
    public class Company
    {
        /// <summary>
        /// 公司主体表外键
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 公司名称 
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 公司地址
        /// </summary>
        public string CompanyAddress { get; set; }
        /// <summary>
        /// 法人姓名
        /// </summary>
        public string CompanyLegalPerson { get; set; }
        /// <summary>
        /// 法人身份证号
        /// </summary>
        public string CompanyIDNUM { get; set; }
        /// <summary>
        /// 统一社会信用代码
        /// </summary>
        public string CompanyUnifyNUM { get; set; }
        /// <summary>
        /// 营业执照(图片)
        /// </summary>
        public string CompanyPhoto { get; set; }
        /// <summary>
        /// 负责人姓名
        /// </summary>
        public string CompanyPersonName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string CompanyPersonIDNUM { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string CompanyLinkmanPhone { get; set; }
        /// <summary>
        /// 身份证正面
        /// </summary>
        public string IDFront { get; set; }
        /// <summary>
        /// 身份证反面
        /// </summary>
        public string IDBack { get; set; }
        /// <summary>
        /// 主体类型
        /// </summary>
        public bool CompanyType { get; set; }
        /// <summary>
        /// 认证状态
        /// </summary>
        public bool CompanyStates { get; set; }
        public int StoreId { get; set; }
    }
}
