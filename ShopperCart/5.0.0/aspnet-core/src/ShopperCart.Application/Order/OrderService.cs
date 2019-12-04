using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopperCart.Order.BusinessObject;
using ShopperCart.Product;

namespace ShopperCart.Order
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Models.Order> orderRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Models.OrderLine> orderItemRepository;
        private readonly ProductService productService;
        private readonly IMapper mapper;

        public OrderService(IRepository<Models.Order> orderRepository, IRepository<Models.Product> productRepository
            , IUnitOfWork unitOfWork, IRepository<Models.OrderLine> orderItemRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
            this.orderItemRepository = orderItemRepository;
            this.mapper = mapper;
            productService = new ProductService(productRepository, mapper, unitOfWork);
        }

        public void CreateOrder(OrderBO orderBO)
        {
            try
            {
                OrderBO orderBOTemp = new OrderBO(orderBO.CustomerId, orderBO.Date, orderBO.OrderItems, orderBO.Status);

                //validate the orderItems
                foreach (var orderItem in orderBO.OrderItems)
                {
                    var product = productService.GetProduct(orderItem.ProductId).UnitPrice;
                    var result = orderBOTemp.ValidateOrderItems(orderItem, product);

                    if (!(result))
                        break;
                }

                foreach (var item in orderBO.OrderItems)
                {
                    //Updating the product
                    productService.Update(item.ProductId, -(item.Quantity));
                }

                
                var order = mapper.Map<Models.Order>(orderBOTemp);

                //This method will add orderlines as well, since this entity has the orderline list
                orderRepository.Insert(order);
                unitOfWork.SaveChanges();
            }
            catch (OrderNotFoundException ex)
            {
                throw ex;
            }
        }

        public void RemoveOrder(int id)
        {
            try
            {
                var orderBO = orderRepository.Get(id);

                if (orderBO == null)
                    throw new OrderNotFoundException();

                var order = mapper.Map<Models.Order>(orderBO);
                //Checks the status type
                if (order.Status == Models.StatusType.Completed)
                {
                    //product quantity will not be update if the status is confirmed
                    orderRepository.Delete(order);
                }
                else
                {
                    //Retrieving the orderLine from the database, so that can get the quantity
                    var orderBOTemp = GetOrderById(id);

                    foreach (var temp in orderBOTemp.OrderItems)
                    {
                        //updates the quantity
                        productService.Update(temp.ProductId, temp.Quantity);
                    }

                    orderRepository.Delete(order);
                }
                //Records will be saved after checking the status type
                unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateOrder(OrderBO orderBO)
        {
            try
            {
                foreach (var item in orderBO.OrderItems)
                {                    
                    if (item.Id != 0)
                    {
                        //updating order and product
                        UpdateOrderWithProduct(orderBO, item);
                    }
                    else
                    {
                        //When the order item doesn't have an id or doesnt know the id of adding the exisitng item, 
                        //this method loads
                        InsertOrUpdateOrderLine(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateOrderWithProduct(OrderBO orderBO, OrderLineBO item)
        {
            //Retrieving the orderline as temporary to check the database quantity
            var tempOrderLine = orderItemRepository.Get(item.Id);
            OrderBO orderbo = new OrderBO();

            //Identifying the difference between the updated orderline and database quantity
            var tempDifference = tempOrderLine.Quantity - item.Quantity;
            //setting the quantity
            tempOrderLine.Quantity = item.Quantity;

            if (item.Quantity == 0)
            {
                //If the quantity is zero the order item is deleted
                RemoveOrderLine(tempOrderLine);
            }
            else
            {
                //updates the orderline
                var order = mapper.Map<Models.OrderLine>(tempOrderLine);
                orderItemRepository.Update(order);
                unitOfWork.SaveChanges();
            }

            //updates the difference quantity
            productService.Update(item.ProductId, tempDifference);
        }

        private void InsertOrUpdateOrderLine(OrderLineBO orderLineBO)
        {
            productService.Update(orderLineBO.ProductId, orderLineBO.Quantity);

            var orderItem = mapper.Map<Models.OrderLine>(orderLineBO);
            orderItemRepository.Insert(orderItem);
            unitOfWork.SaveChanges();
        }

        private void RemoveOrderLine(Models.OrderLine orderLine)
        {
            if (orderLine == null)
                throw new OrderLineNotFoundException();
            orderItemRepository.Delete(orderLine);
            unitOfWork.SaveChanges();
        }

        public OrderBO GetOrderById(int id)
        {
            try
            {
                var orders = orderRepository.GetAllIncluding()
                                                .Include(i => i.OrderItems)
                                                    .ThenInclude(i => i.Products)
                                                    .Include(i => i.Customers)
                                                    .First(o => o.Id == id);
                var query = mapper.Map<OrderBO>(orders);
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<OrderBO> GetOrders()
        {
            try
            {
                var orders = orderRepository.GetAllIncluding(c => c.Customers, o => o.OrderItems).ToList();

                if (orders != null)
                {
                    var query = mapper.Map<IEnumerable<OrderBO>>(orders);
                    return query;
                }
                else
                {
                    throw new OrderNotFoundException();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
