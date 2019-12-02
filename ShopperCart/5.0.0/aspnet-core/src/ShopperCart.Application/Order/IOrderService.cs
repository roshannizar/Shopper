using ShopperCart.Order.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopperCart.Order
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetOrders();
        OrderDto GetOrderById(int id);
        void CreateOrder(OrderDto order);
        void UpdateOrder(OrderDto orderBOs);
        void RemoveOrder(int id);
    }
}
