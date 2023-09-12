using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Web.Models;

namespace Web.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
        public DbSet<Cat> Cats { get; set; }
    }
}
