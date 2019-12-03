using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopperCart.Customer.BusinessObject
{
    public class CustomerBOMapper:Profile
    {
        public CustomerBOMapper()
        {
            CreateMap<CustomerBO, Models.Customer>().ReverseMap();
        }
    }
}
