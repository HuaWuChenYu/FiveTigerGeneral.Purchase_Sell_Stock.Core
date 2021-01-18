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

namespace Purchase_Sell_Stock.DAL
{
    /// <summary>
    /// 用于设置
    /// </summary>
    public class SetDal
    {
        DBHelper dBHelper = SimplyFactoryDB.GetInstance("Dapper");
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
        public List<Powers> GetPowersForUp(int employeeId, int powersParentId)
        {
            List<Powers> plist = dBHelper.GetList<Powers>($"select d.* from Employee a join Roles b on " +
                $"a.EmployeeRolesId=b.RolesId join RolesAndPowers c on c.RolesAndPowersRolesId=b.RolesId join Powers d on d.PowersId=c.RolesAndPowersPowersId where EmployeeId={employeeId} and PowersParentId={powersParentId}");
            return plist;
        }
        public List<ViewStoreInfo> GetStores(string userPhone)
        {
            string str = "select d.*,a.EmployeeName,a.EmployeeId,f.ClassifyName,e.IndustryName,datediff(day,d.StoreCreateDate,d.StoreEffectiveDate) StoreTimeOut from Employee a join " +
                "Users b on a.EmployeeUserId=b.UserId join EmployeeAndStore c on c.EmployeeAndStoreEmployeeId=a.EmployeeId " +
                $"join Store d on c.EmployeeAndStoreStoreId=d.StoreId join Industry e on e.IndustryId=d.StoreIndustryId " +
                $"join Classify f on f.ClassifyId=d.StoreClassifyId  where UserPhone='{userPhone}'";
            List<ViewStoreInfo> slist = dBHelper.GetList<ViewStoreInfo>(str);
            return slist;
        }
    }
}
