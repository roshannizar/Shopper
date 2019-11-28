using AutoMapper;
using ShopperCart.Product.Dto;
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
            CreateMap<ProductViewModel, ProductDto>().ReverseMap();
        }
    }
}
