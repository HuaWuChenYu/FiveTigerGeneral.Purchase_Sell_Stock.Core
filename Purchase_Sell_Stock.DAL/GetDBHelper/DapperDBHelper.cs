using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.DAL.GetDBHelper
{
    public class DapperDBHelper : DBHelper
    {
        string connStr = "Data Source=192.168.137.64;Initial Catalog=OurProject;User ID=sa";
        public override int ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }

        public override object ExecuteScalar()
        {
            throw new NotImplementedException();
        }

        public override List<T> GetList<T>()
        {
            return new List<T>();
        }
    }
}
