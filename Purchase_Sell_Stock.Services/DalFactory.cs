using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Text;
using Purchase_Sell_Stock.DAL;

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
                    return new CommodityDal() as T;
                    break;
                case "Customer":
                    return new CustomerDal() as T;
                    break;
                case "Discount":
                    return new DiscountDal() as T;
                    break;
                case "Infomation":
                    return new InformationDal() as T;
                    break;
                case "Login":
                    return new LoginDal() as T;
                    break;
                case "Order":
                    return new OrderDal() as T;
                    break;
                case "Property":
                    return new PropertyDal() as T;
                    break;
                case "Purchase":
                    return new PurchaseDal() as T;
                    break;
                case "Set":
                    return new SetDal() as T;
                    break;
                case "Storage":
                    return new StorageDal() as T;
                    break;
                case "Stores":
                    return new StorageDal() as T;
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}
