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
    }
}
