using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopperCart.Order.Dto;
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

        public OrderService(IRepository<Models.Order> orderRepository,IRepository<Models.Product> productRepository
            ,IUnitOfWork unitOfWork,IRepository<Models.OrderLine> orderItemRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
            this.orderItemRepository = orderItemRepository;
            this.mapper = mapper;
            productService = new ProductService(productRepository, mapper,unitOfWork);
        }

        public void CreateOrder(OrderDto orderDto)
        {
            try
            {
                foreach (var item in orderDto.OrderItems)
                {
                    //Updating the product
                    productService.Update(item.ProductId, -(item.Quantity));
                }

                OrderDto orderDtoTemp = new OrderDto(orderDto.CustomerId,orderDto.Date,orderDto.OrderItems,orderDto.Status);
                var order = mapper.Map<Models.Order>(orderDtoTemp);
                //This method will add orderlines as well, since this entity has the orderline list
                orderRepository.Insert(order);
                unitOfWork.SaveChanges();
            }
            catch (OrderNotFoundException ex)
            {
                throw ex;
            }
        }

        public void DeleteOrder(int id)
        {
            try
            {
                var orderDto = orderRepository.Get(id);

                if (orderDto == null)
                    throw new OrderNotFoundException();

                var order = mapper.Map<Models.Order>(orderDto);
                //Checks the status type
                if (order.Status == Models.StatusType.Completed)
                {
                    //product quantity will not be update if the status is confirmed
                    orderRepository.Delete(order);
                }
                else
                {
                    //Retrieving the orderLine from the database, so that can get the quantity
                    var orderLineBOTemp = GetOrderLineByOrderId(id);

                    foreach (var temp in orderLineBOTemp)
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

        public IEnumerable<OrderDto> GetOrderById(int id)
        {
            try
            {
                var orders = orderRepository.GetAllIncluding(c => c.Customers, ol => ol.OrderItems).Where(o => o.Id == id);
                var query = mapper.Map<IEnumerable<OrderDto>>(orders);
                return query;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<OrderLineDto> GetOrderLineByOrderId(int id)
        {
            var orderLines = orderItemRepository.GetAllIncluding(p => p.Products).Where(ol => ol.OrderId == id);
            var query = mapper.Map<IEnumerable<OrderLineDto>>(orderLines);
            return query;
        }

        public IEnumerable<OrderDto> GetOrders()
        {
            try
            {
                var orders = orderRepository.GetAllIncluding(c => c.Customers,o => o.OrderItems).ToList();
                var query = mapper.Map<IEnumerable<OrderDto>>(orders);
                return query;
            }
            catch (OrderNotFoundException ex)
            {
                throw ex;
            }
        }

        public OrderDto GetSingleOrderById(int id)
        {
            var query = orderRepository.Get(id);
            return mapper.Map<OrderDto>(query);
        }

        public void UpdateOrder(List<OrderLineDto> orderLineBOs)
        {
            try
            {

                foreach (var item in orderLineBOs)
                {
                    //Retrieving the orderline as temporary to check the database quantity
                    var tempOrderLine = orderItemRepository.Get(item.Id);

                    //Identifying the difference between the updated orderline and database quantity
                    var tempDifference = tempOrderLine.Quantity - item.Quantity;

                    //setting the quantity
                    tempOrderLine.Quantity = item.Quantity;

                    if (item.Quantity == 0)
                    {
                        //If the quantity is zero the order item is deleted
                        DeleteOrderLine(tempOrderLine);
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DeleteOrderLine(Models.OrderLine orderLine)
        {
            if (orderLine == null)
                throw new OrderLineNotFoundException();
            orderItemRepository.Delete(orderLine);
            unitOfWork.SaveChanges();
        }
    }
}
