using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Purchase_Sell_Stock.Model.SettingModels;
using Purchase_Sell_Stock.IServices;

namespace Purchase_Sell_Stock.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        ISet _iset;
        public SettingController(ISet set)
        {
            _iset = set;
        }
        [HttpGet]
        public List<Powers> GetPowers(int employeeId, int powersParentId)
        {
            return _iset.GetPowersForUp(employeeId,powersParentId);
        }
        [HttpGet]
        public List<ViewStoreInfo> GetStoresFromLogin(string userPhone)
        {
            return _iset.GetStoresFromLogin(userPhone);
        }
    }
}