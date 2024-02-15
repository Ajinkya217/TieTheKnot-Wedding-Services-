using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TieTheKnot.Models;

namespace TieTheKnot.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<TieTheKnot.Models.VendorInfo>? VendorInfo { get; set; }
        public DbSet<TieTheKnot.Models.UserInfo>? UserInfo { get; set; }

    }
}
