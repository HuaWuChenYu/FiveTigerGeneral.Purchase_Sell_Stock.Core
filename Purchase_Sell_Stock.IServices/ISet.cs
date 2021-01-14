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
        List<Powers> GetPowersForUp(int employeeId);
        /// <summary>
        /// 根据权限的父id  生成不同不同的左边导航
        /// </summary>
        /// <param name="powersId">权限父id</param>
        /// <returns></returns>
        List<Powers> GetPowersForLeft(int powersId);
        //==========================================设置======================================================
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
        /// 主体认证  添加主体
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        int AddCompany(Company company);
        /// <summary>
        /// 店铺设置  添加一条店铺设置
        /// </summary>
        /// <returns></returns>
        int AddStoreSet(StoreSet storeSet);
        /// <summary>
        /// 显示所有部门
        /// </summary>
        /// <param name="coding">部门编码</param>
        /// <param name="deptName">部门名称</param>
        /// <returns></returns>
        List<Department> GetDepartments(string coding,string deptName);
        /// <summary>
        /// 添加一条部门信息
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        int AddDepartment(Department department);
        /// <summary>
        /// 编辑部门
        /// </summary>
        /// <returns></returns>
        int UpdateDepartment(Department department);
        /// <summary>
        /// 角色的权限的显示
        /// </summary>
        /// <returns></returns>
        List<Powers> GetPowers();
        /// <summary>
        /// 角色表的显示
        /// </summary>
        /// <param name="roleTypeId">角色类型id</param>
        /// <returns></returns>
        List<Roles> GetRoles(int roleTypeId);
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
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="employee">员工</param>
        /// <returns></returns>
        int AddEmployee(Employee employee);
        /// <summary>
        /// 修改员工
        /// </summary>
        /// <param name="employee">员工</param>
        /// <returns></returns>
        int UpdateEmployee(Employee employee);
        List<Classify> ClassifiesShow();
    }
}
