using Purchase_Sell_Stock.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model.SettingModels;
using Purchase_Sell_Stock.IServices;
using Purchase_Sell_Stock.Model.GoodsFunction;

namespace Purchase_Sell_Stock.Services
{
    /// <summary>
    /// 用于设置
    /// </summary>
    public class SetBll :ISet
    {   
        SetDal _dal = DalFactory.GetDal<SetDal>("Set");

        public int AddCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public int AddDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public int AddEmployee(Employee employee)
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

        public List<Powers> GetPowersForLeft(int powersId)
        {
            throw new NotImplementedException();
        }

        public List<Powers> GetPowersForUp(int employeeId)
        {
            throw new NotImplementedException();
        }

        public List<Roles> GetRoles(int roleTypeId)
        {
            throw new NotImplementedException();
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

        public int UpdateDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public int UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public int UpdateStore(Store store)
        {
            throw new NotImplementedException();
        }
    }
}
