using _148103_148214.PizzaPicker.CORE;
using _148103_148214.PizzaPicker.INTERFACES.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace _148103_148214.PizzaPicker.DAO
{
    public class PizzaPickerContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Pizzeria> Pizzerias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizzeria>().HasData(
                SeedData.GetPizzerias());
            modelBuilder.Entity<Pizza>().HasData(
                SeedData.GetPizzas());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(AppConfig.Instance.ConnectionString);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PizzaPickerDb;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
