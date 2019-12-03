using AutoMapper;
using ShopperCart.Customer.BusinessObject;
using ShopperCart.Product.BusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopperCart.Order.BusinessObject
{
    public class OrderBOMapper:Profile
    {
        public OrderBOMapper()
        {
            CreateMap<OrderBO, Models.Order>().ReverseMap();
            CreateMap<OrderLineBO, Models.OrderLine>().ReverseMap();
            CreateMap<OrderBO, OrderLineBO>().ReverseMap();
            CreateMap<Models.Order, Models.OrderLine>().ReverseMap();
        }
    }
}
