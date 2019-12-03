using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.Domain.Repositories;
using AutoMapper;
using ShopperCart.Customer.BusinessObject;

namespace ShopperCart.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Models.Customer> repository;
        private readonly IMapper mapper;

        public CustomerService(IRepository<Models.Customer> repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<CustomerBO> GetCustomers()
        {
            var customer = repository.GetAll();

            var query = mapper.Map<IEnumerable<CustomerBO>>(customer);
            return query;
        }
    }
}
