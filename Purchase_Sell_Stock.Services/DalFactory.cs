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
                case "Customer":
                    return new CustomerDal() as T;
                case "Discount":
                    return new DiscountDal() as T;
                case "Infomation":
                    return new InformationDal() as T;
                case "Login":
                    return new LoginDal() as T;
                case "Order":
                    return new OrderDal() as T;
                case "Goods":
                    return new GoodsDal() as T;
                case "Property":
                    return new PropertyDal() as T;
                case "Procurement":
                    return new ProcurementDal() as T;
                case "Set":
                    return new SetDal() as T;
                case "Storage":
                    return new StorageDal() as T;
                case "Stores":
                    return new StorageDal() as T;
                default:
                    return null;
            }
        }
    }
}
