using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Storage
{
    public class IncomingorderCombine
    {
        /// <summary>
        /// 入库订单Id
        /// </summary>
        public int IncomingorderId { get; set; }
        /// <summary>
        /// 入库订单单号
        /// </summary>
        public string IncomingorderOrderNumber { get; set; }
        /// <summary>
        /// 采购表外键	
        /// </summary>
        public int ProcurementId { get; set; }
        /// <summary>
        /// 出入库类型名称
        /// </summary>
        public string StorageTypeName { get; set; }
        /// <summary>
        /// 状态（待入库 部分入库 已入库）
        /// </summary>
        public int IncomingorderState { get; set; }
        /// <summary>
        /// 收货方（仓库外键）
        /// </summary>
        public string WarehouseName { get; set; }
        /// <summary>
        /// 收货数量（默认值0）
        /// </summary>
        public int IncomingorderNumber { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime IncomingordercreationTime { get; set; }
        /// <summary>
        /// 入库时间
        /// </summary>
        public DateTime IncomingorderTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string IncomingorderRemark { get; set; }


        /// <summary>
        /// 采购表主键
        /// </summary>
        
        /// <summary>
        /// 采购单号
        /// </summary>
        public string ProcurementNum { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public string ProviderName { get; set; }
        /// <summary>
        /// 采购方
        /// </summary>
        public string ProcurementName { get; set; }
        /// <summary>
        /// 采购创建人
        /// </summary>
        public string ProcurementCreator { get; set; }
        /// <summary>
        /// 采购单状态
        /// </summary>
        public int ProcurementState { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime ProcurementTime { get; set; }

        /// <summary>
        /// 采购商品表主键
        /// </summary>
        public int ProcurementGoodsId { get; set; }
        /// <summary>
        /// 采购商品数量
        /// </summary>
        public int ProcurementGoodsNum { get; set; }
        /// <summary>
        /// 商品外键
        /// </summary>
        public int GoodsId { get; set; }


        /// <summary>
        /// 商品表
        /// </summary>

        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 商品规格
        /// </summary>
        public string GoodsSize { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// 商品类型
        /// </summary>
        public string Goodsclassify { get; set; }
        /// <summary>
        /// 商品分类名称
        /// </summary>
        public string GoodsTypeName { get; set; }
        /// <summary>
        /// 商品单位名称
        /// </summary>
        public string GoodsUnitName { get; set; }

        /// <summary>
        /// 已入库数量
        /// </summary>
        public int IncomingorderNuming { get; set; }
    }
}
