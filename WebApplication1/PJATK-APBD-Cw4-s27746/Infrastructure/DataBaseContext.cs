using Microsoft.EntityFrameworkCore;
using WebApplication1.PJATK_APBD_Cw4_s27746.Models;

namespace WebApplication1.PJATK_APBD_Cw4_s27746.Infrastructure;

public class DataBaseContext(DbContextOptions options) : DbContext(options)
{
    
    public DbSet<PCs> PCs { get; set; }
    public DbSet<Components> Components { get; set; }
    public DbSet<ComponentManufacturers> ComponentManufacturers { get; set; }
    public DbSet<PCComponents> PCComponents { get; set; }
    public DbSet<ComponentTypes> ComponentTypes { get; set; }

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
            options.Property(p => p.Code).HasColumnType("char(10)");
            options.ToTable("Components");
            options.Property(p => p.Name).HasMaxLength(300);
        });
        
        //------------------------seeding------------------------

        modelBuilder.Entity<PCs>().HasData(
            new PCs { Id = 1, Name = "ASUS51287", weight = 10, warranty = 5, created_at = new DateTime(2026, 1, 1), stock = 25 },
            new PCs { Id = 2, Name = "Gaming Beast X", weight = 12, warranty = 36, created_at = new DateTime(2026, 2, 1), stock = 5 },
            new PCs { Id = 3, Name = "Office Mini Pro", weight = 4, warranty = 24, created_at = new DateTime(2026, 3, 1), stock = 12 }
        );

        modelBuilder.Entity<ComponentTypes>().HasData(
            new ComponentTypes { Id = 1, Abbreviation = "CPU", Name = "Central Processing Unit" },
            new ComponentTypes { Id = 2, Abbreviation = "GPU", Name = "Graphics Processing Unit" },
            new ComponentTypes { Id = 3, Abbreviation = "RAM", Name = "Random Access Memory" }
        );

        modelBuilder.Entity<ComponentManufacturers>().HasData(
            new ComponentManufacturers { Id = 1, Abbreviation = "INTEL", FullName = "Intel Corporation", FoundationDate = new DateOnly(1968, 7, 18) },
            new ComponentManufacturers { Id = 2, Abbreviation = "AMD", FullName = "Advanced Micro Devices", FoundationDate = new DateOnly(1969, 5, 1) },
            new ComponentManufacturers { Id = 3, Abbreviation = "NVIDIA", FullName = "Nvidia Corporation", FoundationDate = new DateOnly(1993, 4, 5) }
        );

        modelBuilder.Entity<Components>().HasData(
            new Components { Code = "CPU0000001", Name = "Intel Core i9", Description = "High-end CPU", ComponentManufacturersId = 1, ComponentTypesId = 1 },
            new Components { Code = "GPU0000001", Name = "RTX 4090", Description = "High-end GPU", ComponentManufacturersId = 3, ComponentTypesId = 2 },
            new Components { Code = "RAM0000001", Name = "DDR5 32GB", Description = "Fast RAM", ComponentManufacturersId = 2, ComponentTypesId = 3 }
        );

        modelBuilder.Entity<PCComponents>().HasData(
            new PCComponents { PCId = 1, ComponentCode = "CPU0000001", amount = 1 },
            new PCComponents { PCId = 1, ComponentCode = "GPU0000001", amount = 2 },
            new PCComponents { PCId = 2, ComponentCode = "RAM0000001", amount = 4 }
        );
    }
    
}



