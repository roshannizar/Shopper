using AutoMapper;
using ShopperCart.Customer.BusinessObject;
using ShopperCart.Order.BusinessObject;
using ShopperCart.Product.BusinessObject;
using ShopperCart.Web.Models.Customer;
using ShopperCart.Web.Models.Order;
using ShopperCart.Web.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperCart.Web.AutoMapper
{
    public class ViewModelMapper:Profile
    {
        public ViewModelMapper()
        {
            CreateMap<ProductViewModel, ProductBO>().ReverseMap();
            CreateMap<OrderViewModel, OrderBO>().ReverseMap();
            CreateMap<OrderLineViewModel, OrderLineBO>().ReverseMap();
            CreateMap<OrderViewModel, OrderLineViewModel>().ReverseMap();
            CreateMap<CustomerViewModel, CustomerBO>().ReverseMap();
        }
    }
}
