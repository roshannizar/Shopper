using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopperCart.Controllers;
using ShopperCart.Customer;
using ShopperCart.Order;
using ShopperCart.Order.Dto;
using ShopperCart.Product;
using ShopperCart.Web.Models.Order;

namespace ShopperCart.Web.Mvc.Controllers
{
    public class OrderController : ShopperCartControllerBase
    {
        private readonly IOrderService orderService;
        private readonly ICustomerService customerService;
        private readonly IProductService productService;

        public OrderController(IOrderService orderService, ICustomerService customerService,IProductService productService)
        {
            this.orderService = orderService;
            this.customerService = customerService;
            this.productService = productService;
        }
        public IActionResult Index()
        {
            var OrdersDto = orderService.GetOrders();
            var model = ObjectMapper.Map<IEnumerable<OrderViewModel>>(OrdersDto);
            return View(model);
        }

        public IActionResult OrderItems()
        {
            //Loading product to drop down
            ViewBag.ProductList = productService.GetProducts().Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            }).OrderBy(x => x.Text).ToList();

            //Loading customers to drop down
            ViewBag.CustomerList = customerService.GetCustomers().Select(c => new SelectListItem
            {
                Text = c.FirstName + " " + c.LastName,
                Value = c.Id.ToString()
            }).OrderBy(x => x.Text).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody]OrderViewModel orderViewModel)
        {
            try
            {
                orderViewModel.Status = StatusTypeViewModel.Pending;
                var order = ObjectMapper.Map<OrderDto>(orderViewModel);
                //Create Order
                orderService.CreateOrder(order);

                TempData["Message"] = "Order has been added successfully!";
                return RedirectToAction("Index", "Order");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error Occured while creating an Order! " + ex;
                throw new Exception();
            }
        }

        [HttpGet]
        public IActionResult OrderDetail(int id)
        {
            try
            {
                //Loads the orders
                var ordersBO = orderService.GetOrderById(id);
                ViewBag.Order = ObjectMapper.Map<IEnumerable<OrderViewModel>>(ordersBO);
                //Load the status
                var StatusBO = orderService.GetSingleOrderById(id).Status;
                ViewBag.Status = ObjectMapper.Map<StatusTypeViewModel>(StatusBO);

                if (ViewBag.Status != null)
                {
                    var models = orderService.GetOrderLineByOrderId(id);

                    if (models == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        var model = ObjectMapper.Map<IEnumerable<OrderLineViewModel>>(models);
                        return View(model);
                    }
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                TempData["Message"] = "No Order found! " + ex;
                throw new Exception();
            }
        }
    }
}