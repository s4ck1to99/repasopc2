using repaso_pc2_appsweb.Logistics.Interfaces.REST.Resources;

namespace repaso_pc2_appsweb.Logistics.Interfaces.REST.Transform;

public static class InventoryResourceFromEntityAssembler
{
    public static InventoryResource ToResourceFromEntity(Domain.Model.Aggregates.Inventory entity)
    {
        return new InventoryResource(entity.Id,  entity.ProductId, entity.WarehouseId);
    }
}