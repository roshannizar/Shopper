using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using ShopperCart.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopperCart.Product.BusinessObject
{
    public class ProductBO
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        [StringLength(50, ErrorMessage = "Name cannot be too long")]
        public string Name { get; set; }
        [Display(Name = "Product Description")]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double UnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; }

        public ProductBO UpdateQuantity(ProductBO product, int quantity)
        {
            if (product != null)
            {
                Id = product.Id;
                Name = product.Name;
                Description = product.Description;
                UnitPrice = product.UnitPrice;

                if (quantity != 0)
                {
                    Quantity = product.Quantity + quantity;
                }
                else
                {
                    throw new InAdequateProductQuantityException();
                }
            } 
            else
            {
                throw new ProductNotFoundException();
            }
            return this;
        }
    }
}
