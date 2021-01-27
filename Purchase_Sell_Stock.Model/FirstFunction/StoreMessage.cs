using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Sell_Stock.Model.FirstFunction
{
    public class StoreMessage
    {
        public int StoreMessageId { get; set; }
        public string StoreMessageContent { get; set; }
        public bool StoreMessageState { get; set; }
        public DateTime StoreMessageTime { get; set; }
        public string StrStoreMessageTime { get { return StoreMessageTime.ToString("yyyy年MM月dd日"); } }
        public int StoreId { get; set; }

    }
}
