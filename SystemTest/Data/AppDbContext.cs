using Microsoft.EntityFrameworkCore;
using SystemTest.Models;

namespace SystemTest.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Category> categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {  
                    Id = 1,
                    Name = "Human Resorces"
                }, new Category()
                {
                    Id=2,
                    Name="Product Manager"
            });
            base.OnModelCreating(modelBuilder);
            foreach ( var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

    }
}
