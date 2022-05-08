using CoffeeCafe.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeCafe.Data
{
    public class CustomerDbContext : DbContext
   {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        { }

        public DbSet<Customer> Customer { get; set; }
    }
}