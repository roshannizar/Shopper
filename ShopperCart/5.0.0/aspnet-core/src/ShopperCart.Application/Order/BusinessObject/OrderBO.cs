using Abp.Application.Services.Dto;
using ShopperCart.Customer;
using ShopperCart.Customer.BusinessObject;
using ShopperCart.Product;
using ShopperCart.Product.BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopperCart.Order.BusinessObject
{
    public class OrderBO
    {
        public int Id { get; set; }
        public virtual List<OrderLineBO> OrderItems { get; set; }
        public int CustomerId;

        public virtual CustomerBO Customers { get; set; }
        public DateTime Date { get; set; }
        public StatusTypeBO Status;

        public OrderBO()
        {

        }

        public OrderBO Create(int customerId, DateTime dateTime, List<OrderLineBO> orderItemsBO, StatusTypeBO status)
        {
            CustomerId = customerId;
            Date = dateTime;
            OrderItems = orderItemsBO;
            Status = status;

            foreach(var item in orderItemsBO)
            {
                if (item.Quantity == 0)
                {
                    throw new InAdequateProductQuantityException();
                }
            }

            return this;
        }

        public OrderBO Update(OrderBO orderBO, OrderLineBO orderLineBO)
        {
            Id = orderBO.Id;
            CustomerId = orderBO.CustomerId;
            return this;
        }
    }
}
