using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Purchase_Sell_Stock.Model.SettingModels;
using Purchase_Sell_Stock.IServices;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace Purchase_Sell_Stock.API.Controllers
{
    /// <summary>
    /// 设置
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        ISet _iset;
        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="set"></param>
        public SettingController(ISet set, ILogger<CustomerController> logger)
        {
            _logger = logger;
            _iset = set;
        }
        /// <summary>
        /// 角色名称获取角色id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public int GetRoleId(string name=null)
        {
            _logger.LogInformation($"获取角色名称{name}");
            return _iset.GetRoleId(name);
        }
        /// <summary>
        /// 获取手机号
        /// </summary>
        /// <param name="eid"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetPhoneByEId(int eid=-1)
        {
            _logger.LogInformation($"获取的手机号:{eid}");
            return _iset.GetPhoneByEId(eid);
        }
        /// <summary>
        /// 添加店铺
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddStore(Store store)
        {
            _logger.LogInformation($"添加的店铺:{store.StoreName}");
            return _iset.AddStore(store);
        }
        /// <summary>
        /// 获取行业
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Industry> GetIndustriesForShow()
        {
            _logger.LogInformation("获取行业成功");
            return _iset.GetIndustriesForShow();
        }
        /// <summary>
        /// 获取分类
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Classify> GetClassifiesForShow()
        {
            _logger.LogInformation("获取分类");
            return _iset.GetClassifiesForShow();
        }
        /// <summary>
        /// 根据小菜单id 查询出中大菜单的主键
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        [HttpGet]
        public int GetPowerIdForBig(int pid=-1)
        {
            _logger.LogInformation("查询大菜单");
            return _iset.GetPowerIdForBig(pid);
        }
        /// <summary>
        /// 通过权限名称获取权限路径
        /// </summary>
        /// <param name="name"></param>
        /// <param name="empId"></param>
        /// <returns></returns>
        [HttpGet]
        public Powers GetPowersBySel(string name=null, int empId=-1)
        {
            _logger.LogInformation($"权限名以及路径{name}{empId}");
            return _iset.GetPowersBySel(name,empId);
        }
        /// <summary>
        /// 添加店铺设置
        /// </summary>
        /// <param name="storeSet"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddStoreSet(StoreSet storeSet)
        {
            _logger.LogInformation($"添加店铺设置{storeSet.StoreId},{storeSet.StoreSetAtuoCancel},{storeSet.StoreSetChangeStore}" +
                $"{storeSet.StoreSetClose},{storeSet.StoreSetId},{storeSet.StoreSetInformation},{storeSet.StoreSetIsDeduction}," +
                $"{storeSet.StoreSetIsEmpty},{storeSet.StoreSetIsEvaluate},{storeSet.StoreSetIsSales},{storeSet.StoreSetIsService}" +
                $"{storeSet.StoreSetMakeInvoice},{storeSet.StoreSetOperation},{storeSet.StoreSetOrder},{storeSet.StoreSetPoster}" +
                $"{storeSet.StoreSetPoster}");
            return _iset.AddStoreSet(storeSet);
        }
        /// <summary>
        /// 查询店铺是否认证主体 认证过返回值
        /// </summary>
        /// <param name="storeid"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Company> IsHaveCompany(int storeid=-1)
        {
            _logger.LogInformation($"查询店铺是否认证主题,认真返回值{storeid}");
            return _iset.IsHaveCompany(storeid);
        }
        /// <summary>
        /// 添加主体
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddCompany(Company company)
        {
            _logger.LogInformation("添加主题");
            return _iset.AddCompany(company);
        }
        /// <summary>
        /// 通过id获取部门
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public Department GetDepartmentById(int id=-1)
        {
            _logger.LogInformation($"通过id获取部门:{id}");
            return _iset.GetDepartmentById(id);
        }
        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost]
        public int UpdateDepartment(Department department)
        {
            _logger.LogInformation("修改部门");
            return _iset.UpdateDepartment(department);
        }
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddDepartment(Department department)
        {
            _logger.LogInformation("添加部门");
            return _iset.AddDepartment(department);
        }
        /// <summary>
        /// 查询员工
        /// </summary>
        /// <param name="number"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetDepartmentByShow(string number=null, string name=null)
        {
            _logger.LogInformation($"通过{number},{name}查询员工");
            List<Department> dlist = _iset.GetDepartmentByShow();
            if (!string.IsNullOrEmpty(number))
            {
                dlist= dlist.Where(s => s.DepartmentNumber == number).ToList();
            }
            if (!string.IsNullOrEmpty(name))
            {
                dlist = dlist.Where(s => s.DepartmentName.Contains(name)).ToList();
            }
            var jsonData = new
            {
                code = 0,
                msg = "",
                data = dlist,
                count = dlist.Count()
            };
            return jsonData;
        }
        /// <summary>
        /// 修改员工
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPost]
        public int UpdateEmployee(Employee emp)
        {
            _logger.LogInformation("修改员工");
            return _iset.UpdateEmployee(emp);
        }
        /// <summary>
        /// 通过id查询员工信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public Employee GetEmployeeById(int id=-1)
        {
            _logger.LogInformation("通过id获取员工信息");
            return _iset.GetEmployeeById(id);
        }
        /// <summary>
        /// 添加员工信息
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddEmployee(Employee emp)
        {
            _logger.LogInformation("添加员工信息");
            return _iset.AddEmployee(emp);
        }
        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Roles> GetRolesForSelect()
        {
            _logger.LogInformation("获取角色信息");
            return _iset.GetRolesForSelect();
        }
        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Department> GetDepartments()
        {
            _logger.LogInformation("获取部门信息");
            return _iset.GetDepartments();
        }
        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="eNumber"></param>
        /// <param name="eName"></param>
        /// <param name="ePhone"></param>
        /// <param name="eDepartId"></param>
        /// <param name="eRoleId"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetEmployeesForShow(int pageIndex=1,int pageSize=3, string eNumber="", string eName="", string ePhone="", int eDepartId=-1, int eRoleId=-1)
        {
            _logger.LogInformation("获取员工信息");
            List<Employee> elist= _iset.GetEmployeesForShow();
            if (!string.IsNullOrEmpty(eNumber))
            {
                elist = elist.Where(s => s.EmployeeNumber == eNumber).ToList();
            }
            if (!string.IsNullOrEmpty(eName))
            {
                elist = elist.Where(s => s.EmployeeName == eName).ToList();
            }
            if (!string.IsNullOrEmpty(ePhone))
            {
                elist = elist.Where(s => s.EmployeeContact == ePhone).ToList();
            }
            if (eDepartId>0)
            {
                elist = elist.Where(s => s.EmployeeDepartmentId == eDepartId).ToList();
            }
            if (eRoleId>0)
            {
                elist = elist.Where(s => s.EmployeeRolesId == eRoleId).ToList();
            }
            var jsonData = new
            {
                code = 0,
                msg = "",
                data = elist.Skip((pageIndex-1)*pageSize).Take(pageIndex*pageSize),
                count = elist.Count()
            };
            return jsonData;
        }
        /// <summary>
        /// 角色的权限的显示
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="powersParentId"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Powers> GetPowers(int employeeId=-1, int powersParentId=-1)
        {
            _logger.LogInformation("根据员工id生成不同的导航栏");
            return _iset.GetPowersForUp(employeeId,powersParentId);
        }
        /// <summary>
        /// 通过用户手机号返回店铺信息
        /// </summary>
        /// <param name="userPhone"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public List<ViewStoreInfo> GetStoresFromLogin(string userPhone=null)
        {
            _logger.LogInformation("通过手机号返回店铺信息");
            return _iset.GetStoresFromLogin(userPhone);
        }
        /// <summary>
        /// 通过店铺id  店铺信息
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        [HttpGet]
        public Store GetStoresForUpdate(int storeId=-1)
        {
            _logger.LogInformation($"获取店铺id:{storeId}");
            return _iset.GetStoresForUpdate(storeId);
        }
        /// <summary>
        /// 用于修改店铺信息
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        [HttpPost]
        public int UpdateStore(Store store)
        {
            _logger.LogInformation("修改店铺信息");
            return _iset.UpdateStore(store);
        }
        /// <summary>
        /// 用于显示角色类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<RoleType> GetRoleTypes()
        {
            _logger.LogInformation("角色类型加载");
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
        /// <summary>
        /// 通过角色类型获取角色
        /// </summary>
        /// <param name="roleTypesId"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Roles> GetRoles(int roleTypesId=-1)
        {
            _logger.LogInformation($"角色类型获取角色{roleTypesId}");
            return _iset.GetRoles(roleTypesId);
        }
        /// <summary>
        /// 用于修改角色的权限
        /// </summary>
        /// <param name="powerParentId"></param>
        /// <param name="rolesId"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Powers> GetPowersBySet(int powerParentId=-1, int rolesId=-1)
        {
            _logger.LogInformation("修改角色权限");
            return _iset.GetPowersBySet(powerParentId,rolesId);
        }
        /// <summary>
        /// 根据角色查询权限id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Powers> GetPowersByShowId(int roleId=-1)
        {
            _logger.LogInformation("根据角色id查询权限");
            return _iset.GetPowersByShowId(roleId);
        }
        /// <summary>
        /// 删除角色的一项权限
        /// </summary>
        /// <param name="powerId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet]
        public int DeletePowersAndRoles(string powerId=null, int roleId=-1)
        {
            _logger.LogInformation("删除角色");
            return _iset.DeletePowersAndRoles(powerId, roleId);
        }
        /// <summary>
        /// 添加角色的一项权限
        /// </summary>
        /// <param name="powerId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet]
        public int AddPowersAndRoles(string powerId=null, int roleId=-1)
        {
            _logger.LogInformation("获取角色的一项权限");
            return _iset.AddPowersAndRoles(powerId,roleId);
        }
    }
}