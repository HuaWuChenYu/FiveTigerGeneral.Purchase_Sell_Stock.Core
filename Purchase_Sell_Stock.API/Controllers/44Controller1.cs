using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Purchase_Sell_Stock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class _44Controller1 : ControllerBase
    {
        [HttpGet]
        [Route("/api/aa")]
        public int aa()
        {
            return 11;
        }
    }
}
