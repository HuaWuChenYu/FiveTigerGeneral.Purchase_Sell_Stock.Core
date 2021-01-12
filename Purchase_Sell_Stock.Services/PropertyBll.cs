using Purchase_Sell_Stock.Model.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.DAL;
using Purchase_Sell_Stock.IServices;
using Org.BouncyCastle.Cms;

namespace Purchase_Sell_Stock.Services
{
    public class PropertyBll: IProperty
    {
        PropertyDal pd = new PropertyDal();
        public List<Amount_settled> amount_SettledsShow()
        {
            return new List<Amount_settled>();/* pd.amount_SettledsShow();*/
        }
    }
}
