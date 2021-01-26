using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using NetTaste;
using Purchase_Sell_Stock.DAL.GetDBHelper;
using Purchase_Sell_Stock.Model.SettingModels;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Linq;

namespace Purchase_Sell_Stock.DAL
{
    /// <summary>
    /// 用于设置
    /// </summary>
    public class SetDal
    {
        DBHelper dBHelper = SimplyFactoryDB.GetInstance("Dapper");
        //测试
        public List<Classify> ClassifiesShow()
        {
            //string name = "主店";
            ////' or 1=1 --
            //string name2 = "直销";
            //object obj = dBHelper.ExecuteScalar("select count(*) from Classify where ClassifyName=@name", new { name});
            //DynamicParameters dp = new DynamicParameters();
            //dp.Add("@MemberId", "2019595");
            //dp.Add("@Name", "张三");
            //dp.Add("@Name2", "", DbType.String, ParameterDirection.Output);
            //int n = dBHelper.ExecuteNonQuery("page_Test", dp);
            List<Classify> clist = dBHelper.GetList<Classify>("select * from Classify");
            return clist;
        }
        //角色名称获取角色id
        public int GetRoleId(string name)
        {
            string sql = $"select RolesId from Roles where RolesName='{name}'";
            int id = dBHelper.GetList<Roles>(sql).SingleOrDefault().RolesId;
            return id;
        }
        //获取手机号
        public string GetPhoneByEId(int eid)
        {
            string sql = $"select UserPhone from Employee a join Users b on a.EmployeeUserId=b.UserId where EmployeeId={eid}";
            string phone= dBHelper.GetList<Users>(sql).SingleOrDefault().UserPhone;
            return phone;
        }
        //添加店铺
        public int AddStore(Store store)
        {
            string sql2 = "select top 1 * from Store order by StoreId desc";
            int s = dBHelper.GetList<Store>(sql2).SingleOrDefault().StoreId;
            string sql = $"insert into Store values ('WH100{s+1}','{store.StoreName}',NULL,'{store.StoreLinkman}',NULL,'{store.StoreLinkmanPhone}',NULL,NULL,'1','{DateTime.Now.AddMonths(1)}','{DateTime.Now}','{store.StoreLogo}','{store.StoreIntroduction}','{store.StoreIndustryId}','{store.StoreClassifyId}','{store.StoreCompanyId}',NULL)";
            int n = dBHelper.ExecuteNonQuery(sql);
            string sql4 = $"select StoreId from Store where StoreCoding='WH100{s + 1}'";
            int id = dBHelper.GetList<Store>(sql4)[0].StoreId;
            string sql3 = $"insert into EmployeeAndStore values ('{store.StoreId}','{id}')";
            int nn = dBHelper.ExecuteNonQuery(sql3);
            return n;
        }
        //获取行业
        public List<Industry> GetIndustriesForShow()
        {
            string sql = "select * from Industry";
            List<Industry> ilist = dBHelper.GetList<Industry>(sql);
            return ilist;
        }
        //获取分类
        public List<Classify> GetClassifiesForShow()
        {
            string sql = "select * from Classify";
            List<Classify> clist = dBHelper.GetList<Classify>(sql);
            return clist;
        }
        //根据小菜单id 查询出中大菜单的主键
        public int GetPowerIdForBig(int pid)
        {
            string sql = $"select PowersParentId from Powers where PowersId={pid}";
            int n = dBHelper.GetList<Powers>(sql).ToList().SingleOrDefault().PowersParentId;
            return n;
        }
        //通过权限名称获取权限路径
        public Powers GetPowersBySel(string name,int empId)
        {
            string sql = "select d.* from Employee a join Roles b on a.EmployeeRolesId=b.RolesId join RolesAndPowers c on c.RolesAndPowersRolesId=b.RolesId " +
                $"join Powers d on d.PowersId=c.RolesAndPowersPowersId where EmployeeId={empId} and PowersName='{name}'";
            Powers power = dBHelper.GetList<Powers>(sql).SingleOrDefault();
            return power;
        }
        //添加店铺设置
        public int AddStoreSet(StoreSet storeSet)
        {
            string sql = $"insert into StoreSet values('{storeSet.StoreSetInformation}','{storeSet.StoreSetPoster}',{(storeSet.StoreSetIsService?1:0)},{(storeSet.StoreSetIsEmpty?1:0)},{storeSet.StoreSetIsEvaluate},{(storeSet.StoreSetIsSales?1:0)},{(storeSet.StoreSetIsDeduction?1:0)},{storeSet.StoreSetAtuoCancel},{(storeSet.StoreSetMakeInvoice?1:0)},{storeSet.StoreSetChangeStore},{(storeSet.StoreSetOrder?1:0)},{storeSet.StoreSetOperation},'{storeSet.StoreSetClose}',{storeSet.StoreId})";
            int n= dBHelper.ExecuteNonQuery(sql);
            return n;
        }
        //查询店铺是否认证主体 认证过返回值
        public List<Company> IsHaveCompany(int storeid)
        {
            string sql = $"select * from Store where StoreId={storeid}";
            int n= dBHelper.GetList<Store>(sql).SingleOrDefault().StoreCompanyId;
            if (n!=default &&n > 0)
            {
                string sql2 = $"select a.* from Company a join Store b on b.StoreCompanyId=a.CompanyId where StoreId={storeid}";
                List<Company> clist = dBHelper.GetList<Company>(sql2);
                return clist;
            }
            else
            {
                return null;
            }
        }
        //添加主体
        public int AddCompany(Company company)
        {
            string sql = $"insert into Company values ('{company.CompanyName}','{company.CompanyAddress}','{company.CompanyLegalPerson}','{company.CompanyIDNUM}','{company.CompanyUnifyNUM}','{company.CompanyPhoto}','{company.CompanyPersonName}','{company.CompanyPersonIDNUM}','{company.CompanyLinkmanPhone}','{company.IDFront}','{company.IDBack}','1','{(company.CompanyType?1:0)}')";
            int n = dBHelper.ExecuteNonQuery(sql);
            string sql2 = "select * from Company";
            int id = dBHelper.GetList<Company>(sql2).OrderByDescending(s=>s.CompanyId).FirstOrDefault().CompanyId;
            string sql3 = $"update Store set StoreCompanyId='{id}' where StoreId={company.StoreId}";
            int j = dBHelper.ExecuteNonQuery(sql3);
            if (n>0&&j>0)
            {
                return 1;
            }
            return 0;
        }
        //通过id获取部门
        public Department GetDepartmentById(int id)
        {
            string sql = $"select * from Department where DepartmentId={id}";
            Department department = dBHelper.GetList<Department>(sql).SingleOrDefault();
            return department;
        }
        //修改部门
        public int UpdateDepartment(Department department)
        {
            string sql = $"update Department set DepartmentName='{department.DepartmentName}',DepartmentParentId='{department.DepartmentParentId}' where DepartmentId={department.DepartmentId}";
            int n = dBHelper.ExecuteNonQuery(sql);
            return n;
        }
        //添加部门
        public int AddDepartment(Department department)
        {
            string sql = " select top 1 * from Department order by DepartmentId desc";
            department.DepartmentNumber = (dBHelper.GetList<Department>(sql).SingleOrDefault().DepartmentId+1).ToString();
            string sql2 = $"insert into Department values ('WHSJ10{department.DepartmentNumber}','{department.DepartmentName}','{department.DepartmentParentId}')";
            int n = dBHelper.ExecuteNonQuery(sql2);
            return n;
        }
        //获取部门信息
        public List<Department> GetDepartmentByShow()
        {
            string sql = $"select * from Department";
            List<Department> elist = dBHelper.GetList<Department>(sql).OrderBy(s=>s.DepartmentParentId).ToList();
            List<Department> dlist = new List<Department>();
            List<Department> nlist = elist.Where(s => s.DepartmentParentId == 0).ToList();
            foreach (var item in nlist)
            {
                item.Level = 1;
                dlist.Add(item);
                List<Department> list = elist.Where(s => s.DepartmentParentId == item.DepartmentId).ToList();
                foreach (var item2 in list)
                {
                    item2.Level = 2;
                    dlist.Add(item2);
                    List<Department> list2 = elist.Where(s => s.DepartmentParentId == item2.DepartmentId).ToList();
                    if (list2.Count>0)
                    {
                        foreach (var item3 in list2)
                        {
                            item3.Level = 3;
                            dlist.Add(item3);
                        }
                    }
                }
            }
            return dlist;
        }
        //修改员工
        public int UpdateEmployee(Employee emp)
        {
            string sql = $"update Employee set EmployeeName='{emp.EmployeeName}',EmployeeContact='{emp.EmployeeContact}',EmployeeStates='{(emp.EmployeeStates?1:0)}',EmployeeDepartmentId='{emp.EmployeeDepartmentId}',EmployeeRolesId='{emp.EmployeeRolesId}' where EmployeeId={emp.EmployeeId}";
            int n = dBHelper.ExecuteNonQuery(sql);
            return n;
        }
        //通过id查询员工信息
        public Employee GetEmployeeById(int id)
        {
            string sql = $"select * from Employee where EmployeeId={id}";
            Employee emp = dBHelper.GetList<Employee>(sql).ToList().FirstOrDefault();
            return emp;
        }
        //添加员工信息
        public int AddEmployee(Employee emp)
        {
            string sql2 = $"select UserId from Users where UserAccount='{emp.DepartmentName}'";//emp.DepartmentName 当做用户账号来传值
            Users user = dBHelper.GetList<Users>(sql2).ToList().FirstOrDefault();
            string sql = $"insert into Employee values ('{emp.EmployeeNumber}','{emp.EmployeeName}','{emp.EmployeeContact}','{DateTime.Now}','{(emp.EmployeeStates?1:0)}','{emp.EmployeeDepartmentId}','{user.UserId}','{emp.EmployeeRolesId}')";
            int n = dBHelper.ExecuteNonQuery(sql);
            return n;
        }
        //获取角色信息
        public List<Roles> GetRolesForSelect()
        {
            string sql = "select * from Roles";
            List<Roles> rlist = dBHelper.GetList<Roles>(sql);
            return rlist;
        }
        //获取部门信息
        public List<Department> GetDepartments()
        {
            string sql = "select * from Department";
            List<Department> dlist = dBHelper.GetList<Department>(sql);
            return dlist;
        }
        //获取员工信息
        public List<Employee> GetEmployeesForShow()
        {
            string sql = "select * from Employee a join Department b on a.EmployeeDepartmentId=b.DepartmentId join Roles c on a.EmployeeRolesId=c.RolesId ";
            List<Employee> elist = dBHelper.GetList<Employee>(sql);
            return elist;
        }
        //用于显示导航
        public List<Powers> GetPowersForUp(int employeeId, int powersParentId)
        {
            List<Powers> plist = dBHelper.GetList<Powers>($"select d.* from Employee a join Roles b on " +
                $"a.EmployeeRolesId=b.RolesId join RolesAndPowers c on c.RolesAndPowersRolesId=b.RolesId join Powers d on d.PowersId=c.RolesAndPowersPowersId where EmployeeId={employeeId} and PowersParentId={powersParentId}");
            return plist;
        }
        //用于选择店铺页面
        public List<ViewStoreInfo> GetStores(string userPhone)
        {
            string str = "select d.*,a.EmployeeName,a.EmployeeId,f.ClassifyName,e.IndustryName,datediff(day,d.StoreCreateDate,d.StoreEffectiveDate) StoreTimeOut from Employee a join " +
                "Users b on a.EmployeeUserId=b.UserId join EmployeeAndStore c on c.EmployeeAndStoreEmployeeId=a.EmployeeId " +
                $"join Store d on c.EmployeeAndStoreStoreId=d.StoreId join Industry e on e.IndustryId=d.StoreIndustryId " +
                $"join Classify f on f.ClassifyId=d.StoreClassifyId  where UserPhone='{userPhone}'";
            List<ViewStoreInfo> slist = dBHelper.GetList<ViewStoreInfo>(str);
            return slist;
        }
        //用于获取修改的店铺信息   
        public Store GetStoresForUpdate(int storeId)
        {
            string sql = $"select * from Store where StoreId={storeId}";
            Store store = dBHelper.GetList<Store>(sql).FirstOrDefault();
            return store;
        }
        //修改店铺信息
        public int UpdateStore(Store store)
        {
            string sql = $"update Store set StoreName = '{store.StoreName}' ,StoreIntroduction='{store.StoreIntroduction}', " +
                $"StorePrincipalPhone='{store.StorePrincipalPhone}', StoreLinkman='{store.StoreLinkman}',StoreLinkmanPhone" +
                $"='{store.StoreLinkmanPhone}',StoreLogo='{store.StoreLogo}' where StoreCoding='{store.StoreCoding}'";
            int n = dBHelper.ExecuteNonQuery(sql);
            return n;
        }
        //用于修改角色的权限
        public List<Powers> GetPowersBySet(int powerParentId,int rolesId)
        {
            string sql = "select * from Powers a join RolesAndPowers b on a.PowersId=b.RolesAndPowersPowersId join Roles c on b." +
                $"RolesAndPowersRolesId=c.RolesId where PowersParentId={powerParentId} and RolesId={rolesId}";
            List<Powers> plist = dBHelper.GetList<Powers>(sql);
            return plist;
        }
        //用于显示角色类型
        public List<RoleType> GetRoleTypes()
        {
            string sql = "select * from RoleType";
            List<RoleType> rlist = dBHelper.GetList<RoleType>(sql);
            return rlist;
        }
        //通过角色类型获取角色
        public List<Roles> GetRoles(int roleTypesId)
        {
            string sql = $"select * from Roles where RolesRoleTypeId={roleTypesId}";
            List<Roles> rlist = dBHelper.GetList<Roles>(sql);
            return rlist;
        }
        //根据角色查询权限id
        public List<Powers> GetPowersByShowId(int roleId)
        {
            string sql = "select PowersId from Powers a join RolesAndPowers b on a.PowersId=b.RolesAndPowersPowersId " +
                $"join Roles c on b.RolesAndPowersRolesId=c.RolesId where RolesId={roleId}";
            List<Powers> plist = dBHelper.GetList<Powers>(sql);
            return plist;
        }
        //删除角色的一项权限
        
        public int DeletePowersAndRoles(string powerId,int roleId)
        {
            string sql = $"delete RolesAndPowers where RolesAndPowersPowersId in ({powerId}) and  RolesAndPowersRolesId={roleId}";
            int n = dBHelper.ExecuteNonQuery(sql);
            return n;
        }
        //添加角色的一项权限
        public int AddPowersAndRoles(string powerId, int roleId)
        {
            int n=0;
            string[] imgArr = powerId.Split(new char[] { ',' });
            foreach (var item in imgArr)
            {
                string sql = $"insert into RolesAndPowers values ({roleId},{item})";
                n += dBHelper.ExecuteNonQuery(sql);
            }
            return n;
        }
    }
}
