using System;
using System.Collections.Generic;
using System.Text;

namespace ShopperCart.Product
{
    public class InvalidUnitPriceException:Exception
    {
        public InvalidUnitPriceException():base("Unit price is invalid")
        {

        }
    }
}
