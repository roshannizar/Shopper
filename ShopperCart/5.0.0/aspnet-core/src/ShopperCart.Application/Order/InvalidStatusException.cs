using System;
using System.Collections.Generic;
using System.Text;

namespace ShopperCart.Order
{
    public class InvalidStatusException:Exception
    {
        public InvalidStatusException():base("Invalid status entered")
        {

        }
    }
}
