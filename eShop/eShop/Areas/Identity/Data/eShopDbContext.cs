using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.Areas.Identity.Data;
using eShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eShop.Data
{
    public class eShopDbContext : IdentityDbContext<eShopUser>
    {
        public eShopDbContext(DbContextOptions<eShopDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
