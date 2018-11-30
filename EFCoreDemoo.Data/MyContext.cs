using EFCoreDemo.domain;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemoo.Data
{
  public class MyContext:DbContext
  {
    public MyContext(DbContextOptions<MyContext> options):base(options)
    {
      
    }

    public DbSet<Province> Provinces { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<CityCompany> CityCompanies { get; set; }
    public DbSet<Company> Companies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<CityCompany>()
        .HasKey(x => new {x.CompanyId, x.CityId});

      modelBuilder.Entity<CityCompany>()
        .HasOne<City>()
        .WithMany(x => x.CityCompanies)
        .HasForeignKey(x => x.CityId);

      modelBuilder.Entity<CityCompany>()
        .HasOne(x => x.Company)
        .WithMany(x => x.CityCompanies)
        .HasForeignKey(x => x.CompanyId);

      modelBuilder.Entity<Mayor>()
        .HasOne(x => x.City)
        .WithOne(x => x.Mayor)
        .HasForeignKey<Mayor>(x => x.CityId);

      modelBuilder.Entity<City>()
        .HasOne(x => x.Province)
        .WithMany(x => x.Cities)
        .HasForeignKey(x => x.ProvinceId);
    }
  }
}
