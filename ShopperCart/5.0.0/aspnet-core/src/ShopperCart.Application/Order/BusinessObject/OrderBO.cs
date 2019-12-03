using Abp.Application.Services.Dto;
using ShopperCart.Customer.BusinessObject;
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
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual CustomerBO Customers { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public StatusTypeBO Status { get; set; }

        public OrderBO()
        {

        }

        public OrderBO(int customerId, DateTime dateTime, List<OrderLineBO> orderItemsBO, StatusTypeBO status)
        {
            this.CustomerId = customerId;
            this.Date = dateTime;
            this.OrderItems = orderItemsBO;
            this.Status = status;
        }

        public bool ValidateOrderItems(OrderLineBO orderItemBO, double unitPrice)
        {
            if(orderItemBO.UnitPrice == unitPrice)
            {
                return true;
            }

            return false;
        }
    }
}
