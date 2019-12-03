using ShopperCart.Order.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopperCart.Order
{
    public interface IOrderService
    {
        IEnumerable<OrderBO> GetOrders();
        OrderBO GetOrderById(int id);
        void CreateOrder(OrderBO order);
        void UpdateOrder(OrderBO orderBOs);
        void RemoveOrder(int id);
    }
}
