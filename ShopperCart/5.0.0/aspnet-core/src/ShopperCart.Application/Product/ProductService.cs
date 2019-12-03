using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using ShopperCart.Customer;
using ShopperCart.Product.BusinessObject;


namespace ShopperCart.Product
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Models.Product> repository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IRepository<Models.Product> repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public void Create(ProductBO productDto)
        {
            try
            {
                if (productDto != null)
                {
                    var product = mapper.Map<Models.Product>(productDto);
                    repository.Insert(product);
                    unitOfWork.SaveChanges();
                }
                else
                {
                    throw new ProductNotFoundException();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ProductBO GetProduct(int id)
        {
            try
            {
                var query = repository.Get(id);
                return mapper.Map<ProductBO>(query);
            }
            catch (ProductNotFoundException)
            {
                throw new ProductNotFoundException();
            }
        }

        public IEnumerable<ProductBO> GetProducts()
        {
            var product = repository.GetAll();
            var query = mapper.Map<IEnumerable<ProductBO>>(product);
            return query;
        }

        public void Update(int productId, int quantity)
        {
            try
            {
                var productBO = repository.Get(productId);

                if (productBO.Quantity > 0)
                {

                    if (productBO != null)
                    {
                        productBO.Quantity = productBO.Quantity + quantity;
                    }
                    else
                    {
                        throw new ProductNotFoundException();
                    }

                    var product = mapper.Map<Models.Product>(productBO);
                    repository.Update(product);
                    unitOfWork.SaveChanges();
                }else
                {
                    throw new InAdequateProductQuantityException();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
