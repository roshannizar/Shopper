using Abp.Application.Services.Dto;
using ShopperCart.Product;
using ShopperCart.Product.BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopperCart.Order.BusinessObject
{
    public class OrderLineBO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual ProductBO Products { get; set; }

        public int OrderId { get; set; }
        public virtual OrderBO Orders { get; set; }
        
        private int _Quantity;

        public int Quantity 
        {
            get
            {
                return this._Quantity;
            }
            set 
            {
                this._Quantity = value;
            } 
        }

        private double _UnitPrice;

        public double UnitPrice
        {
            get
            {
                return this._UnitPrice;
            }
            set
            {
                this._UnitPrice = value;
            }
        }

        public bool IsDeleted { get; set; }

        public OrderLineBO()
        {

        }

        public OrderLineBO Create(int productId, int orderId, double unitPrice, int quantity)
        {
            ProductId = productId;
            OrderId = orderId;
            _UnitPrice = unitPrice;
            _Quantity = quantity;
            return this;
        }

        public OrderLineBO Update(int productId, int orderId, double unitPrice, int quantity,int updatedQuantity)
        {
            ProductId = productId;
            OrderId = orderId;
            _UnitPrice = unitPrice;
            _Quantity = quantity + updatedQuantity;
            return this;
        }
    }
}