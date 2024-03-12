using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SystemTest.Data;

public class UserSystemTestContext : IdentityDbContext<IdentityUser>
{
    public UserSystemTestContext(DbContextOptions<UserSystemTestContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin",
                NormalizedName = "admin",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Employee",
                NormalizedName = "employee",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }
            );
    }
}
