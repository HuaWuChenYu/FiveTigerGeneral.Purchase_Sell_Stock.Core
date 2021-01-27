using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Purchase_Sell_Stock.Model.GoodsFunction;
using Purchase_Sell_Stock.Model.SettingModels;

namespace Purchase_Sell_Stock.IServices
{
    public interface ISet
    {
        //武晨宇  设置
        //==========================================首页======================================================
        /// <summary>
        /// 通过店铺id  查询店铺
        /// </summary>
        /// <param name="storeId">店铺id</param>
        /// <returns></returns>
        Store GetStore(int storeId);
        /// <summary>
        /// 获取访问次数   查询店铺访问次数字段
        /// </summary>
        /// <param name="StoreId">店铺id</param>
        /// <returns></returns>
        int GetLookStoreCount(int StoreId);
        /// <summary>
        /// 获取订单数
        /// </summary>
        /// <param name="StoreId"></param>
        /// <returns></returns>
        int GetOrdersCount(int StoreId,int TimeType);
        /// <summary>
        /// 访问支付 转化率  
        /// </summary>
        /// <param name="StoreId">店铺id</param>
        /// <param name="TimeType">时间</param>
        /// <returns></returns>
        double GetLookPay(int StoreId, int TimeType);
        /// <summary>
        /// 获取某时间段的支付金额
        /// </summary>
        /// <param name="StoreId">店铺id</param>
        /// <param name="TimeType">时间</param>
        /// <returns></returns>
        decimal GetAllMoney(int StoreId, int TimeType);
        /// <summary>
        /// 支付了的人数
        /// </summary>
        /// <param name="StoreId">店铺id</param>
        /// <param name="TimeType">时间</param>
        /// <returns></returns>
        int GetPayPeopleCount(int StoreId, int TimeType);
        /// <summary>
        /// 当日支付了的平均价格
        /// </summary>
        /// <param name="StoreId">店铺id</param>
        /// <param name="TimeType">时间</param>
        /// <returns></returns>
        decimal GetPayPeopleAvg(int StoreId, int TimeType);
        /// <summary>
        /// 新增了的用户数
        /// </summary>
        /// <param name="StoreId">店铺id</param>
        /// <param name="TimeType">时间</param>
        /// <returns></returns>
        int GetNewUser(int StoreId, int TimeType);
        /// <summary>
        /// 老用户活跃数
        /// </summary>
        /// <param name="StoreId">店铺id</param>
        /// <param name="TimeType">时间</param>
        int GetOldActiveUser(int StoreId, int TimeType);
        /// <summary>
        /// 访问用户数
        /// </summary>
        /// <param name="StoreId">店铺id</param>
        /// <param name="TimeType">时间</param>
        /// <returns></returns>
        int GetLookPeople(int StoreId, int TimeType);
        /// <summary>
        /// 商品排行
        /// </summary>
        /// <param name="storeId">店铺id</param>
        /// <param name="TimeType">时间</param>
        /// <returns></returns>
        List<Goods> GetGoods(int storeId,int TimeType);
        //==========================================模板======================================================
        /// <summary>
        /// 通过员工id 加载店铺信息
        /// </summary>
        /// <param name="employeeId">员工id</param>
        /// <returns></returns>
        List<Store> GetStores(int employeeId);
        /// <summary>
        /// 根据员工id  生成不同的上面导航栏
        /// </summary>
        /// <param name="employeeId">员工id</param>
        /// <returns></returns>
        List<Powers> GetPowersForUp(int employeeId,int powersParentId);
        /// <summary>
        /// 根据权限的父id  生成不同不同的左边导航
        /// </summary>
        /// <param name="powersId">权限父id</param>
        /// <returns></returns>
        List<Powers> GetPowersForLeft(int powersId);
        /// <summary>
        /// 通过用户手机号返回店铺信息
        /// </summary>
        /// <param name="userPhone"></param>
        /// <returns></returns>
        List<ViewStoreInfo> GetStoresFromLogin(string userPhone);
        //==========================================设置======================================================
        /// <summary>
        /// 通过角色类型获取角色
        /// </summary>
        /// <param name="roleTypesId"></param>
        /// <returns></returns>
        List<Roles> GetRoles(int roleTypesId);
        /// <summary>
        /// 用于显示角色类型
        /// </summary>
        /// <returns></returns>
        List<RoleType> GetRoleTypes();
        /// <summary>
        /// 用于修改角色的权限
        /// </summary>
        /// <param name="powerParentId"></param>
        /// <param name="rolesId"></param>
        /// <returns></returns>
        List<Powers> GetPowersBySet(int powerParentId, int rolesId);
        /// <summary>
        /// 通过店铺id  店铺信息
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        Store GetStoresForUpdate(int storeId);
        /// <summary>
        /// 店铺信息的反填显示
        /// </summary>
        /// <returns></returns>
        List<Store> GetStoresForBackFill();
        /// <summary>
        /// 用于修改店铺信息
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        int UpdateStore(Store store);
        
