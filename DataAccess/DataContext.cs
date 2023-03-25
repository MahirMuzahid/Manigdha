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

        DbSet<User> Users { get; set; }
        DbSet<BidHistory> BidHistories { get; set; }
        DbSet<CatagoryType> CatagoryTypes { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Division> Divisions { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<PaymentType> PaymentTypes { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductCatagory> ProductCatagories { get; set; }



    }
}
