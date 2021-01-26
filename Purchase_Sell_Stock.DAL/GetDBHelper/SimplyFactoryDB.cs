using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Purchase_Sell_Stock.DAL.GetDBHelper
{
    public class SimplyFactoryDB
    {
        //Tuple  相对于系统自定义的类,有T1,T2...属性,获取时候通过.Item1 .Item2等获取值
        //1.通过传入的字符串判断是否用哪个工厂
        //2.用一个集合来存储所有的工厂和工厂标识(是用来判断哪个工厂的)
        //3.用反正获取所有的工厂子类和工厂标识,并且添加到集合
        //4.循环tlist 判断传入的和工厂标识哪个相同 返回值
        public static List<Tuple<string, DBHelper>> factories = new List<Tuple<string, DBHelper>>();
        /// <summary>
        /// 获取所有子工厂
        /// </summary>
        public static void Fullfactories()
        {
            foreach (Type t in typeof(DBHelper).Assembly.GetTypes())
            {
                if (typeof(DBHelper).IsAssignableFrom(t)&&!t.IsAbstract)
                {
                    factories.Add(Tuple.Create(t.Name.Replace("DBHelper",string.Empty),(DBHelper)Activator.CreateInstance(t)));
                }
            }
        }
        static int count = 1;
        static readonly object obj = new object();
        /// <summary>
        /// 获取工厂实例化
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static DBHelper GetInstance(string name)
        {
            DBHelper _dBHelper = null;
            lock (obj)
            {
                if (count == 1)
                {
                    Fullfactories();
                    count++;
                }
            }
            foreach (Tuple<string,DBHelper> t in factories)
            {
                if (t.Item1==name)
                {
                    _dBHelper = t.Item2;
                }
            }
            return _dBHelper;
        }
    }
}
