using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Text;
using DAL;

namespace Purchase_Sell_Stock.Services
{
    public class DalFactory
    {
        /// <summary>
        /// 获取dal
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T GetDal<T>(string name) where T : class
        {
            switch (name)
            {
                case "Commodity":
                    return new CommodityBll() as T;
                    break;
                case "Customer":
                    return new CustomerBll() as T;
                    break;
                case "Discount":
                    return new DiscountBll() as T;
                    break;
                case "Infomation":
                    return new InformationBll() as T;
                    break;
                case "Login":
                    return new LoginBll() as T;
                    break;
                case "Order":
                    return new OrderBll() as T;
                    break;
                case "Property":
                    return new PropertyBll() as T;
                    break;
                case "Purchase":
                    return new PurchaseBll() as T;
                    break;
                case "Set":
                    return new SetBll() as T;
                    break;
                case "Storage":
                    return new StorageBll() as T;
                    break;
                case "Stores":
                    return new StorageBll() as T;
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}
