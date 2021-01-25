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
        //通过id获取部门
        [HttpGet]
        public Department GetDepartmentById(int id)
        {
            return _iset.GetDepartmentById(id);
        }
        //修改部门
        [HttpPost]
        public int UpdateDepartment(Department department)
        {
            return _iset.UpdateDepartment(department);
        }
        //添加部门
        [HttpPost]
        public int AddDepartment(Department department)
        {
            return _iset.AddDepartment(department);
        }
        //查询员工
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
        //修改员工
        [HttpPost]
        public int UpdateEmployee(Employee emp)
        {
            return _iset.UpdateEmployee(emp);
        }
        //通过id查询员工信息
        [HttpGet]
        public Employee GetEmployeeById(int id)
        {
            return _iset.GetEmployeeById(id);
        }
        //添加员工信息
        [HttpPost]
        public int AddEmployee(Employee emp)
        {
            return _iset.AddEmployee(emp);
        }
        //获取角色信息
        [HttpGet]
        public List<Roles> GetRolesForSelect()
        {
            return _iset.GetRolesForSelect();
        }
        //获取部门信息
        [HttpGet]
        public List<Department> GetDepartments()
        {
            return _iset.GetDepartments();
        }
        //获取员工信息
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
        [HttpGet]
        public List<Powers> GetPowersByShowId(int roleId)
        {
            return _iset.GetPowersByShowId(roleId);
        }
        //删除角色的一项权限
        [HttpGet]
        public int DeletePowersAndRoles(string powerId, int roleId)
        {
            return _iset.DeletePowersAndRoles(powerId, roleId);
        }
        //添加角色的一项权限
        [HttpGet]
        public int AddPowersAndRoles(string powerId, int roleId)
        {
            return _iset.AddPowersAndRoles(powerId,roleId);
        }
    }
}