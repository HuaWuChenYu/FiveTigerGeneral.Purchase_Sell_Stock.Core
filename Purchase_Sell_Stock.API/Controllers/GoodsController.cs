using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Purchase_Sell_Stock.Model.GoodsFunction;
using Purchase_Sell_Stock.Services;
using Purchase_Sell_Stock.IServices;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Purchase_Sell_Stock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class GoodsController : ControllerBase
    {
        private IGoods _goods1;
        public GoodsController(IGoods goods)
        {
            _goods1 = goods;
        }

        [HttpGet]
        [Route("/api/GetGoodsList/{storeId}")]
        /// <summary>
        /// 商品档案查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="goodsNum"></param>
        /// <param name="goodsName"></param>
        /// <param name="goodsType"></param>
        /// <param name="goodsClassify"></param>
        /// <returns></returns>
        public string GetGoodsList(int storeId, int pageIndex, int pageSize, string goodsName = "", string goodsType = "", string goodsClassify = "")
        {
            if (goodsType == "全部")
            {
                goodsType = "";
            }
            GoodsPaging<Goods> goodsPaging = _goods1.GetGoodsList<Goods>(pageIndex, pageSize, goodsName, goodsType, goodsClassify, storeId);
            //return resource;
            var jsonData = new
            {
                code = 0,
                msg = "",
                count = goodsPaging.Count,
                data = goodsPaging.list
            };
            string str = JsonConvert.SerializeObject(jsonData);
            return str;
        }
        [HttpGet]
        [Route("/api/GetGoodsBrandList/{storeId}")]
        ///<summary>
        /// 商品品牌下拉
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="brandId"></param>
        /// <param name="brandName"></param>
        /// <returns></returns>
        public List<GoodsBrand> GetGoodsBrandList( int storeId,int brandId, string brandName)
        {
            List<GoodsBrand> list = _goods1.GetGoodsBrandList(brandId, brandName, storeId);
            return list;
        }
        [HttpGet]
        [Route("/api/GetGoodsBrandListShow/{storeId}")]
        ///<summary>
        /// 商品品牌显示
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="brandId"></param>
        /// <param name="brandName"></param>
        /// <returns></returns>
        public string GetGoodsBrandListShow(int storeId, int brandId, string brandName)
        {
            List<GoodsBrand> list = _goods1.GetGoodsBrandList(brandId, brandName, storeId);
            return JsonConvert.SerializeObject(new { code=0,msg="",count=list.Count,data=list});
        }
        [HttpGet]
        [Route("/api/DelBrand")]
        /// <summary>
        /// 删除品牌
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public int DelBrand(int brandId)
        {
            return _goods1.DelBrand(brandId);
        }
        [HttpGet]
        [Route("/api/GetGoodsTypeList/{typeId}/{typeName}/{storeId}")]
        /// <summary>
        /// 商品分类下拉
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeId"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public List<GoodsType> GetGoodsTypeList(int typeId, string typeName, int storeId)
        {
            List<GoodsType> list = _goods1.GetGoodsTypeList(typeId, typeName, storeId);
            return list;
        }
        [HttpGet]
        [Route("/api/GetGoodsUnitList/{storeId}")]
        /// <summary>
        /// 商品单位下拉
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="unitId"></param>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public List<GoodsUnit> GetGoodsUnitList(int unitId, string unitName, int storeId)
        {
            List<GoodsUnit> list = _goods1.GetGoodsUnitList(unitId, unitName, storeId);
            return list;
        }
        [HttpGet]
        [Route("/api/GetGoodsUnitListShow/{storeId}")]
        /// <summary>
        /// 商品单位显示
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="brandId"></param>
        /// <param name="brandName"></param>
        /// <returns></returns>
        public string GetGoodsUnitListShow(int storeId, int unitId, string unitName)
        {
            List<GoodsUnit> list = _goods1.GetGoodsUnitList(unitId, unitName, storeId);
            return JsonConvert.SerializeObject(new { code = 0, msg = "", count = list.Count, data = list });
        }
        /// <summary>
        /// 删除单位
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/DelUnit")]
        public int DelUnit(int unitId)
        {
            return _goods1.DelUnit(unitId);
        }
        [HttpPost]
        [Route("/api/AddGoodsType")]
        /// <summary>
        /// 添加商品分类
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns> v  
        public int AddGoodsType(GoodsType goods)
        {
            return _goods1.AddGoodsType(goods);
        }
        [HttpPost]
        [Route("/api/AddGoodsBrand")]
        /// <summary>
        /// 添加商品品牌
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns> v  
        public int AddGoodsBrand(GoodsBrand goods)
        {
            return _goods1.AddGoodsBrand(goods);
        }
        [HttpPost]
        [Route("/api/AddGoodsUnit")]
        /// <summary>
        /// 添加商品单位
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns> v  
        public int AddGoodsUnit(GoodsUnit goods)
        {
            return _goods1.AddGoodsUnit(goods);
        }
        [HttpPost]
        [Route("/api/AddGoods")]
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns> v
        public int AddGoods([FromBody] Goods goods)
        {
            int i = _goods1.AddGoods(goods);
            return i;
        }
        [HttpPost]
        [Route("/api/ModifyState/{goodId}")]
        /// <summary>
        /// 修改上下架
        /// </summary>
        /// <param name="goodId"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public int ModifyState(int goodId)
        {
            int i = _goods1.ModifyState(goodId);
            return i;
        }
        [HttpPost]
        [Route("/api/DeleteGoods/{goodIds}")]
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="goodsIds"></param>
        /// <returns></returns>
        /// [HttpPost]
        public int DeleteGoods(string goodIds)
        {
            return _goods1.DeleteGoods(goodIds);
        }
        [HttpGet]
        [Route("/api/GetGoodsById/{goodsId}")]
        /// <summary>
        /// 根据Id查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Goods GetGoodsById(int goodsId)
        {
            List<Goods> list = _goods1.GetGoodsById(goodsId);
            return list[0];
        }
        [HttpPost]
        [Route("/api/ModifyGoods")]
        /// <summary>
        /// 修改商品单位
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public int ModifyGoods(Goods goods)
        {
            int i = _goods1.ModifyGoods(goods);
            return i;
        }
    }
}
