using AuthAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace AuthAPI.Data
{
    public class DataContext: IdentityDbContext<CustomUser>
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        public DbSet<CustomUser> Users { get; set; }
    }
}
