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
                @"Data Source=LAPTOP-JA53F0CF;Initial Catalog=JewelryStoreDB;Integrated Security=True;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<JewelryItem> JewelryItems { get; set; }
        public DbSet<JewelryOrder> JewelryOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasMany(p => p.JewelryOrders)
                .WithOne(e => e.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<JewelryItem>()
                .HasMany(p => p.JewelryOrders)
                .WithOne(e => e.JewelryItem)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<JewelryOrder>()
                .HasKey(a => a.Id);

            modelBuilder
                .Entity<JewelryOrder>()
                .HasOne(pr => pr.JewelryItem)
                .WithMany(s => s.JewelryOrders)
                .HasForeignKey(pr => pr.JewelryItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
               .Entity<JewelryOrder>()
               .HasOne(pr => pr.User)
               .WithMany(s => s.JewelryOrders)
               .HasForeignKey(pr => pr.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
