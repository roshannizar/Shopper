using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopperCart.Controllers;

namespace ShopperCart.Web.Mvc.Controllers
{
    public class CustomerController : ShopperCartControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}