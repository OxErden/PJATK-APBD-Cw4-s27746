using Microsoft.EntityFrameworkCore;
using WebApplication1.PJATK_APBD_Cw4_s27746.Models;

namespace WebApplication1.PJATK_APBD_Cw4_s27746.Infrastructure;

public class DataBaseContext(DbContextOptions options) : DbContext(options)
{
    
    DbSet<PCs> PCs { get; set; }
    DbSet<Components> Components { get; set; }
    DbSet<ComponentManufacturers> ComponentManufacturers { get; set; }
    DbSet<PCComponents> PCComponents { get; set; }
    DbSet<ComponentTypes> ComponentTypes { get; set; }

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
                
                options.HasMany(p=>p.Components).WithOne(p=>p.ComponentType).HasForeignKey(p=>p.ComponentTypesId);
            }
        );

        modelBuilder.Entity<ComponentManufacturers>(options =>
        {
            options.HasKey(p => p.Id);
            options.ToTable("ComponentManufacturers");
            options.Property(p => p.Abbreviation).HasMaxLength(30);
            options.Property(p => p.FullName).HasMaxLength(300);
            options.Property(p=>p.FoundationDate).HasColumnType("date");

            options.HasMany(p => p.Components).WithOne(p => p.ComponentManufacturer).HasForeignKey
                (p => p.ComponentManufacturersId);
        });

        modelBuilder.Entity<PCComponents>(options =>
        {
            options.HasKey(p => new {p.PCId, p.ComponentCode});
            options.ToTable("PCComponents");
            options.Property(p => p.ComponentCode).HasColumnType("char(10)");
            
            options.HasOne(p => p.PCs).WithMany(p => p.PCcomponents).HasForeignKey(p => p.PCId);
            options.HasOne(p=>p.Components).WithMany(p => p.PCcomponents).HasForeignKey(p=>p.ComponentCode);
        });

        modelBuilder.Entity<Components>(options =>
        {
            options.HasKey(p => p.Code);
            options.ToTable("Components");
            options.Property(p => p.Name).HasMaxLength(300);
        });
    }
    
}



