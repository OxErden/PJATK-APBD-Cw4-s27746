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

        });
    }
    
}



