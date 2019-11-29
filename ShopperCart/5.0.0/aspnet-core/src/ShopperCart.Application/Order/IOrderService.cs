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
        IEnumerable<OrderDto> GetOrderById(int id);
        IEnumerable<OrderLineDto> GetOrderLineByOrderId(int id);
        OrderDto GetSingleOrderById(int id);
        void CreateOrder(OrderDto order);
        void UpdateOrder(List<OrderLineDto> orderLineBOs);
        void DeleteOrder(int id);
    }
}
