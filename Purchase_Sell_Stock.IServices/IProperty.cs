using Purchase_Sell_Stock.Model.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.IServices
{
    public interface IProperty
    {
        List<Amount_settled> amount_SettledsShow();
    }
}
