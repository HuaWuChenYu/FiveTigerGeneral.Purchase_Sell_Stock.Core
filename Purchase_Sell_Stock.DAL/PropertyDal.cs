using Purchase_Sell_Stock.DAL.GetDBHelper;
using Purchase_Sell_Stock.Model.Storage;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using Purchase_Sell_Stock.Model.Propertys;
using Dapper;

namespace Purchase_Sell_Stock.DAL
{
    public class PropertyDal
    {

        DBHelper dpper = GetDBHelper.SimplyFactoryDB.GetInstance("Dapper");
        DBHelper ado = GetDBHelper.SimplyFactoryDB.GetInstance("Ado");
        /// <summary>
        /// 插入待结数据
        /// </summary>
        /// <returns></returns>
        public int AddAmount_settledInfos()
        {
            string sql = "insert  into Amount_settled values('1','20.33','2020-5-5','JD_10002','矿泉水')";

            return dpper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 插入余额数据
        /// </summary>
        /// <returns></returns>
        public int Addbalance_MoneyInfos()
        {
            string sql = "insert  into balance_Money values('1','20.33','2020-5-5','JD_10002','矿泉水')";
            return ado.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 插入充值记录数据
        /// </summary>
        /// <returns></returns>
        public int AddRechanged_recordInfos()
        {
            string sql = "insert  into Rechanged_record values('1','20.33','2020-5-5','JD_10002','矿泉水')";

            return ado.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 插入详细账单数据
        /// </summary>
        /// <returns></returns>
        public int AddBilling_detailsInfos()
        {
            string sql = "insert  into Billing_details values('1','20.33','2020-5-5','JD_10002','矿泉水')";
            return dpper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 显示待结算信息
        /// </summary>
        /// <returns></returns>
        public List<Amount_settledMoney> Amount_settledMoneyShowInfos()
        {
            string sql = "select Amount_settledMoney,OrderSubmitTime,OrderUnm,ProductName from Amount_settled";
            return ado.GetList<Amount_settledMoney>(sql);
        }

        /// <summary>
        /// 显示余额信息 
        ///查询条件（ 时间范围内 单据类型 说明 ）
        /// </summary>
        /// <returns></returns>

        public Coods_Page<balance_Money> balance_MoneyShowInfos(string Order_num, string starttime_quantum, string endttime_quantum, string remark ,int pageIndex, int pageSize )
        {
            string sql = $" 1=1";
            if (!string.IsNullOrEmpty(Order_num))
            {
                sql += $" and Order_num ='{Order_num}'";
            }
            if (!string.IsNullOrEmpty(starttime_quantum) && !string.IsNullOrEmpty(endttime_quantum))
            {
                sql += $" and OrderFinshTime between '{starttime_quantum}' And '{endttime_quantum}'";
            }
            if (!string.IsNullOrEmpty(remark))
            {
                sql += $" and Explain like '%{remark}%'";
            }
            string TableFields = "Balance_MoneyId,OrderFinshTime,Income,Balance_Money,Order_num,Income_Source,Explain ";
            string TableName = "MoneyBalance a join Balance_Money b on a.UserId=b.UserId";
            string SqlWhere = sql;
            string OrderBy = "Balance_MoneyId";
            Page_Params _Params = new Page_Params();
            Coods_Page<balance_Money> lis = new Coods_Page<balance_Money>();
            SqlParameter[] Page_Param = _Params.Page_Param(TableFields, TableName, SqlWhere, OrderBy, pageIndex, pageSize);
            lis.list =ado.GetList<balance_Money>("Proc_Paging", Page_Param);
            lis.AllCount = Convert.ToInt32(Page_Param[6].Value);

            return lis;
        }


        /// <summary>
        /// 显示充值记录信息
        /// </summary>
        /// <returns></returns>
        public Coods_Page<Rechanged_record> Rechanged_recordShowInfos(int pageIndex=1, int pageSize=2)
        {
           
            Coods_Page<Rechanged_record> lis = new Coods_Page<Rechanged_record>();

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@SqlWhere", " 1=1");
            dynamicParameters.Add("@TableFields", " *");
            dynamicParameters.Add("@TableName", "Rechanged_record");
            dynamicParameters.Add("@OrderBy","Rechanged_recordId");
            dynamicParameters.Add("@pageIndex",pageIndex);
            dynamicParameters.Add("@pageSize",pageSize);
            dynamicParameters.Add("@TotalCount",lis.AllCount,DbType.Int32,ParameterDirection.Output);
            lis.list = dpper.GetList<Rechanged_record>("Proc_Paging",dynamicParameters);
            lis.AllCount = dynamicParameters.Get<int>("@TotalCount");

            return lis;
        }

        /// <summary>
        /// 显示详细账单信息
        /// </summary>
        /// <returns></returns>
        public Coods_Page<Billing_details> Billing_detailsShowInfos(string page, int pageIndex, int pageSize, string Account_Type, string Order_NUm, int InorOut, string Order_type, string statrtime, string endtime)
        {
            string sql = $" 1=1 and datediff(month, date_recorded, getdate())+'{page}' = 0";
            if (!string.IsNullOrEmpty(Account_Type))
            {
                sql = $" 1=1 and Account_Type='{Account_Type}'";
            }
            if (!string.IsNullOrEmpty(Order_NUm))
            {
                sql += $" and Order_NUm='{Order_NUm}'";
            }
            if (InorOut>0 && InorOut == 1)
            {
                sql += $" and InorOut=1";
            }
            if (InorOut>0 && InorOut == 2)
            {
                sql += $" and InorOut=2";
            }
            if (!string.IsNullOrEmpty(Order_type))
            {
                sql += $" and Order_type='{Order_type}'";
            }
            if (!string.IsNullOrEmpty(statrtime) &&!string.IsNullOrEmpty(endtime))
            {
                sql = $"1=1 and date_recorded between '{statrtime}' and '{endtime}'";
            }
            string TableFields = "Billing_detailsId,date_recorded,Account_Type,Account_Money,Balance_Money,InorOut,Order_type,Order_NUm";
            string TableName = "Billing_details a join MoneyBalance b on a.UserId=b.UserId";
            string SqlWhere = sql;
            string OrderBy = "Billing_detailsId";
            Page_Params _Params = new Page_Params();
            Coods_Page<Billing_details> lis = new Coods_Page<Billing_details>();
            SqlParameter[] Page_Param = _Params.Page_Param(TableFields, TableName, SqlWhere, OrderBy, pageIndex, pageSize);
            lis.list = GetDBHelper.SimplyFactoryDB.GetInstance("Ado").GetList<Billing_details>("Proc_Paging", Page_Param);
            lis.AllCount = Convert.ToInt32(Page_Param[6].Value);

            return lis;
        }
    }
}
