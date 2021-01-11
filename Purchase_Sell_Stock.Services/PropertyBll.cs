using Purchase_Sell_Stock.Model.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.DAL;

namespace Purchase_Sell_Stock.Services
{
    public class PropertyBll
    {
        PropertyDal pd = new PropertyDal();
        public List<Amount_settled> amount_SettledsShow()
        { 
            return pd.amount_SettledsShow();
        }
    }
}
