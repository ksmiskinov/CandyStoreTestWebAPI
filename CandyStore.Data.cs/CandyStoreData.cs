using CandyStore.Domain;
using Microsoft.EntityFrameworkCore;

namespace CandyStore.Data.cs
{
  public class CandyStoreData : DbContext
  {

    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Seller> Сards { get; set; }
    public DbSet<Store> Stores { get; set; }

    public DbSet<Seller> Sellers { get; set; }


    public CandyStoreData(DbContextOptions<CandyStoreData> options)
        : base(options)
    {
      Database.EnsureCreated();
    }

  }
}
