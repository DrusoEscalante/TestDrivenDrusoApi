using Microsoft.EntityFrameworkCore;
using TestDrivenDrusoApi.models;

namespace TestDrivenDrusoApi.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<CustomerModel> Customers { get; set; }

    }
   
}
