using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ShopperCart.Web.Mvc.Controllers
{
    public class ProductController : Controller
    {
        public ProductController()
        {

        }

        public async Task<ActionResult> Index()
        {
            return View();
        }
    }
}