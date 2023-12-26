using Microsoft.EntityFrameworkCore;

namespace PhoneApiSchoolProject.Models;

public class PhoneContext : DbContext
{
    
    public DbSet<PhoneModel> Phones { get; set; }
    public DbSet<OsModel> PhoneOs { get; set; }
    public DbSet<AppsModel> PhoneApps { get; set; }

    public PhoneContext(DbContextOptions<PhoneContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<AppsModel>()
            .HasOne(a => a.CompatibleOs)
            .WithMany(o => o.CompatibleApps)
            .HasForeignKey(a => a.CompatibleOsId);


        modelBuilder.Entity<PhoneModel>()
            .HasOne(p => p.Os)
            .WithMany(o => o.Phones)
            .HasForeignKey(p => p.OsId);
    }

}