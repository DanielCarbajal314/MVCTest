using LocalDataBaseRepository.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalDataBaseRepository.Context
{
    public class ShopDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ShopDbContext() : base("WebShopLocalDb") { }


    }
}
