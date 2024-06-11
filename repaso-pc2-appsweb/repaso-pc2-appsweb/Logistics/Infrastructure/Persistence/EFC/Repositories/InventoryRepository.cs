using repaso_pc2_appsweb.Logistics.Domain.Model.Repositories;
using repaso_pc2_appsweb.Shared.Infrastracture.Persistence.EFC.Configuration;
using repaso_pc2_appsweb.Shared.Infrastracture.Persistence.EFC.Repositories;
using repaso_pc2_appsweb.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace repaso_pc2_appsweb.Logistics.Infrastructure.Persistence.EFC.Repositories;

public class InventoryRepository : BaseRepository<Domain.Model.Aggregates.Inventory>, IInventoryRepository
{
    public InventoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Domain.Model.Aggregates.Inventory?> FindByIdAsync(int id)
    {
        return await Context.Set<Domain.Model.Aggregates.Inventory>().FindAsync(id);
    }
}