using Microsoft.EntityFrameworkCore;
using WebApplication1.PJATK_APBD_Cw4_s27746.Models;

namespace WebApplication1.PJATK_APBD_Cw4_s27746.Infrastructure;

public class DataBaseContext(DbContextOptions options) : DbContext(options)
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PCs>(options =>
        {
            options.HasKey(p => p.Id);
            options.ToTable("PCs");
            options.Property(p => p.Name).HasMaxLength(50);
            options.Property(p => p.weight).HasColumnType("float(5)");
            options.Property(p => p.created_at).HasColumnType("datetime");
        });

        modelBuilder.Entity<ComponentTypes>(options =>
            {
                options.HasKey(p => p.Id);
                options.ToTable("ComponentTypes");
                options.Property(p => p.Abbreviation).HasMaxLength(30);
                options.Property(p => p.Name).HasMaxLength(150);
            }
        );

        modelBuilder.Entity<ComponentManufacturers>(options =>
        {
            options.HasKey(p => p.Id);
            options.ToTable("ComponentManufacturers");
            options.Property(p => p.Abbreviation).HasMaxLength(30);
            options.Property(p => p.FullName).HasMaxLength(300);
            options.Property(p=>p.FoundationDate).HasColumnType("date");
        });

        modelBuilder.Entity<PCComponents>(options =>
        {
            options.HasKey(p => p.PCId);
            options.ToTable("PCComponents");
            options.Property(p => p.ComponentCode).HasColumnType("char(10)");
        });

        modelBuilder.Entity<Components>(options =>
        {
            options.HasKey(p => p.Code);
            options.ToTable("Components");
            options.Property(p => p.Name).HasMaxLength(300);
        });
    }
    
}



