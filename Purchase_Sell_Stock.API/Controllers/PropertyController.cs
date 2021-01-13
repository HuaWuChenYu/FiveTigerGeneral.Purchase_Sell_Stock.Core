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
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PropertyController : Controller
    {
        List<Amount_settled> ss;
        public PropertyController(IServiceProvider service) 
        {
            var property = service.GetService<PropertyBll>();
            //ss= property.amount_SettledsShow();
        }

        [Route("/api/Show")]
        public List<Amount_settled> PropertyShow() 
        {
            return ss;
        }
    }
}