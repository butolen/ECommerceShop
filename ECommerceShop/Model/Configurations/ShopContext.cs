using ECommerceShop.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceShop.Configurations;

public class ShopContext : DbContext
{
   public DbSet<Review> Reviews { get; set; }
   public DbSet<User> Users { get; set; }
   public DbSet<Product> Products { get; set; }
   public DbSet<OrderItem> OrderItems { get; set; }
   
   public DbSet<DeletedUser> DeletedUsers { get; set; }
   public DbSet<Administrator> Administrators { get; set; }

    public ShopContext(DbContextOptions<ShopContext> options): base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Product)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(oi => oi.ProductId);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.User)
            .WithMany(u => u.OrderItems)
            .HasForeignKey(oi => oi.Username);

        // Review
        modelBuilder.Entity<Review>()
            .HasOne(r => r.Product)
            .WithMany(p => p.Reviews)
            .HasForeignKey(r => r.ProductId);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.Username);
        modelBuilder.Entity<Review>()
            .Property(r => r.ReviewId)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<OrderItem>()
            .HasKey(o => new { o.ProductId, o.Username });
    }

}