using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using repaso_pc2_appsweb.Logistics.Domain.Model.Aggregates;
using repaso_pc2_appsweb.Shared.Infrastracture.Persistence.EFC.Configuration.Extensions;
namespace repaso_pc2_appsweb.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext (DbContextOptions options) : DbContext(options)
{

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Logistics Context

        builder.Entity<Inventory>().HasKey(i => i.Id);
        builder.Entity<Inventory>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Inventory>().Property(i => i.CurrentStock).IsRequired();
        builder.Entity<Inventory>().Property(i => i.MinimumStock).IsRequired();
        builder.Entity<Inventory>().Property(i => i.ProductId).IsRequired();
        builder.Entity<Inventory>().Property(i => i.WarehouseId).IsRequired();

        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}