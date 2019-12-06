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
        private readonly ProductService productService;
        private readonly IMapper mapper;

        public OrderService(IRepository<Models.Order> orderRepository, IRepository<Models.Product> productRepository
            , IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            productService = new ProductService(productRepository, mapper, unitOfWork);
        }

        public void CreateOrder(OrderBO orderBO)
        {
            try
            {
                var orderBOTemp = orderBO.Create(orderBO.CustomerId, orderBO.Date, orderBO.OrderItems, orderBO.Status);

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
                var order = orderRepository.Get(id);

                if (order == null)
                    throw new OrderNotFoundException();

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
                var orderTemp = orderRepository.GetAllIncluding().Include(i => i.OrderItems).First(o => o.Id == orderBO.Id);

                var order = mapper.Map<Models.Order>(orderBO);

                foreach (var item in order.OrderItems.ToList())
                {                    
                    if (item.Id != 0)
                    {
                        var orderItemQuantity = orderTemp.OrderItems.FirstOrDefault(o => o.Id == item.Id).Quantity;
                        var difference = orderItemQuantity - item.Quantity;
                        orderTemp.OrderItems.FirstOrDefault(o => o.Id == item.Id).Quantity = item.Quantity;

                        if (item.IsDeleted)
                        {
                            //Remove the orderline
                            var orderItem = orderTemp.OrderItems.FirstOrDefault(o => o.Id == item.Id);
                            orderTemp.OrderItems.Remove(orderItem);
                        }

                        //updates the difference quantity
                        productService.Update(item.ProductId, difference);
                    }
                    else
                    {
                        productService.Update(item.ProductId, item.Quantity);
                        orderTemp.OrderItems.Add(item);
                    }

                    //updates the order
                    orderRepository.Update(orderTemp);
                    unitOfWork.SaveChanges();
                }
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
    }
}
