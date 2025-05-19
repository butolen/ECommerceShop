using ECommerceShop.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceShop.Configurations;

public class ShopContext : DbContext
{
    DbSet<reviews> Reviews { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<OrderItem> OrderItems { get; set; }
    DbSet<Administrator> Administrators { get; set; }

    public ShopContext(DbContextOptions<ShopContext> options): base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<reviews>()
            .HasOne<Product>() 
            .WithMany()
            .HasForeignKey("productId") 
            .OnDelete(DeleteBehavior.Cascade);


        builder.Entity<Product>()
            .HasOne<User>() 
            .WithMany()
            .HasForeignKey("user") 
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<OrderItem>()
            .HasOne(oi => oi.Product)
            .WithMany()
            .HasForeignKey(oi => oi.ProductProductId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<OrderItem>()
            .HasOne(oi => oi.User)
            .WithMany()
            .HasForeignKey(oi => oi.UsersUsername)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<reviews>()
            .Property(r => r.reviewId)
            .ValueGeneratedOnAdd();
    }

}