using Purchase_Sell_Stock.DAL;
using System.Collections.Generic;
using Purchase_Sell_Stock.Model.SettingModels;
using Purchase_Sell_Stock.IServices;
using Purchase_Sell_Stock.Model.GoodsFunction;
using System;

namespace Purchase_Sell_Stock.Services
{
    /// <summary>
    /// 用于设置
    /// </summary>
    public class SetBll : ISet
    {   
        SetDal _dal = DalFactory.GetDal<SetDal>("Set");
        //通过id获取部门
        public Department GetDepartmentById(int id)
        {
            return _dal.GetDepartmentById(id);
        }
        //修改部门
        public int UpdateDepartment(Department department)
        {
            return _dal.UpdateDepartment(department);
        }
        //添加部门
        public int AddDepartment(Department department)
        {
            return _dal.AddDepartment(department);
        }
        //查询员工
        public List<Department> GetDepartmentByShow()
        {
            return _dal.GetDepartmentByShow();
        }
        //修改员工
        public int UpdateEmployee(Employee emp)
        {
            return _dal.UpdateEmployee(emp);
        }
        //通过id查询员工信息
        public Employee GetEmployeeById(int id)
        {
            return _dal.GetEmployeeById(id);
        }
        //添加员工信息
        public int AddEmployee(Employee emp)
        {
            return _dal.AddEmployee(emp);
        }
        //获取角色信息
        public List<Roles> GetRolesForSelect()
        {
            return _dal.GetRolesForSelect();
        }
        //获取部门信息
        public List<Department> GetDepartments()
        {
            return _dal.GetDepartments();
        }
        //获取员工信息
        public List<Employee> GetEmployeesForShow()
        {
            return _dal.GetEmployeesForShow();
        }
        //添加角色的一项权限
        public int AddPowersAndRoles(string powerId, int roleId)
        {
            return _dal.AddPowersAndRoles(powerId,roleId);
        }
        //删除角色的一项权限
        public int DeletePowersAndRoles(string powerId, int roleId)
        {
            return _dal.DeletePowersAndRoles(powerId,roleId);
        }
        ////根据角色查询权限id
        public List<Powers> GetPowersByShowId(int roleId)
        {
            return _dal.GetPowersByShowId(roleId);
        }
        public int AddCompany(Company company)
        {
            throw new NotImplementedException();
        }


        public int AddStoreSet(StoreSet storeSet)
        {
            throw new NotImplementedException();
        }

        public List<Classify> ClassifiesShow()
        {
            return _dal.ClassifiesShow();
        }

        public decimal GetAllMoney(int StoreId, int TimeType)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetDepartments(string coding, string deptName)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployees(string employeeNumber, string employeeName, string employeeContact, int departmentId, int rolesId)
        {
            throw new NotImplementedException();
        }

        public List<Goods> GetGoods(int storeId, int TimeType)
        {
            throw new NotImplementedException();
        }

        public double GetLookPay(int StoreId, int TimeType)
        {
            throw new NotImplementedException();
        }

        public int GetLookPeople(int StoreId, int TimeType)
        {
            throw new NotImplementedException();
        }

        public int GetLookStoreCount(int StoreId)
        {
            throw new NotImplementedException();
        }

        public int GetNewUser(int StoreId, int TimeType)
        {
            throw new NotImplementedException();
        }

        public int GetOldActiveUser(int StoreId, int TimeType)
        {
            throw new NotImplementedException();
        }

        public int GetOrdersCount(int StoreId, int TimeType)
        {
            throw new NotImplementedException();
        }

        public decimal GetPayPeopleAvg(int StoreId, int TimeType)
        {
            throw new NotImplementedException();
        }

        public int GetPayPeopleCount(int StoreId, int TimeType)
        {
            throw new NotImplementedException();
        }

        public List<Powers> GetPowers()
        {
            throw new NotImplementedException();
        }

        public List<Powers> GetPowersBySet(int powerParentId, int rolesId)
        {
            return _dal.GetPowersBySet(powerParentId,rolesId);
        }

        public List<Powers> GetPowersForLeft(int powersId)
        {
            throw new NotImplementedException();
        }

        public List<Powers> GetPowersForUp(int employeeId, int powersParentId)
        {
            return _dal.GetPowersForUp(employeeId,powersParentId);
        }

        public List<Roles> GetRoles(int roleTypeId)
        {
            return _dal.GetRoles(roleTypeId);
        }

        public List<RoleType> GetRoleTypes()
        {
            return _dal.GetRoleTypes();
        }

        public Store GetStore(int storeId)
        {
            throw new NotImplementedException();
        }

        public List<Store> GetStores(int employeeId)
        {
            throw new NotImplementedException();
        }

        public List<Store> GetStoresForBackFill()
        {
            throw new NotImplementedException();
        }

        public Store GetStoresForUpdate(int storeId)
        {
            return _dal.GetStoresForUpdate(storeId);
        }

        public List<ViewStoreInfo> GetStoresFromLogin(string userPhone)
        {
            return _dal.GetStores(userPhone);
        }

        public int UpdateStore(Store store)
        {
            return _dal.UpdateStore(store);
        }
    }
}
