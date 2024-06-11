using repaso_pc2_appsweb.Logistics.Domain.Model.Queries;

namespace repaso_pc2_appsweb.Logistics.Domain.Model.Services;

public interface IInventoryQueryService
{
    Task<IEnumerable<Aggregates.Inventory>> Handle(GetAllInventoriesQuery query);
    Task<Aggregates.Inventory?> Handle(GetInventoryByIdQuery query);
}