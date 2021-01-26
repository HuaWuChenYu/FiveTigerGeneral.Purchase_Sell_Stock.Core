using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Purchase_Sell_Stock.Model.SettingModels;
using Purchase_Sell_Stock.IServices;
using Microsoft.AspNetCore.Authorization;

namespace Purchase_Sell_Stock.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SettingController : ControllerBase
    {
        ISet _iset;
        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="set"></param>
        public SettingController(ISet set)
        {
            _iset = set;
        }
        /// <summary>
        /// 角色名称获取角色id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public int GetRoleId(string name)
        {
            return _iset.GetRoleId(name);
        }
        /// <summary>
        /// 获取手机号
        /// </summary>
        /// <param name="eid"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetPhoneByEId(int eid)
        {
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
            return _iset.AddStore(store);
        }
        /// <summary>
        /// 获取行业
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Industry> GetIndustriesForShow()
        {
            return _iset.GetIndustriesForShow();
        }
        /// <summary>
        /// 获取分类
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Classify> GetClassifiesForShow()
        {
            return _iset.GetClassifiesForShow();
        }
        /// <summary>
        /// 根据小菜单id 查询出中大菜单的主键
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        [HttpGet]
        public int GetPowerIdForBig(int pid)
        {
            return _iset.GetPowerIdForBig(pid);
        }
        /// <summary>
        /// 通过权限名称获取权限路径
        /// </summary>
        /// <param name="name"></param>
        /// <param name="empId"></param>
        /// <returns></returns>
        [HttpGet]
        public Powers GetPowersBySel(string name, int empId)
        {
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
            return _iset.AddStoreSet(storeSet);
        }
        /// <summary>
        /// 查询店铺是否认证主体 认证过返回值
        /// </summary>
        /// <param name="storeid"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Company> IsHaveCompany(int storeid)
        {
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
            return _iset.AddCompany(company);
        }
        /// <summary>
        /// 通过id获取部门
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public Department GetDepartmentById(int id)
        {
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
            return _iset.AddDepartment(department);
        }
        /// <summary>
        /// 查询员工
        /// </summary>
        /// <param name="number"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetDepartmentByShow(string number, string name)
        {
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
            return _iset.UpdateEmployee(emp);
        }
        /// <summary>
        /// 通过id查询员工信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public Employee GetEmployeeById(int id)
        {
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
            return _iset.AddEmployee(emp);
        }
        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Roles> GetRolesForSelect()
        {
            return _iset.GetRolesForSelect();
        }
        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Department> GetDepartments()
        {
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
        public List<Powers> GetPowers(int employeeId, int powersParentId)
        {
            return _iset.GetPowersForUp(employeeId,powersParentId);
        }
        /// <summary>
        /// 通过用户手机号返回店铺信息
        /// </summary>
        /// <param name="userPhone"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ViewStoreInfo> GetStoresFromLogin(string userPhone)
        {
            return _iset.GetStoresFromLogin(userPhone);
        }
        /// <summary>
        /// 通过店铺id  店铺信息
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        [HttpGet]
        public Store GetStoresForUpdate(int storeId)
        {
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
            return _iset.UpdateStore(store);
        }
        /// <summary>
        /// 用于显示角色类型
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 通过角色类型获取角色
        /// </summary>
        /// <param name="roleTypesId"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Roles> GetRoles(int roleTypesId)
        {
            return _iset.GetRoles(roleTypesId);
        }
        /// <summary>
        /// 用于修改角色的权限
        /// </summary>
        /// <param name="powerParentId"></param>
        /// <param name="rolesId"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Powers> GetPowersBySet(int powerParentId, int rolesId)
        {
            return _iset.GetPowersBySet(powerParentId,rolesId);
        }
        /// <summary>
        /// 根据角色查询权限id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Powers> GetPowersByShowId(int roleId)
        {
            return _iset.GetPowersByShowId(roleId);
        }
        /// <summary>
        /// 删除角色的一项权限
        /// </summary>
        /// <param name="powerId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet]
        public int DeletePowersAndRoles(string powerId, int roleId)
        {
            return _iset.DeletePowersAndRoles(powerId, roleId);
        }
        /// <summary>
        /// 添加角色的一项权限
        /// </summary>
        /// <param name="powerId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet]
        public int AddPowersAndRoles(string powerId, int roleId)
        {
            return _iset.AddPowersAndRoles(powerId,roleId);
        }
    }
}