using repaso_pc2_appsweb.Logistics.Domain.Model.Commands;
using repaso_pc2_appsweb.Logistics.Interfaces.REST.Resources;

namespace repaso_pc2_appsweb.Logistics.Interfaces.REST.Transform;

public static class CreateInventoryCommandFromResourceAssembler
{

    public static CreateInventoryCommand ToCommandFromResource(CreateInventoryResource resource) => 
        new(resource.ProductId, resource.WarehouseId);
}