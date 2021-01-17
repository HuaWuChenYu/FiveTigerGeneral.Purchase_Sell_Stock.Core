using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.Storage
{
    /// <summary>
    /// 出库订单表和订单表以及商品表结合
    /// </summary>
    public class OutboundorderCombine
    {
        /// <summary>
        /// 出库订单Id
        /// </summary>
        public int OutboundorderId { get; set; }
        /// <summary>
        /// 出库订单编号
        /// </summary>
        public string OutboundorderOrderNumber { get; set; }
        /// <summary>
        /// 订单外键
        /// </summary>
        public int OrdersId { get; set; }
        /// <summary>
        /// 出库类型外键
        /// </summary>
        public int StorageTypeId { get; set; }
        /// <summary>
        /// 状态（待出库 部分出库 已出库）
        /// </summary>
        public int OutboundorderState { get; set; }
        /// <summary>
        /// 出库数量（默认值0）
        /// </summary>
        public int OutboundorderNumber { get; set; }
        /// <summary>
        /// 发货方（仓库）（仓库外键）
        /// </summary>
        public int WarehouseId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime OutboundordercreationTime { get; set; }
        /// <summary>
        /// 出库时间	
        /// </summary>
        public DateTime OutboundorderTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string OutboundorderRemark { get; set; }
        /// <summary>
        /// 商品总共数量
        /// </summary>
        public int OutboundGoodsNum { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrdersNum { get; set; }
 
        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrdersState { get; set; }
      
    
      
       
        /// <summary>
        /// 客户外键
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// 店铺外键
        /// </summary>
        public int StoreId { get; set; }



        /// <summary>
        /// 订单商品表
        /// </summary>

        /// <summary>
        /// 订单商品主键
        /// </summary>
        public int OrdersGoodsId { get; set; }
        /// <summary>
        /// 商品外键
        /// </summary>
        public int GoodsId { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int OrdersGoodsNum { get; set; }

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
        /// 商品单位名称
        /// </summary>
        public string GoodsUnitName { get; set; }
        /// <summary>
        /// 店铺外键
        /// </summary>


        /// <summary>
        /// 仓库
        /// </summary>
        
        /// <summary>
        /// 仓库编号
        /// </summary>
        public string WarehouseOrderNumber { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WarehouseName { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string WarehousePrincipal { get; set; }
        /// <summary>
        /// 负责人电话
        /// </summary>
        public string WarehousePrincipalPhone { get; set; }

        /// <summary>
        /// 买家名称
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 买家手机号
        /// </summary>
        public string CustomerPhone { get; set; }
        /// <summary>
        /// 出入库类型名称
        /// </summary>
        public string StorageTypeName { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Adress { get; set; }


        
        /// <summary>
        /// 采购退货商品表主键
        /// </summary>
        public int ProcurementGoodsId { get; set; }
        /// <summary>
        /// 采购退货表
        /// </summary>
        public int CancleProcurementId { get; set; }
        /// <summary>
        /// 采购退货商品数量
        /// </summary>
        public int CancleProcurementGoodsNum { get; set; }
        /// <summary>
        /// 退货状态
        /// </summary>
        public int CancleProcurementState { get; set; }
        /// <summary>
        /// 退货单号
        /// </summary>
        public string CancleProcurementNum { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public string ProviderName { get; set; }
        /// <summary>
        /// 退货方
        /// </summary>
        public string CancleProcurementName { get; set; }
 

    }
}
