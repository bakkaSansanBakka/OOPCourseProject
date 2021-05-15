using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProj.MVVM.Model;
using Microsoft.EntityFrameworkCore;

namespace CourseProj.Context
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //LAPTOP-JA53F0CF
            optionsBuilder.UseSqlServer(
                @"Data Source=LAPTOP-JA53F0CF;Initial Catalog=JewelryStoreDB;Integrated Security=True;Trusted_Connection=True;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<JewelryItem> JewelryItems { get; set; }
        public DbSet<JewelryOrder> JewelryOrders { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<JewelryOrder>()
                .HasKey(t => new { t.JewelryItemId, t.DeliveryId, t.UserId });

            modelBuilder
                .Entity<JewelryOrder>()
                .HasOne(pr => pr.JewelryItem)
                .WithMany(s => s.JewelryOrders)
                .HasForeignKey(pr => pr.JewelryItemId);

            modelBuilder
                .Entity<JewelryOrder>()
                .HasOne(pr => pr.Delivery)
                .WithMany(s => s.JewelryOrders)
                .HasForeignKey(pr => pr.DeliveryId);

            modelBuilder
               .Entity<JewelryOrder>()
               .HasOne(pr => pr.User)
               .WithMany(s => s.JewelryOrders)
               .HasForeignKey(pr => pr.UserId);

        }
    }
}
