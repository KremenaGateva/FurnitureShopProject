namespace WebStore.Data
{
    using System;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using WebStore.Models;

    public class WebStoreContext : IdentityDbContext<User>
    {
        public WebStoreContext(DbContextOptions<WebStoreContext> options)
            :base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrdersProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Orders)
                .WithOne(po => po.Product)
                .HasForeignKey(po => po.ProductId);


            modelBuilder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithOne(po => po.Order)
                .HasForeignKey(po => po.OrderId);

            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.ShoppingCart)
                .WithOne(sh => sh.Buyer)
                .HasForeignKey<ShoppingCart>(sh => sh.BuyerId);
                
        }

    }
}
