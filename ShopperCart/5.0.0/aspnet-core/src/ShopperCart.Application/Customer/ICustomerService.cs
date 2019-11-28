using ShopperCart.Customers.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopperCart.Customer
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetCustomers();
    }
}
