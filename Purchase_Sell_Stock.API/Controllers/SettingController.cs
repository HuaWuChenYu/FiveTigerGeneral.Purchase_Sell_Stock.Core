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
        [HttpGet]
        public Store GetStoresForUpdate(int storeId)
        {
            return _iset.GetStoresForUpdate(storeId);
        }
        [HttpPost]
        public int UpdateStore(Store store)
        {
            return _iset.UpdateStore(store);
        }
        //用于显示角色类型
        [HttpGet]
        public List<RoleType> GetRoleTypes()
        {
            List<RoleType> rlist= _iset.GetRoleTypes();
            foreach (var item in rlist)
            {
                item.children = _iset.GetRoles(item.id);
            }
            //List<ViewRoleType> vlist = (List<ViewRoleType>)(from a in rlist
            //                           select new List<ViewRoleType>
            //                           {
            //                               new ViewRoleType(){ id=a.RoleTypeId,name=a.RoleTypeName}
            //                           }.ToList());
            return rlist;
        }
        //通过角色类型获取角色
        [HttpGet]
        public List<Roles> GetRoles(int roleTypesId)
        {
            return _iset.GetRoles(roleTypesId);
        }
        [HttpGet]
        public List<Powers> GetPowersBySet(int powerParentId, int rolesId)
        {
            return _iset.GetPowersBySet(powerParentId,rolesId);
        }
    }
}