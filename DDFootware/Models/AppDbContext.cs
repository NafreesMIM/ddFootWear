﻿using Microsoft.EntityFrameworkCore;

namespace DDFootware.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Outlet> Outlets { get; set; }
        public DbSet<OutletStock> OutletStocks { get; set; }
        public DbSet<WebOrder> WebOrders { get; set; }
        public DbSet<PreOrder> PreOrders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AuthenticationToken> AuthenticationTokens { get; set; }
    }

}
