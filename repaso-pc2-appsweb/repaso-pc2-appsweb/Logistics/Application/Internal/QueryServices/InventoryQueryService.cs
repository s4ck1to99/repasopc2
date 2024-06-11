using repaso_pc2_appsweb.Logistics.Domain.Model.Queries;
using repaso_pc2_appsweb.Logistics.Domain.Model.Repositories;
using repaso_pc2_appsweb.Logistics.Domain.Model.Services;

namespace repaso_pc2_appsweb.Logistics.Application.Internal.QueryServices;

public class InventoryQueryService (IInventoryRepository inventoryRepository) : IInventoryQueryService
{
    public async Task<IEnumerable<Domain.Model.Aggregates.Inventory>> Handle(GetAllInventoriesQuery query)
    {
        return await inventoryRepository.ListAsync();
    }
    public async Task<Domain.Model.Aggregates.Inventory?> Handle(GetInventoryByIdQuery query)
    {
        return await inventoryRepository.FindByIdAsync(query.InventoryId);
    }
}
