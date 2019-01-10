using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCartFunctionality.Data
{
    public class ShoppingDbContext:DbContext
    {
        public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options)
            : base(options) { }
        public ShoppingDbContext() { }
        public DbSet<ItemDetails> ItemDetails { get; set; }
    }
}
