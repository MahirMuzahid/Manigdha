using Microsoft.EntityFrameworkCore;
using SharedModal.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<BidHistory> BidHistories { get; set; }
        public DbSet<CatagoryType> CatagoryTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCatagory> ProductCatagories { get; set; }
        public DbSet<NonDigitalProductImageVerification> NonDigitalProductImageVerifications { get; set; }
        public DbSet<ClothsRequirmentVerification> ClothsRequirmentVerifications { get; set; }



    }
}
