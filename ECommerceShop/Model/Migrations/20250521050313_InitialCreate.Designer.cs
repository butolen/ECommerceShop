﻿// <auto-generated />
using ECommerceShop.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerceShop.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20250521050313_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ECommerceShop.Entities.Administrator", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("username");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(15)")
                        .HasColumnName("password");

                    b.HasKey("Username");

                    b.ToTable("administrators");
                });

            modelBuilder.Entity("ECommerceShop.Entities.OrderItem", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<string>("Username")
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("user");

                    b.Property<int>("QuantityOrdered")
                        .HasColumnType("int")
                        .HasColumnName("quantity_ordered");

                    b.HasKey("ProductId", "Username");

                    b.HasIndex("Username");

                    b.ToTable("products_has_users");
                });

            modelBuilder.Entity("ECommerceShop.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("category");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(700)")
                        .HasColumnName("description");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("image");

                    b.Property<int>("InStock")
                        .HasColumnType("int")
                        .HasColumnName("instock");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(5,2)")
                        .HasColumnName("price");

                    b.HasKey("ProductId");

                    b.ToTable("products");
                });

            modelBuilder.Entity("ECommerceShop.Entities.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("reviewid");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("productid");

                    b.Property<int>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("rating");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("username");

                    b.HasKey("ReviewId");

                    b.HasIndex("ProductId");

                    b.HasIndex("Username");

                    b.ToTable("reviews");
                });

            modelBuilder.Entity("ECommerceShop.Entities.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("username");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)")
                        .HasColumnName("address");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(15)")
                        .HasColumnName("password");

                    b.HasKey("Username");

                    b.ToTable("users");
                });

            modelBuilder.Entity("ECommerceShop.Entities.OrderItem", b =>
                {
                    b.HasOne("ECommerceShop.Entities.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceShop.Entities.User", "User")
                        .WithMany("OrderItems")
                        .HasForeignKey("Username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ECommerceShop.Entities.Review", b =>
                {
                    b.HasOne("ECommerceShop.Entities.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceShop.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("Username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ECommerceShop.Entities.Product", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("ECommerceShop.Entities.User", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
