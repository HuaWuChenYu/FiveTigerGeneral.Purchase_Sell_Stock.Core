using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Purchase_Sell_Stock.Model.Storage;
using Purchase_Sell_Stock.Services;

namespace Purchase_Sell_Stock.API.Controllers
{
    public class PropertyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<Amount_settled> PropertyShow(IServiceProvider service) 
        {
            var property = service.GetService<PropertyBll>();
            return property.amount_SettledsShow();
        }
    }
}