﻿using Purchase_Sell_Stock.DAL.GetDBHelper;
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
        public int AddBilling_detailsInfos(int UserId, string Account_Type, decimal Account_Money, int InorOut, string Order_type, string Order_NUm)
        {
            string sql = $"insert into Billing_details values('{UserId}','{DateTime.Now}','{Account_Type}','{Account_Money}','{InorOut}','{Order_type}','{Order_NUm}')";
            return dpper.ExecuteNonQuery(sql);
        }


        /// <summary>
        /// 显示待结算信息
        /// </summary>
        /// <returns></returns>
        public Coods_Page<Amount_settledMoney> Amount_settledMoneyShowInfos(string OrderUnm, int pageIndex, int pageSize)
        {
            string sql = $" 1=1";
            if (!string.IsNullOrEmpty(OrderUnm))
            {
                sql += $" and OrderUnm='{OrderUnm}'";
            }

            string TableFields = "*";
            string TableName = "Amount_settled";
            string SqlWhere = sql;
            string OrderBy = "Amount_settleId";
            Page_Params _Params = new Page_Params();
            Coods_Page<Amount_settledMoney> lis = new Coods_Page<Amount_settledMoney>();
            SqlParameter[] Page_Param = _Params.Page_Param(TableFields, TableName, SqlWhere, OrderBy, pageIndex, pageSize);
            lis.list = ado.GetList<Amount_settledMoney>("Proc_Paging", Page_Param);
            lis.AllCount = Convert.ToInt32(Page_Param[6].Value);
            return lis;
        }

        /// <summary>
        /// 显示余额信息 
        ///查询条件（ 时间范围内 单据类型 说明 ）
        /// </summary>
        /// <returns></returns>

        public Coods_Page<balance_Money> balance_MoneyShowInfos(string Order_num, string starttime_quantum, string endttime_quantum, string remark, int pageIndex, int pageSize)
        {
            string sql = $" 1=1 and a.UserId=1";
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
            string TableFields = "Balance_MoneyId,OrderFinshTime,Income,Balance_Money,Order_num,Income_Source,Explain,(select SUM(Amount_settledMoneys ) from Amount_settled) as sttledmoney ";
            string TableName = "MoneyBalance a join Balance_Money b on a.UserId=b.UserId join Amount_settled c on b.UserId=c.UserId";
            string SqlWhere = sql;
            string OrderBy = "Balance_MoneyId";
            Page_Params _Params = new Page_Params();
            Coods_Page<balance_Money> lis = new Coods_Page<balance_Money>();
            SqlParameter[] Page_Param = _Params.Page_Param(TableFields, TableName, SqlWhere, OrderBy, pageIndex, pageSize);
            lis.list = ado.GetList<balance_Money>("Proc_Paging", Page_Param);
            lis.AllCount = Convert.ToInt32(Page_Param[6].Value);

            return lis;
        }


        /// <summary>
        /// 显示充值记录信息
        /// </summary>
        /// <returns></returns>
        public Coods_Page<Rechanged_record> Rechanged_recordShowInfos(int pageIndex = 1, int pageSize = 2)
        {

            Coods_Page<Rechanged_record> lis = new Coods_Page<Rechanged_record>();

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@SqlWhere", " 1=1");
            dynamicParameters.Add("@TableFields", " *");
            dynamicParameters.Add("@TableName", "Rechanged_record");
            dynamicParameters.Add("@OrderBy", "Rechanged_recordId");
            dynamicParameters.Add("@pageIndex", pageIndex);
            dynamicParameters.Add("@pageSize", pageSize);
            dynamicParameters.Add("@TotalCount", lis.AllCount, DbType.Int32, ParameterDirection.Output);
            lis.list = dpper.GetList<Rechanged_record>("Proc_Paging", dynamicParameters);
            lis.AllCount = dynamicParameters.Get<int>("@TotalCount");

            return lis;
        }

        /// <summary>
        /// 显示详细账单信息
        /// </summary>
        /// <returns></returns>
        public Coods_Page<Billing_details> Billing_detailsShowInfos(string UserId, string page, int pageIndex, int pageSize, string Account_Type, string Order_NUm, int InorOut, string Order_type, string statrtime, string endtime)
        {
            UserId = "1";
            string sql = $" 1=1  and  datediff(month, date_recorded, getdate()) = 0 ";
            string num = $"select COUNT(*) from Billing_details a where datediff(month, date_recorded, getdate()) = 0 ";
            string MoneySum =$"select SUM(Account_Money) from Billing_details a where datediff(month, date_recorded, getdate()) = 0 ";
            string TableFields;
            if (!string.IsNullOrEmpty(Account_Type))
            {

                sql += $" and Account_Type='{Account_Type}'";
                num += $" and Account_Type='{Account_Type}'";
                MoneySum += $" and Account_Type='{Account_Type}'";
            }
            if (!string.IsNullOrEmpty(Order_NUm))
            {
                sql += $" and Order_NUm='{Order_NUm}'";
                num += $" and Order_NUm='{Order_NUm}'";
                MoneySum += $" and Order_NUm='{Order_NUm}'";
            }
            if (InorOut == 1)
            {
                sql += $" and InorOut=1";
                num += $" and InorOut=1";
                MoneySum += $" and InorOut=1";
            }
            else if (InorOut == 2)
            {
                sql += $" and InorOut=2";
                num += $" and InorOut=2";
                MoneySum += $" and InorOut=2";
            }
            if (!string.IsNullOrEmpty(Order_type))
            {
                sql += $" and Order_type='{Order_type}'";
                num += $" and Order_type='{Order_type}'";
                MoneySum += $" and Order_type='{Order_type}'";
            }
            if (!string.IsNullOrEmpty(statrtime) && !string.IsNullOrEmpty(endtime))
            {
                sql = $" 1=1 and date_recorded between '{statrtime}' And '{endtime}'";
                num = $"select COUNT(*) from Billing_details a where date_recorded between '{statrtime}' And '{endtime}'";
                MoneySum = $"select SUM(Account_Money) from Billing_details a where date_recorded between '{statrtime}' And '{endtime}' ";
                if (!string.IsNullOrEmpty(Account_Type))
                {

                    sql += $" and Account_Type='{Account_Type}'";
                    num += $" and Account_Type='{Account_Type}'";
                    MoneySum += $" and Account_Type='{Account_Type}'";
                }
                if (!string.IsNullOrEmpty(Order_NUm))
                {
                    sql += $" and Order_NUm='{Order_NUm}'";
                    num += $" and Order_NUm='{Order_NUm}'";
                    MoneySum += $" and Order_NUm='{Order_NUm}'";
                }
                if (InorOut == 1)
                {
                    sql += $" and InorOut=1";
                    num += $" and InorOut=1";
                    MoneySum += $" and InorOut=1";
                }
                else if (InorOut == 2)
                {
                    sql += $" and InorOut=2";
                    num += $" and InorOut=2";
                    MoneySum += $" and InorOut=2";
                }
                if (!string.IsNullOrEmpty(Order_type))
                {
                    sql += $" and Order_type='{Order_type}'";
                    num += $" and Order_type='{Order_type}'";
                    MoneySum += $" and Order_type='{Order_type}'";
                }
                TableFields = $"Billing_detailsId,date_recorded,Account_Type,Account_Money,Balance_Money,InorOut,Order_type,Order_NUm,({num}  group by InorOut having a.InorOut = b.InorOut) Num,({MoneySum} group by InorOut having a.InorOut = b.InorOut) MoneySum";
            }
            else
            {

                TableFields = $"Billing_detailsId,date_recorded,Account_Type,Account_Money,Balance_Money,InorOut,Order_type,Order_NUm,({num} group by InorOut having a.InorOut = b.InorOut) Num,({MoneySum} group by InorOut having a.InorOut = b.InorOut) MoneySum";

            }
           
            string TableName = "Billing_details b join MoneyBalance c on b.UserId=c.UserId ";
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
