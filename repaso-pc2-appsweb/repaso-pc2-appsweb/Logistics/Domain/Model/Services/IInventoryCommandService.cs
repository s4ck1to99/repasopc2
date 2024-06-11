using repaso_pc2_appsweb.Logistics.Domain.Model.Commands;
using repaso_pc2_appsweb.Logistics.Domain.Model.Aggregates;

namespace repaso_pc2_appsweb.Logistics.Domain.Model.Services;

public interface IInventoryCommandService
{
    Task<Inventory?> Handle(CreateInventoryCommand command);
}