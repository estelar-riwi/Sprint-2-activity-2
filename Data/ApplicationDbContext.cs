using Microsoft.EntityFrameworkCore;
using Sprint2Activity2.Models;

namespace Sprint2Activity2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<Waiter> waiters { get; set; }
        public DbSet<Dish> dishes { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Reservation> reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Waiter>().ToTable("Waiters");
            modelBuilder.Entity<Dish>().ToTable("Dishes");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Reservation>().ToTable("Reservations");
        }
    }
}