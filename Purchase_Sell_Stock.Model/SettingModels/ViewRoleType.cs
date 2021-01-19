using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.SettingModels
{
    public class ViewRoleType
    {
        public int id { get; set; }//节点Id
        public string name { get; set; }//节点名称
        public string title { get { return name; } }//节点名称
        public bool spread { get; set; } = true; //是否展开状态（默认false）

        public List<ViewRoleType> children { get; set; }//子节点结合
    }
}
