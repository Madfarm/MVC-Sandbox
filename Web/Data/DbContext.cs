using Microsoft.Extensions.Options;
using System.Data.Entity;
using Web.Models;

namespace Web.Data
{
    public class DbContext
    {
        public DbContext(): base() { }
        public DbSet<Cat> Cats { get; set; }
    }
}
