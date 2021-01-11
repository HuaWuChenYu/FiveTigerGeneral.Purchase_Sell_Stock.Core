using System;
using System.Collections.Generic;
using System.Text;
using Purchase_Sell_Stock.Model.SettingModels;

namespace Purchase_Sell_Stock.IServices
{
    public interface ISet
    {
        List<Classify> ClassifiesShow();
    }
}
