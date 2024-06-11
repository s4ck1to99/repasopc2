using repaso_pc2_appsweb.Shared.Domain.Repositories;
using repaso_pc2_appsweb.Logistics.Domain.Model.Aggregates;
namespace repaso_pc2_appsweb.Logistics.Domain.Model.Repositories;

public interface IInventoryRepository : IBaseRepository<Aggregates.Inventory>
{
    Task<Inventory?> FindByIdAsync(int id);
    
}