using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopperCart.Controllers;
using ShopperCart.Customer;
using ShopperCart.Web.Models.Customer;

namespace ShopperCart.Web.Mvc.Controllers
{
    public class CustomerController : ShopperCartControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public IActionResult Index()
        {
            var customerBOs = customerService.GetCustomers();
            var model = ObjectMapper.Map<IEnumerable<CustomerViewModel>>(customerBOs);
            return View(model);
        }
    }
}