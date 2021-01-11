using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.DAL.GetDBHelper
{
    public class DapperDBHelper : DBHelper
    {
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
            throw new NotImplementedException();
        }
    }
}
