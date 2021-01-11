using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Purchase_Sell_Stock.IServices;
using Purchase_Sell_Stock.Model.SettingModels;
using Purchase_Sell_Stock.Model.GoodsFunction;
using Purchase_Sell_Stock.DAL.GetDBHelper;

namespace Purchase_Sell_Stock.API.Controllers
{
    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        
        ISet _iset;
        public TestController(ISet set)
        {
            _iset = set;
        }
        [HttpGet]
        public List<Classify> ClassifiesShow()
        {
            List<Classify> clist = _iset.ClassifiesShow();
            return clist;
        }
        
    }
}