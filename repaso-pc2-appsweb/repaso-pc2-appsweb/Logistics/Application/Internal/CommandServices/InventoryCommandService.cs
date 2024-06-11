using repaso_pc2_appsweb.Logistics.Domain.Model.Aggregates;
using repaso_pc2_appsweb.Logistics.Domain.Model.Commands;
using repaso_pc2_appsweb.Logistics.Domain.Model.Repositories;
using repaso_pc2_appsweb.Logistics.Domain.Model.Services;
using repaso_pc2_appsweb.Shared.Domain.Repositories;

namespace repaso_pc2_appsweb.Logistics.Application.Internal.CommandServices;

public class InventoryCommandService (IInventoryRepository inventoryRepository, IUnitOfWork unitOfWork) : IInventoryCommandService
{
    

    public async Task<Domain.Model.Aggregates.Inventory?> Handle(CreateInventoryCommand command)
    {
        var inventory = new Domain.Model.Aggregates.Inventory(command);
        try
        {


            await inventoryRepository.AddAsync(inventory);
            await unitOfWork.CompleteAsync();
            return inventory;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the inventory: {e.Message}");
            return null;
        }
    
    }
}