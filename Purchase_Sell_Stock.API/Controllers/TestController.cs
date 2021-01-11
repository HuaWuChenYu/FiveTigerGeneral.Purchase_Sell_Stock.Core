using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Purchase_Sell_Stock.IServices;
using Purchase_Sell_Stock.Model.SettingModels;
using Purchase_Sell_Stock.Services;

namespace Purchase_Sell_Stock.API.Controllers
{
    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        SetBll _bll = new SetBll();
        //ISet _iset;
        //public TestController(ISet set)
        //{
        //    _iset = set;
        //}
        [HttpGet]
        public List<Classify> ClassifiesShow()
        {
            List<Classify> clist= _bll.ClassifiesShow();
            return clist;
        }
    }
}