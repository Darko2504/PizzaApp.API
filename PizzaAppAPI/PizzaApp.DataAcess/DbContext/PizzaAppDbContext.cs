using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzaApp.Domain.Entities;

namespace PizzaApp.DataAcess.DbContext
{
    public class PizzaAppDbContext : IdentityDbContext<User>
    {
        public PizzaAppDbContext(DbContextOptions options) : base(options) 
        {
            //Pri sekoj start ja brise i ja rekreira bazata.
            //Idealno koga ja gradime na pocetok 
            //Database.EnsureDeleted(); 
            //Database.EnsureCreated(); 
        }

        public DbSet<Pizza> Pizza { get;set; }
        public DbSet<Order> Order{ get;set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Fluent api
            //Table relationships
            //property constraints

            #region Relationships

           

            builder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Pizza>()
                .HasOne(u => u.User)
                .WithMany(p => p.Pizzas)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Order>()
                .HasMany(p => p.Pizzas)
                .WithOne(o => o.Order)
                .HasForeignKey(o => o.OrderId);

            builder.Entity<Order>()
                .HasKey(k => k.Id);

            builder.Entity<Order>()
                .Property(a => a.AdressTo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Entity<Order>()
                .Property(a => a.Description)
                .HasMaxLength(50);

            builder.Entity<Order>()
                .Property(a => a.OrderPrice)
                .IsRequired();



            builder.Entity<Pizza>()
                .HasKey(k => k.Id);

            builder.Entity<Pizza>()
                .Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Entity<Pizza>()
                .Property(p => p.Description)
                .HasMaxLength(500);

            builder.Entity<Pizza>()
                .Property(p => p.Price)
                .IsRequired();
            #endregion

        }
    }
}
