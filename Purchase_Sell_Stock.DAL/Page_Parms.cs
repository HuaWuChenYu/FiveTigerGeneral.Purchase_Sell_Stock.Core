using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Purchase_Sell_Stock.DAL
{
    public class Page_Parms
    {
        public SqlParameter[] Page_Param(string TableFields, string TableName, string SqlWhere, string OrderBy, int pageIndex, int pageSize)
        {
            SqlParameter[] parms = new SqlParameter[]
         {
             new SqlParameter() { ParameterName = "@TableFields", DbType = DbType.String, Value = TableFields },
             new SqlParameter() { ParameterName = "@TableName", DbType = DbType.String, Value =TableName },
             new SqlParameter() { ParameterName = "@SqlWhere", DbType = DbType.String, Value = SqlWhere },
             new SqlParameter() { ParameterName = "@OrderBy", DbType = DbType.String, Value = OrderBy },
             new SqlParameter() { ParameterName = "@PageIndex", DbType = DbType.String, Value = pageIndex },
             new SqlParameter() { ParameterName = "@PageSize", DbType = DbType.String, Value = pageSize },
             new SqlParameter() { ParameterName = "@TotalCount", DbType = DbType.Int32, Direction = ParameterDirection.Output },
         };
            return parms;
        }
    }
}
