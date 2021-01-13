using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using NetTaste;
using Purchase_Sell_Stock.DAL.GetDBHelper;
using Purchase_Sell_Stock.Model.SettingModels;
using System.Data.SqlClient;
using System.Data;

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
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter(){ ParameterName="@MemberId",DbType=DbType.Int32,Value=111},
                new SqlParameter(){ ParameterName="@Name",DbType=DbType.AnsiString,Value="hhhhh"}
            };
            List<Classify> clist = dBHelper.GetList<Classify>("page_Test",paras);
            //List<Classify> clist= DapperHelper.Query<Classify>("select * from Classify");
            return clist;
        }
    }
}
