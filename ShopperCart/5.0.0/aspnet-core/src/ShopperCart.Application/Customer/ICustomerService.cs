using ShopperCart.Customer.BusinessObject;
using System.Collections.Generic;
using System.Linq;

namespace ShopperCart.Customer
{
    public interface ICustomerService
    {
        IEnumerable<CustomerBO> GetCustomers();
    }
}
