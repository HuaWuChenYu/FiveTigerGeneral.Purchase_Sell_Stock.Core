using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Purchase_Sell_Stock.IServices;
using Purchase_Sell_Stock.Model.SettingModels;

namespace Purchase_Sell_Stock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        ISet _set = null;
        public TestController(ISet set)
        {
            _set = set;
        }
        [HttpGet]
        public List<Classify> ClassifiesShow()
        {
            return _set.ClassifiesShow();
        }
    }
}