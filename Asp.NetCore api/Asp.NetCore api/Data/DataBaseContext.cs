using Asp.NetCore_api.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetCore_api.Data
{
    public class DataBaseContext : DbContext
    {
        //constructor
        public DataBaseContext(DbContextOptions options):base(options)
        {

        }


        public DbSet<Product> Products { set; get; }
        public DbSet<Warehouse> Warehouses { set; get; }

        public DbSet<Order> Order { set; get; }
    }
}
