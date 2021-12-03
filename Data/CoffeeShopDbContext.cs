using CoffeeShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Data
{
    public class CoffeeShopDbContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<BillLine> BillLines {get;set;}

        public DbSet<Image> Images { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<WebInfo> WebInfos { get; set; }

        public DbSet<CartMap> CartMaps { get; set; }

        public CoffeeShopDbContext(DbContextOptions<CoffeeShopDbContext> options)
            :base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category).WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId).IsRequired(false);

            modelBuilder.Entity<Bill>()
                .HasMany(b => b.BillLines)
                .WithOne(bl => bl.Bill);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Avatar)
                .WithMany().HasForeignKey(c => c.ImageId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.BannerImage)
                .WithMany();

            modelBuilder.Entity<Product>()
                .HasOne(p => p.SmallImage)
                .WithMany();

            modelBuilder.Entity<Bill>()
                .HasOne(b => b.Customer)
                .WithMany(c => c.Bills)
                .HasForeignKey(b => b.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Category>()
                .HasData(
                    new Category { Id = 1, Name = "Loại 1", Note = "Loại này bình thường" },
                    new Category { Id = 2, Name = "Loại 2", Note = "Loại này hơi xịn" },
                    new Category { Id = 3, Name = "Loại 3", Note = "Loại này rất xịn" }
                );

            int Count = 1;
            modelBuilder.Entity<Product>()
                .HasData(
                    new Product { Id = Count, Name = "Hạt coffee loại" + Count++, Price = 250000, CategoryId = 1, Quantity = 100, Weight=550 },
                    new Product { Id = Count, Name = "Hạt coffee loại" + Count++, Price = 220000, CategoryId = 1, Quantity = 100, Weight=550 },
                    new Product { Id = Count, Name = "Hạt coffee loại" + Count++, Price = 240000, CategoryId = 1, Quantity = 100, Weight=350 },
                    new Product { Id = Count, Name = "Hạt coffee loại" + Count++, Price = 150000, CategoryId = 2, Quantity = 100, Weight=250 },
                    new Product { Id = Count, Name = "Hạt coffee loại" + Count++, Price = 350000, CategoryId = 2, Quantity = 100, Weight=250 },
                    new Product { Id = Count, Name = "Hạt coffee loại" + Count++, Price = 650000, CategoryId = 2, Quantity = 100, Weight=250 },
                    new Product { Id = Count, Name = "Hạt coffee loại" + Count++, Price = 550000, CategoryId = 3, Quantity = 100, Weight=250 },
                    new Product { Id = Count, Name = "Hạt coffee loại" + Count++, Price = 225000, CategoryId = 3, Quantity = 100, Weight=250 },
                    new Product { Id = Count, Name = "Hạt coffee loại" + Count++, Price = 255000, CategoryId = 3, Quantity = 100, Weight=500 }
                );

            Count = 1;
            modelBuilder.Entity<CartMap>()
                .HasData(
                    new CartMap { Id = Count, ProductId = Count++, UserId = "7764bb69-5b0d-483c-9ef8-90b84d09936a" },
                    new CartMap { Id = Count, ProductId = Count++, UserId = "7764bb69-5b0d-483c-9ef8-90b84d09936a" },
                    new CartMap { Id = Count, ProductId = Count++, UserId = "7764bb69-5b0d-483c-9ef8-90b84d09936a" },
                    new CartMap { Id = Count, ProductId = Count++, UserId = "99637bc7-e749-4486-aec7-e85da1c59e6b" },
                    new CartMap { Id = Count, ProductId = Count++, UserId = "99637bc7-e749-4486-aec7-e85da1c59e6b" },
                    new CartMap { Id = Count, ProductId = Count++, UserId = "99637bc7-e749-4486-aec7-e85da1c59e6b" }
                );
        }
    }
}
