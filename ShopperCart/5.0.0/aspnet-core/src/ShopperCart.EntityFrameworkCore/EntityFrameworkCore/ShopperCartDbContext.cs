using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ShopperCart.Authorization.Roles;
using ShopperCart.Authorization.Users;
using ShopperCart.MultiTenancy;

namespace ShopperCart.EntityFrameworkCore
{
    public class ShopperCartDbContext : AbpZeroDbContext<Tenant, Role, User, ShopperCartDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ShopperCartDbContext(DbContextOptions<ShopperCartDbContext> options)
            : base(options)
        {
        }
    }
}
