using Purchase_Sell_Stock.DAL.GetDBHelper;
using Purchase_Sell_Stock.Model.Storage;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using Purchase_Sell_Stock.Model.Propertys;

namespace Purchase_Sell_Stock.DAL
{
    public class PropertyDal
    {

        /// <summary>
        /// 插入待结数据
        /// </summary>
        /// <returns></returns>

        DBHelper dB = GetDBHelper.SimplyFactoryDB.GetInstance("AdoDBHelper");
        public int AddAmount_settledInfos()
        {
            string sql = "insert  into Amount_settled values('1','20.33','2020-5-5','JD_10002','矿泉水')";

            return dB.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 插入余额数据
        /// </summary>
        /// <returns></returns>
        public int Addbalance_MoneyInfos()
        {
            string sql = "insert  into balance_Money values('1','20.33','2020-5-5','JD_10002','矿泉水')";
            return dB.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 插入充值记录数据
        /// </summary>
        /// <returns></returns>
        public int AddRechanged_recordInfos()
        {
            string sql = "insert  into Rechanged_record values('1','20.33','2020-5-5','JD_10002','矿泉水')";

            return dB.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 插入详细账单数据
        /// </summary>
        /// <returns></returns>
        public int AddBilling_detailsInfos()
        {
            string sql = "insert  into Billing_details values('1','20.33','2020-5-5','JD_10002','矿泉水')";
            return dB.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 显示待结算信息
        /// </summary>
        /// <returns></returns>
        public List<Amount_settledMoney> Amount_settledMoneyShowInfos()
        {
            string sql = "select Amount_settledMoney,OrderSubmitTime,OrderUnm,ProductName,Remaek from Amount_settled";
            return dB.GetList<Amount_settledMoney>(sql);
        }

        /// <summary>
        /// 显示余额信息 
        ///查询条件（ 时间范围内 单据类型 说明 ）
        /// </summary>
        /// <returns></returns>
        public Coods_Page<balance_Money> balance_MoneyShowInfos(int pageIndex, int pageSize, string Order_num, string starttime_quantum, string endttime_quantum, string remark)
        {
            string sql = $"where 1=1";
            if (!string.IsNullOrEmpty(Order_num))
            {
                sql += $" and Order_num ={Order_num}";
            }
            if (!string.IsNullOrEmpty(starttime_quantum) && !string.IsNullOrEmpty(endttime_quantum))
            {
                sql += $"where OrderSubmitTime between '{starttime_quantum}' And '{endttime_quantum}'";
            }
            if (!string.IsNullOrEmpty(remark))
            {
                sql += $" and remark like '%{remark}%'";
            }
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter(){ParameterName="@TableFields",DbType=DbType.String,Value="*" },
                new SqlParameter(){ParameterName="@TableName",DbType=DbType.String,Value="balance_Money" },
                new SqlParameter(){ParameterName="@SqlWhere",DbType=DbType.String,Value=sql },
                new SqlParameter(){ParameterName="@OrderBy",DbType=DbType.String,Value="balance_MoneyId " },
                new SqlParameter(){ParameterName="@PageIndex",DbType=DbType.String,Value=pageIndex },
                new SqlParameter(){ParameterName="@PageSize",DbType=DbType.String,Value=pageSize },
                new SqlParameter(){ParameterName="@TotalCount",DbType=DbType.Int32,Direction=ParameterDirection.Output},
            };
        
            Coods_Page<balance_Money> lis = new Coods_Page<balance_Money>();
            lis.list = dB.GetList<balance_Money>("Proc_Paging", parms);

            return lis;
        }

        /// <summary>
        /// 显示充值记录信息
        /// </summary>
        /// <returns></returns>
        public List<Rechanged_record> Rechanged_recordShowInfos()
        {
            string sql = "select * from balance_Money";
            return dB.GetList<Rechanged_record>(sql);
        }

        /// <summary>
        /// 显示详细账单信息
        /// </summary>
        /// <returns></returns>
        public List<Billing_details> Billing_detailsShowInfos()
        {
            string sql = "select * from Billing_details";
            return dB.GetList<Billing_details>(sql);
        }
    }
}
