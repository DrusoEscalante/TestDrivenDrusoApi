using Microsoft.EntityFrameworkCore;

namespace TestDrivenDrusoApi.Data
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
    }
}