        /// <summary>
        /// 显示所有部门
        /// </summary>
        /// <param name="coding">部门编码</param>
        /// <param name="deptName">部门名称</param>
        /// <returns></returns>
        List<Department> GetDepartments(string coding,string deptName);
        /// <summary>
        /// 角色的权限的显示
        /// </summary>
        /// <returns></returns>
        List<Powers> GetPowers();
        
        /// <summary>
        /// 员工显示
        /// </summary>
        /// <param name="employeeNumber">员工工号</param>
        /// <param name="employeeName">员工姓名</param>
        /// <param name="employeeContact">联系电话</param>
        /// <param name="departmentId">所属部门</param>
        /// <param name="rolesId">所属角色</param>
        /// <returns></returns>
        List<Employee> GetEmployees(string employeeNumber,string employeeName,string employeeContact,int departmentId,int rolesId);
        
        List<Classify> ClassifiesShow();
        /// <summary>
        /// 根据角色查询权限id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        List<Powers> GetPowersByShowId(int roleId);
        /// <summary>
        /// 删除角色的一项权限
        /// </summary>
        /// <param name="powerId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        int DeletePowersAndRoles(string powerId, int roleId);
        /// <summary>
        /// 添加角色的一项权限
        /// </summary>
        /// <param name="powerId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        int AddPowersAndRoles(string powerId, int roleId);
        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <returns></returns>
        List<Employee> GetEmployeesForShow();
        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns></returns>
        List<Department> GetDepartments();
        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        List<Roles> GetRolesForSelect();
        /// <summary>
        /// 添加员工信息
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        int AddEmployee(Employee emp);
        /// <summary>
        /// 通过id查询员工信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee GetEmployeeById(int id);
        /// <summary>
        /// 修改员工
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        int UpdateEmployee(Employee emp);
        /// <summary>
        /// 部门信息
        /// </summary>
        /// <param name="number"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        List<Department> GetDepartmentByShow();
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        int AddDepartment(Department department);
        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int UpdateDepartment(Department department);
        /// <summary>
        /// 通过id获取部门
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Department GetDepartmentById(int id);
        /// <summary>
        /// 添加公司
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        int AddCompany(Company company);
        /// <summary>
        /// 查询店铺是否认证主体 认证过返回值
        /// </summary>
        /// <param name="storeid"></param>
        /// <returns></returns>
        List<Company> IsHaveCompany(int storeid);
        /// <summary>
        /// 添加店铺设置
        /// </summary>
        /// <param name="storeSet"></param>
        /// <returns></returns>
        int AddStoreSet(StoreSet storeSet);
        /// <summary>
        /// 通过权限名称获取权限路径
        /// </summary>
        /// <param name="name"></param>
        /// <param name="empId"></param>
        /// <returns></returns>
        Powers GetPowersBySel(string name, int empId);
        /// <summary>
        /// 根据小菜单id 查询出中大菜单的主键
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        int GetPowerIdForBig(int pid);
        /// <summary>
        /// 获取分类
        /// </summary>
        /// <returns></returns>
        List<Classify> GetClassifiesForShow();
        /// <summary>
        /// 获取行业
        /// </summary>
        /// <returns></returns>
        List<Industry> GetIndustriesForShow();
        /// <summary>
        /// 添加店铺
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        int AddStore(Store store);
        /// <summary>
        /// 获取电话通过员工id
        /// </summary>
        /// <param name="eid"></param>
        /// <returns></returns>
        string GetPhoneByEId(int eid);
        /// <summary>
        /// 获取角色id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        int GetRoleId(string name);
    }
}
