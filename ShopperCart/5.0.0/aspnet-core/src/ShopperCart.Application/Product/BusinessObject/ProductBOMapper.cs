using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopperCart.Product.BusinessObject
{
    public class ProductBOMapper:Profile
    {
        public ProductBOMapper()
        {
            CreateMap<ProductBO, Models.Product>().ReverseMap();
        }
    }
}
