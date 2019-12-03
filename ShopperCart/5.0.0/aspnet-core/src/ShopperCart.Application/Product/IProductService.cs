using ShopperCart.Product.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopperCart.Product
{
    public interface IProductService
    {
        IEnumerable<ProductBO> GetProducts();
        ProductBO GetProduct(int id);
        void Create(ProductBO product);
        void Update(int productId, int quantity);
    }
}
