using System;
using System.Collections.Generic;
using System.Text;

namespace ShopperCart.Customer
{
    public class InvalidCustomerException:Exception
    {
        public InvalidCustomerException():base("Invalid Customer")
        {

        }
    }
}
