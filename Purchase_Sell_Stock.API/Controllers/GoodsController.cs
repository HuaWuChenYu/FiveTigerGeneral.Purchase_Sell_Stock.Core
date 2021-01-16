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
        [Route("/api/GetGoodsList/{pageIndex}/{pageSize}/{goodsName}/{goodsType}/{goodsClassify}/{storeId}")]
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
            if (goodsName == "空")
            {
                goodsName = "";
            }
            if (goodsType == "全部")
            {
                goodsType = "";
            }
            if (goodsClassify == "空")
            {
                goodsClassify = "";
            }
            GoodsPaging<Goods> goodsPaging = _goods1.GetGoodsList<Goods>(pageIndex, pageSize, goodsName, goodsType, goodsClassify, storeId);
            var dataJson = new
            {
                code = 0,
                msg = "",
                count = goodsPaging.Count,
                data = goodsPaging.list
            };
            return JsonConvert.SerializeObject(dataJson);
        }
        [HttpGet]
        [Route("/api/GetGoodsBrandList/{brandId}/{brandName}/{storeId}")]
        ///<summary>
        /// 商品品牌查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="brandId"></param>
        /// <param name="brandName"></param>
        /// <returns></returns>
        public List<GoodsBrand> GetGoodsBrandList(int brandId, string brandName, int storeId)
        {

            List<GoodsBrand> list = _goods1.GetGoodsBrandList(brandId, brandName, storeId);
            return list;
        }
        [HttpGet]
        [Route("/api/GetGoodsTypeList/{typeId}/{typeName}/{storeId}")]
        /// <summary>
        /// 商品分类查询
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
        [Route("/api/GetGoodsUnitList/{unitId}/{unitName}/{storeId}")]
        /// <summary>
        /// 商品单位查询
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
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/UploadPhoto")]
        public string UploadPhoto([FromForm] IFormCollection formCollection)
        {
            FormFileCollection fileCollection = (FormFileCollection)formCollection.Files;
            foreach (IFormFile file in fileCollection)
            {
                StreamReader reader = new StreamReader(file.OpenReadStream());
                String content = reader.ReadToEnd();
                String name = file.FileName;//文件名称
                var path = Directory.GetCurrentDirectory();//文件夹绝对路径
                string fullPath = path + @"\Img\" + name;//图片绝对路径
                string filePath = @"\Img\" + name;//文件相对路径,需要保存到数据库
                using (FileStream fs = System.IO.File.Create(fullPath))
                {
                    // 复制文件,保存文件至Img文件夹
                    file.CopyTo(fs);
                    // 清空缓冲区数据
                    fs.Flush();
                }
                var dataJson = new
                {
                    result = filePath,
                    code = 0
                };
                return JsonConvert.SerializeObject(dataJson);
            }
            return "";
        }
        
    }
}
