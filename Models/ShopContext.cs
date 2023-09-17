using Microsoft.EntityFrameworkCore;

namespace FlowerSales.Models
{
    public class ShopContext: DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(flowers => flowers.Products)
                .WithOne(a => a.Category)
                .HasForeignKey(fk => fk.CategoryId);

            modelBuilder.Seed(); // ModelBuilderExtensions.cs
        }
        public DbSet<Product> Products { get; set;}
        public DbSet<Category> Categories { get; set; }
    }
}
