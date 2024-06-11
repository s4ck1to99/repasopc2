using repaso_pc2_appsweb.Logistics.Domain.Model.Commands;

namespace repaso_pc2_appsweb.Logistics.Domain.Model.Aggregates;

/**
 * Inventory aggregate root entity.
 *
 * <p>
 * This class represents the Inventory aggregate root entity. It contains the properties and methods to manage the inventory
 * </p>
 */
public partial class Inventory
{
    public int Id { get; set; }
    public string ProductId { get; set; }
    public string WarehouseId { get; set; }

    protected Inventory()
    {
        this.ProductId = string.Empty;
        this.WarehouseId = string.Empty;
    }

    public Inventory(CreateInventoryCommand command)
    {
        this.ProductId = command.ProductId;
        this.WarehouseId = command.WarehouseId;
    }
    
}