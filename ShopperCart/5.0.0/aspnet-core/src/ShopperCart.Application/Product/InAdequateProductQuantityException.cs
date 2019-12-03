using System;
using System.Collections.Generic;
using System.Text;

namespace ShopperCart.Product
{
    public class InAdequateProductQuantityException:Exception
    {
        public InAdequateProductQuantityException():base("InAdequate quantity to update the product")
        {

        }
    }
}
