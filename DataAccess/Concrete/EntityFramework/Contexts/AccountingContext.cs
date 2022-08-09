using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class AccountingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=intern-db.cjq6i1xxy6zz.eu-central-1.rds.amazonaws.com;Database=ProductStockProject2;Uid=sa;Password=VKynM2xF5P9SLFpdHAJk144X0OyyMTFq7fXu9Vw3tBVXeHYY8S");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminOperationClaim> AdminOperationClaims { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        


    }
}
